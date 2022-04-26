Esta aplicação serve para gerenciar o atendimento de um restaurante ou lanchonete. API desenvolvida em .Net 6, utilizando MySQL 8 como banco de dados.

Projeto desenvolvido para estudo.

# Comandos:
## Criar migration
`dotnet ef migrations add [nome da migration] -s .\GerenciamentoRestaurante.Api\ -p .\GerenciamentoRestaurante.Infra\`

## Atualizar banco de dados
`dotnet ef database update -s .\GerenciamentoRestaurante.Api\ -p .\GerenciamentoRestaurante.Infra\`

# Usuários

Execute os comandos abaixo para criar o usuário administrador.

`insert into pessoas (Nome, Tipo) values ('Administrador', '1');`

`insert into usuarios (PessoaId, Login, Senha, Ativo, Salt) values ([pessoaId], 'admin', '+LMtqRd1c6XdJZD7/EH377QBvAohfyotTho0+U+G18g=', '1', 'fxV54nbQe5aNOH0a0Zp7bA==');`

As credencias são: admin - 123456