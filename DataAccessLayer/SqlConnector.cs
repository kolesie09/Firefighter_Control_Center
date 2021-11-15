using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FirefighterControlCenter.DataAccessLayer
{
    public class SqlConnector
    {
        public static List<Firefighter_ranking> Ranking()
        {
            var list = new List<Firefighter_ranking>();
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                const string sqlquery = "SELECT city.Name_City, street.Name_Street, street_ranking.Year, street_ranking.Number_departures FROM city, street, street_ranking WHERE city.ID=street.ID AND street.ID=street_ranking.ID_Street";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Firefighter_ranking firefighter = new Firefighter_ranking
                        {
                            //Id = int.Parse(reader["id_departure_ranking"].ToString()),
                            Imie = reader["name"].ToString(),
                            Naziwsko = reader["last_name"].ToString(),
                            Nazwa_miasta = reader["Name_City"].ToString(),
                            Nazwa_ulicy = reader["Name_Street"].ToString(),
                            Rok = int.Parse(reader["Year"].ToString()),
                            Ilosc_wyjazdow = int.Parse(reader["Number_departures"].ToString())
                            
                        };
                        list.Add(firefighter);
                    }
                }
                cnn.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            return list;
        }

        public static int SelectNumberDeparture()
        {
            int LastNumberDeparture = 0;
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {
                
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                const string sqlquery = "SELECT MAX(Departure_number) FROM departure_card";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                    
                        LastNumberDeparture = int.Parse(reader["MAX(Departure_number)"].ToString());
                    
                    
                        
                    
                }
                cnn.Close();
            }
            catch (Exception e)
            {
                
            }
            return LastNumberDeparture;
        }

        public static List<string> SelectDateDepartureCard(string TypeSelect, string x)
        {
            var list = new List<string>();
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                if (TypeSelect == "City")
                {
                    const string sqlquery = "SELECT Name_City FROM city";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            list.Add(reader["Name_City"].ToString());
                        }
                    }
                }
                else if(TypeSelect == "Street")
                {
                    string sqlquery =("SELECT Name_Street FROM street, city WHERE city.ID_city=street.ID_City AND city.Name_City='" + x + "'");
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            list.Add(reader["Name_Street"].ToString());
                        }
                    }
                }
                else if(TypeSelect == "TypeIncident")
                {
                    const string sqlquery = "SELECT Name FROM incident_type";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            list.Add(reader["Name"].ToString());
                        }
                    }
                }
                else if(TypeSelect == "Incident")
                {
                    string sqlquery = ("SELECT incident.Name FROM incident_type, incident WHERE incident_type.ID=incident.ID_Incident_Type AND incident_type.Name='"+x+"'");
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            list.Add(reader["Name"].ToString());
                        }
                    }
                }

                
                cnn.Close();
                
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            return list;
        }

        public static List<string> SelectFirefighterDepartureCard(string TypeSelect, string x)
        {
            var list = new List<string>();
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                if (TypeSelect == "DriverC")
                {
                    const string sqlquery = "SELECT nick FROM firefighter, firefighter_status WHERE firefighter.ID_Status=firefighter_status.ID_firefighter_status AND firefighter_status.Name='Czynny' AND firefighter.Kat_C=1;";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            list.Add(reader["Nick"].ToString());
                        }
                    }
                }
                else if (TypeSelect == "DriverB")
                {
                    const string sqlquery = "SELECT nick FROM firefighter, firefighter_status WHERE firefighter.ID_Status=firefighter_status.ID_firefighter_status AND firefighter_status.Name='Czynny' AND firefighter.Kat_B=1;";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            list.Add(reader["Nick"].ToString());
                        }
                    }
                }
                else if (TypeSelect == "Firefighter")
                {
                    const string sqlquery = "SELECT nick FROM firefighter, firefighter_status WHERE firefighter.ID_Status=firefighter_status.ID_firefighter_status AND firefighter_status.Name='Czynny';";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            list.Add(reader["Nick"].ToString());
                        }
                    }
                }


                cnn.Close();

            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            return list;
        }

        public static void InsertFirefighterToTruck(string number_operation, string driver, string commander, string firefighter1, string firefighter2, string firefighter3, string firefighter4)
        {
            
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {
                string sqlquery = "";
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                if (number_operation == "499z01")
                {
                    sqlquery = "INSERT INTO `499z01_departure` (`ID`, `Nick_Driver`, `Nick_Commander`, `Nick_Firefighter_1`, `Nick_Firefighter_2`, `Nick_Firefighter_3`, `Nick_Firefighter_4`) VALUES (NULL, '" + driver + "', '" + commander + "', '" + firefighter1 + "', '" + firefighter2 + "', '" + firefighter3 + "', '" + firefighter4 + "');";
                }
                else if (number_operation == "499z15")
                {
                    sqlquery = "INSERT INTO `499z15_departure` (`ID`, `Nick_Driver`, `Nick_Commander`, `Nick_Firefighter_1`, `Nick_Firefighter_2`, `Nick_Firefighter_3`, `Nick_Firefighter_4`) VALUES (NULL, '" + driver + "', '" + commander + "', '" + firefighter1 + "', '" + firefighter2 + "', '" + firefighter3 + "', '" + firefighter4 + "');";
                }
                else if (number_operation == "499z18")
                {
                    sqlquery = "INSERT INTO `499z18_departure` (`ID`, `Nick_Driver`, `Nick_Commander`, `Nick_Firefighter_1`, `Nick_Firefighter_2`, `Nick_Firefighter_3`) VALUES (NULL, '" + driver + "', '" + commander + "', '" + firefighter1 + "', '" + firefighter2 + "', '" + firefighter3 + "');";
                   
                }
                else if (number_operation == "499z19")
                {
                    sqlquery = "INSERT INTO `499z19_departure` (`ID`, `Nick_Driver`, `Nick_Commander`, `Nick_Firefighter_1`, `Nick_Firefighter_2`, `Nick_Firefighter_3`, `Nick_Firefighter_4`) VALUES (NULL, '" + driver + "', '" + commander + "', '" + firefighter1 + "', '" + firefighter2 + "', '" + firefighter3 + "', '" + firefighter4 + "');";
                    
                }
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                    
                    
                    
                   

                }

                cnn.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("Coś poszło nie tak z zapisywaniem danych obsady\r\n Błąd informacyjny dla administratora aplikacji:\r\n\r\n\r\n" + e);
                
            }
            
        }

        public static int SelectIDTruck(string number_operation, string driver, string commander, string firefighter1, string firefighter2, string firefighter3, string firefighter4)
        {
            int IDTruck = 0;
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {

                string sqlquery = "";
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                if (number_operation == "499z01")
                {
                    sqlquery = "SELECT MAX(ID) FROM 499z01_departure WHERE Nick_Driver = '"+driver+"' AND Nick_Commander = '"+commander+"' AND Nick_Firefighter_1 = '" + firefighter1 + "' AND Nick_Firefighter_2 = '"+firefighter2+"' AND Nick_Firefighter_3 = '" + firefighter3 + "' AND Nick_Firefighter_4 = '" + firefighter4 + "';";
                }
                else if (number_operation == "499z15")
                {
                    sqlquery = "SELECT MAX(ID) FROM 499z15_departure WHERE Nick_Driver = '" + driver + "' AND Nick_Commander = '" + commander + "' AND Nick_Firefighter_1 = '" + firefighter1 + "' AND Nick_Firefighter_2 = '" + firefighter2 + "' AND Nick_Firefighter_3 = '" + firefighter3 + "' AND Nick_Firefighter_4 = '" + firefighter4 + "';";
                }
                else if (number_operation == "499z18")
                {
                    sqlquery = "SELECT MAX(ID) FROM 499z18_departure WHERE Nick_Driver = '" + driver + "' AND Nick_Commander = '" + commander + "' AND Nick_Firefighter_1 = '" + firefighter1 + "' AND Nick_Firefighter_2 = '" + firefighter2 + "' AND Nick_Firefighter_3 = '" + firefighter3 + "';";

                }
                else if (number_operation == "499z19")
                {
                    sqlquery = "SELECT MAX(ID) FROM 499z19_departure WHERE Nick_Driver = '" + driver + "' AND Nick_Commander = '" + commander + "' AND Nick_Firefighter_1 = '" + firefighter1 + "' AND Nick_Firefighter_2 = '" + firefighter2 + "' AND Nick_Firefighter_3 = '" + firefighter3 + "' AND Nick_Firefighter_4 = '" + firefighter4 + "';";

                }
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();

                    reader.Read();
                    
                        IDTruck = int.Parse(reader["MAX(ID)"].ToString());
                    
                    
                }

                cnn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Coś poszło nie tak z zapisywaniem danych obsady\r\n Błąd informacyjny dla administratora aplikacji:\r\n\r\n\r\n" + e);
            }
            return IDTruck;
        }

        public static void InsertDateDepartureCard(int departure_number, string departure_date, string Hour_departure, string Hour_arrival, int ID_place_departure, int ID_reason_departure, int ID_Departure_commander, int ID_499z01, int ID_499z15, int ID_499z18, int ID_499z19, int Year)
        {
            
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {
                string sqlquery = "";
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                
                    sqlquery = "INSERT INTO `departure_card` (`ID_departure_card`, `Departure_number`, `Departure_date`, `Hour_departure`, `Hour_arrival`, `ID_place_departure`, `ID_reason_departure`, `ID_Departure_commander`, `ID_499z01`, `ID_499z15`, `ID_499z18`, `ID_499z19`, `Year`) VALUES (NULL, '" + departure_number + "', '" + departure_date + "', '" + Hour_departure + "', '" + Hour_arrival + "', '" + ID_place_departure + "', '" + ID_reason_departure + "', '" + ID_Departure_commander + "', '" + ID_499z01 + "', '" + ID_499z15 + "', '" + ID_499z18 + "', '" + ID_499z19 + "', '" + Year + "');";
                
                
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                    
                    
                    
                   

                }

                cnn.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("Coś poszło nie tak z zapisywaniem danych obsady\r\n Błąd informacyjny dla administratora aplikacji:\r\n\r\n\r\n" + e);
                
            }
            
        }
    }
    
}