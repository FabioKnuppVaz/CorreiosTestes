using CorreiosTestes.Core;
using OpenQA.Selenium;

namespace CorreiosTestes.Pages.App
{
    [Binding]
    public class RastreioIndexPage
    {
        string _url = "https://rastreamento.correios.com.br/app/index.php";

        By _inputCodigo = By.Id("objeto");
        By _btnBuscar = By.Id("b-pesquisar");
        By _lblCaptcha = By.CssSelector("body > main > div.container > form > div.jumbotron > div.campos.captcha > div:nth-child(2) > div.mensagem");

        SeleniumDsl _seleniumDsl;

        public RastreioIndexPage(SeleniumDsl seleniumDsl)
        {
            _seleniumDsl = seleniumDsl;
        }

        public void AcessarSistema()
        {
            _seleniumDsl.GoToUrl(_url);
        }

        public void BuscarRastreio(string codigo)
        {
            _seleniumDsl.FindElement(_inputCodigo).SendKeys(codigo);
            _seleniumDsl.FindElement(_btnBuscar).Click();
        }

        public string MensagemCaptcha()
        {
            return _seleniumDsl.FindElement(_lblCaptcha).Text();
        }
    }
}
