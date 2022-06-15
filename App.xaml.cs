using DeszkaImageViewer.Core.Utils;
using DeszkaImageViewer.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace DeszkaImageViewer;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static string[] Args = new string[0];
    public static bool HasArgs;

    private readonly ServiceProvider _serviceProvider;

    public ServiceProvider ServiceProvider
    {
        get
        {
            return ServiceProvider;
        }
    }

    public App()
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    private void ConfigureServices(ServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        services.AddSingleton<MainWindowUtils>();
        services.AddSingleton<ExportWindow>();
        services.AddSingleton<ExportWindowUtils>();
        services.AddSingleton<DialogUtils>();
        services.AddSingleton<ImageUtils>();
    }

    private void Application_Startup(object sender, StartupEventArgs e)
    {
        Args = e.Args;
        HasArgs = e.Args.Length > 0;

        var mainWindow = _serviceProvider.GetService<MainWindow>();

        if (mainWindow is null)
            return;

        mainWindow.Show();
    }
}
