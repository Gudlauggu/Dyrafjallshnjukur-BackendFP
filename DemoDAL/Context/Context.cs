﻿using DAL.Entities;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PubItem>()
                .HasKey(pi => new { pi.ItemId, pi.PubId });

            modelBuilder.Entity<PubItem>()
                .HasOne(pi => pi.Pub)
                .WithMany(p => p.PubItems)
                .HasForeignKey(pi => pi.PubId);

            modelBuilder.Entity<PubItem>()
                .HasOne(pi => pi.Item)
                .WithMany(i => i.PubItems)
                .HasForeignKey(pi => pi.ItemId);


            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.ItemId, oi.OrderId });

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Item)
                .WithMany(i => i.OrderItems)
                .HasForeignKey(oi => oi.ItemId);


        }

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
        public DbSet<Order>  Order { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<User> User { get; set; }




    }
}
