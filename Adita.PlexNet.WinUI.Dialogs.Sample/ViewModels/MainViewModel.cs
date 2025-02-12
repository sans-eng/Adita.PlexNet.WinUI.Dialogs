using System.Threading.Tasks;
using Adita.PlexNet.Core.Dialogs.Abstractions.Managers;
using Adita.PlexNet.WinUI.Dialogs.Sample.ViewModels.Dialogs;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Adita.PlexNet.WinUI.Dialogs.Sample.ViewModels;
public partial class MainViewModel : ObservableRecipient
{
    private readonly IDialogManager<SampleDialogViewModel> _dialogManager;
    private readonly IDialogManager<SampleDialogWithReturnViewModel, string> _dialogWithReturnManager;
    private readonly IDialogManager<SampleDialogWithReturnAndParamViewModel, string, string> _dialogWithReturnAndParamManager;

    [ObservableProperty]
    private string _dialogWithReturnResult = string.Empty;
    [ObservableProperty]
    private string __parameter = string.Empty;
    [ObservableProperty]
    private string _dialogWithReturnAndParamResult = string.Empty;

    public MainViewModel(IDialogManager<SampleDialogViewModel> dialogManager, IDialogManager<SampleDialogWithReturnViewModel, string> dialogWithReturnManager,
        IDialogManager<SampleDialogWithReturnAndParamViewModel, string, string> dialogWithReturnAndParamManager)
    {
        _dialogManager = dialogManager;
        _dialogWithReturnManager = dialogWithReturnManager;
        _dialogWithReturnAndParamManager = dialogWithReturnAndParamManager;
    }

    [RelayCommand]
    private async Task ShowDialogAsync()
    {
        await _dialogManager.ShowDialogAsync();
    }
    [RelayCommand]
    private async Task ShowDialogWithReturnAsync()
    {
        var result = await _dialogWithReturnManager.ShowDialogAsync();
        if (result.Action == Core.Dialogs.DialogActionResult.Submit && result.Value != null)
        {
            DialogWithReturnResult = result.Value;
        }
    }
    [RelayCommand]
    private async Task ShowDialogWithReturnAndParamAsync()
    {
        var result = await _dialogWithReturnAndParamManager.ShowDialogAsync(Parameter);
        if (result.Action == Core.Dialogs.DialogActionResult.Submit && result.Value != null)
        {
            DialogWithReturnAndParamResult = result.Value;
        }
    }
}
