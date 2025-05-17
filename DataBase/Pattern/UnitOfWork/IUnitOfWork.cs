using OOP_CourseWork.DataBase.Pattern.Repository;
using OOP_CourseWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseWork.DataBase.Pattern.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Item> Items { get; }
        IRepository<Comment> Comments { get; }
        IRepository<Cart> Carts { get; }
        IRepository<Favorite> Favorites { get; }
        IRepository<LastView> LastViews { get; }
        IRepository<Order> Orders { get; }
        IRepository<Contact> Contacts { get; }

        Task<int> CompleteAsync();
    }
}
