using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PracticingUI.ViewModels;
using PracticingUI.Views;
using Database;
using System;
using Microsoft.EntityFrameworkCore;

namespace PracticingUI
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
        public static IServiceProvider Services { get; private set; } = null;
        public override void OnFrameworkInitializationCompleted()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Local.json")
                .Build();

            var services = new ServiceCollection();

            services.AddDbContext<AppDbContext>(options 
                => options.UseNpgsql(config.GetConnectionString("Default")));

            services.AddSingleton<MainWindowViewModel>();

            services.AddTransient<RegistrationViewModel>();

            Services = services.BuildServiceProvider();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = Services.GetRequiredService<MainWindowViewModel>()
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}