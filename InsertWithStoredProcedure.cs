// Stored Procedure
//CREATE PROCEDURE AddEmployee
//   @Name NVARCHAR(100),
//   @City NVARCHAR(100),
//    @Experience INT
//AS
//BEGIN
//    INSERT INTO Employees (Name, City, Experience)
//   VALUES (@Name, @City, @Experience)
//END

using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Connection string to your SQL Server database
        string connectionString = "Server=.\\sqlexpress;database=Ajay_Assignment;integrated security = true;";

        // Name of the stored procedure to add records
        string storedProcedureName = "AddEmployee";

        // Sample data for the new record
        string name = "Ajay";
        string city = "MP";
        int experience = 2;

        // Create a new SqlConnection object with the connection string
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Create a new SqlCommand object for the stored procedure
            using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
            {
                // Specify that the command is a stored procedure
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters to the stored procedure
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@City", city);
                command.Parameters.AddWithValue("@Experience", experience);

                try
                {
                    // Open the connection to the database
                    connection.Open();

                    // Execute the stored procedure
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if any rows were affected (i.e., if the record was added successfully)
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Record added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("No record was added.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding record: " + ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
