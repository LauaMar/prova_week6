using prova_week6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prova_week6
{
    public class Menu
    {
        public static void Start()
        {
            Console.WriteLine("===Benvenuto!===");

            int scelta = -1;
            bool uscita = false;
            ContoBancario contoAttivo = new ContoBancario();
            while (!uscita)
            {
                Console.WriteLine("Inserire il codice corrispondente all'azione che si desidera compiere: ");
                Console.WriteLine("Premere 1 per creare un nuovo conto corrente,");
                Console.WriteLine("Premere 2 per aggiungere un movimento,");
                Console.WriteLine("Premere 3 per stampare i dati del conto e i movimenti,");
                Console.WriteLine("Premere 0 per uscire");
                while (!int.TryParse(Console.ReadLine(), out scelta))
                {
                    Console.WriteLine("Codice inserito non corretto, riprova");
                }

                int numeroConto = 1;
                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("Inserisci il nome della banca");
                        BancaManager.CheckStringa(out string nomeBanca);

                        Console.WriteLine("Inserisci il saldo iniziale");
                        BancaManager.CheckDecimal(out decimal saldoIniziale);

                        contoAttivo = BancaManager.CreaNuovoAccount(numeroConto, DateTime.Now, nomeBanca, saldoIniziale);
                        numeroConto++;
                        Console.WriteLine();
                        break;
                    case 2:
                        bool isPrelievo = false;
                        int tipoMov = -1;
                        Console.WriteLine("Scegli il tipo di movimento da aggiungere: \n [1] --> prelievo, \n [2] --> versamento");
                        while(!(int.TryParse(Console.ReadLine(), out tipoMov)&&(tipoMov==1 ||tipoMov==2)))
                        {
                            Console.WriteLine("La scelta effettuata non corrisponde a nessuna opzione, riprova: ");
                        }
                        if (tipoMov == 1)
                        {
                             isPrelievo = true;
                        }

                        Console.WriteLine("inserisci l'importo della transazione:");
                        BancaManager.CheckDecimal(out decimal importo);

                        Console.WriteLine("Inserisci data e ora del movimento:");
                        BancaManager.CheckDateTime(out DateTime dataMovimento);

                        int tipoMovimento = BancaManager.ScegliMovimento();
                        try
                        {
                            BancaManager.AggiungiMovimento(contoAttivo, isPrelievo, importo, dataMovimento, tipoMovimento);
                        } catch(ContoInRossoException CE)
                        {
                            Console.WriteLine(CE.Message);
                            Console.WriteLine($"Credito disponibile: {CE.SaldoContoCorrente}€;  Prelievo richiesto: {CE.ImportoPrelievo}€. ");
                        }
                        Console.WriteLine();
                        break;
                    case 3:
                        int stampaMov = -1;
                        BancaManager.StampaInformazioniConto(contoAttivo);
                        Console.WriteLine();
                        Console.WriteLine("Vuoi vedere la lista movimenti? \n [0]--> NO \n [1]--> SI");
                        while (!(int.TryParse(Console.ReadLine(), out stampaMov) && (stampaMov == 0 || stampaMov == 1)))
                            Console.WriteLine("Scelta inserita non corretta, riprova:");
                        if(stampaMov==1)
                        {
                            BancaManager.StampaListaMovimenti(contoAttivo);
                            Console.WriteLine();
                        }
                        break;
                    case 0:
                        uscita = true;
                        break;
                    default:
                        Console.WriteLine("La scelta effettuata non corrisponde a nessuna azione!");
                        Console.WriteLine();
                        break;
                }

            }
        }
    } 
}
