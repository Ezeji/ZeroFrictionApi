﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFriction.Core.Entities;

namespace ZeroFriction.Core.Interfaces
{
    public interface IDataRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T newEntity);
        Task<T> GetAsync(string entityId);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(string entityId);
        Task<IReadOnlyList<T>> GetAllAsync();
    }
}
