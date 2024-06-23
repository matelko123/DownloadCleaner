using CommunityToolkit.Mvvm.ComponentModel;

namespace DownloadCleaner.App.ViewModels;
public abstract class AppViewModel : ObservableObject, IDisposable
{
    public virtual void Dispose()
    {
    }
}
