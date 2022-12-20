using Business.Abstracts;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class RentalManager : IRentalService
    {
        private IRentalDal rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            this.rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public Result Add(Rental entity)
        {
            int customerId = entity.CustomerId;
            if (this.rentalDal.HaveAllCarsTurned(customerId))
            {
                this.rentalDal.Add(entity);
                return new SuccessResult($"Araba kimliği {entity.CarId} olan araç kiralandı");
            }
            return new ErrorResult($"ID'si {customerId} olan müşterinin teslim etmediği araç bulunmakta! Bundan dolayı kiralama işlemi başarısız!");
        }

        public Result Delete(Rental entity)
        {
            throw new NotImplementedException();
        }

        public SuccessDataResult<List<Rental>> GetAll()
        {
            var data = this.rentalDal.GetAll();
            var message = "Tüm araba kiralamaları listelendi";
            return new SuccessDataResult<List<Rental>>(message, data);
        }

        public Result GetById(int id)
        {
            throw new NotImplementedException();
        }

        [ValidationAspect(typeof(RentalValidator))]
        public Result Update(Rental entity)
        {
            this.rentalDal.Update(entity);
            return new SuccessResult($"Kimliği {entity.CarId} olan araç güncellendi");
        }
    }
}
