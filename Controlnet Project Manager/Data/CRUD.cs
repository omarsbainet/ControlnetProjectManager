using Controlnet_Project_Manager.Areas.Identity.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Authorization;
using static Controlnet_Project_Manager.Pages.Proyectos.Proyectos;






namespace Controlnet_Project_Manager.Data
{
    public class CRUD : ControllerBase
    {
        private readonly IServiceScopeFactory serviceScopeFactory;
        private IHttpContextAccessor _httpContextAccessor { get; set; }
        private UserManager<CPMUser> _userManager { get; set; }
        private IDbContextFactory<ApplicationDbContext> _dbFactory { get; set; }
        private NavigationManager _navigationManager { get; set; }



        public CRUD(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            var scope = this.serviceScopeFactory.CreateScope().ServiceProvider;
            _httpContextAccessor = scope.GetService<IHttpContextAccessor>();
            _dbFactory = scope.GetService<IDbContextFactory<ApplicationDbContext>>();
            _userManager = scope.GetService<UserManager<CPMUser>>();
            _navigationManager = scope.GetService<NavigationManager>();

        }

        public void Initialize(
            IHttpContextAccessor httpContextAccessor,
            UserManager<CPMUser> userManager,
            IDbContextFactory<ApplicationDbContext> dbFactory,
            NavigationManager navigationManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _dbFactory = dbFactory;
            _navigationManager = navigationManager;
        }


        public async Task<MenuRol> GetMenuRol(int idMenu, CPMUser user)
        {
            //await GetCurrentUser();
            await using var context = await _dbFactory.CreateDbContextAsync();
            return await context.MenuRoles.Include(c=>c.Rol).FirstOrDefaultAsync(it => it.IdMenu == idMenu && it.Rol == user.Rol);
        }

        /*
         * FUNCIONES DE SELECCION DE DATOS
         */

        /*
         * Sirve para obtener todas las notificiaciones del usuario logueado
         */

        public async Task<List<Notificacion>> GetAllNotifications(string userid)
        {
            try
            {
                //Contexto de la base de datos
                await using var context = await _dbFactory.CreateDbContextAsync();
                //Obtengo el id del usuario autenticado
                //De la base de datos, obtengo el usuario que coincida con el id
                CPMUser user = context.Users.FirstOrDefault(it => it.Id == userid);
                //Finalmente, devuelvo la lista de aquellas notificaciones que su esten asignada a un usuario y su correspondiente id
                return context.Notificaciones.Where(it => it.IDUsuario.Id == user.Id && it.Eliminada == false).ToList();
            } catch (Exception ex) { 
                Console.WriteLine(ex.ToString());
                return new List<Notificacion>();

            }
            
            
        }

        //Obtiene recuento de todas las notificaciones no leidas
        public async Task<int> GetAllNoLeidas(string userid)
        {
            //Contexto de la db
            await using var context = await _dbFactory.CreateDbContextAsync();
            //Obtenemos el id de usuario
            //Obtenemos el usuario con ese id
            CPMUser user = context.Users.FirstOrDefault(u => u.Id == userid);
            //Devolvemos la cantidad de notificaciones que no han sido leidas y que coinciden con el id del usuario
            return context.Notificaciones.Where(it => it.IDUsuario.Id == user.Id && it.Leida == false).Count();
        }

        /*
         * FUNCIONES DE MODIFICACION DE DATOS
         */

        /*
         * Esta funcion recibe el id de una notificacion, y cambia su valor de leida a true, para que el usuario vea que ya la ha leido
         */

        public async Task ChangeNotificationLeidaStatus (int idnotificacion)
        {
            //Contexto de la DB
            await using var context = await _dbFactory.CreateDbContextAsync();
            //Obtenemos de la base de datos la notificacion que deseamos cambiar
            Notificacion notificacion = context.Notificaciones.FirstOrDefault(it => it.Id == idnotificacion);
            //Cambiamos la notificacion a leida
            notificacion.Leida = true;
            //finalmente, llamamamos al metodo Update y le pasamos la notificacion cambiada
            context.Notificaciones.Update(notificacion);
            //Guardamos los cambios
            await context.SaveChangesAsync();

        }


        /*
         * Esta funcion recibe la lista de notificaciones como parametro, y pone todas las notificaciones y su atributo leida a true
         */

        public async Task ChangeAllLeidaState(List<Notificacion> listanotis)
        {
            await using var context = await _dbFactory.CreateDbContextAsync();
             foreach ( var noti in listanotis)
            {
                noti.Leida = true;
                context.Notificaciones.Update(noti);
            }
            await context.SaveChangesAsync();

        }

        /*
         * Cambia el estado del atributo eliminada en las notificaciones, haciendo asi que no aparezcan en la lista, pero aun asi se guardan en la base de datos
         */

        public async Task ChangeEliminadaState(int id)
        {
            //Obtiene contexto de la DB
            await using var context = await _dbFactory.CreateDbContextAsync();
            //Encuentra la notificacion de la que se desea hacer el cambio
            Notificacion noti = context.Notificaciones.FirstOrDefault(n => n.Id == id);
            //Se cambia el atributo eliminada de la notificacion a true
            noti.Eliminada = true;
            noti.Leida = true;

            context.Update(noti);
            //Se guardan los cambios
           await context.SaveChangesAsync();

        }


        /*
         * Elimina la notificacion pasada por parametros de la base de datos
         */

        public async Task DeleteNotification(int id)
        {
            //Contexto de la db
            await using var context = await _dbFactory.CreateDbContextAsync();
            context.Notificaciones.Where(n => n.Id == id).ExecuteDeleteAsync();
            await context.SaveChangesAsync();
        }
        

        public async Task<List<Proyecto>> GetAllProyectos()
        {
            await using var ctx = await _dbFactory.CreateDbContextAsync();
            return await ctx.Proyectos.Include(it => it.Estado).Include(it => it.Incidencias).Include(it => it.Desarrollos).Include(it => it.Cliente).ToListAsync();
        }

        public async Task<List<KanbanTaskItem>> GetAllProyectosKanban()
        {
            List<KanbanTaskItem> tasks = new List<KanbanTaskItem>();

            await using var ctx = await _dbFactory.CreateDbContextAsync();

            // Consultar los proyectos desde la base de datos
            var proyectos = await ctx.Proyectos.Include(it => it.Estado).Include(it=> it.Incidencias).Include(it=> it.Desarrollos).Include(it => it.Cliente).ToListAsync();

            // Inicializar tasks utilizando los nombres de proyectos
            tasks = proyectos.Select(proyecto => new KanbanTaskItem(
                proyecto.Id,
                proyecto.Nombre,
                proyecto.Estado.Nombre,
                proyecto.FechaPrevistaContrato,
                proyecto.FechaPrevistaEntrega,
                proyecto.HorasEstimadas,
                proyecto.HorasSemanalesEstimadas,
                proyecto.Cliente?.Nombre ?? ""
            )).ToList();

            return tasks;
        }

    }
}
