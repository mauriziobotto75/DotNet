namespace Amministratori_Condominio.UI
{
    partial class FrmAggiungiIntervento
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
            this.lblCondominio = new System.Windows.Forms.Label();
            this.cmbCondominio = new System.Windows.Forms.ComboBox();
            this.lblDescrizione = new System.Windows.Forms.Label();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.lblData = new System.Windows.Forms.Label();
            this.dtpDataIntervento = new System.Windows.Forms.DateTimePicker();
            this.lblStato = new System.Windows.Forms.Label();
            this.cmbStato = new System.Windows.Forms.ComboBox();
            this.chkDataPassata = new System.Windows.Forms.CheckBox();
            this.btnSalva = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblCondominio
            this.lblCondominio.AutoSize = true;
            this.lblCondominio.Location = new System.Drawing.Point(12, 15);
            this.lblCondominio.Name = "lblCondominio";
            this.lblCondominio.Size = new System.Drawing.Size(60, 13);
            this.lblCondominio.TabIndex = 0;
            this.lblCondominio.Text = "Condominio:";

            // cmbCondominio
            this.cmbCondominio.FormattingEnabled = true;
            this.cmbCondominio.Location = new System.Drawing.Point(100, 12);
            this.cmbCondominio.Name = "cmbCondominio";
            this.cmbCondominio.Size = new System.Drawing.Size(250, 21);
            this.cmbCondominio.TabIndex = 1;
            this.cmbCondominio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // lblDescrizione
            this.lblDescrizione.AutoSize = true;
            this.lblDescrizione.Location = new System.Drawing.Point(12, 45);
            this.lblDescrizione.Name = "lblDescrizione";
            this.lblDescrizione.Size = new System.Drawing.Size(61, 13);
            this.lblDescrizione.TabIndex = 2;
            this.lblDescrizione.Text = "Descrizione:";

            // txtDescrizione
            this.txtDescrizione.Location = new System.Drawing.Point(100, 42);
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(350, 20);
            this.txtDescrizione.TabIndex = 3;
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Height = 80;

            // lblData
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(12, 130);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(88, 13);
            this.lblData.TabIndex = 4;
            this.lblData.Text = "Data Intervento:";

            // dtpDataIntervento
            this.dtpDataIntervento.Location = new System.Drawing.Point(100, 127);
            this.dtpDataIntervento.Name = "dtpDataIntervento";
            this.dtpDataIntervento.Size = new System.Drawing.Size(200, 20);
            this.dtpDataIntervento.TabIndex = 5;
            this.dtpDataIntervento.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // lblStato
            this.lblStato.AutoSize = true;
            this.lblStato.Location = new System.Drawing.Point(12, 160);
            this.lblStato.Name = "lblStato";
            this.lblStato.Size = new System.Drawing.Size(34, 13);
            this.lblStato.TabIndex = 6;
            this.lblStato.Text = "Stato:";

            // cmbStato
            this.cmbStato.FormattingEnabled = true;
            this.cmbStato.Items.AddRange(new object[] { "Programmato", "In Corso", "Completato", "Rimandato" });
            this.cmbStato.Location = new System.Drawing.Point(100, 157);
            this.cmbStato.Name = "cmbStato";
            this.cmbStato.Size = new System.Drawing.Size(150, 21);
            this.cmbStato.TabIndex = 7;
            this.cmbStato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // chkDataPassata
            this.chkDataPassata.AutoSize = true;
            this.chkDataPassata.Location = new System.Drawing.Point(100, 190);
            this.chkDataPassata.Name = "chkDataPassata";
            this.chkDataPassata.Size = new System.Drawing.Size(150, 17);
            this.chkDataPassata.TabIndex = 8;
            this.chkDataPassata.Text = "Permetti data nel passato";
            this.chkDataPassata.UseVisualStyleBackColor = true;
            this.chkDataPassata.CheckedChanged += new System.EventHandler(this.chkDataPassata_CheckedChanged);

            // btnSalva
            this.btnSalva.Location = new System.Drawing.Point(150, 220);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(100, 23);
            this.btnSalva.TabIndex = 9;
            this.btnSalva.Text = "Salva";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);

            // btnAnnulla
            this.btnAnnulla.Location = new System.Drawing.Point(260, 220);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(100, 23);
            this.btnAnnulla.TabIndex = 10;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);

            // FrmAggiungiIntervento
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 260);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnSalva);
            this.Controls.Add(this.chkDataPassata);
            this.Controls.Add(this.cmbStato);
            this.Controls.Add(this.lblStato);
            this.Controls.Add(this.dtpDataIntervento);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.lblDescrizione);
            this.Controls.Add(this.cmbCondominio);
            this.Controls.Add(this.lblCondominio);
            this.Name = "FrmAggiungiIntervento";
            this.Text = "Aggiungi Intervento";
            this.Load += new System.EventHandler(this.FrmAggiungiIntervento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblCondominio;
        private System.Windows.Forms.ComboBox cmbCondominio;
        private System.Windows.Forms.Label lblDescrizione;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.DateTimePicker dtpDataIntervento;
        private System.Windows.Forms.Label lblStato;
        private System.Windows.Forms.ComboBox cmbStato;
        private System.Windows.Forms.CheckBox chkDataPassata;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.Button btnAnnulla;
    }
}
