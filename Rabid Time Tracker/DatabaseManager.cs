using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarfBuzzSharp;
using SQLite;

namespace Rabid_Time_Tracker
{
    internal class DatabaseManager
    {
        SQLiteConnection _db;
        public DatabaseManager(string databasePath)
        {
            _db = new SQLiteConnection(databasePath);

            _db.CreateTable<Session>();
            _db.CreateTable<Period>();
        }
    }
}
