namespace AbstractLibraryTask
{
    public class LibraryBuilder
    {
        public static Library BuildLibrary(string filePath, LibraryType libraryType)
        {
            ILibraryFactory libraryFactory;
            switch (libraryType)
            {
                case LibraryType.PaperBook:
                    libraryFactory = new PaperBookLibraryFactory();
                    break;
                case LibraryType.EBook:
                    libraryFactory = new EbookLibraryFactory();
                    break;
                default:
                    throw new ArgumentException("Invalid library type");
            }

            return libraryFactory.CreateLibrary(filePath);
        }
    }

    public enum LibraryType
    {
        PaperBook,
        EBook
    }
}
