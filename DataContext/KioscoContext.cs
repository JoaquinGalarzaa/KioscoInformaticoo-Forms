using KioscoInformaticoo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioscoInformaticoo.DataContext
{
    public class KioscoContext : DbContext
    {
        public KioscoContext()
        {
            
        }
        public KioscoContext(DbContextOptions<KioscoContext> Options) : base (Options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string? cadenaConexion = configuration.GetConnectionString("mysqlLocal");
            optionsBuilder.UseMySql(cadenaConexion,ServerVersion.AutoDetect(cadenaConexion));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //datos semilla Productos
            modelBuilder.Entity<Producto>().HasData(
                new Producto() { Id = 1, Nombre = "Coca Cola 2lts", Precio = 2650 },
                new Producto() { Id = 2, Nombre = "Doritos 160grs", Precio = 1450 }
                );

            //datos semilla Localidades
            modelBuilder.Entity<Localidad>().HasData(
                new Localidad() { Id= 1, Nombre = "San Justo"},
                new Localidad() { Id = 2, Nombre = "La Criolla" }

            );
            //datos semilla Clientes
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente() { Id = 1, Nombre = "Joaquin Galarza" },
                new Cliente() { Id = 2, Nombre = "Juan Perez"}
            );

        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

    }
}
