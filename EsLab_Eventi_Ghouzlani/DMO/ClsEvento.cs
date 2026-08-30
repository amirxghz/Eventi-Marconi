using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsLab_Eventi_Ghouzlani
{
    public class ClsEvento
    {
        int ID;
        string nome;
        string descrizione;
        DateTime dal;
        DateTime al;
        int adminID;

        public int ID1 { get => ID; set => ID = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Descrizione { get => descrizione; set => descrizione = value; }
        public DateTime Dal { get => dal; set => dal = value; }
        public DateTime Al { get => al; set => al = value; }
        public int AdminID { get => adminID; set => adminID = value; }

        public ClsEvento()
        {

        }
    }
}
