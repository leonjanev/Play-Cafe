using System.Data;
using PlayCafe.ViewModels.Cafe;
using PlayCafe.Services.Interfaces;
using Microsoft.Data.SqlClient;

namespace PlayCafe.Services
{

    public class ProductService : IProductService
    {
        private readonly string _connectionString;

        public ProductService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AppDbContextConnection");
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetAllProducts", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var products = new List<Product>();

                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            products.Add(new Product
                            {
                                Id = reader.GetInt32("Id"),
                                Name = reader.GetString("Name"),
                                Description = reader.GetString("Description"),
                                Price = reader.GetDecimal("Price"),
                                ImageUrl = reader.GetString("ImageUrl"),
                                IsAvailable = reader.GetBoolean("IsAvailable"),
                                CreatedAt = reader.GetDateTime("CreatedAt"),
                                SubCategoryId = reader.GetInt32("SubCategoryId")
                            });
                        }
                    }
                    return products;
                }
            }
        }

        public async Task<IEnumerable<Product>> GetProductsBySubCategoryId(int subCategoryId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetProductsBySubCategoryId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubCategoryId", subCategoryId);
                    var products = new List<Product>();

                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            products.Add(new Product
                            {
                                Id = reader.GetInt32("Id"),
                                Name = reader.GetString("Name"),
                                Description = reader.GetString("Description"),
                                Price = reader.GetDecimal("Price"),
                                ImageUrl = reader.GetString("ImageUrl"),
                                IsAvailable = reader.GetBoolean("IsAvailable"),
                                CreatedAt = reader.GetDateTime("CreatedAt"),
                                SubCategoryId = reader.GetInt32("SubCategoryId")
                            });
                        }
                    }
                    return products;
                }
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetProductById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Product
                            {
                                Id = reader.GetInt32("Id"),
                                Name = reader.GetString("Name"),
                                Description = reader.GetString("Description"),
                                Price = reader.GetDecimal("Price"),
                                ImageUrl = reader.GetString("ImageUrl"),
                                IsAvailable = reader.GetBoolean("IsAvailable"),
                                CreatedAt = reader.GetDateTime("CreatedAt"),
                                SubCategoryId = reader.GetInt32("SubCategoryId")
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public async Task<int> CreateProduct(Product product)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CreateProduct", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@Description", product.Description);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@ImageUrl", product.ImageUrl);
                    cmd.Parameters.AddWithValue("@IsAvailable", product.IsAvailable);
                    cmd.Parameters.AddWithValue("@SubCategoryId", product.SubCategoryId);

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

        public async Task<bool> UpdateProduct(Product product)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateProduct", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", product.Id);
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@Description", product.Description);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@ImageUrl", product.ImageUrl);
                    cmd.Parameters.AddWithValue("@IsAvailable", product.IsAvailable);
                    cmd.Parameters.AddWithValue("@SubCategoryId", product.SubCategoryId);

                    await conn.OpenAsync();
                    int result = await cmd.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
        }

        public async Task<bool> UpdateProductAvailability(int id, bool isAvailable)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateProductAvailability", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@IsAvailable", isAvailable);

                    await conn.OpenAsync();
                    int result = await cmd.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeleteProduct", conn))
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