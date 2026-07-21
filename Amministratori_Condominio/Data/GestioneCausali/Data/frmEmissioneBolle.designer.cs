using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Gestione_Amministratore.Forms
{
    // UI layout del form EmissioneBolle (controlli principali).
    // Questa classe contiene solo la creazione dei controlli (analogamente al Designer).
    public partial class EmissioneBolle : Form
    {
        // Toolbar
        private ToolStrip toolStrip;
        private ToolStripButton tsbNew;
        private ToolStripButton tsbSave;
        private ToolStripButton tsbPrint;

        // Top selectors
        private Label lblStudio;
        private ComboBox cmbStudio;
        private Label lblImmobile;
        private ComboBox cmbImmobile;

        // Modulo / Tipo / Nome
        private GroupBox grpModulo;
        private Label lblTipo;
        private ComboBox cmbTipoModulo;
        private Label lblNomeModulo;
        private ComboBox cmbNomeModulo;
        private Button btnSelectModulo;
        private Button btnAddModulo;

        // C/C
        private Label lblCC;
        private ComboBox cmbCC;
        private Button btnSelectCC;
        private Button btnAddCC;

        // Dates / Numero Emesso
        private Label lblDataEmissione;
        private DateTimePicker dtpDataEmissione;
        private Label lblDataScadenza;
        private DateTimePicker dtpDataScadenza;
        private Label lblNumeroEmesso;
        private TextBox txtNumeroEmesso;

        // Pagamenti (DataGridView)
        private GroupBox grpPagamenti;
        private DataGridView dgvPagamenti;
        private Button btnAddPagamento;
        private Button btnRemovePagamento;

        // Totali / Spese / Bolli
        private CheckBox chkStampaDifferenza;
        private Label lblSpeseIncasso;
        private TextBox txtSpeseIncasso;
        private Label lblBolli;
        private TextBox txtBolli;
        private Label lblTotale;

        // Opzioni stampa
        private CheckBox chkStampaZero;
        private CheckBox chkStampaNegativi;
        private CheckBox chkSaltoPagina;

        // Internal data
        internal DataTable PagamentiTable;

        public EmissioneBolle()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Emissione Bollette";
            this.Size = new Size(900, 620);
            this.StartPosition = FormStartPosition.CenterParent;

            // ToolStrip
            toolStrip = new ToolStrip();
            tsbNew = new ToolStripButton("Nuovo");
            tsbSave = new ToolStripButton("Salva");
            tsbPrint = new ToolStripButton("Stampa");
            toolStrip.Items.AddRange(new ToolStripItem[] { tsbNew, tsbSave, tsbPrint });
            toolStrip.Dock = DockStyle.Top;
            this.Controls.Add(toolStrip);

            // Top selectors panel
            Panel topPanel = new Panel { Dock = DockStyle.Top, Height = 40 };
            lblStudio = new Label { Text = "Studio:", Left = 8, Top = 10, Width = 50 };
            cmbStudio = new ComboBox { Left = 60, Top = 6, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            lblImmobile = new Label { Text = "Immobile:", Left = 270, Top = 10, Width = 60 };
            cmbImmobile = new ComboBox { Left = 335, Top = 6, Width = 350, DropDownStyle = ComboBoxStyle.DropDownList };
            topPanel.Controls.AddRange(new Control[] { lblStudio, cmbStudio, lblImmobile, cmbImmobile });
            this.Controls.Add(topPanel);

            // Modulo group
            grpModulo = new GroupBox { Text = "Modulo", Left = 8, Top = 48, Width = 560, Height = 100 };
            lblTipo = new Label { Text = "Tipo:", Left = 8, Top = 24, Width = 50 };
            cmbTipoModulo = new ComboBox { Left = 60, Top = 20, Width = 140, DropDownStyle = ComboBoxStyle.DropDownList };
            lblNomeModulo = new Label { Text = "Nome:", Left = 210, Top = 24, Width = 50 };
            cmbNomeModulo = new ComboBox { Left = 260, Top = 20, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            btnSelectModulo = new Button { Text = "...", Left = 465, Top = 18, Width = 30 };
            btnAddModulo = new Button { Text = "+", Left = 505, Top = 18, Width = 30 };

            lblCC = new Label { Text = "C/C:", Left = 8, Top = 56, Width = 30 };
            cmbCC = new ComboBox { Left = 60, Top = 52, Width = 300, DropDownStyle = ComboBoxStyle.DropDownList };
            btnSelectCC = new Button { Text = "...", Left = 365, Top = 50, Width = 30 };
            btnAddCC = new Button { Text = "+", Left = 405, Top = 50, Width = 30 };

            grpModulo.Controls.AddRange(new Control[] {
                lblTipo, cmbTipoModulo, lblNomeModulo, cmbNomeModulo, btnSelectModulo, btnAddModulo,
                lblCC, cmbCC, btnSelectCC, btnAddCC
            });
            this.Controls.Add(grpModulo);

            // Dates and numero emesso panel
            Panel datesPanel = new Panel { Left = 576, Top = 48, Width = 300, Height = 100 };
            lblDataEmissione = new Label { Text = "Data Emissione:", Left = 8, Top = 8, Width = 100 };
            dtpDataEmissione = new DateTimePicker { Left = 110, Top = 4, Width = 170, Format = DateTimePickerFormat.Short };
            lblDataScadenza = new Label { Text = "Data Scadenza:", Left = 8, Top = 36, Width = 100 };
            dtpDataScadenza = new DateTimePicker { Left = 110, Top = 32, Width = 170, Format = DateTimePickerFormat.Short };
            lblNumeroEmesso = new Label { Text = "Ultimo Numero Emesso:", Left = 8, Top = 64, Width = 140 };
            txtNumeroEmesso = new TextBox { Left = 150, Top = 60, Width = 130, ReadOnly = true };

            datesPanel.Controls.AddRange(new Control[] { lblDataEmissione, dtpDataEmissione, lblDataScadenza, dtpDataScadenza, lblNumeroEmesso, txtNumeroEmesso });
            this.Controls.Add(datesPanel);

            // Pagamenti group (DataGridView)
            grpPagamenti = new GroupBox { Text = "Elenco Pagamenti", Left = 8, Top = 156, Width = 868, Height = 300 };
            dgvPagamenti = new DataGridView { Left = 8, Top = 20, Width = 840, Height = 240, AllowUserToAddRows = false, RowHeadersVisible = false };
            btnAddPagamento = new Button { Text = "Aggiungi", Left = 8, Top = 265, Width = 90 };
            btnRemovePagamento = new Button { Text = "Rimuovi", Left = 106, Top = 265, Width = 90 };
            grpPagamenti.Controls.AddRange(new Control[] { dgvPagamenti, btnAddPagamento, btnRemovePagamento });
            this.Controls.Add(grpPagamenti);

            // Totals and options panel
            Panel bottomPanel = new Panel { Left = 8, Top = 470, Width = 868, Height = 120 };
            chkStampaDifferenza = new CheckBox { Text = "Stampa differenza tra Dovuto e Pagato", Left = 8, Top = 8, Width = 260 };
            lblSpeseIncasso = new Label { Text = "Spese Incasso:", Left = 8, Top = 36, Width = 100 };
            txtSpeseIncasso = new TextBox { Left = 110, Top = 32, Width = 80, Text = "0.00" };
            lblBolli = new Label { Text = "Bolli:", Left = 200, Top = 36, Width = 50 };
            txtBolli = new TextBox { Left = 245, Top = 32, Width = 80, Text = "0.00" };
            lblTotale = new Label { Text = "Totale: 0.00", Left = 350, Top = 36, Width = 200 };

            chkStampaZero = new CheckBox { Text = "Stampa Boll. con Importi a Zero", Left = 8, Top = 64, Width = 200 };
            chkStampaNegativi = new CheckBox { Text = "Stampa Boll. con Importi Negativi", Left = 210, Top = 64, Width = 250 };
            chkSaltoPagina = new CheckBox { Text = "Salto pagina per ogni bolletta", Left = 470, Top = 64, Width = 220 };

            bottomPanel.Controls.AddRange(new Control[] {
                chkStampaDifferenza, lblSpeseIncasso, txtSpeseIncasso, lblBolli, txtBolli, lblTotale,
                chkStampaZero, chkStampaNegativi, chkSaltoPagina
            });
            this.Controls.Add(bottomPanel);

            // Event wiring (basic)
            this.Load += EmissioneBolle_Load;
            tsbNew.Click += tsbNew_Click;
            tsbSave.Click += tsbSave_Click;
            tsbPrint.Click += tsbPrint_Click;
            cmbStudio.SelectedIndexChanged += cmbStudio_SelectedIndexChanged;
            cmbImmobile.SelectedIndexChanged += cmbImmobile_SelectedIndexChanged;
            btnAddPagamento.Click += btnAddPagamento_Click;
            btnRemovePagamento.Click += btnRemovePagamento_Click;
            dgvPagamenti.CellValueChanged += dgvPagamenti_CellValueChanged;
            dtpDataEmissione.ValueChanged += dtpDataEmissione_ValueChanged;
            dtpDataScadenza.ValueChanged += dtpDataScadenza_ValueChanged;
            txtSpeseIncasso.TextChanged += txtSpeseIncasso_TextChanged;
            txtBolli.TextChanged += txtBolli_TextChanged;
            btnSelectModulo.Click += btnSelectModulo_Click;
            btnSelectCC.Click += btnSelectCC_Click;
        }
    }
}
