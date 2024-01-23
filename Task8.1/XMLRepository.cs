using System.Xml.Serialization;

namespace AbstractLibraryTask
{
    public class XMLRepository<T> : IRepository<T>
    {
        public void Save(string filePath, T data)
        {
            var serializer = new XmlSerializer(typeof(T), new Type[] { typeof(PaperBook), typeof(EBook) });
            using (var streamWriter = new StreamWriter(filePath))
            {
                serializer.Serialize(streamWriter, data);
            }
        }

        public T Load(string filePath)
        {
            var serializer = new XmlSerializer(typeof(T), new Type[] { typeof(PaperBook), typeof(EBook) });
            using (var streamReader = new StreamReader(filePath))
            {
                return (T)serializer.Deserialize(streamReader);
            }
        }
    }
}
