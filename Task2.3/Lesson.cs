namespace Task2_3
{
    public abstract class Lesson : Entity
    {
        public Lesson(string textDescription) : base(textDescription) { }

        public abstract Lesson Clone();
    }
}
