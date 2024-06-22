using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using DownloadCleaner.App.Commands;
using DownloadCleaner.App.ViewModels.Controls;

namespace DownloadCleaner.App.ViewModels;

public partial class MainViewModel : ObservableRecipient
{
    public ObservableCollection<CleanDirectoryControlViewModel> CleanDirectoryControls;

    public readonly ICommand AddNewCleanDirectoryControlCommand;

    public bool IsCleaning = false;

    public MainViewModel()
    {
        CleanDirectoryControls = new ObservableCollection<CleanDirectoryControlViewModel>();
        AddNewCleanDirectoryControlCommand = new AddNewCleanDirectoryControlCommand(this);
    }
}