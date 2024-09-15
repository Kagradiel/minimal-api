namespace MinimalApi.Domain.ModelViews;

public struct Home
{
    public string Mensagem { get => "Bem vindo a API de veiculos MinimalApi"; }
    public string Docs { get => "/swagger"; }
}