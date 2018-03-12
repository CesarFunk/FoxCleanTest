using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Librerias que se usaron
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SystemFacturacion.Models;

namespace SystemFacturacion.DAL
{
    public class SysDbContext : DbContext
    {
        private const string StrConexion = @"Data Source=DESKTOP-7C3K8Q0\SQLEXPRESS;Initial Catalog=DbSystemFacturacion;Integrated Security=True";
        public SysDbContext() : base(StrConexion)
        {
        }


        public DbSet<Costumer> Cliente { get; set; }
        public DbSet<Product> Producto { get; set; }
        public DbSet<Category> Categoria { get; set; }
        public DbSet<Bill> Factura { get; set; }
        public DbSet<Detail> Detalle { get; set; }
        //metodo que construye la base de datos en vase a los modelos(entidades)
        /// <summary>
        /// Utiliza la clase modelBuilder
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}