using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Controlnet_Project_Manager.Data;

namespace Controlnet_Project_Manager.Areas.Identity.Data;

public class ProgramadoresEquipos
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [ForeignKey("IdUsuario")]
    public CPMUser Programador { get; set; }
    [ForeignKey("IdEquipo")]
    public Equipo Equipo { get; set; }
}