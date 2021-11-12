using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione_WEEK6
{
    class Agente:Persona
    {
        public string AreaGeografica { get; set; }
        public int AnnoInizioAttivita { get; set; }       
        
        public Agente()
        {

        }

        public Agente (string nome, string cognome, string codicefiscale, string area, int anno)
        {
            Nome = nome;
            Cognome = cognome;
            CodiceFiscale = codicefiscale;
            AnnoInizioAttivita = anno;
            AreaGeografica = area;
            
        }

        
               


        //I dati relativi all’agente devono essere stampati nel seguente formato:
        //CF: CodiceFiscaleDell’Agente - Nome: IlNomeDellAgente – Cognome: IlCognomeDellAgente – Anni di Servizio: AnniDiServizioDellAgente

        public override string ToString()
        {
            return $"CF: {CodiceFiscale} - Nome: {Nome}- Cognome: {Cognome} - Anni di servizio:{CalcolaAnniServizio()}";
        }

        public override int CalcolaAnniServizio()
        {
            int anniServizio;
            anniServizio = DateTime.Now.Year - AnnoInizioAttivita;
            return anniServizio;
        }
    }
}
