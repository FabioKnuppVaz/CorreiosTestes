using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowExample.Core;
using SeleniumExtras.WaitHelpers;

namespace CorreiosTestes.Core
{
    [Binding]
    public class SeleniumDsl
    {
        IWebDriver _webDriver;
        IWebElement _iWebElement;

        public SeleniumDsl(WebDriverFactory webDriverFactory)
        {
            _webDriver = webDriverFactory.GetWebDriver();
        }

        public void GoToUrl(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
        }

        public SeleniumDsl FindElement(By by)
        {
            WaitVisible(by);
            _iWebElement = _webDriver.FindElement(by);
            return this;
        }

        public SeleniumDsl SendKeys(string text)
        {
            _iWebElement.SendKeys(text);
            return this;
        }

        public SeleniumDsl SelectByText(string text)
        {
            new SelectElement(_iWebElement).SelectByText(text);
            return this;
        }

        public SeleniumDsl Click()
        {
            _iWebElement.Click();
            return this;
        }

        public void WaitVisible(By by)
        {
            WebDriverWait wait = new (_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public string Text()
        {
            return _iWebElement.Text;
        }
    }
}
