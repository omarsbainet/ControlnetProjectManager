using Heron.MudCalendar;
using MudBlazor;

namespace Controlnet_Project_Manager.Areas.Identity.Data
{
    public class CustomItemCalendar : CalendarItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ColorEstado { get; set; }
        public string Color { get; set; }
        public string TipoFecha { get; set; }
        public string DescripcionFecha { get; set; }
        public string Icono { get; set; }
    }
}
