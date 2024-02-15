using AbstractLibraryTask;

namespace BookCatalogTask
{
    class Program
    {
        static async Task Main()
        {
            string filePath = "books_info.csv";

            // Build the EBook library
            Library eBookLibrary = LibraryBuilder.BuildLibrary(filePath, LibraryType.EBook);

            await InitializeAndDisplayPagesAsync(eBookLibrary);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static async Task InitializeAndDisplayPagesAsync(Library library)
        {
            // Initialize pages for EBooks asynchronously
            await library.InitializePagesAsync();

            // Display updated library contents with pages
            DisplayLibraryContents(library, "EBook Library");
        }

        static void DisplayLibraryContents(Library library, string libraryType)
        {
            Console.WriteLine($"----- {libraryType} -----");
            foreach (var book in library.Catalog.Books.Values)
            {
                Console.WriteLine($"Title: {book.Title}. Pages: {(book is EBook eBook ? eBook.Pages.ToString() : "N/A")}. Identifier: {book.Identifier}. Author: {string.Join(", ", book.Authors.Select(a => $"{a.FirstName} {a.LastName}"))}. Date: {book.PublicationDate}");

            }
            Console.WriteLine($"Press Release Items: {string.Join(", ", library.PressReleaseItems)}");
        }
    }
}