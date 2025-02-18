using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using L01_2022RR651_2022VM651.Models;

namespace laboratorioWebActivas.Models
{
    //Si se camba nombre revisar inyeccion de dependencias en program
    public class blogDBContext: DbContext
    {
        public blogDBContext(DbContextOptions<blogDBContext> options) : base(options)
        {
        }

        //Agregar DBset para cada modelo
        public DbSet<roles> roles { get; set; }
        public DbSet<usuarios> usuarios { get; set; }
        public DbSet<publicaciones> publicaciones { get; set; }
        public DbSet<comentarios> comentarios { get; set; }
        public DbSet<calificaciones> calificaciones { get; set; }
    }
}
