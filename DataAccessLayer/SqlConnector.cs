using System;
using System.Collections.Generic;
using System.Configuration;
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
                            /*Id = int.Parse(reader["id_departure_ranking"].ToString()),
                            Imie = reader["name"].ToString(),
                            Naziwsko = reader["last_name"].ToString(),
                            Nazwa_miasta = reader["Name_City"].ToString(),
                            Nazwa_ulicy = reader["Name_Street"].ToString(),
                            Rok = int.Parse(reader["Year"].ToString()),
                            Ilosc_wyjazdow = int.Parse(reader["Number_departures"].ToString())
                            */
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

        public static int NumberDeparture()
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
                    while (reader.Read())
                    {
                        LastNumberDeparture = int.Parse(reader["MAX(Departure_number)"].ToString());
                    }
                    
                        
                    
                }
                cnn.Close();
            }
            catch (Exception e)
            {
                
            }
            return LastNumberDeparture;
        }
    }
}