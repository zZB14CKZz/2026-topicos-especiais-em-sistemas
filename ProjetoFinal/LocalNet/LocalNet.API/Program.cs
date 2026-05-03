using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using LocalNet.API.Data;
using LocalNet.API.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", () => "Bem vindo ao LocalNet API!");

app.MapGet("/api/mensagem/{grupoId}", ([FromServices] AppDataContext _context, string grupoId) =>
{   
    var mensagens = _context.Mensagens.Where(m => m.GrupoId == grupoId).ToList();

    if(mensagens.Any())
    {
        return Results.Ok(mensagens);
    }
    return Results.NotFound("Nenhuma mensagem encontrada");
});

app.MapPost("/api/mensagem", ([FromServices] AppDataContext _context, [FromBody] Mensagem mensagem) =>
{
    _context.Mensagens.Add(mensagem);
    _context.SaveChanges();
    return Results.Created();
});

app.MapPut("/api/mensagem/{mensagemId}", ([FromServices] AppDataContext _context, string mensagemId, [FromBody] Mensagem mensagem) =>
{
    var mensagemExistente = _context.Mensagens.FirstOrDefault(m => m.Id == mensagemId);

    if (mensagemExistente == null)
    {
        return Results.NotFound("Mensagem não encontrada");
    }

    mensagemExistente.Text = mensagem.Text;
    mensagemExistente.UpdatedAt = DateTime.Now;

    _context.Mensagens.Update(mensagemExistente);
    _context.SaveChanges();
    return Results.Ok(mensagemExistente);
});

app.MapDelete("/api/mensagem/{mensagemId}", ([FromServices] AppDataContext _context, string mensagemId) =>
{
    var mensagem = _context.Mensagens.FirstOrDefault(m => m.Id == mensagemId);
    if (mensagem == null)
    {
        return Results.NotFound("Mensagem não encontrada");
    }

    _context.Mensagens.Remove(mensagem);
    _context.SaveChanges();
    return Results.Ok(mensagem);
});

app.Run();