using Core.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Rental : IEntity
    {
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string RentDate { get; set; }
        public string ReturnDate { get; set; }

        public override string? ToString()
        {
            string rentalString = $"RentalId : {RentalId}, CarId : {CarId}, CustomerId : {CustomerId}, " +
                $"RentDate : {RentDate}";
            if (ReturnDate != "donmedi   ")
            {
                rentalString += $", ReturnDate : {ReturnDate}";
            }
            return rentalString;
        }
    }
}
