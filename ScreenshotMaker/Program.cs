using ScreenshotMaker;

Console.WriteLine("Podaj URL strony:");
string url = Console.ReadLine(); 

using var rendered = new ImageRenderer();

await rendered.GetImageAltsFromURL(url);  
await rendered.CreateScreen(url);  
Console.WriteLine("Wait for me: ");
Console.Read();