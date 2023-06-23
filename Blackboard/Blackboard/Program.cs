
using System.Data.SqlClient;

namespace Blackboard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestConnectionString();

        }

        static void TestConnectionString()
        {

                string connectionString = "Server=localhost;Database=database;User Id=Luigi;Password=1234";
          
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection successful!");
                    // Perform additional operations if needed
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Connection failed: {ex.Message}");
                }
            }
        }
    }
}