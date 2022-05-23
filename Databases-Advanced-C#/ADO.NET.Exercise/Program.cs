using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADO.NET.Exercise
{
    class Program
    {
        const string SqlConnectionString = "Server=localhost; User Id=sa;Password=@Test123456; Database=MinionsDB";
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(SqlConnectionString))
            {
                connection.Open();

                //ProblemOne();                
                //ProblemTwo();
                //ProblemThree();              
                //ProblemFour();
                //ProblemFive();
                //ProblemSixs();
                //ProblemSeven();
                //ProblemEight();
                //ProblemNine();            

            }
        }

        private static void ProblemNine()
        {
            var connection = new SqlConnection(SqlConnectionString);

            string updateMinionsAgeQuery = @"EXEC usp_GetOlder @id";

            string selectMinionQuery = @"SELECT Name, Age FROM Minions WHERE Id = @Id";

            int id = int.Parse(Console.ReadLine());

            using (var updateCommand = new SqlCommand(updateMinionsAgeQuery, connection))
            {
                updateCommand.Parameters.AddWithValue("@Id", id);
                updateCommand.ExecuteNonQuery();
            }

            using (var command = new SqlCommand(selectMinionQuery, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                var reader = command.ExecuteReader();
                reader.Read();

                Console.WriteLine($"{reader["Name"]} – {reader["Age"]} years old");
            }
        }

        private static void ProblemEight()
        {
            var connection = new SqlConnection(SqlConnectionString);
            int[] input = Console.ReadLine()
                                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToArray();

            string updateMinionsName = @"UPDATE Minions SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1 WHERE Id = @Id";
            string callMinionsQuery = @"SELECT Name, Age FROM Minions";

            foreach (var item in input)
            {
                using (var minionsCommand = new SqlCommand(updateMinionsName, connection))
                {
                    minionsCommand.Parameters.AddWithValue("@Id", item);
                    minionsCommand.ExecuteNonQuery();
                }
            }

            using (var callMinionsCommand = new SqlCommand(callMinionsQuery, connection))
            {
                var reader = callMinionsCommand.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
                }
            }
        }

        private static void ProblemSeven()
        {
            var connection = new SqlConnection(SqlConnectionString);
            string minionsNameQuery = @"SELECT Name FROM Minions";

            List<string> minionsName = new List<string>();

            using (var nameCommand = new SqlCommand(minionsNameQuery, connection))
            {
                var reader = nameCommand.ExecuteReader();

                while (reader.Read())
                {
                    var minionName = reader["Name"];

                    minionsName.Add((string)minionName);
                }
            }

            int evenCount = 0;
            int oddCount = 0;

            for (int i = 0; i < minionsName.Count; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(minionsName[evenCount]);
                    evenCount++;
                }
                else
                {
                    Console.WriteLine(minionsName[minionsName.Count - 1 - oddCount]);
                    oddCount++;
                }
            }
        }

        private static void ProblemSixs()
        {
            var connection = new SqlConnection(SqlConnectionString);

            int input = int.Parse(Console.ReadLine());

            string villainQuery = @"SELECT Name FROM Villains WHERE Id = @villainId";

            string minionsForRelease = @"DELETE FROM MinionsVillains WHERE VillainId = @villainId";

            string vallainForDelete = @"DELETE FROM Villains WHERE Id = @villainId";

            string villainName = string.Empty;

            int result = 0;

            using (var villainCommand = new SqlCommand(villainQuery, connection))
            {
                villainCommand.Parameters.AddWithValue("@villainId", input);
                villainName = (string)villainCommand.ExecuteScalar();
            }

            if (villainName is null)
            {
                Console.WriteLine("No such villain was found.");
            }
            else
            {

                using (var releseMinionsCommand = new SqlCommand(minionsForRelease, connection))
                {
                    releseMinionsCommand.Parameters.AddWithValue("@villainId", input);
                    result = releseMinionsCommand.ExecuteNonQuery();

                }

                using (var deleteVallainsCommand = new SqlCommand(vallainForDelete, connection))
                {
                    deleteVallainsCommand.Parameters.AddWithValue("@villainId", input);
                    deleteVallainsCommand.ExecuteNonQuery();
                }

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{result} minions were released.");
            }
        }

        private static void ProblemFive()
        {
            var connection = new SqlConnection(SqlConnectionString);

            string countryName = Console.ReadLine();

            string selectCountrysQuery = @" SELECT t.Name AS Name
                                          FROM Towns as t
                                          JOIN Countries AS c ON c.Id = t.CountryCode
                                          WHERE c.Name = @countryName";

            string updateCountrysQuert = @"UPDATE Towns
                                             SET Name = UPPER(Name)
                                             WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

            using (var commandUpdate = new SqlCommand(updateCountrysQuert, connection))
            {
                commandUpdate.Parameters.AddWithValue("@countryName", countryName);
                commandUpdate.ExecuteNonQuery();
            }

            using (var command = new SqlCommand(selectCountrysQuery, connection))
            {
                command.Parameters.AddWithValue("@countryName", countryName);

                var reader = command.ExecuteReader();

                List<string> towns = new List<string>();

                while (reader.Read())
                {
                    towns.Add(reader["Name"].ToString());
                }

                if (towns.Count > 0)
                {
                    Console.WriteLine($"{towns.Count} towns are affected.");
                    Console.WriteLine($"[{String.Join(", ", towns)}]");
                }
                else
                {
                    Console.WriteLine("No town names were affected.");
                }

            }

        }

        private static int? GetMinionId(SqlConnection connection, string minionName)
        {
            var minionIdQuery = "SELECT Id FROM Minions WHERE Name = @Name";
            using var commandMinion = new SqlCommand(minionIdQuery, connection);
            commandMinion.Parameters.AddWithValue("@Name", minionName);
            var minionId = commandMinion.ExecuteScalar();

            return (int?)minionId;

        }

        private static int? CreateMinion (SqlConnection connection, string minionName, int age, int? townId)
        {
            string createMinion = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
            using var commandMinion = new SqlCommand(createMinion, connection);
            commandMinion.Parameters.AddWithValue("@name", minionName);
            commandMinion.Parameters.AddWithValue("@age", age);
            commandMinion.Parameters.AddWithValue("@townId", townId);
            var result = commandMinion.ExecuteScalar();

            return (int?)result;

        }

        private static int? GetVillianId(SqlConnection connection, string villainName)
        {
            string villainQuery = @"SELECT Id FROM Villains WHERE Name = @Name";
            using var command = new SqlCommand(villainQuery, connection);

            command.Parameters.AddWithValue("@Name", villainName);
            var villainId = command.ExecuteScalar();

            return (int?)villainId;
        }

        private static int? GetTownId(SqlConnection connection,string town )
        {
            string townId = "SELECT Id FROM Towns WHERE Name = @townName";
            using var sqlCommand = new SqlCommand(townId, connection);
            sqlCommand.Parameters.AddWithValue("@townName", town);
            var result = sqlCommand.ExecuteScalar();

            return (int?)result;
        }

        private static void ProblemFour()
        {
            var connection = new SqlConnection(SqlConnectionString);
            string[] minionInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] villainInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string minionName = minionInput[1];
            int age = int.Parse(minionInput[2]);
            string minionTown = minionInput[3];

            string villainName = villainInput[1];

            int? townId = GetTownId(connection, minionTown);

            if (townId == null)
            {
                string createTown = "INSERT INTO Towns (Name) VALUES (@townName)";
                using var commandCreateTown = new SqlCommand(createTown, connection);
                commandCreateTown.Parameters.AddWithValue("@townName", minionTown);
                Console.WriteLine($"Town <{minionTown}> was added to the database.");
            }


            int? villianId = GetVillianId(connection, villainName);

            if (villianId is null)
            {
                string createVillain = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";
                using var commandVilllain = new SqlCommand(createVillain, connection);
                commandVilllain.Parameters.AddWithValue("@villainName", villainName);
                Console.WriteLine($"Villain <{villainName}> was added to the database.&quot;");
            }

            CreateMinion(connection, minionName, age, townId);

            var minionId = GetMinionId(connection, minionName);

            var insertToMinionVillain = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";
            var sqlCommand = new SqlCommand(insertToMinionVillain, connection);
            sqlCommand.Parameters.AddWithValue("@minionId", minionId);
            sqlCommand.Parameters.AddWithValue("@villainId", villianId);

            sqlCommand.ExecuteNonQuery();

            Console.WriteLine($"Successfully added <{minionName}> to be minion of <{villainName}>");
        }

        private static object ExecuteDBScalar (SqlConnection connection, string item)
        {
            using var command = new SqlCommand(item, connection);           
            var result = command.ExecuteScalar();
            return result;            
        }

        private static void ProblemThree()
        {
            var connection = new SqlConnection(SqlConnectionString);

            int currId = int.Parse(Console.ReadLine());

            string currState = "SELECT Name FROM Villains WHERE Id = @Id";

            using var command = new SqlCommand(currState, connection);
            command.Parameters.AddWithValue("@Id", currId);

            var name = command.ExecuteScalar();

            string currMinions = @"SELECT ROW_NUMBER() OVER(ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

            using var commandForMinions = new SqlCommand(currMinions, connection);
            commandForMinions.Parameters.AddWithValue("@Id", currId);

            if (name is null)
            {
                Console.WriteLine($"No villain with ID {currId} exists in the database.");
            }
            else
            {
                Console.WriteLine($"Villain: {name}");

                using (var reader = commandForMinions.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        if (!reader.HasRows)
                        {
                            Console.WriteLine("(no minions)");
                        }
                        else
                        {
                            Console.WriteLine($"{reader[0]}. {reader[1]} {reader[2]}");
                        }

                    }
                }

            }
        }

        private static void ProblemTwo()
        {
            var connection = new SqlConnection(SqlConnectionString);
            string selectFromDB = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                                        FROM Villains AS v
                                        JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                                        GROUP BY v.Id, v.Name                                        
                                        ORDER BY COUNT(mv.VillainId)";

            using (var command = new SqlCommand(selectFromDB, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader[0];
                        var count = reader[1];

                        Console.WriteLine($"{name} - {count}");
                    }
                }
            }
        }

        private static void ProblemOne()
        {
            var connection = new SqlConnection(SqlConnectionString);
            string createDataBase = "CREATE DATABASE MinionsDB";

            ExecuteNonQueryMethod(connection, createDataBase);


            var createStatment = GetCreateStatment();

            foreach (var item in createStatment)
            {
                ExecuteNonQueryMethod(connection, item);
            };

            var insertStatment = GetInsertStatment();

            foreach (var item in insertStatment)
            {
                ExecuteNonQueryMethod(connection, item);
            }
        }

        private static string[] GetInsertStatment()
        {
            var result = new string[]
            {
                "INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')",
                "INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)",
                "INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)",
                "INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')",
                "INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)",
                "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)"
            };

            return result;
        }

        private static void ExecuteNonQueryMethod(SqlConnection connection, string item)
        {
            using (var command = new SqlCommand(item, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        private static string[] GetCreateStatment()
        {
            var result = new string[]
            {
                "CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))",
                "CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))",
                "CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))",
                "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))",
                "CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))",
                "CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))",
            };
            return result;
        }
    }    
}
