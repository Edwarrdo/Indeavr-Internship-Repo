using System;
using System.Collections.Generic;

namespace Problem12
{
    class Time : IComparable<Time>
    {
        private int hours;
        private int minutes;

        public int Hours
        {
            get
            {
                return this.hours;
            }

            set
            {
                if (value < 0 || 23 < value)
                {
                    throw new ArgumentOutOfRangeException("Minutes must be between 0 and 59.");
                }
                this.hours = value;
            }
        }

        public int Minutes
        {
            get
            {
                return this.minutes;
            }

            set
            {
                if (value < 0 || 59 < value)
                {
                    throw new ArgumentOutOfRangeException("Minutes must be between 0 and 59.");
                }
                this.minutes = value;
            }
        }

        public Time(int hours, int minutes)
        {
            this.Hours = hours;
            this.Minutes = minutes;
        }

        public int CompareTo(Time other)
        {
            if (this.Hours < other.Hours)
            {
                return -1;
            }
            else if (this.Hours > other.Hours)
            {
                return 1;
            }
            else
            {
                if (this.Minutes < other.Minutes)
                {
                    return -1;
                }
                else if (this.Minutes > other.Minutes)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
    
    class TimeInterval : IEqualityComparer<TimeInterval>
    {
        public Time ArrivalTime { get; set; }

        public Time DepartureTime { get; set; }

        public TimeInterval(Time arrivalTime, Time departureTime)
        {
            this.ArrivalTime = arrivalTime;
            this.DepartureTime = departureTime;
        }

        public bool Equals(TimeInterval x, TimeInterval y)
        {
            bool result = x.ArrivalTime == y.ArrivalTime &&
                x.DepartureTime == y.DepartureTime;
            return result;
        }

        public int GetHashCode(TimeInterval interval)
        {
            int hashCode = (interval.ArrivalTime.Hours.GetHashCode() *
                interval.ArrivalTime.Minutes.GetHashCode()) ^
                (interval.DepartureTime.Hours.GetHashCode() *
                interval.DepartureTime.Minutes.GetHashCode());
            return hashCode;
        }
    }
    
    public class StartUp
    {
        static void Main(string[] args)
        {
            Time intervalStart;
            Time intervalEnd;
            GetInterval(out intervalStart, out intervalEnd);

            List<TimeInterval> busses = GetBusses();

            int bussesInIntervalCount = GetBussesInInterval(busses, intervalStart, intervalEnd);
            Console.WriteLine(bussesInIntervalCount);
        }

        private static void GetInterval(out Time intervalStart, out Time intervalEnd)
        {
            string inputLine = Console.ReadLine();
            GetStartAndEndInterval(inputLine, out intervalStart, out intervalEnd);
        }

        private static List<TimeInterval> GetBusses()
        {
            string bussesCountInputLine = Console.ReadLine();
            int bussesCount = int.Parse(bussesCountInputLine);

            List<TimeInterval> busses = new List<TimeInterval>();
            for (int i = 0; i < bussesCount; i++)
            {
                string inputLine = Console.ReadLine();
                Time arrivalTime;
                Time departureTime;
                GetStartAndEndInterval(inputLine, out arrivalTime, out departureTime);

                TimeInterval currentBus = new TimeInterval(arrivalTime, departureTime);
                busses.Add(currentBus);
            }
            return busses;
        }

        private static void GetStartAndEndInterval(string inputLine,
            out Time intervalStart, out Time intervalEnd)
        {
            string[] tokens = inputLine.Split(new char[] { ' ', ':', '-' },
                        StringSplitOptions.RemoveEmptyEntries);

            int intervalStartHours = int.Parse(tokens[0]);
            int intervalStartMinutes = int.Parse(tokens[1]);
            intervalStart = new Time(intervalStartHours, intervalStartMinutes);

            int intervalEndHours = int.Parse(tokens[2]);
            int intervalEndMinutes = int.Parse(tokens[3]);
            intervalEnd = new Time(intervalEndHours, intervalEndMinutes);
        }

        private static int GetBussesInInterval(List<TimeInterval> busses,
            Time intervalStart, Time intervalEnd)
        {
            HashSet<TimeInterval> arrivalFittingBusses = new HashSet<TimeInterval>();
            foreach (TimeInterval bus in busses)
            {
                if (intervalStart.CompareTo(bus.ArrivalTime) <= 0)
                {
                    arrivalFittingBusses.Add(bus);
                }
            }

            HashSet<TimeInterval> departureFittingBusses = new HashSet<TimeInterval>();
            foreach (TimeInterval bus in busses)
            {
                if (intervalEnd.CompareTo(bus.DepartureTime) >= 0)
                {
                    departureFittingBusses.Add(bus);
                }
            }

            arrivalFittingBusses.IntersectWith(departureFittingBusses);
            int fittingBussesCount = arrivalFittingBusses.Count;
            return fittingBussesCount;
        }
    }
}
