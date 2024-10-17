using BlazorServerHub;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNet.SignalR.Client.Transports;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNet.SignalR.Client;
using static System.Runtime.InteropServices.JavaScript.JSType;
using MudBlazor;

namespace Controlnet_Project_Manager.Data
{
    public class Notis : ControllerBase
    {

        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly IHubContext<ChatHub> _hubContext;

        public Notis(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            var scope = this.serviceScopeFactory.CreateScope().ServiceProvider;
            _hubContext = scope.GetService<IHubContext<ChatHub>>();
        }

        //Funcion Send, que recibe los parametros para enviar el mensaje
        public async Task send(string userId, string mensaje)
        {
            await _hubContext.Clients.User(userId).SendAsync("RecibirNotificacion", mensaje);
        }


    }
}
    


