using ProgettoEnterprise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise
{
    class FileSearcher
    {

        //metodo che esegue il calcolo della funzione prefisso che sarà usata nel KMP 
        private int[] ComputePrefixFunction(string pattern)
        {
            Logger.getInstance.write("STRINGA RICERCATA NEL FILE: " + pattern);

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
            int n = text.Length;
            int m = pattern.Length;
            int[] prefixFunction = ComputePrefixFunction(pattern);
            int q = 0;

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
                    Logger.getInstance.write("Pattern trovato alla posizione: " + (i - m + 1));
                    
                    q = prefixFunction[q - 1];
                }

            }
            Console.WriteLine("ricerca terminata");
            Logger.getInstance.write("_______________________________________________________________________________________");
            

        }


        public void search(String text, String pattern)
        {
            KMPSearch(text, pattern);
        }

       

    }
}
