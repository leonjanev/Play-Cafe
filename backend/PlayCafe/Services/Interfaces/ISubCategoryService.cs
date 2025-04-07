using PlayCafe.ViewModels.Cafe;

namespace PlayCafe.Services.Interfaces
{
    public interface ISubCategoryService
    {
        Task<IEnumerable<SubCategory>> GetAllSubCategories();
        Task<IEnumerable<SubCategory>> GetSubCategoriesByCategoryId(int categoryId);
        Task<SubCategory> GetSubCategoryById(int id);
        Task<int> CreateSubCategory(SubCategory subCategory);
        Task<bool> UpdateSubCategory(SubCategory subCategory);
        Task<bool> DeleteSubCategory(int id);
    }
} 