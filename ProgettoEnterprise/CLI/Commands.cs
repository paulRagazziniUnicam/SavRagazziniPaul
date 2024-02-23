using Enterprise;
using Microsoft.Extensions.DependencyInjection;
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
        public void readData(int choice) {
           
            if (choice == 1) { persistencyService.readAllDocuments(); } 
            else { 
                if (choice == 2) { 
                    persistencyService.readAllResoults(); } }
        }

        public void deleatAll() {
            persistencyService.deleteAll();
        }

        
       

    }

    
}
