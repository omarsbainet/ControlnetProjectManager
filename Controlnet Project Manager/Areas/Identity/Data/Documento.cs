using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Controlnet_Project_Manager.Areas.Identity.Data
{
    public class DocumentoIncidencia
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("idIncidencia")]
        public Incidencia Incidencia { get; set; }

        public string Nombre { get; set; }
        public string Documento { get; set; }
    }

    public class DocumentoDesarrollo
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("idDesarrollo")]
        public Desarrollo Desarrollo { get; set; }

        public string Nombre { get; set; }


        public string Documento { get; set; }
    }
    
    public class DocumentoPeticion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("idPeticion")]
        public Peticion Peticion { get; set; }
        public string Nombre { get; set; }
        public string Documento { get; set; }
    }

    public class DocumentoProyecto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("idProyecto")]

        public Proyecto Proyecto { get; set; }

        public string Nombre { get; set; }

        public string Documento { get; set; }   
    }
}
