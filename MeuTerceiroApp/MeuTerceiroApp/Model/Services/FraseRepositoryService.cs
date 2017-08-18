//Importações de classes
using MeuTerceiroApp.Model.Entities;
using MeuTerceiroApp.Model.Repositories;
using MeuTerceiroApp.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Namespace da classe
namespace MeuTerceiroApp.Model.Services
{
    //Criação da classe
    public class FraseRepositoryService
    {
        public FraseRepository LoadAlunoEventoDirectory()
        {
            FraseRepository fraseRepository = new FraseRepository();
            ObservableCollection<Frase> Frases = new ObservableCollection<Frase>(new FraseDAO().GetAllItems());

            if (Frases.Any())
            {
                fraseRepository.Frases = Frases;
            }
            return fraseRepository;
        }
    }
}
