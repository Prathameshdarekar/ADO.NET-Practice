using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Connection string to your SQL Server database
        string connectionString = "Server=.\\sqlexpress;database=ADODOTNETPRACTISE;integrated security = true;";

        // SQL query to insert data into a table
        string insertQuery = "INSERT INTO trainer (id, name, city, experience) VALUES (@id, @name, @city, @experience)";

        // Sample data to be inserted into the table
        int id = 3;
        string name = "Dashrath";
        string city = "hyderabad";
        int experience = 3;

        // Create a new SqlConnection object with the connection string
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Create a new SqlCommand object with the insert query and connection
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                // Add parameters to the SqlCommand to prevent SQL injection
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@city", city);
                command.Parameters.AddWithValue("@experience", experience);

                try
                {
                    // Open the connection to the database
                    connection.Open();

                    // Execute the insert query
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if any rows were affected (i.e., if the insertion was successful)
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Data inserted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("No rows were inserted.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error inserting data: " + ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
