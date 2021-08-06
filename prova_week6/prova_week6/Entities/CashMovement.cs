using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prova_week6.Entities
{
   public class CashMovement : Movimento
    {
        public string Esecutore { get; set; }

        public override string ToString()
        {
            return $"{(IsPrelievo ? "Prelievo" : "Versamento"),-15}{Importo,-15}{DataMovimento,-20}{Esecutore,-30}{"---",-25}{"---",-25}{"---",-15}{"---",-20}";
        }
    }
}
