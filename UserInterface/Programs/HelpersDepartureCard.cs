using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirefighterControlCenter.UserInterface.Forms;

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

        private static string FullTimeFromMinute(int minute)
        {
            int add = 0;

            int TimeH = minute / 60;
            int TimeM = minute % 60;

            string FullHour;
            string FullMinute;
            string FullFull;
            
            if(TimeM < 15)
            {
                TimeM = 0;
                FullMinute = "0" + TimeM.ToString();
            }
            else if (TimeM > 45)
            {
                TimeM = 0;
                add++;
                FullMinute = "0"+TimeM.ToString();
            }
            else
            {
                TimeM = 30;
                FullMinute = TimeM.ToString();
            }

            if (TimeH<10)
            {
                TimeH = TimeH + add;
                FullHour = "0" + TimeH.ToString();
            }
            else
            {
                TimeH = TimeH + add;
                FullHour = TimeH.ToString();
            }

            FullFull = FullHour + ":" + FullMinute;
            return FullFull;
            
            
        }
    }
}
