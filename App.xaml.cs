using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OOP_CourseWork.DataBase;
using OOP_CourseWork.DataBase.Pattern.UnitOfWork;
using OOP_CourseWork.View;
using OOP_CourseWork.ViewModel;
using System;
using System.Configuration;
using System.Data;
using System.Windows;
using OOP_CourseWork.DataBase.ADO;

namespace OOP_CourseWork
{
    public partial class App : Application
    {
        private IServiceProvider _provider;
        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();
            services.AddDbContext<OOP_CourseWork.DataBase.AppContext>(options =>
                options.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<AdminViewModel>();
            services.AddTransient<BonusViewModel>();
            services.AddTransient<CartViewModel>();
            services.AddTransient<FavoriteViewModel>();
            services.AddTransient<HistoryViewModel>();
            services.AddTransient<LastViewViewModel>();
            services.AddTransient<OrdersViewModel>();
            services.AddTransient<RegisterViewModel>();
            services.AddTransient<ShopItemViewModel>();
            services.AddTransient<ShopMainViewModel>();
            services.AddTransient<SignViewModel>();
            services.AddTransient<SizeHelpViewModel>();
            services.AddTransient<PaymentViewModel>();

            services.AddTransient<MainWindow>();
            services.AddTransient<ActivePlaceWindow>();
            services.AddTransient<AdminWindow>();
            services.AddTransient<BonusWindow>();
            services.AddTransient<CartWindow>();
            services.AddTransient<ContactWindow>();
            services.AddTransient<FavoriteWindow>();
            services.AddTransient<HelpWindow>();
            services.AddTransient<HistoryWindow>();
            services.AddTransient<LastViewWindow>();
            services.AddTransient<OrdersWindow>();
            services.AddTransient<RegisterWindow>();
            services.AddTransient<ShopItemWindow>();
            services.AddTransient<ShopMainWindow>();
            services.AddTransient<SignWindow>();
            services.AddTransient<SizeHelpWindow>();
            services.AddTransient<PaymentWindow>();

            _provider = services.BuildServiceProvider();

            base.OnStartup(e);

            var optionsBuilder = new DbContextOptionsBuilder<OOP_CourseWork.DataBase.AppContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=OOP_CourseWork;Trusted_Connection=True;");

            var dbContext = new OOP_CourseWork.DataBase.AppContext(optionsBuilder.Options);
            var unitOfWork = new UnitOfWork(dbContext);

            // Initialize ADO.NET database
            try
            {
                DatabaseInitializer.Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize ADO.NET database: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            var mainWindow = new MainWindow(unitOfWork);
            mainWindow.Show();
        }

        public static void ChangeTheme(string themeName)
        {
            ResourceDictionary newTheme = new ResourceDictionary();

            switch (themeName)
            {
                case "Pink":
                    newTheme.Source = new Uri("Recources/Theme/PinkTheme.xaml", UriKind.Relative);
                    break;
                case "Dark":
                    newTheme.Source = new Uri("Recources/Theme/OptimisticTheme.xaml", UriKind.Relative);
                    break;
            }


            Current.Resources.MergedDictionaries.Clear();
            Current.Resources.MergedDictionaries.Add(newTheme);
        }
    }

}
