using FirefighterControlCenter.DataAccessLayer;
using FirefighterControlCenter.UserInterface.Programs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Net.Mail;
using System.Threading;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface.Programs
{
    internal class ProgramsDepartureCard
    {

        private SqlConnectorv2 SQL;
        private ErrorManager errorManager;
        public ProgramsDepartureCard()
        {
            SQL = new SqlConnectorv2();
            errorManager = new ErrorManager();

        }




        public void Email_send(string title, string filePath)
        {
            try
            {
                var password = SqlConnectorv2.SelectPasswordEmail();
                var emailAddresses = SqlConnectorv2.SelectEmail();

                using (var smtpServer = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpServer.Credentials = new System.Net.NetworkCredential("wyjazdyospbarlinek@gmail.com", password);
                    smtpServer.EnableSsl = true;

                    using (var mail = new MailMessage())
                    {
                        mail.From = new MailAddress("wyjazdyospbarlinek@gmail.com");
                        mail.Subject = title;
                        mail.Body = "W załączniku przesyłamy dokumentację wyjazdu."; // Warto dodać choć krótką treść

                        // Dodawanie odbiorców
                        foreach (var address in emailAddresses)
                        {
                            mail.To.Add(address);
                        }

                        // Bezpieczne dodawanie załącznika
                        if (File.Exists(filePath))
                        {
                            using (var attachment = new Attachment(filePath))
                            {
                                mail.Attachments.Add(attachment);
                                smtpServer.Send(mail);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nie znaleziono pliku załącznika pod adresem: " + filePath);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Błąd wysyłania e-maila: {e.Message}");
            }
        }
        public void Email_send(string title, string filePath, int ID_Departure)
        {
            try
            {
                var password = SqlConnectorv2.SelectPasswordEmail();
                var emailAddresses = SqlConnectorv2.SelectEmail();

                using (var smtpServer = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpServer.Credentials = new System.Net.NetworkCredential("wyjazdyospbarlinek@gmail.com", password);
                    smtpServer.EnableSsl = true;

                    using (var mail = new MailMessage())
                    {
                        mail.From = new MailAddress("wyjazdyospbarlinek@gmail.com");
                        mail.Subject = title;
                        mail.Body = "W załączniku przesyłamy dokumentację wyjazdu."; // Warto dodać choć krótką treść

                        // Dodawanie odbiorców
                        foreach (var address in emailAddresses)
                        {
                            mail.To.Add(address);
                        }

                        // Bezpieczne dodawanie załącznika
                        if (File.Exists(filePath))
                        {
                            using (var attachment = new Attachment(filePath))
                            {
                                mail.Attachments.Add(attachment);
                                smtpServer.Send(mail);
                                SQL.UpdateStatusEmail(ID_Departure);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nie znaleziono pliku załącznika pod adresem: " + filePath);
                        }
                    }
                }

                
            }
            catch (Exception e)
            {
                MessageBox.Show($"Błąd wysyłania e-maila: {e.Message}");
            }

        }
       
        public static int ShowMax(List<string> list)
        {
            int max = 0;

            for (int i = 1; i < list.Count; i += 2)
            {
                if (int.Parse(list[i]) > max)
                {
                    max = int.Parse(list[i]);
                }
            }
            return max;
        }
        public bool PrintNewDepartureCard(List<string> Basic, List<string> Place, List<string> Reason, List<string> Vehicle, string Commander)
        {

            int Time;
            int Year;
            int Month;
            int ID_Place;
            int ID_Reason;
            bool ID_Reason_Bool;
            int ID_Commander;
            List<int> ID_Vehicle;

            int test = 0;


            try
            {

                #region Basic Information - 0
                Time = MinuteToHour(DepartureArrivalToMinute(int.Parse(Basic[1]), int.Parse(Basic[2]), int.Parse(Basic[3]), int.Parse(Basic[4])));
                Year = ShowYear(Basic[5]);
                Month = ShowMounth(Basic[5]);
                test++;
                #endregion
                #region Place Information - 1 
                ID_Place = SqlConnectorv2.SelectPlace(Place[0], Place[1]);
                test++;
                #endregion
                #region Reason Information - 2
                ID_Reason = SqlConnectorv2.SelectReason(Reason[0], Reason[1]);
                ID_Reason_Bool = SqlConnectorv2.DepartureOrNot(ID_Reason);
                if (ID_Reason_Bool == false)
                {
                    Basic[0] = "0";
                }
                test++;
                #endregion
                #region Vehicle Information - 3
                ID_Vehicle = SelectedFirefighterFromTruck(Vehicle);
                ID_Commander = SqlConnectorv2.SelectIdFireFighter(Commander);
                test++;
                #endregion

               
                PDF.CreatePDFv2(Basic, Place, Reason, ID_Vehicle, Year, Month, Time, Commander);
                test++;

                try
                {
                    Process print = new Process();
                    print.StartInfo = new ProcessStartInfo()
                    {
                        CreateNoWindow = true,
                        Verb = "print",
                        FileName = PDF.CreatePDFv2(Basic, Place, Reason, ID_Vehicle, Year, Month, Time, Commander)
                    };
                    print.Start();

                }
                catch { MessageBox.Show("Wystąpił problem z drukowaniem.\n Sprawdź:\n1.Czy drukarka jest włączona?\n2.Czy jest ustawiona jako domyślna?\n3.Czy ma toner/tusz?"); }
                test++;

                SqlConnectorv2.SQLVoid("INSERT INTO `departure_card`(`ID_departure_card`, `Departure_number`, `Departure_date`, `Hour_departure`, `Hour_arrival`, `ID_place_departure`, `ID_reason_departure`, `ID_Departure_commander`, `ID_499z01`, `ID_499z15`, `ID_499z18`, `ID_499z19`, `Year`, `Mounth`, `Hour`, `Trip`) VALUES('', " + Basic[0] + ", '" + Basic[5] + "', '" + Basic[1] + ":" + Basic[2] + "', '" + Basic[3] + ":" + Basic[4] + "' , " + ID_Place + ", " + ID_Reason + ", " + ID_Commander + ", 1, 1, 1, 1, " + Year + ", " + Month + " , " + Time + ", " + Place[2] + ")"); //6
                test++;

                int ID_Departure_Card = SqlConnectorv2.SelectIDDepartureCard(Year);
                test++;

                AddVehicleToDepartureCard(ID_Vehicle, ID_Departure_Card, Year);
                test++;

                if (Place[1] != "")
                {
                    string Title = $"{Basic[0]}-{Year} - {Place[0]}, ul. {Place[1]} - {Reason[1]}";
                    Email_send(Title, $"c:/OSP/Wyjazdy/{Year} Rok/{MonthName(Month)} Miesiąc/{Title}.pdf", ID_Departure_Card);
                }
                else
                {
                    string Title = $"{Basic[0]}-{Year} - {Place[0]} - {Reason[1]}";
                    Email_send(Title, $"c:/OSP/Wyjazdy/{Year} Rok/{MonthName(Month)} Miesiąc/{Title}.pdf", ID_Departure_Card);
                }
                test++;

                return true;
            }
            catch
            {
                MessageBox.Show(errorManager.GetErrorMessage(test));
                return false;
            }
        }

        public bool PrintPreviousDepartureCard(List<string> NewBasic, List<string> NewPlace, List<string> OldPlace, List<string> NewReason, List<string> OldReason, List<string> Vehicle_New, List<string> Vehicle_Old, string Commander)
        {
            int ID_Departure_card;
            int Time;
            int Year;
            int Month;
            int ID_Place_New;
            int ID_Place_Old;
            int ID_Reason_New;
            bool ID_Reason_New_Bool;
            int ID_Reason_Old;
            bool ID_Reason_Old_Bool;
            int ID_Commander;
            List<int> ID_Vehicle_New;
            List<int> ID_Vehicle_Old;

            bool New = false;

            int test = 0;

            try
            {



                #region Basic
                Time = MinuteToHour(DepartureArrivalToMinute(int.Parse(NewBasic[1]), int.Parse(NewBasic[2]), int.Parse(NewBasic[3]), int.Parse(NewBasic[4])));
                Year = ShowYear(NewBasic[5]);
                Month = ShowMounth(NewBasic[5]);
                ID_Departure_card = SqlConnectorv2.SelectIDDepartureCard(int.Parse(NewBasic[0]), Year);
                test++;

                #endregion
                #region Place
                for (int i = 0; i < NewPlace.Count - 1; i++)
                {
                    if (NewPlace[i] != OldPlace[i])
                    {
                        New = true;
                    }
                    i++;
                }
                ID_Place_New = SqlConnectorv2.SelectPlace(NewPlace[0], NewPlace[1]);
                if (New == true)
                {

                    ID_Place_Old = SqlConnectorv2.SelectPlace(OldPlace[0], OldPlace[1]);


                }
                test++;
                #endregion
                #region Reason
                New = false;
                for (int i = 0; i < NewReason.Count; i++)
                {
                    if (NewReason[i] != OldReason[i])
                    {
                        New = true;
                    }
                    i++;
                }
                ID_Reason_New = SqlConnectorv2.SelectReason(NewReason[0], NewReason[1]);
                ID_Reason_Old = SqlConnectorv2.SelectReason(OldReason[0], OldReason[1]);
                ID_Reason_New_Bool = SqlConnectorv2.DepartureOrNot(ID_Reason_New);
                ID_Reason_Old_Bool = SqlConnectorv2.DepartureOrNot(ID_Reason_Old);
                test++;

                #endregion

                #region Vehicle




                ID_Vehicle_New = SelectedFirefighterFromTruck(Vehicle_New);
                ID_Vehicle_Old = SelectedFirefighterFromTruck(Vehicle_Old);
                ID_Commander = SqlConnectorv2.SelectIdFireFighter(Commander);
                test++;
                try
                {
                    Process print = new Process();
                    print.StartInfo = new ProcessStartInfo()
                    {
                        CreateNoWindow = true,
                        Verb = "print",
                        FileName = PDF.CreatePDFv2(NewBasic, NewPlace, NewReason, ID_Vehicle_New, Year, Month, Time, Commander)
                    };
                    print.Start();

                }
                catch { MessageBox.Show("Wystąpił problem z drukowaniem.\n Sprawdź:\n1.Czy drukarka jest włączona?\n2.Czy jest ustawiona jako domyślna?\n3.Czy ma toner/tusz?"); }
                test++;
               
                
                #endregion

                SqlConnectorv2.SQLVoid($"UPDATE `departure_card` SET `Departure_date`= '{NewBasic[5]}',`Hour_departure`= '{NewBasic[1]}:{NewBasic[2]}',`Hour_arrival`='{NewBasic[3]}:{NewBasic[4]}',`ID_place_departure`= {ID_Place_New},`ID_reason_departure`= {ID_Reason_New},`ID_Departure_commander`= {ID_Commander},`ID_499z01`= 1,`ID_499z15`= 1,`ID_499z18`= 1,`ID_499z19`= 1,`Year`= {Year},`Mounth`= {Month} ,`Hour`= {Time},`Trip`= {NewPlace[3]} WHERE departure_card.ID_departure_card = {ID_Departure_card}");
                test++;
                test++;
                AddVehicleToDepartureCard(ID_Vehicle_New, ID_Departure_card, Year);

                DeleteOldVehicleDepartureCard(ID_Vehicle_New, ID_Vehicle_Old, ID_Departure_card, Year);
                test++;



                if (NewPlace[1] != "")
                {
                    string Title = $"{NewBasic[0]}-{Year} - {NewPlace[0]}, ul. {NewPlace[1]} - {NewReason[1]}";
                    Email_send("Poprawa wyjazdu " + Title, $"c:/OSP/Wyjazdy/{Year} Rok/{MonthName(Month)} Miesiąc/{Title}.pdf", ID_Departure_card);
                }
                else
                {
                    string Title = $"{NewBasic[0]}-{Year} - {NewPlace[0]} - {NewReason[1]}";
                    Email_send("Poprawa wyjazdu " + Title, $"c:/OSP/Wyjazdy/{Year} Rok/{MonthName(Month)} Miesiąc/{Title}.pdf", ID_Departure_card);
                }



                return true;
            }
            catch
            {
                MessageBox.Show(errorManager.GetErrorMessage(test));
                return false;
            }
        }

        #region HelpToPrint
        #region Basic Information
        public int DepartureArrivalToMinute(int HourDeparture, int MinuteDeparture, int HourArrival, int MinuteArrival)
        {
            int time;
            if (HourDeparture < HourArrival)
            {
                HourDeparture *= 60;
                HourArrival *= 60;
                MinuteDeparture += HourDeparture;
                MinuteArrival += HourArrival;

                time = MinuteArrival - MinuteDeparture;
            }
            else if (HourDeparture == HourArrival)
            {
                if (MinuteDeparture > MinuteArrival)
                {
                    MinuteDeparture -= MinuteArrival;
                    time = (24 * 60) - MinuteDeparture;
                }
                else
                {
                    time = MinuteArrival - MinuteDeparture;
                }
            }
            else
            {
                time = ((24 * 60) - ((HourDeparture * 60) + MinuteDeparture)) + ((HourArrival * 60) + MinuteArrival);
            }
            return time;
        }
        public int MinuteToHour(int Time)
        {
            int H = Time / 60;
            int M = Time % 60;
            string Mi = M.ToString();
            if (M == 0) { M = 00; } else { H++; };
            return H;
        }

        public int ShowYear(string Data)
        {
            return int.Parse(Data.Substring(6, 4));
        }
        public int ShowMounth(string Data)
        {
            return int.Parse(Data.Substring(3, 2));
        }



        #endregion
        #region Vehicle Information
        public static List<int> SelectedFirefighterFromTruck(List<string> Vehicle)
        {
            List<int> ListWithVehicle = new List<int>();
            for (int i = 0; i < Vehicle.Count; i++)
            {
                try
                {
                    if (SqlConnectorv2.IDCars(Vehicle[i], false) != 0 && SqlConnectorv2.IDCars(Vehicle[Math.Min(i + 1, Vehicle.Count - 1)], false) == 0)
                    {
                        bool LastFirefighter = false;
                        List<string> list = new List<string>();
                        list.Add(Vehicle[i]);
                        for (int j = i + 1; j <= i + 9; j++)
                        {
                            if (LastFirefighter == false)
                            {
                                if (j < Vehicle.Count && Vehicle[j] != "" && SqlConnectorv2.IDCars(Vehicle[j], false) == 0)
                                {
                                    list.Add(Vehicle[j]);
                                }
                                else
                                {
                                    LastFirefighter = true;
                                    list.Add("0");
                                }
                            }
                            else
                            {
                                list.Add("0");
                            }
                        }
                        if (list[1] != "0")
                        {
                            ListWithVehicle.Add(SqlConnectorv2.SelectFireFighterFromTruck(list));
                        }

                    }
                    else
                    {
                        continue;
                    }
                }
                catch
                {
                    MessageBox.Show("Nie udało się wysortować strażaków");
                }
            }
            return ListWithVehicle;
        }
        #endregion
        #region Ranking
     
        #endregion


        public void DeleteOldVehicleDepartureCard(List<int> ID_Vehicle_New, List<int> ID_Vehicle_Old, int ID_Departure_card, int Year)
        {

            bool test = false;
            try
            {
                for (int i = 0; i < ID_Vehicle_Old.Count; i++)
                {
                    test = false;
                    for (int j = 0; j < ID_Vehicle_New.Count; j++)
                    {
                        if (ID_Vehicle_New[j] == ID_Vehicle_Old[i])
                        {
                            test = true; break;
                        }
                    }
                    if (test == false)
                    {
                        SqlConnectorv2.SQLVoid($"DELETE FROM `departure_card_vehicle` WHERE departure_card_vehicle.DepartureCard_ID = {ID_Departure_card} AND departure_card_vehicle.VehicleCard_ID = {ID_Vehicle_Old[i]}");
                    }
                }

            }
            catch
            {
                MessageBox.Show("Problem z usunięciem starego zastępu z bazy danych");
            }


        }

        private void AddVehicleToDepartureCard(List<int> ID_Vehicle, int ID_Departure_card, int Year)
        {

            foreach (int element in ID_Vehicle)
            {
                SqlConnectorv2.AddVehicleToDepartureCard(ID_Departure_card, element);
            }
        }

        
       

        #endregion

        #region Departure Without Sending

        public void DepWitSen()
        {
            try
            {
                List<int> Departure = SQL.DepartureWithoutSending();
                if (Departure.Count > 0)
                {
                    Thread thread = new Thread(() => MessageBox.Show("Znaleziono niewyslane maile\nDaj mi chwilę na wysłanie\nGdy zostaną wysłane pokaże się okno do wypisywania karty wyjazdu"));
                    thread.Start();
                    foreach (int ID in Departure)
                    {
                        List<string> list = SQL.InfoResendEmail(ID);
                        string Title;
                        if (list[3] != "")
                        {

                            Title = $"{list[0]}-{list[1]} - {list[2]}, ul. {list[3]} - {list[4]}";
                        }
                        else
                        {
                            Title = $"{list[0]}-{list[1]} - {list[2]} - {list[4]}";
                        }

                        Email_send(Title, $"c:/OSP/Wyjazdy/{list[1]} Rok/{MonthName(int.Parse(list[5]))} Miesiąc/{Title}.pdf", ID);
                    }


                    thread = new Thread(() => MessageBox.Show("Wysłano zaległe maile"));
                    thread.Start();
                }
            }
            catch
            {
                MessageBox.Show("Problem z wysłanie zaległych maili");
            }

        }


        #endregion





        public static string MonthName(int Month)
        {
            if (Month == 1)
            {
                return "Styczeń";
            }
            else if (Month == 2)
            {
                return "Luty";
            }
            else if (Month == 3)
            {
                return "Marzec";
            }
            else if (Month == 4)
            {
                return "Kwiecień";
            }
            else if (Month == 5)
            {
                return "Maj";
            }
            else if (Month == 6)
            {
                return "Czerwiec";
            }
            else if (Month == 7)
            {
                return "Lipiec";
            }
            else if (Month == 8)
            {
                return "Sierpień";
            }
            else if (Month == 9)
            {
                return "Wrzesień";
            }
            else if (Month == 10)
            {
                return "Październik";
            }
            else if (Month == 11)
            {
                return "Listopad";
            }
            else
            {
                return "Grudzień";
            }
        }








       

    }
}

[TestFixture]
public class Testy
{
    [Test]
    public void TestTime()
    {
        var programsDepartureCard = new FirefighterControlCenter.UserInterface.Programs.ProgramsDepartureCard();

        var result = programsDepartureCard.MinuteToHour(125);



        Assert.That(result, Is.EqualTo("3:00"));
    }


    [Test]
    public void TestDelete()
    {
        var programsDepartureCard = new FirefighterControlCenter.UserInterface.Programs.ProgramsDepartureCard();

        List<int> ID_Vehicle_New = new List<int>();

        ID_Vehicle_New.Add(547);
        ID_Vehicle_New.Add(643);

        List<int> ID_Vehicle_Old = new List<int>();

        ID_Vehicle_Old.Add(547);
        ID_Vehicle_Old.Add(548);

        //int NumberDepartureCard = 76;
        //int Year = 2024;





        //var result = programsDepartureCard.DeleteOldVehicleDepartureCard(ID_Vehicle_New, ID_Vehicle_Old, NumberDepartureCard, Year);



        // Assert.That(result, Is.EqualTo(1));
    }


    [Test]
    public void TestLogin()
    {
        

       
            var resualt = HelpPrograms.CheckPassword("admin", "kutangpan");
        
        

        Assert.That(resualt, Is.EqualTo(true));

    }
    [Test]
    public void TestCalcTime()
    {
        var programsDepartureCard = new FirefighterControlCenter.UserInterface.Programs.ProgramsDepartureCard();

        var result = programsDepartureCard.DepartureArrivalToMinute(15, 30, 16, 00);



        Assert.That(result, Is.EqualTo(30));
    }

    [Test]
    public void TestYear()
    {
        var programsDepartureCard = new FirefighterControlCenter.UserInterface.Programs.ProgramsDepartureCard();

        var result = programsDepartureCard.ShowMounth("10.10.2024");



        Assert.That(result, Is.EqualTo(10));
    }

    [Test]
    public void TestVehicle()
    {
        //var programsDepartureCard = new ProgramsDepartureCard();
        List<string> list = new List<string>();
        list.Add("499z01");
        list.Add("Dobrzeniecki D");
        list.Add("Kyc M");


        List<int> result = new List<int>();
        result = ProgramsDepartureCard.SelectedFirefighterFromTruck(list);



        Assert.That(result[0], Is.EqualTo(549));
    }


}

