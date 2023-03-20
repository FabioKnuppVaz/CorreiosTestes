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
            WebDriver = new ChromeDriver(path);
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
