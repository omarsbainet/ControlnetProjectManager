using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controlnet_Project_Manager.Areas.Identity.Data;

public class Estado
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Nombre { get; set; }

    public string Color { get; set; }

    public int Orden { get; set; }

    public bool Oculto { get; set; }
}