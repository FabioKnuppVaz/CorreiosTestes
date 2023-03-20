using CorreiosTestes.Core;
using OpenQA.Selenium;
using System.Dynamic;

namespace CorreiosTestes.Pages.App.Endereco
{
    [Binding]
    public class CepIndexPage
    {
        private string _url;

        private static By _inputCep = By.Id("endereco");
        private static By _selectTipo = By.CssSelector("#tipoCEP");
        private static By _btnBuscar = By.XPath("//button[contains(text(), 'Buscar')]");

        private static string _dadosLocator = "//table[@id='resultado-DNEC']/tbody/tr/td";
        private static By _lblLogradouro = By.XPath(_dadosLocator + "[1]");
        private static By _lblBairro = By.XPath(_dadosLocator + "[2]");
        private static By _lblLocalidade = By.XPath(_dadosLocator + "[3]");
        private static By _lblCep = By.XPath(_dadosLocator + "[4]");

        private static By _lblAlert = By.Id("mensagem-resultado-alerta");

        private SeleniumDsl _seleniumDsl;

        public CepIndexPage(SeleniumDsl seleniumDsl, ScenarioContext scenarioContext)
        {
            _seleniumDsl = seleniumDsl;
            _url = scenarioContext.Get<dynamic>("env").urlCep;
        }

        public void AcessarSistema()
        {
            _seleniumDsl.GoToUrl(_url);
        }

        public void BuscarCep(string cep, string tipo)
        {
            _seleniumDsl.FindElement(_inputCep).SendKeys(cep);
            _seleniumDsl.FindElement(_selectTipo).SelectByText(tipo);
            _seleniumDsl.FindElement(_btnBuscar).Click();
        }

        public dynamic DadosBusca()
        {
            dynamic dados = new ExpandoObject();
            dados.logradouro = _seleniumDsl.FindElement(_lblLogradouro).Text();
            dados.bairro = _seleniumDsl.FindElement(_lblBairro).Text();
            dados.localidade = _seleniumDsl.FindElement(_lblLocalidade).Text();
            dados.cep = _seleniumDsl.FindElement(_lblCep).Text();

            return dados;
        }

        public string Alert()
        {
            return _seleniumDsl.FindElement(_lblAlert).Text();
        }
    }
}
