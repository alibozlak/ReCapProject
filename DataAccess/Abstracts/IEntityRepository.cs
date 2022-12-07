using Entities.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IEntityRepository<T> where T : class, IEntity, new() 
    {
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T,bool>> filter = null);
        void Add(T item);
        void Update(T item);
        void DeleteByEntity(T item);
    }
}
