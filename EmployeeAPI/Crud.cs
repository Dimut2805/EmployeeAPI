using System;
using System.Data.Entity;
using System.Linq;
using EmployeeAPI.DataBase;
using Microsoft;

namespace EmployeeAPI
{
    public class Crud
    {
        private String connectionString;
        public Crud(String server, String port, String user, String password, String database)
        {
            connectionString = $"Host={server};Database={database};Username={user};Password={password};";
            //npgSqlConnection = new NpgsqlConnection(connectionString);
        }
        public void Read(int companyId)
        {

            using (DataBase.Communication db = new DataBase.Communication(connectionString))
            {
                foreach (DataBase.Employee employee in db.employees.Include(p => p.passport).ToList())
                {
                    if (employee.companyId == companyId)
                    {
                        Console.WriteLine($"{employee.id} - {employee.passport.type}");
                    }
                }
            }
        }
        public int Add(String name, String surname, String phone, int companyId, String type, String number)
        {
            using(DataBase.Communication db = new DataBase.Communication(connectionString))
            {
                int id = MadeId(db);
                db.employees.Add(new DataBase.Employee()
                {
                    id = id,
                    name = name,
                    surname = surname,
                    phone = phone,
                    companyId = companyId,
                    passport = new DataBase.Passport()
                    {
                        type = type,
                        number = number
                    }
                });
                db.SaveChanges();
        
                return id;
            }
        }
        private int MadeId(DataBase.Communication db)
        {
            int id = 1;
            foreach(DataBase.Employee employee in db.employees.OrderBy(p=>p.id).ToList())
            {
                if(id == employee.id) {
                    id++;
                }
                else { return id; }
            }
            return id;
        }
    }
}
        //String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=dimik2001;Database=Job;";
        /*public class Crud
        {
            private String connectionString;
            private NpgsqlConnection npgSqlConnection;
            public Crud(String server, String port, String user, String password, String database)
            {
                connectionString = $"Server={server};Port={port};User Id={user};Password={password};Database={database};";
                npgSqlConnection = new NpgsqlConnection(connectionString);
            }
            public int Add(String name, String surname, String phone, int companyId, String type, String number)
            {
                npgSqlConnection.Open();
                int id = madeId("SELECT id FROM people");
                new NpgsqlCommand($"INSERT INTO people (id, name, surname, phone, companyId) VALUES ({id}, {name}, {surname}, {phone}, {companyId})", npgSqlConnection).ExecuteNonQuery();
                new NpgsqlCommand($"INSERT INTO passport (id, type, number) VALUES ({id},{type},{number})", npgSqlConnection).ExecuteNonQuery();
                return id;

            }
            public void Read(int companyId) 
            {
                npgSqlConnection.Open();
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand($"SELECT * FROM people WHERE companyId={companyId}", npgSqlConnection);
                NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                {
                    NpgsqlDataReader dbPassport = new NpgsqlCommand($"SELECT type, number FROM passport WHERE id={dbDataRecord[0]}", npgSqlConnection).ExecuteReader();
                    String record = "";
                    for (int i = 0; i < dbDataRecord.FieldCount; i++)
                    {
                        record += dbDataRecord[i] + " ";
                    }
                    Console.WriteLine(record+dbPassport[0]+" "+dbPassport[1]);
                }
                npgSqlConnection.Close();
            }

            public void update(string json)
            {
                Person person = JsonConvert.DeserializeObject<Person>(json);
                List<Replacements> listReplacements = person.replacements;
                foreach(Replacements replacements in listReplacements)
                {
                    new NpgsqlCommand($"UPDATE people SET {replacements.Name}={replacements.Content} WHERE id={person.id}", npgSqlConnection).ExecuteNonQuery();
                }
            }
            public void Delete(int id)
            {
                npgSqlConnection.Open();
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand($"DELETE FROM people WHERE id='{id}'", npgSqlConnection);
                npgSqlCommand.ExecuteNonQuery();
                npgSqlConnection.Close();
            }
        }
        class Person
        {
            public int id;
            public List<Replacements> replacements { get; set; }
        }
        class Replacements
        {
            public string Name { get; set; }
            public string Content { get; set; }
        }*/