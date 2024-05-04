using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Connection string to your SQL Server database
        string connectionString = "Server =.\\sqlexpress; database = ADODOTNETPRACTISE; integrated security = true;";

        // SQL query to delete data from a table
        string deleteQuery = "DELETE FROM employees WHERE id = @IdToDelete";

        // ID of the record to delete
        int idToDelete = 1; // Example ID to be deleted

        // Create a new SqlConnection object with the connection string
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Create a new SqlCommand object with the delete query and connection
            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
            {
                // Add parameters to the SqlCommand to prevent SQL injection
                command.Parameters.AddWithValue("@IdToDelete", idToDelete);

                try
                {
                    // Open the connection to the database
                    connection.Open();

                    // Execute the delete query
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if any rows were affected (i.e., if the deletion was successful)
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Record deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("No record was deleted.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting record: " + ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
