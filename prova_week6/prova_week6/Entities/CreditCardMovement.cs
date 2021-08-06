using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prova_week6.Entities
{
    public class CreditCardMovement : Movimento
    {
        public Tipologia Tipo { get; set; }
        public long NumeroCarta { get; set; }

        public override string ToString()
        {
            return $"{(IsPrelievo ? "Prelievo" : "Versamento"),-15}{Importo,-15}{DataMovimento,-20}{"---",-30}{"---",-25}{"---",-25}{Tipo,-15}{NumeroCarta,-20}";
        }
    }
}
    
