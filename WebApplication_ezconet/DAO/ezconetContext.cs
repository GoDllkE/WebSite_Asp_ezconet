using System;
using Microsoft.EntityFrameworkCore;
using WebApplication_ezconet.Models;

namespace WebApplication_ezconet.DAO
{
    internal class ezconetContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Sexo> Sexo { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"F:\\Users\\Gustavo Toledo\\Documents\\Visual Studio 2017\\Projects\\ASP\\WebApplication_ezconet\\WebApplication_ezconet\\App_Data\\ProjectDatabase.mdf\";Integrated Security=True");
        }
        
    }
}