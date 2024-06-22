using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace DownloadCleaner.App.ViewModels.Controls;
public partial class CleanDirectoryControlViewModel : ObservableRecipient
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(DestinationFolderName))]
    private string? _destinationDirectory;
    
    public string? DestinationFolderName => Path.GetFileName(DestinationDirectory);

    [ObservableProperty]
    private HashSet<string> _extensions = new();

    public CleanDirectoryControlViewModel(string destinationDirectory, HashSet<string> extensions)
        : this()
    {
        _destinationDirectory = destinationDirectory;
        _extensions = extensions;
    }

    public CleanDirectoryControlViewModel()
    {
    }

    [RelayCommand]
    private async Task PickupNewDestinationAsync()
    {
        // Create a folder picker
        FolderPicker openPicker = new FolderPicker();
        // See the sample code below for how to make the window accessible from the App class.
        var window = App.MainWindow;

        // Retrieve the window handle (HWND) of the current WinUI 3 window.
        var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);

        // Initialize the folder picker with the window handle (HWND).
        WinRT.Interop.InitializeWithWindow.Initialize(openPicker, hWnd);

        // Set options for your folder picker
        openPicker.SuggestedStartLocation = PickerLocationId.Downloads;
        openPicker.FileTypeFilter.Add("*");

        // Open the picker for the user to pick a folder
        StorageFolder folder = await openPicker.PickSingleFolderAsync();
        DestinationDirectory = folder?.Path ?? string.Empty;
    }
}
