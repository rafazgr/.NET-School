namespace AbstractLibraryTask
{
    public class EbookLibraryFactory : ILibraryFactory
    {
        public Library CreateLibrary(string filePath)
        {
            CsvParser csvParser = new CsvParser(filePath, LibraryType.EBook);
            List<EBook> eBooks = csvParser.ParseEBooks();
            List<string> pressReleaseItems = csvParser.GetPressReleaseItems();

            Catalog catalog = new Catalog();
            foreach (var eBook in eBooks)
            {
                catalog.AddBook(eBook, eBook.Identifier);
            }

            return new Library { Catalog = catalog, PressReleaseItems = pressReleaseItems };
        }
    }
}