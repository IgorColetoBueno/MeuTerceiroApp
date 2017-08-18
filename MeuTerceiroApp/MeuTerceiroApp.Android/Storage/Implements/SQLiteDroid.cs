using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using MeuTerceiroApp.Storage.Interfaces;
using MeuTerceiroApp.Droid.Storage.Implements;

[assembly: Dependency(typeof(SQLiteDroid))]
namespace MeuTerceiroApp.Droid.Storage.Implements
{    
    public class SQLiteDroid : ISQLite
    {
        private string caminhoDB;

        public string CaminhoDB
        {
            get
            {
                if (string.IsNullOrEmpty(caminhoDB))
                {
                    caminhoDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                return caminhoDB;
            }
            set { caminhoDB = value; }
        }

        private SQLite.Net.Interop.ISQLitePlatform platform;
        public SQLite.Net.Interop.ISQLitePlatform Platform
        {
            get
            {
                if (platform == null)
                {
                    platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }
                return platform;
            }
        }

    }
}
