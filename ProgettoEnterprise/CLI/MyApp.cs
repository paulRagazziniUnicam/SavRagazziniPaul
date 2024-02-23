
using ProgettoEnterprise.CLI.Interfaces;
using System;


namespace ProgettoEnterprise
{
    //classe che chiama tutti gli handeler 
    public class MyApp
    {

        //variabile flag per l'uscita dall'esecuzione
        private int stopFlag = 0;

        //Comandi iniettati che richiamano a loro volta tutti i servizi dell'app
        private readonly ICommands commandService;

        public MyApp(ICommands commands)
        {
            commandService = commands;
           
        }

        


        //loop di esecuzione dell'applicazione


        public void execute()
        {
            
            while (this.stopFlag == 0)
            {
                Console.WriteLine("'R' per leggere i dati, 'W' per eseguire una ricerca, 'C' per cancellare le entry del DB");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "R":
                        commandService.readAllData();
                        break;

                    case "W":
                        Console.Write("Scrivere il nome del file da scaricare:  ");
                        Console.WriteLine("Le opzioni sono: 'sample1' , 'sample2' ,'sample3' ");

                        string filename = Console.ReadLine();

                        Console.WriteLine("inserire la stringa che si vuole cercare: ");
                        string pattern = Console.ReadLine();

                        commandService.downloadAndSearch(filename, pattern);
                        break;

                    case "C":
                        commandService.deleteAll();
                        break;

                    default: Console.WriteLine("INPUT ERRATO");
                        
                        break;

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

