using Business.Abstracts;
using Core.Utilities.Results;
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

        public Result Add(Brand entity)
        {
            var brandName = entity.BrandName;
            if (!this.IsBrandNameEmpty(brandName))
            {
                this.brandDal.Add(entity);
                return new SuccessResult($"{brandName} adlı marka eklendi");
            }
            return new ErrorResult(Messages.Brand.BrandNameIsntEmpty);
        }

        public Result Delete(Brand entity)
        {
            this.brandDal.DeleteByEntity(entity);
            return new SuccessResult($"{entity.BrandName} adlı marka silindi");
        }

        public Result GetAll()
        {
            var data = this.brandDal.GetAll();
            var message = "Tüm markalar listelendi";
            return new SuccessDataResult<List<Brand>>(message,data);
        }

        public Result GetById(int id)
        {
            var data = this.brandDal.Get(brand => brand.BrandId == id);
            var message = $"ID'si {id} olan marka getirildi";
            return new SuccessDataResult<Brand>(message,data);
        }

        public Result Update(Brand entity)
        {
            var brandName = entity.BrandName;
            if (!this.IsBrandNameEmpty(brandName))
            {
                this.brandDal.Update(entity);
                return new SuccessResult($"{brandName} adlı marka güncellendi");
            }
            return new ErrorResult(Messages.Brand.BrandNameIsntEmpty);
        }

        private bool IsBrandNameEmpty(string brandName)
        {
            if (brandName == null || brandName.Length < 1)
            {
                return true;
            }
            return false;
        }
    }
}
