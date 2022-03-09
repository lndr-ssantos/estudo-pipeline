using System.Threading.Tasks;
using GerenciamentoRestaurante.Domain.Dtos;
using GerenciamentoRestaurante.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoRestaurante.Api.Controllers;

[ApiController]
[Route("v1/itensCardapio")]
public class ItensCardapioController : ControllerBase
{
    private readonly IItemCardapioService _itemCardapioService;

    public ItensCardapioController(IItemCardapioService itemCardapioService)
    {
        _itemCardapioService = itemCardapioService;
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar([FromBody] ItemCardapioDto itemCardapioDto)
    {
        return Ok(await _itemCardapioService.Adicionar(itemCardapioDto));
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] ItemCardapioDto itemCardapioDto)
    {
        return Ok(await _itemCardapioService.Atualizar(id, itemCardapioDto));
    }
    
    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        return Ok(await _itemCardapioService.Obter());
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObterPorId([FromRoute] int id)
    {
        return Ok(await _itemCardapioService.Obter(id));
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Remover([FromRoute] int id)
    {
        var result = await _itemCardapioService.Remover(id);
        return result ? NoContent() : UnprocessableEntity();
    }
}
