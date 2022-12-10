using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CarManager : ICarService
    {
        private ICarDal carDal;

        public CarManager(ICarDal carDal)
        {
            this.carDal = carDal;
        }

        public Result Add(Car entity)
        {
            var carName = entity.Description;
            if (IsValid(carName,entity.DailyPrice))
            {
                this.carDal.Add(entity);
                return new SuccessResult($"{carName} adlı araba eklendi");
            }
            return new ErrorResult(Messages.Car.CarNameInvalid);
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

        public Result Update(Car entity)
        {
            var carName = entity.Description;
            if (this.IsValid(carName,entity.DailyPrice))
            {
                this.carDal.Update(entity);
                return new SuccessResult($"{carName} adlı araba güncellendi");
            }
            return new ErrorResult(Messages.Car.CarNameInvalid);
        }

        private bool IsValid(string carName, double dailyPrice)
        {
            if (carName != null && carName.Length > 1)
            {
                if (dailyPrice > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
