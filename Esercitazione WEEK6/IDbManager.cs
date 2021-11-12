using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione_WEEK6
{
    interface IDbManager
    {
        public List<Agente> GetAllAgents();
        public Agente GetAgentByCF(string codicefiscale);
        public List<Agente> GetAgentsByArea(string area);
        public List<Agente> GetAgentByYear(int year);
        public bool AddAgent(string nome, string cognome, string codicefiscale, string areagrografica, int annoInizioAttivita);
    }
}
