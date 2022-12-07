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

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return this.carDal.GetAll(car => car.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return this.carDal.GetAll(car => car.ColorId== colorId);
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
