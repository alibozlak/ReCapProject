﻿using Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IEntityService<T> where T : class, IEntity, new()
    {
        void Add(T entity);
    }
}
