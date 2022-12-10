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
    public class ColorManager : IColorService
    {
        private IColorDal colorDal;

        public ColorManager(IColorDal colorDal)
        {
            this.colorDal = colorDal;
        }

        public Result Add(Color entity)
        {
            var colorName = entity.ColorName;
            if (!this.IsColorNameEmpty(colorName))
            {
                this.colorDal.Add(entity);
                return new SuccessResult($"{colorName} adlı renk eklendi");
            }
            return new ErrorResult(Messages.Color.ColorNameIsntEmpty);
        }

        public Result Delete(Color entity)
        {
            this.colorDal.DeleteByEntity(entity);
            return new SuccessResult($"{entity.ColorName} adlı renk silindi");
        }

        public SuccessDataResult<List<Color>> GetAll()
        {
            var data = this.colorDal.GetAll();
            var message = "Tüm renkler listelendi";
            return new SuccessDataResult<List<Color>>(message,data);
        }

        public Result GetById(int id)
        {
            var data = this.colorDal.Get(c => c.ColorId == id);
            var message = $"ID'si {id} olan renk getirildi";
            return new SuccessDataResult<Color>(message,data);
        }

        public Result Update(Color entity)
        {
            var colorName = entity.ColorName;
            if (!this.IsColorNameEmpty(colorName))
            {
                this.colorDal.Update(entity);
                return new SuccessResult($"{colorName} adlı renk güncellendi");
            }
            return new ErrorResult(Messages.Color.ColorNameIsntEmpty);
        }

        private bool IsColorNameEmpty(string colorName)
        {
            if (colorName == null || colorName.Length < 1)
            {
                return true;
            }
            return false;
        }
    }
}
