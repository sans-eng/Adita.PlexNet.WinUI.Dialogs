using Adita.PlexNet.Core.Dialogs.Abstractions.Providers;

namespace Adita.PlexNet.WinUI.Dialogs.Providers;

/// <summary>
/// Represents a dialog view provider
/// </summary>
public class DialogViewProvider : IDialogViewProvider
{
    #region Public methods
    /// <inheritdoc/>
    public object? GetView<TDialog>()
    {
        return DialogView.GetView<TDialog>();
    }
    #endregion Public methods
}
