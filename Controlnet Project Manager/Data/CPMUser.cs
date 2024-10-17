using System.ComponentModel.DataAnnotations.Schema;
using Controlnet_Project_Manager.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace Controlnet_Project_Manager.Data;

public class CPMUser : IdentityUser
{
 [ForeignKey("IdRol")]
 public Rol? Rol { get; set; }
 public string Nombre { get; set; }

 [ForeignKey("IdSuperior")]
 public CPMUser? Superior { get; set; }
 public bool Activo { get; set; }
 
 [ForeignKey("IdEquipo")]
 public Equipo? Equipo { get; set; }

public virtual List<ProgramadoresEquipos> Programadores { get; set; }

    public string? UsuarioGitHub { get; set; }
    public string? TokenGitHub { get; set; }

    public int? Coste { get; set; }
    public byte[]? Foto { get; set; }
}

