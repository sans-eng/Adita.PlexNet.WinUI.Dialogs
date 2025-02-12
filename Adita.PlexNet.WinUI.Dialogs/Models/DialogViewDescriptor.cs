using System;
using Microsoft.UI.Xaml;

namespace Adita.PlexNet.WinUI.Dialogs;

/// <summary>
/// Represents a dialog view.
/// </summary>
public class DialogViewDescriptor : DependencyObject
{
    #region Dependency properties
    /// <summary>
    /// Identifies <see cref="TargetType"/> property.
    /// </summary>
    public static readonly DependencyProperty TargetTypeProperty =
        DependencyProperty.Register(nameof(TargetType), typeof(Type), typeof(DialogViewDescriptor), new PropertyMetadata(default));
    /// <summary>
    /// Identifies <see cref="View"/> property.
    /// </summary>
    public static readonly DependencyProperty ViewProperty =
        DependencyProperty.Register(nameof(View), typeof(object), typeof(DialogViewDescriptor), new PropertyMetadata(default));
    #endregion Dependency properties

    #region Public properties
    /// <summary>
    /// Gets or sets the <see cref="Type"/> for current <see cref="DialogViewDescriptor"/>.
    /// </summary>
    public Type TargetType
    {
        get => (Type)GetValue(TargetTypeProperty);
        set => SetValue(TargetTypeProperty, value);
    }
    /// <summary>
    /// Gets or sets the <see cref="object"/> of the view for current <see cref="DialogViewDescriptor"/>.
    /// </summary>
    public object View
    {
        get => (DataTemplate)GetValue(ViewProperty);
        set => SetValue(ViewProperty, value);
    }
    #endregion Public properties
}