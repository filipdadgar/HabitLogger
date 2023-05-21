namespace Habit;

public class HabitTracker
{
    // This is a list of habits.
    private List<Habit> _habits = new List<Habit>();
    private Db _db;
    
    // Properties
    public List<Habit> Habits
    {
        get => _habits;
        set => _habits = value;
    }

    // Constructors
    public HabitTracker(Db db)
    {
        _db = db;
        _db.CreateHabitsTable();
        _habits = _db.GetAllHabits();
    }
    
    // Methods
    public void GetAll()
    {
        // Get all the habits.
        foreach (Habit habit in _habits)
        {
            // Display the habit's name.
            Console.WriteLine($"Habit: {habit.HabitName}");
            
            // Display the habit's description.
            Console.WriteLine($"Description: {habit.Description}");
            
            // Display the habit's frequency.
            Console.WriteLine($"Frequency: {habit.Frequency}");
        }
    }

    public void AddHabit(Habit habit)
    {
        _habits.Add(habit);
        _db.InsertHabit(habit);
    }

    // Delete habit from list
    public void RemoveHabit(string name)
    {
        _habits.RemoveAll(habit => habit.HabitName == name);
        _db.RemoveHabit(name);
    }
}
