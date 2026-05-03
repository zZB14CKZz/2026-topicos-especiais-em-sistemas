using LocalNet.API.Data;
using LocalNet.API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Adicionando o contexto do banco de dados
builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();

app.MapGet("/", () => "API do LocalNet Messenger - Módulo de Usuários!");

// POST: Cadastrar Usuário
app.MapPost("/api/usuario/cadastrar", 
    ([FromBody] Usuario usuario, 
    [FromServices] AppDataContext ctx) =>
{
    ctx.Usuarios.Add(usuario);
    ctx.SaveChanges();
    return Results.Created("", usuario);
});

// GET: Listar Usuários
app.MapGet("/api/usuario/listar", 
    ([FromServices] AppDataContext ctx) =>
{
    if(ctx.Usuarios.Any())
    {
        return Results.Ok(ctx.Usuarios.ToList());
    }
    return Results.NotFound("Nenhum usuário cadastrado.");
});

// GET: Buscar Usuário por ID
app.MapGet("/api/usuario/buscar/{id}", 
    ([FromRoute] string id,
    [FromServices] AppDataContext ctx) =>
{
    foreach(Usuario u in ctx.Usuarios.ToList())
    {
        if(u.Id == id)
        {
            return Results.Ok(u);
        }
    }
    return Results.NotFound("Usuário não encontrado.");
});

// PUT: Atualizar Usuário
app.MapPut("/api/usuario/atualizar/{id}", 
    ([FromRoute] string id,
    [FromBody] Usuario usuarioAtualizado,
    [FromServices] AppDataContext ctx) =>
{
    foreach(Usuario u in ctx.Usuarios.ToList())
    {
        if(u.Id == id)
        {
            u.Nome = usuarioAtualizado.Nome;
            u.Email = usuarioAtualizado.Email;
            u.Telefone = usuarioAtualizado.Telefone;
            
            ctx.Usuarios.Update(u);
            ctx.SaveChanges();
            return Results.Ok(u);
        }
    }
    return Results.NotFound("Usuário não encontrado.");
});

// DELETE: Deletar Usuário
app.MapDelete("/api/usuario/deletar/{id}", 
    ([FromRoute] string id,
    [FromServices] AppDataContext ctx) =>
{
    foreach(Usuario u in ctx.Usuarios.ToList())
    {
        if(u.Id == id)
        {
            ctx.Usuarios.Remove(u);
            ctx.SaveChanges();
            return Results.Ok("Usuário deletado.");
        }
    }
    return Results.NotFound("Usuário não encontrado.");
});

// EXTRA: Entrar no grupo
app.MapPost("/api/usuario/entrar-grupo", 
    ([FromBody] UsuarioGrupo ligacao, 
    [FromServices] AppDataContext ctx) =>
{
    ctx.UsuarioGrupos.Add(ligacao);
    ctx.SaveChanges();
    return Results.Created("", ligacao);
});

app.Run();