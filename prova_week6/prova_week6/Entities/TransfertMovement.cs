using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prova_week6.Entities
{
   public class TransfertMovement: Movimento
    {
        public string BancaOrigine { get; set; }
        public string BancaDestinazione { get; set; }

        public override string ToString()
        {
            return $"{(IsPrelievo ? "Prelievo" : "Versamento"),-15}{Importo,-15}{DataMovimento,-20}{"---",-30}{BancaOrigine,-25}{BancaDestinazione,-25}{"---",-15}{"---",-20}";
        }

    }
}
