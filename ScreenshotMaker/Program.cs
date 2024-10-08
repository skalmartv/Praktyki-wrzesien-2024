using ScreenshotMaker;

using var rendered = new ImageRenderer();


var htmlContent = "https://www.whitepress.com/pl/baza-wiedzy/230/jak-zalozyc-bloga-w-wordpressie-krok-po-kroku";

await rendered.GetDataFromURL(htmlContent);
await rendered.CreateScreen(htmlContent);


Console.WriteLine("Wait for me: ");
Console.Read();