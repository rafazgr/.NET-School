namespace BookCatalogTask
{
    public class Book
    {
        private string _title;
        private string _isbn;

        public string Title
        {
            get => _title;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Title), "Title cannot be null.");
                }

                _title = value;
            }
        }

        public DateTime? PublicationDate { get; set; }
        public List<Author> Authors { get; set; }

        public string ISBN
        {
            get => _isbn;
            set
            {
                string normalizedISBN = NormalizeAndValidateISBN(value);
                _isbn = normalizedISBN;
            }
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
    }
}
