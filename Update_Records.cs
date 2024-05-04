using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Connection string to your SQL Server database
        string connectionString = "Server =.\\sqlexpress; database = ADODOTNETPRACTISE; integrated security = true;";

        // SQL query to update data in a table
        string updateQuery = "UPDATE employees SET name = @Name, city = @City, experience = @Experience WHERE id = @Id";

        // Sample data for update
        int idToUpdate = 1; // ID of the record to update
        string newName = "Aniket";
        string newCity = "Satara";
        int newExperience = 10; // New experience value

        // Create a new SqlConnection object with the connection string
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Create a new SqlCommand object with the update query and connection
            using (SqlCommand command = new SqlCommand(updateQuery, connection))
            {
                // Add parameters to the SqlCommand to prevent SQL injection
                command.Parameters.AddWithValue("@Id", idToUpdate);
                command.Parameters.AddWithValue("@Name", newName);
                command.Parameters.AddWithValue("@City", newCity);
                command.Parameters.AddWithValue("@Experience", newExperience);

                try
                {
                    // Open the connection to the database
                    connection.Open();

                    // Execute the update query
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if any rows were affected (i.e., if the update was successful)
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Data updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("No rows were updated.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating data: " + ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
