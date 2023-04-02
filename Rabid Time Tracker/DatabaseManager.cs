﻿using System;
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
        static public DatabaseManager Instance { get; private set; }
        static public void Create(string databasePath)
        {
            Instance = new DatabaseManager(databasePath);
        }

        SQLiteConnection _db;
        DatabaseManager(string databasePath)
        {
            _db = new SQLiteConnection(databasePath);

            _db.CreateTable<Project>();
            _db.CreateTable<Session>();
            _db.CreateTable<Period>();
        }

        public void Insert(object item)
        {
            _db.Insert(item);
        }

        public void Update(object item)
        {
            _db.Update(item);
        }

        public void Delete(object item)
        {
            _db.Delete(item);
        }

        public List<Project> Projects_GetAll()
        {
            return _db.Table<Project>().ToList();
        }

    }
}
