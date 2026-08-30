using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsLab_Eventi_Ghouzlani
{
    public class ClsUtente
    {
        int ID;
        string nome;
        string cognome;
        string username;
        string password;
        string matricola;
        bool rappresentanteClasse;
        bool rappresentanteIstituto;
        char ruolo;
        string classeID;

        public int ID1 { get => ID; set => ID = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cognome { get => cognome; set => cognome = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Matricola { get => matricola; set => matricola = value; }
        public bool RappresentanteClasse { get => rappresentanteClasse; set => rappresentanteClasse = value; }
        public bool RappresentanteIstituto { get => rappresentanteIstituto; set => rappresentanteIstituto = value; }
        public char Ruolo { get => ruolo; set => ruolo = value; }
        public string ClasseID { get => classeID; set => classeID = value; }

        public ClsUtente()
        {

        }
    }
}
