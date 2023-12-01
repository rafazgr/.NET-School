using System.Text.RegularExpressions;

namespace BookCatalogTask
{
    public class Catalog
    {
        private Dictionary<string, Book> books;

        public Catalog()
        {
            books = new Dictionary<string, Book>();
        }

        public void AddBook(Book book, string isbn)
        {
            string normalizedISBN = NormalizeAndValidateISBN(isbn);

            if (books.ContainsKey(normalizedISBN))
            {
                throw new ArgumentException("Book with this ISBN already exists.");
            }

            books.Add(normalizedISBN, book);
        }

        public Book GetBook(string isbn)
        {
            string normalizedISBN = NormalizeAndValidateISBN(isbn);

            if (books.TryGetValue(normalizedISBN, out Book book))
            {
                return book;
            }

            return null;
        }

        private string NormalizeAndValidateISBN(string isbn)
        {
            string normalizedISBN = isbn.Replace("-", "");

            if (normalizedISBN.Length != 13 || !Regex.IsMatch(normalizedISBN, "^[0-9]+$"))
            {
                throw new ArgumentException("Invalid ISBN format. Must have 13 digits and contain only digits 0-9.");
            }

            return normalizedISBN;
        }

        public IEnumerable<string> GetBookSorted()
        {
            return books.Values.Select(book => book.Title).OrderBy(title => title);
        }

        public IEnumerable<Book> GetBooksByAuthor(string authorName)
        {
            return books.Values
                .Where(book => book.Authors.Contains(authorName))
                .OrderBy(book => book.PublicationDate);
        }

        public IEnumerable<(string AuthorName, int BookCount)> GetAuthorBookCount()
        {
            return books.Values
                .SelectMany(book => book.Authors, (book, author) => author)
                .GroupBy(author => author)
                .Select(group => (AuthorName: group.Key, BookCount: group.Count()));
        }
    }
}