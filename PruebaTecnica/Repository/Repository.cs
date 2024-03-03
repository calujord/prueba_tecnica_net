using Microsoft.EntityFrameworkCore;
using PruebaTecnica.ContextoBBDD;
using PruebaTecnica.Repository.Impl;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PruebaTecnica.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationContext _context;
        internal DbSet<T> dbSet;

        public Repository(ApplicationContext context)
        {
            _context = context;
            this.dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(List<T> Entities)
        {
            dbSet.AddRange(Entities);
            _context.SaveChanges();
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

    }
}
