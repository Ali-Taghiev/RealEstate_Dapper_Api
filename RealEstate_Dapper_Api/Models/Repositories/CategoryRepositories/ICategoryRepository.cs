using RealEstate_Dapper_Api.Models.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Models.Repositories.CategoryRepositories
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        void CreateCategory(CreateCategoryDto categoryDto);
        void DeleteCategory(int ID);
        Task UpdateCategory(UpdateCategoryDto categoryDto);
        Task <GetByIdCategoryDto> GetCategory(int ID);
    }
}
