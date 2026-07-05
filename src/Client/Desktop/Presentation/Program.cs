using Client.Services;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Forms;
using ViewModels;
using ViewModels.Interface;

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

            var mainForm = ServiceProvider.GetRequiredService<HallsManagement>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7068/")
            });

            services.AddScoped<HallApiService>();

            services.AddTransient<IHallsViewModel, HallsViewModel>();
            services.AddTransient<HallsManagement>();
        }
    }
}
