﻿using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IBrandDal : IEntityDal<Brand>
    {
        bool ExistByBrandId(int brandId);
    }
}