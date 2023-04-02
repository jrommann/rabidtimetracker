using Microsoft.VisualBasic;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabid_Time_Tracker
{
    [Table("Projects")]
    internal class Project
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Indexed]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Started {get; set; }
    }
}

