using Microsoft.EntityFrameworkCore;
using Spendee.Data;
using Spendee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Spendee.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly DataContext Db;
        protected readonly DbSet<TEntity> Dbset;      
        
        public Repository(DataContext db)
        {
            Db = db;
            Dbset = db.Set<TEntity>();
        }

        public virtual async Task Add(TEntity entity)
        {
            Dbset.Add(entity);
            await SaveChanges();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await Dbset.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await Dbset.FindAsync(id);
        }

        public virtual  async Task Remove(TEntity entity)
        {
            Dbset.Remove(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await Dbset.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            Dbset.Update(entity);
            await SaveChanges();
        }
    }
}
