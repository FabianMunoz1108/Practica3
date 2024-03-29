﻿using DeLaSalle.Ecommerce.Core.Entities;
using DeLaSalle.Ecommerce.Api.Repositories.Interfaces;

namespace DeLaSalle.Ecommerce.Api.Repositories
{
    public class InMemoryProductCategoryRepository : IProductCategoryRepository
    {
        private readonly List<ProductCategory> _categories;

        public InMemoryProductCategoryRepository()
        {
            _categories = new List<ProductCategory>();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductCategory>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductCategory> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductCategory> SaveAsync(ProductCategory category)
        {
            throw new NotImplementedException();
        }

        public Task<ProductCategory> UpdateAsync(ProductCategory category)
        {
            throw new NotImplementedException();
        }
    }
}