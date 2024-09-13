using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

namespace Adita.PlexNet.WinUI.Dialogs
{
    /// <summary>
    /// Represents a dialog view.
    /// </summary>
    public class DialogViewTemplate : DependencyObject
    {
        #region Dependency properties
        /// <summary>
        /// Identifies <see cref="TargetType"/> property.
        /// </summary>
        public static readonly DependencyProperty TargetTypeProperty =
            DependencyProperty.Register(nameof(TargetType), typeof(Type), typeof(DialogViewTemplate), new PropertyMetadata(default));
        /// <summary>
        /// Identifies <see cref="ViewTemplate"/> property.
        /// </summary>
        public static readonly DependencyProperty ViewTemplateProperty =
            DependencyProperty.Register(nameof(ViewTemplate), typeof(DataTemplate), typeof(DialogViewTemplate), new PropertyMetadata(default));
        #endregion Dependency properties

        #region Public properties
        /// <summary>
        /// Gets or sets the <see cref="Type"/> for current <see cref="DialogViewTemplate"/>.
        /// </summary>
        public Type TargetType
        {
            get => (Type)GetValue(TargetTypeProperty);
            set => SetValue(TargetTypeProperty, value);
        }
        /// <summary>
        /// Gets or sets the <see cref="DataTemplate"/> for current <see cref="DialogViewTemplate"/>.
        /// </summary>
        public DataTemplate ViewTemplate
        {
            get => (DataTemplate)GetValue(ViewTemplateProperty);
            set => SetValue(ViewTemplateProperty, value);
        }
        #endregion Public properties
    }
}