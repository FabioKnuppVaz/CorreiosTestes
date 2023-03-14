using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowExample.Core;

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

        public string Text()
        {
            string text = "";
            int retry = 0;

            while (String.IsNullOrEmpty(text) || retry <= 100)
            {
                text = _iWebElement.Text;
                retry++;
            }

            return text;
        }
    }
}
