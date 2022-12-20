using Business.Abstracts;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class BrandManager : IBrandService
    {
        private IBrandDal brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            this.brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public Result Add(Brand entity)
        {
            // ****** ValidationAspect'e geçildi *******
            //ValidationTool.Validate(new BrandValidator(), entity);

            this.brandDal.Add(entity);
            return new SuccessResult($"{entity.BrandName} adlı marka eklendi");
        }

        public Result Delete(Brand entity)
        {
            this.brandDal.DeleteByEntity(entity);
            return new SuccessResult($"{entity.BrandName} adlı marka silindi");
        }

        public SuccessDataResult<List<Brand>> GetAll()
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

        [ValidationAspect(typeof(BrandValidator))]
        public Result Update(Brand entity)
        {
            // ****** ValidationAspect'e geçildi *******
            //ValidationTool.Validate(new BrandValidator(),entity);

            this.brandDal.Update(entity);
            return new SuccessResult($"{entity.BrandName} adlı marka güncellendi");
        }

        // ***** FluentValidation'a Geçildi : *********
        //private bool IsBrandNameEmpty(string brandName)
        //{
        //    if (brandName == null || brandName.Length < 1)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
