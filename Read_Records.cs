using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Connection string to your SQL Server database
        string connectionString = "Server=.\\sqlexpress;database=Ajay_Assignment;integrated security = true;";

        // SQL query to select data from a table
        string selectQuery = "SELECT * FROM employees";

        // Create a new SqlConnection object with the connection string
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Create a new SqlCommand object with the select query and connection
            using (SqlCommand command = new SqlCommand(selectQuery, connection))
            {
                try
                {
                    // Open the connection to the database
                    connection.Open();

                    // Execute the select query and obtain a data reader
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

                                // Display the retrieved values
                                Console.WriteLine($"ID: {id}, Name: {name}, City: {city}, Experience: {experience} years");
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
                    Console.WriteLine("Error reading data: " + ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
