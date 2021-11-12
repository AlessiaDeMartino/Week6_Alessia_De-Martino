using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione_WEEK6
{
    class AgentiManagerMock : IDbManager
    {

        static List<Agente> agenti = new List<Agente>()
        {
            new Agente{Nome="Alessia", Cognome="Franchi", CodiceFiscale="ALU678D", AreaGeografica="Basilicata", AnnoInizioAttivita=2008},
            new Agente{Nome="Leonardo", Cognome="Bianchi", CodiceFiscale="LFMB532S", AreaGeografica="Trentino", AnnoInizioAttivita=1999}
        };

        public bool AddAgent(string nome, string cognome, string codicefiscale, string areagrografica, int annoInizioAttivita)
        {
            Agente agenteInserire = new Agente { Nome = nome, Cognome = cognome, CodiceFiscale = codicefiscale, AreaGeografica = areagrografica, AnnoInizioAttivita = annoInizioAttivita };
            agenti.Add(agenteInserire);
            return true;
                
         }
        public Agente GetAgentByCF(string codicefiscale)
        {
            foreach (var itemX in agenti)
            {
                if (itemX.CodiceFiscale == codicefiscale)
                {
                    return itemX;
                }
            }
            return null;
        }
        public List<Agente> GetAgentByYear(int year)
        {
            List<Agente> agenteAnni = new List<Agente>();
            foreach (var itemY in agenti)
            {
                if (itemY.CalcolaAnniServizio()>=year)

                {
                    agenteAnni.Add(itemY);
                    return agenteAnni;
                }
            }
            return null;

        }
        public List<Agente> GetAgentsByArea(string area)
        {
            List<Agente> agenteArea = new List<Agente>();
            foreach (var item2 in agenti)
            {
                if (item2.AreaGeografica == area)
                {
                    agenteArea.Add(item2);
                    return agenteArea;
                }
            }
            return null;
        }
        public List<Agente> GetAllAgents()
        {
            return agenti;
        }
    }
}
