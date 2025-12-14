using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FirefighterControlCenter.DataAccessLayer
{


    public class SqlConnector
    {

        private const string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
        public static List<Firefighter_ranking> RankingFirefighter(string Year)
        {
            var list = new List<Firefighter_ranking>();
           
            MySqlConnection cnn;
            try
            {

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "WITH filtered_departures AS (SELECT vc.Driver, vc.Commander, vc.Firefighter_1, vc.Firefighter_2, vc.Firefighter_3, vc.Firefighter_4, vc.Firefighter_5, vc.Firefighter_6, vc.Firefighter_7, z01.Nick_Driver_01, z01.Nick_Commander_01, z01.Nick_Firefighter_01_1, z01.Nick_Firefighter_01_2, z01.Nick_Firefighter_01_3, z01.Nick_Firefighter_01_4, z15.Nick_Driver_15, z15.Nick_Commander_15, z15.Nick_Firefighter_15_1, z15.Nick_Firefighter_15_2, z15.Nick_Firefighter_15_3, z15.Nick_Firefighter_15_4, z18.Nick_Driver_18, z18.Nick_Commander_18, z18.Nick_Firefighter_18_1, z18.Nick_Firefighter_18_2, z18.Nick_Firefighter_18_3, z19.Nick_Driver_19, z19.Nick_Commander_19, z19.Nick_Firefighter_19_1, z19.Nick_Firefighter_19_2, z19.Nick_Firefighter_19_3, z19.Nick_Firefighter_19_4, dc.hour FROM departure_card AS dc LEFT JOIN departure_card_vehicle AS dcv ON dc.ID_departure_card = dcv.DepartureCard_ID LEFT JOIN vehicle_card AS vc ON dcv.VehicleCard_ID = vc.ID_Vehicle_card LEFT JOIN incident AS inc ON dc.ID_reason_departure = inc.ID_incident LEFT JOIN incident_type AS it ON inc.ID_Incident_Type = it.ID LEFT JOIN 499z01_departure AS z01 ON dc.ID_499z01 = z01.ID_01 LEFT JOIN 499z15_departure AS z15 ON dc.ID_499z15 = z15.ID_15 LEFT JOIN 499z18_departure AS z18 ON dc.ID_499z18 = z18.id_18 LEFT JOIN 499z19_departure AS z19 ON dc.ID_499z19 = z19.id_19 WHERE dc.Year = " + Year + " AND it.ID_Rate = 1), all_names AS (SELECT Driver AS name, hour FROM filtered_departures UNION ALL SELECT Commander, hour FROM filtered_departures UNION ALL SELECT Firefighter_1, hour FROM filtered_departures UNION ALL SELECT Firefighter_2, hour FROM filtered_departures UNION ALL SELECT Firefighter_3, hour FROM filtered_departures UNION ALL SELECT Firefighter_4, hour FROM filtered_departures UNION ALL SELECT Firefighter_5, hour FROM filtered_departures UNION ALL SELECT Firefighter_6, hour FROM filtered_departures UNION ALL SELECT Firefighter_7, hour FROM filtered_departures UNION ALL SELECT Nick_Driver_01, hour FROM filtered_departures UNION ALL SELECT Nick_Commander_01, hour FROM filtered_departures UNION ALL SELECT Nick_Firefighter_01_1, hour FROM filtered_departures UNION ALL SELECT Nick_Firefighter_01_2, hour FROM filtered_departures UNION ALL SELECT Nick_Firefighter_01_3, hour FROM filtered_departures UNION ALL SELECT Nick_Firefighter_01_4, hour FROM filtered_departures UNION ALL SELECT Nick_Driver_15, hour FROM filtered_departures UNION ALL SELECT Nick_Commander_15, hour FROM filtered_departures UNION ALL SELECT Nick_Firefighter_15_1, hour FROM filtered_departures UNION ALL SELECT Nick_Firefighter_15_2, hour FROM filtered_departures UNION ALL SELECT Nick_Firefighter_15_3, hour FROM filtered_departures UNION ALL SELECT Nick_Firefighter_15_4, hour FROM filtered_departures UNION ALL SELECT Nick_Driver_18, hour FROM filtered_departures UNION ALL SELECT Nick_Commander_18, hour FROM filtered_departures UNION ALL SELECT Nick_Firefighter_18_1, hour FROM filtered_departures UNION ALL SELECT Nick_Firefighter_18_2, hour FROM filtered_departures UNION ALL SELECT Nick_Firefighter_18_3, hour FROM filtered_departures UNION ALL SELECT Nick_Driver_19, hour FROM filtered_departures UNION ALL SELECT Nick_Commander_19, hour FROM filtered_departures UNION ALL SELECT Nick_Firefighter_19_1, hour FROM filtered_departures UNION ALL SELECT Nick_Firefighter_19_2, hour FROM filtered_departures UNION ALL SELECT Nick_Firefighter_19_3, hour FROM filtered_departures UNION ALL SELECT Nick_Firefighter_19_4, hour FROM filtered_departures), siksa AS (SELECT name, SUM(hour) AS total_hours, COUNT(*) AS total_count FROM all_names WHERE name IS NOT NULL AND name != '' AND name != '0' GROUP BY name) SELECT firefighter.name, firefighter.last_name, siksa.total_hours, siksa.total_count FROM siksa LEFT JOIN firefighter ON siksa.name = firefighter.Nick ORDER BY siksa.total_count DESC, firefighter.name;";

                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Firefighter_ranking firefighter = new Firefighter_ranking
                        {

                            Imie = reader["name"].ToString(),
                            Naziwsko = reader["last_name"].ToString(),
                            Rok = int.Parse(Year),
                            Ilosc_wyjazdow = int.Parse(reader["total_count"].ToString()),
                            Poswiecony_czas = int.Parse(reader["total_hours"].ToString()),
                            Procentowo = Math.Round(double.Parse(reader["total_count"].ToString()) / SelectNumberDeparture(int.Parse(Year)) * 100, 2).ToString() + "%"


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
           
            MySqlConnection cnn;
            try
            {
                if (type == "city")
                {
                    cnn = new MySqlConnection(connectionString);
                    cnn.Open();
                    string sqlquery = "SELECT city.Name_city , COUNT(*) AS miasta FROM departure_card, incident_type, incident, city, place WHERE city.ID_city = place.ID_City AND place.ID_place = departure_card.ID_place_departure AND departure_card.ID_reason_departure = incident.ID_incident AND incident.ID_Incident_Type = incident_type.ID AND incident_type.ID_Rate = 1 AND departure_card.Year = " + Year + " GROUP BY city.Name_city ORDER BY miasta DESC;";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Ranking ranking = new Ranking
                            {


                                Nazwa = reader["Name_city"].ToString(),
                                Rok = int.Parse(Year),
                                Ilosc_wyjazdow = int.Parse(reader["miasta"].ToString())

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

                    string sqlquery = "SELECT incident.Name_incident, COUNT(*) AS incydent FROM departure_card, incident_type, incident WHERE departure_card.ID_reason_departure = incident.ID_incident AND incident.ID_Incident_Type = incident_type.ID AND incident_type.ID_Rate = 1 AND departure_card.Year = " + Year + " GROUP BY incident.Name_incident ORDER BY incydent DESC;";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Ranking ranking = new Ranking
                            {
                                Nazwa = reader["Name_incident"].ToString(),
                                Rok = int.Parse(Year),
                                Ilosc_wyjazdow = int.Parse(reader["incydent"].ToString())
                            };
                            //test = reader["Name_incident"].ToString();

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
           
            MySqlConnection cnn;
            try
            {

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "SELECT city.Name_city ,street.Name_street, COUNT(*) AS ulice FROM departure_card, incident_type, incident, city, place, street WHERE city.ID_city = place.ID_City AND place.ID_place = departure_card.ID_place_departure AND place.ID_Street = street.ID_street AND departure_card.ID_reason_departure = incident.ID_incident AND incident.ID_Incident_Type = incident_type.ID AND incident_type.ID_Rate = 1 AND departure_card.Year = " + Year + " GROUP BY street.ID_street ORDER BY ulice DESC;";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        Ranking_City ranking = new Ranking_City
                        {


                            Nazwa_miasta = reader["Name_city"].ToString(),
                            Nazwa_ulicy = reader["Name_street"].ToString(),
                            Rok = int.Parse(Year),
                            Ilosc_wyjazdow = int.Parse(reader["ulice"].ToString())

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

        public static int FirstYear()
        {

            int First = 0;
           
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

        public static List<string> SelectFirefighterDepartureCard(string TypeSelect, string x)
        {
            var list = new List<string>();
           
            MySqlConnection cnn;
            try
            {
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                if (TypeSelect == "DriverC")
                {
                    const string sqlquery = "SELECT nick FROM firefighter, firefighter_status WHERE firefighter.ID_Status=firefighter_status.ID_firefighter_status AND firefighter_status.NameStatus='Czynny' AND firefighter.Kat_C=1 ORDER BY nick ASC;";
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
                    const string sqlquery = "SELECT nick FROM firefighter, firefighter_status WHERE firefighter.ID_Status=firefighter_status.ID_firefighter_status AND firefighter_status.NameStatus='Czynny' AND firefighter.Kat_B=1 ORDER BY nick ASC;";
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
                    const string sqlquery = "SELECT nick FROM firefighter, firefighter_status WHERE firefighter.ID_Status=firefighter_status.ID_firefighter_status AND firefighter_status.NameStatus='Czynny' ORDER BY nick ASC;";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            list.Add(reader["Nick"].ToString());
                        }
                    }
                }
                else if (TypeSelect == "All")
                {
                    const string sqlquery = "SELECT nick FROM firefighter, firefighter_status WHERE firefighter.ID_Status=firefighter_status.ID_firefighter_status ORDER BY nick ASC;";
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


 

        public static int SelectIDCommander(string Commander)
        {
            int Zwracana = 0;
           
            MySqlConnection cnn;
            try
            {
                string sqlquery = "";

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                sqlquery = "SELECT firefighter.ID_firefighter FROM firefighter WHERE firefighter.Nick = '" + Commander + "';";
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
       
        public static List<Cylinder> Cylinder(string FireTruck)
        {
            var list = new List<Cylinder>();
           
            MySqlConnection cnn;
            try
            {

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "SELECT `cylinder`.`Number`, `cylinder`.`Amount_air` FROM cylinder, garage WHERE cylinder.ID_Truck = garage.ID_garage AND cylinder.ID_Status = 1 AND garage.Car_operational_number = '" + FireTruck + "';";
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

           
            MySqlConnection cnn;
            try
            {
                string sqlquery;
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                if (What == "Zmiana lokalizacji")
                {
                    sqlquery = "UPDATE `cylinder` SET `ID_Truck` = '" + SelectTruckToCylinder("Truck", New) + "' WHERE `cylinder`.`Number` = " + Cylinder + ";";
                }
                else if (What == "Zmiana statusu")
                {
                    sqlquery = "UPDATE `cylinder` SET `ID_Status` = '" + SelectTruckToCylinder("Status", New) + "' WHERE `cylinder`.`Number` = " + Cylinder + ";";
                }
                else
                {
                    sqlquery = "UPDATE `cylinder` SET `Amount_air` = '" + New + "' WHERE `cylinder`.`Number` = " + Cylinder + ";";
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
           
            MySqlConnection cnn;

            if (What == "Truck")
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
                string sqlquery = "SELECT status_breathing_apparatus.ID_status FROM status_breathing_apparatus WHERE status_breathing_apparatus.Name = '" + text + "';";
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



        public static void InsertAddNewFirefighter(List<string> newFirefighter)
        {

           
            MySqlConnection cnn;
            try
            {
                string sqlquery = "";
                cnn = new MySqlConnection(connectionString);
                cnn.Open();

                sqlquery = "INSERT INTO firefighter(`Nick`,`name`,`last_name`,`Date_birth`,`Date_admission`,`Medical_exams_done`,`Next_medical_exams`,`ID_Status`,`Kat_B`,`Kat_C`) VALUES ( '" + newFirefighter[0] + "', '" + newFirefighter[1] + "', '" + newFirefighter[2] + "','" + newFirefighter[3] + "', '" + newFirefighter[4] + "','" + newFirefighter[5] + "','" + newFirefighter[6] + "', '" + newFirefighter[7] + "', '" + newFirefighter[8] + "', '" + newFirefighter[9] + "');";

                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                }

                cnn.Close();

                cnn.Open();

                sqlquery = "INSERT INTO training(`ID_firefighter`,`Date_training`, `Chamber_exams_done`, `Next_chamber_exams`, `Helsman`, `First_aid_course`, `Water_rescue`, `chemical_ecological`, `Commander`, `Head`, `Altitude_rescue`, `air_ambulance_service`, `Technical_rescue`) VALUES ('" + SelectIDCommander(newFirefighter[0]).ToString() + "','" + newFirefighter[10] + "', '" + newFirefighter[11] + "', '" + newFirefighter[12] + "', '" + newFirefighter[13] + "', '" + newFirefighter[14] + "', '" + newFirefighter[15] + "', '" + newFirefighter[16] + "', '" + newFirefighter[17] + "', '" + newFirefighter[18] + "', '" + newFirefighter[19] + "', '" + newFirefighter[20] + "', '" + newFirefighter[21] + "');";

                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                }

                cnn.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Błąd przy dodawaniu strażaka. Sprawdź czy zostało uzupelnione wszystko co najwazniejsze");

            }

        }

        public static List<string> ReadFirefighters(string Nick)
        {
            var list = new List<string>();
           
            MySqlConnection cnn;
            try
            {

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "SELECT firefighter.name, firefighter.last_name, firefighter.Date_birth, firefighter.Date_admission, firefighter.Medical_exams_done, firefighter_status.NameStatus, firefighter.Kat_B, firefighter.Kat_C FROM firefighter, firefighter_status where firefighter.Nick = '" + Nick + "' AND firefighter.ID_Status = firefighter_status.ID_firefighter_status;";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(reader["name"].ToString());
                        list.Add(reader["last_name"].ToString());
                        list.Add(reader["Date_birth"].ToString());
                        list.Add(reader["Date_admission"].ToString());
                        list.Add(reader["Medical_exams_done"].ToString());
                        list.Add(reader["NameStatus"].ToString());
                        list.Add(reader["Kat_B"].ToString());
                        list.Add(reader["Kat_C"].ToString());
                    }


                }
                cnn.Close();
                cnn.Open();
                sqlquery = "SELECT training.Date_training, training.Chamber_exams_done, training.Commander, training.Head, training.First_aid_course, training.air_ambulance_service, training.Technical_rescue, training.Water_rescue, training.Chemical_ecological, training.Altitude_rescue, training.Helsman FROM firefighter, training where firefighter.Nick = '" + Nick + "' AND firefighter.ID_firefighter = training.ID_firefighter;";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(reader["Date_training"].ToString());
                        list.Add(reader["Chamber_exams_done"].ToString());
                        list.Add(reader["Commander"].ToString());
                        list.Add(reader["Head"].ToString());
                        list.Add(reader["First_aid_course"].ToString());
                        list.Add(reader["air_ambulance_service"].ToString());
                        list.Add(reader["Technical_rescue"].ToString());
                        list.Add(reader["Water_rescue"].ToString());
                        list.Add(reader["Chemical_ecological"].ToString());
                        list.Add(reader["Altitude_rescue"].ToString());
                        list.Add(reader["Helsman"].ToString());







                    }


                }





            }
            catch (Exception)
            {
                MessageBox.Show("Brak informacji o wybranej osobie");
            }
            return list;
        }

        public static List<string> ReadStatus()
        {
            var list = new List<string>();
           
            MySqlConnection cnn;
            try
            {

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "SELECT firefighter_status.NameStatus FROM firefighter_status;";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(reader["NameStatus"].ToString());
                    }


                }
                cnn.Close();




            }
            catch (Exception)
            {
                MessageBox.Show("Brak informacji o wybranej osobie");
            }
            return list;
        }

      

        

        public static void UpdateFirefighter(List<string> list)
        {

           
            MySqlConnection cnn;


            cnn = new MySqlConnection(connectionString);
            cnn.Open();
            string sqlquery = "UPDATE training , firefighter SET firefighter.Nick = '" + list[0] + "' , firefighter.name = '" + list[1] + "' , firefighter.last_name = '" + list[2] + "' , firefighter.Date_birth='" + list[3] + "' , firefighter.Date_admission = '" + list[4] + "' , firefighter.Medical_exams_done = '" + list[5] + "' , firefighter.Next_medical_exams = '" + list[6] + "' , firefighter.ID_Status = '" + list[7] + "' , firefighter.Kat_B = '" + list[8] + "' , firefighter.Kat_C = '" + list[9] + "' , training.Date_training = '" + list[10] + "' , training.Chamber_exams_done = '" + list[11] + "' , training.Next_chamber_exams = '" + list[12] + "' , training.Helsman = '" + list[13] + "' , training.First_aid_course = '" + list[14] + "' , training.First_aid_course_done = '2000-10-10' , training.Next_first_aid_course = '2000-1-1' , training.Water_rescue = '" + list[15] + "' , training.Chemical_ecological = '" + list[16] + "', training.Commander = '" + list[17] + "' , training.Head = '" + list[18] + "' , training.Altitude_rescue = '" + list[19] + "' , training.air_ambulance_service = '" + list[20] + "' , training.Technical_rescue = '" + list[21] + "' WHERE training.ID_firefighter = firefighter.ID_firefighter AND firefighter.Nick = '" + list[22] + "';";
            using (var command = new MySqlCommand(sqlquery, cnn))
            {
                var reader = command.ExecuteReader();
                reader.Read();
            }
            cnn.Close();


        }






       
    }

}