namespace DownloadCleaner.App.Contracts.Services;

public interface IActivationService
{
    Task ActivateAsync(object activationArgs);
}
