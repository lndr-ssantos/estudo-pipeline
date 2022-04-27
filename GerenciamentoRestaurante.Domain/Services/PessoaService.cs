using GerenciamentoRestaurante.Domain.Dtos;
using GerenciamentoRestaurante.Domain.Entities;
using GerenciamentoRestaurante.Domain.Interfaces.Repositories;
using GerenciamentoRestaurante.Domain.Interfaces.Services;
using GerenciamentoRestaurante.Domain.ViewModels;
using GerenciamentoRestaurante.Shared.Exceptions;
using GerenciamentoRestaurante.Shared.Helpers;

namespace GerenciamentoRestaurante.Domain.Services;

public class PessoaService : IPessoaService
{
    private readonly IPessoaRepository _pessoaRepository;

    public PessoaService(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }

    public async Task<PessoaViewModel> Adicionar(PessoaDto pessoaDto)
    {
        var novaPessoa = new Pessoa(pessoaDto);

        var (senha, salt) = SecurityHelper.CriptografarSenha(pessoaDto.Usuario.Senha);
        novaPessoa.Usuario.AdicionarSenha(senha, salt);

        await _pessoaRepository.AdicionarAsync(novaPessoa);
        await _pessoaRepository.SalvarAsync();

        return new PessoaViewModel(novaPessoa);
    }

    public async Task<PessoaViewModel> Atualizar(int id, PessoaDto pessoaDto)
    {
        var pessoa = await _pessoaRepository.ObterPorIdAsync(id);

        if (pessoa == null)
        {
            throw new BusinessException("Pessoa não encontrada");
        }

        pessoa.Atualizar(pessoaDto);

        _pessoaRepository.Atualizar(pessoa);
        await _pessoaRepository.SalvarAsync();

        return new PessoaViewModel(pessoa);
    }

    public async Task<IList<PessoaViewModel>> Obter()
    {
        var pessoas = await _pessoaRepository.ObterAsync();

        return pessoas.Select(pessoa => new PessoaViewModel(pessoa)).ToList();
    }

    public async Task<PessoaViewModel> Obter(int id)
    {
        var pessoa = await _pessoaRepository.ObterPorIdAsync(id);
        
        if (pessoa == null)
        {
            throw new BusinessException("Pessoa não encontrada");
        }

        return new PessoaViewModel(pessoa);
    }

    public async Task<bool> Remover(int id)
    {
        var pessoa = await _pessoaRepository.ObterPorIdAsync(id);
        
        if (pessoa == null)
        {
            throw new BusinessException("Pessoa não encontrada");
        }
        
        _pessoaRepository.Remover(pessoa);
        await _pessoaRepository.SalvarAsync();

        return true;
    }
}
