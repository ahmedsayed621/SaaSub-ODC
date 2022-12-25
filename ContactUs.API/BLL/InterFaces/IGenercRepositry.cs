﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactUs.API.BLL.Spcefication;
using ContactUs.API.Data;
using ContactUs.API.Model;

namespace ContactUs.API.BLL.InterFaces
{
    public interface IGenercRepositry<T>  where T : BaseEntity
    {
        Task Add(T entity);
        T Delete(T entity);
        T Update(T entity);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetDataByIdAsync(int id);
        Task<T> GetDataByNameAsync(string Name);
        Task<IReadOnlyList<T>> GetAllDataWithSpecificatonAsync(ISpecification<T> spec);
        Task<T> GetDataByIdWithSpecificatonAsync(ISpecification<T> spec);
        Task<int> Count(ISpecification<T> spec);
    }
}
