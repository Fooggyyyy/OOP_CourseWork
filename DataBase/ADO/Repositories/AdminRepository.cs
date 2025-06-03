using Microsoft.Data.SqlClient;
using OOP_CourseWork.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace OOP_CourseWork.DataBase.ADO.Repositories
{
    public class AdminRepository : IAdminRepository, IDisposable
    {
        private readonly AdminDbContext _context;
        private bool _disposed;

        public AdminRepository(AdminDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var products = new List<Product>();
            using var connection = _context.CreateConnection();
            using var command = new SqlCommand("SELECT * FROM Products", connection);
            using var reader = await command.ExecuteReaderAsync();
            
            while (await reader.ReadAsync())
            {
                products.Add(MapProductFromReader(reader));
            }

            return products;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            using var connection = _context.CreateConnection();
            using var command = new SqlCommand("SELECT * FROM Products WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            using var reader = await command.ExecuteReaderAsync();
            
            if (await reader.ReadAsync())
            {
                return MapProductFromReader(reader);
            }

            return null;
        }

        public async Task<int> AddProductAsync(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("Product name cannot be empty", nameof(product));

            using var connection = _context.CreateConnection();
            using var command = new SqlCommand(
                @"INSERT INTO Products (Name, Description, Price, TypeWear, Image) 
                  VALUES (@Name, @Description, @Price, @TypeWear, @Image);
                  SELECT SCOPE_IDENTITY();", 
                connection);

            try
            {
                command.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = product.Name.Trim();
                command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = 
                    (object?)product.Description?.Trim() ?? DBNull.Value;
                command.Parameters.Add("@Price", SqlDbType.Decimal).Value = product.Price;
                command.Parameters.Add("@TypeWear", SqlDbType.Int).Value = (int)product.TypeWear;
                command.Parameters.Add("@Image", SqlDbType.VarBinary).Value = 
                    (object?)product.Image ?? DBNull.Value;

                var result = await command.ExecuteScalarAsync();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
                throw new Exception("Failed to get the ID of the inserted product");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add product: {ex.Message}", ex);
            }
        }

        public async Task UpdateProductAsync(Product product)
        {
            using var connection = _context.CreateConnection();
            using var command = new SqlCommand(
                @"UPDATE Products 
                  SET Name = @Name, Description = @Description, 
                      Price = @Price, TypeWear = @TypeWear, Image = @Image
                  WHERE Id = @Id", 
                connection);

            command.Parameters.AddWithValue("@Id", product.Id);
            AddProductParameters(command, product);
            await command.ExecuteNonQueryAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            using var connection = _context.CreateConnection();
            using var command = new SqlCommand(
                "DELETE FROM Products WHERE Id = @Id", 
                connection);

            command.Parameters.AddWithValue("@Id", id);
            await command.ExecuteNonQueryAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsSortedAsync(string sortBy)
        {
            var products = new List<Product>();
            using var connection = _context.CreateConnection();
            using var command = new SqlCommand($"SELECT * FROM Products ORDER BY {sortBy}", connection);
            using var reader = await command.ExecuteReaderAsync();
            
            while (await reader.ReadAsync())
            {
                products.Add(MapProductFromReader(reader));
            }

            return products;
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm)
        {
            var products = new List<Product>();
            using var connection = _context.CreateConnection();
            using var command = new SqlCommand(
                "SELECT * FROM Products WHERE Name LIKE @SearchTerm OR Description LIKE @SearchTerm", 
                connection);

            command.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");
            using var reader = await command.ExecuteReaderAsync();
            
            while (await reader.ReadAsync())
            {
                products.Add(MapProductFromReader(reader));
            }

            return products;
        }

        public async Task<byte[]> GetProductImageAsync(int id)
        {
            using var connection = _context.CreateConnection();
            using var command = new SqlCommand("SELECT Image FROM Products WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            var result = await command.ExecuteScalarAsync();
            return result as byte[];
        }

        public async Task UpdateProductImageAsync(int id, byte[] imageData)
        {
            using var connection = _context.CreateConnection();
            using var command = new SqlCommand(
                "UPDATE Products SET Image = @Image WHERE Id = @Id", 
                connection);

            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Image", imageData ?? (object)DBNull.Value);
            await command.ExecuteNonQueryAsync();
        }

        private Product MapProductFromReader(SqlDataReader reader)
        {
            return new Product
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Name = reader.GetString(reader.GetOrdinal("Name")),
                Description = reader.IsDBNull(reader.GetOrdinal("Description")) 
                    ? null 
                    : reader.GetString(reader.GetOrdinal("Description")),
                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                TypeWear = (TypeWear)reader.GetInt32(reader.GetOrdinal("TypeWear")),
                Image = reader.IsDBNull(reader.GetOrdinal("Image")) 
                    ? null 
                    : (byte[])reader["Image"]
            };
        }

        private void AddProductParameters(SqlCommand command, Product product)
        {
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Description", product.Description ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@TypeWear", (int)product.TypeWear);
            command.Parameters.AddWithValue("@Image", product.Image ?? (object)DBNull.Value);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _context?.Dispose();
                _disposed = true;
            }
        }
    }
} 