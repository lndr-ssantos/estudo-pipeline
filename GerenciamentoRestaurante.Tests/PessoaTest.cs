using GerenciamentoRestaurante.Domain.Dtos;
using GerenciamentoRestaurante.Domain.Enums;
using GerenciamentoRestaurante.Domain.Interfaces.Repositories;
using GerenciamentoRestaurante.Domain.Services;
using NSubstitute;
using Xunit;

namespace GerenciamentoRestaurante.Tests;

public class PessoaTest
{
    [Fact]
    public void DeveAdicionarPessoa()
    {
        var pessoaRepository = Substitute.For<IPessoaRepository>();
        var pessoaService = new PessoaService(pessoaRepository);

        var pessoaDto = new PessoaDto
        {
            Nome = "Teste",
            Tipo = TipoPessoaEnum.Administrador,
            Usuario = new UsuarioDto
            {
                Login = "login",
                Senha = "1234"
            }
        };
        
        var resultado = pessoaService.Adicionar(pessoaDto);
        
        Assert.NotNull(resultado);
    }
}