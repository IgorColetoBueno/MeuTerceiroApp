using MeuTerceiroApp.Model.Entities;
using MeuTerceiroApp.Storage.Interfaces;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace MeuTerceiroApp.Storage
{
    public class DatabaseManager
    {
        private SQLiteConnection database;

        public DatabaseManager()
        {
            var config = DependencyService.Get<ISQLite>();
            database = new SQLiteConnection(config.Platform, Path.Combine(config.CaminhoDB, "MeuTerceiroApp.db3"));
            database.CreateTable<Frase>();
        }

        public SQLiteConnection GetConnection()
        {
            return database;
        }
    }
}