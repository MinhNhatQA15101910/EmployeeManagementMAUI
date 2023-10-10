using UserManagement.MAUI.Services;
using UserManagement.MAUI.ViewModels;
using UserManagement.MAUI.Views;

namespace UserManagement.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            // Services
            builder.Services.AddSingleton<IEmployeeService, EmployeeService>();

            // Views
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<CurrentEmployeeInfoPage>();
            builder.Services.AddTransient<EmployeeListPage>();
            builder.Services.AddTransient<AddUpdateEmployeePage>();

            // ViewModels
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddTransient<CurrentEmployeeInfoViewModel>();
            builder.Services.AddTransient<EmployeeListViewModel>();
            builder.Services.AddTransient<AddUpdateEmployeeViewModel>();

            return builder.Build();
        }
    }
}