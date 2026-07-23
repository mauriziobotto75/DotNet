namespace Amministratori_Condominio.UI
{
    partial class FrmGestioneAgenda
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grpFiltri = new System.Windows.Forms.GroupBox();
            this.lblMese = new System.Windows.Forms.Label();
            this.cmbMeseFiltro = new System.Windows.Forms.ComboBox();
            this.lblAnno = new System.Windows.Forms.Label();
            this.cmbAnnoFiltro = new System.Windows.Forms.ComboBox();
            this.lblStato = new System.Windows.Forms.Label();
            this.cmbStatoFiltro = new System.Windows.Forms.ComboBox();
            this.btnAggiorna = new System.Windows.Forms.Button();

            this.grpOrari = new System.Windows.Forms.GroupBox();
            this.dgvOrari = new System.Windows.Forms.DataGridView();

            this.grpDettagli = new System.Windows.Forms.GroupBox();
            this.dgvDettagli = new System.Windows.Forms.DataGridView();
            this.lblDescrizione = new System.Windows.Forms.Label();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.lblData = new System.Windows.Forms.Label();
            this.dtpDataIntervento = new System.Windows.Forms.DateTimePicker();
            this.lblCondominio = new System.Windows.Forms.Label();
            this.txtCondominio = new System.Windows.Forms.TextBox();
            this.lblStatoIntervento = new System.Windows.Forms.Label();
            this.txtStato = new System.Windows.Forms.TextBox();

            this.grpAzioni = new System.Windows.Forms.GroupBox();
            this.btnNuovoIntervento = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnCompleta = new System.Windows.Forms.Button();
            this.btnElimina = new System.Windows.Forms.Button();
            this.btnChiudi = new System.Windows.Forms.Button();

            this.grpFiltri.SuspendLayout();
            this.grpOrari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrari)).BeginInit();
            this.grpDettagli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDettagli)).BeginInit();
            this.grpAzioni.SuspendLayout();
            this.SuspendLayout();

            // grpFiltri
            this.grpFiltri.Controls.Add(this.lblMese);
            this.grpFiltri.Controls.Add(this.cmbMeseFiltro);
            this.grpFiltri.Controls.Add(this.lblAnno);
            this.grpFiltri.Controls.Add(this.cmbAnnoFiltro);
            this.grpFiltri.Controls.Add(this.lblStato);
            this.grpFiltri.Controls.Add(this.cmbStatoFiltro);
            this.grpFiltri.Controls.Add(this.btnAggiorna);
            this.grpFiltri.Location = new System.Drawing.Point(12, 12);
            this.grpFiltri.Name = "grpFiltri";
            this.grpFiltri.Size = new System.Drawing.Size(900, 60);
            this.grpFiltri.TabIndex = 0;
            this.grpFiltri.TabStop = false;
            this.grpFiltri.Text = "Filtri";

            // lblMese
            this.lblMese.AutoSize = true;
            this.lblMese.Location = new System.Drawing.Point(10, 25);
            this.lblMese.Name = "lblMese";
            this.lblMese.Size = new System.Drawing.Size(35, 13);
            this.lblMese.TabIndex = 0;
            this.lblMese.Text = "Mese:";

            // cmbMeseFiltro
            this.cmbMeseFiltro.FormattingEnabled = true;
            this.cmbMeseFiltro.Location = new System.Drawing.Point(50, 22);
            this.cmbMeseFiltro.Name = "cmbMeseFiltro";
            this.cmbMeseFiltro.Size = new System.Drawing.Size(120, 21);
            this.cmbMeseFiltro.TabIndex = 1;
            this.cmbMeseFiltro.SelectedIndexChanged += new System.EventHandler(this.cmbMeseFiltro_SelectedIndexChanged);

            // lblAnno
            this.lblAnno.AutoSize = true;
            this.lblAnno.Location = new System.Drawing.Point(185, 25);
            this.lblAnno.Name = "lblAnno";
            this.lblAnno.Size = new System.Drawing.Size(32, 13);
            this.lblAnno.TabIndex = 2;
            this.lblAnno.Text = "Anno:";

            // cmbAnnoFiltro
            this.cmbAnnoFiltro.FormattingEnabled = true;
            this.cmbAnnoFiltro.Location = new System.Drawing.Point(223, 22);
            this.cmbAnnoFiltro.Name = "cmbAnnoFiltro";
            this.cmbAnnoFiltro.Size = new System.Drawing.Size(80, 21);
            this.cmbAnnoFiltro.TabIndex = 3;

            // lblStato
            this.lblStato.AutoSize = true;
            this.lblStato.Location = new System.Drawing.Point(320, 25);
            this.lblStato.Name = "lblStato";
            this.lblStato.Size = new System.Drawing.Size(34, 13);
            this.lblStato.TabIndex = 4;
            this.lblStato.Text = "Stato:";

            // cmbStatoFiltro
            this.cmbStatoFiltro.FormattingEnabled = true;
            this.cmbStatoFiltro.Location = new System.Drawing.Point(360, 22);
            this.cmbStatoFiltro.Name = "cmbStatoFiltro";
            this.cmbStatoFiltro.Size = new System.Drawing.Size(120, 21);
            this.cmbStatoFiltro.TabIndex = 5;
            this.cmbStatoFiltro.SelectedIndexChanged += new System.EventHandler(this.cmbStatoFiltro_SelectedIndexChanged);

            // btnAggiorna
            this.btnAggiorna.Location = new System.Drawing.Point(800, 22);
            this.btnAggiorna.Name = "btnAggiorna";
            this.btnAggiorna.Size = new System.Drawing.Size(90, 23);
            this.btnAggiorna.TabIndex = 6;
            this.btnAggiorna.Text = "Aggiorna";
            this.btnAggiorna.UseVisualStyleBackColor = true;
            this.btnAggiorna.Click += new System.EventHandler(this.btnAggiorna_Click);

            // grpOrari
            this.grpOrari.Controls.Add(this.dgvOrari);
            this.grpOrari.Location = new System.Drawing.Point(12, 80);
            this.grpOrari.Name = "grpOrari";
            this.grpOrari.Size = new System.Drawing.Size(900, 200);
            this.grpOrari.TabIndex = 1;
            this.grpOrari.TabStop = false;
            this.grpOrari.Text = "Visualizzazione Settimanale";

            // dgvOrari
            this.dgvOrari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrari.Location = new System.Drawing.Point(3, 16);
            this.dgvOrari.Name = "dgvOrari";
            this.dgvOrari.ReadOnly = true;
            this.dgvOrari.Size = new System.Drawing.Size(894, 181);
            this.dgvOrari.TabIndex = 0;

            // grpDettagli
            this.grpDettagli.Controls.Add(this.dgvDettagli);
            this.grpDettagli.Controls.Add(this.lblDescrizione);
            this.grpDettagli.Controls.Add(this.txtDescrizione);
            this.grpDettagli.Controls.Add(this.lblData);
            this.grpDettagli.Controls.Add(this.dtpDataIntervento);
            this.grpDettagli.Controls.Add(this.lblCondominio);
            this.grpDettagli.Controls.Add(this.txtCondominio);
            this.grpDettagli.Controls.Add(this.lblStatoIntervento);
            this.grpDettagli.Controls.Add(this.txtStato);
            this.grpDettagli.Location = new System.Drawing.Point(12, 290);
            this.grpDettagli.Name = "grpDettagli";
            this.grpDettagli.Size = new System.Drawing.Size(900, 250);
            this.grpDettagli.TabIndex = 2;
            this.grpDettagli.TabStop = false;
            this.grpDettagli.Text = "Elenco Interventi";

            // dgvDettagli
            this.dgvDettagli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDettagli.Location = new System.Drawing.Point(6, 80);
            this.dgvDettagli.Name = "dgvDettagli";
            this.dgvDettagli.ReadOnly = true;
            this.dgvDettagli.Size = new System.Drawing.Size(888, 160);
            this.dgvDettagli.TabIndex = 0;
            this.dgvDettagli.SelectionChanged += new System.EventHandler(this.dgvDettagli_SelectionChanged);

            // lblDescrizione
            this.lblDescrizione.AutoSize = true;
            this.lblDescrizione.Location = new System.Drawing.Point(6, 22);
            this.lblDescrizione.Name = "lblDescrizione";
            this.lblDescrizione.Size = new System.Drawing.Size(61, 13);
            this.lblDescrizione.TabIndex = 1;
            this.lblDescrizione.Text = "Descrizione:";

            // txtDescrizione
            this.txtDescrizione.Location = new System.Drawing.Point(75, 19);
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ReadOnly = true;
            this.txtDescrizione.Size = new System.Drawing.Size(300, 20);
            this.txtDescrizione.TabIndex = 2;

            // lblData
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(380, 22);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(32, 13);
            this.lblData.TabIndex = 3;
            this.lblData.Text = "Data:";

            // dtpDataIntervento
            this.dtpDataIntervento.Location = new System.Drawing.Point(420, 19);
            this.dtpDataIntervento.Name = "dtpDataIntervento";
            this.dtpDataIntervento.Size = new System.Drawing.Size(120, 20);
            this.dtpDataIntervento.TabIndex = 4;
            this.dtpDataIntervento.Enabled = false;

            // lblCondominio
            this.lblCondominio.AutoSize = true;
            this.lblCondominio.Location = new System.Drawing.Point(6, 48);
            this.lblCondominio.Name = "lblCondominio";
            this.lblCondominio.Size = new System.Drawing.Size(60, 13);
            this.lblCondominio.TabIndex = 5;
            this.lblCondominio.Text = "Condominio:";

            // txtCondominio
            this.txtCondominio.Location = new System.Drawing.Point(75, 45);
            this.txtCondominio.Name = "txtCondominio";
            this.txtCondominio.ReadOnly = true;
            this.txtCondominio.Size = new System.Drawing.Size(300, 20);
            this.txtCondominio.TabIndex = 6;

            // lblStatoIntervento
            this.lblStatoIntervento.AutoSize = true;
            this.lblStatoIntervento.Location = new System.Drawing.Point(380, 48);
            this.lblStatoIntervento.Name = "lblStatoIntervento";
            this.lblStatoIntervento.Size = new System.Drawing.Size(34, 13);
            this.lblStatoIntervento.TabIndex = 7;
            this.lblStatoIntervento.Text = "Stato:";

            // txtStato
            this.txtStato.Location = new System.Drawing.Point(420, 45);
            this.txtStato.Name = "txtStato";
            this.txtStato.ReadOnly = true;
            this.txtStato.Size = new System.Drawing.Size(120, 20);
            this.txtStato.TabIndex = 8;

            // grpAzioni
            this.grpAzioni.Controls.Add(this.btnNuovoIntervento);
            this.grpAzioni.Controls.Add(this.btnModifica);
            this.grpAzioni.Controls.Add(this.btnCompleta);
            this.grpAzioni.Controls.Add(this.btnElimina);
            this.grpAzioni.Controls.Add(this.btnChiudi);
            this.grpAzioni.Location = new System.Drawing.Point(12, 548);
            this.grpAzioni.Name = "grpAzioni";
            this.grpAzioni.Size = new System.Drawing.Size(900, 60);
            this.grpAzioni.TabIndex = 3;
            this.grpAzioni.TabStop = false;
            this.grpAzioni.Text = "Azioni";

            // btnNuovoIntervento
            this.btnNuovoIntervento.Location = new System.Drawing.Point(10, 25);
            this.btnNuovoIntervento.Name = "btnNuovoIntervento";
            this.btnNuovoIntervento.Size = new System.Drawing.Size(100, 23);
            this.btnNuovoIntervento.TabIndex = 0;
            this.btnNuovoIntervento.Text = "Nuovo";
            this.btnNuovoIntervento.UseVisualStyleBackColor = true;
            this.btnNuovoIntervento.Click += new System.EventHandler(this.btnNuovoIntervento_Click);

            // btnModifica
            this.btnModifica.Location = new System.Drawing.Point(120, 25);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(100, 23);
            this.btnModifica.TabIndex = 1;
            this.btnModifica.Text = "Modifica";
            this.btnModifica.UseVisualStyleBackColor = true;
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);

            // btnCompleta
            this.btnCompleta.Location = new System.Drawing.Point(230, 25);
            this.btnCompleta.Name = "btnCompleta";
            this.btnCompleta.Size = new System.Drawing.Size(100, 23);
            this.btnCompleta.TabIndex = 2;
            this.btnCompleta.Text = "Completa";
            this.btnCompleta.UseVisualStyleBackColor = true;
            this.btnCompleta.Click += new System.EventHandler(this.btnCompleta_Click);

            // btnElimina
            this.btnElimina.Location = new System.Drawing.Point(340, 25);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(100, 23);
            this.btnElimina.TabIndex = 3;
            this.btnElimina.Text = "Elimina";
            this.btnElimina.UseVisualStyleBackColor = true;
            this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);

            // btnChiudi
            this.btnChiudi.Location = new System.Drawing.Point(800, 25);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(90, 23);
            this.btnChiudi.TabIndex = 4;
            this.btnChiudi.Text = "Chiudi";
            this.btnChiudi.UseVisualStyleBackColor = true;
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);

            // FrmGestioneAgenda
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 620);
            this.Controls.Add(this.grpAzioni);
            this.Controls.Add(this.grpDettagli);
            this.Controls.Add(this.grpOrari);
            this.Controls.Add(this.grpFiltri);
            this.Name = "FrmGestioneAgenda";
            this.Text = "Gestione Agenda dell'Amministratore";
            this.Load += new System.EventHandler(this.FrmGestioneAgenda_Load);
            this.grpFiltri.ResumeLayout(false);
            this.grpFiltri.PerformLayout();
            this.grpOrari.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrari)).EndInit();
            this.grpDettagli.ResumeLayout(false);
            this.grpDettagli.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDettagli)).EndInit();
            this.grpAzioni.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox grpFiltri;
        private System.Windows.Forms.Label lblMese;
        private System.Windows.Forms.ComboBox cmbMeseFiltro;
        private System.Windows.Forms.Label lblAnno;
        private System.Windows.Forms.ComboBox cmbAnnoFiltro;
        private System.Windows.Forms.Label lblStato;
        private System.Windows.Forms.ComboBox cmbStatoFiltro;
        private System.Windows.Forms.Button btnAggiorna;

        private System.Windows.Forms.GroupBox grpOrari;
        private System.Windows.Forms.DataGridView dgvOrari;

        private System.Windows.Forms.GroupBox grpDettagli;
        private System.Windows.Forms.DataGridView dgvDettagli;
        private System.Windows.Forms.Label lblDescrizione;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.DateTimePicker dtpDataIntervento;
        private System.Windows.Forms.Label lblCondominio;
        private System.Windows.Forms.TextBox txtCondominio;
        private System.Windows.Forms.Label lblStatoIntervento;
        private System.Windows.Forms.TextBox txtStato;

        private System.Windows.Forms.GroupBox grpAzioni;
        private System.Windows.Forms.Button btnNuovoIntervento;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.Button btnCompleta;
        private System.Windows.Forms.Button btnElimina;
        private System.Windows.Forms.Button btnChiudi;
    }
}
