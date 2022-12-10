using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfRentalDal : EfEntityRepository<Rental, RentACarContext>, IRentalDal
    {
        public bool HaveAllCarsTurned(int customerId)
        {
            Rental lastRental = null;
            using (RentACarContext context = new RentACarContext())
            {
                lastRental = context.Rentals.Where(r => r.CustomerId == customerId).OrderBy(r => r.ReturnDate).Last();
            }
            if (lastRental.ReturnDate != "donmedi   ")
            {
                return true;
            }
            return false;
        }
    }
}
