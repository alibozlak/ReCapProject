using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfCarDal : EfEntityRepository<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarsByDetail()
        {
            using (RentACarContext rentACarContext = new RentACarContext())
            {
                var result = from c in rentACarContext.Cars
                             join b in rentACarContext.Brands on c.BrandId equals b.BrandId
                             join co in rentACarContext.Colors on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 CarName = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
