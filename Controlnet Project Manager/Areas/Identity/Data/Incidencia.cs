using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Controlnet_Project_Manager.Data;

namespace Controlnet_Project_Manager.Areas.Identity.Data;

public class Incidencia
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Nombre { get; set; }
    public string? Informacion { get; set; }
    
    [ForeignKey("idEstadoIncidencia")]
    public EstadoIncidencia EstadoIncidencia { get; set; }

    [ForeignKey("idAutor")]
    public CPMUser Autor { get; set; }
    
    [ForeignKey("idPadre")]
    public Incidencia? Padre { get; set; }
    
    public virtual List<Incidencia>? Hijos { get; set; }

    public DateTime FechaCreacion { get; set; }
    
    public DateTime? FechaCerrada { get; set; }
    
    [ForeignKey("idProyecto")]
    public Proyecto Proyecto { get; set; }
    
    [ForeignKey("idUsuarioAsignado")]
    public CPMUser UsuarioAsignado { get; set; }
}