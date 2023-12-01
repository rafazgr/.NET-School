namespace BookCatalogTask
{
    public class Book
    {
        private string title;
        private DateOnly? publicationDate;
        private HashSet<string> authors;

        public Book(string title, DateOnly? publicationDate, IEnumerable<string> authors)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be empty or null.");
            }

            this.title = title;
            this.publicationDate = publicationDate;
            this.authors = new HashSet<string>(authors ?? Array.Empty<string>());
        }

        public string Title => title;
        public DateOnly? PublicationDate => publicationDate;
        public HashSet<string> Authors => authors;
    }
}