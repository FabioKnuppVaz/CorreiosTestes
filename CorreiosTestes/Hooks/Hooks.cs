using SpecFlowExample.Core;

namespace SpecFlowExample.Hooks
{
    [Binding]
    public class Hooks
    {
        WebDriverFactory _webDriverFactory;

        public Hooks(WebDriverFactory webDriverFactory)
        {
            _webDriverFactory = webDriverFactory;
        }

        [BeforeScenario]
        public void Setup()
        {
            _webDriverFactory.SetWebDriver();
        }

        [AfterScenario]
        public void TearDown()
        {
            _webDriverFactory.Quit();
        }
    }
}
