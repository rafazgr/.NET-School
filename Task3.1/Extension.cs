namespace QueueTask
{
    public static class QueueExtension
    {
        public static IQueue<T> Tail<T>(this IQueue<T> queue)
        {
            if (queue.IsEmpty())
            {
                throw new InvalidOperationException("Cannot get Tail of an empty queue.");
            }

            IQueue<T> newQueue = new Queue<T>();
            queue.Dequeue();
            while (!queue.IsEmpty())
            {
                newQueue.Enqueue(queue.Dequeue());
            }

            return newQueue;
        }
    }
}
