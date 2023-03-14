using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabid_Time_Tracker
{
    internal class Period
    {
        public Period(string project, string note)
        {
            Project = project;
            Note = note;
        }

        public string Project { get; private set; }
        public string Note { get; private set; }
        public int Seconds { get; private set; }
        
        public void AddSecond() { Seconds++; }

    }
}
