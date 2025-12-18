using FirefighterControlCenter.DataAccessLayer;
using FirefighterControlCenter.DataAccessLayer.Statistics;
using MySql.Data.MySqlClient;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace FirefighterControlCenter.DataAccessLayer
{
    public class SqlConnectorv2
    {
        private const string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";

        public static string SelectPasswordEmail()
        {

            string Password;
            MySqlConnection cnn;
            try
            {

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "SELECT PASSWORD FROM `password_to_email` WHERE `ID` = 1;";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();

                    Password = reader["PASSWORD"].ToString();
                }
                cnn.Close();

                return Password;
            }
            catch
            {
                return "0";
            }
            

        }

        #region Statistics

        public List<TripsDividedIntoMonths> TripsDividedIntoMonths(int From, int To)
        {
            var list = new List<TripsDividedIntoMonths>();
            MySqlConnection cnn;
            try
            {
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "SELECT MONTHNAME(STR_TO_DATE(departure_card.Departure_date, '%d.%m.%Y')) AS miesiac, COUNT(*) AS liczba_wyjazdow FROM departure_card JOIN incident ON departure_card.ID_reason_departure = incident.ID_incident JOIN incident_type ON incident.ID_Incident_Type = incident_type.ID WHERE Year >= " + From + " AND Year <= " + To + " AND incident_type.ID_Rate = 1 GROUP BY miesiac ORDER BY liczba_wyjazdow DESC;";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var trip = new TripsDividedIntoMonths
                        {
                            miesiac = reader["Miesiac"].ToString(),
                            liczba_wyjazdow = int.Parse(reader["Liczba_wyjazdow"].ToString())
                        };
                        list.Add(trip);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem z pobraniem danych statystycznych - Wyjazdy podzielone na miesiące");
            }
            return list;
        }

        public List<TripsDividedIntoDays> TripsDividedIntoDays(int From, int To)
        {
            var list = new List<TripsDividedIntoDays>();
            MySqlConnection cnn;
            try
            {
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "SELECT DAY(STR_TO_DATE(departure_card.Departure_date, '%d.%m.%Y')) AS dzien, COUNT(*) AS liczba_wyjazdow FROM departure_card JOIN incident ON departure_card.ID_reason_departure = incident.ID_incident JOIN incident_type ON incident.ID_Incident_Type = incident_type.ID WHERE Year >= " + From + " AND Year <= " + To + " AND incident_type.ID_Rate = 1 GROUP BY dzien ORDER BY liczba_wyjazdow DESC; ";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var trip = new TripsDividedIntoDays
                        {
                            dzien = reader["Dzien"].ToString(),
                            liczba_wyjazdow = int.Parse(reader["Liczba_wyjazdow"].ToString())
                        };
                        list.Add(trip);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem z pobraniem danych statystycznych - Wyjazdy podzielone na dni");
            }
            return list;
        }

        #endregion


        #region Departure Card - Basic Information
        public static string SelectLastNumberDeparture(int Year)
        {

            string LastNumberDeparture;
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

                    LastNumberDeparture = reader["MAX(Departure_number)"].ToString();
                }
                cnn.Close();
            }
            catch
            {
                return "0";
            }
            if (LastNumberDeparture == "")
            {
                return "0";
            }
            else
            {
                return LastNumberDeparture;
            }

        }

        public static bool IsThereANumber(int NumberDepartureCard, int Year)
        {

            MySqlConnection cnn;
            try
            {
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = $"SELECT departure_card.ID_departure_card FROM departure_card WHERE departure_card.Departure_number = {NumberDepartureCard} AND departure_card.Year = {Year};";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();

                    int i = reader.GetInt16("ID_departure_card");
                }
                cnn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<string> SelectBasicInformation(int NumberDeparture, int Year)
        {
            var list = new List<string>();
            MySqlConnection cnn;
            try
            {
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "SELECT Hour_departure, Hour_arrival, Departure_date FROM Departure_card WHERE Departure_number = " + NumberDeparture + " AND Year = " + Year + "";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(reader["Hour_departure"].ToString().Substring(0, 2));
                        list.Add(reader["Hour_departure"].ToString().Substring(3, 2));
                        list.Add(reader["Hour_arrival"].ToString().Substring(0, 2));
                        list.Add(reader["Hour_arrival"].ToString().Substring(3, 2));
                        list.Add(reader["Departure_date"].ToString());
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem z pobraniem danych na temat podstawowych informacji");
            }
            return list;
        }
        #endregion
        #region Departure Card - Place Departure
        public static List<string> SelectPlaceDepartureCard(string TypeSelect, string x)
        {
            var list = new List<string>();
            MySqlConnection cnn;
            try
            {
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                if (TypeSelect == "City")
                {
                    string sqlquery = "SELECT Name_City FROM city ORDER BY Name_City ASC;";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            list.Add(reader["Name_City"].ToString());
                        }
                    }
                }
                else if (TypeSelect == "Street")
                {
                    string sqlquery = ("SELECT Name_Street FROM street, city WHERE city.ID_city=street.ID_City AND city.Name_City='" + x + "' ORDER BY Name_Street ASC;");
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["Name_Street"].ToString() != "")
                                list.Add(reader["Name_Street"].ToString());
                        }
                    }
                }

                cnn.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Problem z pobraniem danych odnośnie miejsca zdarzenia");
            }
            return list;
        }

        public static List<string> SelectPPlaceDepartureCard(int DepartureNumber, int Year)
        {
            var list = new List<string>();
            MySqlConnection cnn;
            try
            {
                cnn = new MySqlConnection(connectionString);
                cnn.Open();

                string sqlquery = "SELECT city.Name_city , street.Name_street, departure_card.Trip FROM departure_card, city, street, place WHERE departure_card.Departure_number = " + DepartureNumber + " AND departure_card.ID_place_departure = place.ID_place AND place.ID_City = city.ID_city AND place.ID_Street = street.ID_street AND departure_card.Year = " + Year + ";";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(reader["Name_City"].ToString());// 0 - Nazwa miejscowości
                        list.Add(reader["Name_street"].ToString());// 1 - Nazwa Ulicy
                        list.Add(reader["Trip"].ToString());// 2 - Długość trasy
                    }
                }


                cnn.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Problem z pobraniem danych odnośnie miejsca zdarzenia");
            }
            return list;
        }

        public static int SelectPlace(string City, string Street)
        {
            int ID_Place;
            MySqlConnection cnn;
            try
            {

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "SELECT place.ID_place FROM place,city,street WHERE place.ID_City = city.ID_city AND place.ID_Street = street.ID_street AND street.ID_City = city.ID_city AND street.Name_street = '" + Street + "' AND city.Name_city = '" + City + "'";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();

                    ID_Place = int.Parse(reader["ID_place"].ToString());
                }
                cnn.Close();
            }
            catch
            {
                ID_Place = NewPlace(City, Street);
            }

            return ID_Place;
        }

        public static int NewPlace(string City, string Street)
        {
            int ID_City;
            int ID_Street;
            MySqlConnection cnn;
            try
            {

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "SELECT city.ID_city FROM city WHERE city.Name_city = '" + City + "'";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();

                    ID_City = int.Parse(reader["ID_city"].ToString());
                }
                cnn.Close();

                try
                {
                    cnn = new MySqlConnection(connectionString);
                    cnn.Open();
                    string sqlqueryy = "SELECT street.ID_street FROM street, city WHERE city.ID_city = street.ID_City AND street.ID_City = " + ID_City + " AND street.Name_street = '" + Street + "'";
                    using (var command = new MySqlCommand(sqlqueryy, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();

                        ID_Street = int.Parse(reader["ID_street"].ToString());
                    }
                    cnn.Close();

                    try
                    {
                        cnn = new MySqlConnection(connectionString);
                        cnn.Open();
                        string sqlqueryyy = "INSERT INTO `place`(`ID_place`, `ID_City`, `ID_Street`) VALUES ('[value-1]','" + ID_City + "','" + ID_Street + "')";
                        using (var command = new MySqlCommand(sqlqueryyy, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();
                        }
                        cnn.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Problem ze stworzeniem nowej lokalizacji");
                    }

                }
                catch
                {
                    cnn = new MySqlConnection(connectionString);
                    cnn.Open();
                    string sqlqueryy = "INSERT INTO `street`(`ID_street`, `ID_City`, `Name_street`) VALUES ('','" + ID_City + "','" + Street + "')";
                    using (var command = new MySqlCommand(sqlqueryy, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();
                    }
                    cnn.Close();
                }
            }
            catch
            {
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "INSERT INTO `city`(`ID_city`, `Name_city`) VALUES ('','" + City + "')";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                }
                cnn.Close();
            }






            return SelectPlace(City, Street);
        }



        #endregion
        #region Departure Card - Reason Departure
        public static List<string> SelectReasonDepartureCard(string TypeSelect, string x)
        {
            var list = new List<string>();

            MySqlConnection cnn;
            try
            {
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                if (TypeSelect == "TypeIncident")
                {
                    const string sqlquery = "SELECT Name_Type_Incident FROM incident_type";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            list.Add(reader["Name_Type_Incident"].ToString());
                        }
                    }
                }
                else if (TypeSelect == "Incident")
                {
                    string sqlquery = ("SELECT incident.Name_incident FROM incident_type, incident WHERE incident_type.ID=incident.ID_Incident_Type AND incident_type.Name_Type_Incident='" + x + "' ORDER BY incident.Name_incident ASC;");
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["Name_incident"].ToString() != "")
                            {
                                list.Add(reader["Name_incident"].ToString());
                            }

                        }
                    }
                }


                cnn.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Problem z pobraniem danych odnośnie powodu wyjazdu");
            }
            return list;
        }
        public static List<string> SelectPReasonDepartureCard(int NumberDepartureCard, int Year)
        {
            List<string> list = new List<string>();
            MySqlConnection cnn;
            try
            {
                cnn = new MySqlConnection(connectionString);
                cnn.Open();

                string sqlquery = "SELECT incident.Name_incident, incident_type.Name_Type_Incident FROM incident_type, incident, departure_card WHERE departure_card.ID_reason_departure = incident.ID_incident AND incident.ID_Incident_Type = incident_type.ID AND departure_card.Departure_number = '" + NumberDepartureCard + "' AND departure_card.Year = '" + Year + "';";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(reader["Name_Type_Incident"].ToString());// 0 - Nazwa typu incydentu
                        list.Add(reader["Name_incident"].ToString());// 1 - Nazwa incydentu
                    }
                }


                cnn.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Problem z pobraniem danych odnośnie powodu wyjazdu");
            }
            return list;
        }
        public static int SelectReason(string TypeReason, string Reason)
        {
            int ID_Reason;
            MySqlConnection cnn;
            try
            {

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "SELECT incident.ID_incident FROM incident_type, incident WHERE incident.ID_Incident_Type = incident_type.ID AND incident_type.Name_Type_Incident = '" + TypeReason + "' AND incident.Name_incident = '" + Reason + "';";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();

                    ID_Reason = int.Parse(reader["ID_incident"].ToString());
                }
                cnn.Close();
            }
            catch
            {
                ID_Reason = NewReason(TypeReason, Reason);
            }

            return ID_Reason;
        }

        public static int NewReason(string TypeReason, string Reason)
        {
            int ID_TypeReason;
            int ID_Reason;
            MySqlConnection cnn;
            try
            {

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "SELECT incident_type.ID FROM incident_type WHERE incident_type.Name_Type_Incident = '" + TypeReason + "'";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();

                    ID_TypeReason = int.Parse(reader["ID"].ToString());
                }
                cnn.Close();

                try
                {
                    cnn = new MySqlConnection(connectionString);
                    cnn.Open();
                    string sqlqueryy = "SELECT incident.ID_incident FROM incident WHERE incident.Name_incident = '" + Reason + "' AND incident.ID_Incident_Type = '" + ID_TypeReason + "'";
                    using (var command = new MySqlCommand(sqlqueryy, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();

                        ID_Reason = int.Parse(reader["ID_incident"].ToString());
                    }
                    cnn.Close();



                }
                catch
                {
                    cnn = new MySqlConnection(connectionString);
                    cnn.Open();
                    string sqlqueryy = "INSERT INTO `incident`(`ID_incident`, `ID_Incident_Type`, `Name_incident`) VALUES ('','" + ID_TypeReason + "','" + Reason + "')";
                    using (var command = new MySqlCommand(sqlqueryy, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();
                    }
                    cnn.Close();
                }
            }
            catch
            {
                MessageBox.Show("Nieprawidłowa nazwa rodzaju wyjazdu \n Nie można wpisywać swoich rodzajów \n Proszę wybrać z listy");
                ID_TypeReason = 0;
            }





            if (ID_TypeReason != 0)
            {
                return SelectReason(TypeReason, Reason);
            }
            else
            {
                return ID_TypeReason;
            }

        }
        #endregion
        #region Departure Card - Vehicle

        public static List<string> GetVehicle()
        {
            var Vehicle = new List<string>();
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);

            try
            {


                cnn.Open();
                string sqlquery = "SELECT garage.Car_operational_number, garage.places FROM garage WHERE garage.status_vehicle = 1 ORDER BY garage.Car_operational_number ASC;";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Vehicle.Add(reader["Car_operational_number"].ToString());
                        Vehicle.Add(reader["places"].ToString());
                    }
                }
                cnn.Close();
            }
            catch
            {
                cnn.Close();
                MessageBox.Show("Program z pobraniem listy pojazdów.\nProszę sprawdzić czy baza danych jest włączona");
            }
            return Vehicle;
        }

        public static string SelectCategoryVehicle(string car_operational_number)
        {
            string category;
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            try
            {

                cnn.Open();
                string sqlquery = "SELECT garage.Category FROM garage WHERE garage.Car_operational_number = '" + car_operational_number + "';";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();

                    category = reader["Category"].ToString();
                }
                cnn.Close();
            }
            catch
            {
                cnn.Close();
                return "0";
            }
            return category;
        }

        public static List<string> SelectFirefighterDepartureCard(string TypeSelect)
        {
            var list = new List<string>();
            string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            try
            {

                cnn.Open();
                if (TypeSelect == "C")
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
                else if (TypeSelect == "B")
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
            catch
            {
                cnn.Close();
                MessageBox.Show("Problem z pobraniem danych odnośnie strażaków");
            }
            return list;
        }

        public static bool NewOrOld(int NumberDepartureCard, int Year)
        {
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            try
            {


                cnn.Open();
                string sqlquery = "SELECT departure_card_vehicle.VehicleCard_ID FROM departure_card_vehicle, departure_card WHERE departure_card_vehicle.DepartureCard_ID = departure_card.ID_departure_card AND departure_card.Departure_number = '" + NumberDepartureCard + "' AND departure_card.Year = '" + Year + "';";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();

                    reader["VehicleCard_ID"].ToString();
                }
                cnn.Close();
                return true;
            }
            catch
            {
                cnn.Close();
                return false;
            }
        }


        public static int SelectIdFireFighter(string Nick)
        {
            MySqlConnection cnn;
            int ID;
            cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open();
                string sqlquery = "SELECT firefighter.ID_firefighter FROM firefighter WHERE firefighter.Nick = '" + Nick + "';";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                    ID = int.Parse(reader["ID_firefighter"].ToString());
                }
                cnn.Close();
            }
            catch
            {
                cnn.Close();
                MessageBox.Show("Problem z pobraniem numeru identyfikacyjnego strażaka");
                return 0;
            }


            return ID;
        }

        public static List<string> SelectFireFightersToPDF(int ID_Vehicle)
        {
            List<string> list = new List<string>();
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            cnn.Open();


            try
            {


                string sqlquery = "SELECT garage.Car_operational_number ,vehicle_card.Driver, vehicle_card.Commander, vehicle_card.Firefighter_1, vehicle_card.Firefighter_2, vehicle_card.Firefighter_3, vehicle_card.Firefighter_4, vehicle_card.Firefighter_5, vehicle_card.Firefighter_6, vehicle_card.Firefighter_7, garage.places FROM garage, vehicle_card WHERE garage.ID_garage = vehicle_card.ID_Vehicle AND vehicle_card.ID_Vehicle_card = " + ID_Vehicle + ";";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(reader["Car_operational_number"].ToString());
                        list.Add(reader["Driver"].ToString());
                        list.Add(reader["Commander"].ToString());
                        list.Add(reader["Firefighter_1"].ToString());
                        list.Add(reader["Firefighter_2"].ToString());
                        list.Add(reader["Firefighter_3"].ToString());
                        list.Add(reader["Firefighter_4"].ToString());
                        list.Add(reader["Firefighter_5"].ToString());
                        list.Add(reader["Firefighter_6"].ToString());
                        list.Add(reader["Firefighter_7"].ToString());
                        list.Add(reader["places"].ToString());
                    }


                }


            }
            catch
            {

                MessageBox.Show("Problem z pobraniem listy strażaków");
            }
            cnn.Close();
            return list;
        }

        public static List<string> SelectPFirefighterDepartureCard(int NumberDepartureCard, int Year)
        {
            List<string> list = new List<string>();
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            cnn.Open();
            if (NewOrOld(NumberDepartureCard, Year) == true)
            {

                try
                {


                    string sqlquery = "SELECT garage.Car_operational_number, vehicle_card.Driver, vehicle_card.Commander, vehicle_card.Firefighter_1, vehicle_card.Firefighter_2, vehicle_card.Firefighter_3, vehicle_card.Firefighter_4, vehicle_card.Firefighter_5, vehicle_card.Firefighter_6, vehicle_card.Firefighter_7 FROM departure_card, departure_card_vehicle, vehicle_card, garage WHERE garage.ID_garage = vehicle_card.ID_Vehicle AND departure_card.ID_departure_card = departure_card_vehicle.DepartureCard_ID and departure_card_vehicle.VehicleCard_ID = vehicle_card.ID_Vehicle_card AND departure_card.Departure_number = '" + NumberDepartureCard + "' AND departure_card.Year = '" + Year + "' ORDER BY garage.Car_operational_number ASC;";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            list.Add(reader["Car_operational_number"].ToString());
                            list.Add(reader["Driver"].ToString());
                            list.Add(reader["Commander"].ToString());
                            list.Add(reader["Firefighter_1"].ToString());
                            list.Add(reader["Firefighter_2"].ToString());
                            list.Add(reader["Firefighter_3"].ToString());
                            list.Add(reader["Firefighter_4"].ToString());
                            list.Add(reader["Firefighter_5"].ToString());
                            list.Add(reader["Firefighter_6"].ToString());
                            list.Add(reader["Firefighter_7"].ToString());
                        }


                    }


                }
                catch
                {
                    MessageBox.Show("Problem z pobraniem nowej karty wyjazdu");
                }
            }
            else
            {

                try
                {
                    string sqlquery = "SELECT 499z01_departure.Nick_Driver_01, 499z01_departure.Nick_Commander_01, 499z01_departure.Nick_Firefighter_01_1, 499z01_departure.Nick_Firefighter_01_2, 499z01_departure.Nick_Firefighter_01_3, 499z01_departure.Nick_Firefighter_01_4, 499z15_departure.Nick_Driver_15, 499z15_departure.Nick_Commander_15, 499z15_departure.Nick_Firefighter_15_1, 499z15_departure.Nick_Firefighter_15_2, 499z15_departure.Nick_Firefighter_15_3, 499z15_departure.Nick_Firefighter_15_4, 499z18_departure.Nick_Driver_18, 499z18_departure.Nick_Commander_18, 499z18_departure.Nick_Firefighter_18_1, 499z18_departure.Nick_Firefighter_18_2, 499z18_departure.Nick_Firefighter_18_3, 499z19_departure.Nick_Driver_19, 499z19_departure.Nick_Commander_19, 499z19_departure.Nick_Firefighter_19_1, 499z19_departure.Nick_Firefighter_19_2, 499z19_departure.Nick_Firefighter_19_3, 499z19_departure.Nick_Firefighter_19_4 FROM departure_card, firefighter, 499z01_departure, 499z15_departure, 499z18_departure, 499z19_departure WHERE departure_card.ID_499z01 = 499z01_departure.ID AND departure_card.ID_499z15 = 499z15_departure.ID AND departure_card.ID_499z18 = 499z18_departure.ID AND departure_card.ID_499z19 = 499z19_departure.ID  AND departure_card.Departure_number = '" + NumberDepartureCard + "' AND departure_card.Year = '" + Year + "';";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();

                        list.Add("499z01");
                        list.Add(reader["Nick_Driver_01"].ToString());
                        list.Add(reader["Nick_Commander_01"].ToString());
                        list.Add(reader["Nick_Firefighter_01_1"].ToString());
                        list.Add(reader["Nick_Firefighter_01_2"].ToString());
                        list.Add(reader["Nick_Firefighter_01_3"].ToString());
                        list.Add(reader["Nick_Firefighter_01_4"].ToString());
                        list.Add("499z15");
                        list.Add(reader["Nick_Driver_15"].ToString());
                        list.Add(reader["Nick_Commander_15"].ToString());
                        list.Add(reader["Nick_Firefighter_15_1"].ToString());
                        list.Add(reader["Nick_Firefighter_15_2"].ToString());
                        list.Add(reader["Nick_Firefighter_15_3"].ToString());
                        list.Add(reader["Nick_Firefighter_15_4"].ToString());
                        list.Add("499z18");
                        list.Add(reader["Nick_Firefighter_15_4"].ToString());
                        list.Add(reader["Nick_Driver_18"].ToString());
                        list.Add(reader["Nick_Commander_18"].ToString());
                        list.Add(reader["Nick_Firefighter_18_1"].ToString());
                        list.Add(reader["Nick_Firefighter_18_2"].ToString());
                        list.Add(reader["Nick_Firefighter_18_3"].ToString());
                        list.Add("499z19");
                        list.Add(reader["Nick_Driver_19"].ToString());
                        list.Add(reader["Nick_Commander_19"].ToString());
                        list.Add(reader["Nick_Firefighter_19_1"].ToString());
                        list.Add(reader["Nick_Firefighter_19_2"].ToString());
                        list.Add(reader["Nick_Firefighter_19_3"].ToString());
                        list.Add(reader["Nick_Firefighter_19_4"].ToString());
                    }


                }
                catch
                {
                    MessageBox.Show("Problem z pobraniem starej karty wyajzdu");
                }
            }

            cnn.Close();




            return list;
        }

        public static int SelectFireFighterFromTruck(List<string> Vehicle)
        {
            int ID_Vehicle;
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            try
            {

                cnn.Open();

                string sqlquery = "SELECT vehicle_card.ID_Vehicle_card FROM vehicle_card, garage WHERE vehicle_card.ID_Vehicle = garage.ID_garage AND garage.Car_operational_number = '" + Vehicle[0] + "' AND vehicle_card.Driver = '" + Vehicle[1] + "' AND vehicle_card.Commander = '" + Vehicle[2] + "' AND vehicle_card.Firefighter_1 = '" + Vehicle[3] + "' AND vehicle_card.Firefighter_2 = '" + Vehicle[4] + "' AND vehicle_card.Firefighter_3 = '" + Vehicle[5] + "' AND vehicle_card.Firefighter_4 = '" + Vehicle[6] + "' AND vehicle_card.Firefighter_5 = '" + Vehicle[7] + "' AND vehicle_card.Firefighter_6 = '" + Vehicle[8] + "' AND vehicle_card.Firefighter_7 = '" + Vehicle[9] + "';";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();

                    ID_Vehicle = int.Parse(reader["ID_Vehicle_card"].ToString());
                }
                cnn.Close();

            }
            catch
            {
                cnn.Close();
                ID_Vehicle = NewVehicleForDeparture(Vehicle);

            }
            return ID_Vehicle;
        }

        public static int HowManyPlaces(int Vehicle)
        {
            int Places;
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            try
            {

                cnn.Open();

                string sqlquery = "SELECT garage.places FROM garage, vehicle_card WHERE vehicle_card.ID_Vehicle_card = " + Vehicle + " AND vehicle_card.ID_Vehicle = garage.ID_garage;";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();

                    Places = int.Parse(reader["places"].ToString());
                }
                cnn.Close();

            }
            catch
            {
                cnn.Close();
                return 0;
            }
            return Places;
        }

        private static int NewVehicleForDeparture(List<string> Vehicle)
        {
            int ID_Vehicle;
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            try
            {

                cnn.Open();
                int Cars = IDCars(Vehicle[0], true);
                string sqlquery = "INSERT INTO `vehicle_card`(`ID_Vehicle_card`, `ID_Vehicle`, `Driver`, `Commander`, `Firefighter_1`, `Firefighter_2`, `Firefighter_3`, `Firefighter_4`, `Firefighter_5`, `Firefighter_6`, `Firefighter_7`) VALUES ('','" + Cars + "','" + Vehicle[1] + "','" + Vehicle[2] + "','" + Vehicle[3] + "','" + Vehicle[4] + "','" + Vehicle[5] + "','" + Vehicle[6] + "','" + Vehicle[7] + "','" + Vehicle[8] + "','" + Vehicle[9] + "')";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                }
                cnn.Close();

                ID_Vehicle = SelectFireFighterFromTruck(Vehicle);

            }
            catch
            {
                cnn.Close();
                MessageBox.Show("Brak możliwości stworzenia nowego zespołu pojazdu");
                ID_Vehicle = 0;
            }
            return ID_Vehicle;
        }

        public static int IDCars(string operational_number, bool ShowMessage)
        {
            int ID_Vehicle;
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            try
            {

                cnn.Open();

                string sqlquery = "SELECT garage.ID_garage FROM garage WHERE garage.Car_operational_number = '" + operational_number + "';";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();

                    ID_Vehicle = int.Parse(reader["ID_garage"].ToString());
                }
                cnn.Close();
            }
            catch
            {
                cnn.Close();
                if (ShowMessage == true)
                {
                    MessageBox.Show("Problem ze znalezieniem wozu");
                }
                ID_Vehicle = 0;
            }

            return ID_Vehicle;
        }

        public static void AddVehicleToDepartureCard(int ID_Departure_Card, int ID_Vehicle)
        {

            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open();
                string sqlquery = $"SELECT departure_card_vehicle.DepartureCard_ID, departure_card_vehicle.VehicleCard_ID FROM departure_card_vehicle WHERE departure_card_vehicle.DepartureCard_ID = {ID_Departure_Card} AND departure_card_vehicle.VehicleCard_ID = {ID_Vehicle}";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                    reader.GetInt32("DepartureCard_ID");
                }
                cnn.Close();
            }
            catch
            {
                cnn.Close();
                cnn.Open();
                string sqlquery = $"INSERT INTO `departure_card_vehicle`(`DepartureCard_ID`, `VehicleCard_ID`) VALUES ({ID_Departure_Card},{ID_Vehicle})";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                }
                cnn.Close();
            }
        }
        #endregion

        #region Car Management
        public List<string> SelectVehicle()
        {
            var Vehicle = new List<string>();
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            Vehicle.Add("");
            try
            {
                cnn.Open();
                string sqlquery = "SELECT garage.Car_operational_number FROM garage ORDER BY garage.Car_operational_number ASC;";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Vehicle.Add(reader.GetString("Car_operational_number"));
                    }
                }
                cnn.Close();
            }
            catch
            {
                cnn.Close();
                MessageBox.Show("Problem z pobraniem aut");
            }
            return Vehicle;
        }


        public List<string> SelectInformationVehicle(string OperationalNumber)
        {
            var Vehicle = new List<string>();
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);

            try
            {
                cnn.Open();
                string sqlquery = $"SELECT garage.Car_brand, garage.Car_model, garage.Year_car_production, garage.Year_purchase_car, garage.Car_operational_number, garage.Car_markings, garage.Car_review, garage.places, garage.status_vehicle, garage.Category FROM garage WHERE garage.Car_operational_number = '{OperationalNumber}';";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Vehicle.Add(reader["Car_brand"].ToString());
                        Vehicle.Add(reader["Car_model"].ToString());
                        Vehicle.Add(reader["Year_car_production"].ToString());
                        Vehicle.Add(reader["Year_purchase_car"].ToString());
                        Vehicle.Add(reader["Car_operational_number"].ToString());
                        Vehicle.Add(reader["Car_markings"].ToString());
                        Vehicle.Add(reader["Car_review"].ToString());
                        Vehicle.Add(reader["places"].ToString());
                        Vehicle.Add(StatusVehicleName(int.Parse(reader["status_vehicle"].ToString())));
                        Vehicle.Add(reader["Category"].ToString());
                    }
                }
                cnn.Close();
            }
            catch
            {
                cnn.Close();
                MessageBox.Show("Problem z pobraniem informacji o aucie");
            }
            return Vehicle;
        }

        public void InsertVehicle(List<string> NewVehicle)
        {
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open();
                string sqlquery = $"INSERT INTO `garage`(`ID_garage`, `Car_brand`, `Car_model`, `Year_car_production`, `Year_purchase_car`, `Car_operational_number`, `Car_markings`, `Car_review`, `places`, `status_vehicle`, `Category`) VALUES ('','{NewVehicle[0]}','{NewVehicle[1]}','{NewVehicle[2]}','{NewVehicle[3]}','{NewVehicle[4]}','{NewVehicle[5]}','{NewVehicle[6]}','{NewVehicle[7]}','{StatusVehicle(NewVehicle[8])}','{NewVehicle[9]}')";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                }
                cnn.Close();
            }
            catch
            {
                cnn.Close();
                MessageBox.Show("Brak możliwości dodania nowego wozu");
            }
        }
        public void UpdateVehicle(List<string> NewVehicle)
        {
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open();
                string sqlquery = $"UPDATE `garage` SET `Car_brand`='{NewVehicle[0]}',`Car_model`='{NewVehicle[1]}',`Year_car_production`='{NewVehicle[2]}',`Year_purchase_car`='{NewVehicle[3]}',`Car_markings`='{NewVehicle[5]}',`Car_review`='{NewVehicle[6]}',`places`='{NewVehicle[7]}',`status_vehicle`='{StatusVehicle(NewVehicle[8])}',`Category`='{NewVehicle[9]}' WHERE garage.Car_operational_number = '{NewVehicle[4]}'";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                }
                cnn.Close();
            }
            catch
            {
                cnn.Close();
                MessageBox.Show("Brak możliwości aktualizacji informacji na temat wozu");
            }
        }

        public int StatusVehicle(string NameStatus)
        {
            int NumberStatus;
            MySqlConnection cnn;
            try
            {

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = $"SELECT status_vehicle.ID_status_vehicle FROM status_vehicle WHERE status_vehicle.Name_status_vehicle = '{NameStatus}'";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();

                    NumberStatus = reader.GetInt16("ID_status_vehicle");
                }
                cnn.Close();
                return NumberStatus;
            }
            catch
            {
                return 0;
            }
        }

        public string StatusVehicleName(int ID_Status)
        {
            string NameStatus;
            MySqlConnection cnn;
            try
            {

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = $"SELECT status_vehicle.Name_status_vehicle FROM status_vehicle WHERE status_vehicle.ID_status_vehicle = {ID_Status}";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();

                    NameStatus = reader.GetString("Name_status_vehicle");
                }
                cnn.Close();
                return NameStatus;
            }
            catch
            {
                return "";
            }
        }

        #endregion
        #region Rate Management
        public List<string> GetRateName()
        {
            List<string> Rate = new List<string>();
            Rate.Add("");
            MySqlConnection cnn;
            try
            {
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "SELECT rate.Name FROM rate";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Rate.Add(reader.GetString("Name"));

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem z danych na temat nazw ekwiwalentów");
            }
            return Rate;
        }
        public List<string> GetRate()
        {
            List<string> Rate = new List<string>();
            MySqlConnection cnn;
            try
            {
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "SELECT rate.Rate FROM rate";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Rate.Add(reader.GetInt16("Rate").ToString());

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem z danych na temat kwot ekwiwalentu");
                Rate.Add("0");
                Rate.Add("0");
                Rate.Add("0");
            }
            return Rate;
        }
        public List<string> GetRateType()
        {
            List<string> Rate = new List<string>();
            MySqlConnection cnn;
            try
            {
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "SELECT incident_type.Name_Type_Incident, Rate.Name FROM incident_type, Rate WHERE incident_type.ID_Rate = Rate.ID_Rate";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Rate.Add(reader.GetString("Name"));

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem z danych na temat rodzaju ekwiwalentu dla danego typu wyjazdu");
                Rate.Add("Brak");
                Rate.Add("Brak");
                Rate.Add("Brak");
                Rate.Add("Brak");
                Rate.Add("Brak");
                Rate.Add("Brak");
                Rate.Add("Brak");
                Rate.Add("Brak");
                Rate.Add("Brak");
            }
            return Rate;
        }
        public void UpdateRateType(int IDType, string NameRate)
        {
            int ID_Rate;

            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open();
                string sqlquery = $"SELECT rate.ID_Rate FROM rate WHERE rate.Name = '{NameRate}'";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();

                    ID_Rate = reader.GetInt32("ID_Rate");
                }
                cnn.Close();

                cnn.Open();
                sqlquery = $"UPDATE `incident_type` SET `ID_Rate`='{ID_Rate}' WHERE incident_type.ID = {IDType}";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();

                }
                cnn.Close();

            }
            catch
            {
                cnn.Close();
                MessageBox.Show("Brak możliwości aktualizacji danych");
            }
        }

        public void UpdateRate(int IDRate, string Rate)
        {
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open();
                string sqlquery = $"UPDATE `rate` SET `Rate`='{Rate}' WHERE rate.ID_Rate = {IDRate}";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();

                }
                cnn.Close();

            }
            catch
            {
                cnn.Close();
                MessageBox.Show("Brak możliwości aktualizacji danych");
            }
        }

        #endregion
        #region EmailManagement
        public static List<string> SelectEmail()
        {
            var List = new List<string>();
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open();
                string sqlquery = $"SELECT email.Adress FROM email";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        List.Add(reader.GetString("Adress"));
                    }
                }
                cnn.Close();
            }
            catch
            {
                cnn.Close();
                MessageBox.Show("Nie można pobrać adresów email");
            }
            return List;

        }

        public void AddEmail(string Email)
        {
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open();
                string sqlquery = $"INSERT INTO `email`(`ID_Email`, `Adress`) VALUES ('[value-1]','{Email}')";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                }
                cnn.Close();
            }
            catch
            {
                cnn.Close();
                MessageBox.Show("Brak możliwości dodania nowego maila");
            }
        }
        public void RemoveEmail(string Email)
        {
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open();
                string sqlquery = $"DELETE FROM `email` WHERE email.Adress = '{Email}'";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                }
                cnn.Close();
            }
            catch
            {
                cnn.Close();
                MessageBox.Show("Brak możliwości usunięcia Email");
            }
        }


        #endregion


        #region CheckReview

        public static void UpdatePasswordHashByLogin(string login, string newHash)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            using var cmd = new MySqlCommand(
                "UPDATE users SET Password = @h WHERE Login = @l LIMIT 1;", conn);
            cmd.Parameters.AddWithValue("@h", newHash);
            cmd.Parameters.AddWithValue("@l", login);
            cmd.ExecuteNonQuery();
        }

        public static string SelectPassword(string Login)
        {
            string Password = "";
           
            MySqlConnection cnn;
            try
            {

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = "SELECT Password  FROM `users` WHERE `Login` LIKE '" + Login + "'";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();

                    Password = reader["Password"].ToString();
                }
                cnn.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            return Password;
        }

        public static string[,] CheckFirefighter()
        {
            string query = "SELECT firefighter.Nick, firefighter.Next_medical_exams FROM firefighter WHERE firefighter.ID_Status = 1 ORDER by firefighter.Nick ASC;";

            // Połącz się z bazą danych
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Wykonaj zapytanie
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Sprawdź, czy są wiersze do pobrania
                            if (reader.HasRows)
                            {
                                // Pobierz liczbę kolumn
                                int kolumny = reader.FieldCount;

                                // Skopiuj dane do listy wierszy (możemy wcześniej nie znać liczby wierszy)
                                var listaWierszy = new System.Collections.Generic.List<string[]>();

                                while (reader.Read())
                                {
                                    string[] wiersz = new string[kolumny];
                                    for (int i = 0; i < kolumny; i++)
                                    {
                                        wiersz[i] = reader[i].ToString();
                                    }
                                    listaWierszy.Add(wiersz);
                                }

                                // Konwertuj listę wierszy do tablicy dwuwymiarowej
                                int wiersze = listaWierszy.Count;
                                string[,] wynik = new string[wiersze, kolumny];

                                for (int i = 0; i < wiersze; i++)
                                {
                                    for (int j = 0; j < kolumny; j++)
                                    {
                                        wynik[i, j] = listaWierszy[i][j];
                                    }
                                }

                                return wynik;
                            }
                            else
                            {
                                return null; // Brak danych
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Błąd: " + ex.Message);
                    return null;
                }
            }
        }
        public static string[,] CheckVehicle()
        {
            string query = "SELECT garage.Car_operational_number, garage.Car_review FROM garage WHERE garage.status_vehicle = 1";

            // Połącz się z bazą danych
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Wykonaj zapytanie
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Sprawdź, czy są wiersze do pobrania
                            if (reader.HasRows)
                            {
                                // Pobierz liczbę kolumn
                                int kolumny = reader.FieldCount;

                                // Skopiuj dane do listy wierszy (możemy wcześniej nie znać liczby wierszy)
                                var listaWierszy = new System.Collections.Generic.List<string[]>();

                                while (reader.Read())
                                {
                                    string[] wiersz = new string[kolumny];
                                    for (int i = 0; i < kolumny; i++)
                                    {
                                        wiersz[i] = reader[i].ToString();
                                    }
                                    listaWierszy.Add(wiersz);
                                }

                                // Konwertuj listę wierszy do tablicy dwuwymiarowej
                                int wiersze = listaWierszy.Count;
                                string[,] wynik = new string[wiersze, kolumny];

                                for (int i = 0; i < wiersze; i++)
                                {
                                    for (int j = 0; j < kolumny; j++)
                                    {
                                        wynik[i, j] = listaWierszy[i][j];
                                    }
                                }

                                return wynik;
                            }
                            else
                            {
                                return null; // Brak danych
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Błąd: " + ex.Message);
                    return null;
                }
            }
        }

        #endregion

        public static string GetCommnader(int DepartureNumber, int Year)
        {
            string Commander;
            MySqlConnection cnn;
            try
            {

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = $"SELECT firefighter.Nick FROM firefighter , departure_card WHERE firefighter.ID_firefighter = departure_card.ID_Departure_commander AND departure_card.Departure_number = {DepartureNumber} AND departure_card.Year = {Year}";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();

                    Commander = reader.GetString("Nick");
                }
                cnn.Close();
                return Commander;
            }
            catch
            {
                return "";
            }

        }



        public static void SQLVoid(string sqlquery)
        {
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open();

                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                }
                cnn.Close();
            }
            catch
            {
                cnn.Close();
                MessageBox.Show("Brak możliwości wykonania polecenia SQL");
            }

        }

        public List<int> DepartureWithoutSending()
        {
            var Resualt = new List<int>();
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);

            try
            {


                cnn.Open();
                string sqlquery = "SELECT departure_card.ID_departure_card FROM departure_card WHERE departure_card.Email_send = 0";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Resualt.Add(reader.GetInt16("ID_departure_card"));
                    }
                }
                cnn.Close();
            }
            catch
            {
                cnn.Close();
                MessageBox.Show("Problem z pobraniem listy wyjazdów bez wyslanego maila.");
            }
            return Resualt;
        }

        public List<string> InfoResendEmail(int ID_Departure)
        {
            var list = new List<string>();
            MySqlConnection cnn;
            try
            {
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = $"SELECT departure_card.Departure_number, departure_card.Year, city.Name_city, street.Name_street , incident.Name_incident, departure_card.Mounth FROM incident, place, city, street, departure_card WHERE departure_card.ID_departure_card = {ID_Departure} and departure_card.ID_place_departure = place.ID_place AND place.ID_City = city.ID_city AND place.ID_Street = street.ID_street AND departure_card.ID_reason_departure = incident.ID_incident";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(reader["Departure_number"].ToString());
                        list.Add(reader["Year"].ToString());
                        list.Add(reader["Name_city"].ToString());
                        list.Add(reader["Name_street"].ToString());
                        list.Add(reader["Name_incident"].ToString());
                        list.Add(reader["Mounth"].ToString());

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem z pobraniem danych na temat podstawowych informacji");
            }
            return list;
        }

        public static int SelectIDDepartureCard(int DepartureNumber, int Year)
        {
            int ID;
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open();
                string sqlquery = "SELECT departure_card.ID_departure_card FROM departure_card WHERE departure_card.Departure_number = " + DepartureNumber + " AND departure_card.Year = " + Year;
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                    ID = reader.GetInt16("ID_departure_card");
                }
                cnn.Close();
            }
            catch
            {
                cnn.Close();
                MessageBox.Show("Problem z pobraniem numeru identyfikacyjnego wyjazdu");
                return 0;
            }

            return ID;
        }

        public static int SelectIDDepartureCard(int Year)
        {
            int ID;
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open();
                string sqlquery = "SELECT MAX(departure_card.ID_departure_card) FROM departure_card WHERE departure_card.Year = " + Year;
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                    ID = reader.GetInt16("MAX(departure_card.ID_departure_card)");
                }
                cnn.Close();
            }
            catch
            {
                cnn.Close();
                MessageBox.Show("Problem z pobraniem numeru identyfikacyjnego wyjazdu");
                return 0;
            }

            return ID;
        }

        public void UpdateStatusEmail(int ID_Departure)
        {
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open();
                string sqlquery = $"UPDATE `departure_card` SET `Email_send`= 1 WHERE departure_card.ID_departure_card = {ID_Departure}";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                }
                cnn.Close();
            }
            catch
            {
                cnn.Close();
                MessageBox.Show("Brak możliwości zmiany statusu maila.\nMożlwe, że mail zostanie wysłany ponownie wraz z włączeniem aplikacji");
            }

        }

        public static bool DepartureOrNot(int ID_Reason)
        {
            bool status;

            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open();
                string sqlquery = $"SELECT rate.ID_Rate FROM rate, incident, incident_type WHERE incident_type.ID_Rate = rate.ID_Rate AND incident.ID_Incident_Type = incident_type.ID AND incident.ID_incident = {ID_Reason};";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                    if (reader.GetInt16("ID_Rate") == 1)
                    {
                        status = true;
                    }
                    else
                    {

                        status = false;
                    }
                }
                cnn.Close();
            }
            catch
            {
                cnn.Close();
                MessageBox.Show("Nie mogę rozpoznać czy to był wyjazd z wezwania czy nie");
                return false;
            }

            return status;
        }

        public static bool CheckFiremanExist(string FireNick)
        {
            bool status;
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open();
                string sqlquery = $"SELECT ID_firefighter from firefighter where firefighter.Nick = '"+FireNick+"';";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                    reader.GetInt16("ID_firefighter");
                    status = true;
                }
                cnn.Close();
            }
            catch
            {
                cnn.Close();
                status = false;
            }
            return status;
        }

        public static bool CheckCommanderExist(string FireNick)
        {
            bool status;
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open();
                string sqlquery = $"SELECT f.ID_firefighter FROM firefighter f JOIN training t ON f.ID_firefighter = t.ID_firefighter WHERE f.Nick LIKE '"+FireNick+"' AND (t.Commander = 1 OR t.Head = 1);";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                    reader.GetInt16("ID_firefighter");
                    status = true;
                }
                cnn.Close();
            }
            catch
            {
                cnn.Close();
                status = false;
            }
            return status;
        }

        public static void UpdatePayCheck(int ID_Firefighter, int Year, int Month, int Time, int ID_Reason, bool plusminus)
        {
            int ID_Paycheck;
            int NewTime;

            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open();
                string sqlquery = $"SELECT paycheck.ID_paycheck, paycheck.Time FROM paycheck, incident_type, incident WHERE incident.ID_incident = {ID_Reason} AND incident.ID_Incident_Type = paycheck.ID_incident_type AND paycheck.ID_Firefighter = {ID_Firefighter} AND paycheck.Year = {Year} AND paycheck.Month = {Month};";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                    ID_Paycheck = int.Parse(reader["ID_paycheck"].ToString());
                    NewTime = int.Parse(reader["Time"].ToString());
                }
                cnn.Close();

                if (plusminus == true)
                {
                    NewTime += Time;
                }
                else
                {
                    NewTime -= Time;
                }

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                sqlquery = $"UPDATE `paycheck` SET `Time`={NewTime} WHERE paycheck.ID_paycheck = {ID_Paycheck};";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();

                }
                cnn.Close();


            }
            catch
            {
                cnn.Close();
                int ID;
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = $"SELECT incident.ID_Incident_Type FROM incident WHERE incident.ID_incident = {ID_Reason}";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                    ID = int.Parse(reader["ID_Incident_Type"].ToString());
                }
                cnn.Close();



                cnn.Open();
                sqlquery = $"INSERT INTO `paycheck`(`ID_paycheck`, `ID_Firefighter`, `Year`, `Month`, `ID_incident_type`, `Time`) VALUES ('',{ID_Firefighter},{Year},{Month},{ID},{Time});";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                }
                cnn.Close();


            }
        }

        #region Ranking
       
        #region Ranking - Incident
        public static void UpdateToRankingIncident(int ID_Incident, int Year, bool plusminus, bool ID_Reason_Bool)
        {
            if (ID_Reason_Bool == true)
            {
                MySqlConnection cnn;
                cnn = new MySqlConnection(connectionString);
                try
                {
                    int ID_Ranking;
                    int NumberDep;
                    string sqlquery = "";

                    cnn.Open();
                    sqlquery = "SELECT incident_ranking.ID_incident_ranking, incident_ranking.Number_departures FROM incident_ranking WHERE incident_ranking.ID_incident = " + ID_Incident + " AND incident_ranking.Year = " + Year + ";";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();
                        ID_Ranking = int.Parse(reader["ID_incident_ranking"].ToString());
                        NumberDep = int.Parse(reader["Number_departures"].ToString());
                    }
                    cnn.Close();

                    if (plusminus == true)
                    {
                        NumberDep++;
                    }
                    else
                    {
                        NumberDep--;
                    }

                    cnn.Open();
                    sqlquery = "UPDATE `incident_ranking` SET `Number_departures`=" + NumberDep + " WHERE incident_ranking.ID_incident_ranking = " + ID_Ranking + ";";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();
                    }
                    cnn.Close();
                    try
                    {

                        cnn.Open();
                        sqlquery = "SELECT ranking_incident_type.ID_ranking_incident_type, ranking_incident_type.Number_departures FROM incident, incident_type, ranking_incident_type WHERE incident.ID_Incident_Type = incident_type.ID AND ranking_incident_type.ID_incident_type = incident_type.ID AND incident.ID_incident = " + ID_Incident + " AND ranking_incident_type.Year = " + Year + ";";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();
                            ID_Ranking = int.Parse(reader["ID_ranking_incident_type"].ToString());
                            NumberDep = int.Parse(reader["Number_departures"].ToString());
                        }
                        cnn.Close();

                        if (plusminus == true)
                        {
                            NumberDep++;
                        }
                        else
                        {
                            NumberDep--;
                        }

                        cnn.Open();
                        sqlquery = "UPDATE `ranking_incident_type` SET `Number_departures`=" + NumberDep + " WHERE ranking_incident_type.ID_ranking_incident_type = " + ID_Ranking + ";";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();
                        }
                        cnn.Close();
                    }
                    catch
                    {
                        cnn.Close();
                        int ID;

                        cnn.Open();
                        sqlquery = "SELECT incident.ID_Incident_Type FROM incident WHERE incident.ID_incident = " + ID_Incident + ";";
                        using (var command = new MySqlCommand(sqlquery, cnn))
                        {
                            var reader = command.ExecuteReader();
                            reader.Read();
                            ID = int.Parse(reader["ID_Incident_Type"].ToString());
                        }
                        cnn.Close();





                        cnn.Open();
                        sqlquery = "INSERT INTO `ranking_incident_type`(`ID_ranking_incident_type`, `ID_incident_type`, `Year`, `Number_departures`) VALUES (''," + ID + "," + Year + ",1);";
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
                    cnn.Close();
                    cnn.Open();
                    string sqlquery = "INSERT INTO `incident_ranking`(`ID_incident_ranking`, `ID_incident`, `Year`, `Number_departures`) VALUES (''," + ID_Incident + "," + Year + ",0);";
                    using (var command = new MySqlCommand(sqlquery, cnn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();
                    }
                    cnn.Close();

                    UpdateToRankingIncident(ID_Incident, Year, true, ID_Reason_Bool);
                }
            }


        }
        #endregion
        #region Ranking - Firefighter
        public static List<string> GetFirefighter(int ID_Vehicle)
        {
            List<string> list = new List<string>();
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            try
            {
                string sqlquery = "";

                cnn.Open();
                sqlquery = "SELECT vehicle_card.Driver, vehicle_card.Commander, vehicle_card.Firefighter_1, vehicle_card.Firefighter_2, vehicle_card.Firefighter_3, vehicle_card.Firefighter_4, vehicle_card.Firefighter_5, vehicle_card.Firefighter_6, vehicle_card.Firefighter_7 FROM vehicle_card WHERE vehicle_card.ID_Vehicle_card = " + ID_Vehicle + ";";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(reader["Driver"].ToString());
                        list.Add(reader["Commander"].ToString());
                        list.Add(reader["Firefighter_1"].ToString());
                        list.Add(reader["Firefighter_2"].ToString());
                        list.Add(reader["Firefighter_3"].ToString());
                        list.Add(reader["Firefighter_4"].ToString());
                        list.Add(reader["Firefighter_5"].ToString());
                        list.Add(reader["Firefighter_6"].ToString());
                        list.Add(reader["Firefighter_7"].ToString());
                    }
                }
                cnn.Close();
            }
            catch
            {
                cnn.Close();
                MessageBox.Show("Problem z pobraniem danych na temat strażaków na akcje do rankingu");

            }
            return list;
        }
        


        #endregion
        #endregion

        #region Equivalent
        public static List<List<string>> DataEquivalent(int Month, int Year, int Ratee)
        {
            List<string> Name = new List<string>();
            List<string> Lastname = new List<string>();
            List<string> Departure = new List<string>();
            List<string> Rate = new List<string>();
            List<List<string>> tablica = new List<List<string>>();
            MySqlConnection cnn;
            try
            {

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = $"WITH filtered_departures AS (SELECT vc.Driver, vc.Commander, vc.Firefighter_1, vc.Firefighter_2, vc.Firefighter_3, vc.Firefighter_4, vc.Firefighter_5, vc.Firefighter_6, vc.Firefighter_7, dc.hour FROM departure_card dc LEFT JOIN departure_card_vehicle dcv ON dc.ID_departure_card = dcv.DepartureCard_ID LEFT JOIN vehicle_card vc ON dcv.VehicleCard_ID = vc.ID_Vehicle_card LEFT JOIN incident inc ON dc.ID_reason_departure = inc.ID_incident LEFT JOIN incident_type it ON inc.ID_Incident_Type = it.ID WHERE dc.Year = " + Year + " AND dc.Mounth = " + Month + " AND it.ID_Rate = " + Ratee + "), all_departure AS (SELECT Driver AS name, hour FROM filtered_departures UNION ALL SELECT Commander, hour FROM filtered_departures UNION ALL SELECT Firefighter_1, hour FROM filtered_departures UNION ALL SELECT Firefighter_2, hour FROM filtered_departures UNION ALL SELECT Firefighter_3, hour FROM filtered_departures UNION ALL SELECT Firefighter_4, hour FROM filtered_departures UNION ALL SELECT Firefighter_5, hour FROM filtered_departures UNION ALL SELECT Firefighter_6, hour FROM filtered_departures UNION ALL SELECT Firefighter_7, hour FROM filtered_departures), departure_h AS (SELECT name, SUM(hour) AS departure_hours FROM all_departure WHERE name IS NOT NULL AND name != '' AND name != '0' GROUP BY name) SELECT f.name, f.last_name, dh.departure_hours, rate.Rate FROM departure_h dh LEFT JOIN firefighter f ON dh.name = f.Nick LEFT JOIN rate ON rate.ID_Rate = " + Ratee + " ORDER BY dh.departure_hours DESC, f.name;";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Name.Add(reader["name"].ToString());
                        Lastname.Add(reader["last_name"].ToString());
                        Departure.Add(reader["departure_hours"].ToString());
                        Rate.Add(reader["Rate"].ToString());

                    }
                }



                tablica.Add(Name);
                tablica.Add(Lastname);
                tablica.Add(Departure);
                tablica.Add(Rate);

            }
            catch (Exception)
            {
                MessageBox.Show("Problem z pobraniem danych na temat podstawowych informacji");
            }

            return tablica;
        }

        public static List<List<string>> DataGminnyEquivalent(int Month, int Year, int Ratee)
        {
            List<string> Name = new List<string>();
            List<string> Lastname = new List<string>();
            List<string> Departure = new List<string>();
            List<string> Practice = new List<string>();
            List<string> Training = new List<string>();
            List<List<string>> tablica = new List<List<string>>();
            MySqlConnection cnn;
            try
            {

                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = $"WITH filtered_departures AS (SELECT vc.Driver, vc.Commander, vc.Firefighter_1, vc.Firefighter_2, vc.Firefighter_3, vc.Firefighter_4, vc.Firefighter_5, vc.Firefighter_6, vc.Firefighter_7, dc.hour FROM departure_card dc LEFT JOIN departure_card_vehicle dcv ON dc.ID_departure_card = dcv.DepartureCard_ID LEFT JOIN vehicle_card vc ON dcv.VehicleCard_ID = vc.ID_Vehicle_card LEFT JOIN incident inc ON dc.ID_reason_departure = inc.ID_incident LEFT JOIN incident_type it ON inc.ID_Incident_Type = it.ID WHERE dc.Year = " + Year + " AND dc.Mounth = " + Month + " AND it.ID_Rate = 1), filtered_practice AS (SELECT vc.Driver, vc.Commander, vc.Firefighter_1, vc.Firefighter_2, vc.Firefighter_3, vc.Firefighter_4, vc.Firefighter_5, vc.Firefighter_6, vc.Firefighter_7, dc.hour FROM departure_card dc LEFT JOIN departure_card_vehicle dcv ON dc.ID_departure_card = dcv.DepartureCard_ID LEFT JOIN vehicle_card vc ON dcv.VehicleCard_ID = vc.ID_Vehicle_card LEFT JOIN incident inc ON dc.ID_reason_departure = inc.ID_incident LEFT JOIN incident_type it ON inc.ID_Incident_Type = it.ID WHERE dc.Year = " + Year + " AND dc.Mounth = " + Month + " AND it.ID_Rate = 2), filtered_training AS (SELECT vc.Driver, vc.Commander, vc.Firefighter_1, vc.Firefighter_2, vc.Firefighter_3, vc.Firefighter_4, vc.Firefighter_5, vc.Firefighter_6, vc.Firefighter_7, dc.hour FROM departure_card dc LEFT JOIN departure_card_vehicle dcv ON dc.ID_departure_card = dcv.DepartureCard_ID LEFT JOIN vehicle_card vc ON dcv.VehicleCard_ID = vc.ID_Vehicle_card LEFT JOIN incident inc ON dc.ID_reason_departure = inc.ID_incident LEFT JOIN incident_type it ON inc.ID_Incident_Type = it.ID WHERE dc.Year = " + Year + " AND dc.Mounth = " + Month + " AND it.ID_Rate = 3), all_departure AS (SELECT Driver AS name, hour FROM filtered_departures UNION ALL SELECT Commander, hour FROM filtered_departures UNION ALL SELECT Firefighter_1, hour FROM filtered_departures UNION ALL SELECT Firefighter_2, hour FROM filtered_departures UNION ALL SELECT Firefighter_3, hour FROM filtered_departures UNION ALL SELECT Firefighter_4, hour FROM filtered_departures UNION ALL SELECT Firefighter_5, hour FROM filtered_departures UNION ALL SELECT Firefighter_6, hour FROM filtered_departures UNION ALL SELECT Firefighter_7, hour FROM filtered_departures), all_practice AS (SELECT Driver AS name, hour FROM filtered_practice UNION ALL SELECT Commander, hour FROM filtered_practice UNION ALL SELECT Firefighter_1, hour FROM filtered_practice UNION ALL SELECT Firefighter_2, hour FROM filtered_practice UNION ALL SELECT Firefighter_3, hour FROM filtered_practice UNION ALL SELECT Firefighter_4, hour FROM filtered_practice UNION ALL SELECT Firefighter_5, hour FROM filtered_practice UNION ALL SELECT Firefighter_6, hour FROM filtered_practice UNION ALL SELECT Firefighter_7, hour FROM filtered_practice), all_training AS (SELECT Driver AS name, hour FROM filtered_training UNION ALL SELECT Commander, hour FROM filtered_training UNION ALL SELECT Firefighter_1, hour FROM filtered_training UNION ALL SELECT Firefighter_2, hour FROM filtered_training UNION ALL SELECT Firefighter_3, hour FROM filtered_training UNION ALL SELECT Firefighter_4, hour FROM filtered_training UNION ALL SELECT Firefighter_5, hour FROM filtered_training UNION ALL SELECT Firefighter_6, hour FROM filtered_training UNION ALL SELECT Firefighter_7, hour FROM filtered_training), departure_h AS (SELECT name, SUM(hour) AS total_hours FROM all_departure WHERE name IS NOT NULL AND name != '' AND name != '0' GROUP BY name), practice_h AS (SELECT name, SUM(hour) AS total_hours FROM all_practice WHERE name IS NOT NULL AND name != '' AND name != '0' GROUP BY name), training_h AS (SELECT name, SUM(hour) AS total_hours FROM all_training WHERE name IS NOT NULL AND name != '' AND name != '0' GROUP BY name), all_names AS (SELECT name FROM departure_h UNION SELECT name FROM practice_h UNION SELECT name FROM training_h), all_hours AS (SELECT n.name, COALESCE(d.total_hours, 0) AS departure_hours, COALESCE(p.total_hours, 0) AS practice_hours, COALESCE(t.total_hours, 0) AS training_hours FROM all_names n LEFT JOIN departure_h d ON n.name = d.name LEFT JOIN practice_h p ON n.name = p.name LEFT JOIN training_h t ON n.name = t.name) SELECT f.name, f.last_name, ah.departure_hours, ah.practice_hours, ah.training_hours FROM all_hours ah LEFT JOIN firefighter f ON ah.name = f.Nick ORDER BY ah.departure_hours DESC, f.name;";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Name.Add(reader["name"].ToString());
                        Lastname.Add(reader["last_name"].ToString());
                        Departure.Add(reader["departure_hours"].ToString());
                        Practice.Add(reader["practice_hours"].ToString());
                        Training.Add(reader["training_hours"].ToString());

                    }
                }



                tablica.Add(Name);
                tablica.Add(Lastname);
                tablica.Add(Departure);
                tablica.Add(Practice);
                tablica.Add(Training);

            }
            catch (Exception)
            {
                MessageBox.Show("Problem z pobraniem danych na temat podstawowych informacji");
            }

            return tablica;
        }
        public List<int> YearDeparture()
        {
            var Resualt = new List<int>();
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);

            try
            {


                cnn.Open();
                string sqlquery = "SELECT MAX(departure_card.Year), MIN(departure_card.Year) FROM departure_card";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Resualt.Add(int.Parse(reader["MAX(departure_card.Year)"].ToString()));
                        Resualt.Add(int.Parse(reader["MIN(departure_card.Year)"].ToString()));
                    }
                }
                cnn.Close();
            }
            catch
            {
                cnn.Close();
                MessageBox.Show("Problem z określeniem określeniem lat.");
            }
            return Resualt;
        }

        #endregion

        #region History

        public List<string[]> DownloadHistory(int howMany)
        {
            var ResultMatrix = new List<string[]>();
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);

            try
            {
                cnn.Open();
                string sqlquery = "SELECT departure_card.ID_departure_card, departure_card.Departure_number, departure_card.Year, departure_card.Departure_date, city.Name_city, street.Name_street, incident.Name_incident FROM departure_card, city, street, incident, place WHERE departure_card.ID_place_departure = place.ID_place AND departure_card.ID_reason_departure = incident.ID_incident AND place.ID_City = city.ID_city AND place.ID_Street = street.ID_street AND departure_card.ID_departure_card >= (SELECT MAX(ID_departure_card) - " + howMany + " FROM departure_card) ORDER BY ID_departure_card DESC";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        string[] row = new string[7];
                        row[0] = reader.GetInt32("ID_departure_card").ToString();
                        row[1] = reader.GetInt32("Departure_number").ToString();
                        row[2] = reader.GetInt32("Year").ToString();
                        row[3] = reader.GetString("Departure_date");
                        row[4] = reader.GetString("Name_city");
                        row[5] = reader.GetString("Name_street");
                        row[6] = reader.GetString("Name_incident");
                        ResultMatrix.Add(row);
                    }
                }
                cnn.Close();
            }
            catch
            {
                cnn.Close();
                MessageBox.Show("Problem z pobraniem danych do historii wyjazdu ");
            }
            return ResultMatrix;
        }

        public List<string> DownloadDepartureCard(string idDeparture)
        {
            var DataDeparture = new List<string>();
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);


            try
            {
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sqlquery = $"SELECT dc.Departure_number, dc.Year, dc.Departure_date, dc.Hour_departure, dc.Hour_arrival, dc.Hour, ct.Name_city, str.Name_street, dc.Trip, inct.Name_Type_Incident, inc.Name_incident FROM departure_card AS dc LEFT JOIN place AS pl ON dc.ID_place_departure = pl.ID_place LEFT JOIN city AS ct ON pl.ID_City = ct.ID_city LEFT JOIN street AS str ON pl.ID_Street = str.ID_street LEFT JOIN incident AS inc ON dc.ID_reason_departure = inc.ID_incident LEFT JOIN incident_type AS inct ON inc.ID_Incident_Type = inct.ID WHERE dc.ID_departure_card = " + idDeparture + ";";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DataDeparture.Add(reader["Departure_number"].ToString());
                        DataDeparture.Add(reader["Year"].ToString());
                        DataDeparture.Add(reader["Departure_date"].ToString());
                        DataDeparture.Add(reader["Hour_departure"].ToString());
                        DataDeparture.Add(reader["Hour_arrival"].ToString());
                        DataDeparture.Add(reader["Hour"].ToString());
                        DataDeparture.Add(reader["Name_city"].ToString());
                        DataDeparture.Add(reader["Name_street"].ToString());
                        DataDeparture.Add(reader["Trip"].ToString());
                        DataDeparture.Add(reader["Name_Type_Incident"].ToString());
                        DataDeparture.Add(reader["Name_incident"].ToString());


                    }
                }
            }
            catch
            {
                cnn.Close();
                MessageBox.Show("Problem z pobraniem danych karty wyjazdu ");
            }
            return DataDeparture;
        }

        public List<string[]> DownloadFirefighters(string idDeparture)
        {
            var ResultMatrix = new List<string[]>();
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);

            try
            {
                cnn.Open();
                string sqlquery = "SELECT gar.Car_operational_number, vc.Driver, vc.Commander, vc.Firefighter_1, vc.Firefighter_2, vc.Firefighter_3, vc.Firefighter_4, vc.Firefighter_5, vc.Firefighter_6, vc.Firefighter_7 FROM vehicle_card AS vc LEFT JOIN departure_card_vehicle AS dcv ON dcv.VehicleCard_ID = vc.ID_Vehicle_card LEFT JOIN garage AS gar ON vc.ID_Vehicle = gar.ID_garage WHERE dcv.DepartureCard_ID = " + idDeparture + ";";
                using (var command = new MySqlCommand(sqlquery, cnn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        string[] row = new string[10];
                        row[0] = reader.GetString("Car_operational_number");
                        row[1] = reader.GetString("Driver");
                        row[2] = reader.GetString("Commander");
                        row[3] = reader.GetString("Firefighter_1");
                        row[4] = reader.GetString("Firefighter_2");
                        row[5] = reader.GetString("Firefighter_3");
                        row[6] = reader.GetString("Firefighter_4");
                        row[7] = reader.GetString("Firefighter_5");
                        row[8] = reader.GetString("Firefighter_6");
                        row[9] = reader.GetString("Firefighter_7");
                        ResultMatrix.Add(row);
                    }
                }
                cnn.Close();
            }
            catch
            {
                cnn.Close();
                MessageBox.Show("Problem z pobraniem danych do historii wyjazdu ");
            }
            return ResultMatrix;
        }
        #endregion

    }
}

[TestFixture]
public class Test
{
    [Test]
    public void TestFirefighterID()
    {
        var result = SqlConnectorv2.CheckCommanderExist("Krzepiński Ł");
            
        Assert.That(result, Is.EqualTo(true));
    }




        [Test]
    public void TestID_Place()
    {


        var result = SqlConnectorv2.SelectPlace("Jeleń", "Ślimak");



        Assert.That(result, Is.EqualTo(220));
    }

    [Test]
    public void TestID_Reason()
    {


        var result = SqlConnectorv2.SelectReason("Pożaryyyyy", "Pożar kominka");



        Assert.That(result, Is.EqualTo(217));
    }
    [Test]
    public void TestGet()
    {


        var result = SqlConnectorv2.SelectIDDepartureCard(76, 2024);



        Assert.That(result, Is.EqualTo(718));
    }

}


