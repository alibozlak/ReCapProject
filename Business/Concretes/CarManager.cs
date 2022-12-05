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
        private IBrandService brandService;
        private IColorService colorService;

        public CarManager(ICarDal carDal, IBrandService brandService, IColorService colorService)
        {
            this.carDal = carDal;
            this.brandService = brandService;
            this.colorService = colorService;
        }

        public void Add(Car car)
        {
            int carId = car.CarId;
            if (carId <= 0)
            {
                Console.WriteLine("Arabanın ID'si 1'den küçük olmaz! Girilen ID : "+ carId);
                return;
            }
            if (IsValid(car.BrandId, car.ColorId, car.DailyPrice))
            {
                this.carDal.Add(car);
            }
        }

        public void DeleteById(int carId)
        {
            if (this.ExistById(carId))
            {
               this.carDal.DeleteById(carId);
            }
        }

        public List<Car> GetAll()
        {
            return this.carDal.GetAll();
        }

        public Car GetById(int carId)
        {
            if (this.ExistById(carId))
            {
                return this.carDal.GetById(carId);
            }
            return null;
        }

        public void Update(Car car)
        {
            if (ExistById(car.CarId))
            {
                if (IsValid(car.BrandId, car.ColorId, car.DailyPrice))
                {
                    this.carDal.Update(car);
                }
            }
            
        }

        private bool ExistById(int carId)
        {
            List<Car> cars = this.carDal.GetAll();
            foreach (Car car in cars)
            {
                if (car.CarId == carId)
                {
                    return true;
                }
            }
            Console.WriteLine("ID'si " + carId + " olan bir araba yok! ");
            return false; 
        }

        private bool IsValid(int brandId, int colorId, double dailyPrice)
        {
            if (!this.brandService.ExistByBrandId(brandId))
            {
                Console.WriteLine("ID'si " + brandId + " olan bir marka yok! ");
                return false;
            }
            if (!this.colorService.ExistByColorId(colorId))
            {
                Console.WriteLine("ID'si " + colorId + " olan bir renk yok! ");
                return false;
            }
            if (dailyPrice < 0)
            {
                Console.WriteLine("Araba kiralama fiyatı 0'dan küçük olamaz! Girilen fiyet : " + dailyPrice);
                return false;
            }
            return true; 
        }
    }
}
