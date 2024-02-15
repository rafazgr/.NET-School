namespace AbstractLibraryTask
{
    public class PaperBookLibraryFactory : ILibraryFactory
    {
        public Library CreateLibrary(string filePath)
        {
            CsvParser csvParser = new CsvParser(filePath, LibraryType.PaperBook);
            List<PaperBook> paperBooks = csvParser.ParsePaperBooks();
            List<string> pressReleaseItems = csvParser.GetPressReleaseItems();

            Catalog catalog = new Catalog();
            foreach (var paperBook in paperBooks)
            {
                catalog.AddBook(paperBook, paperBook.Identifier);
            }

            return new Library { Catalog = catalog, PressReleaseItems = pressReleaseItems };
        }
    }
}
