using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        private IUserDal userDal;

        public UserManager(IUserDal userDal)
        {
            this.userDal = userDal;
        }

        public Result Add(User entity)
        {
            //
            //
            this.userDal.Add(entity);
            return new SuccessResult($"{entity.FirstName} adlı user eklendi");
        }

        public Result Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public SuccessDataResult<List<User>> GetAll()
        {
            var data = this.userDal.GetAll();
            var message = "Tüm kullanıcılar (users) listelendi";
            return new SuccessDataResult<List<User>>(message,data);
        }

        public Result GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Result Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
