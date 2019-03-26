
namespace EarthQuakeTest.Services.Abstract
{
    public interface IDownloader
    {
        string DownloadRawJsonData(string url);
    }
}
