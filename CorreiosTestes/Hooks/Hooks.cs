using CorreiosTestes.Core;
using SpecFlowExample.Core;

namespace SpecFlowExample.Hooks
{
    [Binding]
    public class Hooks
    {
        WebDriverFactory _webDriverFactory;
        ScenarioContext _scenarioContext;
        JsonParse _jsonParse;
        dynamic _env;

        public Hooks(WebDriverFactory webDriverFactory, ScenarioContext scenarioContext, JsonParse jsonParse)
        {
            _webDriverFactory = webDriverFactory;
            _scenarioContext = scenarioContext;
            _jsonParse = jsonParse;
        }

        [BeforeScenario]
        public void Setup()
        {
            string envVar = Environment.GetEnvironmentVariable("AMBIENTE");

            envVar ??= "dev";

            _env = _jsonParse.ToDynamic("../../../" + envVar + ".json");

            _scenarioContext["env"] = _env;
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
