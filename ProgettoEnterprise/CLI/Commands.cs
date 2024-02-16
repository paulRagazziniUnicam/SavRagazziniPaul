using Enterprise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoEnterprise
{
    //comandi utente
   public class Commands
    {
       
        //comando che esegue download e ricerca pattern sul file scaricato: params= nome file, pattern 
        public static void downloadAndSearch(string filename, string pattern) {

            FileDownloader downloader = new FileDownloader();
            downloader.downloadFile(filename);

            FileSearcher searcher = new FileSearcher();
            searcher.search(File_to_String.convert(filename), pattern);
        }

        //comando che avvia la lettura del file di logging 
        public static void readData() {
            using (StreamReader reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SaveLog.txt")))
            { 
                string fileContent = reader.ReadToEnd();

                Console.WriteLine(fileContent);
            }
        }

        
        //continua l'esecuzione dopo un aver applicato KMP ad un download
        public static int continueExecution() {
            return 0;
        }

        //stoppa l'esecuzione
        public static int stopExecution() {
            return 1;
        }

    }

    
}
