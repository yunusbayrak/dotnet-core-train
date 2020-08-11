using DataAccess.Configs;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DataAccess.EntityFramework.Context
{
    public class JkiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.ConnectionString);
            //optionsBuilder
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;                
            }

            ////bu entity için default filter oluşturarak her sorguda silinmişmi kontrolünü otomatik yapar.
            ////Sorgu yaparken default filtreleri iptal etmek için 
            ////var faaliyetler = context.Faaliyet.IgnoreQueryFilters().ToList();
            //modelbuilder.Entity<Faaliyet>().HasQueryFilter(c => !c.IsDeleted);


            base.OnModelCreating(modelbuilder);
        }

        public DbSet<Faaliyet> Faaliyet { get; set; }
        public DbSet<Ihbar> Ihbar { get; set; }
        public DbSet<IhbarDurumu> IhbarDurumu { get; set; }
        public DbSet<IslemDurumu> IslemDurumu { get; set; }
        public DbSet<Olay> Olay { get; set; }
        public DbSet<OlayIhbar> OlayIhbar { get; set; }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Rol> Rol { get; set; }
    }
}
