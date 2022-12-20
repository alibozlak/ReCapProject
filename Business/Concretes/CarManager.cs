using Business.Abstracts;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;

namespace Business.Concretes
{
    public class CarManager : ICarService
    {
        private ICarDal carDal;

        public CarManager(ICarDal carDal)
        {
            this.carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public Result Add(Car entity)
        {
            this.carDal.Add(entity);
            return new SuccessResult($"{entity.Description} adlı araba eklendi");
        }

        public Result Delete(Car entity)
        {
            this.carDal.DeleteByEntity(entity);
            return new SuccessResult($"{entity.Description} adlı araba silindi");
        }

        public SuccessDataResult<List<Car>> GetAll()
        {
            var data = this.carDal.GetAll();
            var message = "Tüm arabalar getirildi";
            return new SuccessDataResult<List<Car>>(message,data);
        }

        public Result GetById(int id)
        {
            var data = this.carDal.Get(car => car.CarId == id);
            var message = $"ID'si {id} olan araba getirildi";
            return new SuccessDataResult<Car>(message,data);
        }

        public Result GetCarsByBrandId(int brandId)
        {
            var data = this.carDal.GetAll(car => car.BrandId == brandId);
            var message = $"Marka ID'si {brandId} olan arabalar listelendi";
            return new SuccessDataResult<List<Car>>(message,data);
        }

        public Result GetCarsByColorId(int colorId)
        {
            var data = this.carDal.GetAll(car => car.ColorId == colorId);
            var message = $"Renk ID'si {colorId} olan arabalar listelendi";
            return new SuccessDataResult<List<Car>>(message,data);
        }

        public Result GetCarsByDetail()
        {
            var data = this.carDal.GetCarsByDetail();
            var message = "Tüm araba detayları listelendi";
            return new SuccessDataResult<List<CarDetailDto>>(message,data);
        }

        [ValidationAspect(typeof(CarValidator))]
        public Result Update(Car entity)
        {
            this.carDal.Update(entity);
            return new SuccessResult($"{entity.Description} adlı araba güncellendi");
        }

        // ****** FluentValidation'a geçildi ********
        //private bool IsValid(string carName, double dailyPrice)
        //{
        //    if (carName != null && carName.Length > 1)
        //    {
        //        if (dailyPrice > 0)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
