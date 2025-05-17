using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Diagnostics.Metrics;
using OOP_CourseWork.Model;
using OOP_CourseWork.DataBase.ModelCreating;
using Microsoft.Extensions.Options;
using System.Configuration;

namespace OOP_CourseWork.DataBase
{
    public class AppContext : DbContext
    {
        private string _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=OOP_CourseWork;Trusted_Connection=True;";

        public DbSet<Favorite> Favorites => Set<Favorite>();
        public DbSet<LastView> LastViews => Set<LastView>();
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<User> Users => Set<User>();

        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CartOnModelCreating());
            modelBuilder.ApplyConfiguration(new CommentOnModelCreating());
            modelBuilder.ApplyConfiguration(new FavoriteOnModelCreating());
            modelBuilder.ApplyConfiguration(new ItemOnModelCreating());
            modelBuilder.ApplyConfiguration(new LastViewOnModelCreating());
            modelBuilder.ApplyConfiguration(new OrderOnModelCreating());
            modelBuilder.ApplyConfiguration(new UserOnModelCreating());
            modelBuilder.ApplyConfiguration(new ContactOnModelCreating());
        }

    }
}

