using PuppeteerSharp;
using PuppeteerSharp.Input;

const string url = "file///D:/Demo/html/index.html";

await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultChromiumRevision);
var browser = await Puppeteer.LaunchAsync(new LaunchOptions
{
    Headless = false,
    DefaultViewport = null
});

var delay = 100;
var page = await browser.NewPageAsync();
page.Request += Page_Request;
page.Response = += Page_response;
await page.GoToAsync(url);


var firstNameSelector = "#firstName";
await page.WaitForSelectorAsync(firstNameSelector);
await TypeFieldValue(page, firstNameSelector, "MyFirstName", delay);

var lastNameSelector = "#lastName";
await TypeFieldValue(page, lastNameSelector, "MyLastName", delay);


static async Task TypeFieldValue(Page page, string fieldSelector, string value, int delay = 0)
{
    await page.FocusAsync(fieldSelector);
    await page.TypeAsync(fieldSelector, value, new TypeOptions { Delay = delay });
    await page.Keyboard.PressAsync("Tab");
}
