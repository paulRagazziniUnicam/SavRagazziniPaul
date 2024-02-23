using ProgettoEnterprise.Persistency.Interfaces;
using System.Net;
using ProgettoEnterprise.FileManager.Interfaces;




namespace ProgettoEnterprise
{
    //classe che scarica file da un URL specificato
   public class FileDownloader : Downloader 
    {

        private readonly DbReadWrite read_write_service;

        //costruttore
        public FileDownloader(DbReadWrite service)
        {
            read_write_service = service;
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

                    this.read_write_service.addDocument(name);

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore di download: {ex.Message}");
                }
            }
        }








        //non funziona (perchè?)
        public async void HttpDownload(string name)
        {

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string downloadPath = Path.Combine(desktopPath, (name + ".txt"));

            string url = "https://filesamples.com/samples/document/txt/";

            HttpClient client = new HttpClient();

            try
            {   //l'array di byte attende la risposta del Get di client, il cui response body verrà passato come array di byte
                byte[] text = await client.GetByteArrayAsync(url + name + ".txt");
                //crea un file in downloadPath e lo sovrascrive col contenuto del response body 
                File.WriteAllBytes(downloadPath, text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }


        }
      


      
    }


}

