Esta aplicação serve para gerenciar o atendimento de um restaurante ou lanchonete. API desenvolvida em .Net 6, utilizando MySQL 8 como banco de dados.

Projeto desenvolvido para estudo.

# Comandos:
## Criar migration
`dotnet ef migrations add [nome da migration] -s .\GerenciamentoRestaurante.Api\ -p .\GerenciamentoRestaurante.Infra\`

## Atualizar banco de dados
`dotnet ef database update -s .\GerenciamentoRestaurante.Api\ -p .\GerenciamentoRestaurante.Infra\`