using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prova_week6.Entities
{
   public class ContoBancario
    {
        public int Numero { get; set; }
        public DateTime DataUltimaOperazione { get; set; }
        public string NomeBanca { get; set; }
        public decimal Saldo { get; set; }
        public IList<Movimento> ListaMovimenti { get; set; } = new List<Movimento>();

    }
}
