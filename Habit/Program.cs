// This is an application where you can track your habits.
// The application should restore and retrieve data from a real database.
// The application should be able to add, edit, and delete habits.
// The application should be able to add, edit, and delete records for each habit.
// It should create a table in the database for each habit.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;


namespace Habit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SQLitePCL.Batteries.Init();
            // Create a new instance of the HabitTracker class.
            Db db = new Db
            {
                ConnectionString = "Data Source=habits.db"
            };
            HabitTracker habitTracker = new HabitTracker(db);

            while (true)
            {
                // Prepare the console.
                Console.Clear();
                Console.Title = "Habit";
            
                // Display the welcome message.
                Console.WriteLine("Welcome to Habit!");
            
                // Display the menu.
                Console.WriteLine("1. Add Habit");
                Console.WriteLine("2. Display All Habits");
                Console.WriteLine("3. Display DB Status");
                Console.WriteLine("4. Remove Habit");
                Console.WriteLine("5. Exit");
            
                // Get the user's choice.
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
            
                // Process the user's choice.
                switch (choice)
                {
                    case "1":
                        // Create a new instance of the Habit class.
                        Habit habit = new Habit();
                    
                        // Run the Habit class.
                        habit.Run();

                        // Add the habit to the tracker.
                        habitTracker.AddHabit(habit);
                        break;
                    case "2":
                        // Display all habits.
                        habitTracker.GetAll();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "5":
                        // Exit the application.
                        Environment.Exit(0);
                        break;
                    case "3":
                        // Display the database status.
                        Console.WriteLine($"Database Name: {db.DatabaseName}");
                        Console.WriteLine($"Database Username: {db.DatabaseUsername}");
                        Console.WriteLine($"Database Password: {db.DatabasePassword}");
                        Console.WriteLine($"Database Connection String: {db.ConnectionString}");
                        
                        // Display record count.
                        Console.WriteLine($"Habit Count: {habitTracker.Habits.Count}");
                        
                        // Display db size.
                        Console.WriteLine($"Database Size: {db.Size}");
                        
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    default:
                        // Display an error message.
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "4":
                        // Delete a habit.
                        Console.WriteLine("Enter the name of the habit you want to delete: ");
                        // List all habits names for user to choose from.
                        foreach (Habit habit1 in habitTracker.Habits)
                        {
                            Console.WriteLine(habit1.HabitName);
                        }
                        string habitName = Console.ReadLine();
                        habitTracker.RemoveHabit(habitName);
                        break;
                }
            }
        }
    }

}

// Path: Habit/Models/Habit.cs
// This is a model for a habit.
