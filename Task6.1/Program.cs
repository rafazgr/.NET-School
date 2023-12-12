namespace BookCatalogTask
{
    class Program
    {
        static void Main()
        {
            Catalog catalog = new Catalog();

            Author author1 = new Author { FirstName = "Juan", LastName = "Rulfo", DateOfBirth = new DateTime(1917, 1, 16) };
            Author author2 = new Author { FirstName = "Gabriel", LastName = "Garcia Marquez", DateOfBirth = new DateTime(1927, 3, 6) };
            Author author3 = new Author { FirstName = "Carlos", LastName = "Fuentes", DateOfBirth = new DateTime(1928, 11, 11) };

            Book book1 = new Book { Title = "Pedro Paramo", PublicationDate = new DateTime(1967, 1, 7), Authors = new List<Author> { author1 } };
            Book book2 = new Book { Title = "El gallo de oro", PublicationDate = new DateTime(1980, 4, 5), Authors = new List<Author> { author1, author2 } };
            Book book3 = new Book { Title = "Cien años de soledad", PublicationDate = new DateTime(1967, 6, 5), Authors = new List<Author> { author2 } };
            Book book4 = new Book { Title = "Aura", PublicationDate = new DateTime(1962, 12, 8), Authors = new List<Author> { author3 } };
            Book book5 = new Book { Title = "La muerte de Artemio Cruz", PublicationDate = new DateTime(1962, 10, 22), Authors = new List<Author> { author1, author3 } };

            catalog.AddBook(book1, "978-8-43-764609-1");
            catalog.AddBook(book2, "9788437644721");
            catalog.AddBook(book3, "978-8-49-759220-8");
            catalog.AddBook(book4, "9786074451849");
            catalog.AddBook(book5, "978-6-07-313351-7");

            Console.WriteLine("Original Catalog");
            catalog.DisplayCatalog();

            IRepository<CatalogData> xmlRepository = new XMLRepository<CatalogData>();
            IRepository<CatalogData> jsonRepository = new JSONRepository<CatalogData>();

            catalog.SaveToRepository(xmlRepository, "catalog.xml");
            catalog.SaveToRepository(jsonRepository, "catalog");

            Catalog loadedFromXml = Catalog.LoadFromRepository(xmlRepository, "catalog.xml");
            Catalog loadedFromJson = Catalog.LoadFromRepository(jsonRepository, "catalog");

            Console.WriteLine("Catalog loaded from XML");
            loadedFromXml.DisplayCatalog();

            Console.WriteLine("Catalog loaded from JSON files");
            loadedFromJson.DisplayCatalog();
        }
    }
}