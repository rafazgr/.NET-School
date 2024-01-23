namespace AbstractLibraryTask
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
                return books.ToDictionary(book => book.Identifier);
            }
            set
            {
                books = new List<Book>(value.Values);
            }
        }

        public void AddBook(Book book, string Identifier)
        {

            if (Books.ContainsKey(Identifier))
            {
                throw new ArgumentException($"Book with this identifier {Identifier} {book.Title} already exists.");
            }

            books.Add(book);
        }

        public Book GetBook(string Identifier)
        {

            if (Books.TryGetValue(Identifier, out Book book))
            {
                return book;
            }

            return null;
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
                .GroupBy(book => book.Identifier)
                .ToDictionary(group => group.Key, group => group.First());

            return catalog;
        }
    }
}