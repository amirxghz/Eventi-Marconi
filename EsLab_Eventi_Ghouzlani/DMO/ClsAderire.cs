using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsLab_Eventi_Ghouzlani
{
    public class ClsAderire
    {
        int IdAderire;
        bool iscritto;
        bool autorizzato;
        bool pagato;
        bool partecipato;
        int attivitaID;
        string classeID;
        int studenteID;

        public int IDaderire { get => IdAderire; set => IdAderire = value; }
        public bool Iscritto { get => iscritto; set => iscritto = value; }
        public bool Autorizzato { get => autorizzato; set => autorizzato = value; }
        public bool Pagato { get => pagato; set => pagato = value; }
        public bool Partecipato { get => partecipato; set => partecipato = value; }
        public int AttivitaID { get => attivitaID; set => attivitaID = value; }
        public string ClasseID { get => classeID; set => classeID = value; }
        public int StudenteID { get => studenteID; set => studenteID = value; }

        public ClsAderire()
        {

        }
    }
}