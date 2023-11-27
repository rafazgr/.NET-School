namespace QueueTask
{
    public interface IQueue<T>
    {
        void Enqueue(T element);
        T Dequeue();
        bool IsEmpty();
    }
}
