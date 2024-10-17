using Controlnet_Project_Manager.Areas.Identity.Data;
using Microsoft.JSInterop;
using MudBlazor;

namespace Controlnet_Project_Manager.Pages.Incidencia
{
    public class FileService
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly ISnackbar _snackbar;

        public FileService(IJSRuntime jsRuntime, ISnackbar snackbar)
        {
            _jsRuntime = jsRuntime;
            _snackbar = snackbar;
        }

        public async Task DescargarArchivo(List<DocumentoProyecto> lstDocProyectos, int idArchivo, string nombreArchivo)
        {
            try
            {
                // Buscar el documento en la lista de documentos con el id proporcionado.
                DocumentoProyecto documento = lstDocProyectos.FirstOrDefault(d => d.Id == idArchivo);

                if (documento != null)
                {
                    // Convertir el archivo Base64 a bytes.
                    byte[] archivoBytes = Convert.FromBase64String(documento.Documento);

                    // Invocar la función JavaScript para iniciar la descarga del archivo
                    await _jsRuntime.InvokeVoidAsync("downloadFile", nombreArchivo, Convert.ToBase64String(archivoBytes));

                    _snackbar.Add("Se ha descargado correctamente", Severity.Success);
                }
                else
                {
                    _snackbar.Add("No se ha encontrado el archivo", Severity.Error);
                }
            }
            catch (Exception ex)
            {
                _snackbar.Add($"Error al descargar el archivo: {ex.Message}", Severity.Error);
            }
        }

        public async Task DescargarArchivo(List<DocumentoIncidencia> lstDocIncidencia, int idArchivo, string nombreArchivo)
        {
            try
            {
                // Buscar el documento en la lista de documentos con el id proporcionado.
                DocumentoIncidencia documento = lstDocIncidencia.FirstOrDefault(d => d.Id == idArchivo);

                if (documento != null)
                {
                    // Convertir el archivo Base64 a bytes.
                    byte[] archivoBytes = Convert.FromBase64String(documento.Documento);

                    // Invocar la función JavaScript para iniciar la descarga del archivo
                    await _jsRuntime.InvokeVoidAsync("downloadFile", nombreArchivo, Convert.ToBase64String(archivoBytes));

                    _snackbar.Add("Se ha descargado correctamente", Severity.Success);
                }
                else
                {
                    _snackbar.Add("No se ha encontrado el archivo", Severity.Error);
                }
            }
            catch (Exception ex)
            {
                _snackbar.Add($"Error al descargar el archivo: {ex.Message}", Severity.Error);
            }
        }

        public async Task DescargarArchivo(List<DocumentoDesarrollo> lstDocDesarrollo, int idArchivo, string nombreArchivo)
        {
            try
            {
                // Buscar el documento en la lista de documentos con el id proporcionado.
                DocumentoDesarrollo documento = lstDocDesarrollo.FirstOrDefault(d => d.Id == idArchivo);

                if (documento != null)
                {
                    // Convertir el archivo Base64 a bytes.
                    byte[] archivoBytes = Convert.FromBase64String(documento.Documento);

                    // Invocar la función JavaScript para iniciar la descarga del archivo
                    await _jsRuntime.InvokeVoidAsync("downloadFile", nombreArchivo, Convert.ToBase64String(archivoBytes));

                    _snackbar.Add("Se ha descargado correctamente", Severity.Success);
                }
                else
                {
                    _snackbar.Add("No se ha encontrado el archivo", Severity.Error);
                }
            }
            catch (Exception ex)
            {
                _snackbar.Add($"Error al descargar el archivo: {ex.Message}", Severity.Error);
            }
        }


        public async Task DescargarArchivo(List<DocumentoPeticion> lstDocPeticion, int idArchivo, string nombreArchivo)
        {
            try
            {
                // Buscar el documento en la lista de documentos con el id proporcionado.
                DocumentoPeticion documento = lstDocPeticion.FirstOrDefault(d => d.Id == idArchivo);

                if (documento != null)
                {
                    // Convertir el archivo Base64 a bytes.
                    byte[] archivoBytes = Convert.FromBase64String(documento.Documento);

                    // Invocar la función JavaScript para iniciar la descarga del archivo
                    await _jsRuntime.InvokeVoidAsync("downloadFile", nombreArchivo, Convert.ToBase64String(archivoBytes));

                    _snackbar.Add("Se ha descargado correctamente", Severity.Success);
                }
                else
                {
                    _snackbar.Add("No se ha encontrado el archivo", Severity.Error);
                }
            }
            catch (Exception ex)
            {
                _snackbar.Add($"Error al descargar el archivo: {ex.Message}", Severity.Error);
            }
        }
    }
}
