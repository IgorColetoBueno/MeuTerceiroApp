using MeuTerceiroApp.Model.Entities;
using MeuTerceiroApp.Model.Services;
using MeuTerceiroApp.Storage;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuTerceiroApp.ViewModel
{
    public class FraseViewModel
    {
        public ObservableCollection<Frase> Frases { get; set; }
        FraseDAO fraseDAO { get; set; }
        public FraseViewModel()
        {
            Frases = new ObservableCollection<Frase>();
            fraseDAO = new FraseDAO();
        }

        public ObservableCollection<Frase> Listar()
        {
            Frases.Clear();
            var frasesRepository = new FraseRepositoryService().LoadAlunoEventoDirectory();

            if (frasesRepository.Frases != null)
            {
                foreach (var frase in frasesRepository.Frases)
                {
                    Frases.Add(frase);
                }

                return Frases;
            }
            return null;
        }

        public bool SalvarFrase(Frase frase)
        {
            try
            {
                new FraseDAO().SaveValue(frase);
                return true;
            }
            catch (SQLiteException)
            {
                return false;
                throw;
            }
        }

    }
}
