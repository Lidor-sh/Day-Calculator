using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayCalculator
{
    class Program
    {
        public static int YearCode(int year)
        {
            int yearcode;
            yearcode = (year % 100 + (year % 100) / 4) % 7;
            return yearcode;
        } 

        public static int MonthCode(int month)
        {
            int monthcode=-1;
            switch(month)
            {
                case 1:
                case 10:
                    monthcode = 0;
                    break;
                case 2:
                case 3:
                case 11:
                    monthcode = 3;
                    break;
                case 4:
                case 7:
                    monthcode = 6;
                    break;
                case 5:
                    monthcode = 1;
                    break;
                case 6:
                    monthcode = 4;
                    break;
                case 8:
                    monthcode = 2;
                    break;
                case 9:
                case 12:
                    monthcode = 5;
                    break;
            }
            return monthcode;
        }

        public static int CenturyCode(int year)
        {
            int centurycode=-1;
            if (year < 1799)
                centurycode = 4;
            else if (year < 1899)
                centurycode = 2;
            else if (year < 1999)
                centurycode = 0;
            else if (year < 2099)
                centurycode = 6;
            else if (year < 2199)
                centurycode = 4;
            else if (year < 2299)
                centurycode = 2;
            else
                centurycode = 0;
            return centurycode;
        }

        public static int LeapYearCode(int year,int month)
        {
            int leapyearcode = 0;
            if(year % 4 == 0)
            {
                if (month <= 2)
                    leapyearcode = 1;
            }
            return leapyearcode;
        }

        static void Main(string[] args)
        {
            int year, month, day;
            bool GoodDay = false;
            Console.WriteLine("Welcome to Day Calculator");
            Console.WriteLine("Enter the year(YYYY):");
            year = int.Parse(Console.ReadLine());
            while(year >= 2400 || year < 1700)
            {
                Console.WriteLine("There is a limit please choose year between 1700-2399");
                year = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter the month(MM):");
            month = int.Parse(Console.ReadLine());
            while(month > 12 || month < 1)
            {
                Console.WriteLine("There is a limit please choose month between 1-12");
                month = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter the day(DD):");
            day = int.Parse(Console.ReadLine());
            while(!GoodDay)
            {
                switch(month)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        if (day <= 31 && day > 0)
                            GoodDay = true;
                        break;
                    case 2:
                        if(year % 4 == 0)
                        {
                            if (day <= 29 && day > 0)
                                GoodDay = true;
                        }
                        else
                        {
                            if (day <= 28 && day > 0)
                                GoodDay = true;
                        }
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        if (day <= 30 && day > 0)
                            GoodDay = true;
                        break;
                }
                if(!GoodDay)
                {
                    Console.WriteLine("There is a limit please choose a correct day");
                    month = int.Parse(Console.ReadLine());
                }
            }
            //finish with the date
            //start with the calculation
            int TheDayNumber;
            TheDayNumber = (YearCode(year) + MonthCode(month) + CenturyCode(year) + day - LeapYearCode(year, month)) % 7;
            switch(TheDayNumber)
            {
                case 0:
                    Console.WriteLine("Sunday");
                    break;
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
            }

        }
    }
}
