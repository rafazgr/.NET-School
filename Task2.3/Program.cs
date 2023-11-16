namespace Task2_3
{
    class Program
    {
        static void Main()
        {
            Lecture lecture = new Lecture("Lecture1", "Topic1");
            PracticalLesson practicalLesson = new PracticalLesson("Practical Lesson 1", "Task Condition 1", "Task Solution 1");

            Training originalTraining = new Training();
            originalTraining.Add(practicalLesson);
            Training clonedTraining = originalTraining.Clone();
            clonedTraining.Add(lecture);

            Console.WriteLine("Is the original training practical? " + originalTraining.IsPractical());
            Console.WriteLine("Is the cloned training practical? " + clonedTraining.IsPractical());
        }
    }
}
