namespace BookCatalogTask
{
    class Program
    {
        static void Main()
        {
            Catalog catalog = new Catalog();

            Book book1 = new Book("Book A", new DateOnly(2022, 3, 1), new[] { "Author 1", "Author 2" });
            Book book2 = new Book("Book B", new DateOnly(2022, 1, 1), new[] { "Author 1" });
            Book book3 = new Book("Book C", new DateOnly(2022, 2, 1), new[] { "Author 2" });

            catalog.AddBook(book1, "123-4-56-789012-3");
            catalog.AddBook(book2, "9876543210123");
            catalog.AddBook(book3, "456-7-89-012345-6");

            Console.WriteLine("Book Titles Sorted Alphabetically:");
            foreach (var title in catalog.GetBookSorted())
            {
                Console.WriteLine(title);
            }

            Console.WriteLine("\nBooks by Author 1 Sorted by Publication Date:");
            foreach (var book in catalog.GetBooksByAuthor("Author 1"))
            {
                Console.WriteLine($"{book.Title} - {book.PublicationDate}");
            }

            Console.WriteLine("\nAuthor Book Count:");
            foreach (var tuple in catalog.GetAuthorBookCount())
            {
                Console.WriteLine($"{tuple.AuthorName} - {tuple.BookCount}");
            }

            // Check if a book registered as XXX-X-XX-XXXXXX-X is found as XXXXXXXXXXXXX
            string isbnToCheck = "1234567890123";
            Book checkedBook = catalog.GetBook(isbnToCheck);

            if (checkedBook != null)
            {
                Console.WriteLine($"\nChecking Book with ISBN {isbnToCheck}: {checkedBook.Title} - {checkedBook.PublicationDate}");
            }
            else
            {
                Console.WriteLine($"\nBook with ISBN {isbnToCheck} not found in the catalog.");
            }
        }
    }
}