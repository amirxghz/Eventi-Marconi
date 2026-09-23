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
    public partial class FrmValidaAccessoEvento : Form
    {
        public FrmValidaAccessoEvento()
        {
            InitializeComponent();
        }

        private void FrmValidaAccessoEvento_Load(object sender, EventArgs e)
        {
            tbIDaderire.Focus();
        }

        private void tbIDaderire_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ValidaAccesso();
            }
        }

        private void btnValida_Click(object sender, EventArgs e)
        {
            ValidaAccesso();
        }

        private void ValidaAccesso()
        {
            string codice = tbIDaderire.Text.Trim().ToUpper();
            tbIDaderire.Clear();

            if (string.IsNullOrEmpty(codice))
            {
                MessageBox.Show("Inserisci un codice.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbIDaderire.Focus();
            }
            else
            {
                string errore;
                List<ClsAderire> adesioni = ClsAderireBL.GetByCodicePartecipazione(ref Program.conn, codice, out errore);

                if (!string.IsNullOrEmpty(errore))
                    MessageBox.Show("Errore: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (adesioni == null || adesioni.Count == 0)
                    MessageBox.Show("Codice non trovato.", "Accesso negato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    bool accessoConsentito = true;
                    
                    bool eventoGratuito = false;
                    List<ClsAttivita> attivita = ClsAttivitaBL.GetAll(ref Program.conn, out errore);
                    ClsAttivita attivitaAderita = null;

                    if (attivita != null)
                        attivitaAderita = attivita.FirstOrDefault(a => a.ID1 == adesioni[0].AttivitaID);

                    if (attivitaAderita != null)
                    {
                        ClsEvento evento = ClsEventoBL.GetByID(ref Program.conn, attivitaAderita.EventoID, out errore);
                        if (evento != null)
                            eventoGratuito = evento.Prezzo <= 0;
                    }

                    bool tuttiPagati = eventoGratuito || adesioni.All(a => a.Pagato);
                    if (!tuttiPagati)
                    {
                        DialogResult dr = MessageBox.Show("Lo studente non risulta aver pagato.\nVuoi segnarlo come pagato adesso e consentire l'accesso?", "Pagamento mancante", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (dr != DialogResult.Yes)
                        {
                            MessageBox.Show("Accesso negato: pagamento non registrato.", "Accesso negato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            accessoConsentito = false;
                        }
                        else
                        {
                            for (int i = 0; i < adesioni.Count; i++)
                            {
                                adesioni[i].Pagato = true;
                                ClsAderireBL.Update(ref Program.conn, adesioni[i].IDaderire, adesioni[i], out errore);
                            }
                        }
                    }

                    if (accessoConsentito)
                    {
                        bool giaPartecipato = adesioni.All(a => a.Partecipato);
                        if (giaPartecipato)
                            MessageBox.Show("Questo codice è già stato validato in precedenza.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            for (int i = 0; i < adesioni.Count; i++)
                            {
                                adesioni[i].Partecipato = true;
                                ClsAderireBL.Update(ref Program.conn, adesioni[i].IDaderire, adesioni[i], out errore);
                            }

                            if (!string.IsNullOrEmpty(errore))
                                MessageBox.Show("Errore nella validazione: " + errore, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                ClsUtente studente = ClsUtenteBL.GetByID(ref Program.conn, adesioni[0].StudenteID, out errore);

                                string msg = "Accesso validato!";
                                if (studente != null)
                                    msg += "\n" + studente.Nome + " " + studente.Cognome;

                                MessageBox.Show(msg, "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tbIDaderire.Focus();
                            }
                        }
                    }
                }
            }
        }
    }
}