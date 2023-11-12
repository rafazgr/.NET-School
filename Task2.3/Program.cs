class Entity
{
    protected string _textDescription;

    public Entity(string textDescription)
    {
        _textDescription = textDescription;
    }
}

abstract class Lesson : Entity
{
    public Lesson(string textDescription) : base(textDescription) { }

    public abstract Lesson Clone();
}

class Lecture : Lesson
{
    private string _topic;

    public Lecture(string textDescription, string topic) : base(textDescription)
    {
        _topic = topic;
    }

    public override Lesson Clone()
    {
        return new Lecture(_textDescription, _topic);
    }
}

class PracticalLesson : Lesson
{
    private string _taskCondition;
    private string _solution;

    public PracticalLesson(string textDescription, string taskCondition, string solution) : base(textDescription)
    {
        _taskCondition = taskCondition;
        _solution = solution;
    }

    public override Lesson Clone()
    {
        return new PracticalLesson(_textDescription, _taskCondition, _solution);
    }
}

class Training
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
