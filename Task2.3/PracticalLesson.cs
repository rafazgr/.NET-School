namespace Task2_3
{
    public class PracticalLesson : Lesson
    {
        private string _taskCondition;
        private string _solution;

        public PracticalLesson(string textDescription, string taskCondition, string solution) : base(textDescription)
        {
            _taskCondition = taskCondition;
            _solution = solution;
        }

        public string Solution
        {
            get { return _solution; }
        }

        public override Lesson Clone()
        {
            return new PracticalLesson(_textDescription, _taskCondition, _solution);
        }
    }
}
