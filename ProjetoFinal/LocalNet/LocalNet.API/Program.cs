using LocalNet.API.Data;
using LocalNet.API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();

app.MapGet("/", () => "API do LocalNet Messenger - Módulo de Usuários!");

app.MapGet("/api/usuario/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Usuarios.Any())
    {
        return Results.Ok(ctx.Usuarios.ToList());
    }

    return Results.NotFound("Nenhum usuário cadastrado.");
});

app.MapGet("/api/usuario/buscar/{id}", ([FromServices] AppDataContext ctx, [FromRoute] string id) =>
{
    foreach (Usuario u in ctx.Usuarios.ToList())
    {
        if (u.Id == id)
        {
            return Results.Ok(u);
        }
    }
    return Results.NotFound("Usuário não encontrado.");
});

app.MapPost("/api/usuario/cadastrar", ([FromServices] AppDataContext ctx, [FromBody] Usuario usuario) =>
{
    ctx.Usuarios.Add(usuario);
    ctx.SaveChanges();
    return Results.Created(usuario);
});

app.MapPut("/api/usuario/atualizar/{id}", ([FromBody] Usuario usuarioAtualizado, [FromServices] AppDataContext ctx, [FromRoute] string id) =>
{
    foreach (Usuario u in ctx.Usuarios.ToList())
    {
        if (u.Id == id)
        {
            u.Nome = usuarioAtualizado.Nome;
            u.Email = usuarioAtualizado.Email;
            u.Telefone = usuarioAtualizado.Telefone;
            u.AtualizadoEm = DateTime.Now;

            ctx.Usuarios.Update(u);
            ctx.SaveChanges();
            return Results.Ok(u);
        }
    }
    return Results.NotFound("Usuário não encontrado.");
});

app.MapDelete("/api/usuario/deletar/{id}", ([FromServices] AppDataContext ctx, [FromRoute] string id) =>
{
    foreach (Usuario u in ctx.Usuarios.ToList())
    {
        if (u.Id == id)
        {
            ctx.Usuarios.Remove(u);
            ctx.SaveChanges();
            return Results.Ok("Usuário deletado.");
        }
    }
    return Results.NotFound("Usuário não encontrado.");
});

app.MapPost("/api/usuario/entrar-grupo", ([FromServices] AppDataContext ctx, [FromBody] UsuarioGrupo ligacao) =>
{
    ctx.UsuarioGrupos.Add(ligacao);
    ctx.SaveChanges();
    return Results.Created(ligacao);
});

app.MapGet("/api/mensagem/listar/{grupoId}", ([FromServices] AppDataContext ctx, [FromRoute] string grupoId) =>
{

    foreach (Mensagem m in ctx.Mensagens.ToList())
    {
        if (m.GrupoId == grupoId)
        {
            return Results.Ok(m);
        }
    }
    return Results.NotFound("Nenhuma mensagem encontrada");
});

app.MapPost("/api/mensagem/cadastrar", ([FromServices] AppDataContext ctx, [FromBody] Mensagem mensagem) =>
{
    ctx.Mensagens.Add(mensagem);
    ctx.SaveChanges();
    return Results.Created();
});

app.MapPut("/api/mensagem/atualizar/{mensagemId}", ([FromServices] AppDataContext ctx, [FromBody] Mensagem mensagem, [FromRoute] string mensagemId) =>
{

    foreach (Mensagem m in ctx.Mensagens.ToList())
    {
        if (m.Id == mensagemId)
        {
            m.Text = mensagem.Text;
            m.AtualizadoEm = DateTime.Now;

            ctx.Mensagens.Update(m);
            ctx.SaveChanges();
            return Results.Ok(m);
        }
    }
    return Results.NotFound("Mensagem não encontrada");
});

app.MapDelete("/api/mensagem/deletar/{mensagemId}", ([FromServices] AppDataContext ctx, [FromRoute] string mensagemId) =>
{
    foreach (Mensagem m in ctx.Mensagens.ToList())
    {
        if (m.Id == mensagemId)
        {
            ctx.Mensagens.Remove(m);
            ctx.SaveChanges();
            return Results.Ok("Mensagem deletada.");
        }
    }
    return Results.NotFound("Mensagem não encontrada");
});

app.Run();