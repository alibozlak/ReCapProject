using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        private List<Brand> brands;

        public InMemoryBrandDal()
        {
            brands = new List<Brand>()
            {
                new Brand {BrandId = 1, BrandName = "Fiat"},
                new Brand {BrandId = 2, BrandName = "Mercedes"},
                new Brand {BrandId = 3, BrandName = "Audi"},
            };
        }

        public void Add(Brand item)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExistByBrandId(int brandId)
        {
            foreach (Brand brand in brands)
            {
                if (brand.BrandId == brandId)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Brand> GetAll()
        {
            throw new NotImplementedException();
        }

        public Brand GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Brand item)
        {
            throw new NotImplementedException();
        }
    }
}
