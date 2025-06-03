using Microsoft.Data.SqlClient;
using System;
using System.IO;

namespace OOP_CourseWork.Data
{
    public class DatabaseInitializer
    {
        private readonly string _connectionString;
        private readonly string _databaseName;

        public DatabaseInitializer(string serverName = ".", string databaseName = "OOP_Course_Work_ADO")
        {
            _databaseName = databaseName;
            _connectionString = $"Server={serverName};Integrated Security=true;TrustServerCertificate=True;Encrypt=False;";
        }

        public bool Initialize()
        {
            try
            {
                if (DatabaseExists())
                {
                    Console.WriteLine("Database already exists, skipping initialization.");
                    return true;
                }

                Console.WriteLine("Starting database initialization...");
                CreateDatabaseIfNotExists();
                CreateTables();
                CreateTriggers();
                CreateStoredProcedures();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing database: {ex.Message}");
                return false;
            }
        }

        private bool DatabaseExists()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(
                        $"SELECT database_id FROM sys.databases WHERE Name = '{_databaseName}'",
                        connection);
                    return (command.ExecuteScalar() != null);
                }
            }
            catch
            {
                return false;
            }
        }

        private void CreateDatabaseIfNotExists()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand($"CREATE DATABASE [{_databaseName}]", connection);
                command.ExecuteNonQuery();
            }
        }

        private void CreateTables()
        {
            var connectionString = $"Server=.;Database={_databaseName};Integrated Security=true;TrustServerCertificate=True;Encrypt=False;";
            var createTablesScript = @"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE [dbo].[Products] (
                        [Id] INT IDENTITY(1,1) PRIMARY KEY,
                        [Name] NVARCHAR(100) NOT NULL,
                        [Description] NVARCHAR(MAX),
                        [Price] DECIMAL(18,2) NOT NULL,
                        [TypeWear] INT NOT NULL,
                        [Image] VARBINARY(MAX)
                    )
                END

                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE [dbo].[Orders] (
                        [Id] INT IDENTITY(1,1) PRIMARY KEY,
                        [OrderDate] DATETIME NOT NULL DEFAULT GETDATE(),
                        [TotalAmount] DECIMAL(18,2) NOT NULL,
                        [Status] INT NOT NULL DEFAULT 0
                    )
                END

                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderItems]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE [dbo].[OrderItems] (
                        [Id] INT IDENTITY(1,1) PRIMARY KEY,
                        [OrderId] INT NOT NULL,
                        [ProductId] INT NOT NULL,
                        [Quantity] INT NOT NULL,
                        [Price] DECIMAL(18,2) NOT NULL,
                        FOREIGN KEY ([OrderId]) REFERENCES [Orders]([Id]),
                        FOREIGN KEY ([ProductId]) REFERENCES [Products]([Id])
                    )
                END";

            ExecuteScript(createTablesScript, connectionString);
        }

        private void CreateTriggers()
        {
            var connectionString = $"Server=.;Database={_databaseName};Integrated Security=true;TrustServerCertificate=True;Encrypt=False;";
            var createTriggersScript = @"
                IF NOT EXISTS (SELECT * FROM sys.triggers WHERE name = 'TR_OrderItems_Insert')
                BEGIN
                    EXEC('CREATE TRIGGER TR_OrderItems_Insert
                        ON [dbo].[OrderItems]
                        AFTER INSERT
                        AS
                        BEGIN
                            UPDATE o
                            SET TotalAmount = (
                                SELECT SUM(oi.Price * oi.Quantity)
                                FROM OrderItems oi
                                WHERE oi.OrderId = o.Id
                            )
                            FROM Orders o
                            INNER JOIN inserted i ON o.Id = i.OrderId
                        END')
                END";

            ExecuteScript(createTriggersScript, connectionString);
        }

        private void CreateStoredProcedures()
        {
            var connectionString = $"Server=.;Database={_databaseName};Integrated Security=true;TrustServerCertificate=True;Encrypt=False;";
            var createProceduresScript = @"
                IF NOT EXISTS (SELECT * FROM sys.procedures WHERE name = 'GetProductsByType')
                BEGIN
                    EXEC('CREATE PROCEDURE GetProductsByType
                        @TypeWear INT
                        AS
                        BEGIN
                            SELECT * FROM Products
                            WHERE TypeWear = @TypeWear
                        END')
                END

                IF NOT EXISTS (SELECT * FROM sys.procedures WHERE name = 'UpdateProductPrice')
                BEGIN
                    EXEC('CREATE PROCEDURE UpdateProductPrice
                        @ProductId INT,
                        @NewPrice DECIMAL(18,2)
                        AS
                        BEGIN
                            UPDATE Products
                            SET Price = @NewPrice
                            WHERE Id = @ProductId
                        END')
                END";

            ExecuteScript(createProceduresScript, connectionString);
        }

        private void ExecuteScript(string script, string connectionString = null)
        {
            using (var connection = new SqlConnection(connectionString ?? _connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new SqlCommand(script, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error executing script: {ex.Message}", ex);
                }
            }
        }
    }
} 