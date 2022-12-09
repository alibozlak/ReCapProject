using Business.Abstracts;
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

        public void Add(Car entity)
        {
            if (IsValid(entity.Description,entity.DailyPrice))
            {
                this.carDal.Add(entity);
            }
        }

        public void Delete(Car entity)
        {
            this.carDal.DeleteByEntity(entity);
        }

        public List<Car> GetAll()
        {
            return this.carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return this.carDal.Get(car => car.CarId == id);
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return this.carDal.GetAll(car => car.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return this.carDal.GetAll(car => car.ColorId== colorId);
        }

        public List<CarDetailDto> GetCarsByDetail()
        {
            return this.carDal.GetCarsByDetail();
        }

        public void Update(Car entity)
        {
            if (this.IsValid(entity.Description,entity.DailyPrice))
            {
                this.carDal.Update(entity);
            }
        }

        private bool IsValid(string carName, double dailyPrice)
        {
            if (carName != null && carName.Length > 1)
            {
                if (dailyPrice > 0)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Arabanın günlük fiyatı 0'dan küçük olamaz! Girilen : " + dailyPrice);
                }
            }
            else
            {
                Console.WriteLine("Araba ismi en az 2 karakter olmalıdır !");
            }
            return false;
        }
    }
}
