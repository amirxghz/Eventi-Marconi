using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsLab_Eventi_Ghouzlani
{
    public partial class FrmIscrizioni : Form
    {
        private List<ClsEvento> _eventi = new List<ClsEvento>();
        private List<ClsUtente> _iscrizioniEventoCorrente =new List<ClsUtente>();
        private List<List<ClsAderire>> _adesioniEventoCorrente =new List<List<ClsAderire>>();

        private bool _aggiornamentoInterno = false;

        public FrmIscrizioni()
        {
            InitializeComponent();
        }

        private void FrmIscrizioni_Load(object sender, EventArgs e)
        {
            CaricaEventi();
        }

        private void CaricaEventi()
        {
            string errore;

            _eventi = ClsEventoBL.GetAll(ref Program.conn,out errore);

            if (!string.IsNullOrEmpty(errore))
                MessageBox.Show("Errore nel caricamento eventi: " + errore,"Errore",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else
                PopolaListViewEventi(_eventi);
        }

        private void PopolaListViewEventi(List<ClsEvento> eventi)
        {
            List<ClsEvento> eventiOrdinati =eventi.OrderBy(ev => ev.Dal).ToList();

            lvEventi.Items.Clear();

            for (int i = 0; i < eventiOrdinati.Count; i++)
            {
                ClsEvento ev = eventiOrdinati[i];

                ListViewItem lvi =new ListViewItem(ev.Nome);
                lvi.SubItems.Add(ev.Dal.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(ev.Al.ToString("dd/MM/yyyy"));
                lvi.Tag = ev;
                lvEventi.Items.Add(lvi);
            }
        }

        private void lvEventi_SelectedIndexChanged(object sender,EventArgs e)
        {
            if (lvEventi.SelectedItems.Count == 0)
            {
                lvIscrizioni.Items.Clear();
                _iscrizioniEventoCorrente.Clear();
                _adesioniEventoCorrente.Clear();
                chxbPagato.Enabled = false;
            }
            else
            {
                ClsEvento evento =(ClsEvento)lvEventi.SelectedItems[0].Tag;
                CaricaIscrizioni(evento.ID1);
                rtbDescrizione.Text = evento.Descrizione;
            }
        }

        private void CaricaIscrizioni(int eventoID)
        {
            string errore;

            List<ClsAttivita> attivitaEvento =ClsAttivitaBL.GetByEventoID(ref Program.conn,eventoID,out errore);

            if (!string.IsNullOrEmpty(errore))
            {
                MessageBox.Show("Errore nel caricamento attività: " + errore,"Errore",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                _iscrizioniEventoCorrente.Clear();
                _adesioniEventoCorrente.Clear();

                int i = 0;

                while (i < attivitaEvento.Count)
                {
                    List<ClsAderire> adesioni =ClsAderireBL.GetByAttivitaID(ref Program.conn, attivitaEvento[i].ID1, out errore);

                    if (string.IsNullOrEmpty(errore))
                    {
                        int j = 0;

                        while (j < adesioni.Count)
                        {
                            ClsAderire ad = adesioni[j];

                            if (ad.Iscritto && ad.StudenteID > 0)
                            {
                                int indiceStudente = -1;
                                int k = 0;

                                while (k < _iscrizioniEventoCorrente.Count && indiceStudente == -1)
                                {
                                    if (_iscrizioniEventoCorrente[k].ID ==ad.StudenteID)
                                        indiceStudente = k;
                                    k++;
                                }

                                if (indiceStudente == -1)
                                {
                                    ClsUtente studente =ClsUtenteBL.GetByID(ref Program.conn,ad.StudenteID,out errore);

                                    if (studente != null)
                                    {
                                        _iscrizioniEventoCorrente.Add(studente);

                                        _adesioniEventoCorrente.Add(new List<ClsAderire>());

                                        indiceStudente = _iscrizioniEventoCorrente.Count - 1;
                                    }
                                }
                                if (indiceStudente >= 0)
                                    _adesioniEventoCorrente[indiceStudente].Add(ad);
                            }

                            j++;
                        }
                    }

                    i++;
                }
                PopolaListViewIscrizioni(_iscrizioniEventoCorrente);
            }
        }

        private void PopolaListViewIscrizioni(List<ClsUtente> iscrizioni)
        {
            lvIscrizioni.Items.Clear();
            int i = 0;
            while (i < iscrizioni.Count)
            {
                ClsUtente studente = iscrizioni[i];

                int indiceStudente = -1;
                int j = 0;

                while (j < _iscrizioniEventoCorrente.Count &&indiceStudente == -1)
                {
                    if (_iscrizioniEventoCorrente[j].ID == studente.ID)
                        indiceStudente = j;
                    j++;
                }

                if (indiceStudente >= 0)
                {
                    List<ClsAderire> adesioni =_adesioniEventoCorrente[indiceStudente];

                    bool haPartecipato = false;
                    bool haPagato = true;

                    int k = 0;

                    while (k < adesioni.Count)
                    {
                        if (adesioni[k].Partecipato)
                            haPartecipato = true;

                        if (!adesioni[k].Pagato)
                            haPagato = false;

                        k++;
                    }

                    ListViewItem lvi =new ListViewItem(studente.Nome + " " + studente.Cognome);
                    lvi.SubItems.Add(studente.ClasseID);
                    lvi.SubItems.Add(haPartecipato ? "Si" : "No");
                    lvi.SubItems.Add(haPagato ? "Si" : "No");
                    lvi.Tag = studente;
                    lvIscrizioni.Items.Add(lvi);
                }
                i++;
            }
        }

        private void lvIscrizioni_SelectedIndexChanged(object sender,EventArgs e)
        {
            if (lvIscrizioni.SelectedItems.Count == 0)
                chxbPagato.Enabled = false;
            else
            {
                ClsUtente studente =(ClsUtente)lvIscrizioni.SelectedItems[0].Tag;

                int indiceStudente = -1;
                int i = 0;

                while (i < _iscrizioniEventoCorrente.Count &&indiceStudente == -1)
                {
                    if (_iscrizioniEventoCorrente[i].ID ==studente.ID)
                        indiceStudente = i;
                    i++;
                }

                if (indiceStudente >= 0)
                {
                    List<ClsAderire> adesioni =_adesioniEventoCorrente[indiceStudente];

                    bool haPagato = true;

                    int j = 0;

                    while (j < adesioni.Count)
                    {
                        if (!adesioni[j].Pagato)
                            haPagato = false;
                        j++;
                    }

                    _aggiornamentoInterno = true;

                    chxbPagato.Enabled = true;
                    if (adesioni.Count > 0 && haPagato)
                        chxbPagato.Checked = true;
                    else
                        chxbPagato.Checked = false;

                    _aggiornamentoInterno = false;
                }
            }
        }

        private void chxbPagato_CheckedChanged(object sender,EventArgs e)
        {
            if (!_aggiornamentoInterno &&lvIscrizioni.SelectedItems.Count > 0)
            {
                ClsUtente studente = (ClsUtente)lvIscrizioni.SelectedItems[0].Tag;

                int studenteSelezionato = studente.ID;

                int indiceStudente = -1;
                int i = 0;

                while (i < _iscrizioniEventoCorrente.Count && indiceStudente == -1)
                {
                    if (_iscrizioniEventoCorrente[i].ID == studenteSelezionato)
                        indiceStudente = i;
                    i++;
                }

                if (indiceStudente >= 0)
                {
                    List<ClsAderire> adesioni = _adesioniEventoCorrente[indiceStudente];

                    string errore = "";

                    int j = 0;

                    while (j < adesioni.Count)
                    {
                        ClsAderire ad = adesioni[j];
                        ad.Pagato = chxbPagato.Checked;
                        ClsAderireBL.Update(ref Program.conn,ad.IDaderire,ad,out errore);

                        j++;
                    }

                    if (!string.IsNullOrEmpty(errore))
                        MessageBox.Show("Errore: " + errore,"Errore",MessageBoxButtons.OK,MessageBoxIcon.Error);

                    if (lvEventi.SelectedItems.Count > 0)
                    {
                        ClsEvento evento =(ClsEvento)lvEventi.SelectedItems[0].Tag;

                        CaricaIscrizioni(evento.ID1);

                        int k = 0;

                        while (k < lvIscrizioni.Items.Count)
                        {
                            ClsUtente studenteLista =(ClsUtente)lvIscrizioni.Items[k].Tag;
                            if (studenteLista.ID ==studenteSelezionato)
                            {
                                lvIscrizioni.Items[k].Selected = true;
                                lvIscrizioni.Items[k].EnsureVisible();

                                k = lvIscrizioni.Items.Count;
                            }
                            else
                                k++;
                        }
                    }
                }
            }
        }

        private void tbFiltroEventi_TextChanged(object sender,EventArgs e)
        {
            string filtro =tbFiltroEventi.Text.Trim();

            if (string.IsNullOrEmpty(filtro))
                PopolaListViewEventi(_eventi);
            else
            {
                List<ClsEvento> risultato =_eventi.FindAll(ev =>ev.Nome != null &&ev.Nome.ToLower().Contains(filtro.ToLower()));
                PopolaListViewEventi(risultato);
            }
        }

        private void tbFiltroNome_TextChanged(object sender,EventArgs e)
        {
            string filtro =tbFiltroNome.Text.Trim();

            if (string.IsNullOrEmpty(filtro))
                PopolaListViewIscrizioni(_iscrizioniEventoCorrente);
            else
            {
                List<ClsUtente> risultato =_iscrizioniEventoCorrente.FindAll(studente => (studente.Nome != null && studente.Nome.ToLower() .Contains(filtro.ToLower())) ||
                                                                                        (studente.Cognome != null &&studente.Cognome.ToLower().Contains(filtro.ToLower())));
                PopolaListViewIscrizioni(risultato);
            }
        }
    }
}