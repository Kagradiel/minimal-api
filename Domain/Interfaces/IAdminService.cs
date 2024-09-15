using MinimalApi.Domain.Entities;
using MinimalApi.DTOs;

namespace MinimalApi.Domain.Interfaces;

public interface IAdministradorService
{
    Admin? Login(LoginDTO loginDTO);
    Admin Incluir(Admin admin);
    Admin? BuscaPorId(int id);
    List<Admin> Todos(int? pagina);
}