using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    class Context : DbContext
    {
        private static DbContextOptions<Context> options =
            new DbContextOptionsBuilder<Context>().UseInMemoryDatabase("TheDB").Options;


        /*public Context() : base(options)
        {
            
        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=tcp:dyrafjallshnjukur.database.windows.net,1433;Initial Catalog=VideoDyrafjallshnjukurDB;Persist Security Info=False;User ID=dyrafjallshnjukur;Password=Kukur007;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        public DbSet<Item> Item { get; set; }
        public DbSet<ItemType> ItemType { get; set; }
        public DbSet<Pub> Pub { get; set; }
        public DbSet<Supplier> Supplier { get; set; }

    }
}
