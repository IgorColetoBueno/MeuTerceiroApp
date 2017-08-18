//Importações de classes
using MeuTerceiroApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Namespace da classe
namespace MeuTerceiroApp.Model.Repositories
{
    //Criação da classe
    public class FraseRepository
    {
        //Criação de propriedade do tipo ObservableCollection para formar um repositório
        public ObservableCollection<Frase> Frases { get; set; }
    }
}
