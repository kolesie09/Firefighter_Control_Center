using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using FirefighterControlCenter.UserInterface.Forms;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface
{
    public class HelpersDepartureCard
    {

        public static string CalcTime(string hourdeparture, string minutedeparture, string hourarrival, string minutearrival)
        {
            int hourD = int.Parse(hourdeparture);
            int hourA = int.Parse(hourarrival);
            int minuteD = int.Parse(minutedeparture);
            int minuteA = int.Parse(minutearrival);

            int HourDInMinute = HourToMinute(hourD);
            int HourAInMinute = HourToMinute(hourA);

            int HourMinuteD = HourDInMinute + minuteD;
            int HourMinuteA = HourAInMinute + minuteA;

            if(HourMinuteD<HourMinuteA)
            {
                int TimeDeparture = HourMinuteA - HourMinuteD;
                string Time = FullTimeFromMinute(TimeDeparture);
                return Time;
            }
            else
            {
                int TimeDeparture = 1440 - HourMinuteD + HourMinuteA;
                string Time = FullTimeFromMinute(TimeDeparture);
                return Time;
            }

            
        }

        private static int HourToMinute(int hour)
        {
            int hourtominute = hour * 60;
            return hourtominute;
        }
        public static void email_send(string type, string Name, string Mount, int Year)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("wyjazdyospbarlinek@gmail.com");
                if(type == "osp")
                {
                    mail.To.Add("damian.dobrzeniecki@outlook.com");
                }
                else if(type == "test")
                {
                    mail.To.Add("damian.dobrzeniecki@outlook.com");
                }
                //mail.To.Add("damian.dobrzeniecki@outlook.com");
                mail.Subject = Name;
                mail.Body = "";

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment("c:/OSP/Wyjazdy/"+Year+" Rok/"+Mount+" Miesiąc/"+Name+".pdf");
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("wyjazdyospbarlinek@gmail.com", "5PffHvp7Gl");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch(Exception e)
            {
                MessageBox.Show("Coś poszło nie tak z mailem");
                MessageBox.Show(e.ToString());
            }

        }

        private static string FullTimeFromMinute(int minute)
        {
            int add = 0;

            int TimeH = minute / 60;
            int TimeM = minute % 60;

            string FullHour;
            string FullMinute;
            string FullFull;
            
            if(minute>60)
            {
                if (TimeM < 15)
                {
                    TimeM = 0;
                    FullMinute = "0" + TimeM.ToString();
                }
                else if (TimeM > 45)
                {
                    TimeM = 0;
                    add++;
                    FullMinute = "0" + TimeM.ToString();
                }
                else
                {
                    TimeM = 30;
                    FullMinute = TimeM.ToString();
                }

                if (TimeH < 10)
                {
                    TimeH = TimeH + add;
                    FullHour = "0" + TimeH.ToString();
                }
                else
                {
                    TimeH = TimeH + add;
                    FullHour = TimeH.ToString();
                }
            }
            else
            {
                FullHour = "1";
                FullMinute = "00";
            }

            

            FullFull = FullHour + ":" + FullMinute;
            return FullFull;
            
            
        }
    }
}
