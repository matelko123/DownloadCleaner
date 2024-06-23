using DownloadCleaner.App.Contracts.Services;
using DownloadCleaner.App.Contracts.Stores;
using DownloadCleaner.App.Models;

namespace DownloadCleaner.App.Stores;

internal class CleanDirectoriesStore : ICleanDirectoriesStore, IDisposable
{
    private const string STORAGE_KEY = "CleanDirectoriesModel";
    public static readonly string SourceFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";

    private readonly ILocalSettingsService _localSettingsService;

    public CleanDirectoriesStore(
        ILocalSettingsService localSettingsService)
    {
        _localSettingsService = localSettingsService;

        CleanDirectoriesModel = _localSettingsService
            .ReadSettings<CleanDirectoriesModel>(STORAGE_KEY)
                ?? CleanDirectoriesModel.DefaultSettings;
    }

    private CleanDirectoriesModel CleanDirectoriesModel { get; set; }

    public void SaveSettings(CleanDirectoriesModel cleanDirectories) => CleanDirectoriesModel = cleanDirectories;
    public CleanDirectoriesModel LoadSettings() => CleanDirectoriesModel;


    private void SaveSettings() =>_localSettingsService.SaveSettings(STORAGE_KEY, CleanDirectoriesModel);
    public void Dispose() => SaveSettings();
}
