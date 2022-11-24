using DeLaSalle.Ecommerce.Core.Dto;

namespace DeLaSalle.Ecommerce.Api.Services.Interfaces
{
    public interface IBrandService
    {
        Task<List<BrandDto>?> GetAllAsync();
        Task<BrandDto?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<BrandDto> SaveAsync(BrandDto dto);
        Task<BrandDto> UpdateAsync(BrandDto dto);
    }
}