using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Car : IEntity
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public short ModelYear { get; set; }
        public double DailyPrice { get; set; }
        public string Description { get; set; } 

        public override String ToString()
        {
            return "{ carId : " + CarId + ", brandId : " + BrandId + ", colorId : " + ColorId +
                ", modelYear : " + ModelYear + ", dailyPrice : " + DailyPrice + ", description : "
                + Description + " }";
        }
    }
}
