using DomainClass.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.SqlServer.Common
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly ApplicationContext dbContext;

        public EfRepository(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Insert(TEntity entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            dbContext.Remove(entity);
            dbContext.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return dbContext.Set<TEntity>().FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().ToList();
        }

        public void Update(TEntity entity)
        {
            dbContext.Update(entity);
            dbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return dbContext.Set<TEntity>().AsQueryable();
        }
    }

}
