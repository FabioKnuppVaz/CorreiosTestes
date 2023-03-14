using CorreiosTestes.Pages.App;
using NUnit.Framework;

namespace CorreiosTestes.StepDefinitions.App
{
    [Binding]
    public class RastreioIndexSteps
    {
        RastreioIndexPage rastreioIndexPage;

        public RastreioIndexSteps(RastreioIndexPage rastreioIndexPage)
        {
            this.rastreioIndexPage = rastreioIndexPage;
        }

        [Given(@"acessar a pagina de busca por rastreio")]
        public void AcessarAPaginaDeBuscaPorRastreio()
        {
            rastreioIndexPage.AcessarSistema();
        }

        [When(@"realizar a busca do rastreio (.*)")]
        public void RealizarABuscaDoRastreioSSBR(string codigo)
        {
            rastreioIndexPage.BuscarRastreio(codigo);
        }

        [Then(@"validar o retorno")]
        public void ValidarORetorno()
        {
            string mensagem = rastreioIndexPage.MensagemCaptcha();
            if (mensagem.Equals("Preencha o campo captcha"))
            { 
                Assert.Fail("Teste falhando ate liberacao do captcha");
            }
        }
    }
}
