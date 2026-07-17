using Client.Models;
using Client.Services;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Forms;
using ViewModels;

namespace Presentation
{
    internal static class Program
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();

            var mainForm = ServiceProvider.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7068/")
            });

            services.AddScoped<ApiService<HallModel>>();
            services.AddTransient<HallsViewModel>();

            services.AddScoped<ApiService<MajorModel>>();
            services.AddTransient<MajorsViewModel>();

            services.AddScoped<HallsViewModel>();
            services.AddTransient<HallsManagementForm>();

            services.AddScoped<MajorsViewModel>();
            services.AddTransient<MajorsManagementForm>();

            services.AddScoped<HallsManagementForm>();
            services.AddScoped<MajorsManagementForm>();
            services.AddTransient<MainForm>();
        }
    }
}
