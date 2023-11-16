namespace Task2_3
{
    public class Training
    {
        private List<Lesson> _lessons;

        public Training()
        {
            _lessons = new List<Lesson>();
        }

        public void Add(Lesson lesson)
        {
            _lessons.Add(lesson);
        }

        public bool IsPractical()
        {
            foreach (var lesson in _lessons)
            {
                if (lesson is Lecture)
                {
                    return false;
                }
            }
            return true;
        }

        public Training Clone()
        {
            Training clonedTraining = new Training();

            foreach (var lesson in _lessons)
            {
                clonedTraining.Add(lesson.Clone());
            }

            return clonedTraining;
        }
    }
}
