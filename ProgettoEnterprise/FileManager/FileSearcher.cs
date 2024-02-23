using Microsoft.Extensions.DependencyInjection;
using ProgettoEnterprise;

using ProgettoEnterprise.FileManager.Interfaces;
using ProgettoEnterprise.Persistency.Interfaces;


namespace ProgettoEnterprise
{
    //classe che applica l'algoritmo KMP su una stringa
    class FileSearcher : Searcher
    {
        private readonly DbReadWrite persistencyService;
     
        public FileSearcher(DbReadWrite persistency)
        {   this.persistencyService = persistency;
        }

        private DbReadWrite createService()
        {
            var serviceProvider = new ServiceCollection()
               .AddTransient<DbReadWrite, DBmanager>()
               .BuildServiceProvider();

            return serviceProvider.GetService<DbReadWrite>();
        }

        //metodo che esegue il calcolo della funzione prefisso che sarà usata nel KMP 
        private int[] ComputePrefixFunction(string pattern)
        {

            int m = pattern.Length;
            int[] prefixFunction = new int[m];
            prefixFunction[0] = 0;
            int k = 0;

            for (int q = 1; q < m; q++)
            {
                while (k > 0 && pattern[k] != pattern[q])
                {
                    k = prefixFunction[k - 1];
                }

                if (pattern[k] == pattern[q])
                {
                    k++;
                }

                prefixFunction[q] = k;
            }

            return prefixFunction;
        }



        //metodo che esegue il pattern matching a seguito del calcolo della funzione prefisso
        private void KMPSearch(string text, string pattern)
        {
            var serviceProvider = new ServiceCollection()
              .AddTransient<DbReadWrite, DBmanager>()
              .BuildServiceProvider();

            var service = serviceProvider.GetService<DbReadWrite>();



            int n = text.Length;
            int m = pattern.Length;
            int[] prefixFunction = ComputePrefixFunction(pattern);
            int q = 0;
            int numeroMatch = 0;

            for (int i = 0; i < n; i++)
            {
                while (q > 0 && pattern[q] != text[i])
                {
                    q = prefixFunction[q - 1];
                }

                if (pattern[q] == text[i])
                {
                    q++;
                }

                if (q == m)
                {
                    Console.WriteLine("Pattern trovato alla posizione: " + (i - m + 1));
                    numeroMatch++;

                   
                    
                    

                    
                    q = prefixFunction[q - 1];
                }

            }
            service.addResoult(pattern, numeroMatch);

        }


        public void search(String text, String pattern)
        {
           
            KMPSearch(text, pattern);
        }

       

    }
}
