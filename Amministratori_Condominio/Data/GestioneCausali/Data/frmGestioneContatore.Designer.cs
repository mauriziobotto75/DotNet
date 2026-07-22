namespace Amministratori_Condominio.UI
{
    partial class FrmGestioneContatore
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
            this.grpContatore = new System.Windows.Forms.GroupBox();
            this.txtNomeContatore = new System.Windows.Forms.TextBox();
            this.lblNomeContatore = new System.Windows.Forms.Label();
            this.txtUnitaMisura = new System.Windows.Forms.TextBox();
            this.lblUnitaMisura = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.btnSalvaContatore = new System.Windows.Forms.Button();

            this.grpLetture = new System.Windows.Forms.GroupBox();
            this.dgvLetture = new System.Windows.Forms.DataGridView();
            this.cmbUnita = new System.Windows.Forms.ComboBox();
            this.lblUnita = new System.Windows.Forms.Label();
            this.dtpDataLettura = new System.Windows.Forms.DateTimePicker();
            this.lblDataLettura = new System.Windows.Forms.Label();
            this.txtValoreLettura = new System.Windows.Forms.TextBox();
            this.lblValoreLettura = new System.Windows.Forms.Label();
            this.btnAggiungiLettura = new System.Windows.Forms.Button();
            this.btnModificaLettura = new System.Windows.Forms.Button();
            this.btnEliminaLettura = new System.Windows.Forms.Button();

            this.grpConsumi = new System.Windows.Forms.GroupBox();
            this.dgvConsumi = new System.Windows.Forms.DataGridView();
            this.txtTotaleLettureFinali = new System.Windows.Forms.TextBox();
            this.lblTotaleLettureFinali = new System.Windows.Forms.Label();
            this.txtDifferenzaConsumi = new System.Windows.Forms.TextBox();
            this.lblDifferenzaConsumi = new System.Windows.Forms.Label();

            this.btnChiudi = new System.Windows.Forms.Button();

            this.grpContatore.SuspendLayout();
            this.grpLetture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLetture)).BeginInit();
            this.grpConsumi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumi)).BeginInit();
            this.SuspendLayout();

            // grpContatore
            this.grpContatore.Controls.Add(this.lblNomeContatore);
            this.grpContatore.Controls.Add(this.txtNomeContatore);
            this.grpContatore.Controls.Add(this.lblUnitaMisura);
            this.grpContatore.Controls.Add(this.txtUnitaMisura);
            this.grpContatore.Controls.Add(this.lblTipo);
            this.grpContatore.Controls.Add(this.cmbTipo);
            this.grpContatore.Controls.Add(this.btnSalvaContatore);
            this.grpContatore.Location = new System.Drawing.Point(12, 12);
            this.grpContatore.Name = "grpContatore";
            this.grpContatore.Size = new System.Drawing.Size(650, 100);
            this.grpContatore.TabIndex = 0;
            this.grpContatore.TabStop = false;
            this.grpContatore.Text = "Dati Contatore";

            // lblNomeContatore
            this.lblNomeContatore.AutoSize = true;
            this.lblNomeContatore.Location = new System.Drawing.Point(6, 22);
            this.lblNomeContatore.Name = "lblNomeContatore";
            this.lblNomeContatore.Size = new System.Drawing.Size(35, 13);
            this.lblNomeContatore.TabIndex = 0;
            this.lblNomeContatore.Text = "Nome:";

            // txtNomeContatore
            this.txtNomeContatore.Location = new System.Drawing.Point(50, 19);
            this.txtNomeContatore.Name = "txtNomeContatore";
            this.txtNomeContatore.Size = new System.Drawing.Size(150, 20);
            this.txtNomeContatore.TabIndex = 1;

            // lblUnitaMisura
            this.lblUnitaMisura.AutoSize = true;
            this.lblUnitaMisura.Location = new System.Drawing.Point(6, 48);
            this.lblUnitaMisura.Name = "lblUnitaMisura";
            this.lblUnitaMisura.Size = new System.Drawing.Size(70, 13);
            this.lblUnitaMisura.TabIndex = 2;
            this.lblUnitaMisura.Text = "Unità Misura:";

            // txtUnitaMisura
            this.txtUnitaMisura.Location = new System.Drawing.Point(80, 45);
            this.txtUnitaMisura.Name = "txtUnitaMisura";
            this.txtUnitaMisura.Size = new System.Drawing.Size(120, 20);
            this.txtUnitaMisura.TabIndex = 3;

            // lblTipo
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(220, 22);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 4;
            this.lblTipo.Text = "Tipo:";

            // cmbTipo
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
                "Acqua Fredda",
                "Acqua Calda",
                "Termico",
                "Gas",
                "Elettricità"});
            this.cmbTipo.Location = new System.Drawing.Point(260, 19);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(120, 21);
            this.cmbTipo.TabIndex = 5;

            // btnSalvaContatore
            this.btnSalvaContatore.Location = new System.Drawing.Point(540, 65);
            this.btnSalvaContatore.Name = "btnSalvaContatore";
            this.btnSalvaContatore.Size = new System.Drawing.Size(100, 23);
            this.btnSalvaContatore.TabIndex = 6;
            this.btnSalvaContatore.Text = "Salva Contatore";
            this.btnSalvaContatore.UseVisualStyleBackColor = true;
            this.btnSalvaContatore.Click += new System.EventHandler(this.btnSalvaContatore_Click);

            // grpLetture
            this.grpLetture.Controls.Add(this.lblUnita);
            this.grpLetture.Controls.Add(this.cmbUnita);
            this.grpLetture.Controls.Add(this.lblDataLettura);
            this.grpLetture.Controls.Add(this.dtpDataLettura);
            this.grpLetture.Controls.Add(this.lblValoreLettura);
            this.grpLetture.Controls.Add(this.txtValoreLettura);
            this.grpLetture.Controls.Add(this.btnAggiungiLettura);
            this.grpLetture.Controls.Add(this.btnModificaLettura);
            this.grpLetture.Controls.Add(this.btnEliminaLettura);
            this.grpLetture.Controls.Add(this.dgvLetture);
            this.grpLetture.Location = new System.Drawing.Point(12, 118);
            this.grpLetture.Name = "grpLetture";
            this.grpLetture.Size = new System.Drawing.Size(650, 250);
            this.grpLetture.TabIndex = 1;
            this.grpLetture.TabStop = false;
            this.grpLetture.Text = "Letture Contatore";

            // lblUnita
            this.lblUnita.AutoSize = true;
            this.lblUnita.Location = new System.Drawing.Point(6, 22);
            this.lblUnita.Name = "lblUnita";
            this.lblUnita.Size = new System.Drawing.Size(35, 13);
            this.lblUnita.TabIndex = 0;
            this.lblUnita.Text = "Unità:";

            // cmbUnita
            this.cmbUnita.FormattingEnabled = true;
            this.cmbUnita.Location = new System.Drawing.Point(50, 19);
            this.cmbUnita.Name = "cmbUnita";
            this.cmbUnita.Size = new System.Drawing.Size(150, 21);
            this.cmbUnita.TabIndex = 1;

            // lblDataLettura
            this.lblDataLettura.AutoSize = true;
            this.lblDataLettura.Location = new System.Drawing.Point(210, 22);
            this.lblDataLettura.Name = "lblDataLettura";
            this.lblDataLettura.Size = new System.Drawing.Size(32, 13);
            this.lblDataLettura.TabIndex = 2;
            this.lblDataLettura.Text = "Data:";

            // dtpDataLettura
            this.dtpDataLettura.Location = new System.Drawing.Point(250, 19);
            this.dtpDataLettura.Name = "dtpDataLettura";
            this.dtpDataLettura.Size = new System.Drawing.Size(120, 20);
            this.dtpDataLettura.TabIndex = 3;

            // lblValoreLettura
            this.lblValoreLettura.AutoSize = true;
            this.lblValoreLettura.Location = new System.Drawing.Point(380, 22);
            this.lblValoreLettura.Name = "lblValoreLettura";
            this.lblValoreLettura.Size = new System.Drawing.Size(36, 13);
            this.lblValoreLettura.TabIndex = 4;
            this.lblValoreLettura.Text = "Valore:";

            // txtValoreLettura
            this.txtValoreLettura.Location = new System.Drawing.Point(420, 19);
            this.txtValoreLettura.Name = "txtValoreLettura";
            this.txtValoreLettura.Size = new System.Drawing.Size(100, 20);
            this.txtValoreLettura.TabIndex = 5;

            // btnAggiungiLettura
            this.btnAggiungiLettura.Location = new System.Drawing.Point(540, 19);
            this.btnAggiungiLettura.Name = "btnAggiungiLettura";
            this.btnAggiungiLettura.Size = new System.Drawing.Size(100, 23);
            this.btnAggiungiLettura.TabIndex = 6;
            this.btnAggiungiLettura.Text = "Aggiungi";
            this.btnAggiungiLettura.UseVisualStyleBackColor = true;
            this.btnAggiungiLettura.Click += new System.EventHandler(this.btnAggiungiLettura_Click);

            // btnModificaLettura
            this.btnModificaLettura.Location = new System.Drawing.Point(540, 48);
            this.btnModificaLettura.Name = "btnModificaLettura";
            this.btnModificaLettura.Size = new System.Drawing.Size(100, 23);
            this.btnModificaLettura.TabIndex = 7;
            this.btnModificaLettura.Text = "Modifica";
            this.btnModificaLettura.UseVisualStyleBackColor = true;
            this.btnModificaLettura.Click += new System.EventHandler(this.btnModificaLettura_Click);

            // btnEliminaLettura
            this.btnEliminaLettura.Location = new System.Drawing.Point(540, 77);
            this.btnEliminaLettura.Name = "btnEliminaLettura";
            this.btnEliminaLettura.Size = new System.Drawing.Size(100, 23);
            this.btnEliminaLettura.TabIndex = 8;
            this.btnEliminaLettura.Text = "Elimina";
            this.btnEliminaLettura.UseVisualStyleBackColor = true;
            this.btnEliminaLettura.Click += new System.EventHandler(this.btnEliminaLettura_Click);

            // dgvLetture
            this.dgvLetture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLetture.Location = new System.Drawing.Point(6, 50);
            this.dgvLetture.Name = "dgvLetture";
            this.dgvLetture.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLetture.Size = new System.Drawing.Size(530, 190);
            this.dgvLetture.TabIndex = 9;
            this.dgvLetture.SelectionChanged += new System.EventHandler(this.dgvLetture_SelectionChanged);

            // grpConsumi
            this.grpConsumi.Controls.Add(this.dgvConsumi);
            this.grpConsumi.Controls.Add(this.lblTotaleLettureFinali);
            this.grpConsumi.Controls.Add(this.txtTotaleLettureFinali);
            this.grpConsumi.Controls.Add(this.lblDifferenzaConsumi);
            this.grpConsumi.Controls.Add(this.txtDifferenzaConsumi);
            this.grpConsumi.Location = new System.Drawing.Point(12, 374);
            this.grpConsumi.Name = "grpConsumi";
            this.grpConsumi.Size = new System.Drawing.Size(650, 180);
            this.grpConsumi.TabIndex = 2;
            this.grpConsumi.TabStop = false;
            this.grpConsumi.Text = "Riepilogo Consumi";

            // dgvConsumi
            this.dgvConsumi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsumi.Location = new System.Drawing.Point(6, 20);
            this.dgvConsumi.Name = "dgvConsumi";
            this.dgvConsumi.ReadOnly = true;
            this.dgvConsumi.Size = new System.Drawing.Size(634, 100);
            this.dgvConsumi.TabIndex = 0;
            this.dgvConsumi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // lblTotaleLettureFinali
            this.lblTotaleLettureFinali.AutoSize = true;
            this.lblTotaleLettureFinali.Location = new System.Drawing.Point(6, 130);
            this.lblTotaleLettureFinali.Name = "lblTotaleLettureFinali";
            this.lblTotaleLettureFinali.Size = new System.Drawing.Size(110, 13);
            this.lblTotaleLettureFinali.TabIndex = 1;
            this.lblTotaleLettureFinali.Text = "Totale Letture Finali:";

            // txtTotaleLettureFinali
            this.txtTotaleLettureFinali.Location = new System.Drawing.Point(120, 127);
            this.txtTotaleLettureFinali.Name = "txtTotaleLettureFinali";
            this.txtTotaleLettureFinali.ReadOnly = true;
            this.txtTotaleLettureFinali.Size = new System.Drawing.Size(100, 20);
            this.txtTotaleLettureFinali.TabIndex = 2;

            // lblDifferenzaConsumi
            this.lblDifferenzaConsumi.AutoSize = true;
            this.lblDifferenzaConsumi.Location = new System.Drawing.Point(340, 130);
            this.lblDifferenzaConsumi.Name = "lblDifferenzaConsumi";
            this.lblDifferenzaConsumi.Size = new System.Drawing.Size(116, 13);
            this.lblDifferenzaConsumi.TabIndex = 3;
            this.lblDifferenzaConsumi.Text = "Totale Differenze:";

            // txtDifferenzaConsumi
            this.txtDifferenzaConsumi.Location = new System.Drawing.Point(462, 127);
            this.txtDifferenzaConsumi.Name = "txtDifferenzaConsumi";
            this.txtDifferenzaConsumi.ReadOnly = true;
            this.txtDifferenzaConsumi.Size = new System.Drawing.Size(100, 20);
            this.txtDifferenzaConsumi.TabIndex = 4;

            // btnChiudi
            this.btnChiudi.Location = new System.Drawing.Point(562, 562);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(100, 23);
            this.btnChiudi.TabIndex = 3;
            this.btnChiudi.Text = "Chiudi";
            this.btnChiudi.UseVisualStyleBackColor = true;
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);

            // FrmGestioneContatore
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 597);
            this.Controls.Add(this.grpConsumi);
            this.Controls.Add(this.btnChiudi);
            this.Controls.Add(this.grpLetture);
            this.Controls.Add(this.grpContatore);
            this.Name = "FrmGestioneContatore";
            this.Text = "Gestione Contatore";
            this.Load += new System.EventHandler(this.FrmGestioneContatore_Load);
            this.grpContatore.ResumeLayout(false);
            this.grpContatore.PerformLayout();
            this.grpLetture.ResumeLayout(false);
            this.grpLetture.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLetture)).EndInit();
            this.grpConsumi.ResumeLayout(false);
            this.grpConsumi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumi)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox grpContatore;
        private System.Windows.Forms.Label lblNomeContatore;
        private System.Windows.Forms.TextBox txtNomeContatore;
        private System.Windows.Forms.Label lblUnitaMisura;
        private System.Windows.Forms.TextBox txtUnitaMisura;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Button btnSalvaContatore;

        private System.Windows.Forms.GroupBox grpLetture;
        private System.Windows.Forms.Label lblUnita;
        private System.Windows.Forms.ComboBox cmbUnita;
        private System.Windows.Forms.Label lblDataLettura;
        private System.Windows.Forms.DateTimePicker dtpDataLettura;
        private System.Windows.Forms.Label lblValoreLettura;
        private System.Windows.Forms.TextBox txtValoreLettura;
        private System.Windows.Forms.Button btnAggiungiLettura;
        private System.Windows.Forms.Button btnModificaLettura;
        private System.Windows.Forms.Button btnEliminaLettura;
        private System.Windows.Forms.DataGridView dgvLetture;

        private System.Windows.Forms.GroupBox grpConsumi;
        private System.Windows.Forms.DataGridView dgvConsumi;
        private System.Windows.Forms.Label lblTotaleLettureFinali;
        private System.Windows.Forms.TextBox txtTotaleLettureFinali;
        private System.Windows.Forms.Label lblDifferenzaConsumi;
        private System.Windows.Forms.TextBox txtDifferenzaConsumi;

        private System.Windows.Forms.Button btnChiudi;
    }
}
