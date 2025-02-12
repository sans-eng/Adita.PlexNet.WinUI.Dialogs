using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Adita.PlexNet.Core.Dialogs.Abstractions.Providers;
using Adita.PlexNet.WinUI.Dialogs.Extensions;
using Adita.PlexNet.WinUI.Dialogs.Providers;
using Adita.PlexNet.WinUI.Dialogs.Sample.ViewModels;
using Adita.PlexNet.WinUI.Dialogs.Sample.ViewModels.Dialogs;
using Adita.PlexNet.WinUI.Dialogs.Sample.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Adita.PlexNet.WinUI.Dialogs.Sample;
/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : Application
{
    private Window? m_window;

    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        ServiceProvider = ConfigureServices();
        this.InitializeComponent();
    }


    public IServiceProvider ServiceProvider
    {
        get;
        internal set;
    }
    public static new App Current => (App)Application.Current;

    private IServiceProvider ConfigureServices()
    {
        return new ServiceCollection()
            .AddDialogEnvironment()
                .RegisterDialog<SampleDialogViewModel>()
                .RegisterDialog<SampleDialogWithReturnViewModel>()
                .RegisterDialog<SampleDialogWithReturnAndParamViewModel>()
                .Build()
            .AddTransient<MainViewModel>()
            .AddTransient<MainPage>()
            .BuildServiceProvider();
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
        m_window = new MainWindow();
        var hostProvider = ServiceProvider.GetRequiredService<IDialogHostProvider>();
        if(hostProvider is DialogHostProvider provider)
        {
            provider.SetDefaultHost(m_window);
        }
        m_window.Activate();
    }
}
