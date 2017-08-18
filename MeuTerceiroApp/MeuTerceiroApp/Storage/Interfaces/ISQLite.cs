using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuTerceiroApp.Storage.Interfaces
{
    public interface ISQLite
    {
        string CaminhoDB { get; }

        ISQLitePlatform Platform { get; }

    }
}
