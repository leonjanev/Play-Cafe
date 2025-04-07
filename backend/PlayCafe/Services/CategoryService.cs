using System.Data;
using PlayCafe.ViewModels.Cafe;
using PlayCafe.Services.Interfaces;
using Microsoft.Data.SqlClient;

namespace PlayCafe.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly string _connectionString;

        public CategoryService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AppDbContextConnection");
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetAllCategories", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var categories = new List<Category>();

                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            categories.Add(new Category
                            {
                                Id = reader.GetInt32("Id"),
                                Name = reader.GetString("Name"),
                                Description = reader.GetString("Description")
                            });
                        }
                    }
                    return categories;
                }
            }
        }

        public async Task<Category> GetCategoryById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetCategoryById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Category
                            {
                                Id = reader.GetInt32("Id"),
                                Name = reader.GetString("Name"),
                                Description = reader.GetString("Description")
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public async Task<int> CreateCategory(Category category)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CreateCategory", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", category.Name);
                    cmd.Parameters.AddWithValue("@Description", category.Description);
                    
                    SqlParameter outputParam = new SqlParameter
                    {
                        ParameterName = "@Id",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    
                    return (int)outputParam.Value;
                }
            }
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateCategory", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", category.Id);
                    cmd.Parameters.AddWithValue("@Name", category.Name);
                    cmd.Parameters.AddWithValue("@Description", category.Description);

                    await conn.OpenAsync();
                    int result = await cmd.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
        }

        public async Task<bool> DeleteCategory(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeleteCategory", conn))
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