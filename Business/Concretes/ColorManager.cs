using Business.Abstracts;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

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
            ValidationTool.Validate(new ColorValidator(), entity);

            this.colorDal.Add(entity);
            return new SuccessResult($"{entity.ColorName} adlı renk eklendi");
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
            ValidationTool.Validate(new ColorValidator(), entity);

            this.colorDal.Update(entity);
            return new SuccessResult($"{entity.ColorName} adlı renk güncellendi");
        }

        // ************* FluentValidation'a geçildi **************
        //private bool IsColorNameEmpty(string colorName)
        //{
        //    if (colorName == null || colorName.Length < 1)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
