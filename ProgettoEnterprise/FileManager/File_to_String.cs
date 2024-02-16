using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Enterprise
{
    class File_to_String
    {
        public static String convert(String name)

        {
            String path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), ((name + ".txt")));
#pragma warning disable
            String result = null;
#pragma warning restore

            try
            {
                // Open the file for reading
                using (StreamReader reader = new StreamReader(path))
                {
                    // Read and display the lines from the file until the end of the file is reached

                    while (
                        (reader.ReadLine()) != null)
                    {
                        result = result + reader.ReadLine();
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
            }


#pragma warning disable

            return result;

#pragma warning restore
        }
    }
}

