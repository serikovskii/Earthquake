﻿using System.Collections.Generic;

namespace EarthQuakeTest.Services.Abstract
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Delete(T entity);
        List<T> GetAll();
    }
}
