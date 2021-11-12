using System;
using System.Collections.Generic;
using System.Linq;



//****************RISPOSTE QUIZ:**********************
//1) a,e,g
//2) b,d
//3)a,c




//Implementare una Console App che tramite menù permetta di:
//-Mostrare tutti gli agenti di polizia
//- Scelta un’area geografica, mostrare gli agenti assegnati a quell’area
//- Scelti gli anni di servizio, mostrare gli agenti con anni di servizio maggiori o uguali rispetto all’input
//- Inserire un nuovo agente solo se non è già presente nel database
//L’agente ha le seguenti caratteristiche:
//-Nome
//- Cognome
//- Codice fiscale
//- Area geografica
//- Anno di inizio attività
//L’agente deriva da un’astrazione di persona. La persona ha le seguenti caratteristiche:
//-Nome
//- Cognome
//- Codice fiscale
//Gli agenti andranno salvati su SqlServer tramite Ado .Net.
//Note:
//-Il nome del database deve essere “ProvaAgenti”
//- I nomi delle colonne della/e tabella/e devono essere uguali ai nomi delle proprietà della/e classe/i.
//- I dati relativi all’agente devono essere stampati nel seguente formato:
//CF: CodiceFiscaleDell’Agente - Nome: IlNomeDellAgente – Cognome: IlCognomeDellAgente – Anni di Servizio: AnniDiServizioDellAgente
//- Gli agenti sono uguali se hanno lo stesso codice fiscale
//- Gli anni di servizio sono calcolati nel seguente modo: anno corrente(2021) meno l’anno di inizio attività. Ad es. se l’anno di inizio attività è 1993, gli anni di servizio sono 2021-1993 = 28

namespace Esercitazione_WEEK6
{
    class Program
    {
        //Devo implementare la parte Mock per l'area geografica e l'inserimento del nuovo agente
        static void Main(string[] args)
        {
            DbAgentiManager dB = new DbAgentiManager();
            AgentiManagerMock aM = new AgentiManagerMock();

            bool continua = true;
            while (continua)
            {

                int choice;
                do
                {
                    Console.WriteLine("\nBenvenuto nell'area Agenti di Polizia! Cosa desideri fare?");
                    Console.WriteLine("[1] Mostra tutti gli agenti");
                    Console.WriteLine("[2] Mostra gli agenti di un'area geografica da te scelta");
                    Console.WriteLine("[3] Mostra agenti con anni di servizio maggiori o uguali agli anni da te inseriti");
                    Console.WriteLine("[4] Inserisci nuovo agente");
                    Console.WriteLine("[0] Esci");
                } while (!((int.TryParse(Console.ReadLine(), out choice)) && choice >= 0 && choice <= 4));

                switch (choice)
                {
                    case 1:
                        List<Agente> agenti = new List<Agente>();
                        agenti = dB.GetAllAgents();
                        //agenti = aM.GetAllAgents();
                        foreach (var item in agenti)
                         Console.WriteLine(item.ToString());
                        break;
                    case 2:

                        //Parte Opzionale: 
                        List<Agente> agentiAreeG = new List<Agente>();
                        agentiAreeG = dB.PrintAreeGeografiche();
                        Console.WriteLine("Scegli un'area geografica tra queste indicate!");
                        string sceltArea = Console.ReadLine();                       
                        bool agenteArea = ControlArea(sceltArea, agentiAreeG);
                        if (!(agenteArea))
                        {
                            Console.WriteLine("Non hai inserito un'area geografica presente nel database");
                        }
                        else
                        {

                            List<Agente> agentiArea = new List<Agente>();
                            agentiArea = dB.GetAgentsByArea(sceltArea);

                            //if (!(agentiArea.Any()))
                            //{
                            //    Console.WriteLine("Non sono stati trovati agenti in quell'area geografica!");
                            //}
                            //else
                            //{
                            //    Console.WriteLine("Ecco gli agenti corrispondenti all'area inserita:");

                                foreach (var item1 in agentiArea)
                                {
                                    Console.WriteLine(item1.ToString());
                                }                           
                        }
                        break;
                    case 3:
                        int anniServizioMin;
                        do
                        {
                            Console.WriteLine("Scegli gli anni di servizio minimi di un agente");
                        } while (!(int.TryParse(Console.ReadLine(), out anniServizioMin) && anniServizioMin > 0));
                        List<Agente> agentiAnniServizio = new List<Agente>();
                        agentiAnniServizio = dB.GetAgentByYear(anniServizioMin);

                        //agentiAnniServizio = aM.GetAgentByYear(anniServizioMin);

                        if (!(agentiAnniServizio.Any()))
                        {
                            Console.WriteLine("Non sono stati trovati agenti con quegli anni di servizio!");
                        }
                        else
                        {
                            foreach (var item in agentiAnniServizio)
                            {
                                Console.WriteLine(item.ToString());
                            }
                        }

                        break;
                    case 4:
                        Console.WriteLine("Inserisci Codice Fiscale");
                        string codice_fiscale = Console.ReadLine();
                        if (dB.GetAgentByCF(codice_fiscale) != null)
                        {
                            Console.WriteLine("Codice Fiscale associato ad un agente già presente.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Inserisci Nome");
                            string name = Console.ReadLine();
                            Console.WriteLine("Inserisci Cognome");
                            string surname = Console.ReadLine();
                            Console.WriteLine("Inserisci Area geografica");
                            string areaG = Console.ReadLine();
                            int annoInizio;
                           
                            do
                            {
                              Console.WriteLine("Inserisci anno inizio attività");
                            } while (!(int.TryParse(Console.ReadLine(), out annoInizio) && annoInizio > 0));

                            Agente agenteInserire = new Agente(name, surname, codice_fiscale, areaG, annoInizio);

                            bool esito = dB.AddAgent(name, surname, codice_fiscale, areaG, annoInizio);

                            if (!(esito))
                            {
                                Console.WriteLine("Errore. Non è stato possibile aggiungere!");
                            }
                            else
                            {
                                Console.WriteLine("Aggiunto correttamente");
                            }
                        }
                        break;
                    case 0:
                        continua = false;
                        break;
                }
            }
        }

        private static bool ControlArea(string sceltArea, List<Agente> agentiAreeG)
        {
               bool utenteArea = true;                
                foreach (var item in agentiAreeG)
                    if (item.AreaGeografica == sceltArea)
                    {
                    utenteArea = true;
                    return utenteArea;
                    }     
                else
                {
                    utenteArea = false;
                }
                return utenteArea;

            }
        }
    }


