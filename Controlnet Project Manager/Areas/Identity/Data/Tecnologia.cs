using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Controlnet_Project_Manager.Areas.Identity.Data
{
    public class Tecnologia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public bool EstaActivo { get; set; }

        public string Color { get; set; }

    }
}
