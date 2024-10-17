using Controlnet_Project_Manager.Pages.PanelUsuarios;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controlnet_Project_Manager.Areas.Identity.Data;

public class Equipo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column(TypeName = "VARCHAR")]
    [StringLength(255)]
    public string Nombre { get; set; }

    public virtual List<EquiposProyecto> Equipos { get; set; }

    public virtual List<ProgramadoresEquipos> Programadores { get; set; }
}