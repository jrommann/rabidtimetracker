using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabid_Time_Tracker
{
    internal class Session
    {
        public Session(DateTime date) 
        { 
            this.Date = date;
            Periods = new List<Period>();
        }

        public DateTime Date { get; private set; }
        public int Seconds { get; private set; }

        public List<Period> Periods { get; private set; }

        public void AddSecond()
        {
            Seconds++;
        }

        public void AddPeriod(Period p)
        {
            Periods.Add(p);
        }
    }
}
