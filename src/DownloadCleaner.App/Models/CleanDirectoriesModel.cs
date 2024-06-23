using DownloadCleaner.App.Stores;

namespace DownloadCleaner.App.Models;
public class CleanDirectoriesModel
{
    public IEnumerable<CleanDirectoryModel> CleanDirectories { get; set; }

    public CleanDirectoriesModel(IEnumerable<CleanDirectoryModel> cleanDirectoryModels)
    {
        CleanDirectories = cleanDirectoryModels;
    }

    public static readonly CleanDirectoriesModel DefaultSettings = new (
        new List<CleanDirectoryModel>()
        {
            new (
                Path.Combine(CleanDirectoriesStore.SourceFolderPath, "Photos"),
                new List<string> () {".png", ".jpg", ".jpeg", ".gif", ".ai", ".bmp", ".ico", ".ps", ".psd", ".svg", ".tif", ".tiff" }
            ),
            new(
                Path.Combine(CleanDirectoriesStore.SourceFolderPath, "Documents"),
                new List<string> () {".txt", ".tex", ".doc", ".docx", ".pdf", ".xls ", ".xlsm", ".xlsx", ".html", ".htm", ".xhtml", ".key", ".odp", ".ods", ".odt", ".pps", ".ppt", ".pptx", ".csv", ".json" }
            ),
            new(
                Path.Combine(CleanDirectoriesStore.SourceFolderPath, "Music"),
                new List<string> () {".mp3", ".aif", ".cda", ".mid", ".midi", ".mpa", ".ogg", ".wav", ".wma", "wpl" }
            ),
            new(
                Path.Combine(CleanDirectoriesStore.SourceFolderPath, "Videos"),
                new List<string> () {".mp4", ".mkv", ".avi", ".mpg", ".mpeg", ".rm", ".wmv" }
            ),
            new(
                Path.Combine(CleanDirectoriesStore.SourceFolderPath, "Archives"),
                new List<string> () {".arj", ".deb", ".pkg", ".rar", ".rpm", ".tar", ".gz", ".z", ".zip" }
            ),
            new(
                Path.Combine(CleanDirectoriesStore.SourceFolderPath, "Installers"),
                new List<string> () {".exe", ".msi", ".apk", ".bat", ".bin", ".cgi", ".pl", ".com", ".gadget", ".jar", ".msi", ".py", ".wsf" }
            )
        }
    );
}
