using System.Xml.Serialization;

namespace BookCatalogTask
{
    public class XMLRepository<T> : IRepository<T>
    {
        public void Save(string filePath, T data)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var streamWriter = new StreamWriter(filePath))
            {
                serializer.Serialize(streamWriter, data);
            }
        }

        public T Load(string filePath)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var streamReader = new StreamReader(filePath))
            {
                return (T)serializer.Deserialize(streamReader);
            }
        }
    }
}