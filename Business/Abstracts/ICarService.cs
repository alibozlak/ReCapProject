using Core.Utilities.Results;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICarService : IEntityService<Car>
    {
        Result GetCarsByBrandId(int brandId);
        Result GetCarsByColorId(int colorId);

        Result GetCarsByDetail();
    }
}
