using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Controlnet_Project_Manager.Areas.Identity.Data;

public class Cliente
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Nombre { get; set; }

    public string? Correo { get; set; }

    public string? PaginaWeb { get; set; }

    public string? NombreContacto { get; set; }

    public string? Telefono { get; set; }

}
