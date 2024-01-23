using System.Xml.Serialization;

namespace AbstractLibraryTask
{
    public class PaperBook : Book
    {
        [XmlIgnore]
        public List<string> ISBNs { get; set; }
        [XmlIgnore]
        public string Publisher { get; set; }
    }
}