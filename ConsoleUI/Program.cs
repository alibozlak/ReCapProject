using Business.Abstracts;
using Business.Concretes;
using DataAccess.Concretes.InMemory;
using Entities.Concretes;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car4 = new Car { 
                CarId = 4, BrandId = 3, ColorId = 3, ModelYear = 2019, DailyPrice = 300, Description = "Audi A2" 
            };

            ICarService carService = new CarManager(
                    new InMemoryCarDal(), 
                    new BrandManager(new InMemoryBrandDal()),
                    new ColorManager(new InMemoryColorDal())
            );

            carService.Add(car4);
            Console.WriteLine("-------");

            List<Car> cars = carService.GetAll();
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}