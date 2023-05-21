using Microsoft.Data.Sqlite;

namespace Habit;

public class Db
{
    // This is a database.
    private string _connectionString;
    private string _databaseName;
    private string _databasePassword;
    private string _databaseUsername;
    
    // Properties
    public string ConnectionString
    {
        get => _connectionString;
        set => _connectionString = value;
    }
    
    public string DatabaseName
    {
        get => _databaseName;
        set => _databaseName = value;
    }
    
    public string DatabasePassword
    {
        get => _databasePassword;
        set => _databasePassword = value;
    }
    
    public string DatabaseUsername
    {
        get => _databaseUsername;
        set => _databaseUsername = value;
    }

    // Create a sqllite database.
    public void CreateSqliteDatabase()
    {
        // Set the connection string.
        _connectionString = $"Data Source={_databaseName}.db";

        // Create a new instance of the SqliteConnection class.
        SqliteConnection connection = new SqliteConnection(_connectionString);
    
        // Open the connection.
        connection.Open();
    
        // Close the connection.
        connection.Close();
    }

    // Create the record
    public void CreateHabitsTable()
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
                @"
                CREATE TABLE IF NOT EXISTS Habits (
                    Id INTEGER PRIMARY KEY,
                    Name TEXT NOT NULL,
                    Description TEXT NOT NULL,
                    Frequency TEXT NOT NULL
                )
            ";

            command.ExecuteNonQuery();
        }
    }

    public void InsertHabit(Habit habit)
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
                @"
                INSERT INTO Habits (Name, Description, Frequency) 
                VALUES ($Name, $Description, $Frequency)
            ";

            command.Parameters.AddWithValue("$Name", habit.HabitName);
            command.Parameters.AddWithValue("$Description", habit.Description);
            command.Parameters.AddWithValue("$Frequency", habit.Frequency);

            command.ExecuteNonQuery();
        }
    }
    
    public long Size
    {
        get
        {
            var fileInfo = new System.IO.FileInfo(_databaseName + ".db");
            return fileInfo.Exists ? fileInfo.Length : 0;
        }
    }

    public List<Habit> GetAllHabits()
    {
        var habits = new List<Habit>();

        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
                @"
            SELECT Name, Description, Frequency
            FROM Habits
        ";

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var habit = new Habit
                    {
                        HabitName = reader.GetString(0),
                        Description = reader.GetString(1),
                        Frequency = reader.GetString(2)
                    };

                    habits.Add(habit);
                }
            }
        }

        return habits;
    }
    
    // Delete the record
    public void RemoveHabit(string name)
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
                @"
                DELETE FROM Habits
                WHERE Name = $Name
            ";

            command.Parameters.AddWithValue("$Name", name);

            command.ExecuteNonQuery();
        }
    }
}