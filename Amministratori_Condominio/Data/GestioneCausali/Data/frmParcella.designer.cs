namespace GestioneAmministratori
{
    partial class FormParcella
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelAmministratore;
        private System.Windows.Forms.ComboBox comboBoxAmministratore;
        private System.Windows.Forms.Label labelCondominio;
        private System.Windows.Forms.ComboBox comboBoxCondominio;
        private System.Windows.Forms.Label labelAnno;
        private System.Windows.Forms.TextBox textBoxAnno;
        private System.Windows.Forms.Button buttonCarica;
        private System.Windows.Forms.Button buttonEsporta;
        private System.Windows.Forms.DataGridView dataGridViewParcella;

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
            this.labelAmministratore = new System.Windows.Forms.Label();
            this.comboBoxAmministratore = new System.Windows.Forms.ComboBox();
            this.labelCondominio = new System.Windows.Forms.Label();
            this.comboBoxCondominio = new System.Windows.Forms.ComboBox();
            this.labelAnno = new System.Windows.Forms.Label();
            this.textBoxAnno = new System.Windows.Forms.TextBox();
            this.buttonCarica = new System.Windows.Forms.Button();
            this.buttonEsporta = new System.Windows.Forms.Button();
            this.dataGridViewParcella = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParcella)).BeginInit();
            this.SuspendLayout();

            // labelAmministratore
            this.labelAmministratore.AutoSize = true;
            this.labelAmministratore.Location = new System.Drawing.Point(12, 15);
            this.labelAmministratore.Name = "labelAmministratore";
            this.labelAmministratore.Size = new System.Drawing.Size(75, 13);
            this.labelAmministratore.TabIndex = 0;
            this.labelAmministratore.Text = "Amministratore:";

            // comboBoxAmministratore
            this.comboBoxAmministratore.FormattingEnabled = true;
            this.comboBoxAmministratore.Location = new System.Drawing.Point(93, 12);
            this.comboBoxAmministratore.Name = "comboBoxAmministratore";
            this.comboBoxAmministratore.Size = new System.Drawing.Size(200, 21);
            this.comboBoxAmministratore.TabIndex = 1;
            this.comboBoxAmministratore.SelectedIndexChanged += 
                new System.EventHandler(this.comboBoxAmministratore_SelectedIndexChanged);

            // labelCondominio
            this.labelCondominio.AutoSize = true;
            this.labelCondominio.Location = new System.Drawing.Point(310, 15);
            this.labelCondominio.Name = "labelCondominio";
            this.labelCondominio.Size = new System.Drawing.Size(60, 13);
            this.labelCondominio.TabIndex = 2;
            this.labelCondominio.Text = "Condominio:";

            // comboBoxCondominio
            this.comboBoxCondominio.FormattingEnabled = true;
            this.comboBoxCondominio.Location = new System.Drawing.Point(376, 12);
            this.comboBoxCondominio.Name = "comboBoxCondominio";
            this.comboBoxCondominio.Size = new System.Drawing.Size(200, 21);
            this.comboBoxCondominio.TabIndex = 3;

            // labelAnno
            this.labelAnno.AutoSize = true;
            this.labelAnno.Location = new System.Drawing.Point(582, 15);
            this.labelAnno.Name = "labelAnno";
            this.labelAnno.Size = new System.Drawing.Size(32, 13);
            this.labelAnno.TabIndex = 4;
            this.labelAnno.Text = "Anno:";

            // textBoxAnno
            this.textBoxAnno.Location = new System.Drawing.Point(620, 12);
            this.textBoxAnno.Name = "textBoxAnno";
            this.textBoxAnno.Size = new System.Drawing.Size(60, 20);
            this.textBoxAnno.TabIndex = 5;
            this.textBoxAnno.Text = DateTime.Now.Year.ToString();

            // buttonCarica
            this.buttonCarica.Location = new System.Drawing.Point(686, 12);
            this.buttonCarica.Name = "buttonCarica";
            this.buttonCarica.Size = new System.Drawing.Size(75, 23);
            this.buttonCarica.TabIndex = 6;
            this.buttonCarica.Text = "Carica";
            this.buttonCarica.UseVisualStyleBackColor = true;
            this.buttonCarica.Click += new System.EventHandler(this.buttonCarica_Click);

            // buttonEsporta
            this.buttonEsporta.Location = new System.Drawing.Point(767, 12);
            this.buttonEsporta.Name = "buttonEsporta";
            this.buttonEsporta.Size = new System.Drawing.Size(75, 23);
            this.buttonEsporta.TabIndex = 7;
            this.buttonEsporta.Text = "Esporta";
            this.buttonEsporta.UseVisualStyleBackColor = true;
            this.buttonEsporta.Click += new System.EventHandler(this.buttonEsporta_Click);

            // dataGridViewParcella
            this.dataGridViewParcella.ColumnHeadersHeightSizeMode = 
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParcella.Location = new System.Drawing.Point(12, 40);
            this.dataGridViewParcella.Name = "dataGridViewParcella";
            this.dataGridViewParcella.Size = new System.Drawing.Size(830, 350);
            this.dataGridViewParcella.TabIndex = 8;

            // FormParcella
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 400);
            this.Controls.Add(this.dataGridViewParcella);
            this.Controls.Add(this.buttonEsporta);
            this.Controls.Add(this.buttonCarica);
            this.Controls.Add(this.textBoxAnno);
            this.Controls.Add(this.labelAnno);
            this.Controls.Add(this.comboBoxCondominio);
            this.Controls.Add(this.labelCondominio);
            this.Controls.Add(this.comboBoxAmministratore);
            this.Controls.Add(this.labelAmministratore);
            this.Name = "FormParcella";
            this.Text = "Parcella Amministratore";
            this.Load += new System.EventHandler(this.FormParcella_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParcella)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
