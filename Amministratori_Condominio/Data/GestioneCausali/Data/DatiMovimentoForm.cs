using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmministratoriCondominio
{
    public partial class DatiMovimentoForm : Form
    {
        private string _connectionString = "Server=YOUR_SERVER;Database=Amministratori_Condominio;Trusted_Connection=true;";
        private int _idGestione;
        private int _idMovimentoCorrente;
        private bool _isEditMode = false;

        public DatiMovimentoForm(int idGestione)
        {
            InitializeComponent();
            _idGestione = idGestione;
            _idMovimentoCorrente = 0;
            CaricaDati();
        }

        private void InitializeComponent()
        {
            // Panel principale
            Panel panelPrincipale = new Panel { Dock = DockStyle.Fill, Padding = new Padding(10) };

            // Sezione Tipo Movimento
            Label lblTipoMovimento = new Label { Text = "Tipo Movimento", Location = new Point(10, 20), Width = 100 };
            RadioButton rbIncasso = new RadioButton { Text = "Incasso", Location = new Point(120, 20), Width = 80 };
            RadioButton rbSpesa = new RadioButton { Text = "Spesa", Location = new Point(200, 20), Width = 80, Checked = true };
            RadioButton rbAltro = new RadioButton { Text = "Altro", Location = new Point(280, 20), Width = 80 };
            rbIncasso.CheckedChanged += RbTipoMovimento_CheckedChanged;
            rbSpesa.CheckedChanged += RbTipoMovimento_CheckedChanged;
            rbAltro.CheckedChanged += RbTipoMovimento_CheckedChanged;

            // Sezione Causale
            Label lblCausale = new Label { Text = "Causale", Location = new Point(10, 60), Width = 100 };
            ComboBox cbCausale = new ComboBox { Location = new Point(120, 60), Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };
            cbCausale.Name = "cbCausale";
            cbCausale.SelectedIndexChanged += CbCausale_SelectedIndexChanged;

            // Sezione Numero Protocollo
            Label lblProtocollo = new Label { Text = "Protocollo Anno/Num.", Location = new Point(10, 100), Width = 100 };
            TextBox tbAnno = new TextBox { Location = new Point(120, 100), Width = 60 };
            tbAnno.Name = "tbAnno";
            tbAnno.Text = DateTime.Now.Year.ToString();
            Label lblBarra = new Label { Text = "/", Location = new Point(185, 100), Width = 20, TextAlign = ContentAlignment.MiddleCenter };
            TextBox tbNumero = new TextBox { Location = new Point(210, 100), Width = 100 };
            tbNumero.Name = "tbNumero";

            // Sezione Data
            Label lblData = new Label { Text = "Data", Location = new Point(380, 100), Width = 50 };
            DateTimePicker dtpData = new DateTimePicker { Location = new Point(440, 100), Width = 120 };
            dtpData.Name = "dtpData";
            dtpData.Value = DateTime.Now;

            // Causale GroupBox
            GroupBox gbCausale = new GroupBox { Text = "Causale", Location = new Point(10, 140), Width = 550, Height = 80 };
            Label lblCodDesc = new Label { Text = "Cod. Descr.", Location = new Point(20, 30), Width = 60 };
            TextBox tbCodDescrizioneCausale = new TextBox { Location = new Point(90, 30), Width = 100 };
            tbCodDescrizioneCausale.Name = "tbCodDescrizioneCausale";
            Label lblDescrizioneCausale = new Label { Text = "Descrizione", Location = new Point(20, 55), Width = 60 };
            TextBox tbDescrizioneCausale = new TextBox { Location = new Point(90, 55), Width = 400 };
            tbDescrizioneCausale.Name = "tbDescrizioneCausale";
            gbCausale.Controls.AddRange(new Control[] { lblCodDesc, tbCodDescrizioneCausale, lblDescrizioneCausale, tbDescrizioneCausale });

            // Sezione Spesa
            Label lblSpesa = new Label { Text = "Spesa", Location = new Point(10, 240), Width = 100 };
            ComboBox cbSpesa = new ComboBox { Location = new Point(120, 240), Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };
            cbSpesa.Name = "cbSpesa";
            cbSpesa.SelectedIndexChanged += CbSpesa_SelectedIndexChanged;

            // Sezione Voce di Spesa
            Label lblVoceSpesa = new Label { Text = "Voce", Location = new Point(10, 280), Width = 100 };
            ComboBox cbVoceSpesa = new ComboBox { Location = new Point(120, 280), Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };
            cbVoceSpesa.Name = "cbVoceSpesa";

            // Sezione Fornitore
            Label lblFornitore = new Label { Text = "Fornitore", Location = new Point(10, 320), Width = 100 };
            TextBox tbFornitore = new TextBox { Location = new Point(120, 320), Width = 250 };
            tbFornitore.Name = "tbFornitore";
            Button btnSelezionaFornitore = new Button { Text = "...", Location = new Point(375, 320), Width = 25, Height = 20 };
            btnSelezionaFornitore.Click += BtnSelezionaFornitore_Click;

            // Sezione Documento
            Label lblDocumento = new Label { Text = "Documento", Location = new Point(10, 360), Width = 100 };
            Label lblDataDoc = new Label { Text = "Data", Location = new Point(120, 335), Width = 50 };
            DateTimePicker dtpDataDocumento = new DateTimePicker { Location = new Point(120, 360), Width = 100 };
            dtpDataDocumento.Name = "dtpDataDocumento";
            Label lblNumDoc = new Label { Text = "Num.", Location = new Point(240, 335), Width = 50 };
            TextBox tbNumDocumento = new TextBox { Location = new Point(240, 360), Width = 100 };
            tbNumDocumento.Name = "tbNumDocumento";
            Label lblContoCorrente = new Label { Text = "Conto Corrente", Location = new Point(10, 390), Width = 100 };
            TextBox tbContoCorrente = new TextBox { Location = new Point(120, 390), Width = 250 };
            tbContoCorrente.Name = "tbContoCorrente";
            Button btnSelezionaCC = new Button { Text = "...", Location = new Point(375, 390), Width = 25, Height = 20 };
            btnSelezionaCC.Click += BtnSelezionaContoCorrente_Click;

            // Sezione Importo
            Label lblImporto = new Label { Text = "Importo da versare", Location = new Point(380, 280), Width = 150 };
            TextBox tbImporto = new TextBox { Location = new Point(380, 300), Width = 120, TextAlign = HorizontalAlignment.Right };
            tbImporto.Name = "tbImporto";
            tbImporto.Text = "0,00";

            // Sezione Note
            Label lblNote = new Label { Text = "Note", Location = new Point(10, 430), Width = 100 };
            TextBox tbNote = new TextBox { Location = new Point(120, 430), Width = 400, Height = 80, Multiline = true };
            tbNote.Name = "tbNote";

            // Button Salva
            Button btnSalva = new Button { Text = "Salva", Location = new Point(120, 530), Width = 80, Height = 30 };
            btnSalva.Click += BtnSalva_Click;

            // Button Abbandona
            Button btnAbbandona = new Button { Text = "Abbandona", Location = new Point(220, 530), Width = 80, Height = 30 };
            btnAbbandona.Click += BtnAbbandona_Click;

            // Button Esci
            Button btnEsci = new Button { Text = "Esci", Location = new Point(320, 530), Width = 80, Height = 30 };
            btnEsci.Click += BtnEsci_Click;

            // Aggiungi controlli al panel
            panelPrincipale.Controls.AddRange(new Control[]
            {
                lblTipoMovimento, rbIncasso, rbSpesa, rbAltro,
                lblCausale, cbCausale,
                lblProtocollo, tbAnno, lblBarra, tbNumero,
                lblData, dtpData,
                gbCausale,
                lblSpesa, cbSpesa,
                lblVoceSpesa, cbVoceSpesa,
                lblFornitore, tbFornitore, btnSelezionaFornitore,
                lblDocumento, lblDataDoc, dtpDataDocumento, lblNumDoc, tbNumDocumento,
                lblContoCorrente, tbContoCorrente, btnSelezionaCC,
                lblImporto, tbImporto,
                lblNote, tbNote,
                btnSalva, btnAbbandona, btnEsci
            });

            this.Controls.Add(panelPrincipale);
            this.Text = "Dati Movimento - Imm. 950 - Immobile dei Fiori";
            this.Width = 700;
            this.Height = 650;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void CaricaDati()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    // Carica Causali
                    string queryCausali = "SELECT DISTINCT Descrizione FROM MovimentiContabili WHERE IdGestione = @IdGestione";
                    SqlDataAdapter adaCausali = new SqlDataAdapter(queryCausali, conn);
                    adaCausali.SelectCommand.Parameters.AddWithValue("@IdGestione", _idGestione);
                    DataTable dtCausali = new DataTable();
                    adaCausali.Fill(dtCausali);

                    ComboBox cbCausale = this.Controls.Find("cbCausale", true).FirstOrDefault() as ComboBox;
                    if (cbCausale != null)
                    {
                        cbCausale.DataSource = dtCausali;
                        cbCausale.DisplayMember = "Descrizione";
                    }

                    // Carica Spese
                    string querySpese = "SELECT DISTINCT IdConto, Descrizione FROM PianoConti WHERE IdCondominio IN (SELECT IdCondominio FROM Gestioni WHERE IdGestione = @IdGestione) AND TipoConto = 'Costo'";
                    SqlDataAdapter adaSpese = new SqlDataAdapter(querySpese, conn);
                    adaSpese.SelectCommand.Parameters.AddWithValue("@IdGestione", _idGestione);
                    DataTable dtSpese = new DataTable();
                    adaSpese.Fill(dtSpese);

                    ComboBox cbSpesa = this.Controls.Find("cbSpesa", true).FirstOrDefault() as ComboBox;
                    if (cbSpesa != null)
                    {
                        cbSpesa.DataSource = dtSpese;
                        cbSpesa.DisplayMember = "Descrizione";
                        cbSpesa.ValueMember = "IdConto";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel caricamento dati: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RbTipoMovimento_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                MessageBox.Show($"Tipo movimento selezionato: {rb.Text}", "Info");
            }
        }

        private void CbCausale_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb != null && cb.SelectedItem != null)
            {
                DataRowView drv = cb.SelectedItem as DataRowView;
                if (drv != null)
                {
                    TextBox tbDescrizioneCausale = this.Controls.Find("tbDescrizioneCausale", true).FirstOrDefault() as TextBox;
                    if (tbDescrizioneCausale != null)
                    {
                        tbDescrizioneCausale.Text = drv["Descrizione"].ToString();
                    }
                }
            }
        }

        private void CbSpesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbSpesa = sender as ComboBox;
            if (cbSpesa != null && cbSpesa.SelectedValue != null)
            {
                CaricaVociSpesa(Convert.ToInt32(cbSpesa.SelectedValue));
            }
        }

        private void CaricaVociSpesa(int idConto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string queryVoci = "SELECT IdConto, Descrizione FROM PianoConti WHERE IdConto = @IdConto";
                    SqlDataAdapter ada = new SqlDataAdapter(queryVoci, conn);
                    ada.SelectCommand.Parameters.AddWithValue("@IdConto", idConto);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);

                    ComboBox cbVoceSpesa = this.Controls.Find("cbVoceSpesa", true).FirstOrDefault() as ComboBox;
                    if (cbVoceSpesa != null && dt.Rows.Count > 0)
                    {
                        cbVoceSpesa.DataSource = dt;
                        cbVoceSpesa.DisplayMember = "Descrizione";
                        cbVoceSpesa.ValueMember = "IdConto";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel caricamento voci spesa: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSelezionaFornitore_Click(object sender, EventArgs e)
        {
            // Apre una form per selezionare il fornitore da una lista
            FormFornitori formFornitori = new FormFornitori();
            if (formFornitori.ShowDialog() == DialogResult.OK)
            {
                TextBox tbFornitore = this.Controls.Find("tbFornitore", true).FirstOrDefault() as TextBox;
                if (tbFornitore != null)
                {
                    tbFornitore.Text = formFornitori.NomeFornitoreSelezionato;
                }
            }
        }

        private void BtnSelezionaContoCorrente_Click(object sender, EventArgs e)
        {
            // Apre una form per selezionare il conto corrente
            FormContiCorrenti formCC = new FormContiCorrenti();
            if (formCC.ShowDialog() == DialogResult.OK)
            {
                TextBox tbContoCorrente = this.Controls.Find("tbContoCorrente", true).FirstOrDefault() as TextBox;
                if (tbContoCorrente != null)
                {
                    tbContoCorrente.Text = formCC.ContoSelezionato;
                }
            }
        }

        private void BtnSalva_Click(object sender, EventArgs e)
        {
            if (ValidaDati())
            {
                SalvaMovimento();
                MessageBox.Show("Movimento salvato con successo!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidaDati()
        {
            TextBox tbImporto = this.Controls.Find("tbImporto", true).FirstOrDefault() as TextBox;
            if (tbImporto == null || string.IsNullOrWhiteSpace(tbImporto.Text))
            {
                MessageBox.Show("L'importo è obbligatorio!", "Errore Validazione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(tbImporto.Text, out decimal importo) || importo <= 0)
            {
                MessageBox.Show("L'importo deve essere un numero positivo!", "Errore Validazione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            ComboBox cbCausale = this.Controls.Find("cbCausale", true).FirstOrDefault() as ComboBox;
            if (cbCausale == null || cbCausale.SelectedIndex < 0)
            {
                MessageBox.Show("Selezionare una causale!", "Errore Validazione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void SalvaMovimento()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    TextBox tbImporto = this.Controls.Find("tbImporto", true).FirstOrDefault() as TextBox;
                    ComboBox cbCausale = this.Controls.Find("cbCausale", true).FirstOrDefault() as ComboBox;
                    ComboBox cbVoceSpesa = this.Controls.Find("cbVoceSpesa", true).FirstOrDefault() as ComboBox;
                    DateTimePicker dtpData = this.Controls.Find("dtpData", true).FirstOrDefault() as DateTimePicker;
                    TextBox tbNote = this.Controls.Find("tbNote", true).FirstOrDefault() as TextBox;

                    if (cbVoceSpesa?.SelectedValue != null)
                    {
                        string query = "INSERT INTO MovimentiContabili (IdGestione, IdConto, DataMovimento, Descrizione, Importo, TipoMovimento) " +
                                       "VALUES (@IdGestione, @IdConto, @DataMovimento, @Descrizione, @Importo, @TipoMovimento)";

                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@IdGestione", _idGestione);
                        cmd.Parameters.AddWithValue("@IdConto", Convert.ToInt32(cbVoceSpesa.SelectedValue));
                        cmd.Parameters.AddWithValue("@DataMovimento", dtpData.Value.Date);
                        cmd.Parameters.AddWithValue("@Descrizione", cbCausale.SelectedValue?.ToString() ?? "" + " - " + (tbNote.Text ?? ""));
                        cmd.Parameters.AddWithValue("@Importo", decimal.Parse(tbImporto.Text));
                        cmd.Parameters.AddWithValue("@TipoMovimento", "Dare");

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel salvataggio: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAbbandona_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnEsci_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
