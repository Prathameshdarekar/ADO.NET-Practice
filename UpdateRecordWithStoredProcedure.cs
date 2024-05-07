//CREATE PROCEDURE UpdateEmployee
//    @Id INT,
//    @NewName NVARCHAR(100),
//    @NewCity NVARCHAR(100),
//    @NewExperience INT
//AS
//BEGIN
//    UPDATE Employees
//    SET Name = @NewName,
//        City = @NewCity,
//        Experience = @NewExperience
//    WHERE Id = @Id;
//END

using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Connection string to your SQL Server database
        string connectionString = "Server=.\\sqlExpress;database=ADODOTNETPRACTISE;Integrated security=true;";

        // Name of the stored procedure to update records
        string storedProcedureName = "UpdateEmployee"; 

        // Sample data for the update
        int idToUpdate = 3; 
        string newName = "Dashrath";
        string newCity = "Pune";
        int newExperience = 10; 

        // Create a new SqlConnection object with the connection string
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Create a new SqlCommand object for the stored procedure
            using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
            {
                // Specify that the command is a stored procedure
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters to the stored procedure
                command.Parameters.AddWithValue("@Id", idToUpdate);
                command.Parameters.AddWithValue("@NewName", newName); 
                command.Parameters.AddWithValue("@NewCity", newCity); 
                command.Parameters.AddWithValue("@NewExperience", newExperience); 

                try
                {
                    // Open the connection to the database
                    connection.Open();

                    // Execute the stored procedure
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if any rows were affected (i.e., if the update was successful)
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Record updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("No record was updated.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error calling stored procedure: " + ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
