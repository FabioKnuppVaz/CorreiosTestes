## Testes
[![api tests](https://github.com/FabioKnuppVaz/CorreiosTestes/actions/workflows/main.yml/badge.svg?branch=master)](https://github.com/FabioKnuppVaz/CorreiosTestes/actions/workflows/main.yml)

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

## Fuxo de desenvolvimento e debug ##
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
	"pathChromedriver": ".\\chromedriver"
}
```
O chromedriver nao foi versionado por ser um arquivo executavel e a versao do seu navegador depende de uma versao compativel do chromedriver. Portanto e mais viavel o download direto e a extracao no diretorio que pode ser configuravel.

No github actions temos o acionamento do script main.yml em .github\workflows que realizará a versão mais recente do chromedriver, e logo em seguida irá instalar a versão mais atual do navegador.
```
name: 'Dotnet Tests'

on:
  workflow_dispatch:
    inputs:
      specflow_tags:
        description: 'Specflow Tags'
        required: true
        default: 'CHROME'
  push:
    branches:
      - master

jobs:
  build:
    runs-on: ubuntu-latest

    steps:
      - uses: actions/checkout@v3
      - shell: bash
        run: |
            chmod +x ./CorreiosTestes/Scripts/download.sh
                     ./CorreiosTestes/Scripts/download.sh
      - name: Setup .NET Core SDK 6.0.x
        uses: actions/setup-dotnet@v3
        with:
          dotnet-version: '6.0.x'
      - name: Restore
        run: dotnet restore
      - name: Build
        run: dotnet build
      - name: Automatic commit test
        if: ${{ github.event.inputs.specflow_tags == '' }}
        run: 'dotnet test --filter Category=CHROME'
      - name: Manual Test
        if: ${{ github.event.inputs.specflow_tags != '' }}
        run: 'dotnet test --filter Category=${{ github.event.inputs.specflow_tags }}'
```
O script roda automaticamente a cada push na branch master. Também é possivel rodar os testes manualmente seguindo caminho do github actions em "Actions -> Dotnet Tests -> Run workflow". 
Por default é chamado a tag "Chrome" mas pode ser substituido por exemplo por "SMOKE".

## Parametrizacao dos testes  ##
Sao realizadas as parametrizacoes nos arquivos de feature
```
#language: pt
@CHROME @RASTREIO
Funcionalidade: Rastreamento

    Esquema do Cenario: Validar rastreamento
        Dado acessar a pagina de busca por rastreio
        Quando realizar a busca do rastreio <IDENTIFICADOR>
        Entao validar o retorno

    @POSITIVO @SMOKE
    Exemplos:
        | IDENTIFICADOR |
        | SS987654321BR |
```

```
#language: pt
@CHROME @CEP
Funcionalidade: Busca de CEP

    Esquema do Cenario: Validar busca de CEP
        Dado acessar a pagina de buca por cep
        Quando realizar a busca do CEP <CEP>, <TIPO>
        Entao validar o retorno <CEP>, <LOGRADOURO>, <BAIRRO>, <LOCALIDADE>, <ALERT>
    
    @NEGATIVO
    Exemplos:
        | CEP       | TIPO  | LOGRADOURO                          | BAIRRO | LOCALIDADE   | ALERT                |
        | 80700-000 | Todos |                                     |        |              | Dados não encontrado |

    @POSITIVO @SMOKE
    Exemplos:
        | CEP       | TIPO  | LOGRADOURO                          | BAIRRO | LOCALIDADE   | ALERT                |
        | 01013-001 | Todos | Rua Quinze de Novembro - lado ímpar | Centro | São Paulo/SP |                      |
```

O framework trabalha com injecao de dependencia podendo ser carregado os dados assim como as url's utilizando o objeto [ScenarioContext](https://docs.specflow.org/projects/specflow/en/latest/Bindings/ScenarioContext.html)

## Execução dos teste  ##
Utilizar o gerenciador de testes do visual studio ou utilizar tanto comando do nunit de console ou specflow.
