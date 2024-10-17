using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Controlnet_Project_Manager.Data;

namespace Controlnet_Project_Manager.Areas.Identity.Data;

public class EstadoIncidencia
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Nombre { get; set; }

    [Column(TypeName = "BIT")]
    public bool CierraIncidencia { get; set; }
    
    public string Color { get; set; }
    
    [Column(TypeName = "BIT")]
    
    public bool Notificar { get; set; }
    
    [ForeignKey("idUsuarioAutor")]
    public CPMUser? Autor { get; set; }

    [Column(TypeName = "BIT")]
    public bool EstadoCl { get; set; }
}