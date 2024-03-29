﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FirefighterControlCenter.DataAccessLayer
{
    public class SqlConnector
    {
        public static List<Firefighter_ranking> RankingFirefighter(string Year)
        {
            var list = new List<Firefighter_ranking>();
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {
               
                    cnn = new MySqlConnection(connectionString);
                    cnn.Open();
                    string sqlquery = "SELECT firefighter.name, firefighter.last_name, firefighter_ranking.Number_departures, firefighter_ranking.Year FROM firefighter, firefighter_ranking WHERE firefighter.ID_firefighter = firefighter_ranking.ID_firefighter AND firefighter_ranking.Year ="+Year+" ORDER BY firefighter_ranking.Number_departures DESC;";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                        Firefighter_ranking firefighter = new Firefighter_ranking
                        {

                            Imie = reader["name"].ToString(),
                            Naziwsko = reader["last_name"].ToString(),
                            Rok = int.Parse(reader["Year"].ToString()),
                            Ilosc_wyjazdow = int.Parse(reader["Number_departures"].ToString()),
                            Procentowo = Math.Round(double.Parse(reader["Number_departures"].ToString()) / SelectNumberDeparture(int.Parse(reader["Year"].ToString())) * 100,2).ToString()+"%"


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
        public static List<Ranking> Ranking(string type, string Year)
        {
            var list = new List<Ranking>();
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {
                if(type == "city")
                {
                    cnn = new MySqlConnection(connectionString);
                    cnn.Open();
                    string sqlquery = "SELECT " + type + ".Name_" + type + ", " + type + "_ranking.Year, " + type + "_ranking.Number_departures FROM " + type + ", " + type + "_ranking WHERE " + type + ".ID_" + type + " = " + type + "_ranking.ID_" + type + " AND " + type + "_ranking.Year = " + Year + " ORDER BY " + type + "_ranking.Number_departures DESC;";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Ranking ranking = new Ranking
                            {


                                Nazwa = reader["Name_"+type].ToString(),
                                Rok = int.Parse(reader["Year"].ToString()),
                                Ilosc_wyjazdow = int.Parse(reader["Number_departures"].ToString())

                            };
                            list.Add(ranking);
                        }
                    }
                    cnn.Close();
                }
                else
                {
                    cnn = new MySqlConnection(connectionString);
                    cnn.Open();
                    string test = "";
                    string sqlquery = "SELECT " + type + ".Name, " + type + "_ranking.Year, " + type + "_ranking.Number_departures FROM " + type + ", " + type + "_ranking WHERE " + type + ".ID_" + type + " = " + type + "_ranking.ID_" + type + " AND " + type + "_ranking.Year = " + Year + " ORDER BY " + type + "_ranking.Number_departures DESC;";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Ranking ranking = new Ranking
                            {
                                Nazwa = reader["Name"].ToString(),
                                Rok = int.Parse(reader["Year"].ToString()),
                                Ilosc_wyjazdow = int.Parse(reader["Number_departures"].ToString())
                            };
                            test = reader["Name"].ToString();
                            
                                list.Add(ranking);
                            

                            
                        }
                    }
                    cnn.Close();
                }
                    
                
                
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            return list;
        }
        public static List<Ranking_City> RankingStreet(string type, string Year)
        {
            var list = new List<Ranking_City>();
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {
                
                    cnn = new MySqlConnection(connectionString);
                    cnn.Open();
                    string sqlquery = "SELECT " + type + ".Name_" + type + ", city.Name_city, " + type + "_ranking.Year, " + type + "_ranking.Number_departures FROM " + type + ", " + type + "_ranking, city WHERE " + type + ".ID_" + type + " = " + type + "_ranking.ID_" + type + " AND city.ID_city = " + type + ".ID_City AND " + type + "_ranking.Year = " + Year + " ORDER BY " + type + "_ranking.Number_departures DESC;";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                      var reader = command.ExecuteReader();
                        while (reader.Read())
                        {

                            Ranking_City ranking = new Ranking_City
                            {


                                Nazwa_miasta = reader["Name_city"].ToString(),
                                Nazwa_ulicy = reader["Name_" + type].ToString(),
                                Rok = int.Parse(reader["Year"].ToString()),
                                Ilosc_wyjazdow = int.Parse(reader["Number_departures"].ToString())

                            };
                            list.Add(ranking);
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
        public static List<History_departure_cards> History_departure_cards()
        {
            var list = new List<History_departure_cards>();
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {
                
                    cnn = new MySqlConnection(connectionString);
                    cnn.Open();
                    string sqlquery = "SELECT departure_card.Departure_number, departure_card.Departure_date, departure_card.Hour_departure, departure_card.Hour_arrival, city.Name_city, street.Name_street, incident.Name, firefighter.Nick, 499z01_departure.Nick_Driver_01, 499z01_departure.Nick_Commander_01, 499z01_departure.Nick_Firefighter_01_1, 499z01_departure.Nick_Firefighter_01_2, 499z01_departure.Nick_Firefighter_01_3, 499z01_departure.Nick_Firefighter_01_4, 499z15_departure.Nick_Driver_15, 499z15_departure.Nick_Commander_15, 499z15_departure.Nick_Firefighter_15_1, 499z15_departure.Nick_Firefighter_15_2, 499z15_departure.Nick_Firefighter_15_3, 499z15_departure.Nick_Firefighter_15_4, 499z18_departure.Nick_Driver_18, 499z18_departure.Nick_Commander_18, 499z18_departure.Nick_Firefighter_18_1, 499z18_departure.Nick_Firefighter_18_2, 499z18_departure.Nick_Firefighter_18_3, 499z19_departure.Nick_Driver_19, 499z19_departure.Nick_Commander_19, 499z19_departure.Nick_Firefighter_19_1, 499z19_departure.Nick_Firefighter_19_2, 499z19_departure.Nick_Firefighter_19_3, 499z19_departure.Nick_Firefighter_19_4, departure_card.Hour FROM departure_card, firefighter, place, city, street, incident, 499z01_departure, 499z15_departure, 499z18_departure, 499z19_departure WHERE departure_card.ID_499z01 = 499z01_departure.ID AND departure_card.ID_499z15 = 499z15_departure.ID AND departure_card.ID_499z18 = 499z18_departure.ID AND departure_card.ID_499z19 = 499z19_departure.ID AND departure_card.ID_place_departure = place.ID_place AND place.ID_City = city.ID_city AND place.ID_Street = street.ID_street AND departure_card.ID_reason_departure = incident.ID_incident AND departure_card.ID_Departure_commander = firefighter.ID_firefighter ORDER BY departure_card.Year DESC, departure_card.Departure_number DESC;";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                      var reader = command.ExecuteReader();
                        while (reader.Read())
                        {

                            History_departure_cards History = new History_departure_cards
                            {

                                Numer = int.Parse(reader["Departure_number"].ToString()),
                                Data = reader["Departure_date"].ToString(),
                                Wyjazd = reader["Hour_departure"].ToString(),
                                Przyjazd = reader["Hour_arrival"].ToString(),
                                Miasto = reader["Name_city"].ToString(),
                                Ulica = reader["Name_street"].ToString(),
                                Powod = reader["Name"].ToString(),
                                Dowodca = reader["Nick"].ToString(),
                                Kierowca_01 = reader["Nick_Driver_01"].ToString(),
                                Dowodca_01 = reader["Nick_Commander_01"].ToString(),
                                Strazak_01_1 = reader["Nick_Firefighter_01_1"].ToString(),
                                Strazak_01_2 = reader["Nick_Firefighter_01_2"].ToString(),
                                Strazak_01_3 = reader["Nick_Firefighter_01_3"].ToString(),
                                Strazak_01_4 = reader["Nick_Firefighter_01_4"].ToString(),
                                Kierowca_15 = reader["Nick_Driver_15"].ToString(),
                                Dowodca_15 = reader["Nick_Commander_15"].ToString(),
                                Strazak_15_1 = reader["Nick_Firefighter_15_1"].ToString(),
                                Strazak_15_2 = reader["Nick_Firefighter_15_2"].ToString(),
                                Strazak_15_3 = reader["Nick_Firefighter_15_3"].ToString(),
                                Strazak_15_4 = reader["Nick_Firefighter_15_4"].ToString(),
                                Kierowca_18 = reader["Nick_Driver_18"].ToString(),
                                Dowodca_18 = reader["Nick_Commander_18"].ToString(),
                                Strazak_18_1 = reader["Nick_Firefighter_18_1"].ToString(),
                                Strazak_18_2 = reader["Nick_Firefighter_18_2"].ToString(),
                                Strazak_18_3 = reader["Nick_Firefighter_18_3"].ToString(),
                                Kierowca_19 = reader["Nick_Driver_19"].ToString(),
                                Dowodca_19 = reader["Nick_Commander_19"].ToString(),
                                Strazak_19_1 = reader["Nick_Firefighter_19_1"].ToString(),
                                Strazak_19_2 = reader["Nick_Firefighter_19_2"].ToString(),
                                Strazak_19_3 = reader["Nick_Firefighter_19_3"].ToString(),
                                Strazak_19_4 = reader["Nick_Firefighter_19_4"].ToString(),
                                Godziny = reader["Hour"].ToString()



                            };
                            list.Add(History);
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

        public static int FirstYear()
        {

            int First = 0;
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "SELECT MIN(Year) FROM departure_card;";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();

                    First = int.Parse(reader["MIN(Year)"].ToString());
                }
                cnn.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            return First;
        }
        public static int SelectNumberDeparture(int Year)
        {
            int LastNumberDeparture = 0;
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {
                
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "SELECT MAX(Departure_number) FROM departure_card WHERE departure_card.Year = '" + Year + "';";
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
                Console.Write(e.Message);
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
                    const string sqlquery = "SELECT Name_City FROM city ORDER BY Name_City ASC;";
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
                    string sqlquery =("SELECT Name_Street FROM street, city WHERE city.ID_city=street.ID_City AND city.Name_City='" + x + "' ORDER BY Name_Street ASC;");
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            if(reader["Name_Street"].ToString() != "")
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
                    string sqlquery = ("SELECT incident.Name FROM incident_type, incident WHERE incident_type.ID=incident.ID_Incident_Type AND incident_type.Name='"+x+ "' ORDER BY incident.Name ASC;");
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["Name"].ToString() != "")
                            {
                                list.Add(reader["Name"].ToString());
                            }
                            
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
                    const string sqlquery = "SELECT nick FROM firefighter, firefighter_status WHERE firefighter.ID_Status=firefighter_status.ID_firefighter_status AND firefighter_status.Name='Czynny' AND firefighter.Kat_C=1 ORDER BY nick ASC;";
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
                    const string sqlquery = "SELECT nick FROM firefighter, firefighter_status WHERE firefighter.ID_Status=firefighter_status.ID_firefighter_status AND firefighter_status.Name='Czynny' AND firefighter.Kat_B=1 ORDER BY nick ASC;";
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
                    const string sqlquery = "SELECT nick FROM firefighter, firefighter_status WHERE firefighter.ID_Status=firefighter_status.ID_firefighter_status AND firefighter_status.Name='Czynny' ORDER BY nick ASC;";
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
                    sqlquery = "INSERT INTO `499z01_departure` (`ID`, `Nick_Driver_01`, `Nick_Commander_01`, `Nick_Firefighter_01_1`, `Nick_Firefighter_01_2`, `Nick_Firefighter_01_3`, `Nick_Firefighter_01_4`) VALUES (NULL, '" + driver + "', '" + commander + "', '" + firefighter1 + "', '" + firefighter2 + "', '" + firefighter3 + "', '" + firefighter4 + "');";
                }
                else if (number_operation == "499z15")
                {
                    sqlquery = "INSERT INTO `499z15_departure` (`ID`, `Nick_Driver_15`, `Nick_Commander_15`, `Nick_Firefighter_15_1`, `Nick_Firefighter_15_2`, `Nick_Firefighter_15_3`, `Nick_Firefighter_15_4`) VALUES (NULL, '" + driver + "', '" + commander + "', '" + firefighter1 + "', '" + firefighter2 + "', '" + firefighter3 + "', '" + firefighter4 + "');";
                }
                else if (number_operation == "499z18")
                {
                    sqlquery = "INSERT INTO `499z18_departure` (`ID`, `Nick_Driver_18`, `Nick_Commander_18`, `Nick_Firefighter_18_1`, `Nick_Firefighter_18_2`, `Nick_Firefighter_18_3`) VALUES (NULL, '" + driver + "', '" + commander + "', '" + firefighter1 + "', '" + firefighter2 + "', '" + firefighter3 + "');";
                   
                }
                else if (number_operation == "499z19")
                {
                    sqlquery = "INSERT INTO `499z19_departure` (`ID`, `Nick_Driver_19`, `Nick_Commander_19`, `Nick_Firefighter_19_1`, `Nick_Firefighter_19_2`, `Nick_Firefighter_19_3`, `Nick_Firefighter_19_4`) VALUES (NULL, '" + driver + "', '" + commander + "', '" + firefighter1 + "', '" + firefighter2 + "', '" + firefighter3 + "', '" + firefighter4 + "');";
                    
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
                    sqlquery = "SELECT MAX(ID) FROM 499z01_departure WHERE Nick_Driver_01 = '" + driver+ "' AND Nick_Commander_01 = '" + commander+ "' AND Nick_Firefighter_01_1 = '" + firefighter1 + "' AND Nick_Firefighter_01_2 = '" + firefighter2+ "' AND Nick_Firefighter_01_3 = '" + firefighter3 + "' AND Nick_Firefighter_01_4 = '" + firefighter4 + "';";
                }
                else if (number_operation == "499z15")
                {
                    sqlquery = "SELECT MAX(ID) FROM 499z15_departure WHERE Nick_Driver_15 = '" + driver + "' AND Nick_Commander_15 = '" + commander + "' AND Nick_Firefighter_15_1 = '" + firefighter1 + "' AND Nick_Firefighter_15_2 = '" + firefighter2 + "' AND Nick_Firefighter_15_3 = '" + firefighter3 + "' AND Nick_Firefighter_15_4 = '" + firefighter4 + "';";
                }
                else if (number_operation == "499z18")
                {
                    sqlquery = "SELECT MAX(ID) FROM 499z18_departure WHERE Nick_Driver_18 = '" + driver + "' AND Nick_Commander_18 = '" + commander + "' AND Nick_Firefighter_18_1 = '" + firefighter1 + "' AND Nick_Firefighter_18_2 = '" + firefighter2 + "' AND Nick_Firefighter_18_3 = '" + firefighter3 + "';";

                }
                else if (number_operation == "499z19")
                {
                    sqlquery = "SELECT MAX(ID) FROM 499z19_departure WHERE Nick_Driver_19 = '" + driver + "' AND Nick_Commander_19 = '" + commander + "' AND Nick_Firefighter_19_1 = '" + firefighter1 + "' AND Nick_Firefighter_19_2 = '" + firefighter2 + "' AND Nick_Firefighter_19_3 = '" + firefighter3 + "' AND Nick_Firefighter_19_4 = '" + firefighter4 + "';";

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

        public static void InsertDateDepartureCard(int departure_number, string departure_date, string Hour_departure, string Hour_arrival, int ID_place_departure, int ID_reason_departure, int ID_Departure_commander, int ID_499z01, int ID_499z15, int ID_499z18, int ID_499z19, int Year, int Mounth, string Hour)
        {

            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {
                string sqlquery = "";
                cnn = new MySqlConnection(connectionString);
                cnn.Open();

                if (ID_499z01 != 0)
                {
                    if (ID_499z15 != 0)
                    {
                        if (ID_499z18 != 0)
                        {
                            if (ID_499z19 != 0)
                            {
                                sqlquery = "INSERT INTO `departure_card` (`ID_departure_card`, `Departure_number`, `Departure_date`, `Hour_departure`, `Hour_arrival`, `ID_place_departure`, `ID_reason_departure`, `ID_Departure_commander`, `ID_499z01`, `ID_499z15`, `ID_499z18`, `ID_499z19`, `Year`, `Mounth`, `Hour`) VALUES (NULL, '" + departure_number + "', '" + departure_date + "', '" + Hour_departure + "', '" + Hour_arrival + "', '" + ID_place_departure + "', '" + ID_reason_departure + "', '" + ID_Departure_commander + "', '" + ID_499z01 + "', '" + ID_499z15 + "', '" + ID_499z18 + "', '" + ID_499z19 + "', '" + Year + "', '" + Mounth + "', '" + Hour + "');";
                            }
                            else
                            {
                                sqlquery = "INSERT INTO `departure_card` (`ID_departure_card`, `Departure_number`, `Departure_date`, `Hour_departure`, `Hour_arrival`, `ID_place_departure`, `ID_reason_departure`, `ID_Departure_commander`, `ID_499z01`, `ID_499z15`, `ID_499z18`, `ID_499z19`, `Year`, `Mounth`, `Hour`) VALUES (NULL, '" + departure_number + "', '" + departure_date + "', '" + Hour_departure + "', '" + Hour_arrival + "', '" + ID_place_departure + "', '" + ID_reason_departure + "', '" + ID_Departure_commander + "', '" + ID_499z01 + "', '" + ID_499z15 + "', '" + ID_499z18 + "', 1 , '" + Year + "', '" + Mounth + "', '" + Hour + "');";
                            }
                        }
                        else if (ID_499z19 != 0)
                        {
                            sqlquery = "INSERT INTO `departure_card` (`ID_departure_card`, `Departure_number`, `Departure_date`, `Hour_departure`, `Hour_arrival`, `ID_place_departure`, `ID_reason_departure`, `ID_Departure_commander`, `ID_499z01`, `ID_499z15`, `ID_499z18`, `ID_499z19`, `Year`, `Mounth`, `Hour`) VALUES (NULL, '" + departure_number + "', '" + departure_date + "', '" + Hour_departure + "', '" + Hour_arrival + "', '" + ID_place_departure + "', '" + ID_reason_departure + "', '" + ID_Departure_commander + "', '" + ID_499z01 + "', '" + ID_499z15 + "', 1 , '" + ID_499z19 + "', '" + Year + "', '" + Mounth + "', '" + Hour + "');";
                        }
                        else
                        {
                            sqlquery = "INSERT INTO `departure_card` (`ID_departure_card`, `Departure_number`, `Departure_date`, `Hour_departure`, `Hour_arrival`, `ID_place_departure`, `ID_reason_departure`, `ID_Departure_commander`, `ID_499z01`, `ID_499z15`, `ID_499z18`, `ID_499z19`, `Year`, `Mounth`, `Hour`) VALUES (NULL, '" + departure_number + "', '" + departure_date + "', '" + Hour_departure + "', '" + Hour_arrival + "', '" + ID_place_departure + "', '" + ID_reason_departure + "', '" + ID_Departure_commander + "', '" + ID_499z01 + "', '" + ID_499z15 + "', 1 , 1 , '" + Year + "', '" + Mounth + "', '" + Hour + "');";
                        }
                    }
                    else if (ID_499z18 != 0)
                    {
                        if (ID_499z19 != 0)
                        {
                            sqlquery = "INSERT INTO `departure_card` (`ID_departure_card`, `Departure_number`, `Departure_date`, `Hour_departure`, `Hour_arrival`, `ID_place_departure`, `ID_reason_departure`, `ID_Departure_commander`, `ID_499z01`, `ID_499z15`, `ID_499z18`, `ID_499z19`, `Year`, `Mounth`, `Hour`) VALUES (NULL, '" + departure_number + "', '" + departure_date + "', '" + Hour_departure + "', '" + Hour_arrival + "', '" + ID_place_departure + "', '" + ID_reason_departure + "', '" + ID_Departure_commander + "', '" + ID_499z01 + "', 1 , '" + ID_499z18 + "', '" + ID_499z19 + "', '" + Year + "', '" + Mounth + "', '" + Hour + "');";
                        }
                        else
                        {
                            sqlquery = "INSERT INTO `departure_card` (`ID_departure_card`, `Departure_number`, `Departure_date`, `Hour_departure`, `Hour_arrival`, `ID_place_departure`, `ID_reason_departure`, `ID_Departure_commander`, `ID_499z01`, `ID_499z15`, `ID_499z18`, `ID_499z19`, `Year`, `Mounth`, `Hour`) VALUES (NULL, '" + departure_number + "', '" + departure_date + "', '" + Hour_departure + "', '" + Hour_arrival + "', '" + ID_place_departure + "', '" + ID_reason_departure + "', '" + ID_Departure_commander + "', '" + ID_499z01 + "', 1 , '" + ID_499z18 + "', 1 , '" + Year + "', '" + Mounth + "', '" + Hour + "');";
                        }
                    }
                    else if (ID_499z19 != 0)
                    {
                        sqlquery = "INSERT INTO `departure_card` (`ID_departure_card`, `Departure_number`, `Departure_date`, `Hour_departure`, `Hour_arrival`, `ID_place_departure`, `ID_reason_departure`, `ID_Departure_commander`, `ID_499z01`, `ID_499z15`, `ID_499z18`, `ID_499z19`, `Year`, `Mounth`, `Hour`) VALUES (NULL, '" + departure_number + "', '" + departure_date + "', '" + Hour_departure + "', '" + Hour_arrival + "', '" + ID_place_departure + "', '" + ID_reason_departure + "', '" + ID_Departure_commander + "', '" + ID_499z01 + "', 1 , 1 , '" + ID_499z19 + "', '" + Year + "', '" + Mounth + "', '" + Hour + "');";
                    }
                    else
                    {
                        sqlquery = "INSERT INTO `departure_card` (`ID_departure_card`, `Departure_number`, `Departure_date`, `Hour_departure`, `Hour_arrival`, `ID_place_departure`, `ID_reason_departure`, `ID_Departure_commander`, `ID_499z01`, `ID_499z15`, `ID_499z18`, `ID_499z19`, `Year`, `Mounth`, `Hour`) VALUES (NULL, '" + departure_number + "', '" + departure_date + "', '" + Hour_departure + "', '" + Hour_arrival + "', '" + ID_place_departure + "', '" + ID_reason_departure + "', '" + ID_Departure_commander + "', '" + ID_499z01 + "', 1 , 1 , 1 , '" + Year + "', '" + Mounth + "', '" + Hour + "');";
                    }
                }
                else if (ID_499z15 != 0)
                {
                    if (ID_499z18 != 0)
                    {
                        if (ID_499z19 != 0)
                        {
                            sqlquery = "INSERT INTO `departure_card` (`ID_departure_card`, `Departure_number`, `Departure_date`, `Hour_departure`, `Hour_arrival`, `ID_place_departure`, `ID_reason_departure`, `ID_Departure_commander`, `ID_499z01`, `ID_499z15`, `ID_499z18`, `ID_499z19`, `Year`, `Mounth`, `Hour`) VALUES (NULL, '" + departure_number + "', '" + departure_date + "', '" + Hour_departure + "', '" + Hour_arrival + "', '" + ID_place_departure + "', '" + ID_reason_departure + "', '" + ID_Departure_commander + "', 1 , '" + ID_499z15 + "', '" + ID_499z18 + "', '" + ID_499z19 + "', '" + Year + "', '" + Mounth + "', '" + Hour + "');";
                        }
                        else
                        {
                            sqlquery = "INSERT INTO `departure_card` (`ID_departure_card`, `Departure_number`, `Departure_date`, `Hour_departure`, `Hour_arrival`, `ID_place_departure`, `ID_reason_departure`, `ID_Departure_commander`, `ID_499z01`, `ID_499z15`, `ID_499z18`, `ID_499z19`, `Year`, `Mounth`, `Hour`) VALUES (NULL, '" + departure_number + "', '" + departure_date + "', '" + Hour_departure + "', '" + Hour_arrival + "', '" + ID_place_departure + "', '" + ID_reason_departure + "', '" + ID_Departure_commander + "', 1 , '" + ID_499z15 + "', '" + ID_499z18 + "', 1 , '" + Year + "', '" + Mounth + "', '" + Hour + "');";
                        }
                    }
                    else if (ID_499z19 != 0)
                    {
                        sqlquery = "INSERT INTO `departure_card` (`ID_departure_card`, `Departure_number`, `Departure_date`, `Hour_departure`, `Hour_arrival`, `ID_place_departure`, `ID_reason_departure`, `ID_Departure_commander`, `ID_499z01`, `ID_499z15`, `ID_499z18`, `ID_499z19`, `Year`, `Mounth`, `Hour`) VALUES (NULL, '" + departure_number + "', '" + departure_date + "', '" + Hour_departure + "', '" + Hour_arrival + "', '" + ID_place_departure + "', '" + ID_reason_departure + "', '" + ID_Departure_commander + "', 1 , '" + ID_499z15 + "', 1 , '" + ID_499z19 + "', '" + Year + "', '" + Mounth + "', '" + Hour + "');";
                    }
                    else
                    {
                        sqlquery = "INSERT INTO `departure_card` (`ID_departure_card`, `Departure_number`, `Departure_date`, `Hour_departure`, `Hour_arrival`, `ID_place_departure`, `ID_reason_departure`, `ID_Departure_commander`, `ID_499z01`, `ID_499z15`, `ID_499z18`, `ID_499z19`, `Year`, `Mounth`, `Hour`) VALUES (NULL, '" + departure_number + "', '" + departure_date + "', '" + Hour_departure + "', '" + Hour_arrival + "', '" + ID_place_departure + "', '" + ID_reason_departure + "', '" + ID_Departure_commander + "', 1 , '" + ID_499z15 + "', 1 , 1 , '" + Year + "', '" + Mounth + "', '" + Hour + "');";
                    }
                }
                else if (ID_499z18 != 0)
                {
                    if (ID_499z19 != 0)
                    {
                        sqlquery = "INSERT INTO `departure_card` (`ID_departure_card`, `Departure_number`, `Departure_date`, `Hour_departure`, `Hour_arrival`, `ID_place_departure`, `ID_reason_departure`, `ID_Departure_commander`, `ID_499z01`, `ID_499z15`, `ID_499z18`, `ID_499z19`, `Year`, `Mounth`, `Hour`) VALUES (NULL, '" + departure_number + "', '" + departure_date + "', '" + Hour_departure + "', '" + Hour_arrival + "', '" + ID_place_departure + "', '" + ID_reason_departure + "', '" + ID_Departure_commander + "', 1 , 1 , '" + ID_499z18 + "', '" + ID_499z19 + "', '" + Year + "', '" + Mounth + "', '" + Hour + "');";
                    }
                    else
                    {
                        sqlquery = "INSERT INTO `departure_card` (`ID_departure_card`, `Departure_number`, `Departure_date`, `Hour_departure`, `Hour_arrival`, `ID_place_departure`, `ID_reason_departure`, `ID_Departure_commander`, `ID_499z01`, `ID_499z15`, `ID_499z18`, `ID_499z19`, `Year`, `Mounth`, `Hour`) VALUES (NULL, '" + departure_number + "', '" + departure_date + "', '" + Hour_departure + "', '" + Hour_arrival + "', '" + ID_place_departure + "', '" + ID_reason_departure + "', '" + ID_Departure_commander + "', 1 , 1 , '" + ID_499z18 + "', 1 , '" + Year + "', '" + Mounth + "', '" + Hour + "');";
                    }
                }
                else if (ID_499z19 != 0)
                {
                    sqlquery = "INSERT INTO `departure_card` (`ID_departure_card`, `Departure_number`, `Departure_date`, `Hour_departure`, `Hour_arrival`, `ID_place_departure`, `ID_reason_departure`, `ID_Departure_commander`, `ID_499z01`, `ID_499z15`, `ID_499z18`, `ID_499z19`, `Year`, `Mounth`, `Hour`) VALUES (NULL, '" + departure_number + "', '" + departure_date + "', '" + Hour_departure + "', '" + Hour_arrival + "', '" + ID_place_departure + "', '" + ID_reason_departure + "', '" + ID_Departure_commander + "', 1 , 1 , 1 , '" + ID_499z19 + "', '" + Year + "', '" + Mounth + "', '" + Hour + "');";
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
        public static void UpdateDateDepartureCard(int departure_number, string departure_date, string Hour_departure, string Hour_arrival, int ID_place_departure, int ID_reason_departure, int ID_Departure_commander, int ID_499z01, int ID_499z15, int ID_499z18, int ID_499z19, int Year, int Mounth, string Hour)
        {

            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {
                string sqlquery = "";
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                if(ID_499z01 == 0)
                {
                    ID_499z01++;
                }
                if(ID_499z15 == 0)
                {
                    ID_499z15++;
                }
                if(ID_499z18 == 0)
                {
                    ID_499z18++;
                }
                if(ID_499z19 == 0)
                {
                    ID_499z19++;
                }
                
                sqlquery = "UPDATE `departure_card` SET `Departure_date`='"+departure_date+ "',`Hour_departure`='"+Hour_departure+ "',`Hour_arrival`='"+Hour_arrival+ "',`ID_place_departure`='"+ID_place_departure+ "',`ID_reason_departure`='"+ID_reason_departure+ "',`ID_Departure_commander`='"+ID_Departure_commander+ "',`ID_499z01`='"+ID_499z01+ "',`ID_499z15`='"+ID_499z15+ "',`ID_499z18`='"+ID_499z18+ "',`ID_499z19`='"+ID_499z19+ "',`Mounth`='"+Mounth+ "',`Hour`='"+Hour+ "' WHERE `Departure_number` = '"+departure_number+ "' AND `Year` = '"+Year+"';";
                           


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

        public static int SelectIncident(string Incident, int TypeIncident, string NIncident)
        {
            int Zwracana = 0;
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {
                string sqlquery = "";

                cnn = new MySqlConnection(connectionString);
                if (Incident == "")
                {
                    
                    cnn.Open();
                    sqlquery = "SELECT ID_incident FROM incident WHERE incident.Name = '" + NIncident + "';";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();
                        Zwracana = int.Parse(reader["ID_incident"].ToString()); ;
                    }
                    cnn.Close();
                }
                else
                {
                    cnn.Open();
                    sqlquery = "SELECT ID_incident FROM incident WHERE incident.Name = '" + Incident + "';";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();
                        Zwracana = int.Parse(reader["ID_incident"].ToString()); ;
                    }
                    cnn.Close();
                }
                
                
                
                
            }
            catch 
            {
                try
                {
                    string sqlquery = "";

                    cnn = new MySqlConnection(connectionString);
                    cnn.Open();
                    sqlquery = "INSERT INTO `incident` (`ID_incident`, `ID_Incident_Type`, `Name`) VALUES (NULL, '"+TypeIncident+"', '"+NIncident+"');";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();
                    }
                    cnn.Close();
                    cnn.Open();
                    sqlquery = "SELECT ID_incident FROM incident WHERE incident.Name = '" + NIncident + "';";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();
                        Zwracana = int.Parse(reader["ID_incident"].ToString());
                    }
                    cnn.Close();
                }
                catch
                {

                }
            }
            return Zwracana;
        }

        public static int SelectPlace(string City, string Street)
        {
            int id_City = SelectCity(City);
            int id_Street = SelectStreet(City, Street);
            int Zwracana = 0;
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {
                string sqlquery = "";

                cnn = new MySqlConnection(connectionString);
                
                    cnn.Open();
                    sqlquery = "SELECT place.ID_place FROM place WHERE place.ID_City = '" + id_City + "' AND place.ID_Street = '" + id_Street + "'";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();

                        Zwracana = int.Parse(reader["ID_place"].ToString());

                    }

                    cnn.Close();
                
            }
            catch
            {
                
                try
                {
                    string sqlquery = "";

                    cnn = new MySqlConnection(connectionString);
                    id_City = SelectCity(City);
                    id_Street = SelectStreet(City, Street);
                    cnn.Close();

                    
                        cnn.Open();
                        sqlquery = "INSERT INTO `place` (`ID_place`, `ID_City`, `ID_Street`) VALUES (NULL, '" + id_City + "', '" + id_Street + "');";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();
                        }
                        cnn.Close();
                        cnn.Open();
                        sqlquery = "SELECT place.ID_place FROM place WHERE place.ID_City = '" + id_City + "' AND place.ID_Street = '" + id_Street + "'";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();

                            Zwracana = int.Parse(reader["ID_place"].ToString());

                        }

                        cnn.Close();
                    
                }
                catch (Exception x)
                {
                    MessageBox.Show("Coś poszło nie tak z zapisywaniem danych obsady\r\r\r\n Błąd informacyjny dla administratora aplikacji:\r\r\r\r\n\r\n\r\n" + x);
                }
               

            }
            return Zwracana;
        }
        public static int SelectCity(string City)
        {
            int Zwracana = 0;
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {
                string sqlquery = "";

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                sqlquery = "SELECT city.ID_city FROM city WHERE city.Name_City = '" + City + "';";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                    
                        Zwracana = int.Parse(reader["ID_city"].ToString());

                }

                cnn.Close();

            }
            catch
            {
                try
                {
                    string sqlquery = "";

                    cnn = new MySqlConnection(connectionString);
                    cnn.Open();
                    sqlquery = "INSERT INTO `city` (`ID_city`, `Name_City`) VALUES (NULL, '" + City + "');";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();



                    }
                    cnn.Close();
                    cnn.Open();
                    sqlquery = "SELECT city.ID_city FROM city WHERE city.Name_City = '" + City + "';";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();

                        Zwracana = int.Parse(reader["ID_city"].ToString());

                    }

                    cnn.Close();
                }
                catch
                {
                    MessageBox.Show("Coś poszło nie tak przy dodawaniu");
                }
            }
            return Zwracana;
        }
        public static int SelectStreet(string City, string Street)
        {
            int id_city = SelectCity(City);
            int id_street = 0;
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {
                string sqlquery = "";

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                sqlquery = "SELECT street.ID_street FROM street WHERE street.ID_city = '" + id_city + "' AND street.Name_Street = '"+Street+"';";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                    id_street = int.Parse(reader["ID_street"].ToString());
                }
                cnn.Close();
                

            }
            catch
            {
                try
                {
                    string sqlquery = "";

                    cnn = new MySqlConnection(connectionString);
                    cnn.Open();
                    sqlquery = "INSERT INTO `street` (`ID_street`, `ID_City`, `Name_Street`) VALUES (NULL, '" + id_city + "', '" + Street + "');";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();
                    }

                    cnn.Close();
                    cnn.Open();
                    sqlquery = "SELECT street.ID_street FROM city, street WHERE city.ID_city = '" + id_city + "' AND street.Name_Street = '" + Street + "';";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();
                        id_street = int.Parse(reader["ID_street"].ToString());
                    }
                    cnn.Close();
                }
                catch
                {
                    MessageBox.Show("Coś poszło nie tak z dodawaniem ulicy");
                }
            }

            return id_street;
        }
        public static int SelectIDCommander(string Commander)
        {
            int Zwracana = 0;
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {
                string sqlquery = "";

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                sqlquery = "SELECT firefighter.ID_firefighter FROM firefighter WHERE firefighter.Nick = '"+Commander+"';";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();

                    Zwracana = int.Parse(reader["ID_firefighter"].ToString());

                }

                cnn.Close();

            }
            catch
            {
                
            }
            return Zwracana;
        }
        public static int IDWhatWhere(string What, string Where)
        {
            int ID = 0;
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {
                if (Where != "")
                {
                    if (What == "firefighter")
                    {
                    
                            string sqlquery = "";
                            cnn = new MySqlConnection(connectionString);



                            cnn.Open();
                            sqlquery = "SELECT " + What + ".ID_" + What + " FROM " + What + " WHERE " + What + ".Nick = '" + Where + "';";
                            using (var command = new MySqlCommand(sqlquery, cnn))
                            {
                                var reader = command.ExecuteReader();
                                reader.Read();
                                ID = int.Parse(reader["ID_" + What].ToString());
                            }
                            cnn.Close();
                        
                    
                    }
                    else
                    {
                        string sqlquery = "";
                        cnn = new MySqlConnection(connectionString);



                        cnn.Open();
                        sqlquery = "SELECT " + What + ".ID_" + What + " FROM " + What + " WHERE " + What + ".Name_" + What + " = '" + Where + "';";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();
                            ID = int.Parse(reader["ID_" + What].ToString());
                        }
                        cnn.Close();
                    }
                }
                else if (Where == "")
                {
                    ID = 0;
                }

            }
            catch
            {

            }
            return ID;
         }
        public static void AddToRanking(string type, int ID_What, int Year)
        {
            
            int IDRanking = 0;
            int RankingNumber = 0;
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {
                string sqlquery = "";
                cnn = new MySqlConnection(connectionString);
                
                if(ID_What != 0)
                {
                    cnn.Open();
                    sqlquery = "SELECT " + type + "_ranking.ID_" + type + "_ranking, " + type + "_ranking.Number_departures FROM " + type + "_ranking WHERE " + type + "_ranking.ID_" + type + " = " + ID_What + " AND " + type + "_ranking.Year = " + Year + ";";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();
                        IDRanking = int.Parse(reader["ID_" + type + "_ranking"].ToString());
                        RankingNumber = int.Parse(reader["Number_departures"].ToString());
                    }
                    cnn.Close();

                    RankingNumber++;
                    cnn.Open();
                    sqlquery = "UPDATE " + type + "_ranking SET Number_departures = " + RankingNumber + " WHERE ID_" + type + "_ranking = " + IDRanking + " AND Year = " + Year + ";";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();

                    }
                    cnn.Close();
                }
 
            }
            catch
            {
                string sqlquery = "";
                RankingNumber = 1;
                cnn = new MySqlConnection(connectionString);
                
                    cnn.Open();
                    sqlquery = "INSERT INTO `" + type + "_ranking` (`ID_" + type + "_ranking`, `ID_" + type + "`, `Year`, `Number_departures`) VALUES(NULL, '" + ID_What+ "', '" + Year + "', '" + RankingNumber + "');";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();

                    }
                    cnn.Close();
                    
                
            }
        }
        public static void DelToRanking(string type, int ID_What, int Year)
        {
            
            int IDRanking = 0;
            int RankingNumber = 0;
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {
                string sqlquery = "";
                cnn = new MySqlConnection(connectionString);
                
                if(ID_What != 0)
                {
                    cnn.Open();
                    sqlquery = "SELECT " + type + "_ranking.ID_" + type + "_ranking, " + type + "_ranking.Number_departures FROM " + type + "_ranking WHERE " + type + "_ranking.ID_" + type + " = " + ID_What + " AND " + type + "_ranking.Year = " + Year + ";";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();
                        IDRanking = int.Parse(reader["ID_" + type + "_ranking"].ToString());
                        RankingNumber = int.Parse(reader["Number_departures"].ToString());
                    }
                    cnn.Close();

                    RankingNumber--;
                    cnn.Open();
                    sqlquery = "UPDATE " + type + "_ranking SET Number_departures = " + RankingNumber + " WHERE ID_" + type + "_ranking = " + IDRanking + " AND Year = " + Year + ";";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();

                    }
                    cnn.Close();
                }
 
            }
            catch
            {
                string sqlquery = "";
                RankingNumber = 1;
                cnn = new MySqlConnection(connectionString);
                
                    cnn.Open();
                    sqlquery = "INSERT INTO `" + type + "_ranking` (`ID_" + type + "_ranking`, `ID_" + type + "`, `Year`, `Number_departures`) VALUES(NULL, '" + ID_What+ "', '" + Year + "', '" + RankingNumber + "');";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();

                    }
                    cnn.Close();
                    
                
            }
        }
        public static string OverviewTruck(string operationalNumber)
        {
            string OverView = "";
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "SELECT garage.Car_review FROM garage WHERE garage.Car_operational_number = '"+operationalNumber+"';";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                    OverView = reader["Car_review"].ToString();
                }
                cnn.Close();
            }
            catch
            {

            }
            return OverView;
        }
        public static int Air(string nameTruck, string inTruck, int numberCylinder)
        {
            int Air = 0;
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "SELECT cylinder.Amount_air FROM cylinder, garage, status_breathing_apparatus WHERE cylinder.ID_Truck = garage.ID_garage AND garage.Car_operational_number = '" + nameTruck+ "' AND cylinder.ID_Status = status_breathing_apparatus.ID_status AND status_breathing_apparatus.Name = '" + inTruck+"' AND cylinder.Number = '"+numberCylinder+"'";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                    Air = int.Parse(reader["Amount_air"].ToString());
                }
                cnn.Close();
            }
            catch
            {

            }
            return Air;
        }
        public static int EmailPlace()
        {
            int Status = 0;
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "SELECT email_place.Status FROM email_place";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                    Status = int.Parse(reader["Status"].ToString());
                }
                cnn.Close();
            }
            catch
            {

            }
            return Status;
        }
        public static List<Cylinder> Cylinder(string FireTruck)
        {
            var list = new List<Cylinder>();
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "SELECT `cylinder`.`Number`, `cylinder`.`Amount_air` FROM cylinder, garage WHERE cylinder.ID_Truck = garage.ID_garage AND cylinder.ID_Status = 1 AND garage.Car_operational_number = '" + FireTruck+"';";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Cylinder History = new Cylinder
                        {
                            Number = int.Parse(reader["Number"].ToString()),
                            Air = int.Parse(reader["Amount_air"].ToString())
                        };
                        list.Add(History);
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
        public static List<Cylinder> CylinderGarage()
        {
            var list = new List<Cylinder>();
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "SELECT cylinder.Number, cylinder.Amount_air, garage.Car_operational_number, status_breathing_apparatus.Name FROM cylinder, garage, status_breathing_apparatus WHERE cylinder.ID_Status = status_breathing_apparatus.ID_status AND cylinder.ID_Truck = garage.ID_garage ORDER BY cylinder.Number ASC;";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Cylinder History = new Cylinder
                        {
                            Number = int.Parse(reader["Number"].ToString()),
                            Firetruck = reader["Car_operational_number"].ToString(),
                            Status = reader["Name"].ToString(),
                            Air = int.Parse(reader["Amount_air"].ToString())
                        };
                        list.Add(History);
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
        public static void ChangeInCylinder(int Cylinder, string What, string New)
        {
            
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {
                string sqlquery;
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                if(What == "Zmiana lokalizacji")
                {
                    sqlquery = "UPDATE `cylinder` SET `ID_Truck` = '"+SelectTruckToCylinder("Truck",New)+"' WHERE `cylinder`.`Number` = "+Cylinder+";";
                }
                else if(What == "Zmiana statusu")
                {
                    sqlquery = "UPDATE `cylinder` SET `ID_Status` = '" + SelectTruckToCylinder("Status", New) + "' WHERE `cylinder`.`Number` = " + Cylinder + ";";
                }
                else
                {
                    sqlquery = "UPDATE `cylinder` SET `Amount_air` = '"+New+"' WHERE `cylinder`.`Number` = " + Cylinder + ";";
                }
                
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                    
                }
                cnn.Close();
            }
            catch
            {

            }
            
        }
        public static int SelectTruckToCylinder(string What, string text)
        {
            int ID;
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            
            if(What == "Truck")
            {

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "Select garage.ID_garage FROM garage WHERE garage.Car_operational_number = '" + text + "';";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();

                    ID = int.Parse(reader["ID_garage"].ToString());
                }
                cnn.Close();
            }
            else
            {
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "SELECT status_breathing_apparatus.ID_status FROM status_breathing_apparatus WHERE status_breathing_apparatus.Name = '"+text+"';";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();

                    ID = int.Parse(reader["ID_status"].ToString());
                }
                cnn.Close();
            }
            
            return ID;
        }

        #region To Loading Previous Departure Card
        public static string SelectPreviousDepartureCard(int Year, int NumberDepartureCard, string What)
        {
            string result = "";
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "SELECT departure_card." + What + " FROM `departure_card` WHERE Departure_number = '" + NumberDepartureCard + "' AND Year = '" + Year + "';";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();

                    result = reader[What].ToString();




                }
                cnn.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            return result;
        }

        public static string Loading(string ID, string What, int Number)
        {
            string result = "";
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            try
            {
                if(What == "City")
                {
                    cnn = new MySqlConnection(connectionString);
                    cnn.Open();
                    string sqlquery = "SELECT city.Name_city FROM city, place WHERE place.ID_City = city.ID_city AND place.ID_place = '" + ID + "';";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();

                        result = reader["Name_city"].ToString();

                    }
                    cnn.Close();
                }
                else if(What == "Street")
                {
                    cnn = new MySqlConnection(connectionString);
                    cnn.Open();
                    string sqlquery = "SELECT street.Name_street FROM street, place WHERE place.ID_street = street.ID_street AND place.ID_place = '" + ID + "';";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();

                        result = reader["Name_street"].ToString();

                    }
                    cnn.Close();
                }
                else if(What == "TypeIncident")
                {
                    cnn = new MySqlConnection(connectionString);
                    cnn.Open();
                    string sqlquery = "SELECT incident.ID_Incident_Type FROM incident, departure_card WHERE departure_card.ID_reason_departure = '"+ID+"' AND departure_card.ID_reason_departure = incident.ID_incident;";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();

                        result = reader["ID_Incident_Type"].ToString();

                    }
                    cnn.Close();
                }
                else if(What == "Incident")
                {
                    cnn = new MySqlConnection(connectionString);
                    cnn.Open();
                    string sqlquery = "SELECT incident.Name FROM incident, departure_card WHERE departure_card.ID_reason_departure = '" + ID + "' AND departure_card.ID_reason_departure = incident.ID_incident;";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();

                        result = reader["Name"].ToString();

                    }
                    cnn.Close();
                }
                else if(What == "499z01")
                {
                    if(Number == 1)
                    {
                        cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sqlquery = "SELECT `499z01_departure`.`Nick_Driver_01` FROM `499z01_departure` WHERE `499z01_departure`.`ID` = '" + ID + "';";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();

                            result = reader["Nick_Driver_01"].ToString();

                        }
                        cnn.Close();
                    }
                    else if(Number == 2)
                    {
                        cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sqlquery = "SELECT `499z01_departure`.`Nick_Commander_01` FROM `499z01_departure` WHERE `499z01_departure`.`ID` = '" + ID + "';";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();

                            result = reader["Nick_Commander_01"].ToString();

                        }
                        cnn.Close();
                    }
                    else if(Number == 3)
                    {
                        cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sqlquery = "SELECT `499z01_departure`.`Nick_Firefighter_01_1` FROM `499z01_departure` WHERE `499z01_departure`.`ID` = '" + ID + "';";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();

                            result = reader["Nick_Firefighter_01_1"].ToString();

                        }
                        cnn.Close();
                    }
                    else if(Number == 4)
                    {
                        cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sqlquery = "SELECT `499z01_departure`.`Nick_Firefighter_01_2` FROM `499z01_departure` WHERE `499z01_departure`.`ID` = '" + ID + "';";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();

                            result = reader["Nick_Firefighter_01_2"].ToString();

                        }
                        cnn.Close();
                    }
                    else if(Number == 5)
                    {
                        cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sqlquery = "SELECT `499z01_departure`.`Nick_Firefighter_01_3` FROM `499z01_departure` WHERE `499z01_departure`.`ID` = '" + ID + "';";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();

                            result = reader["Nick_Firefighter_01_3"].ToString();

                        }
                        cnn.Close();
                    }
                    else if(Number == 6)
                    {
                        cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sqlquery = "SELECT `499z01_departure`.`Nick_Firefighter_01_4` FROM `499z01_departure` WHERE `499z01_departure`.`ID` = '" + ID + "';";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();

                            result = reader["Nick_Firefighter_01_4"].ToString();

                        }
                        cnn.Close();
                    }
                    
                }
                else if(What == "499z15")
                {
                    if (Number == 1)
                    {
                        cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sqlquery = "SELECT `499z15_departure`.`Nick_Driver_15` FROM `499z15_departure` WHERE `499z15_departure`.`ID` = '" + ID + "';";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();

                            result = reader["Nick_Driver_15"].ToString();

                        }
                        cnn.Close();
                    }
                    else if (Number == 2)
                    {
                        cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sqlquery = "SELECT `499z15_departure`.`Nick_Commander_15` FROM `499z15_departure` WHERE `499z15_departure`.`ID` = '" + ID + "';";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();

                            result = reader["Nick_Commander_15"].ToString();

                        }
                        cnn.Close();
                    }
                    else if (Number == 3)
                    {
                        cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sqlquery = "SELECT `499z15_departure`.`Nick_Firefighter_15_1` FROM `499z15_departure` WHERE `499z15_departure`.`ID` = '" + ID + "';";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();

                            result = reader["Nick_Firefighter_15_1"].ToString();

                        }
                        cnn.Close();
                    }
                    else if (Number == 4)
                    {
                        cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sqlquery = "SELECT `499z15_departure`.`Nick_Firefighter_15_2` FROM `499z15_departure` WHERE `499z15_departure`.`ID` = '" + ID + "';";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();

                            result = reader["Nick_Firefighter_15_2"].ToString();

                        }
                        cnn.Close();
                    }
                    else if (Number == 5)
                    {
                        cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sqlquery = "SELECT `499z15_departure`.`Nick_Firefighter_15_3` FROM `499z15_departure` WHERE `499z15_departure`.`ID` = '" + ID + "';";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();

                            result = reader["Nick_Firefighter_15_3"].ToString();

                        }
                        cnn.Close();
                    }
                    else if (Number == 6)
                    {
                        cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sqlquery = "SELECT `499z15_departure`.`Nick_Firefighter_15_4` FROM `499z15_departure` WHERE `499z15_departure`.`ID` = '" + ID + "';";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();

                            result = reader["Nick_Firefighter_15_4"].ToString();

                        }
                        cnn.Close();
                    }
                }
                else if(What == "499z18")
                {
                    if (Number == 1)
                    {
                        cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sqlquery = "SELECT `499z18_departure`.`Nick_Driver_18` FROM `499z18_departure` WHERE `499z18_departure`.`ID` = '" + ID + "';";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();

                            result = reader["Nick_Driver_18"].ToString();

                        }
                        cnn.Close();
                    }
                    else if (Number == 2)
                    {
                        cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sqlquery = "SELECT `499z18_departure`.`Nick_Commander_18` FROM `499z18_departure` WHERE `499z18_departure`.`ID` = '" + ID + "';";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();

                            result = reader["Nick_Commander_18"].ToString();

                        }
                        cnn.Close();
                    }
                    else if (Number == 3)
                    {
                        cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sqlquery = "SELECT `499z18_departure`.`Nick_Firefighter_18_1` FROM `499z18_departure` WHERE `499z18_departure`.`ID` = '" + ID + "';";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();

                            result = reader["Nick_Firefighter_18_1"].ToString();

                        }
                        cnn.Close();
                    }
                    else if (Number == 4)
                    {
                        cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sqlquery = "SELECT `499z18_departure`.`Nick_Firefighter_18_2` FROM `499z18_departure` WHERE `499z18_departure`.`ID` = '" + ID + "';";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();

                            result = reader["Nick_Firefighter_18_2"].ToString();

                        }
                        cnn.Close();
                    }
                    else if (Number == 5)
                    {
                        cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sqlquery = "SELECT `499z18_departure`.`Nick_Firefighter_18_3` FROM `499z18_departure` WHERE `499z18_departure`.`ID` = '" + ID + "';";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();

                            result = reader["Nick_Firefighter_18_3"].ToString();

                        }
                        cnn.Close();
                    }
                }
                else if(What == "499z19")
                {
                    if (Number == 1)
                    {
                        cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sqlquery = "SELECT `499z19_departure`.`Nick_Driver_19` FROM `499z19_departure` WHERE `499z19_departure`.`ID` = '" + ID + "';";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();

                            result = reader["Nick_Driver_19"].ToString();

                        }
                        cnn.Close();
                    }
                    else if (Number == 2)
                    {
                        cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sqlquery = "SELECT `499z19_departure`.`Nick_Commander_19` FROM `499z19_departure` WHERE `499z19_departure`.`ID` = '" + ID + "';";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();

                            result = reader["Nick_Commander_19"].ToString();

                        }
                        cnn.Close();
                    }
                    else if (Number == 3)
                    {
                        cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sqlquery = "SELECT `499z19_departure`.`Nick_Firefighter_19_1` FROM `499z19_departure` WHERE `499z19_departure`.`ID` = '" + ID + "';";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();

                            result = reader["Nick_Firefighter_19_1"].ToString();

                        }
                        cnn.Close();
                    }
                    else if (Number == 4)
                    {
                        cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sqlquery = "SELECT `499z19_departure`.`Nick_Firefighter_19_2` FROM `499z19_departure` WHERE `499z19_departure`.`ID` = '" + ID + "';";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();

                            result = reader["Nick_Firefighter_19_2"].ToString();

                        }
                        cnn.Close();
                    }
                    else if (Number == 5)
                    {
                        cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sqlquery = "SELECT `499z19_departure`.`Nick_Firefighter_19_3` FROM `499z19_departure` WHERE `499z19_departure`.`ID` = '" + ID + "';";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();

                            result = reader["Nick_Firefighter_19_3"].ToString();

                        }
                        cnn.Close();
                    }
                    else if (Number == 6)
                    {
                        cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sqlquery = "SELECT `499z19_departure`.`Nick_Firefighter_19_4` FROM `499z19_departure` WHERE `499z19_departure`.`ID` = '" + ID + "';";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();

                            result = reader["Nick_Firefighter_19_4"].ToString();

                        }
                        cnn.Close();
                    }
                }
                
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            return result;
            
        }
        #endregion






        //public static string Overview(string type, )
        //{
        //    string OverView = "";
        //    string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
        //    MySqlConnection cnn;
        //    try
        //    {

        //        cnn = new MySqlConnection(connectionString);
        //        cnn.Open();
        //        string sqlquery = "SELECT garage.Car_review FROM garage WHERE garage.Car_operational_number = '';";
        //        using (var command = new MySqlCommand(sqlquery, cnn))
        //        {
        //            var reader = command.ExecuteReader();
        //            reader.Read();
        //            OverView = reader["Car_review"].ToString();
        //        }
        //        cnn.Close();
        //    }
        //    catch
        //    {

        //    }
        //    return OverView;
        //}
    }
    
}