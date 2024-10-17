using Controlnet_Project_Manager.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Controlnet_Project_Manager.Data;

public class ApplicationDbContext : IdentityDbContext<CPMUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        // Ejecutar el comando para establecer el sort_buffer_size
        this.Database.OpenConnection();
        using (var command = this.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = "SET SESSION sort_buffer_size = 2097152;"; // 2MB en bytes
            command.ExecuteNonQuery();
        }
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Rol>(r =>
        {
            r.HasKey(it => it.Id);
            r.ToTable("Roles");
        });

        builder.Entity<CPMUser>(u => u.ToTable("Usuarios"));
    }

    public DbSet<CPMUser>? Users { get; set; }
    public DbSet<Rol>? Roles { get; set; }
    public DbSet<Proyecto>? Proyectos { get; set; }
    public DbSet<ProgramadoresProyecto>? ProgramadoresProyectos { get; set; }
    public DbSet<Estado>? Estados { get; set; }
    public DbSet<EstadoProyectoUsuario>? EstadoProyectoUsuarios { get; set; }
    public DbSet<Cliente>? Clientes { get; set; }
    public DbSet<Equipo>? Equipos { get; set; }
    public DbSet<CheckinCheckout>? CheckinCheckouts { get; set; }
    public DbSet<MenuRol> MenuRoles { get; set; }
    public DbSet<Incidencia> Incidencias { get; set; }
    public DbSet<EquiposProyecto> EquiposProyectos { get; set; }
    public DbSet<ProgramadoresEquipos>? ProgramadoresEquipos {get; set; }
    public DbSet<EstadoIncidencia> EstadosIncidencias { get; set; }
    public DbSet<Desarrollo> Desarrollos { get; set; }
    public DbSet<EstadoDesarrollo> EstadosDesarrollos { get; set; }


    public DbSet<Peticion> Peticiones { get; set; }

    public DbSet<Tecnologia> Tecnologias { get; set; }


    public DbSet<DocumentoDesarrollo> DocumentosDesarrollos { get; set; }

    public DbSet<DocumentoIncidencia> DocumentosIncidencias { get; set; }

    public DbSet<DocumentoPeticion> DocumentosPeticiones { get; set; }

    public DbSet<DocumentoProyecto> DocumentosProyectos { get; set; }

    public DbSet<ProyectoTecnologia> ProyectosTecnologias { get; set; }

    public DbSet<Notificacion> Notificaciones { get; set; }


}