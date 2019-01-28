using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLib;

namespace TimeProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Time t = new Time("12:23:12");
            Time t2 = new Time("12:23:4");
            Time t3 = new Time("12:42:12");
            Time t4 = new Time("13:23:56");
            Time t1 = new Time("13:23:53");
            Time t5 = new Time("12:23:12");

            List<Time> time = new List<Time>();
            time.Add(t);
            time.Add(t1);
            time.Add(t2);
            time.Add(t3);
            time.Add(t4);

            Console.WriteLine(t >= t5);

            Console.WriteLine(time.Max<Time>());
            
            TimePeriod to = new TimePeriod("10:20:20");

            TimePeriod tp1 = new TimePeriod("10:20:21");
            Console.WriteLine(tp1);
            Console.WriteLine(to);
            Console.WriteLine(to.Equals(tp1));
            Console.WriteLine(to == tp1);
            TimePeriod tp2 = to - tp1;
            Console.WriteLine(tp1);

            Time t6 = t + to;
            Console.WriteLine(t6);
            Console.WriteLine(to.Minutes);
            Console.WriteLine(to.Hours);
            Console.WriteLine(to.Second);
        }
    }
}
