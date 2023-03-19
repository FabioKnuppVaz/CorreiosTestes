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
        
