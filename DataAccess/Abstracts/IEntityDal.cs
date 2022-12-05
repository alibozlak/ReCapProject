using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IEntityDal<T>
    {
        T GetById(int id);
        List<T> GetAll();
        void Add(T item);
        void Update(T item);
        void DeleteById(int id);
    }
}
