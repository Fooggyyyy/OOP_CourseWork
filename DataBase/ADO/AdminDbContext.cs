using Microsoft.Data.SqlClient;
using System;
using System.Configuration;

namespace OOP_CourseWork.DataBase.ADO
{
    public class AdminDbContext : IDisposable
    {
        private readonly string _connectionString;
        private bool _disposed;

        public AdminDbContext()
        {
            try
            {
                _connectionString = ConfigurationManager.ConnectionStrings["ShopConnection"]?.ConnectionString 
                    ?? throw new ConfigurationErrorsException("ShopConnection string not found in configuration");
                
                // Initialize database if needed
                DatabaseInitializer.Initialize();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to initialize AdminDbContext: {ex.Message}", ex);
            }
        }

        public SqlConnection CreateConnection()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(AdminDbContext));
            }

            var connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                connection.Dispose();
                throw new Exception($"Failed to create connection: {ex.Message}", ex);
            }
        }

        public void Dispose()
        {
            _disposed = true;
        }
    }
} 