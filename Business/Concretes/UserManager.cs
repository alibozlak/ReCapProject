﻿using Business.Abstracts;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

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
            ValidationTool.Validate(new UserValidator(),entity);

            this.userDal.Add(entity);
            return new SuccessResult($"Email adresi {entity.Email} olan kullanıcı eklendi");
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
            ValidationTool.Validate(new UserValidator(), entity);

            this.userDal.Update(entity);
            return new SuccessResult($"Email adresi {entity.Email} olan kullanıcı güncellendi");
        }
    }
}
