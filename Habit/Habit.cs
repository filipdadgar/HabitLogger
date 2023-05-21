namespace Habit;

public class Habit
{
    // This is a habit.
    private string _habit;
    private string _description;
    private string _frequency;

    // Properties
    public string HabitName
    {
        get => _habit;
        set => _habit = value;
    }
    
    public string Description
    {
        get => _description;
        set => _description = value;
    }
    
    public string Frequency
    {
        get => _frequency;
        set => _frequency = value;
    }

    // Constructors
    public Habit()
    {
        // This is a constructor.
    }
    
    // Methods
    public void Run()
    {
        // Get the habit's name.
        Console.Write("Enter the habit's name: ");
        _habit = Console.ReadLine();

        // Check if the habit's name is empty or null.
        while (string.IsNullOrEmpty(_habit))
        {
            // Display an error message.
            Console.WriteLine("The habit's name cannot be empty or null.");

            // Get the habit's name.
            Console.Write("Enter the habit's name: ");
            _habit = Console.ReadLine();
        }

        // Get the habit's description.
        Console.Write("Enter the habit's description: ");
        _description = Console.ReadLine();

        // Check if the habit's description is empty or null.
        while (string.IsNullOrEmpty(_description))
        {
            // Display an error message.
            Console.WriteLine("The habit's description cannot be empty or null.");

            // Get the habit's description.
            Console.Write("Enter the habit's description: ");
            _description = Console.ReadLine();
        }

        // Get the habit's frequency.
        Console.Write("Enter the habit's frequency: ");
        _frequency = Console.ReadLine();

        // Check if the habit's frequency is empty or null.
        while (string.IsNullOrEmpty(_frequency))
        {
            // Display an error message.
            Console.WriteLine("The habit's frequency cannot be empty or null.");

            // Get the habit's frequency.
            Console.Write("Enter the habit's frequency: ");
            _frequency = Console.ReadLine();
        }
    }

    
    
}