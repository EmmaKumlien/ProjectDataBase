using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;


namespace Presentation.WpfApp
{
    public partial class App : Application
    {
        private IHost builder;

        public App()
        {
            builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Education\SQL\ProjectDataBase\Infrastructure\Data\DataBase.mdf;Integrated Security=True;Connect Timeout=30"));


                services.AddScoped<BillingAdressRepository>();
                services.AddScoped<CategoryRepository>();
                services.AddScoped<ContactInformationRepository>();
                services.AddScoped<CustomerRepository>();
                services.AddScoped<ManufacturerRepository>();
                services.AddScoped<OrderRowRepository>();
                services.AddScoped<OrderServiceRepository>();
                services.AddScoped<ProductRepository>();

                services.AddScoped<ProductService>();


                services.AddSingleton<MainWindow>();

            }).Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            builder.Start();
            var mainWindow = builder.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}
