using CorreiosTestes.Core;
using SpecFlowExample.Core;

namespace SpecFlowExample.Hooks
{
    [Binding]
    public class Hooks
    {
        private WebDriverFactory _webDriverFactory;
        private dynamic _env;

        public Hooks(WebDriverFactory webDriverFactory)
        {
            _webDriverFactory = webDriverFactory;
        }

        [BeforeScenario]
        public void Setup(JsonParse jsonParse, ScenarioContext scenarioContext)
        {
            string envVar = Environment.GetEnvironmentVariable("AMBIENTE");

            envVar ??= "dev";

            _env = jsonParse.ToDynamic("../../../" + envVar + ".json");

            scenarioContext["env"] = _env;
        }

        [BeforeScenario("CHROME")]
        public void Chrome()
        {
            _webDriverFactory.SetDriver(Drivers.CHROMEDRIVER, (string)_env.pathChromedriver);
        }

        [AfterScenario]
        public void TearDown()
        {
            _webDriverFactory.Quit();
        }
    }
}
