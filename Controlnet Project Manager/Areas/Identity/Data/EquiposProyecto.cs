using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Controlnet_Project_Manager.Areas.Identity.Data
{
    public class EquiposProyecto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("IdEquipo")]
        public Equipo Equipo { get; set; }

        [ForeignKey("IdProyecto")]
        public Proyecto Proyecto { get; set; }

        
    }
}
