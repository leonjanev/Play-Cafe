using System.Data;
using PlayCafe.ViewModels.Cafe;
using PlayCafe.Services.Interfaces;
using Microsoft.Data.SqlClient;

namespace PlayCafe.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly string _connectionString;

        public SubCategoryService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AppDbContextConnection");
        }

        public async Task<IEnumerable<SubCategory>> GetAllSubCategories()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetAllSubCategories", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var subCategories = new List<SubCategory>();

                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            subCategories.Add(new SubCategory
                            {
                                Id = reader.GetInt32("Id"),
                                Name = reader.GetString("Name"),
                                Description = reader.GetString("Description"),
                                CategoryId = reader.GetInt32("CategoryId")
                            });
                        }
                    }
                    return subCategories;
                }
            }
        }

        public async Task<IEnumerable<SubCategory>> GetSubCategoriesByCategoryId(int categoryId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetSubCategoriesByCategoryId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    var subCategories = new List<SubCategory>();

                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            subCategories.Add(new SubCategory
                            {
                                Id = reader.GetInt32("Id"),
                                Name = reader.GetString("Name"),
                                Description = reader.GetString("Description"),
                                CategoryId = reader.GetInt32("CategoryId")
                            });
                        }
                    }
                    return subCategories;
                }
            }
        }
  public async Task<SubCategory> GetSubCategoryById(int id)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            using (SqlCommand cmd = new SqlCommand("sp_GetSubCategoryById", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new SubCategory
                        {
                            Id = reader.GetInt32("Id"),
                            Name = reader.GetString("Name"),
                            Description = reader.GetString("Description"),
                            CategoryId = reader.GetInt32("CategoryId")
                        };
                    }
                    return null;
                }
            }
        }
    }

    public async Task<int> CreateSubCategory(SubCategory subCategory)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            using (SqlCommand cmd = new SqlCommand("sp_CreateSubCategory", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", subCategory.Name);
                cmd.Parameters.AddWithValue("@Description", subCategory.Description);
                cmd.Parameters.AddWithValue("@CategoryId", subCategory.CategoryId);

                SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputIdParam);

                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();

                return (int)outputIdParam.Value;
            }
        }
    }

    public async Task<bool> UpdateSubCategory(SubCategory subCategory)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            using (SqlCommand cmd = new SqlCommand("sp_UpdateSubCategory", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", subCategory.Id);
                cmd.Parameters.AddWithValue("@Name", subCategory.Name);
                cmd.Parameters.AddWithValue("@Description", subCategory.Description);
                cmd.Parameters.AddWithValue("@CategoryId", subCategory.CategoryId);

                await conn.OpenAsync();
                int result = await cmd.ExecuteNonQueryAsync();
                return result > 0;
            }
        }
    }

    public async Task<bool> DeleteSubCategory(int id)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            using (SqlCommand cmd = new SqlCommand("sp_DeleteSubCategory", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                await conn.OpenAsync();
                int result = await cmd.ExecuteNonQueryAsync();
                return result > 0;
            }
        }
    }
    }
} 