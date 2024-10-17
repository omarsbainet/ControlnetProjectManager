using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Controlnet_Project_Manager.Data;

namespace Controlnet_Project_Manager.Areas.Identity.Data;

public class Proyecto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(TypeName = "VARCHAR")]
    [StringLength(255)]
    public string Nombre { get; set; }

    [ForeignKey("IdEstado")]
    public Estado Estado { get; set; }
    public DateTime FechaPrevistaEntrega { get; set; }
    public DateTime FechaPrevistaContrato { get; set; }
    public int HorasEstimadas { get; set; }
    public int HorasSemanalesEstimadas { get; set; }
    public virtual List<EquiposProyecto> Equipos { get; set; }
    public virtual List<ProgramadoresProyecto> Programadores { get; set; }


    public virtual List<Incidencia> Incidencias { get; set; }

    public virtual List<Desarrollo> Desarrollos { get; set; }

    public virtual List<Peticion> Peticiones { get; set; }

    [ForeignKey("IdCliente")]
    public Cliente? Cliente { get; set; }

    [ForeignKey("IdUsuarioGitHub")]
    public CPMUser? OwnerRepositorioGithub { get; set; }
    public string? NombreRepositorioGitHub { get; set; }

    public string? Observaciones { get; set; } 

}