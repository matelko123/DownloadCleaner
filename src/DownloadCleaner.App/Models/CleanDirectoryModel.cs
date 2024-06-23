namespace DownloadCleaner.App.Models;

public class CleanDirectoryModel
{
    public string DestinationFolderPath{ get; set; } = string.Empty;
    public IEnumerable<string> Extensions { get; set; } = new List<string>();

    public CleanDirectoryModel(string destinationFolderPath, IEnumerable<string> extensions)
    {
        DestinationFolderPath = destinationFolderPath;
        Extensions = extensions;
    }
}
