using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controlnet_Project_Manager.Areas.Identity.Data
{
    public class ProyectoTecnologia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("idProyecto")]
        public Proyecto Proyecto { get; set; }

        [ForeignKey("idTecnologia")]
        public Tecnologia Tecnologia { get; set; }
    }
}
