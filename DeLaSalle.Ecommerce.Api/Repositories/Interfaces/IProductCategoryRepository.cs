﻿using DeLaSalle.Ecommerce.Api.DataAccess;
using DeLaSalle.Ecommerce.Core.Entities;

namespace DeLaSalle.Ecommerce.Api.Repositories.Interfaces
{
    public interface IProductCategoryRepository
    {
        
        Task<ProductCategory> SaveAsync(ProductCategory category);
        Task<ProductCategory> UpdateAsync(ProductCategory category);
        Task<List<ProductCategory>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
        Task<ProductCategory> GetById(int id);
    }
}
