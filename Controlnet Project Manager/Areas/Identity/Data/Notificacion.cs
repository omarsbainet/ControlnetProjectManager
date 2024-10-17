using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Controlnet_Project_Manager.Data;

namespace Controlnet_Project_Manager.Areas.Identity.Data;

public class Notificacion
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("idUsuario")]
    public CPMUser IDUsuario { get; set; }

    public bool Leida { get; set; }
    public bool Eliminada { get; set; }
    public string Titulo { get; set; }
    public string? Descripcion { get; set; }
    public string? Link { get; set; }
    public int? Index { get; set; }
}