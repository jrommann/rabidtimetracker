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
        public Session() { }
        public Session(DateTime date) 
        { 
            this.Date = date;
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Indexed]
        public DateTime Date { get; set; }
        public int Seconds { get; set; }
        [Ignore]
        public Period CurrentPeriod { get; private set; }
        public void AddSecond()
        {
            Seconds++;
            CurrentPeriod.Seconds++;
            DatabaseManager.Instance.Update(this);
            DatabaseManager.Instance.Update(CurrentPeriod);
        }

        public void AddPeriod(int projectID, string note)
        {
            if (CurrentPeriod != null)
                CurrentPeriod.EndTime = DateTime.Now;

            CurrentPeriod = new Period(ID, projectID, note);
            DatabaseManager.Instance.Insert(CurrentPeriod);
        }
    }
}
