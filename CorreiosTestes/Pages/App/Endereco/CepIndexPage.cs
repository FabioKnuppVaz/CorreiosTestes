using CorreiosTestes.Core;
using OpenQA.Selenium;
using System.Dynamic;

namespace CorreiosTestes.Pages.App.Endereco
{
    [Binding]
    public class CepIndexPage
    {
        static string _url = "https://buscacepinter.correios.com.br/app/endereco/index.php";

        By _inputCep = By.Id("endereco");
        By _selectTipo = By.CssSelector("#tipoCEP");
        By _btnBuscar = By.XPath("//button[contains(text(), 'Buscar')]");

        static string _dadosLocator = "//table[@id='resultado-DNEC']/tbody/tr/td";
        By _lblLogradouro = By.XPath(_dadosLocator + "[1]");
        By _lblBairro = By.XPath(_dadosLocator + "[2]");
        By _lblLocalidade = By.XPath(_dadosLocator + "[3]");
        By _lblCep = By.XPath(_dadosLocator + "[4]");

        By _lblAlert = By.Id("mensagem-resultado-alerta");

        SeleniumDsl _seleniumDsl;

        public CepIndexPage(SeleniumDsl seleniumDsl)
        {
            _seleniumDsl = seleniumDsl;
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
