using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione_WEEK6
{
    abstract class Persona
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }

        public Persona()
        {

        }

        public Persona(string nome, string cognome, string codicefiscale)
        {
            Nome = nome;
            Cognome = cognome;
            CodiceFiscale = codicefiscale;

        }
        public abstract int CalcolaAnniServizio();
    }
}
