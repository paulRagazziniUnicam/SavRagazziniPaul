using ProgettoEnterprise;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Enterprise
{
    //classe che scarica file da un URL specificato
    class FileDownloader
    {

        public FileDownloader()
        {

        }
        //scarica un file da https://filesamples.com/samples/document/txt/ specificando una delle tre possibilità
        public void downloadFile(String name)
        {

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string downloadPath = Path.Combine(desktopPath, (name + ".txt"));

            string url = "https://filesamples.com/samples/document/txt/";

            //istanzia una WebClient che gestice lo stack TCP in automatico 
#pragma warning disable
            using (WebClient client = new WebClient())
#pragma warning restore
            {
                try
                {
                    client.DownloadFile(url + (name + ".txt"), downloadPath);
                    Console.WriteLine("Download avvenuto con successo.");

                    Logger.getInstance.write("NOME FILE: " + name);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore di download: {ex.Message}");
                }
            }
        }

        
    }
}
