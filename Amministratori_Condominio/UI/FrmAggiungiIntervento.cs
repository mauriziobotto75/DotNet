using System;
using System.Data;
using System.Windows.Forms;
using Amministratori_Condominio.DAL;

namespace Amministratori_Condominio.UI
{
    public partial class FrmAggiungiIntervento : Form
    {
        private string _connectionString;
        private int _idIntervento = -1;
        private AgendaRepository _agendaRepository;
        private int _idCondominio = -1;

        public FrmAggiungiIntervento(string connectionString, int idIntervento = -1)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _idIntervento = idIntervento;
            _agendaRepository = new AgendaRepository(connectionString);
        }

        private void FrmAggiungiIntervento_Load(object sender, EventArgs e)
        {
            CaricaCondomini();
            
            if (_idIntervento > 0)
            {
                CaricaDatiIntervento();
                this.Text = "Modifica Intervento";
            }
            else
            {
                this.Text = "Nuovo Intervento";
                dtpDataIntervento.Value = DateTime.Now;
                cmbStato.SelectedIndex = 0;
            }
        }

        private void CaricaCondomini()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "SELECT IdCondominio, Nome FROM Condomini ORDER BY Nome";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbCondominio.DataSource = dt;
                    cmbCondominio.DisplayMember = "Nome";
                    cmbCondominio.ValueMember = "IdCondominio";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel caricamento dei condomini: " + ex.Message,
                    "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CaricaDatiIntervento()
        {
            try
            {
                DataRow row = _agendaRepository.GetInterventoById(_idIntervento);
                if (row != null)
                {
                    _idCondominio = (int)row["IdCondominio"];
                    cmbCondominio.SelectedValue = _idCondominio;
                    txtDescrizione.Text = row["Descrizione"]?.ToString() ?? "";
                    
                    if (row["DataIntervento"] != DBNull.Value)
                        dtpDataIntervento.Value = Convert.ToDateTime(row["DataIntervento"]);
                    
                    cmbStato.SelectedItem = row["Stato"]?.ToString() ?? "Programmato";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel caricamento dei dati: " + ex.Message,
                    "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            if (ValidaDati())
            {
                try
                {
                    int idCondominio = (int)cmbCondominio.SelectedValue;
                    string descrizione = txtDescrizione.Text;
                    DateTime dataIntervento = dtpDataIntervento.Value;
                    string stato = cmbStato.SelectedItem?.ToString() ?? "Programmato";

                    if (_idIntervento > 0)
                    {
                        // Aggiorna
                        if (_agendaRepository.UpdateIntervento(_idIntervento, descrizione, dataIntervento, stato))
                        {
                            MessageBox.Show("Intervento aggiornato con successo", "Successo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Errore nell'aggiornamento dell'intervento", "Errore",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // Inserisci
                        int newId = _agendaRepository.InsertIntervento(idCondominio, descrizione, dataIntervento, stato);
                        if (newId > 0)
                        {
                            MessageBox.Show("Intervento aggiunto con successo", "Successo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Errore nell'inserimento dell'intervento", "Errore",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errore: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidaDati()
        {
            if (cmbCondominio.SelectedValue == null)
            {
                MessageBox.Show("Selezionare un condominio", "Avviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCondominio.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescrizione.Text))
            {
                MessageBox.Show("Inserire una descrizione dell'intervento", "Avviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescrizione.Focus();
                return false;
            }

            if (dtpDataIntervento.Value < DateTime.Now.Date && !chkDataPassata.Checked)
            {
                if (MessageBox.Show("La data è nel passato. Continuare comunque?", "Conferma",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return false;
            }

            return true;
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chkDataPassata_CheckedChanged(object sender, EventArgs e)
        {
            // Checkbox per permettere date nel passato
        }
    }
}
