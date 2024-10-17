using System.ComponentModel;

namespace Controlnet_Project_Manager.Areas.Identity.Data
{
    public enum MenuEnum
    {
        [Description("VistaRentabilidad"), DefaultValue("Vista Rentabilidad")]
        VistaRentabilidad = 21,

        [Description("BalanceHoras"), DefaultValue("Balance horas")]
        BalanceHoras = 20,

        [Description("Reportes"), DefaultValue("Reportes")]
        Reportes = 19,
        
        [Description("Tecnologias"), DefaultValue("Tecnologias")]
        Tecnologias = 18,
        
        [Description("VistaProyecto"), DefaultValue("Vista Proyecto")]
        VistaProyecto = 17,
        
        [Description("VistaTrabajo"), DefaultValue("Vista trabajo")]
        VistaTrabajo = 16,

        [Description("Peticiones"), DefaultValue("Peticiones")]
        Peticiones = 15,

        [Description("Calendario"), DefaultValue("Calendario")]
        Calendario = 14,

        [Description("Informacion"), DefaultValue("Información")]
        Informacion = 13,

        [Description("Desarrollo"), DefaultValue("Desarrollo")]
        Desarrollo = 12,

        [Description("Incidencias"), DefaultValue("Incidencias")]
        Incidencias = 11,

        [Description("Proyectos"), DefaultValue("Ver proyectos")]
        Proyectos = 10,

        [Description("EstadoProyectos"), DefaultValue("Estado de Proyectos")]
        EstadoProyectos = 9,

        [Description("Clientes"), DefaultValue("Clientes")]
        Clientes = 8,

        [Description("ListaEstadosIncidencia"), DefaultValue("Estados de Incidencia")]
        EstadoIncidencia = 7,

        [Description("ListaEstadosDesarrollo"), DefaultValue("Estados de Desarrollo")]
        EstadoDesarrollo = 6,

        [Description("Estados"), DefaultValue("Estados")]
        Estados = 5,

        [Description("Equipos"), DefaultValue("Equipos")]
        Equipos = 4,

        [Description("Roles"), DefaultValue("Roles")]
        Roles = 3,

        [Description("Usuarios"), DefaultValue("Usuarios")]
        Usuarios = 2,

        [Description("Configuración"), DefaultValue("Configuración")]
        Configuracion = 1
    }
}
