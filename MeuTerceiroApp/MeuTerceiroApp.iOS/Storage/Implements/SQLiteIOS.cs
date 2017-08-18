using MeuTerceiroApp.iOS.Storage.Implements;
using MeuTerceiroApp.Storage.Interfaces;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Text;
using System.IO;

[assembly: Dependency(typeof(SQLiteIOS))]
namespace MeuTerceiroApp.iOS.Storage.Implements
{
    public class SQLiteIOS : ISQLite
    {
        public SQLiteIOS()
        {

        }

        private string caminhoDB;

        public string CaminhoDB
        {
            get
            {
                if (string.IsNullOrEmpty(caminhoDB))
                {
                    var diretorio = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    caminhoDB = Path.Combine(diretorio, "..", "Library");
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
                    platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
                }
                return platform;
            }
        }
    }
}
