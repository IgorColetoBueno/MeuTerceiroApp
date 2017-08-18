//Importações de classes
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Namespace da classe
namespace MeuTerceiroApp.Model.Entities
{
    //Criação da classe Frase
    public class Frase
    {
        //Anotação do id para que ele seja chave primária e auto-incremento
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        //Propriedade para a frase, de fato
        public string MinhaFrase { get; set; }
        //Propriedade para a data de cadastro
        public DateTime CreatedAt { get; set; }
        //Propriedade para a data de alteração
        public DateTime UpdatedAt { get; set; }
    }
}
