using BookCatalogTask;
using System.Xml.Serialization;

namespace AbstractLibraryTask
{
    public class EBook : Book
    {
        [XmlIgnore]
        public List<string> ResourceIdentifier { get; set; }
        [XmlIgnore]
        public List<string> Formats { get; set; }
        public int? Pages { get; private set; }

        public async Task FillPagesAsync()
        {
            Pages = await HtmlParser.FillPagesAsync(Identifier);
        }
    }
}