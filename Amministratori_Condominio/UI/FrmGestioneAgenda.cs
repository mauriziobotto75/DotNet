using System;
using System.Data;
using System.Windows.Forms;
using Amministratori_Condominio.DAL;

namespace Amministratori_Condominio.UI
{
    public partial class FrmGestioneAgenda : Form
    {
        private string _connectionString;
        private int _idAmministratore;
        private AgendaRepository _agendaRepository;
        private int _selectedInterventoId = -1;

        public FrmGestioneAgenda(string connectionString, int idAmministratore)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _idAmministratore = idAmministratore;
            _agendaRepository = new AgendaRepository(connectionString);
        }

        private void FrmGestioneAgenda_Load(object sender, EventArgs e)
        {
            ConfigureUI();
            CaricaInterventi();
        }

        private void ConfigureUI()
        {
            // Configura le colonne della griglia degli orari (calendario settimanale)
            dgvOrari.AllowUserToAddRows = false;
            dgvOrari.AllowUserToDeleteRows = false;
            dgvOrari.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrari.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrari.MultiSelect = false;

            // Colonne: Ora, Lunedì, Martedì, ..., Domenica
            dgvOrari.Columns.Clear();
            dgvOrari.Columns.Add("Ora", "Ora");
            dgvOrari.Columns.Add("Lunedi", "Lunedì");
            dgvOrari.Columns.Add("Martedi", "Martedì");
            dgvOrari.Columns.Add("Mercoledi", "Mercoledì");
            dgvOrari.Columns.Add("Giovedi", "Giovedì");
            dgvOrari.Columns.Add("Venerdi", "Venerdì");
            dgvOrari.Columns.Add("Sabato", "Sabato");
            dgvOrari.Columns.Add("Domenica", "Domenica");

            dgvOrari.Columns[0].Width = 60;
            foreach (DataGridViewColumn col in dgvOrari.Columns)
            {
                if (col.Name != "Ora")
                    col.Width = 120;
            }

            // Popola griglia con orari da 09:00 a 17:30 (ogni 30 minuti)
            PopolaGriglia();

            // Configura la griglia dei dettagli
            dgvDettagli.AllowUserToAddRows = false;
            dgvDettagli.AllowUserToDeleteRows = false;
            dgvDettagli.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDettagli.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDettagli.MultiSelect = false;
            dgvDettagli.Columns.Clear();

            DataGridViewTextBoxColumn colIdIntervento = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdIntervento",
                HeaderText = "ID",
                Width = 50,
                Visible = false
            };
            dgvDettagli.Columns.Add(colIdIntervento);

            DataGridViewTextBoxColumn colData = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataIntervento",
                HeaderText = "Data Intervento",
                Width = 120
            };
            dgvDettagli.Columns.Add(colData);

            DataGridViewTextBoxColumn colCondominio = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NomeCondominio",
                HeaderText = "Condominio",
                Width = 150
            };
            dgvDettagli.Columns.Add(colCondominio);

            DataGridViewTextBoxColumn colDescrizione = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Descrizione",
                HeaderText = "Descrizione",
                Width = 250
            };
            dgvDettagli.Columns.Add(colDescrizione);

            DataGridViewTextBoxColumn colStato = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Stato",
                HeaderText = "Stato",
                Width = 100
            };
            dgvDettagli.Columns.Add(colStato);

            DataGridViewTextBoxColumn colGiorniRimanenti = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GiorniRimanenti",
                HeaderText = "Giorni",
                Width = 60
            };
            dgvDettagli.Columns.Add(colGiorniRimanenti);

            // Combobox per i filtri
            cmbMeseFiltro.Items.AddRange(new object[] { "Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno",
                                                         "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre" });
            cmbMeseFiltro.SelectedIndex = DateTime.Now.Month - 1;

            cmbAnnoFiltro.Text = DateTime.Now.Year.ToString();

            cmbStatoFiltro.Items.AddRange(new object[] { "Tutti", "Programmato", "In Corso", "Completato", "Rimandato" });
            cmbStatoFiltro.SelectedIndex = 0;
        }

        private void PopolaGriglia()
        {
            dgvOrari.Rows.Clear();

            for (int ora = 9; ora <= 17; ora++)
            {
                for (int minuti = 0; minuti < 60; minuti += 30)
                {
                    if (ora == 17 && minuti > 0) break;

                    string orario = $"{ora:D2}:{minuti:D2}";
                    dgvOrari.Rows.Add(orario, "", "", "", "", "", "", "");
                }
            }
        }

        private void CaricaInterventi()
        {
            try
            {
                DateTime dataInizio = new DateTime(int.Parse(cmbAnnoFiltro.Text), int.Parse(cmbMeseFiltro.SelectedIndex.ToString()) + 1, 1);
                DateTime dataFine = dataInizio.AddMonths(1).AddDays(-1);

                string stato = cmbStatoFiltro.SelectedItem?.ToString();
                if (stato == "Tutti")
                    stato = null;

                DataTable dt = _agendaRepository.GetAgendaInterventiByAmministratore(_idAmministratore, dataInizio, dataFine);
                
                if (stato != null)
                {
                    dt.DefaultView.RowFilter = $"Stato = '{stato}'";
                }

                dgvDettagli.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel caricamento degli interventi: " + ex.Message,
                    "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuovoIntervento_Click(object sender, EventArgs e)
        {
            FrmAggiungiIntervento frmAggiungi = new FrmAggiungiIntervento(_connectionString);
            if (frmAggiungi.ShowDialog() == DialogResult.OK)
            {
                CaricaInterventi();
            }
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            if (dgvDettagli.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selezionare un intervento da modificare", "Avviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idIntervento = (int)dgvDettagli.SelectedRows[0].Cells["IdIntervento"].Value;
            FrmAggiungiIntervento frmModifica = new FrmAggiungiIntervento(_connectionString, idIntervento);
            if (frmModifica.ShowDialog() == DialogResult.OK)
            {
                CaricaInterventi();
            }
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            if (dgvDettagli.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selezionare un intervento da eliminare", "Avviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Sei sicuro di voler eliminare questo intervento?", "Conferma",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                int idIntervento = (int)dgvDettagli.SelectedRows[0].Cells["IdIntervento"].Value;
                if (_agendaRepository.DeleteIntervento(idIntervento))
                {
                    MessageBox.Show("Intervento eliminato con successo", "Successo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CaricaInterventi();
                }
                else
                {
                    MessageBox.Show("Errore nell'eliminazione dell'intervento", "Errore",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCompleta_Click(object sender, EventArgs e)
        {
            if (dgvDettagli.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selezionare un intervento da completare", "Avviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idIntervento = (int)dgvDettagli.SelectedRows[0].Cells["IdIntervento"].Value;
                if (_agendaRepository.UpdateStatoIntervento(idIntervento, "Completato"))
                {
                    MessageBox.Show("Intervento segnato come completato", "Successo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CaricaInterventi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbMeseFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CaricaInterventi();
        }

        private void cmbStatoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CaricaInterventi();
        }

        private void btnAggiorna_Click(object sender, EventArgs e)
        {
            CaricaInterventi();
        }

        private void dgvDettagli_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDettagli.SelectedRows.Count > 0)
            {
                _selectedInterventoId = (int)dgvDettagli.SelectedRows[0].Cells["IdIntervento"].Value;
                MostraDettagliIntervento(_selectedInterventoId);
            }
        }

        private void MostraDettagliIntervento(int idIntervento)
        {
            try
            {
                DataRow row = _agendaRepository.GetInterventoById(idIntervento);
                if (row != null)
                {
                    txtDescrizione.Text = row["Descrizione"]?.ToString() ?? "";
                    dtpDataIntervento.Value = row["DataIntervento"] != DBNull.Value 
                        ? Convert.ToDateTime(row["DataIntervento"]) 
                        : DateTime.Now;
                    txtCondominio.Text = row["NomeCondominio"]?.ToString() ?? "";
                    txtStato.Text = row["Stato"]?.ToString() ?? "Programmato";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel caricamento dei dettagli: " + ex.Message, "Errore",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChiudi_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
