using Business.Abstracts;
using Business.Concretes;
using DataAccess.Concretes.EntityFramework;
using Entities.Concretes;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car { 
                BrandId = 1, ColorId = 1, ModelYear = 2019, DailyPrice = -300, Description = "Audi A5" 
            };

            ICarService carService = new CarManager(new EfCarDal());
            carService.Add(car1);
            Console.WriteLine("-------");
            List<Car> cars = carService.GetCarsByColorId(1);
            foreach (var car in cars)
            {
                Console.WriteLine($"Araba Adı : {car.Description}, Günlük Fiyatı : {car.DailyPrice}");
            }
        }
    }
}