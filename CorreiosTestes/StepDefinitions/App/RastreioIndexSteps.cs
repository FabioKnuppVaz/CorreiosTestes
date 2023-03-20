using CorreiosTestes.Pages.App;
using NUnit.Framework;

namespace CorreiosTestes.StepDefinitions.App
{
    [Binding]
    public class RastreioIndexSteps
    {
        private RastreioIndexPage _rastreioIndexPage;

        public RastreioIndexSteps(RastreioIndexPage rastreioIndexPage)
        {
            _rastreioIndexPage = rastreioIndexPage;
        }

        [Given(@"acessar a pagina de busca por rastreio")]
        public void AcessarAPaginaDeBuscaPorRastreio()
        {
            _rastreioIndexPage.AcessarSistema();
        }

        [When(@"realizar a busca do rastreio (.*)")]
        public void RealizarABuscaDoRastreioSSBR(string codigo)
        {
            _rastreioIndexPage.BuscarRastreio(codigo);
        }

        [Then(@"validar o retorno")]
        public void ValidarORetorno()
        {
            string mensagem = _rastreioIndexPage.MensagemCaptcha();
            if (mensagem.Equals("Preencha o campo captcha"))
            { 
                Assert.Fail("Teste falhando ate liberacao do captcha");
            }
        }
    }
}
