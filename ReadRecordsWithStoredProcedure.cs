//CREATE PROCEDURE GetEmployees
//AS
//BEGIN
//    SELECT * FROM Employees;
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

        // Name of the stored procedure to retrieve records
        string storedProcedureName = "GetEmployees"; 

        // Create a new SqlConnection object with the connection string
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Create a new SqlCommand object for the stored procedure
            using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
            {
                // Specify that the command is a stored procedure
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    // Open the connection to the database
                    connection.Open();

                    // Execute the stored procedure and obtain a SqlDataReader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if the data reader has rows
                        if (reader.HasRows)
                        {
                            // Iterate through the rows in the data reader
                            while (reader.Read())
                            {
                                // Access the values in each column by column name or index
                                int id = reader.GetInt32(reader.GetOrdinal("id"));
                                string name = reader.GetString(reader.GetOrdinal("name"));
                                string city = reader.GetString(reader.GetOrdinal("city"));
                                int experience = reader.GetInt32(reader.GetOrdinal("experience"));

                                // Process the retrieved data
                                Console.WriteLine($"ID: {id}, Name: {name}, City: {city}, Experience: {experience}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No data found.");
                        }
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
