using Adita.PlexNet.Core.Dialogs.Abstractions.Builders;
using Adita.PlexNet.Core.Dialogs.Builders;
using Adita.PlexNet.WinUI.Dialogs.DialogContainers;
using Adita.PlexNet.WinUI.Dialogs.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Adita.PlexNet.WinUI.Dialogs.Extensions;

/// <summary>
/// Represents a <see cref="IServiceCollection"/> extensions to register dialog environment.
/// </summary>
public static class ServiceCollectionExtensions
{
    #region Public methods
    /// <summary>
    /// Add dialog environment to specified <paramref name="services"/> and return a <see cref="IDialogBuilder"/>. 
    /// </summary>
    /// <param name="services">A <see cref="IServiceCollection"/> to register the environment.</param>
    /// <returns>a <see cref="IDialogBuilder"/>.</returns>
    public static IDialogBuilder AddDialogEnvironment(this IServiceCollection services)
    {
        return new DialogBuilder(services)
            .AddDialogHostProvider<DialogHostProvider>()
            .AddDialogViewProvider<DialogViewProvider>()
            .ConfigureDialogOptions(options =>
            {
                options.TargetPlatformStandardContainerType = typeof(DialogContainer);
                options.TargetPlatformWithReturnContainerType = typeof(DialogContainer<>);
                options.TargetPlatformWithReturnAndParamContainerType = typeof(DialogContainer<,>);
                options.TargetPlatformOnlyParamContainerType = typeof(ParamOnlyDialogContainer<>);
            });
    }
    #endregion Public methods
}
