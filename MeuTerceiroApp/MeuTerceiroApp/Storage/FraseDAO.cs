using MeuTerceiroApp.Model.Entities;
//Importações da classe
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Namespace da classe
namespace MeuTerceiroApp.Storage
{
        //Criação da classe e implementando ela 
        public class FraseDAO : IDisposable
        {
            //Criação da propriedade de conexão
            private SQLiteConnection database;

            public FraseDAO()
            {
                //Pegando a conexão da classe DatabaseManager
                database = new DatabaseManager().GetConnection();
            }

            public void Dispose()
            {
                //Implementando o método Dipose da interface
                database.Dispose();
            }

            //Criação do método de salvar, se o id for diferente de nulo o método altera
            public void SaveValue(Frase value)
            {
                var all = (from entry in database.Table<Frase>().ToList()
                           where entry.Id == value.Id
                           select entry).ToList();
                if (all.Count == 0)
                {
                    value.CreatedAt = DateTime.Now;
                    database.Insert(value);
                }
                else
                {
                    value.UpdatedAt = DateTime.Now;
                    database.Update(value);

                }
            }
            //criação do método delete
            public void DeleteValue(Frase value)
            {
                var all = (from entry in database.Table<Frase>().AsEnumerable<Frase>()
                           where entry.Id == value.Id
                           select entry).ToList();

                if (all.Count == 1)
                {
                    database.Delete(value);
                }
                else
                {
                    throw new Exception("O banco de dados não possui um registro com o identificador especificado.");
                }
            }
            //Criação do método de consulta 
            public List<Frase> GetAllItems()
            {
                try
                {
                    return database.Table<Frase>().ToList();
                }
                catch (SQLiteException)
                {
                    throw;
                }

            }
            //Criação do método de consulta por objeto/id
            public Frase GetItem(Frase value)
            {
                var result = (from entry in database.Table<Frase>().AsEnumerable<Frase>()
                              where entry.Id == value.Id
                              select entry).FirstOrDefault();

                return result;
            }
        }
    }
