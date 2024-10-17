using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Controlnet_Project_Manager.Data;


namespace Controlnet_Project_Manager.Areas.Identity.Data

{
    public class UsuarioProyectos
    {
        public CPMUser Programador { get; set; }
        public List<Proyecto> Proyectos { get; set; }
        public List<DatosProyectos> DatosProyectos { get; set; }

    }
}