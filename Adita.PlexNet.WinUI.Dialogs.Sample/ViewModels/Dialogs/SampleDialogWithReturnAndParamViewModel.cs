using System.Threading.Tasks;
using System.Windows.Input;
using Adita.PlexNet.Core.Dialogs.Abstractions.Dialogs;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Adita.PlexNet.WinUI.Dialogs.Sample.ViewModels.Dialogs;
public partial class SampleDialogWithReturnAndParamViewModel : Dialog<string, string>
{
    [ObservableProperty]
    private string _value = string.Empty;

    public SampleDialogWithReturnAndParamViewModel()
    {
        Title = "Sample Dialog With Return and Param";
    }
    public override Task InitializeAsync(string parameter)
    {
        Value = parameter;
        return Task.CompletedTask;
    }

    public ICommand SubmitCommand => new RelayCommand(() => Submit(Value));
    public ICommand CancelCommand => new RelayCommand(Cancel);
}
