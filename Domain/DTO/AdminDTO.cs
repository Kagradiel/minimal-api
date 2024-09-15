using MinimalAPI.Domain.Enuns;

namespace MinimalApi.DTOs;

public class AdminDTO
{
    public string Email { get; set; } = default!;
    public string Senha { get; set; } = default!;
    public Perfil? Perfil { get; set; } = default!;
}

