using Controlnet_Project_Manager.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Controlnet_Project_Manager.Areas.Identity.Data;

    public class Peticion
    {

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Nombre { get; set; }
    public string? Informacion { get; set; }

    [ForeignKey("idAutor")]
    public CPMUser Autor { get; set; }

    [ForeignKey("idPadre")]
    public Peticion? Padre { get; set; }
    
    public virtual List<Peticion>? Hijos { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaEntrega { get; set; }
    public DateTime? FechaFinalizacion { get; set; }

    public bool? Aceptado { get; set; } = null;

    public string? Razon { get; set; }

    [ForeignKey("idDesarrollo")]
    public Desarrollo? Desarrollo { get; set; }

    [ForeignKey("idIncidencia")]
    public Incidencia? Incidencia { get; set;}

    [ForeignKey("idProyecto")]
    public Proyecto Proyecto { get; set; }
    }

