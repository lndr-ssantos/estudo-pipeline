using GerenciamentoRestaurante.Domain.Dtos;
using GerenciamentoRestaurante.Domain.Interfaces.Services;
using GerenciamentoRestaurante.Shared.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoRestaurante.Api.Controllers;

[ApiController]
[Route("v1/pedidos")]
public class PedidosController : ControllerBase
{
    private IPedidoService _pedidoService;

    public PedidosController(IPedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    [HttpPost, Authorize(Policy = StringConstants.JwtGarcom)]
    public async Task<IActionResult> Cadastrar([FromBody] PedidoDto pedidoDto)
    {
        return Ok(await _pedidoService.Adicionar(pedidoDto));
    }
    
    [HttpPut("{id:int}"), Authorize(Policy = StringConstants.JwtGarcom)]
    public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] PedidoDto pedidoDto)
    {
        return Ok(await _pedidoService.Atualizar(id, pedidoDto));
    }
    
    [HttpGet, Authorize(Policy = StringConstants.JwtGarcom)]
    public async Task<IActionResult> ObterTodos()
    {
        return Ok(await _pedidoService.Obter());
    }
    
    [HttpGet("{id:int}"), Authorize(Policy = StringConstants.JwtGarcom)]
    public async Task<IActionResult> ObterPorId([FromRoute] int id)
    {
        return Ok(await _pedidoService.Obter(id));
    }
    
    [HttpDelete("{id:int}"), Authorize(Policy = StringConstants.JwtAdministrador)]
    public async Task<IActionResult> Remover([FromRoute] int id)
    {
        var result = await _pedidoService.Remover(id);
        return result ? NoContent() : UnprocessableEntity();
    }
}
