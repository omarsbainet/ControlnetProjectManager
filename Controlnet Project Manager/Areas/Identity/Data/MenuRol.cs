using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controlnet_Project_Manager.Areas.Identity.Data;

public class MenuRol
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [ForeignKey("IdRol")]
    public Rol Rol { get; set; }
    public int IdMenu { get; set; }

    public bool Crear { get; set; }
    public bool Editar { get; set; }
    public bool Eliminar { get; set; }
    public bool? Terminar { get; set; }

    public bool Aceptar { get; set; }
    public bool Rechazar { get; set; }

}