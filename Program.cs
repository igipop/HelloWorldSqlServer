using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World 123!");

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var dbConnectionString = config.GetSection("db").Value;

Console.WriteLine($"Using connection string: {dbConnectionString}");

using (SqlConnection conn = new SqlConnection(dbConnectionString))
{
    conn.Open();

    using (SqlCommand cmd = new SqlCommand("select name from sys.databases", conn))
    {
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0));
            }
        }
    }

    Console.WriteLine("\nDone!!!");
    Console.ReadLine();

}
