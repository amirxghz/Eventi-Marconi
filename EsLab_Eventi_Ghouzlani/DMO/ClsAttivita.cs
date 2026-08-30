using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsLab_Eventi_Ghouzlani
{
    public class ClsAttivita
    {
        int ID;
        string titolo;
        string testo;
        int ordine;
        TimeSpan dalle;
        TimeSpan alle;
        int eventoID;

        public int ID1 { get => ID; set => ID = value; }
        public string Titolo { get => titolo; set => titolo = value; }
        public string Testo { get => testo; set => testo = value; }
        public int Ordine { get => ordine; set => ordine = value; }
        public TimeSpan Dalle { get => dalle; set => dalle = value; }
        public TimeSpan Alle { get => alle; set => alle = value; }
        public int EventoID { get => eventoID; set => eventoID = value; }

        public ClsAttivita()
        {

        }
    }
}
