using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoEnterprise.CLI.Interfaces
{
    public interface ICommands
    {
        public void downloadAndSearch(string filename, string pattern);

        public void readTable(int choice);

        public void readAllData();

        public void deleteAll();

    }
}
