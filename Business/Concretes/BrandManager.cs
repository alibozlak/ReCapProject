using Business.Abstracts;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class BrandManager : IBrandService
    {
        private IBrandDal brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            this.brandDal = brandDal;
        }

        public void Add(Brand entity)
        {
            if (!this.IsBrandNameEmpty(entity.BrandName))
            {
                this.brandDal.Add(entity);
            }
        }

        public void Delete(Brand entity)
        {
            this.brandDal.DeleteByEntity(entity);
        }

        public List<Brand> GetAll()
        {
            return this.brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return this.brandDal.Get(brand => brand.BrandId == id);
        }

        public void Update(Brand entity)
        {
            if (!this.IsBrandNameEmpty(entity.BrandName))
            {
                this.brandDal.Update(entity);
            }
        }

        private bool IsBrandNameEmpty(string brandName)
        {
            if (brandName == null || brandName.Length < 1)
            {
                Console.WriteLine("Araba Markası ismi boş olamaz! ");
                return true;
            }
            return false;
        }
    }
}
