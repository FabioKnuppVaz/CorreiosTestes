using CorreiosTestes.Pages.App.Endereco;
using NUnit.Framework;

namespace CorreiosTestes.StepDefinitions.App.Endereco
{
    [Binding]
    public class CepIndexSteps
    {
        CepIndexPage indexPage;

        public CepIndexSteps(CepIndexPage indexPage)
        {
            this.indexPage = indexPage;
        }

        [Given(@"acessar a pagina de buca por cep")]
        public void AcessarAPaginaDeBucaPorCep()
        {
            indexPage.AcessarSistema();
        }

        [When(@"realizar a busca do CEP (.*), (.*)")]
        public void RealizarABuscaDoCEP(string cep, string tipo)
        {
            indexPage.BuscarCep(cep, tipo);
        }

        [Then(@"validar o retorno (.*), (.*), (.*), (.*), (.*)")]
        public void VerificarORetorno(string cep, string logradouro, string bairro, string localidade, string informacao)
        {
            if (String.IsNullOrEmpty(informacao))
            {
                dynamic dados = indexPage.DadosBusca();

                Assert.That(logradouro, Is.EqualTo((string)dados.logradouro));
                Assert.That(bairro, Is.EqualTo((string)dados.bairro));
                Assert.That(localidade, Is.EqualTo((string)dados.localidade));
                Assert.That(cep, Is.EqualTo((string)dados.cep));
            }
            else
            {
                Assert.That(informacao, Is.EqualTo(indexPage.Alert()));
            }
        }

    }
}
