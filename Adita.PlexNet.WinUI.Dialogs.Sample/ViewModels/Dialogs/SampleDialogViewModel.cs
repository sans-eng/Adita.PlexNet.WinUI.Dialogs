using System.Windows.Input;
using Adita.PlexNet.Core.Dialogs.Abstractions.Dialogs;
using CommunityToolkit.Mvvm.Input;

namespace Adita.PlexNet.WinUI.Dialogs.Sample.ViewModels.Dialogs;
public class SampleDialogViewModel : Dialog
{
    public SampleDialogViewModel()
    {
        Title = "Sample Dialog";
    }
    #region Public properties
    public ICommand OkCommand => new RelayCommand(OK);
    public ICommand CancelCommand => new RelayCommand(Cancel);
    #endregion Public properties
}
