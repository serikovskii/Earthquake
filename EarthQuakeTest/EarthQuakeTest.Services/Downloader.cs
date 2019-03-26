using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EarthQuakeTest.Services.Abstract;

namespace EarthQuakeTest.Services
{
    public class Downloader : IDownloader
    {
        private readonly ILogger logger;

        public Downloader(ILogger logger)
        {
            this.logger = logger;
        }
        public string DownloadRawJsonData(string url)
        {
            using (var client = new WebClient())
            {
                try
                {
                    logger.LogMessage($"Запрос {url}");
                    return client.DownloadString(url);
                }
                catch(WebException exception)
                {
                    logger.LogError(exception);
                    return "";
                }
                
            }
        }
    }
}
