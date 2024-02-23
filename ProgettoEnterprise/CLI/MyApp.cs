using Microsoft.Extensions.DependencyInjection;
using ProgettoEnterprise.CLI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoEnterprise
{
    //classe che chiama tutti gli handeler 
    public class MyApp
    {


        private int stopFlag = 0;

        private readonly ICommands commandService;

        public MyApp(ICommands commands)
        {
            commandService = commands;
           
        }

        


        //loop di esecuzione dell'applicazione


        public void execute()
        {
            var serviceProvider = new ServiceCollection()
               .AddTransient<ICommands, Commands>()
               .BuildServiceProvider();
               var service = serviceProvider.GetService<ICommands>();

            while (this.stopFlag == 0)
            {
                Console.WriteLine("Per leggere i dati salvati digitare 'R', per eseguire un download e fare la ricerca di un pattern digitare 'W'");
                if (Console.ReadLine() == "R") { service.readData(1); }
                else
                {

                    Console.Write("Scrivere il nome del file da scaricare:  ");
                    Console.WriteLine("Le opzioni sono: 'sample1' , 'sample2' ,'sample3' ");

                    string filename = Console.ReadLine();

                    Console.WriteLine("inserire la stringa che si vuole cercare: ");
                    string pattern = Console.ReadLine();

                   service.downloadAndSearch(filename, pattern);
                   
                }

                Console.WriteLine("Continuare l'esecuzione? (Y/N)");
                string response = Console.ReadLine();
                if (response == "N")
                {
                    this.stopFlag = 1;
                }


            }
        }
    }
}

