using HtmlAgilityPack;
using PuppeteerSharp;
using System.Net.Http;
using System.IO;

namespace ScreenshotMaker
{
	public class ImageRenderer : IDisposable
	{
		private BrowserFetcher _browserFetcher;
		private static readonly string[] options = new[] { "--window-size=3840,2160" };
		private static readonly string saveFolder = @"C:\Praktyki-wrzesien-2024\ScreenshotMaker";

		public ImageRenderer()
		{
			_browserFetcher = new BrowserFetcher();
		}

		public async Task GetDataAndImagesFromURL(string htmlUrl)
		{
			try
			{
				var client = new HttpClient();
				var html = await client.GetStringAsync(htmlUrl);
				var htmlDoc = new HtmlDocument();
				htmlDoc.LoadHtml(html);

				var linkList = new List<string>();
				var anchorTags = htmlDoc.DocumentNode.SelectNodes("//a[@href]");
				if (anchorTags != null)
				{
					foreach (var tag in anchorTags)
					{
						var link = tag.GetAttributeValue("href", string.Empty);
						if (!string.IsNullOrEmpty(link))
						{
							linkList.Add(link);
						}
					}
				}

				Console.WriteLine("Znalezione linki:");
				foreach (var link in linkList)
				{
					Console.WriteLine(link);
				}
				Console.WriteLine("=======================================================================");

				var imgTags = htmlDoc.DocumentNode.SelectNodes("//img");
				var altList = new List<string>();
				var imgUrls = new List<string>();

				if (imgTags != null)
				{
					foreach (var img in imgTags)
					{
						var altText = img.GetAttributeValue("alt", "brak atrybutu alt");
						altList.Add($"Alt: {altText}");

						var imgUrl = img.GetAttributeValue("src", string.Empty);
						if (!string.IsNullOrEmpty(imgUrl))
						{
							// Jeœli obrazek ma wzglêdny URL, konwertujemy go na pe³ny URL
							if (!Uri.IsWellFormedUriString(imgUrl, UriKind.Absolute))
							{
								var baseUri = new Uri(htmlUrl);
								imgUrl = new Uri(baseUri, imgUrl).ToString();
							}
							imgUrls.Add(imgUrl);
						}
					}
				}

				Console.WriteLine("Znalezione obrazy:");
				foreach (var alt in altList)
				{
					Console.WriteLine(alt);
				}

				Console.WriteLine("=======================================================================");

				// Tworzenie folderu jeœli nie istnieje
				if (!Directory.Exists(saveFolder))
				{
					Directory.CreateDirectory(saveFolder);
				}

				// Pobieranie i zapisywanie obrazów
				await DownloadAndSaveImages(imgUrls);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private async Task DownloadAndSaveImages(List<string> imgUrls)
		{
			var client = new HttpClient();
			int count = 1;

			foreach (var imgUrl in imgUrls)
			{
				try
				{
					Console.WriteLine($"Pobieranie obrazu: {imgUrl}");
					var imgData = await client.GetByteArrayAsync(imgUrl);

					var fileExtension = Path.GetExtension(imgUrl);
					if (string.IsNullOrEmpty(fileExtension))
					{
						fileExtension = ".jpg"; // Domyœlne rozszerzenie, jeœli nie mo¿na okreœliæ
					}

					var fileName = Path.Combine(saveFolder, $"image_{count}{fileExtension}");

					await File.WriteAllBytesAsync(fileName, imgData);

					Console.WriteLine($"Obraz zapisany jako: {fileName}");
					count++;
				}
				catch (Exception ex)
				{
					Console.WriteLine($"B³¹d podczas pobierania obrazu z URL {imgUrl}: {ex.Message}");
				}
			}
		}

		public void Dispose()
		{
			_browserFetcher = null;
		}

		public async Task CreateScreen(string url)
		{
			await _browserFetcher.DownloadAsync();

			using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
			{
				Headless = true,
				DefaultViewport = new ViewPortOptions()
				{
					Width = 2160,
					Height = 3840,
					IsLandscape = false,
				},
				Timeout = 30000, // Ustawienie d³u¿szego timeoutu
				Args = options,
				AcceptInsecureCerts = true,
				EnqueueAsyncMessages = true
			});

			using var page = await browser.NewPageAsync();
			var response = await page.GoToAsync(url, new NavigationOptions
			{
				WaitUntil = new[] { WaitUntilNavigation.Load, WaitUntilNavigation.DOMContentLoaded }
			});

			await page.SetViewportAsync(new ViewPortOptions
			{
				Width = 2160,
				Height = 3840
			});

			// Zrobienie zrzutu ekranu
			await page.ScreenshotAsync(Path.Combine(Directory.GetCurrentDirectory(), "test_image_from_url_2.png"));

			await browser.CloseAsync();

			Console.WriteLine("Screenshot saved!");
		}
	}
}