using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Enterprise
{
    //classe che converte un file in una stringa per permettere a KMP di analizzarla 
    class File_to_String
    {
        //metodo che prende il nome del file da convertire e lo converte in stringa
        public static String convert(String name)

        {   //path del file scaricato sul desktop 
            String path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), ((name + ".txt")));
#pragma warning disable
            String result = null;
#pragma warning restore

            try
            {
                // apre il file alla destinazione specificata
                using (StreamReader reader = new StreamReader(path))
                {
                    
                    //finchè non arriva alla fine del file aggiunge alla stringa buffer il contenuto 
                    while (
                        (reader.ReadLine()) != null)
                    {
                        result = result + reader.ReadLine();
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Errore di lettura file: " + e.Message);
            }


#pragma warning disable

            return result;

#pragma warning restore
        }
    }
}

