using Business.Abstracts;
using Business.Concretes;
using Core.Utilities.Results;
using DataAccess.Concretes.EntityFramework;
using Entities.Concretes;
using Entities.DTOs;
using Microsoft.VisualBasic;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //EigthLessonFirstHomework();
            //NinethLessonFirstHomework();

            //IUserService userService = new UserManager(new EfUserDal());
            //User user1 = new User
            //{
            //    FirstName = "Mine",
            //    LastName = "Bozlak",
            //    Email = "mine@outlook.com",
            //    Password = "1234mine456"
            //};
            //userService.Add(user1);
            //var users = userService.GetAll().Data;
            //users.ForEach(u => Console.WriteLine(u));

            ICustomerService customerService = new CustomerManager(new EfCustomerDal());
            //Customer customer1 = new Customer
            //{
            //    UserId = 2,
            //    CompanyName = "Meryem Kurban Çocuk Kreşi"
            //};
            //Result result = customerService.Add(customer1);
            //Console.WriteLine(result.Message);
            var customers = customerService.GetAll().Data;
            customers.ForEach(c => Console.WriteLine(c));
            Console.WriteLine("---------");

            IRentalService rentalService = new RentalManager(new EfRentalDal());
            Rental rental1 = new Rental
            {
                CarId = 1,
                CustomerId = 1,
                RentDate = "2022-12-11"
            };
            Result result = rentalService.Add(rental1);
            Console.WriteLine(result.Message);
            //var rentals = rentalService.GetAll().Data;
            //rentals.ForEach(r => Console.WriteLine(r));
        }

        private static void NinethLessonFirstHomework()
        {
            ICarService carService = new CarManager(new EfCarDal());
            //Car car2 = new Car
            //{
            //    CarId = 2,
            //    BrandId = 1,
            //    ColorId = 1,
            //    ModelYear = 2018,
            //    DailyPrice = 650,
            //    Description = "Audi A7"
            //};
            //carService.Update(car2);

            //Car car = carService.GetById(2);
            //Console.WriteLine($"{car.CarId} - {car.Description} - {car.ModelYear} - {car.DailyPrice}");

            //carService.Delete(car2);

            //List<Car> cars = carService.GetAll();
            //foreach (var car in cars)
            //{
            //    Console.WriteLine($"{car.CarId} - {car.Description} - {car.ModelYear} - {car.DailyPrice}");
            //}
            Console.WriteLine("---------");

            IColorService colorService = new ColorManager(new EfColorDal());
            //Color color2 = new Color { ColorName = "red" };
            //colorService.Add(color2);

            //Color color2 = new Color { ColorName = "Mavi", ColorId = 2 };
            //colorService.Update(color2);

            //Color color = colorService.GetById(2);
            //Console.WriteLine($"{color.ColorId} - {color.ColorName}");

            //colorService.Delete(color2);

            //List<Color> colors = colorService.GetAll();
            //foreach (var color in colors)
            //{
            //    Console.WriteLine($"{color.ColorId} - {color.ColorName}");
            //}
            Console.WriteLine("---------");

            IBrandService brandService = new BrandManager(new EfBrandDal());
            //Brand brand2 = new Brand { BrandName = "Mercedes" };
            //brandService.Add(brand2);

            //Brand brand2 = new Brand { BrandName = "Fiat", BrandId = 2 };
            //brandService.Update(brand2);

            //Brand brand = brandService.GetById(2);
            //Console.WriteLine($"{brand.BrandId} - {brand.BrandName}");

            //brandService.Delete(brand2);

            //List<Brand> brands = brandService.GetAll();
            //foreach (var brand in brands)
            //{
            //    Console.WriteLine($"{brand.BrandId} - {brand.BrandName}");
            //}
            Console.WriteLine("----- Car Detail DTO -----");

            //List<CarDetailDto> carDetailDtos = carService.GetCarsByDetail();
            //foreach (var carDetailDto in carDetailDtos)
            //{
            //    Console.WriteLine($"{carDetailDto.CarName} - {carDetailDto.BrandName} - " +
            //        $"{carDetailDto.ColorName} - {carDetailDto.DailyPrice}");
            //}
        }

        private static void EigthLessonFirstHomework()
        {
            Car car1 = new Car
            {
                BrandId = 1,
                ColorId = 1,
                ModelYear = 2019,
                DailyPrice = -300,
                Description = "Audi A5"
            };

            ICarService carService = new CarManager(new EfCarDal());
            carService.Add(car1);
            Console.WriteLine("-------");
            //List<Car> cars = carService.GetCarsByColorId(1);
            //foreach (var car in cars)
            //{
            //    Console.WriteLine($"Araba Adı : {car.Description}, Günlük Fiyatı : {car.DailyPrice}");
            //}
        }
    }
}