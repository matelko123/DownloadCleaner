using System.Windows.Input;
using DownloadCleaner.App.ViewModels;

namespace DownloadCleaner.App.Commands;

internal class AddNewCleanDirectoryControlCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;

    private readonly MainViewModel _mainViewModel;

    public AddNewCleanDirectoryControlCommand(MainViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
    }

    public bool CanExecute(object? parameter) => !_mainViewModel.IsCleaning;

    public void Execute(object? parameter)
    {
        _mainViewModel.CleanDirectoryControls.Add(new ViewModels.Controls.CleanDirectoryControlViewModel());
    }
}