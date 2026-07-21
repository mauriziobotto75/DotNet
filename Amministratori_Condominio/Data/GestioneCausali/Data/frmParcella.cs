using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GestioneAmministratori
{
    public partial class FormParcella : Form
    {
        private string _connectionString = @"Server=YOUR_SERVER;Database=Amministratori_Condominio;Integrated Security=true;";
        private int _idAmministratore = 0;
        private int _idCondominio = 0;

        public FormParcella()
        {
            InitializeComponent();
        }

        private void FormParcella_Load(object sender, EventArgs e)
        {
            ConfiguraGriglia();
            CaricaDatiAmministratori();
            CaricaDatiCondomini();
        }

        /// <summary>
        /// Configura le colonne della DataGridView
        /// </summary>
        private void ConfiguraGriglia()
        {
            dataGridViewParcella.AllowUserToAddRows = false;
            dataGridViewParcella.AllowUserToDeleteRows = false;
            dataGridViewParcella.AllowUserToResizeRows = false;
            dataGridViewParcella.ReadOnly = true;
            dataGridViewParcella.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dataGridViewParcella.MultiSelect = false;

            // Colonne per i mesi
            string[] mesi = { "Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno",
                            "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre" };

            dataGridViewParcella.Columns.Clear();
            dataGridViewParcella.Columns.Add("IdDettaglio", "");
            dataGridViewParcella.Columns.Add("Descrizione", "Descrizione");

            foreach (string mese in mesi)
            {
                dataGridViewParcella.Columns.Add($"col_{mese}", mese);
            }

            dataGridViewParcella.Columns["IdDettaglio"].Visible = false;
            dataGridViewParcella.Columns["Descrizione"].Width = 150;

            foreach (DataGridViewColumn col in dataGridViewParcella.Columns)
            {
                if (col.Name != "Descrizione" && col.Name != "IdDettaglio")
                    col.Width = 60;
            }
        }

        /// <summary>
        /// Carica gli amministratori nella ComboBox
        /// </summary>
        private void CaricaDatiAmministratori()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = @"SELECT IdAmministratore, RagioneSociale 
                                   FROM Amministratori 
                                   ORDER BY RagioneSociale";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    comboBoxAmministratore.DataSource = dt;
                    comboBoxAmministratore.DisplayMember = "RagioneSociale";
                    comboBoxAmministratore.ValueMember = "IdAmministratore";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel caricamento degli amministratori: " + ex.Message, 
                    "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carica i condomini filtrati per amministratore
        /// </summary>
        private void CaricaDatiCondomini()
        {
            try
            {
                if (comboBoxAmministratore.SelectedValue == null)
                    return;

                _idAmministratore = (int)comboBoxAmministratore.SelectedValue;

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = @"SELECT IdCondominio, Nome 
                                   FROM Condomini 
                                   WHERE IdAmministratore = @IdAmministratore
                                   ORDER BY Nome";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdAmministratore", _idAmministratore);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    comboBoxCondominio.DataSource = dt;
                    comboBoxCondominio.DisplayMember = "Nome";
                    comboBoxCondominio.ValueMember = "IdCondominio";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel caricamento dei condomini: " + ex.Message, 
                    "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carica i dati della parcella
        /// </summary>
        private void CaricaParcella()
        {
            try
            {
                if (comboBoxCondominio.SelectedValue == null)
                    return;

                _idCondominio = (int)comboBoxCondominio.SelectedValue;
                int anno = int.Parse(textBoxAnno.Text);

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    // Query per i dettagli della parcella
                    string query = @"
                        SELECT DISTINCT
                            m.IdMovimento,
                            m.Descrizione,
                            MONTH(m.DataMovimento) as Mese,
                            YEAR(m.DataMovimento) as Anno,
                            m.Importo
                        FROM MovimentiContabili m
                        INNER JOIN Gestioni g ON m.IdGestione = g.IdGestione
                        WHERE g.IdCondominio = @IdCondominio
                        AND YEAR(m.DataMovimento) = @Anno
                        ORDER BY m.Descrizione, m.DataMovimento";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdCondominio", _idCondominio);
                    cmd.Parameters.AddWithValue("@Anno", anno);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dtMovimenti = new DataTable();
                    adapter.Fill(dtMovimenti);

                    // Raggruppa per descrizione
                    DataTable dtGruppato = RaggruppaPerDescrizione(dtMovimenti);

                    // Popola la griglia
                    PopolaGriglia(dtGruppato);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel caricamento della parcella: " + ex.Message, 
                    "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Raggruppa i movimenti per descrizione e mese
        /// </summary>
        private DataTable RaggruppaPerDescrizione(DataTable dtMovimenti)
        {
            DataTable dtRaggruppato = new DataTable();
            dtRaggruppato.Columns.Add("IdDettaglio", typeof(int));
            dtRaggruppato.Columns.Add("Descrizione", typeof(string));

            for (int mese = 1; mese <= 12; mese++)
            {
                dtRaggruppato.Columns.Add($"Mese_{mese}", typeof(decimal));
            }

            var descrizioni = dtMovimenti.AsEnumerable().Select(r => r["Descrizione"].ToString()).Distinct();

            int idDettaglio = 1;
            foreach (var descrizione in descrizioni)
            {
                DataRow newRow = dtRaggruppato.NewRow();
                newRow["IdDettaglio"] = idDettaglio++;
                newRow["Descrizione"] = descrizione;

                var movimentiDescrizione = dtMovimenti.AsEnumerable()
                    .Where(r => r["Descrizione"].ToString() == descrizione);

                foreach (var movimento in movimentiDescrizione)
                {
                    int mese = (int)movimento["Mese"];
                    decimal importo = (decimal)movimento["Importo"];
                    newRow[$"Mese_{mese}"] = importo;
                }

                dtRaggruppato.Rows.Add(newRow);
            }

            return dtRaggruppato;
        }

        /// <summary>
        /// Popola la DataGridView con i dati della parcella
        /// </summary>
        private void PopolaGriglia(DataTable dt)
        {
            dataGridViewParcella.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                string descrizione = row["Descrizione"].ToString();
                object[] valori = new object[14];
                valori[0] = row["IdDettaglio"];
                valori[1] = descrizione;

                for (int mese = 1; mese <= 12; mese++)
                {
                    var valore = row[$"Mese_{mese}"];
                    valori[mese + 1] = valore != DBNull.Value ? Convert.ToDecimal(valore).ToString("N2") : "";
                }

                dataGridViewParcella.Rows.Add(valori);
            }

            // Aggiungi riga totale
            AggiungiRigaTotale(dt);
        }

        /// <summary>
        /// Aggiunge la riga dei totali
        /// </summary>
        private void AggiungiRigaTotale(DataTable dt)
        {
            object[] totalRow = new object[14];
            totalRow[0] = -1;
            totalRow[1] = "TOTALE";

            for (int mese = 1; mese <= 12; mese++)
            {
                decimal totale = 0;
                foreach (DataRow row in dt.Rows)
                {
                    var valore = row[$"Mese_{mese}"];
                    if (valore != DBNull.Value)
                        totale += Convert.ToDecimal(valore);
                }
                totalRow[mese + 1] = totale > 0 ? totale.ToString("N2") : "";
            }

            dataGridViewParcella.Rows.Add(totalRow);

            // Formatta la riga totale
            int lastRowIndex = dataGridViewParcella.Rows.Count - 1;
            for (int i = 0; i < dataGridViewParcella.Columns.Count; i++)
            {
                dataGridViewParcella.Rows[lastRowIndex].Cells[i].Style.BackColor = System.Drawing.Color.LightGray;
                dataGridViewParcella.Rows[lastRowIndex].Cells[i].Style.Font = 
                    new System.Drawing.Font(dataGridViewParcella.Font, System.Drawing.FontStyle.Bold);
            }
        }

        private void comboBoxAmministratore_SelectedIndexChanged(object sender, EventArgs e)
        {
            CaricaDatiCondomini();
        }

        private void buttonCarica_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxAnno.Text))
            {
                MessageBox.Show("Inserire l'anno", "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBoxAnno.Text, out int anno) || anno < 2000 || anno > DateTime.Now.Year)
            {
                MessageBox.Show("Anno non valido", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CaricaParcella();
        }

        private void buttonEsporta_Click(object sender, EventArgs e)
        {
            EsportaInExcel();
        }

        /// <summary>
        /// Esporta i dati in Excel
        /// </summary>
        private void EsportaInExcel()
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveFileDialog.FileName = $"Parcella_{comboBoxCondominio.Text}_{textBoxAnno.Text}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Implementazione semplice con Office Interop
                    dynamic excel = null;
                    try
                    {
                        excel = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
                        excel.Visible = false;

                        dynamic workbook = excel.Workbooks.Add();
                        dynamic worksheet = workbook.Sheets[1];

                        // Intestazione
                        worksheet.Cells[1, 1].Value = $"Parcella - {comboBoxCondominio.Text}";
                        worksheet.Cells[2, 1].Value = $"Anno: {textBoxAnno.Text}";

                        // Headers
                        for (int col = 0; col < dataGridViewParcella.Columns.Count; col++)
                        {
                            worksheet.Cells[4, col + 1].Value = dataGridViewParcella.Columns[col].HeaderText;
                        }

                        // Dati
                        for (int row = 0; row < dataGridViewParcella.Rows.Count; row++)
                        {
                            for (int col = 0; col < dataGridViewParcella.Columns.Count; col++)
                            {
                                worksheet.Cells[row + 5, col + 1].Value = 
                                    dataGridViewParcella.Rows[row].Cells[col].Value;
                            }
                        }

                        workbook.SaveAs(saveFileDialog.FileName);
                        workbook.Close();

                        MessageBox.Show("Esportazione completata con successo!", 
                            "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        if (excel != null)
                            excel.Quit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nell'esportazione: " + ex.Message, 
                    "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
