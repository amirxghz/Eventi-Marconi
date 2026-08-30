using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsLab_Eventi_Ghouzlani
{
    public class ClsClasse
    {
        string sigla;
        string aula;
        byte anno;
        string sezione;
        int indirizzoID;

        public string Sigla { get => sigla; set => sigla = value; }
        public string Aula { get => aula; set => aula = value; }
        public byte Anno { get => anno; set => anno = value; }
        public string Sezione { get => sezione; set => sezione = value; }
        public int IndirizzoID { get => indirizzoID; set => indirizzoID = value; }

        public ClsClasse()
        {

        }
    }
}
