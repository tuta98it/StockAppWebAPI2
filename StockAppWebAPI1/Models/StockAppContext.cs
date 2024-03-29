﻿using Microsoft.EntityFrameworkCore;
using StockAppWebApi.Models;

namespace StockAppWebAPI1.Models
{
    public class StockAppContext : DbContext
    {
        public StockAppContext(DbContextOptions<StockAppContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<WatchList> WatchLists { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Tập hợp UserId và StockId làm khoá chính
            modelBuilder.Entity<WatchList>().HasKey(w => new { w.UserId, w.StockId });
        }
    }
}
