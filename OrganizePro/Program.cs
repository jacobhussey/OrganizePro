using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using OrganizePro.UI;
using OrganizePro.Services;
using OrganizePro.Shared;

namespace OrganizePro;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        var services = new ServiceCollection();
        ConfigureServices(services);

        using var serviceProvider = services.BuildServiceProvider();
        var loginForm = serviceProvider.GetRequiredService<LoginForm>();

        Application.Run(loginForm);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var connectionString = configuration.GetConnectionString("MySqlConnection");

        services.AddDbContext<Context.Context>(options =>
            options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 41)))
        );

        services.AddTransient<CustomerService>();
        services.AddTransient<AppointmentService>();
        services.AddTransient<ReportService>();
        services.AddTransient<UserService>();

        services.AddSingleton<Store>();

        services.AddTransient<LoginForm>();
        services.AddTransient<MainDashboard>();
        services.AddTransient<CustomerForm>();
        services.AddTransient<AppointmentForm>();
    }
}
