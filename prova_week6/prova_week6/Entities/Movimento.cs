using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prova_week6.Entities
{
    public class Movimento
    {
        public decimal Importo { get; set; }
        public DateTime DataMovimento { get; set; }
        public bool IsPrelievo { get; set; }
        public ContoBancario Conto { get; set; }

        public void AggiornaSaldo()
        {
            if (IsPrelievo)
            {
                if (Importo <= Conto.Saldo)
                    Conto.Saldo -= Importo;
                else
                    throw new ContoInRossoException("Saldo non sufficiente per effettuare il prelievo!")
                    {
                        SaldoContoCorrente = Conto.Saldo,
                        ImportoPrelievo = Importo
                    };

            }
            else
                Conto.Saldo += Importo;
        }
        public void AggiornaUltimaOperazione()
        {
            if (Conto.DataUltimaOperazione < DataMovimento)
                    Conto.DataUltimaOperazione = DataMovimento;
        }
    }
}
