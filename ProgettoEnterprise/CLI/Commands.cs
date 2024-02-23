using Enterprise;
using ProgettoEnterprise.CLI.Interfaces;
using ProgettoEnterprise.FileManager.Interfaces;
using ProgettoEnterprise.Persistency.Interfaces;


namespace ProgettoEnterprise
{
    //comandi utente
   public class Commands : ICommands
    {
        private readonly DbReadWrite persistencyService;

        private readonly Downloader downloaderService;

        private readonly Searcher searcherService;


        //costruttore
        public Commands(DbReadWrite persistency, Downloader downloader, Searcher searcher)
        {
            this.persistencyService = persistency;
            this.downloaderService = downloader;
            this.searcherService = searcher;
        }



        //comando che esegue download e ricerca pattern sul file scaricato: params= nome file, pattern 
        public void downloadAndSearch(string filename, string pattern) {
           

            this.downloaderService.downloadFile(filename);
            

            this.searcherService.search(File_to_String.convert(filename), pattern);

           
            
        }

        //comando che avvia la lettura del file di logging 
        public void readTable(int choice) {
           
            if (choice == 1) { persistencyService.readAllDocuments(); } 
            else { 
                if (choice == 2) { 
                    persistencyService.readAllResoults(); } }
        }

        public void readAllData() {
            Console.WriteLine("DOCUMENTI: ");
            persistencyService.readAllDocuments();
            Console.WriteLine("RISULTATI DI RICERCA: ");
            persistencyService.readAllResoults();

        }

        //elimina tutto dal database
        public void deleteAll() {
            persistencyService.deleteAll();
        }

        
       

    }

    
}
