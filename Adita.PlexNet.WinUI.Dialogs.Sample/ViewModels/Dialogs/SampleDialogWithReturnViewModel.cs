using System.Windows.Input;
using Adita.PlexNet.Core.Dialogs.Abstractions.Dialogs;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Adita.PlexNet.WinUI.Dialogs.Sample.ViewModels.Dialogs;
public partial class SampleDialogWithReturnViewModel : Dialog<string>
{
    [ObservableProperty]
    private string _value = string.Empty;
    public SampleDialogWithReturnViewModel()
    {
        Title = "Sample Dialog With Return";
    }

    public ICommand SubmitCommand => new RelayCommand(() => Submit(Value));
    public ICommand CancelCommand => new RelayCommand(Cancel);
}
