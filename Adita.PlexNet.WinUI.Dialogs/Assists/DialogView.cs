using System.Linq;
using Microsoft.UI.Xaml;

namespace Adita.PlexNet.WinUI.Dialogs;

/// <summary>
/// Represents a class that serve a collection of dialog view.
/// </summary>
public static class DialogView
{
    #region Private fields
    private static readonly DialogViewCollection _viewDescriptors = [];
    #endregion Private fields

    #region Dependency properties
    /// <summary>
    /// Identifies ViewTemplates property.
    /// </summary>
    public static readonly DependencyProperty ViewsProperty =
        DependencyProperty.RegisterAttached("Views", typeof(DialogViewCollection), typeof(DialogView), new PropertyMetadata(new DialogViewCollection(), OnViewsChanged));
    #endregion Dependency properties

    #region Dependency property getters/setters
    /// <summary>
    /// Gets a <see cref="DialogViewCollection"/> from specified <paramref name="resourceDictionary"/>.
    /// </summary>
    /// <param name="resourceDictionary">A <see cref="ResourceDictionary"/> to get the <see cref="DialogViewCollection"/>.</param>
    /// <returns>A <see cref="DialogViewCollection"/>.</returns>
    public static DialogViewCollection GetViews(ResourceDictionary resourceDictionary)
    {
        return (DialogViewCollection)resourceDictionary.GetValue(ViewsProperty);
    }
    /// <summary>
    /// Sets the specified <paramref name="dialogViews"/> to specified <paramref name="resourceDictionary"/>.
    /// </summary>
    /// <param name="resourceDictionary">A <see cref="ResourceDictionary"/> to sets the specified <paramref name="dialogViews"/>.</param>
    /// <param name="dialogViews">A <see cref="DialogViewCollection"/> to set.</param>
    public static void SetViews(ResourceDictionary resourceDictionary, DialogViewCollection dialogViews)
    {
        resourceDictionary.SetValue(ViewsProperty, dialogViews);
    }
    #endregion Dependency property getters/setters

    #region Dependency property changed event handlers
    private static void OnViewsChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
    {
        if (args.OldValue is DialogViewCollection oldViews)
        {
            _viewDescriptors.RemoveRange(oldViews);
        }

        if (args.NewValue is DialogViewCollection newViews)
        {
            _viewDescriptors.AddRange(newViews);
        }
    }
    #endregion Dependency property changed event handlers

    #region Internal methods
    internal static object? GetView<TDialog>()
    {
        return _viewDescriptors.FirstOrDefault(v => v.TargetType == typeof(TDialog)) is DialogViewDescriptor descriptor ? descriptor.View : default;
    }
    #endregion Internal methods
}
