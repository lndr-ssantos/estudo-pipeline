using GerenciamentoRestaurante.Domain.Dtos;
using GerenciamentoRestaurante.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoRestaurante.Api.Controllers;

[ApiController]
[Route("v1/login")]
public class LoginController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public LoginController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost, AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        return Ok(await _authenticationService.Autenticar(loginDto));
    }
}