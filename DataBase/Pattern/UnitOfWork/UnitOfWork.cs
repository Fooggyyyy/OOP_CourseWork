    using Microsoft.EntityFrameworkCore;
    using OOP_CourseWork.DataBase.Pattern.Repository;
    using OOP_CourseWork.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace OOP_CourseWork.DataBase.Pattern.UnitOfWork
    {
        public class UnitOfWork : IUnitOfWork
        {
            private readonly AppContext _context;

            public UnitOfWork(AppContext context)
            {
                _context = context;
                Users = new Repository<User>(_context);
                Items = new Repository<Item>(_context);
                Comments = new Repository<Comment>(_context);
                Carts = new Repository<Cart>(_context);
                Favorites = new Repository<Favorite>(_context);
                Histories = new Repository<History>(_context);
                LastViews = new Repository<LastView>(_context);
                Orders = new Repository<Order>(_context);
            }

            public IRepository<User> Users { get; }
            public IRepository<Item> Items { get; }
            public IRepository<Comment> Comments { get; }
            public IRepository<Cart> Carts { get; }
            public IRepository<Favorite> Favorites { get; }
            public IRepository<History> Histories { get; }
            public IRepository<LastView> LastViews { get; }
            public IRepository<Order> Orders { get; }

            public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

            public void Dispose()
            {
                _context.Dispose();
                GC.SuppressFinalize(this);
            }
        }
    }
