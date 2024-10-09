using ScreenshotMaker;

using var rendered = new ImageRenderer();

Console.WriteLine("Podaj URL strony:");
string url = Console.ReadLine();  

if (!string.IsNullOrWhiteSpace(url))
{
	await rendered.GetDataAndImagesFromURL(url);  
	await rendered.CreateScreen(url);  

	Console.WriteLine("Screenshot saved!");
}
else
{
	Console.WriteLine("Nie podano poprawnego URL!");
}

Console.WriteLine("Wait for me: ");
Console.Read();