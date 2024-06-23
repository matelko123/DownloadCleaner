using DownloadCleaner.App.Models;

namespace DownloadCleaner.App.Contracts.Stores;
public interface ICleanDirectoriesStore : IDisposable
{
    CleanDirectoriesModel LoadSettings();
    void SaveSettings(CleanDirectoriesModel cleanDirectories);
}
