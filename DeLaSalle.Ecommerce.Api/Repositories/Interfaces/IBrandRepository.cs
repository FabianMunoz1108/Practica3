﻿using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Entities;

namespace DeLaSalle.Ecommerce.Api.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        Task<List<Brand>> GetAllAsync();
        Task<Brand> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<Brand> SaveAsync(Brand brand);
        Task<Brand> UpdateAsync(Brand brand);
    }
}