using Client.Services;
using Core.Interfaces.ExternalServices;
using Infrastructure.ExternalServices.Validation;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Forms;
using Presentation.Forms.ManagementForms;
using ViewModels.Views;

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
            services.AddHttpClient<ApiService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7068/");

                string token = "TOKEN";
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            });


            services.AddScoped<IValidationService, ValidationService>();

            // ======================
            // Api Services (Scoped)
            // ======================
            services.AddTransient<HallApiService>();
            services.AddTransient<AdministratorApiService>();
            services.AddTransient<CourseOfferingApiService>();
            services.AddTransient<CourseSessionApiService>();
            services.AddTransient<AcademicTermApiService>();
            services.AddTransient<CourseApiService>();
            services.AddTransient<CoursePrerequisiteApiService>();
            services.AddTransient<LectureApiService>();
            services.AddTransient<MajorApiService>();
            services.AddTransient<PeriodApiService>();
            services.AddTransient<PersonApiService>();
            services.AddTransient<TimeSlotApiService>();
            services.AddTransient<StudentApiService>();
            services.AddTransient<AccountApiService>();

            // ======================
            // View Models (Transient)
            // ======================
            services.AddTransient<HallsViewModel>();
            services.AddTransient<AdministratorsViewModel>();
            services.AddTransient<CourseOfferingsViewModel>();
            services.AddTransient<CourseSessionsViewModel>();
            services.AddTransient<AcademicTermsViewModel>();
            services.AddTransient<CoursesViewModel>();
            services.AddTransient<CoursePrerequisitesViewModel>();
            services.AddTransient<LecturesViewModel>();
            services.AddTransient<MajorsViewModel>();
            services.AddTransient<PeriodsViewModel>();
            services.AddTransient<PersonsViewModel>();
            services.AddTransient<TimeSlotsViewModel>();
            services.AddTransient<StudentsViewModel>();

            // ======================
            // Forms
            // ======================
            services.AddTransient<HallsManagementForm>();
            services.AddTransient<AdministratorsManagementForm>();
            services.AddTransient<CourseOfferingsManagementForm>();
            services.AddTransient<CourseSessionsManagementForm>();
            services.AddTransient<AcademicTermsManagementForm>();
            services.AddTransient<CoursesManagementForm>();
            services.AddTransient<CoursePrerequisitesManagementForm>();
            services.AddTransient<LecturesManagementForm>();
            services.AddTransient<MajorsManagementForm>();
            services.AddTransient<PeriodsManagementForm>();
            services.AddTransient<TimeSlotsManagementForm>();
            services.AddTransient<StudentsManagementForm>();


            services.AddTransient<MainForm>();
        }
    }
}
