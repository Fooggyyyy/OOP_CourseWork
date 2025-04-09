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

namespace OOP_CourseWork.DataBase
{
    public class DataBase : DbContext
    {
        private string _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=OOP_CourseWork;Trusted_Connection=True;";

        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<User> Users => Set<User>();

        public DataBase(string _connectionstring) 
        {
            Database.EnsureCreated(); 
            this._connectionString = _connectionstring;
        }

        public override void Dispose() //Для утилизации файлового потока для логирования
        {
            base.Dispose();
        }

    }
}


//protected override void OnModelCreating(ModelBuilder modelBuilder)
//{
//    // использование Fluent API
//    base.OnModelCreating(modelBuilder);
//    modelBuilder.Entity<Country>();//Включаем Country В наше БД
//                                   //modelBuilder.Ignore<Country>(); Это если надо наоборот проигнорировать, что бы в БД не добавлялось
//    modelBuilder.Entity<User>().Ignore(u => u.Position); //Position не будет в БД
//    modelBuilder.Entity<User>().Property(u => u.Id).HasField("_id");
//    modelBuilder.Entity<User>().Property(u => u.Name).HasField("_name");
//    modelBuilder.Entity<User>().Property(u => u.Age).HasField("_age");
//}
