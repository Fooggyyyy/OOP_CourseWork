using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Windows;

namespace OOP_CourseWork.DataBase.ADO
{
    public static class DatabaseInitializer
    {
        private static readonly string DefaultImagePath = @"D:\OIP.jpg";

        public static void Initialize()
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["ShopConnection"].ConnectionString;
                var masterConnectionString = new SqlConnectionStringBuilder(connectionString)
                {
                    InitialCatalog = "master"
                }.ConnectionString;

                // Check if database exists
                bool dbExists = false;
                using (var connection = new SqlConnection(masterConnectionString))
                {
                    connection.Open();
                    using var command = new SqlCommand(
                        "SELECT database_id FROM sys.databases WHERE Name = 'OOP_Course_Work_ADO'",
                        connection);
                    dbExists = command.ExecuteScalar() != null;
                }

                // If database exists, drop it
                if (dbExists)
                {
                    using (var connection = new SqlConnection(masterConnectionString))
                    {
                        connection.Open();
                        using var command = new SqlCommand(
                            "ALTER DATABASE [OOP_Course_Work_ADO] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;" +
                            "DROP DATABASE [OOP_Course_Work_ADO]",
                            connection);
                        command.ExecuteNonQuery();
                    }
                }

                // Create database
                using (var connection = new SqlConnection(masterConnectionString))
                {
                    connection.Open();
                    using var command = new SqlCommand(
                        "CREATE DATABASE [OOP_Course_Work_ADO]",
                        connection);
                    command.ExecuteNonQuery();
                }

                // Create tables and populate data
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    CreateTables(connection);
                    PopulateTables(connection);
                }

                MessageBox.Show("Database initialized successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize database: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }

        private static void CreateDatabase(string masterConnectionString)
        {
            using var connection = new SqlConnection(masterConnectionString);
            connection.Open();
            using var command = new SqlCommand(
                "CREATE DATABASE OOP_Course_Work_ADO",
                connection);
            command.ExecuteNonQuery();
        }

        private static void CreateTables(SqlConnection connection)
        {
            // Drop existing tables if they exist
            var dropTablesCommand = @"
                IF OBJECT_ID('OrderItems', 'U') IS NOT NULL DROP TABLE OrderItems;
                IF OBJECT_ID('Orders', 'U') IS NOT NULL DROP TABLE Orders;
                IF OBJECT_ID('Products', 'U') IS NOT NULL DROP TABLE Products;";

            using (var command = new SqlCommand(dropTablesCommand, connection))
            {
                command.ExecuteNonQuery();
            }

            // Create tables
            var createTablesCommand = @"
                CREATE TABLE Products (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Name NVARCHAR(100) NOT NULL,
                    Description NVARCHAR(MAX),
                    Price DECIMAL(18,2) NOT NULL,
                    TypeWear INT NOT NULL,
                    Image VARBINARY(MAX)
                );

                CREATE TABLE Orders (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
                    TotalAmount DECIMAL(18,2) NOT NULL,
                    Status NVARCHAR(50) NOT NULL
                );

                CREATE TABLE OrderItems (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    OrderId INT NOT NULL,
                    ProductId INT NOT NULL,
                    Quantity INT NOT NULL,
                    Price DECIMAL(18,2) NOT NULL,
                    FOREIGN KEY (OrderId) REFERENCES Orders(Id),
                    FOREIGN KEY (ProductId) REFERENCES Products(Id)
                );";

            using (var command = new SqlCommand(createTablesCommand, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        private static void PopulateTables(SqlConnection connection)
        {
            try
            {
                // Convert image to base64 string for SQL
                string imageBase64 = "";
                if (File.Exists(DefaultImagePath))
                {
                    byte[] imageBytes = File.ReadAllBytes(DefaultImagePath);
                    imageBase64 = Convert.ToBase64String(imageBytes);
                }

                // Create SQL script with direct inserts
                var populateScript = $@"
                    -- Insert Products
                    INSERT INTO Products (Name, Description, Price, TypeWear, Image)
                    VALUES 
                    ('Classic Hoodie', 'Comfortable cotton hoodie', 59.99, 0, CAST('' AS VARBINARY(MAX))),
                    ('Denim Jacket', 'Stylish denim jacket', 89.99, 1, CAST('' AS VARBINARY(MAX))),
                    ('Sport T-Shirt', 'Breathable sport t-shirt', 29.99, 2, CAST('' AS VARBINARY(MAX))),
                    ('Winter Coat', 'Warm winter coat', 129.99, 3, CAST('' AS VARBINARY(MAX))),
                    ('Casual Pants', 'Comfortable casual pants', 49.99, 4, CAST('' AS VARBINARY(MAX)));

                    -- Insert Orders
                    INSERT INTO Orders (OrderDate, TotalAmount, Status)
                    VALUES (GETDATE(), 179.97, 'Completed');

                    -- Get the OrderId
                    DECLARE @OrderId INT = SCOPE_IDENTITY();

                    -- Insert OrderItems
                    INSERT INTO OrderItems (OrderId, ProductId, Quantity, Price)
                    VALUES 
                    (@OrderId, 1, 2, 59.99),
                    (@OrderId, 3, 2, 29.99);

                    -- Verify data was inserted
                    SELECT 'Products Count: ' + CAST(COUNT(*) AS VARCHAR) FROM Products;
                    SELECT 'Orders Count: ' + CAST(COUNT(*) AS VARCHAR) FROM Orders;
                    SELECT 'OrderItems Count: ' + CAST(COUNT(*) AS VARCHAR) FROM OrderItems;";

                using (var command = new SqlCommand(populateScript, connection))
                {
                    using var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[0].ToString());
                    }
                }

                MessageBox.Show("Database populated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error populating database: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }
    }
} 