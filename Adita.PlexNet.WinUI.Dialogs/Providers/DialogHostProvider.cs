using Adita.PlexNet.Core.Dialogs.Abstractions.Providers;
using Microsoft.UI.Xaml;

namespace Adita.PlexNet.WinUI.Dialogs.Providers;

/// <summary>
/// Represents a dialog host provider.
/// </summary>
public class DialogHostProvider : IDialogHostProvider
{
    #region Private fields
    private Window? MainWindow;
    #endregion Private fields

    #region Public methods
    /// <summary>
    /// Sets the host of the dialog using specified <paramref name="window"/>.
    /// </summary>
    /// <param name="window">The <see cref="Window"/> for the dialog host.</param>
    /// <remarks>This have to be called when MainWindow is created before it activated.</remarks>
    public void SetDefaultHost(Window window)
    {
        MainWindow = window;
    }
    /// <inheritdoc/>
    public object? GetHost<TDialog>()
    {
        return MainWindow;
    }
    #endregion Public methods
}
