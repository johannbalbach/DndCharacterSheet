using DndCharacterSheetAPI.Application.Interfaces;
using DndCharacterSheetAPI.Application.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DndCharacterSheetAPI.Services
{
    public class ExternalSystemService : IExternalSystemService
    {
        private readonly HttpClient _httpClient;

        public ExternalSystemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<int>> RollDiceAsync(int numberOfDice, int minValue, int maxValue)
        {
            var url = $"http://www.random.org/integers/?num={numberOfDice}&min={minValue}&max={maxValue}&col=1&base=10&format=plain&rnd=new";
            var response = await _httpClient.GetStringAsync(url);

            var result = new List<int>();
            var lines = response.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                if (int.TryParse(line, out var value))
                {
                    result.Add(value);
                }
            }

            return result;
        }
        public async Task<string> GenerateImageAsync(string prompt)
        {
            var options = new ChromeOptions();
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--headless");

            using var driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://huggingface.co/spaces/stabilityai/stable-diffusion-3-medium");

            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.TagName("iframe")));
            }
            catch (WebDriverTimeoutException)
            {

            }

            var inputBox = new WebDriverWait(driver, TimeSpan.FromSeconds(20))
                .Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/gradio-app/div/div/div[1]/div/div/div/div[2]/div/label/input")));

            inputBox.SendKeys(prompt);

            var runButton = new WebDriverWait(driver, TimeSpan.FromSeconds(20))
                .Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button#component-5")));
            runButton.Click();

            await Task.Delay(1000);
            bool imageGenerated = false;
            while (!imageGenerated)
            {
                try
                {
                    var progressElement = driver.FindElement(By.CssSelector("div.progress-text"));
                    await Task.Delay(1000);
                }
                catch (NoSuchElementException)
                {
                    imageGenerated = true;
                }
            }

            var imageElement = driver.FindElement(By.CssSelector("div.image-container img"));
            var imageUrl = imageElement.GetAttribute("src");

            return imageUrl;
        }

        public async Task DownloadImageAsync(string url)
        {
            Guid fileId = Guid.NewGuid();
            string path = $"{Constants.FileSavePath}/{fileId}.webp";

            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                await using var fs = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), path), FileMode.CreateNew);
                await response.Content.CopyToAsync(fs);
            }
        }

        public async Task GenerateAndSaveImageAsync(string prompt)
        {
            var imageUrl = await GenerateImageAsync(prompt);
            await DownloadImageAsync(imageUrl);
        }
    }
}
