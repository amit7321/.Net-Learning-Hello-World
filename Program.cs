// See https://aka.ms/new-console-template for more information

using System;
using System.Data;
using Dapper;
using helloWorld.Data;
using helloWorld.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace helloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            DataContextEF dataContextEf = new DataContextEF(configuration);

            Computer computer = new Computer()
            {
                Mobo = "msi b250",
                Cpu = "12400",
                Price = 23000
            };

            dataContextEf.Add(computer);
            dataContextEf.SaveChanges();

            IEnumerable<Computer>? computers = dataContextEf.Computers?.ToList();

            /*string connectionString = "Server=localhost,1433;Database=dotNetCourse;TrustServerCertificate=true;Trusted_Connection=True";
            IDbConnection dbConnection = new SqlConnection(connectionString);*/

            /*string sqlCommand = "select getdate()";
            DateTime dt = dbConnection.QuerySingle<DateTime>(sqlCommand);*/


            /*Computer c1 = new Computer()
            {
                Mobo = "msi bm260",
                Price = 17000,
                Cpu = "intel i5-12400"
            };*/
        }
    }
}