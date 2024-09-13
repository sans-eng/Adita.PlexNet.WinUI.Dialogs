using Adita.PlexNet.Core.Dialogs;
using Microsoft.UI.Xaml;

namespace Adita.PlexNet.WinUI.Dialogs
{
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
        public void SetHost(Window window)
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
}
