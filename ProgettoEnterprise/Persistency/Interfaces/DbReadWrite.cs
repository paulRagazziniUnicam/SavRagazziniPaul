using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoEnterprise.Persistency.Interfaces
{
    public interface DbReadWrite
    {
        public void addDocument(string nome);

        public void addResoult(string stringa_cercata, int posizione);


        public void readAllResoults();

        public void readAllDocuments();

        public string getLastDocumentName();

        public void deleteAll();


    }
}
