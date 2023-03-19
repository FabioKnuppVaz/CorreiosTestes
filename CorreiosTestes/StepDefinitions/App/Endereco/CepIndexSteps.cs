using CorreiosTestes.Pages.App.Endereco;
using NUnit.Framework;

namespace CorreiosTestes.StepDefinitions.App.Endereco
{
    [Binding]
    public class CepIndexSteps
    {
        CepIndexPage _indexPage;

        public CepIndexSteps(CepIndexPage indexPage)
        {
            _indexPage = indexPage;
        }

        [Given(@"acessar a pagina de buca por cep")]
        public void AcessarAPaginaDeBucaPorCep()
        {
            _indexPage.AcessarSistema();
        }

        [When(@"realizar a busca do CEP (.*), (.*)")]
        public void RealizarABuscaDoCEP(string cep, string tipo)
        {
            _indexPage.BuscarCep(cep, tipo);
        }

        [Then(@"validar o retorno (.*), (.*), (.*), (.*), (.*)")]
        public void VerificarORetorno(string cep, string logradouro, string bairro, string localidade, string alert)
        {
            if (String.IsNullOrEmpty(alert))
            {
                dynamic dados = _indexPage.DadosBusca();

                Assert.That(logradouro, Is.EqualTo((string)dados.logradouro));
                Assert.That(bairro, Is.EqualTo((string)dados.bairro));
                Assert.That(localidade, Is.EqualTo((string)dados.localidade));
                Assert.That(cep, Is.EqualTo((string)dados.cep));
            }
            else
            {
                Assert.That(alert, Is.EqualTo(_indexPage.Alert()));
            }
        }

    }
}
