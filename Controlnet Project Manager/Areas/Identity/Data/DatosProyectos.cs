using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Controlnet_Project_Manager.Areas.Identity.Data
{
    public class DatosProyectos
    {
        public Proyecto Proyecto { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int horasTrabajadas { get; set; }
        public List<Tecnologia> Tecnologias { get; set; }
    }
}
