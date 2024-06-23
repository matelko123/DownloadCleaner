namespace DownloadCleaner.App.Contracts.Services;

public interface ILocalSettingsService
{
    Task<T?> ReadSettingAsync<T>(string key);
    T? ReadSettings<T>(string key);

    Task SaveSettingAsync<T>(string key, T value);
    void SaveSettings<T>(string key, T value);
}
