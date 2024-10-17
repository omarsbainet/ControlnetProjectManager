using MudBlazor;

namespace Controlnet_Project_Manager.Data
{
    public class MyCustomTheme
    {
        public MudTheme Theme { get; set; }

        public MyCustomTheme()
        {
            Theme = new MudTheme()
            {
                Palette = new PaletteLight()
                {
                    Primary = "#009ee0",
                    Secondary = Colors.Shades.White,
                    AppbarBackground = Colors.Shades.White,
                    DrawerIcon = Colors.Shades.White,
                    Background = "#e3f2fd"
                },
                PaletteDark = new PaletteDark()
                {
                    //Primary = Colors.Blue.Lighten1
                    Primary = "#212121",
                    Secondary = Colors.Shades.White,
                    AppbarBackground = Colors.Shades.White,
                    DrawerIcon = Colors.Shades.White,
                    Background = "#323232",
                    Surface = "#37474F",
                    Tertiary = "#FFFFFF",

                },
                LayoutProperties = new LayoutProperties()
                {
                    DrawerWidthLeft = "260px",
                    DrawerWidthRight = "300px"
                }
            };
        }
    }
}
