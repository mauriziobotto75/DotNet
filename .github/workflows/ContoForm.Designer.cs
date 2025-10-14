
namespace RistoranteWinFormsForms
{
    partial class ContoForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvConto;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblOra;
        private System.Windows.Forms.Label lblTotale;
        private System.Windows.Forms.Button btnStampa;
        private System.Windows.Forms.Button btnChiudi;

        private void InitializeComponent()
        {
            this.dgvConto = new System.Windows.Forms.DataGridView();
            this.lblData = new System.Windows.Forms.Label();
            this.lblOra = new System.Windows.Forms.Label();
            this.lblTotale = new System.Windows.Forms.Label();
            this.btnStampa = new System.Windows.Forms.Button();
            this.btnChiudi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConto)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConto
            // 
            this.dgvConto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConto.Location = new System.Drawing.Point(12, 50);
            this.dgvConto.Name = "dgvConto";
            this.dgvConto.Size = new System.Drawing.Size(460, 200);
            this.dgvConto.TabIndex = 0;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(12, 20);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(33, 13);
            this.lblData.TabIndex = 1;
            this.lblData.Text = "Data:";
            // 
            // lblOra
            // 
            this.lblOra.AutoSize = true;
            this.lblOra.Location = new System.Drawing.Point(150, 20);
            this.lblOra.Name = "lblOra";
            this.lblOra.Size = new System.Drawing.Size(29, 13);
            this.lblOra.TabIndex = 2;
            this.lblOra.Text = "Ora:";
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
            // btnStampa
            // 
            this.btnStampa.Location = new System.Drawing.Point(316, 270);
            this.btnStampa.Name = "btnStampa";
            this.btnStampa.Size = new System.Drawing.Size(75, 23);
            this.btnStampa.TabIndex = 4;
            this.btnStampa.Text = "Stampa";
            this.btnStampa.UseVisualStyleBackColor = true;
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
            // ContoForm
            // 
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.btnChiudi);
            this.Controls.Add(this.btnStampa);
            this.Controls.Add(this.lblTotale);
            this.Controls.Add(this.lblOra);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.dgvConto);
            this.Name = "ContoForm";
            this.Text = "Conto del Cliente";
            ((System.ComponentModel.ISupportInitialize)(this.dgvConto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
