using Controlnet_Project_Manager.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controlnet_Project_Manager.Areas.Identity.Data;

public class EstadoProyectoUsuario
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("IdEstado")]
    public Estado Estado { get; set; }

    [ForeignKey("IdUsuario")]
    public CPMUser Usuario { get; set; }

    public bool isChecked { get; set; }
}

