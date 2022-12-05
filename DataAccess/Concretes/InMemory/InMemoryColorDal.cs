using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        private List<Color> colors;

        public InMemoryColorDal()
        {
            colors= new List<Color>()
            {
                new Color {ColorId = 1, ColorName = "Mavi"},
                new Color {ColorId = 2, ColorName = "Beyaz"},
                new Color {ColorId = 3, ColorName = "Siyah"},
            };
        }

        public void Add(Color item)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExistByColorId(int colorId)
        {
            foreach (var color in colors)
            {
                if (color.ColorId == colorId)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Color> GetAll()
        {
            throw new NotImplementedException();
        }

        public Color GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Color item)
        {
            throw new NotImplementedException();
        }
    }
}
