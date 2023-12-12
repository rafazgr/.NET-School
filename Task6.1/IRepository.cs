namespace BookCatalogTask
{
    public interface IRepository<T>
    {
        void Save(string filePath, T data);
        T Load(string filePath);
    }
}