using Newtonsoft.Json.Linq;
using SpecFlowExample.Core;

namespace SpecFlowExample.Hooks
{
    [Binding]
    public class Hooks
    {
        WebDriverFactory _webDriverFactory;
        ScenarioContext _scenarioContext;

        public Hooks(WebDriverFactory webDriverFactory, ScenarioContext scenarioContext)
        {
            _webDriverFactory = webDriverFactory;
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void Setup()
        {
            string envVar = Environment.GetEnvironmentVariable("AMBIENTE");

            envVar ??= "dev";

            string json = File.ReadAllText("../../../" + envVar + ".json");
            dynamic env = JObject.Parse(json);

            _scenarioContext["urlCep"] = (string)env["urlCep"];
            _scenarioContext["urlRastreio"] = (string)env["urlRastreio"];
            _webDriverFactory.SetChromeDriver((string)env["pathChromedriver"]);
        }

        [AfterScenario]
        public void TearDown()
        {
            _webDriverFactory.Quit();
        }
    }
}
