using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace ProgettoEnterprise
{
    class DBmanager
    {
        //path relativa per la connessione al DB, combina la path del db che si trova nella stessa directory dell'exe col nome del DB
        private string connectionString = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MyDatabase.db");




        //metodo per l'insert di un documento
        public void insertDocumento(int id, string nome, string tipo)
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source=" + connectionString + ";Version=3;");
            connection.Open();

            string insertSql = "INSERT INTO Documenti (ID, Nome, Tipo) VALUES (@ID, @Nome, @Tipo)";
            SQLiteCommand insertCommand = new SQLiteCommand(insertSql, connection);


            insertCommand.Parameters.AddWithValue("@ID", id);
            insertCommand.Parameters.AddWithValue("@Nome", nome);
            insertCommand.Parameters.AddWithValue("@Tipo", tipo);

            insertCommand.ExecuteNonQuery();

            connection.Close();
        }



        //metodo per l'insert di un risultato di ricerca 
        public void insertRisultato(int id_documento, string risultato) {
            SQLiteConnection connection = new SQLiteConnection("Data Source=" + connectionString + ";Version=3;");
            connection.Open();

            string insertSql = "INSERT INTO Risultati (ID_Documento, Risultato) VALUES (@ID_Documento, @Risultato)";
            SQLiteCommand insertCommand = new SQLiteCommand(insertSql, connection);

            insertCommand.Parameters.AddWithValue("@ID_Documento", id_documento);
            insertCommand.Parameters.AddWithValue("@Risultato", risultato);

            insertCommand.ExecuteNonQuery();

            connection.Close();
        }



        //metodo per quary generica 
        public void searchQuary(string table)
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source=" + connectionString + ";Version=3;");
            connection.Open();

            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = connection.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM " + table;

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                Console.WriteLine(myreader);
            }
            connection.Close();


        }





            //testa la connessione col DB 
            public void testConnection()
            
            {
                SQLiteConnection connection = new SQLiteConnection("Data Source=" + connectionString + ";Version=3;");
                try {
                    connection.Open();

                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        Console.WriteLine("Connection to SQLite database is successful!");
                    }
                    else
                    {
                        Console.WriteLine("Connection to SQLite database failed!");
                    }
                    connection.Close();
                } catch (Exception ex) { Console.WriteLine("something went wrong: " + ex); }
            }
        }

    }



        
    

