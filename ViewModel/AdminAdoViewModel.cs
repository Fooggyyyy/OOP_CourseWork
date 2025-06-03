using OOP_CourseWork.Commands;
using OOP_CourseWork.DataBase.ADO;
using OOP_CourseWork.DataBase.ADO.Repositories;
using OOP_CourseWork.Model;
using OOP_CourseWork.View;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.IO;

namespace OOP_CourseWork.ViewModel
{
    public class AdminAdoViewModel : INotifyPropertyChanged
    {
        private readonly IAdminRepository _repository;
        private readonly Window _currentWindow;
        private Product _selectedProduct;
        private string _searchTerm;
        private string _selectedSortOption;
        private ObservableCollection<Product> _products;

        public event PropertyChangedEventHandler PropertyChanged;

        public AdminAdoViewModel(IAdminRepository repository, Window currentWindow)
        {
            _repository = repository;
            _currentWindow = currentWindow;
            InitializeCommands();
            LoadProducts();
            InitializeSortOptions();
        }

        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        public string SearchTerm
        {
            get => _searchTerm;
            set
            {
                _searchTerm = value;
                OnPropertyChanged(nameof(SearchTerm));
                SearchProducts();
            }
        }

        public ObservableCollection<string> SortOptions { get; } = new ObservableCollection<string>
        {
            "Name",
            "Price",
            "TypeWear"
        };

        public string SelectedSortOption
        {
            get => _selectedSortOption;
            set
            {
                _selectedSortOption = value;
                OnPropertyChanged(nameof(SelectedSortOption));
                SortProducts();
            }
        }

        public ICommand AddCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand NavigateToMainCommand { get; private set; }
        public ICommand ReinitializeDatabaseCommand { get; private set; }

        private void InitializeCommands()
        {
            AddCommand = new RelayCommand(async _ => await AddProduct());
            EditCommand = new RelayCommand(async _ => await EditProduct(), _ => SelectedProduct != null);
            DeleteCommand = new RelayCommand(async _ => await DeleteProduct(), _ => SelectedProduct != null);
            RefreshCommand = new RelayCommand(async _ => await LoadProducts());
            NavigateToMainCommand = new RelayCommand(_ => NavigateToMain());
            ReinitializeDatabaseCommand = new RelayCommand(_ => ReinitializeDatabase());
        }

        private async Task LoadProducts()
        {
            try
            {
                var products = await _repository.GetAllProductsAsync();
                Products = new ObservableCollection<Product>(products);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task AddProduct()
        {
            try
            {
                var product = new Product
                {
                    Name = "",
                    Description = "",
                    Price = 0,
                    TypeWear = TypeWear.Hoodie
                };

                // Try to load default image
                var defaultImagePath = @"D:\OIP.jpg";
                if (File.Exists(defaultImagePath))
                {
                    product.Image = File.ReadAllBytes(defaultImagePath);
                }

                var dialog = new ProductDialog(product);
                dialog.Owner = _currentWindow;
                
                if (dialog.ShowDialog() == true)
                {
                    // Verify product data before saving
                    if (string.IsNullOrWhiteSpace(product.Name))
                    {
                        MessageBox.Show("Product name cannot be empty.", "Validation Error");
                        return;
                    }

                    if (product.Price <= 0)
                    {
                        MessageBox.Show("Product price must be greater than 0.", "Validation Error");
                        return;
                    }

                    // Log product data before saving
                    Console.WriteLine($"Adding product: Name={product.Name}, Price={product.Price}, Type={product.TypeWear}");
                    
                    var productId = await _repository.AddProductAsync(product);
                    Console.WriteLine($"Product added successfully with ID: {productId}");
                    
                    await LoadProducts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding product: {ex.Message}\n\nStack Trace:\n{ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task EditProduct()
        {
            if (SelectedProduct == null) return;

            try
            {
                var productCopy = new Product
                {
                    Id = SelectedProduct.Id,
                    Name = SelectedProduct.Name,
                    Description = SelectedProduct.Description,
                    Price = SelectedProduct.Price,
                    TypeWear = SelectedProduct.TypeWear,
                    Image = SelectedProduct.Image
                };

                var dialog = new ProductDialog(productCopy);
                
                if (dialog.ShowDialog() == true)
                {
                    await _repository.UpdateProductAsync(productCopy);
                    await LoadProducts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error editing product: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task DeleteProduct()
        {
            if (SelectedProduct == null) return;

            try
            {
                var result = MessageBox.Show(
                    $"Are you sure you want to delete {SelectedProduct.Name}?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    await _repository.DeleteProductAsync(SelectedProduct.Id);
                    await LoadProducts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting product: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void SearchProducts()
        {
            if (string.IsNullOrWhiteSpace(SearchTerm))
            {
                await LoadProducts();
                return;
            }

            try
            {
                var products = await _repository.SearchProductsAsync(SearchTerm);
                Products = new ObservableCollection<Product>(products);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching products: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void SortProducts()
        {
            if (string.IsNullOrWhiteSpace(SelectedSortOption))
            {
                await LoadProducts();
                return;
            }

            try
            {
                var products = await _repository.GetProductsSortedAsync(SelectedSortOption);
                Products = new ObservableCollection<Product>(products);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sorting products: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NavigateToMain()
        {
            var mainWindow = new MainWindow(null);
            mainWindow.Show();
            _currentWindow.Close();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void InitializeSortOptions()
        {
            SelectedSortOption = SortOptions[0];
        }

        private void ReinitializeDatabase()
        {
            try
            {
                var result = MessageBox.Show(
                    "This will delete all existing data and recreate the database. Are you sure?",
                    "Confirm Database Reinitialization",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    DatabaseInitializer.Initialize();
                    LoadProducts();
                    MessageBox.Show("Database reinitialized successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reinitializing database: {ex.Message}\n\nStack Trace:\n{ex.StackTrace}", 
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
} 