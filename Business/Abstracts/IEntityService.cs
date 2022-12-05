using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IEntityService<T>
    {
        T GetById(int id);
        List<T> GetAll();
        void Add(T item);
        void Update(T item);
        void DeleteById(int id); 
    }
}
