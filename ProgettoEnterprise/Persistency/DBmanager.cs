using ProgettoEnterprise.Persistency;
using ProgettoEnterprise.Persistency.Interfaces;

namespace ProgettoEnterprise
{
    //classe adattatore per interazione con DB SQlite
    class DBmanager : DbReadWrite
    {
        //istanza del DbContext
        private MyDBcontext context;

        //il costruttore istanzia il context
        public DBmanager()
        {
            context = new MyDBcontext();
            context.Database.EnsureCreated();

        }

        //insert documento nel DB 
        public void addDocument(string nome)
        {
            context.Documenti.Add(new Documento { Nome = nome });
            context.SaveChanges();
        }

        //aggiunge un Risultato a seguito di una ricerca di una stringa in un file 
        public void addResoult( string stringa_cercata, int posizione)
        {
            context.Risultati.Add(new Risultato { NomeFile = getLastDocumentName(), StringaCercata = stringa_cercata, NumeroMatch = posizione });
            context.SaveChanges();
        }

        //legge i Risultati di ricerca dal Db
        public void readAllResoults()
        {
            var entities = context.Risultati.ToList();
            foreach (var entity in entities)
            {
                Console.Write($"Nome File: {entity.NomeFile}" + ", ");
                Console.Write($"Stringa Cercata: {entity.StringaCercata}" + ", ");
                Console.WriteLine($"Numero di Match: {entity.NumeroMatch}");
            }
        }

        //legge i Documenti dal Db
        public void readAllDocuments()
        {
            var entities = context.Documenti.ToList();
            foreach (var entity in entities)
            {
                Console.Write($"ID: {entity.ID}" + ", ");
                Console.WriteLine($"Nome: {entity.Nome}");
            }
        }

        //ritorna l'ultimo documento scaricato 
        public string getLastDocumentName()
        {
            var entities = context.Documenti.ToList();
            return entities.Last().Nome;

        }

        //elimina tutti i dati dal database
        public void deleteAll()
        {

            
            var allRes = context.Risultati.ToList(); // Fetch all data from the table
            context.Risultati.RemoveRange(allRes); // Remove all data

            var allDocs = context.Documenti.ToList();
            context.Documenti.RemoveRange(allDocs);
            context.SaveChanges(); // Commit changes to the database
        }


}
}



        
    

