using MinimalApi.Domain.Entities;
using MinimalApi.Domain.Interfaces;
using MinimalApi.DTOs;
using MinimalApi.Infraestrutura.Db;

namespace MinimalApi.Services;

public class AdministradorService : IAdministradorService
{
    private readonly DbContexto _context;
    public AdministradorService(DbContexto contexto)
    {
        _context = contexto;
    }

    public Admin? BuscaPorId(int id)
    {
        return _context.Admins.Where(admin => admin.Id == id).FirstOrDefault();
    }

    public Admin Incluir(Admin admin)
    {
        _context.Admins.Add(admin);
        _context.SaveChanges();

        return admin;
    }

    public Admin? Login(LoginDTO loginDTO)
    {
        return _context.Admins.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
    }

    public List<Admin> Todos(int? pagina)
    {
        var query = _context.Admins.AsQueryable();

        int itensPorPagina = 10;

        if (pagina != null)
            query = query.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);

        return query.ToList();
    }
}
