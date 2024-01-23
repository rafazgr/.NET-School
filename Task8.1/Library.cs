namespace AbstractLibraryTask
{
    public class Library
    {
        public Catalog Catalog { get; set; }
        public List<string> PressReleaseItems { get; set; }

        public async Task InitializePagesAsync()
        {
            foreach (var book in Catalog.Books.Values)
            {
                if (book is EBook eBook)
                {
                    await eBook.FillPagesAsync();
                }
            }
        }
    }
}