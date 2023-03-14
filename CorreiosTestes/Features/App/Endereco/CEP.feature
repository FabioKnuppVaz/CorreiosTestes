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
        
