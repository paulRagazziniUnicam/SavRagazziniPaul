using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoEnterprise.Persistency
{
    public class Risultato
    {
        [Key]
        public string NomeFile { get; set; }

        public string StringaCercata { get; set;}

        public int NumeroMatch { get; set; }
    }
}
