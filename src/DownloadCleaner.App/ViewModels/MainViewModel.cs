using System.Collections.ObjectModel;
using System.Windows.Input;
using DownloadCleaner.App.Commands;
using DownloadCleaner.App.Contracts.Stores;
using DownloadCleaner.App.Models;
using DownloadCleaner.App.ViewModels.Controls;

namespace DownloadCleaner.App.ViewModels;

public partial class MainViewModel : AppViewModel
{
    public ObservableCollection<CleanDirectoryControlViewModel> CleanDirectoryControls = new();

    public readonly ICommand AddNewCleanDirectoryControlCommand;

    public bool IsCleaning = false;

    private readonly ICleanDirectoriesStore _cleanDirectoriesStore;
    public MainViewModel(ICleanDirectoriesStore cleanDirectoriesStore)
    {
        AddNewCleanDirectoryControlCommand = new AddNewCleanDirectoryControlCommand(this);
        _cleanDirectoriesStore = cleanDirectoriesStore;
        LoadSettings();
    }

    private void LoadSettings()
    {
        var cleanDirectories = _cleanDirectoriesStore
            .LoadSettings()
            .CleanDirectories
            .Select(x => new CleanDirectoryControlViewModel(x))
            .ToList();

        CleanDirectoryControls = new ObservableCollection<CleanDirectoryControlViewModel>(cleanDirectories);
    }

    public override void Dispose()
    {
        var cleanDirectoryModels = CleanDirectoryControls
            .Select(x => new CleanDirectoryModel(x.DestinationDirectory, x.Extensions)).ToList();
        var cleanDirectories = new CleanDirectoriesModel(cleanDirectoryModels);
        _cleanDirectoriesStore.SaveSettings(cleanDirectories);
    }
}