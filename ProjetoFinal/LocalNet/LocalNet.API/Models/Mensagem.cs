using System;
using LocalNet.API.Models;

namespace LocalNet.API.Models;

public class Mensagem
{
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    public string UsuarioId { get; set; }
    public string GrupoId { get; set; }
    public string? Text { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; }
}