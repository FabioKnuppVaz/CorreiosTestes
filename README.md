
## Requerimentos ##

- S.O de criação (Windows 10 - 64 bits)
- Navegador de criação (Google Chrome Versão 111.0.5563.65 (Versão oficial) 64 bits)
- [.Net 7.0](https://dotnet.microsoft.com/en-us/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/downloads/)
- [Specflow](https://specflow.org/)
- [Nunit](https://nunit.org/)
- [Selenium](https://www.selenium.dev/)
- [Chromedriver](https://chromedriver.chromium.org/downloads)

## Estrutura de arquivos do framework ##

```
├── Core
│    └── Classes de instanciacao e utils
├── Features
│    └── Arquivos de regra de negocio e BDD
├── Hooks
│    └── Inicializacao e finalizacao do fluxo de teste
├── Pages
│    └── Objetos de mapeamentos das telas
├── StepDefinitions
     └── Camada de acoplamento do arquivo de regra de negocio com codigo e validacoes com assertivas
```

## Fuxo de desenvolvimento de debug ##
```
BDD
 └── Hooks
       └── Steps
             └── Pages
```

- Implementar os metodos do selenium na classe SeleniumDsl do diretorio Core e utilize fluent interface.
- Implementar o mapeamento de tela nas classes com terminacao Page no diretorio Page.
- Implementar as acoes das pages nas proprias pages sem fluxo de logica que deve ficar nos steps.
- Implementar a validacao de testes e assertivas nas classes com terminacao Steps no diretorio StepDefinitios.
- Implementar toda regra de negocio com Gherkin nos arquivos .feature no diretorio Features.
- Implementar todos helpers, factories, dsl nos diretorio Core.


## Configuração do framework ##
Utilizar de variaveis de ambiente e criar um arquivo .json com mesmo nome da variavel para ele ser carregado e que esteja dentro do diretório da solucao.  
Caso nao seja setada nenhuma variavel, entao por default sera carregado o arquivo dev.json.
   
Dentro do arquivo temos as urls utilizadas na navegacao e o diretorio onde esta o chromedriver.
```
{
	"urlCep": "https://buscacepinter.correios.com.br/app/endereco/index.php",
	"urlRastreio": "https://rastreamento.correios.com.br/app/index.php",
	"pathChromedriver": "C:\\chromedriver\\chromedriver"
}
```
O chromedriver nao foi versionado por ser um arquivo executavel e a versao do seu navegador depende de uma versao compativel do chromedriver. Portanto e mais viavel o download direto e a extracao no diretorio que pode ser configuravel.

## Parametrizacao dos testes  ##
Sao realizadas as parametrizacoes nos arquivos de feature
```
#language: pt
Funcionalidade: Rastreamento

    @RASTREIO
    Esquema do Cenario: Validar rastreamento
        Dado acessar a pagina de busca por rastreio
        Quando realizar a busca do rastreio <IDENTIFICADOR>
        Entao validar o retorno

    Exemplos:
        | IDENTIFICADOR |
        | SS987654321BR |
```

```
#language: pt
Funcionalidade: Busca de CEP

    @CEP
    Esquema do Cenario: Validar busca de CEP
        Dado acessar a pagina de buca por cep
        Quando realizar a busca do CEP <CEP>, <TIPO>
        Entao validar o retorno <CEP>, <LOGRADOURO>, <BAIRRO>, <LOCALIDADE>, <INFORMACAO>

    Exemplos:
        | CEP       | TIPO  | LOGRADOURO                          | BAIRRO | LOCALIDADE   | INFORMACAO           |
        | 80700-000 | Todos |                                     |        |              | Dados não encontrado |
        | 01013-001 | Todos | Rua Quinze de Novembro - lado ímpar | Centro | São Paulo/SP |                      |
```

O framework trabalha com injecao de dependencia podendo ser carregado os dados assim como as url's utilizando o objeto [ScenarioContext](https://docs.specflow.org/projects/specflow/en/latest/Bindings/ScenarioContext.html)

## Execução dos teste  ##
Utilizar o gerenciador de testes do visual studio
![image](https://user-images.githubusercontent.com/16068350/225189339-91d404e3-5153-4db1-80f7-8c517cff40ba.png)

Ou utilizar tanto comando do nunit de console ou specflow.
