using Controlnet_Project_Manager.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Controlnet_Project_Manager.Areas.Identity.Data;
public class Desarrollo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Nombre { get; set; }
    public string? Informacion { get; set; }

    [ForeignKey("idAutor")]
    public CPMUser Autor { get; set; }

    [ForeignKey("idEstadoDesarrollo")]
    public EstadoDesarrollo EstadoDesarrollo { get; set; }
    
    [ForeignKey("idPadre")]
    public Desarrollo? Padre { get; set; }
    
    public virtual List<Desarrollo>? Hijos { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaEntrega { get; set; }
    public DateTime? FechaFinalizacion { get; set; }

    [ForeignKey("idProyecto")]
    public Proyecto Proyecto { get; set; }

    [ForeignKey("idUsuarioAsignado")]
    public CPMUser UsuarioAsignado { get; set; }
}
