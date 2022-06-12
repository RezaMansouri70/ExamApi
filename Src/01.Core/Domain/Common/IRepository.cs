using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClass.Common
{

    public interface IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        void Insert(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        void SaveChanges();
        TEntity Get(long id);
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> GetQueryable();

    }
}
