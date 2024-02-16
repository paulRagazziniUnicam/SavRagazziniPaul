using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoEnterprise
{
    //classe per logging singleton
    public sealed class Logger
    {
        //path relative al file txt di logging nella BaseDirectory
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SaveLog.txt");
#pragma warning disable
        private static Logger instance = null;
#pragma warning restore
        private Logger()
        { 
        }


        public static Logger getInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }



        //metodo per scrivere un log passando il testo voluto
        public void write(string text)
        {
            try
            {
                // Lo StreamWriter aggiungerà il testo a fine file 
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    // apre un thread separato per scrivere il testo in modo da ottimizzare le performance in caso di molte chiamate 
                    writer.WriteLineAsync(text);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
