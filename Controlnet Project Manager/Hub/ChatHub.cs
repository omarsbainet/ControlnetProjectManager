using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace BlazorServerHub
{
    public class ChatHub : Hub
    {
        //Funcion EnviarNotificacion, la cual envia al usuario pasado por parametros el mensaje
        public async Task EnviarNotificacion(string userId, string mensaje)
        {
            //Se envia a los clientes (al id de usuario recibido) el mensaje, y su tipo.
            //Se llamará a esta notificacion mediante RecibirNotificacion.
            await Clients.User(userId).SendAsync("RecibirNotificacion", mensaje);
        }

    }
}
  

