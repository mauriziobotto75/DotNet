
namespace RistoranteWinFormsForms
{
    partial class ComandeForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvComande;
        private System.Windows.Forms.Label lblSala;
        private System.Windows.Forms.Label lblTavolo;
        private System.Windows.Forms.Label lblTotale;
        private System.Windows.Forms.Button btnConferma;
        private System.Windows.Forms.Button btnChiudi;

        private void InitializeComponent()
        {
            this.dgvComande = new System.Windows.Forms.DataGridView();
            this.lblSala = new System.Windows.Forms.Label();
            this.lblTavolo = new System.Windows.Forms.Label();
            this.lblTotale = new System.Windows.Forms.Label();
            this.btnConferma = new System.Windows.Forms.Button();
            this.btnChiudi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComande)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvComande
            // 
            this.dgvComande.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComande.Location = new System.Drawing.Point(12, 50);
            this.dgvComande.Name = "dgvComande";
            this.dgvComande.Size = new System.Drawing.Size(460, 200);
            this.dgvComande.TabIndex = 0;
            // 
            // lblSala
            // 
            this.lblSala.AutoSize = true;
            this.lblSala.Location = new System.Drawing.Point(12, 20);
            this.lblSala.Name = "lblSala";
            this.lblSala.Size = new System.Drawing.Size(33, 13);
            this.lblSala.TabIndex = 1;
            this.lblSala.Text = "Sala: ";
            // 
            // lblTavolo
            // 
            this.lblTavolo.AutoSize = true;
            this.lblTavolo.Location = new System.Drawing.Point(150, 20);
            this.lblTavolo.Name = "lblTavolo";
            this.lblTavolo.Size = new System.Drawing.Size(44, 13);
            this.lblTavolo.TabIndex = 2;
            this.lblTavolo.Text = "Tavolo: ";
            // 
            // lblTotale
            // 
            this.lblTotale.AutoSize = true;
            this.lblTotale.Location = new System.Drawing.Point(12, 270);
            this.lblTotale.Name = "lblTotale";
            this.lblTotale.Size = new System.Drawing.Size(43, 13);
            this.lblTotale.TabIndex = 3;
            this.lblTotale.Text = "Totale: ";
            // 
            // btnConferma
            // 
            this.btnConferma.Location = new System.Drawing.Point(316, 270);
            this.btnConferma.Name = "btnConferma";
            this.btnConferma.Size = new System.Drawing.Size(75, 23);
            this.btnConferma.TabIndex = 4;
            this.btnConferma.Text = "Conferma";
            this.btnConferma.UseVisualStyleBackColor = true;
            // 
            // btnChiudi
            // 
            this.btnChiudi.Location = new System.Drawing.Point(397, 270);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(75, 23);
            this.btnChiudi.TabIndex = 5;
            this.btnChiudi.Text = "Chiudi";
            this.btnChiudi.UseVisualStyleBackColor = true;
            // 
            // ComandeForm
            // 
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.btnChiudi);
            this.Controls.Add(this.btnConferma);
            this.Controls.Add(this.lblTotale);
            this.Controls.Add(this.lblTavolo);
            this.Controls.Add(this.lblSala);
            this.Controls.Add(this.dgvComande);
            this.Name = "ComandeForm";
            this.Text = "Gestione Comande";
            ((System.ComponentModel.ISupportInitialize)(this.dgvComande)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
