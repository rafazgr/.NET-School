namespace Task2_3
{
    public class Lecture : Lesson
    {
        private string _topic;

        public Lecture(string textDescription, string topic) : base(textDescription)
        {
            _topic = topic;
        }

        public string Topic
        {
            get { return _topic; }
        }

        public override Lesson Clone()
        {
            return new Lecture(_textDescription, _topic);
        }
    }
}
