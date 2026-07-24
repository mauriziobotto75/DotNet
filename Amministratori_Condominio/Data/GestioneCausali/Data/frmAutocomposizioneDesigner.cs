namespace Amministratori
{
    partial class frmAutocomposizioneImmobile
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Codice generato da Windows Form Designer

        private void InitializeComponent()
        {
            this.lblTitolo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();

            this.lblCodice = new System.Windows.Forms.Label();
            this.lblDescrizione = new System.Windows.Forms.Label();
            this.lblIndirizzo = new System.Windows.Forms.Label();
            this.lblComune = new System.Windows.Forms.Label();
            this.lblCAP = new System.Windows.Forms.Label();
            this.lblCodiceFiscale = new System.Windows.Forms.Label();

            this.txtCodice = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.txtIndirizzo = new System.Windows.Forms.TextBox();
            this.txtComune = new System.Windows.Forms.TextBox();
            this.txtCAP = new System.Windows.Forms.TextBox();
            this.txtCodiceFiscale = new System.Windows.Forms.TextBox();

            this.btnComune = new System.Windows.Forms.Button();

            this.btnAbbandona = new System.Windows.Forms.Button();
            this.btnIndietro = new System.Windows.Forms.Button();
            this.btnAvanti = new System.Windows.Forms.Button();
            this.btnFine = new System.Windows.Forms.Button();

            this.pictureBox1 = new System.Windows.Forms.PictureBox();

            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();

            this.SuspendLayout();

            //
            // lblTitolo
            //
            this.lblTitolo.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif",
                    8.25F,
                    System.Drawing.FontStyle.Bold);

            this.lblTitolo.Location =
                new System.Drawing.Point(12, 9);

            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size =
                new System.Drawing.Size(460, 35);

            this.lblTitolo.Text =
                "La seguente funzione consente di generare un nuovo immobile sulla base delle indicazioni dell'operatore.";

            //
            // groupBox1
            //
            this.groupBox1.Controls.Add(this.lblCodice);
            this.groupBox1.Controls.Add(this.lblDescrizione);
            this.groupBox1.Controls.Add(this.lblIndirizzo);
            this.groupBox1.Controls.Add(this.lblComune);
            this.groupBox1.Controls.Add(this.lblCAP);
            this.groupBox1.Controls.Add(this.lblCodiceFiscale);

            this.groupBox1.Controls.Add(this.txtCodice);
            this.groupBox1.Controls.Add(this.txtDescrizione);
            this.groupBox1.Controls.Add(this.txtIndirizzo);
            this.groupBox1.Controls.Add(this.txtComune);
            this.groupBox1.Controls.Add(this.txtCAP);
            this.groupBox1.Controls.Add(this.txtCodiceFiscale);

            this.groupBox1.Controls.Add(this.btnComune);

            this.groupBox1.Location =
                new System.Drawing.Point(105, 52);

            this.groupBox1.Name = "groupBox1";

            this.groupBox1.Size =
                new System.Drawing.Size(410, 155);

            this.groupBox1.TabIndex = 0;

            this.groupBox1.TabStop = false;

            this.groupBox1.Text = "Dati Identificativi";

            //
            // lblCodice
            //
            this.lblCodice.Location =
                new System.Drawing.Point(15, 25);

            this.lblCodice.Size =
                new System.Drawing.Size(70, 20);

            this.lblCodice.Text = "Codice";

            //
            // txtCodice
            //
            this.txtCodice.Location =
                new System.Drawing.Point(110, 22);

            this.txtCodice.Size =
                new System.Drawing.Size(100, 20);

            //
            // lblDescrizione
            //
            this.lblDescrizione.Location =
                new System.Drawing.Point(15, 50);

            this.lblDescrizione.Size =
                new System.Drawing.Size(70, 20);

            this.lblDescrizione.Text = "Descrizione";

            //
            // txtDescrizione
            //
            this.txtDescrizione.Location =
                new System.Drawing.Point(110, 47);

            this.txtDescrizione.Size =
                new System.Drawing.Size(280, 20);

            //
            // lblIndirizzo
            //
            this.lblIndirizzo.Location =
                new System.Drawing.Point(15, 75);

            this.lblIndirizzo.Text = "Indirizzo";

            //
            // txtIndirizzo
            //
            this.txtIndirizzo.Location =
                new System.Drawing.Point(110, 72);

            this.txtIndirizzo.Size =
                new System.Drawing.Size(280, 20);

            //
            // lblComune
            //
            this.lblComune.Location =
                new System.Drawing.Point(15, 100);

            this.lblComune.Text = "Comune";

            //
            // txtComune
            //
            this.txtComune.Location =
                new System.Drawing.Point(110, 97);

            this.txtComune.Size =
                new System.Drawing.Size(240, 20);

            //
            // btnComune
            //
            this.btnComune.Location =
                new System.Drawing.Point(355, 96);

            this.btnComune.Size =
                new System.Drawing.Size(35, 22);

            this.btnComune.Text = "...";

            //
            // lblCAP
            //
            this.lblCAP.Location =
                new System.Drawing.Point(15, 125);

            this.lblCAP.Text = "CAP";

            //
            // txtCAP
            //
            this.txtCAP.Location =
                new System.Drawing.Point(110, 122);

            this.txtCAP.Size =
                new System.Drawing.Size(80, 20);

            //
            // lblCodiceFiscale
            //
            this.lblCodiceFiscale.Location =
                new System.Drawing.Point(210, 125);

            this.lblCodiceFiscale.Text =
                "Codice Fiscale";

            //
            // txtCodiceFiscale
            //
            this.txtCodiceFiscale.Location =
                new System.Drawing.Point(295, 122);

            this.txtCodiceFiscale.Size =
                new System.Drawing.Size(95, 20);

            //
            // pictureBox1
            //
            this.pictureBox1.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.pictureBox1.Location =
                new System.Drawing.Point(15, 60);

            this.pictureBox1.Size =
                new System.Drawing.Size(80, 120);

            this.pictureBox1.SizeMode =
                System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            //
            // btnAbbandona
            //
            this.btnAbbandona.Location =
                new System.Drawing.Point(155, 225);

            this.btnAbbandona.Size =
                new System.Drawing.Size(85, 25);

            this.btnAbbandona.Text = "Abbandona";

            this.btnAbbandona.Click +=
                new System.EventHandler(
                    this.btnAbbandona_Click);

            //
            // btnIndietro
            //
            this.btnIndietro.Location =
                new System.Drawing.Point(245, 225);

            this.btnIndietro.Size =
                new System.Drawing.Size(75, 25);

            this.btnIndietro.Text = "< Indietro";

            this.btnIndietro.Click +=
                new System.EventHandler(
                    this.btnIndietro_Click);

            //
            // btnAvanti
            //
            this.btnAvanti.Location =
                new System.Drawing.Point(325, 225);

            this.btnAvanti.Size =
                new System.Drawing.Size(75, 25);

            this.btnAvanti.Text = "Avanti >";

            this.btnAvanti.Click +=
                new System.EventHandler(
                    this.btnAvanti_Click);

            //
            // btnFine
            //
            this.btnFine.Location =
                new System.Drawing.Point(405, 225);

            this.btnFine.Size =
                new System.Drawing.Size(75, 25);

            this.btnFine.Text = "Fine";

            this.btnFine.Click +=
                new System.EventHandler(
                    this.btnFine_Click);

            //
            // frmAutocomposizioneImmobile
            //
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(6F, 13F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(535, 270);

            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTitolo);

            this.Controls.Add(this.btnAbbandona);
            this.Controls.Add(this.btnIndietro);
            this.Controls.Add(this.btnAvanti);
            this.Controls.Add(this.btnFine);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedDialog;

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.Name =
                "frmAutocomposizioneImmobile";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "Autocomposizione Immobile";

            this.Load +=
                new System.EventHandler(
                    this.frmAutocomposizioneImmobile_Load);

            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)
                (this.pictureBox1)).EndInit();

            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitolo;

        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.Label lblCodice;
        private System.Windows.Forms.Label lblDescrizione;
        private System.Windows.Forms.Label lblIndirizzo;
        private System.Windows.Forms.Label lblComune;
        private System.Windows.Forms.Label lblCAP;
        private System.Windows.Forms.Label lblCodiceFiscale;

        private System.Windows.Forms.TextBox txtCodice;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.TextBox txtIndirizzo;
        private System.Windows.Forms.TextBox txtComune;
        private System.Windows.Forms.TextBox txtCAP;
        private System.Windows.Forms.TextBox txtCodiceFiscale;

        private System.Windows.Forms.Button btnComune;

        private System.Windows.Forms.Button btnAbbandona;
        private System.Windows.Forms.Button btnIndietro;
        private System.Windows.Forms.Button btnAvanti;
        private System.Windows.Forms.Button btnFine;

        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
