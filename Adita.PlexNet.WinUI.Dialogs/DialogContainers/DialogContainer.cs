using Adita.PlexNet.Core.Dialogs;
using Adita.PlexNet.Core.Dialogs.Abstractions.Containers;
using Adita.PlexNet.Core.Dialogs.Abstractions.Dialogs;
using Microsoft.UI.Xaml;
using System;
using System.Threading;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Adita.PlexNet.WinUI.Dialogs.DialogContainers;

/// <summary>
/// Represents a dialog container.
/// </summary>
public sealed partial class DialogContainer : DialogContainerBase, IDialogContainer
{
    #region Private fields
    private IDialog? _contentContext;
    private object? _host;
    #endregion Private fields

    #region Public methods
    /// <inheritdoc/>
    public void SetHost<THost>(THost? host) where THost : class
    {
        if (host is not Window window)
        {
            throw new ArgumentException($"{nameof(host)} have to {nameof(Window)}");
        }

        _host = host;
        XamlRoot = window.Content.XamlRoot;
    }
    /// <inheritdoc/>
    public async Task<DialogResult> ShowDialogAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (_host == null)
        {
            throw new InvalidOperationException("Host is not set.");
        }

        await ShowAsync();

        return _contentContext != null
            ? _contentContext.DialogResult
            : throw new InvalidOperationException($"{nameof(_contentContext)} not set.");
    }
    /// <inheritdoc/>
    public void SetContent<TContent, TContentView>(TContent content, TContentView contentView)
        where TContent : class, IDialog
        where TContentView : class
    {
        ArgumentNullException.ThrowIfNull(contentView);

        _contentContext = content ?? throw new ArgumentNullException(nameof(content));
        content.RequestClosing += OnContentRequestClosing;

        if (contentView is DataTemplate dataTemplate)
        {
            Content = content;
            ContentTemplate = dataTemplate;
        }
        else
        {
            Content = contentView;
        }

        Title = _contentContext?.Title;
    }
    #endregion Public methods

    #region Event handlers
    private void OnContentRequestClosing(object? sender, DialogRequestClosingEventArgs e)
    {
        if (sender is IDialog dialog)
        {
            dialog.RequestClosing -= OnContentRequestClosing;
        }

        Hide();
    }
    #endregion Event handlers
}
