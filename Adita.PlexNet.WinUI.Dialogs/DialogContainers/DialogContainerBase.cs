using Microsoft.UI.Xaml.Controls;

namespace Adita.PlexNet.WinUI.Dialogs.DialogContainers;

/// <summary>
/// Represents a base class for dialog container.
/// </summary>
public abstract class DialogContainerBase : ContentDialog
{

    #region Constructors
    /// <summary>
    /// Initialize a new instance of <see cref="DialogContainer"/>.
    /// </summary>
    protected DialogContainerBase()
    {
        this.DefaultStyleKey = typeof(DialogContainerBase);

        IsPrimaryButtonEnabled = false;
        IsSecondaryButtonEnabled = false;
    }
    #endregion Constructors
}
