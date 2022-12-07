using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand item)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var addedBrand = context.Entry(item);
                addedBrand.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void DeleteByEntity(Brand item)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var deletedBrand = context.Entry(item);
                deletedBrand.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return filter == null ?
                    context.Set<Brand>().ToList() : context.Set<Brand>().Where(filter).ToList();
            }
        }

        public void Update(Brand item)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var updatedBrand = context.Entry(item);
                updatedBrand.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
