using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adita.PlexNet.WinUI.Dialogs
{
    /// <summary>
    /// Represents a class that serve a collection of dialog view.
    /// </summary>
    public static class DialogView
    {
        #region Dependency properties
        /// <summary>
        /// Identifies ViewTemplates property.
        /// </summary>
        public static readonly DependencyProperty ViewTemplatesProperty =
            DependencyProperty.RegisterAttached("ViewTemplates", typeof(DialogViewTemplateCollection), typeof(DialogView), new PropertyMetadata(new DialogViewTemplateCollection()));
        #endregion Dependency properties

        #region Dependency property getters/setters
        /// <summary>
        /// Gets a <see cref="DialogViewTemplateCollection"/> from specified <paramref name="resourceDictionary"/>.
        /// </summary>
        /// <param name="resourceDictionary">A <see cref="ResourceDictionary"/> to get the <see cref="DialogViewTemplateCollection"/>.</param>
        /// <returns>A <see cref="DialogViewTemplateCollection"/>.</returns>
        public static DialogViewTemplateCollection GetViewTemplates(DependencyObject resourceDictionary)
        {
            return (DialogViewTemplateCollection)resourceDictionary.GetValue(ViewTemplatesProperty);
        }
        /// <summary>
        /// Sets the specified <paramref name="dialogViewTemplates"/> to specified <paramref name="resourceDictionary"/>.
        /// </summary>
        /// <param name="resourceDictionary">A <see cref="ResourceDictionary"/> to sets the specified <paramref name="dialogViewTemplates"/>.</param>
        /// <param name="dialogViewTemplates">A <see cref="DialogViewTemplateCollection"/> to set.</param>
        public static void SetViewTemplates(DependencyObject resourceDictionary, DialogViewTemplateCollection dialogViewTemplates)
        {
            resourceDictionary.SetValue(ViewTemplatesProperty, dialogViewTemplates);
        }
        #endregion Dependency property getters/setters
    }
}
