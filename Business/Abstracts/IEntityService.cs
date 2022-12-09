using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IEntityService<T> where T : class, IEntity, new()
    {
        Result Add(T entity);
        Result Update(T entity);
        Result Delete(T entity);
        Result GetAll();
        Result GetById(int id);
    }
}
