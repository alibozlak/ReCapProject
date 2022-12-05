using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> cars;

        public InMemoryCarDal()
        {
            cars = new List<Car>()
            {
                new Car {CarId = 1, BrandId = 1, ColorId = 1, ModelYear = 2010, DailyPrice = 200, Description = "Fiat Doblo"},
                new Car {CarId = 2, BrandId = 2, ColorId = 2, ModelYear = 2015, DailyPrice = 260, Description = "Mercedes Benz"},
                new Car {CarId = 3, BrandId = 3, ColorId = 3, ModelYear = 2020, DailyPrice = 400, Description = "Audi A4"}
            };
        }
        public void Add(Car car)
        {
            this.cars.Add(car);
            Console.WriteLine(car.Description + " arabası veritabanına eklendi. ");
        }

        public void DeleteById(int carId)
        {
            Car car = this.GetById(carId);
            this.cars.Remove(car);
            Console.WriteLine(car.Description + " arabası veritabandan silindi! ");
        }

        public List<Car> GetAll()
        {
            return this.cars;
        }

        public Car GetById(int carId)
        {
            return this.cars.SingleOrDefault(car => car.CarId == carId);
        }

        public void Update(Car car)
        {
            Car _car = this.GetById(car.CarId);
            _car.BrandId = car.BrandId;
            _car.ColorId = car.ColorId;
            _car.ModelYear = car.ModelYear;
            _car.DailyPrice = car.DailyPrice;
            _car.Description = car.Description;
            Console.WriteLine(car.Description + " arabası güncellendi! ");
        }
    }
}
