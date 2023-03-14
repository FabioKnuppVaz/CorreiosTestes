
## Requerimentos ##

- S.O de criação (Windows 10 - 64 bits)
- Navegador de criação (Google Chrome Versão 111.0.5563.65 (Versão oficial) 64 bits)
- [.Net 7.0](https://dotnet.microsoft.com/en-us/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/downloads/)
- [Specflow](https://specflow.org/)
- [Nunit](https://nunit.org/)
- [Selenium](https://www.selenium.dev/)
- [Chromedriver](https://chromedriver.chromium.org/downloads)

## Estrutura de arquivos do framework

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

## Fuxo de desenvolvimento de debug
```
BDD
 └── Hooks
       └── Steps
             └── Pages
```
