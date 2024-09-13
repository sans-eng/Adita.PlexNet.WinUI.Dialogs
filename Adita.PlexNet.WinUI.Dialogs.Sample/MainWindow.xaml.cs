using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Adita.PlexNet.WinUI.Dialogs.Sample
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

           
        }

        private async void myButton_Click(object sender, RoutedEventArgs e)
        {
            var res = DialogView.GetViewTemplates(Application.Current.Resources);
            var template = Application.Current.Resources["Test"] as DataTemplate;

            if (res.Count > 0)
            {
                ContentDialog contentDialog = new ContentDialog()
                {
                    XamlRoot = Content.XamlRoot,
                    PrimaryButtonText = "Test",
                    ContentTemplate = res[0].ViewTemplate,
                    Content = new ModelTest()
                };

                await contentDialog.ShowAsync();
            }
        }
    }
}
