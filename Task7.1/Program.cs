namespace AbstractLibraryTask
{
    class Program
    {
        static void Main()
        {
            string filePath = "books_info.csv";

            Library paperBookLibrary = LibraryBuilder.BuildLibrary(filePath, LibraryType.PaperBook);
            DisplayLibraryContents(paperBookLibrary, "PaperBook Library");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Library eBookLibrary = LibraryBuilder.BuildLibrary(filePath, LibraryType.EBook);
            DisplayLibraryContents(eBookLibrary, "EBook Library");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            IRepository<List<Book>> xmlRepository = new XMLRepository<List<Book>>();
            IRepository<List<Book>> jsonRepository = new JSONRepository<List<Book>>();

            // Save and load PaperBook Catalog
            paperBookLibrary.Catalog.SaveToRepository(xmlRepository, "PaperBookCatalog.xml");
            paperBookLibrary.Catalog.SaveToRepository(jsonRepository, "PaperBookCatalog");

            Catalog loadedPaperBookFromXml = Catalog.LoadFromRepository(xmlRepository, "PaperBookCatalog.xml");
            Catalog loadedPaperBookFromJson = Catalog.LoadFromRepository(jsonRepository, "PaperBookCatalog");

            Console.WriteLine("PaperBook Catalog loaded from XML");
            loadedPaperBookFromXml.DisplayCatalog();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Console.WriteLine("PaperBook Catalog loaded from JSON files");
            loadedPaperBookFromJson.DisplayCatalog();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            // Save and load Ebook Catalog
            eBookLibrary.Catalog.SaveToRepository(xmlRepository, "EBookCatalog.xml");
            eBookLibrary.Catalog.SaveToRepository(jsonRepository, "EBookCatalog");

            Catalog loadedEBookFromXml = Catalog.LoadFromRepository(xmlRepository, "PaperBookCatalog.xml");
            Catalog loadedEBookFromJson = Catalog.LoadFromRepository(jsonRepository, "PaperBookCatalog");

            Console.WriteLine("EBook Catalog loaded from XML");
            loadedEBookFromXml.DisplayCatalog();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Console.WriteLine("EBook Catalog loaded from JSON files");
            loadedEBookFromJson.DisplayCatalog();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void DisplayLibraryContents(Library library, string libraryType)
        {
            Console.WriteLine($"----- {libraryType} -----");
            foreach (var book in library.Catalog.Books.Values)
            {
                Console.WriteLine($"Title: {book.Title}. Identifier: {book.Identifier}. Author: {string.Join(", ", book.Authors.Select(a => $"{a.FirstName} {a.LastName}"))}. Date: {book.PublicationDate}");
            }
            Console.WriteLine($"Press Release Items: {string.Join(", ", library.PressReleaseItems)}");
            Console.WriteLine();
        }
    }
}