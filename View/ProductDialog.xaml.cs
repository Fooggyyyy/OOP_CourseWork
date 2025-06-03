using Microsoft.Win32;
using OOP_CourseWork.Model;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Diagnostics;

namespace OOP_CourseWork.View
{
    public partial class ProductDialog : Window, INotifyPropertyChanged
    {
        private readonly Product _product;
        private BitmapImage _imageSource;
        private string _name;
        private string _description;
        private decimal _price;
        private TypeWear _typeWear;

        public event PropertyChangedEventHandler PropertyChanged;

        public ProductDialog(Product product)
        {
            InitializeComponent();
            _product = product ?? new Product();
            
            // Initialize properties from product
            _name = _product.Name ?? "";
            _description = _product.Description ?? "";
            _price = _product.Price;
            _typeWear = _product.TypeWear;
            
            DataContext = this;
            
            Debug.WriteLine($"Constructor - Initial Name value: '{_name}'");
            
            if (_product.Image != null)
            {
                try
                {
                    using (var ms = new MemoryStream(_product.Image))
                    {
                        var image = new BitmapImage();
                        image.BeginInit();
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.StreamSource = ms;
                        image.EndInit();
                        ImageSource = image;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load image: {ex.Message}");
                }
            }

            // Подписываемся на событие загрузки окна
            this.Loaded += ProductDialog_Loaded;
        }

        private void ProductDialog_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"Window Loaded - Name value: '{_name}'");
            // Принудительно вызываем обновление привязки
            OnPropertyChanged(nameof(Name));
        }

        public string Name
        {
            get
            {
                Debug.WriteLine($"Name Get: '{_name}'");
                return _name;
            }
            set
            {
                Debug.WriteLine($"Name Set: Old value: '{_name}', New value: '{value}'");
                string newValue = value?.Trim() ?? "";
                if (_name != newValue)
                {
                    _name = newValue;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value?.Trim() ?? "";
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }

        public TypeWear TypeWear
        {
            get => _typeWear;
            set
            {
                if (_typeWear != value)
                {
                    _typeWear = value;
                    OnPropertyChanged(nameof(TypeWear));
                }
            }
        }

        public Array TypeWearValues => Enum.GetValues(typeof(TypeWear));

        public BitmapImage ImageSource
        {
            get => _imageSource;
            set
            {
                if (_imageSource != value)
                {
                    _imageSource = value;
                    OnPropertyChanged(nameof(ImageSource));
                }
            }
        }

        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog
                {
                    Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    var image = new BitmapImage(new Uri(openFileDialog.FileName));
                    ImageSource = image;

                    using (var ms = new MemoryStream())
                    {
                        var encoder = new JpegBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(image));
                        encoder.Save(ms);
                        _product.Image = ms.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to select image: {ex.Message}");
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Debug.WriteLine($"Save_Click - Current Name value: '{_name}'");
                Debug.WriteLine($"TextBox.Text value: '{NameTextBox.Text}'");

                // Принудительно обновляем значение из TextBox
                Name = NameTextBox.Text;
                
                // Trim values before validation
                var trimmedName = _name?.Trim() ?? "";
                
                Debug.WriteLine($"Save_Click - Trimmed Name value: '{trimmedName}'");

                if (string.IsNullOrWhiteSpace(trimmedName))
                {
                    MessageBox.Show("Please enter a name for the product.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (_price <= 0)
                {
                    MessageBox.Show("Please enter a valid price for the product.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Update product with current values
                _product.Name = trimmedName;
                _product.Description = _description?.Trim();
                _product.Price = _price;
                _product.TypeWear = _typeWear;

                Debug.WriteLine($"Save_Click - Final Product Name: '{_product.Name}'");

                // If no image was selected, try to load default image
                if (_product.Image == null || _product.Image.Length == 0)
                {
                    var defaultImagePath = @"D:\OIP.jpg";
                    if (File.Exists(defaultImagePath))
                    {
                        _product.Image = File.ReadAllBytes(defaultImagePath);
                    }
                }

                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving product: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void OnPropertyChanged(string propertyName)
        {
            Debug.WriteLine($"PropertyChanged fired for: {propertyName}");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 