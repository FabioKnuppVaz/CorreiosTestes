using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowExample.Core
{
    [Binding]
    public class WebDriverFactory
    {
        IWebDriver _webDriver;

        public void SetWebDriver()
        {
            _webDriver = new ChromeDriver("C:\\Users\\fabio\\Downloads\\chromedriver");
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(25);
            _webDriver.Manage().Window.Maximize();
        }

        public IWebDriver GetWebDriver()
        {
            return _webDriver;
        }

        public void Quit()
        {
            _webDriver.Quit();
        }
    }
}
