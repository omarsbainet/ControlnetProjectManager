using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Controlnet_Project_Manager.Data;

namespace Controlnet_Project_Manager.Areas.Identity.Data;

public class CheckinCheckout
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column(TypeName = "BIT")]
    public bool Entrada { get; set; }
    public DateTime Fecha { get; set; }
    
    [ForeignKey("IdProyecto")]
    public Proyecto Proyecto { get; set; }
    
    [ForeignKey("IdUsuario")]
    public CPMUser Usuario { get; set; }

}