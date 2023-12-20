using System.Text.Json;

namespace BookCatalogTask
{
    public class JSONRepository<T> : IRepository<T>
    {
        public void Save(string filePath, T data)
        {
            var books = data as List<Book>;

            var booksByAuthor = books.SelectMany(book => book.Authors, (book, author) => new { Book = book, Author = author })
                .GroupBy(entry => entry.Author, entry => entry.Book);

            Directory.CreateDirectory(filePath);

            foreach (var authorGroup in booksByAuthor)
            {
                string authorFilePath = GetAuthorFilePath(filePath, authorGroup.Key);
                string json = JsonSerializer.Serialize(authorGroup.ToList(), new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(authorFilePath, json);
            }
        }

        public T Load(string filePath)
        {
            Directory.CreateDirectory(filePath);

            var authorFiles = Directory.GetFiles(filePath, "*.json");
            var loadedBooks = new List<Book>();

            foreach (var authorFile in authorFiles)
            {
                string json = File.ReadAllText(authorFile);
                var authorBooks = JsonSerializer.Deserialize<List<Book>>(json);
                loadedBooks.AddRange(authorBooks);
            }

            return (T)(object)loadedBooks;
        }

        private string GetAuthorFilePath(string baseFilePath, Author author)
        {
            string sanitizedAuthorName = $"{author.FirstName}_{author.LastName}";
            return Path.Combine(baseFilePath, $"{sanitizedAuthorName}.json");
        }
    }
}
