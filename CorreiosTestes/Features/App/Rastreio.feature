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