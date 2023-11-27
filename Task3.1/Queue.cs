namespace QueueTask
{
    public class Queue<T> : IQueue<T>
    {
        private LinkedList<T> linkedList = new LinkedList<T>();

        public void Enqueue(T element)
        {
            linkedList.AddLast(element);
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty. Cannot dequeue an element.");
            }

            T firstElement = linkedList.First.Value;
            linkedList.RemoveFirst();
            return firstElement;
        }

        public bool IsEmpty()
        {
            return linkedList.Count == 0;
        }
    }
}