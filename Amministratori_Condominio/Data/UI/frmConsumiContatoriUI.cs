using System;
using System.Data;
using System.Windows.Forms;
using Amministratori_Condominio.DAL;

namespace Amministratori_Condominio.UI
{
    public partial class FrmConsumiContatore : Form
    {
        private string _connectionString;
        private int _idCondominio;
        private int _idContatore;
        private ConsumiDal _consumiDal;

        public FrmConsumiContatore(string connectionString, int idCondominio, int idContatore)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _idCondominio = idCondominio;
            _idContatore = idContatore;
            _consumiDal = new ConsumiDal(connectionString);
        }

        private void FrmConsumiContatore_Load(object sender, EventArgs e)
        {
            ConfigureDataGridViews();
            CaricaConsumiContatore();
        }

        private void ConfigureDataGridViews()
        {
            // DataGridView Dettagli Consumi
            dgvConsumiDettagli.AutoGenerateColumns = false;
            dgvConsumiDettagli.Columns.Clear();

            DataGridViewTextBoxColumn colInterno = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Interno",
                HeaderText = "Interno",
                Width = 60
            };
            dgvConsumiDettagli.Columns.Add(colInterno);

            DataGridViewTextBoxColumn colScala = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Scala",
                HeaderText = "Scala",
                Width = 50
            };
            dgvConsumiDettagli.Columns.Add(colScala);

            DataGridViewTextBoxColumn colPiano = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Piano",
                HeaderText = "Piano",
                Width = 50
            };
            dgvConsumiDettagli.Columns.Add(colPiano);

            DataGridViewTextBoxColumn colDataInizio = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataLetturaIniziale",
                HeaderText = "Data Inizio",
                Width = 90
            };
            dgvConsumiDettagli.Columns.Add(colDataInizio);

            DataGridViewTextBoxColumn colLetturaIniziale = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LetturaIniziale",
                HeaderText = "Lettura Iniziale",
                Width = 100
            };
            dgvConsumiDettagli.Columns.Add(colLetturaIniziale);

            DataGridViewTextBoxColumn colDataFine = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataLetturaFinale",
                HeaderText = "Data Fine",
                Width = 90
            };
            dgvConsumiDettagli.Columns.Add(colDataFine);

            DataGridViewTextBoxColumn colLetturaFinale = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LetturaFinale",
                HeaderText = "Lettura Finale",
                Width = 100
            };
            dgvConsumiDettagli.Columns.Add(colLetturaFinale);

            DataGridViewTextBoxColumn colDifferenza = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Differenza",
                HeaderText = "Differenza (Consumo)",
                Width = 120
            };
            dgvConsumiDettagli.Columns.Add(colDifferenza);
        }

        private void CaricaConsumiContatore()
        {
            try
            {
                DateTime dataInizio = dtpDataInizio.Value.Date;
                DateTime dataFine = dtpDataFine.Value.Date;

                DataTable dtConsumiDettagli = _consumiDal.GetConsumiByContatoreBetweenDates(_idContatore, dataInizio, dataFine);
                dgvConsumiDettagli.DataSource = dtConsumiDettagli;

                // Carica e visualizza i totali
                DataRow rowTotali = _consumiDal.GetTotaliConsumiByContatore(_idContatore, dataInizio, dataFine);
                if (rowTotali != null)
                {
                    MostraTotali(rowTotali);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostraTotali(DataRow rowTotali)
        {
            int numeroUnita = Convert.ToInt32(rowTotali["NumeroUnita"]);
            decimal totaleLettureIniziali = rowTotali["TotaleLettureIniziali"] != DBNull.Value 
                ? Convert.ToDecimal(rowTotali["TotaleLettureIniziali"]) 
                : 0;
            decimal totaleLettureFinali = rowTotali["TotaleLettureFinali"] != DBNull.Value 
                ? Convert.ToDecimal(rowTotali["TotaleLettureFinali"]) 
                : 0;
            decimal totaleDifferenza = rowTotali["TotaleDifferenza"] != DBNull.Value 
                ? Convert.ToDecimal(rowTotali["TotaleDifferenza"]) 
                : 0;
            decimal mediaConsumi = rowTotali["MediaConsumi"] != DBNull.Value 
                ? Convert.ToDecimal(rowTotali["MediaConsumi"]) 
                : 0;
            decimal consumoMinimo = rowTotali["ConsumoMinimo"] != DBNull.Value 
                ? Convert.ToDecimal(rowTotali["ConsumoMinimo"]) 
                : 0;
            decimal consumoMassimo = rowTotali["ConsumoMassimo"] != DBNull.Value 
                ? Convert.ToDecimal(rowTotali["ConsumoMassimo"]) 
                : 0;

            // Visualizza i totali
            txtNumeroUnita.Text = numeroUnita.ToString();
            txtTotaleLettureIniziali.Text = totaleLettureIniziali.ToString("F2");
            txtTotaleLettureFinali.Text = totaleLettureFinali.ToString("F2");
            txtTotaleDifferenza.Text = totaleDifferenza.ToString("F2");
            txtMediaConsumi.Text = mediaConsumi.ToString("F2");
            txtConsumoMinimo.Text = consumoMinimo.ToString("F2");
            txtConsumoMassimo.Text = consumoMassimo.ToString("F2");

            // Aggiorna il titolo della form con il riepilogo
            this.Text = $"Consumi - Letture Iniziali: {totaleLettureIniziali:F2} | Letture Finali: {totaleLettureFinali:F2} | Differenza: {totaleDifferenza:F2}";
        }

        private void btnAggiorna_Click(object sender, EventArgs e)
        {
            CaricaConsumiContatore();
        }

        private void btnEsporta_Click(object sender, EventArgs e)
        {
            if (dgvConsumiDettagli.Rows.Count == 0)
            {
                MessageBox.Show("Nessun dato da esportare", "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv",
                DefaultExt = "xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (sfd.FileName.EndsWith(".xlsx"))
                    {
                        EsportaExcel(sfd.FileName);
                    }
                    else if (sfd.FileName.EndsWith(".csv"))
                    {
                        EsportaCsv(sfd.FileName);
                    }
                    MessageBox.Show("Esportazione completata", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errore durante l'esportazione: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EsportaExcel(string filePath)
        {
            try
            {
                // Richiede: using Excel = Microsoft.Office.Interop.Excel;
                dynamic excelApp = System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
                if (excelApp == null)
                    excelApp = Activator.CreateInstance(System.Type.GetTypeFromProgID("Excel.Application"));

                dynamic workbook = excelApp.Workbooks.Add();
                dynamic worksheet = workbook.Sheets[1];

                // Scrivi intestazioni
                for (int i = 0; i < dgvConsumiDettagli.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dgvConsumiDettagli.Columns[i].HeaderText;
                }

                // Scrivi dati
                for (int i = 0; i < dgvConsumiDettagli.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvConsumiDettagli.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dgvConsumiDettagli.Rows[i].Cells[j].Value;
                    }
                }

                workbook.SaveAs(filePath);
                workbook.Close();
                excelApp.Quit();
            }
            catch
            {
                EsportaCsv(filePath.Replace(".xlsx", ".csv"));
            }
        }

        private void EsportaCsv(string filePath)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath))
            {
                // Scrivi intestazioni
                string[] headers = new string[dgvConsumiDettagli.Columns.Count];
                for (int i = 0; i < dgvConsumiDettagli.Columns.Count; i++)
                {
                    headers[i] = dgvConsumiDettagli.Columns[i].HeaderText;
                }
                writer.WriteLine(string.Join(",", headers));

                // Scrivi dati
                for (int i = 0; i < dgvConsumiDettagli.Rows.Count; i++)
                {
                    string[] values = new string[dgvConsumiDettagli.Columns.Count];
                    for (int j = 0; j < dgvConsumiDettagli.Columns.Count; j++)
                    {
                        values[j] = dgvConsumiDettagli.Rows[i].Cells[j].Value?.ToString() ?? "";
                    }
                    writer.WriteLine(string.Join(",", values));
                }
            }
        }

        private void btnChiudi_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
