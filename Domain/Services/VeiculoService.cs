using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Entities;
using MinimalApi.Domain.Interfaces;
using MinimalApi.DTOs;
using MinimalApi.Infraestrutura.Db;

namespace MinimalApi.Services;

public class VeiculoService : IVeiculoService
{
    private readonly DbContexto _context;
    public VeiculoService(DbContexto contexto)
    {
        _context = contexto;
    }

    public void Apagar(Veiculo veiculo)
    {
        _context.Veiculos.Remove(veiculo);
        _context.SaveChanges();
    }

    public void Atualizar(Veiculo veiculo)
    {
        _context.Veiculos.Update(veiculo);
        _context.SaveChanges();
    }

    public Veiculo? BuscaPorID(int id)
    {
        return _context.Veiculos.Where(veiculo => veiculo.Id == id).FirstOrDefault();
    }

    public void Incluir(Veiculo veiculo)
    {
        _context.Veiculos.Add(veiculo);
        _context.SaveChanges();
    }

    public Admin? Login(LoginDTO loginDTO)
    {
        return _context.Admins.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
    }

    public List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null)
    {
        var query = _context.Veiculos.AsQueryable();
        if (!string.IsNullOrEmpty(nome))
        {
            query = query.Where(veiculo => EF.Functions.Like(veiculo.Nome.ToLower(), $"%{nome.ToLower()}%"));
        }
        int itensPorPagina = 10;

        if (pagina != null)
            query = query.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);

        return query.ToList();
    }
}
