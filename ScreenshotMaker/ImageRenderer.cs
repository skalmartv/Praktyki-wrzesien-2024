using HtmlAgilityPack;
using PuppeteerSharp;

namespace ScreenshotMaker
{
	public class ImageRenderer : IDisposable
	{
		private BrowserFetcher _browserFetcher;
		private static readonly string[] options = new[] { "--window-size=3840,2160" };

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

				if (imgTags != null)
				{
					foreach (var img in imgTags)
					{
						var altText = img.GetAttributeValue("alt", "brak atrybutu alt");
						altList.Add($"Alt: {altText}");
					}
				}
				Console.WriteLine("Znalezione obrazy:");
				foreach (var alt in altList)
				{
					Console.WriteLine(alt);
				}

				Console.WriteLine("=======================================================================");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
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