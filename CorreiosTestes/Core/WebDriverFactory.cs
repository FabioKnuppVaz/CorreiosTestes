using CorreiosTestes.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowExample.Core
{
    [Binding]
    public class WebDriverFactory
    {
        public IWebDriver WebDriver { get; set; }

        public void SetDriver(Drivers drivers, string path)
        {
            switch (drivers)
            {
                case Drivers.CHROMEDRIVER:
                    ChromeDriver(path);
                    break;
            }
        }

        private void ChromeDriver(string path)
        {
            ChromeOptions chromeOptions = new();
            chromeOptions.AddArguments("--no-sandbox");
            chromeOptions.AddArguments("--disable-dev-shm-usage");
            chromeOptions.AddArguments("--headless");
            chromeOptions.AddArguments("--remote-allow-origins=*");

            WebDriver = new ChromeDriver(path, chromeOptions);
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
            WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(25);
            WebDriver.Manage().Window.Maximize();
        }

        public void Quit()
        {
            WebDriver.Quit();
        }
    }
}
