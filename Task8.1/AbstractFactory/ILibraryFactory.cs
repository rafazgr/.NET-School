namespace AbstractLibraryTask
{
    public interface ILibraryFactory
    {
        Library CreateLibrary(string filePath);
    }
}