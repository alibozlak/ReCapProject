using Business.Abstracts;
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

        public void Add(Color entity)
        {
            if (!this.IsColorNameEmpty(entity.ColorName))
            {
                this.colorDal.Add(entity);
            }
        }

        public void Delete(Color entity)
        {
            this.colorDal.DeleteByEntity(entity);
        }

        public List<Color> GetAll()
        {
            return this.colorDal.GetAll();
        }

        public Color GetById(int id)
        {
            return this.colorDal.Get(c => c.ColorId == id);
        }

        public void Update(Color entity)
        {
            if (!this.IsColorNameEmpty(entity.ColorName))
            {
                this.colorDal.Update(entity);
            }
        }

        private bool IsColorNameEmpty(string colorName)
        {
            if (colorName == null || colorName.Length < 1)
            {
                Console.WriteLine("Arabanın renk ismi boş olamaz!");
                return true;
            }
            return false;
        }
    }
}
