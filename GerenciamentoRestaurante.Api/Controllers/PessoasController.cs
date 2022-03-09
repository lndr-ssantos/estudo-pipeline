using System.Threading.Tasks;
using GerenciamentoRestaurante.Domain.Dtos;
using GerenciamentoRestaurante.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoRestaurante.Api.Controllers;

[ApiController]
[Route("v1/pessoas")]
public class UsuariosController : ControllerBase
{
    private readonly IPessoaService _pessoaService;

    public UsuariosController(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar([FromBody] PessoaDto pessoaDto)
    {
        return Ok(await _pessoaService.Adicionar(pessoaDto));
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] PessoaDto pessoaDto)
    {
        return Ok(await _pessoaService.Atualizar(id, pessoaDto));
    }
    
    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        return Ok(await _pessoaService.Obter());
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObterPorId([FromRoute] int id)
    {
        return Ok(await _pessoaService.Obter(id));
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Remover([FromRoute] int id)
    {
        var result = await _pessoaService.Remover(id);
        return result ? NoContent() : UnprocessableEntity();
    }
}
