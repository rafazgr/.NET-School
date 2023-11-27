namespace QueueTask
{
    class Program
    {
        static void Main(string[] args)
        {
            IQueue<int> TestQueue = new Queue<int>();
            TestQueue.Enqueue(2);
            TestQueue.Enqueue(4);
            TestQueue.Enqueue(6);
            TestQueue.Enqueue(8);

            Console.WriteLine("Original Queue:");

            while (!TestQueue.IsEmpty())
            {
                Console.Write(TestQueue.Dequeue() + " ");
            }

            // TestQueue.Dequeue(); // This will throw an exception

            TestQueue.Enqueue(1);
            TestQueue.Enqueue(3);
            TestQueue.Enqueue(5);
            TestQueue.Enqueue(7);

            IQueue<int> tailQueue = TestQueue.Tail();
            Console.WriteLine("\nTail Queue:");

            while (!tailQueue.IsEmpty())
            {
                Console.Write(tailQueue.Dequeue() + " ");
            }
        }
    }
}
