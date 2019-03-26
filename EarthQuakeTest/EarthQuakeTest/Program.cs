using EarthQuakeTest.Services;
using EarthQuakeTest.Services.Abstract;
using ErathQuakeTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthQuakeTest.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new FileLogger();
            IDownloader downloader = new Downloader(logger);
            IRepository<FeatureCollection> repository = new XmlGenericRepository<FeatureCollection>(logger);

            string json = downloader.DownloadRawJsonData("https://earthquake.usgs.gov/fdsnws/event/1/query?format=geojson&limit=50");
            var data = JsonConvert.DeserializeObject<FeatureCollection>(json);
            repository.Add(data);
        }
    }
}
