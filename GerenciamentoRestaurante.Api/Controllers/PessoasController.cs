using GerenciamentoRestaurante.Domain.Dtos;
using GerenciamentoRestaurante.Domain.Interfaces.Services;
using GerenciamentoRestaurante.Shared.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoRestaurante.Api.Controllers;

[ApiController]
[Route("v1/pessoas")]
public class PessoasController : ControllerBase
{
    private readonly IPessoaService _pessoaService;

    public PessoasController(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }

    [HttpPost, Authorize(Policy = StringConstants.JwtAdministrador)]
    public async Task<IActionResult> Adicionar([FromBody] PessoaDto pessoaDto)
    {
        return Ok(await _pessoaService.Adicionar(pessoaDto));
    }
    
    [HttpPut("{id:int}"), Authorize(Policy = StringConstants.JwtAdministrador)]
    public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] PessoaDto pessoaDto)
    {
        return Ok(await _pessoaService.Atualizar(id, pessoaDto));
    }
    
    [HttpGet, Authorize(Policy = StringConstants.JwtGarcom)]
    public async Task<IActionResult> ObterTodos()
    {
        return Ok(await _pessoaService.Obter());
    }
    
    [HttpGet("{id:int}"), Authorize(Policy = StringConstants.JwtGarcom)]
    public async Task<IActionResult> ObterPorId([FromRoute] int id)
    {
        return Ok(await _pessoaService.Obter(id));
    }
    
    [HttpDelete("{id:int}"), Authorize(Policy = StringConstants.JwtAdministrador)]
    public async Task<IActionResult> Remover([FromRoute] int id)
    {
        var result = await _pessoaService.Remover(id);
        return result ? NoContent() : UnprocessableEntity();
    }
}
