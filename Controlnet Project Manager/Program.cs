using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Controlnet_Project_Manager.Areas.Identity;
using Controlnet_Project_Manager.Data;
using MudBlazor.Services;
using Microsoft.AspNetCore.Authorization;
using Controlnet_Project_Manager.Pages.Incidencia;
using BlazorServerHub;
using MudBlazor;
using Controlnet_Project_Manager.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
});
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<CPMUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager();

builder.Services.AddRazorPages();
builder.Services.AddScoped<CRUD>();
builder.Services.AddScoped<ChatHub>();
builder.Services.AddScoped<Notis>();
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});
var cultureInfo = new CultureInfo("es-ES"); // Spanish (Spain)
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/login";
    // ... otras opciones si las hay
});

builder.Services.AddSignalR();

builder.Services.AddSession(options =>
{
    
    options.IdleTimeout = TimeSpan.FromHours(3);
    options.Cookie.Name = "CPM.Session";
});
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<CPMUser>>();
builder.Services.AddScoped<MyCustomTheme>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<FileService>();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

//app.UseAuthentication();

app.MapHub<ChatHub>("/notificacionesHub");
//Endpoint del hub
//app.UseEndpoints(endpoints =>
//{
//    //El Hub sera de la clase ChatHub, el cual tendr� como ruta del hub
//    endpoints.MapHub<ChatHub>("Notificacion");
//});
app.MapControllers();


//app.MapHub<ChatHub>("notificacionesHub");
app.MapBlazorHub();
app.MapFallbackToPage("/Account/Login", "/Account/Login");
app.MapFallbackToPage("/_Host");

app.Run();