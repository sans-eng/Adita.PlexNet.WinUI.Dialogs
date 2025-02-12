using Adita.PlexNet.Core.Dialogs;
using Adita.PlexNet.Core.Dialogs.Abstractions.Containers;
using Adita.PlexNet.Core.Dialogs.Abstractions.Dialogs;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Adita.PlexNet.WinUI.Dialogs.DialogContainers;

/// <summary>
/// Represents a dialog container that has paramater.
/// </summary>
/// <typeparam name="TParam">The type used for the parameter.</typeparam>
public partial class ParamOnlyDialogContainer<TParam> : DialogContainerBase, IParamOnlyDialogContainer<TParam>
{
    #region Private fields
    private IParamOnlyDialog<TParam>? _contentContext;
    private TParam? _parameter;
    private object? _host;
    #endregion Private fields

    #region Constructors
    /// <summary>
    /// Initialize a new instance of <see cref="DialogContainer{TReturn, TParam}"/>.
    /// </summary>
    public ParamOnlyDialogContainer()
    {
        Opened += OnOpened;
    }
    #endregion Constructors

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
    public async Task<DialogResult> ShowDialogAsync(TParam param, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (_host == null)
        {
            throw new InvalidOperationException("Host is not set.");
        }

        _parameter = param;

        await ShowAsync();

        return _contentContext != null
            ? _contentContext.DialogResult
            : throw new InvalidOperationException($"{nameof(_contentContext)} not set.");
    }
    /// <inheritdoc/>
    public void SetContent<TContent, TContentView>(TContent content, TContentView contentView)
         where TContent : class, IParamOnlyDialog<TParam>
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
        if (sender is IParamOnlyDialog<TParam> dialog)
        {
            dialog.RequestClosing -= OnContentRequestClosing;
        }
        Hide();
    }
    private async void OnOpened(ContentDialog sender, ContentDialogOpenedEventArgs args)
    {
        if (_parameter != null && _contentContext != null)
        {
            await _contentContext.InitializeAsync(_parameter);
        }
    }
    #endregion Event handlers
}
