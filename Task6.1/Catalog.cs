namespace BookCatalogTask
{
    public class Catalog
    {
        private List<Book> books;

        public Catalog()
        {
            books = new List<Book>();
        }

        public Dictionary<string, Book> Books
        {
            get
            {
                return books.ToDictionary(book => book.ISBN);
            }
            set
            {
                books = new List<Book>(value.Values);
            }
        }

        public void AddBook(Book book, string isbn)
        {
            string normalizedISBN = NormalizeAndValidateISBN(isbn);

            if (Books.ContainsKey(normalizedISBN))
            {
                throw new ArgumentException("Book with this ISBN already exists.");
            }

            book.ISBN = normalizedISBN;
            books.Add(book);
        }

        public Book GetBook(string isbn)
        {
            string normalizedISBN = NormalizeAndValidateISBN(isbn);

            if (Books.TryGetValue(normalizedISBN, out Book book))
            {
                return book;
            }

            return null;
        }

        private string NormalizeAndValidateISBN(string isbn)
        {
            string normalizedISBN = isbn.Replace("-", "");

            if (normalizedISBN.Length != 13 || !System.Text.RegularExpressions.Regex.IsMatch(normalizedISBN, "^[0-9]+$"))
            {
                throw new ArgumentException("Invalid ISBN format. Must have 13 digits and contain only digits 0-9.");
            }

            return normalizedISBN;
        }

        public void DisplayCatalog()
        {
            foreach (var book in Books.Values)
            {
                Console.WriteLine($"Title: {book.Title}. Author: {string.Join(", ", book.Authors.Select(a => $"{a.FirstName} {a.LastName}"))}. Date: {book.PublicationDate}");
            }
        }

        public void SaveToRepository(IRepository<List<Book>> repository, string filePath)
        {
            repository.Save(filePath, books);
        }

        public static Catalog LoadFromRepository(IRepository<List<Book>> repository, string filePath)
        {
            List<Book> loadedData = repository.Load(filePath);

            Catalog catalog = new Catalog();
            catalog.Books = loadedData
                .GroupBy(book => book.ISBN)
                .ToDictionary(group => group.Key, group => group.First());

            return catalog;
        }
    }
}
