using System;
using Npgsql;
using System.Data.Common;
using System.Text.Json;
using System.Linq;

namespace EmployeeAPI
{
    class Program
    {
        public static void Main(string[] args)
        {
           
            Crud crud = new Crud("localhost", "5432", "postgres", "dimik2001", "Job");
            //crud.Read(32);
            crud.Read(3);
            
            //crud.Add("DB", "fdsdfs", "dsfdsf", 3, "dfsdf", "dfsdfssd");
            /*crud.update(@"
            {
                'id': '200',
                'Replacements': [
                    {
                        'Name': 'name',
                        'Content': 'Dima'
                    },
                    {
                        'Name': 'companyId',
                        'Content': '32'
                    }
                ]
            }");*/
            /*String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=dimik2001;Database=DownloaderMusic;";
            try
            {
                NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            
            npgSqlConnection.Open();
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand("SELECT * FROM people", npgSqlConnection);
                NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
                if (npgSqlDataReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in npgSqlDataReader)

                        Console.WriteLine(dbDataRecord["name"] + "   " + dbDataRecord["url"]);
                }
                else
                    Console.WriteLine("Запрос не вернул строк");
                Console.ReadKey(true);
            
            }
            catch (Exception e) { Console.WriteLine("Ты лох"); }*/


        }
    }
}
