using System;


    namespace TimeLib
    {
    public struct Time:IEquatable<Time> , IComparable<Time>
    {
        readonly byte _hours;
        readonly byte _minutes;
        readonly byte _seconds;



        public Time(int hours, int minutes, int seconds)
        {
            _hours = (byte)(hours % 24);
            _minutes = (byte)(minutes % 60);
            _seconds = (byte)(seconds % 60);
        }

        public Time(int hours, int minutes) : this(hours, minutes, 0)
        {
            ;
        }
            
        public Time(int hours ) : this(hours, 0, 0)
        {
            ;
        }

       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Time">hour:minutes:seconds</param>
        public Time(string Time)
        {
            if (Time is null)
                throw new NullReferenceException();

            if (Time.Split(':').GetLength(0) != 3)
                throw new ArgumentException();
            else
            {
                string[] tab = Time.Split(':');
                Byte.TryParse(tab[0], out _hours);
                Byte.TryParse(tab[1], out _minutes);
                Byte.TryParse(tab[2], out _seconds);

                _hours %= 24;
                _minutes %= 60;
                _seconds %= 60;
            }
           



        }


          

            public byte Hours
            {
                get
                {
                    return _hours;
                }
            }

            public byte Minutes
            {
                get
                {
                    return _minutes;
                }
            }

            public byte Second
            {
                get
                {
                    return _seconds;
                }
            }

            public int ConvertToSeconds()
            {
            return ((this.Hours * 3600) + (this.Minutes * 60) + this.Second);
            }



            public override string ToString()
            {
                return $"{Hours}:{Minutes}:{Second}";
            }





        public bool Equals(Time other)
             => (this.Hours == other.Hours && this.Minutes == other.Minutes && this.Second == other.Second);


        public static bool Equals(Time t1, Time t2)
        {
            return t1.Equals(t2);
        }


        public override int GetHashCode()
        {
            unchecked
            {
                return (Hours.GetHashCode() * 10 + Minutes.GetHashCode() * 6) ^ Second.GetHashCode();
            }
           
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;

            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() == typeof(Time)) return this.Equals(obj);
            else
            return false;

        }

        public int CompareTo(Time other)
        {
            if (this.Equals(other)) return 0;
            else
                if (this.ConvertToSeconds() > other.ConvertToSeconds())
                    return 1;
                else
                    return -1;


        }

        public static bool operator==(Time left, Time right) => Time.Equals(left, right);
        public static bool operator !=(Time left, Time right) => !(left==right);

        public static bool operator <(Time left, Time right) => left.ConvertToSeconds() < right.ConvertToSeconds();
        public static bool operator >(Time left, Time right) => left.ConvertToSeconds() > right.ConvertToSeconds();

        public static bool operator <=(Time left, Time right) => left.ConvertToSeconds() <= right.ConvertToSeconds();
        public static bool operator >=(Time left, Time right) => left.ConvertToSeconds() >= right.ConvertToSeconds();


        public static Time operator +(Time left, TimePeriod right) => new Time((byte)(left.Hours + right.Hours), (byte)(left.Minutes + right.Minutes%60), (byte)(left.Second + right.Second%60));

    }
}

