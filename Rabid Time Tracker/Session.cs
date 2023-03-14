using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using SQLitePCL;

namespace Rabid_Time_Tracker
{
    [Table("Sessions")]
    internal class Session
    {
        public Session(DateTime date) 
        { 
            this.Date = date;
            Periods = new List<Period>();
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Indexed]
        public DateTime Date { get; set; }
        public int Seconds { get; set; }

        [Ignore]
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
