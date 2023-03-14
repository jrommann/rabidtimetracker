﻿using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using SQLitePCL;

namespace Rabid_Time_Tracker
{
    [Table("Periods")]
    internal class Period
    {
        public Period(int sessionID, int projectID, string note)
        {
            SessionID = sessionID;
            ProjectID = projectID;
            Note = note;
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Indexed]
        public int SessionID { get; set; }
        [Indexed]
        public int ProjectID { get; set; }
        public string Note { get; set; }
        public int Seconds { get; set; }
        
        public void AddSecond() { Seconds++; }

    }
}
