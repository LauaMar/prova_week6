using prova_week6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prova_week6
{
    public static class BancaManager
    {
        private const long minNumeroCarta = 1000000000000000;
        private const long maxNumeroCarta = 10000000000000000;


        public static ContoBancario CreaNuovoAccount(int numeroconto, DateTime dataUltimaOp, string nomeBanca, decimal saldoIniziale)
        {
            ContoBancario nuovoConto = new ContoBancario()
            {
                Numero = numeroconto,
                DataUltimaOperazione = dataUltimaOp,
                NomeBanca = nomeBanca,
                Saldo = saldoIniziale
            };
            return nuovoConto;
        }

        public static void AggiungiMovimento(ContoBancario conto, bool isPrelievo, decimal importo, DateTime dataMovimento, int tipoMovimento)
        {
            switch (tipoMovimento)
            {
                case 1:
                    Console.WriteLine("Inserisci nome e cognome Esecutore:");
                    CheckStringa(out string esecutore);

                    CashMovement cm = new CashMovement()
                    {
                        IsPrelievo = isPrelievo,
                        Importo = importo,
                        DataMovimento = dataMovimento,
                        Esecutore = esecutore,
                        Conto = conto
                    };
                    cm.AggiornaSaldo();
                    cm.AggiornaUltimaOperazione();
                    conto.ListaMovimenti.Add(cm);
                    Console.WriteLine("Movimento aggiunto con successo!");
                    break;
                case 2:
                    Console.WriteLine("Inserisci nome banca di origine:");
                    CheckStringa(out string bancaOrigine);
                    Console.WriteLine("Inserisci nome banca di destinazione:");
                    CheckStringa(out string bancaDestinazione);

                    TransfertMovement tm = new TransfertMovement()
                    {
                        IsPrelievo = isPrelievo,
                        Importo = importo,
                        DataMovimento = dataMovimento,
                        BancaOrigine = bancaOrigine,
                        BancaDestinazione = bancaDestinazione,
                        Conto = conto
                    };
                    tm.AggiornaSaldo();
                    tm.AggiornaUltimaOperazione();
                    conto.ListaMovimenti.Add(tm);
                    Console.WriteLine("Movimento aggiunto con successo!");
                    break;
                case 3:
                    Console.WriteLine("scegli tipo carta");
                    int tipoCarta = ScegliTipoCarta();
                    long numeroCarta = 0;
                    Console.WriteLine("Inserisci numero carta (formato: aaaa bbbb cccc dddd):");
                    while (!(long.TryParse(Console.ReadLine(), out numeroCarta) && numeroCarta >= minNumeroCarta && numeroCarta < maxNumeroCarta))
                        Console.WriteLine("Numero carta inserito non valido, riprova");
                    

                    CreditCardMovement ccm = new CreditCardMovement()
                    {
                        IsPrelievo = isPrelievo,
                        Importo = importo,
                        DataMovimento = dataMovimento,
                        Tipo = (Tipologia)tipoCarta,
                        NumeroCarta = numeroCarta,
                        Conto = conto
                    };
                    ccm.AggiornaSaldo();
                    ccm.AggiornaUltimaOperazione();
                    conto.ListaMovimenti.Add(ccm);
                    Console.WriteLine("Movimento aggiunto con successo!");
                    break;
                default:
                    Console.WriteLine("Hai inserito un codice che non corrisponde a nessuna scelta!");
                    break;
            }
                

        }

        public static void StampaInformazioniConto(ContoBancario conto)
        {
            Console.WriteLine("{0,-10}{1,-50}{2,-10}{3,-30}", "Numero", "Nome della banca", "Saldo", "Data Ultima Operazione");
            Console.WriteLine();
            Console.WriteLine($"{conto.Numero,-10}{conto.NomeBanca,-50}{conto.Saldo,-10}{conto.DataUltimaOperazione,-30}");
            Console.WriteLine();
        }

        public static void StampaListaMovimenti(ContoBancario conto)
        {
            Console.WriteLine("{0,-15}{1,-15}{2,-20}{3,-30}{4,-25}{5, -25}{6, -15}{7,-20}", "Tipo", "Importo", "Data", "Esecutore", "Banca Origine" , "Banca Destinazione", "Tipo Carta", "Numero Carta");
            Console.WriteLine();
            foreach (Movimento m in conto.ListaMovimenti)
                Console.WriteLine(m.ToString());
            Console.WriteLine();
        }


        public static void CheckStringa (out string stringa)
        {
            stringa = Console.ReadLine();
            while (string.IsNullOrEmpty(stringa))
            {
                Console.WriteLine("Hai inserito una stringa vuota, riprova");
                stringa = Console.ReadLine();
            }
        }
        public static void CheckDecimal (out decimal numero)
        {
            while (!(decimal.TryParse(Console.ReadLine(), out numero) && numero > 0))
            {
                Console.WriteLine("Hai inserito un saldo iniziale non valido, riprova");
            }
        }
        public static void CheckDateTime(out DateTime dataOra)
        {
            while (!(DateTime.TryParse(Console.ReadLine(), out dataOra) && dataOra <= DateTime.Now))
                Console.WriteLine("La data o l'ora del movimento inserito non sono corrette, riprova");
        }

        public static int ScegliTipoCarta()
        {
            int sceltaCarta = -1;
            Console.WriteLine("Scegli il tipo di carta di credito:");
            Console.WriteLine("[1] --> AMEX");
            Console.WriteLine("[2] --> VISA");
            Console.WriteLine("[3] --> MASTERCARD");
            Console.WriteLine("[4] --> OTHER");
            while (!(int.TryParse(Console.ReadLine(), out sceltaCarta) && sceltaCarta >= (int)Tipologia.AMEX+1 && sceltaCarta <= (int)Tipologia.OTHER+1))
                Console.WriteLine("Il codice inserito è errato o non corrisponde a nessuna scelta, riprova");

            return (sceltaCarta-1);
        }

        public static int ScegliMovimento()
        {
            int sceltaMov = -1;
            Console.WriteLine("Scegli il tipo di movimento:");
            Console.WriteLine("[1] --> Cash Movement");
            Console.WriteLine("[2] --> Transfert Movement");
            Console.WriteLine("[3] --> CreditCard Movement");
            while (!(int.TryParse(Console.ReadLine(), out sceltaMov) && sceltaMov >=1 && sceltaMov <=3))
                Console.WriteLine("Il codice inserito è errato o non corrisponde a nessuna scelta, riprova");

            return sceltaMov;
        }


    }
}
