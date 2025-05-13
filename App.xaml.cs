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

            _provider = services.BuildServiceProvider();

            base.OnStartup(e);

            // создаём UnitOfWork
            var optionsBuilder = new DbContextOptionsBuilder<OOP_CourseWork.DataBase.AppContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=OOP_CourseWork;Trusted_Connection=True;");

            var dbContext = new OOP_CourseWork.DataBase.AppContext(optionsBuilder.Options);
            var unitOfWork = new UnitOfWork(dbContext);

            // создаём MainWindow вручную
            var mainWindow = new MainWindow(unitOfWork);
            mainWindow.Show();
        }
    }

}
