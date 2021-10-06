using Microsoft.EntityFrameworkCore;
using UCR.App.Dominio;

namespace UCR.App.Persistencia
{
    public class AppContext: DbContext
    {
        public DbSet<Persona> Personas {get;set;}
        public DbSet<Administrativo> Administrativos {get;set;}
        public DbSet<Docente> Docentes {get;set;}
        public DbSet<Estudiante> Estudiantes {get;set;}
        public DbSet<PersonalAseo> PersonalAseo {get;set;}
        public DbSet<PersonalCocina> PersonalCocina {get;set;}
        public DbSet<Restaurante> Restaurante {get;set;}
        public DbSet<Turno> Turnos {get;set;}
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source =(localdb)\\MSSQLLocalDB; Initial Catalog= UCRestaurant");
        
            }

        }       
    }
}