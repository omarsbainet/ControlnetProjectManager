using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Controlnet_Project_Manager.Data;
using Microsoft.AspNetCore.Identity;

namespace Controlnet_Project_Manager.Areas.Identity.Data
{
    public class Rol : IdentityRole<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public int Orden { get; set; }
        public virtual List<MenuRol> Menus { get; set; }
        public decimal PorcentajeConversion { get; set; }
        public bool Plantilla { get; set; }
    }
}