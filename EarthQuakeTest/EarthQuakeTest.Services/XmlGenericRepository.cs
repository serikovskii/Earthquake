using EarthQuakeTest.Services.Abstract;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace EarthQuakeTest.Services
{
    public class XmlGenericRepository<T> : IRepository<T>
    {
        private readonly ILogger logger;

        public XmlGenericRepository(ILogger logger)
        {
            this.logger = logger;
        }

        public void Add(T entity)
        {
            logger.LogMessage($"Запись {entity.ToString()} в файл");
            var data = GetAll();
            data.Add(entity);
            var serializer = new XmlSerializer(typeof(List<T>));
            using (var stream = File.Open("erathquakes.xm", FileMode.OpenOrCreate))
            {
                serializer.Serialize(stream, data);
            }
        }

        public void Delete(T entity)
        {
            logger.LogMessage($"Удаление {entity.ToString()} из файл");
            var data = GetAll();
            data.Remove(entity);
            var serializer = new XmlSerializer(typeof(List<T>));
            using (var stream = File.Open("erathquakes.xm", FileMode.OpenOrCreate))
            {
                serializer.Serialize(stream, data);
            }
        }

        public List<T> GetAll()
        {
            var type = typeof(List<T>);
            logger.LogMessage($"Получение списка {type.Name} из файла");
            var serializer = new XmlSerializer(type);
            using (var stream = File.Open("erathquakes.xm", FileMode.OpenOrCreate))
            {
                if (stream.Length == 0) return new List<T>();
                return serializer.Deserialize(stream) as List<T>;
            }
        }
    }
}
