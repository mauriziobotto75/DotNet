using System;
using System.Data;
using System.Windows.Forms;
using Amministratori_Condominio.DAL;

namespace Amministratori_Condominio.UI
{
    public partial class FrmGestioneContatore : Form
    {
        private string _connectionString;
        private int _idCondominio;
        private int _idContatore;
        private ContatoreDal _contatoreDal;
        private LetturaContatoreDal _letteruraDal;

        public FrmGestioneContatore(string connectionString, int idCondominio, int idContatore = 0)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _idCondominio = idCondominio;
            _idContatore = idContatore;
            _contatoreDal = new ContatoreDal(connectionString);
            _letteruraDal = new LetturaContatoreDal(connectionString);
        }

        private void FrmGestioneContatore_Load(object sender, EventArgs e)
        {
            ConfiguareForm();
            CaricaContatore();
            CaricaLettureContatore();
            CaricaUnitaDisponibili();
        }

        private void ConfiguareForm()
        {
            // Configurazione DataGridView Letture
            dgvLetture.AutoGenerateColumns = false;
            dgvLetture.Columns.Clear();
            
            DataGridViewTextBoxColumn colIdLettura = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdLettura",
                HeaderText = "ID",
                Visible = false
            };
            dgvLetture.Columns.Add(colIdLettura);

            DataGridViewTextBoxColumn colInterno = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Interno",
                HeaderText = "Interno",
                Width = 60
            };
            dgvLetture.Columns.Add(colInterno);

            DataGridViewTextBoxColumn colScala = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Scala",
                HeaderText = "Scala",
                Width = 50
            };
            dgvLetture.Columns.Add(colScala);

            DataGridViewTextBoxColumn colPiano = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Piano",
                HeaderText = "Piano",
                Width = 50
            };
            dgvLetture.Columns.Add(colPiano);

            DataGridViewTextBoxColumn colDataLettura = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataLettura",
                HeaderText = "Data Lettura",
                Width = 100
            };
            dgvLetture.Columns.Add(colDataLettura);

            DataGridViewTextBoxColumn colValore = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Valore",
                HeaderText = "Lettura Finale",
                Width = 100
            };
            dgvLetture.Columns.Add(colValore);

            DataGridViewTextBoxColumn colProprietario = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProprietarioNome",
                HeaderText = "Proprietario/Inquilino",
                Width = 150
            };
            dgvLetture.Columns.Add(colProprietario);

            // Configurazione DataGridView Consumi
            dgvConsumi.AutoGenerateColumns = false;
            dgvConsumi.Columns.Clear();
            
            DataGridViewTextBoxColumn colInternoConsumi = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Interno",
                HeaderText = "Interno",
                Width = 60
            };
            dgvConsumi.Columns.Add(colInternoConsumi);

            DataGridViewTextBoxColumn colUltimaLettura = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataUltimaLettura",
                HeaderText = "Ultima Lettura",
                Width = 100
            };
            dgvConsumi.Columns.Add(colUltimaLettura);

            DataGridViewTextBoxColumn colUltimoValore = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UltimoValore",
                HeaderText = "Valore Attuale",
                Width = 100
            };
            dgvConsumi.Columns.Add(colUltimoValore);
        }

        private void CaricaContatore()
        {
            if (_idContatore > 0)
            {
                DataRow row = _contatoreDal.GetContatore(_idContatore);
                if (row != null)
                {
                    txtNomeContatore.Text = row["Nome"].ToString();
                    txtUnitaMisura.Text = row["UnitaMisura"].ToString();
                    cmbTipo.SelectedItem = row["Tipo"].ToString();
                    this.Text = "Gestione Contatore: " + row["Nome"].ToString();
                }
            }
            else
            {
                this.Text = "Nuovo Contatore";
                cmbTipo.SelectedIndex = 0;
            }
        }

        private void CaricaLettureContatore()
        {
            if (_idContatore > 0)
            {
                DataTable dt = _letteruraDal.GetLettureByContatore(_idContatore);
                dgvLetture.DataSource = dt;
                CalculaConsumi();
            }
        }

        private void CaricaUnitaDisponibili()
        {
            if (_idContatore > 0)
            {
                DataTable dt = _letteruraDal.GetUltimeLetturePerUnita(_idContatore);
                dgvConsumi.DataSource = dt;
            }
        }

        private void CalculaConsumi()
        {
            decimal totaleLettureFinali = 0;
            decimal totaleLettureIniziali = 0;

            foreach (DataGridViewRow row in dgvLetture.Rows)
            {
                if (row.Cells["Valore"].Value != null && 
                    decimal.TryParse(row.Cells["Valore"].Value.ToString(), out decimal valore))
                {
                    totaleLettureFinali += valore;
                }
            }

            txtTotaleLettureFinali.Text = totaleLettureFinali.ToString("F2");
            txtDifferenzaConsumi.Text = (totaleLettureFinali - totaleLettureIniziali).ToString("F2");
        }

        private void btnAggiungiLettura_Click(object sender, EventArgs e)
        {
            if (_idContatore == 0)
            {
                MessageBox.Show("Salvare prima il contatore", "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbUnita.SelectedIndex < 0)
            {
                MessageBox.Show("Selezionare un'unità immobiliare", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtValoreLettura.Text, out decimal valore))
            {
                MessageBox.Show("Inserire un valore numerico valido", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int idUnita = (int)cmbUnita.SelectedValue;
                int idLettura = _letteruraDal.InsertLettura(_idContatore, idUnita, dtpDataLettura.Value, valore);
                
                if (idLettura > 0)
                {
                    MessageBox.Show("Lettura aggiunta con successo", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CaricaLettureContatore();
                    CaricaUnitaDisponibili();
                    PuliziaCampiLettura();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificaLettura_Click(object sender, EventArgs e)
        {
            if (dgvLetture.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selezionare una lettura da modificare", "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtValoreLettura.Text, out decimal valore))
            {
                MessageBox.Show("Inserire un valore numerico valido", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int idLettura = (int)dgvLetture.SelectedRows[0].Cells["IdLettura"].Value;
                bool success = _letteruraDal.UpdateLettura(idLettura, dtpDataLettura.Value, valore);
                
                if (success)
                {
                    MessageBox.Show("Lettura modificata con successo", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CaricaLettureContatore();
                    CaricaUnitaDisponibili();
                    PuliziaCampiLettura();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminaLettura_Click(object sender, EventArgs e)
        {
            if (dgvLetture.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selezionare una lettura da eliminare", "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Confermare l'eliminazione della lettura?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int idLettura = (int)dgvLetture.SelectedRows[0].Cells["IdLettura"].Value;
                    bool success = _letteruraDal.DeleteLettura(idLettura);
                    
                    if (success)
                    {
                        MessageBox.Show("Lettura eliminata con successo", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CaricaLettureContatore();
                        CaricaUnitaDisponibili();
                        PuliziaCampiLettura();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errore: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSalvaContatore_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomeContatore.Text))
            {
                MessageBox.Show("Inserire il nome del contatore", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (_idContatore == 0)
                {
                    _idContatore = _contatoreDal.InsertContatore(
                        _idCondominio,
                        txtNomeContatore.Text,
                        txtUnitaMisura.Text,
                        cmbTipo.SelectedItem?.ToString() ?? "");
                    
                    MessageBox.Show("Contatore creato con successo", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CaricaLettureContatore();
                    CaricaUnitaDisponibili();
                }
                else
                {
                    bool success = _contatoreDal.UpdateContatore(
                        _idContatore,
                        txtNomeContatore.Text,
                        txtUnitaMisura.Text,
                        cmbTipo.SelectedItem?.ToString() ?? "");
                    
                    if (success)
                        MessageBox.Show("Contatore modificato con successo", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLetture_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLetture.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvLetture.SelectedRows[0];
                dtpDataLettura.Value = (DateTime)row.Cells["DataLettura"].Value;
                txtValoreLettura.Text = row.Cells["Valore"].Value.ToString();
            }
        }

        private void PuliziaCampiLettura()
        {
            dtpDataLettura.Value = DateTime.Today;
            txtValoreLettura.Clear();
            cmbUnita.SelectedIndex = -1;
        }

        private void btnChiudi_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
