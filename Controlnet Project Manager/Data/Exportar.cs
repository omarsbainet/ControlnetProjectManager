using Controlnet_Project_Manager.Shared;
using Microsoft.JSInterop;
using System.IO;

namespace Controlnet_Project_Manager.Data
{
    public class Exportar
    {
        public async Task GenerarExcel(IJSRuntime jSRuntime, Stream stream, string nombre)
        {
            byte[] bytes = new byte[stream.Length];
            await stream.ReadAsync(bytes, 0, (int)stream.Length);

            await jSRuntime.InvokeVoidAsync("guardarfichero", nombre, Convert.ToBase64String(bytes));
        }
    }
    }
