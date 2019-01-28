using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLib
{
    public struct TimePeriod:IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        readonly long _seconds;

        
        public long Hours
        {
            get
            {
                return (_seconds/ 60)/ 60;
            }
        }

        public long Minutes
        {
            get
            {
                return  _seconds / 60;
            }
        }

        public long Second
        {
            get
            {
                return _seconds;
            }
        } 


        public TimePeriod(int hours, int minutes , int seconds)
        {
            _seconds = hours * 3600 + minutes * 60 + seconds;
        }

        public TimePeriod(int hours , int minutes):this(hours , minutes , 0)
        {

        }

        public TimePeriod (long seconds)
        {
            _seconds = seconds;
        }

        /// <summary>
        /// if t1 < t2 TimePeriod = t2- t1
        /// else  TimePeriod = 0
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>

        public TimePeriod (Time t1 , Time t2)
        {
            if ( t2.ConvertToSeconds()  - t1.ConvertToSeconds() < 0)
                _seconds = 0;
            else
                _seconds=t2.ConvertToSeconds() - t1.ConvertToSeconds();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TimePeriod">hours:minutes:seconds</param>
        public TimePeriod(string TimePeriod)
        {

            if (TimePeriod is null)
                throw new NullReferenceException();

            if (TimePeriod.Split(':').GetLength(0) != 3)
                throw new ArgumentException();

            string[] tab = TimePeriod.Split(':');
            int hours=0;
            int minutes=0;
            int seconds=0;

            int.TryParse(tab[0], out hours );
            int.TryParse(tab[1], out minutes);
            int.TryParse(tab[2], out seconds);

            _seconds =  hours * 3600 + minutes * 60 + seconds;
        }


        public override string ToString()
        {
            return $"{((_seconds / 60) / 60) }:{((_seconds / 60) % 60)}:{(_seconds % 60)}";
        }

        public bool Equals(TimePeriod other)
        {
            return (this._seconds == other._seconds);
        }

        public static bool Equals (TimePeriod tp1 , TimePeriod tp2)
        {
            return tp1.Equals(tp2);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return _seconds.GetHashCode() * 12;
            }
        }


        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() == typeof(TimePeriod)) return this.Equals(obj);
            else
                return false;
        }


        public int CompareTo(TimePeriod other)
        {
            if (this.Equals(other)) return 0;
            else
                if (this._seconds > other._seconds) return 1;
            else return -1;
        }

        // override operator
        public static bool operator ==(TimePeriod tp1, TimePeriod tp2) => TimePeriod.Equals(tp1, tp2);
        public static bool operator !=(TimePeriod tp1, TimePeriod tp2) => !(tp1 == tp2);

        public static bool operator <(TimePeriod tp1, TimePeriod tp2) => tp1._seconds < tp2._seconds;
        public static bool operator >(TimePeriod tp1, TimePeriod tp2) => tp1._seconds > tp2._seconds;


        public static bool operator <=(TimePeriod tp1, TimePeriod tp2) => tp1._seconds <= tp2._seconds;
        public static bool operator >=(TimePeriod tp1, TimePeriod tp2) => tp1._seconds >= tp2._seconds;




        public static TimePeriod operator +(TimePeriod tp1, TimePeriod tp2) => new TimePeriod(tp1._seconds + tp2._seconds);
        public static TimePeriod operator -(TimePeriod tp1, TimePeriod tp2) => new TimePeriod((tp1._seconds - tp2._seconds >= 0) ? tp1._seconds - tp2._seconds:0);


    }
}
