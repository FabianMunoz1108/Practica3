using DeLaSalle.Ecommerce.Core.Dto;

namespace DeLaSalle.Ecommerce.Api.Services.Interfaces
{
    public interface IProductCategoryService
    {
        Task<bool> ProductCategoryExists(int id);
        Task<ProductCategoryDto> SaveAsync(ProductCategoryDto customer);
        Task<ProductCategoryDto> UpdateAsync(ProductCategoryDto customer);
        Task<List<ProductCategoryDto>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
        Task<ProductCategoryDto> GetByIdAsync(int id);
    }
}
