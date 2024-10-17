using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Controlnet_Project_Manager.Data;

namespace Controlnet_Project_Manager.Areas.Identity.Data;
public class EstadoDesarrollo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Nombre { get; set; }

    [Column(TypeName = "BIT")]
    public bool FinalizacionDesarrollo { get; set; }
    public string Color { get; set; }
    
    [Column(TypeName = "BIT")]
    public bool Notificar { get; set; }
    
    [ForeignKey("idUsuarioAutor")]
    public CPMUser? Autor { get; set; }

    [Column(TypeName = "BIT")]
    public bool EstadoCl { get; set; }

}
