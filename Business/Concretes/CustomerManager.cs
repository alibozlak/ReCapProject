using Business.Abstracts;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            this.customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public Result Add(Customer entity)
        {
            this.customerDal.Add(entity);
            return new SuccessResult("Müşteri eklendi");
        }

        public Result Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public SuccessDataResult<List<Customer>> GetAll()
        {
            var data = this.customerDal.GetAll();
            var message = "Tüm müşteriler listelendi";
            return new SuccessDataResult<List<Customer>>(message, data);
        }

        public Result GetById(int id)
        {
            throw new NotImplementedException();
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public Result Update(Customer entity)
        {
            this.customerDal.Update(entity);
            return new SuccessResult($"Şirket ismi {entity.CompanyName} olan müşteri güncellendi");
        }
    }
}
