using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseWork.DataBase.Pattern.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppContext Context;
        protected readonly DbSet<T> DbSet;

        public Repository(AppContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public async Task<T> Get(int id) => await DbSet.FindAsync(id);

        public async Task<IEnumerable<T>> GetAll() => await DbSet.ToListAsync();

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate) =>
            await DbSet.Where(predicate).ToListAsync();

        public async Task Add(T entity) => await DbSet.AddAsync(entity);

        public async Task AddRange(IEnumerable<T> entities) => await DbSet.AddRangeAsync(entities);

        public async Task Update(T entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public async Task Remove(T entity)
        {
            DbSet.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task RemoveRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
            await Task.CompletedTask;
        }
    }
}
