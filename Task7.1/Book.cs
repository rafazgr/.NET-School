namespace AbstractLibraryTask
{
    public class Book
    {
        private string _title;

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

        public string Identifier { get; set; }
        public DateTime? PublicationDate { get; set; }
        public List<Author> Authors { get; set; }
    }
}