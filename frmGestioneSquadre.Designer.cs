namespace EsISCS
{
    partial class frmGestioneSquadre
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            this.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.squadraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giocateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vinteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pareggiateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.golFattiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.golSubitiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puntiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.differenzaRetiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.squadreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.campionatoDataSet1 = new EsISCS.CampionatoDataSet1();
            this.squadreTableAdapter = new EsISCS.CampionatoDataSet1TableAdapters.SquadreTableAdapter();
            this.campionatoDataSet = new EsISCS.CampionatoDataSet();
            this.squadreTableAdapter1 = new EsISCS.CampionatoDataSetTableAdapters.SquadreTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.squadreBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.campionatoDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.campionatoDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.squadraDataGridViewTextBoxColumn,
            this.giocateDataGridViewTextBoxColumn,
            this.vinteDataGridViewTextBoxColumn,
            this.pareggiateDataGridViewTextBoxColumn,
            this.perseDataGridViewTextBoxColumn,
            this.golFattiDataGridViewTextBoxColumn,
            this.golSubitiDataGridViewTextBoxColumn,
            this.puntiDataGridViewTextBoxColumn,
            this.differenzaRetiDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.squadreBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(1, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(791, 298);
            this.dataGridView1.TabIndex = 0;
            // 
            // squadraDataGridViewTextBoxColumn
            // 
            this.squadraDataGridViewTextBoxColumn.DataPropertyName = "Squadra";
            this.squadraDataGridViewTextBoxColumn.HeaderText = "Squadra";
            this.squadraDataGridViewTextBoxColumn.Name = "squadraDataGridViewTextBoxColumn";
            // 
            // giocateDataGridViewTextBoxColumn
            // 
            this.giocateDataGridViewTextBoxColumn.DataPropertyName = "Giocate";
            this.giocateDataGridViewTextBoxColumn.HeaderText = "Giocate";
            this.giocateDataGridViewTextBoxColumn.Name = "giocateDataGridViewTextBoxColumn";
            // 
            // vinteDataGridViewTextBoxColumn
            // 
            this.vinteDataGridViewTextBoxColumn.DataPropertyName = "Vinte";
            this.vinteDataGridViewTextBoxColumn.HeaderText = "Vinte";
            this.vinteDataGridViewTextBoxColumn.Name = "vinteDataGridViewTextBoxColumn";
            // 
            // pareggiateDataGridViewTextBoxColumn
            // 
            this.pareggiateDataGridViewTextBoxColumn.DataPropertyName = "Pareggiate";
            this.pareggiateDataGridViewTextBoxColumn.HeaderText = "Pareggiate";
            this.pareggiateDataGridViewTextBoxColumn.Name = "pareggiateDataGridViewTextBoxColumn";
            // 
            // perseDataGridViewTextBoxColumn
            // 
            this.perseDataGridViewTextBoxColumn.DataPropertyName = "Perse";
            this.perseDataGridViewTextBoxColumn.HeaderText = "Perse";
            this.perseDataGridViewTextBoxColumn.Name = "perseDataGridViewTextBoxColumn";
            // 
            // golFattiDataGridViewTextBoxColumn
            // 
            this.golFattiDataGridViewTextBoxColumn.DataPropertyName = "GolFatti";
            this.golFattiDataGridViewTextBoxColumn.HeaderText = "GolFatti";
            this.golFattiDataGridViewTextBoxColumn.Name = "golFattiDataGridViewTextBoxColumn";
            // 
            // golSubitiDataGridViewTextBoxColumn
            // 
            this.golSubitiDataGridViewTextBoxColumn.DataPropertyName = "GolSubiti";
            this.golSubitiDataGridViewTextBoxColumn.HeaderText = "GolSubiti";
            this.golSubitiDataGridViewTextBoxColumn.Name = "golSubitiDataGridViewTextBoxColumn";
            // 
            // puntiDataGridViewTextBoxColumn
            // 
            this.puntiDataGridViewTextBoxColumn.DataPropertyName = "Punti";
            this.puntiDataGridViewTextBoxColumn.HeaderText = "Punti";
            this.puntiDataGridViewTextBoxColumn.Name = "puntiDataGridViewTextBoxColumn";
            // 
            // differenzaRetiDataGridViewTextBoxColumn
            // 
            this.differenzaRetiDataGridViewTextBoxColumn.DataPropertyName = "DifferenzaReti";
            this.differenzaRetiDataGridViewTextBoxColumn.HeaderText = "DifferenzaReti";
            this.differenzaRetiDataGridViewTextBoxColumn.Name = "differenzaRetiDataGridViewTextBoxColumn";
            // 
            // squadreBindingSource
            // 
            this.squadreBindingSource.DataMember = "Squadre";
            this.squadreBindingSource.DataSource = this.campionatoDataSet;
            // 
            // campionatoDataSet1
            // 
            this.campionatoDataSet1.DataSetName = "CampionatoDataSet1";
            this.campionatoDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // squadreTableAdapter
            // 
            this.squadreTableAdapter.ClearBeforeFill = true;
            // 
            // campionatoDataSet
            // 
            this.campionatoDataSet.DataSetName = "CampionatoDataSet";
            this.campionatoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // squadreTableAdapter1
            // 
            this.squadreTableAdapter1.ClearBeforeFill = true;
            // 
            // frmGestioneSquadre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 345);
            this.Controls.Add(this.dataGridView1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.squadreBindingSource, "Squadra", true));
            this.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.squadreBindingSource, "Squadra", true));
            this.Name = "frmGestioneSquadre";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.squadreBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.campionatoDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.campionatoDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private CampionatoDataSet1 campionatoDataSet1;
        private System.Windows.Forms.BindingSource squadreBindingSource;
        private CampionatoDataSet1TableAdapters.SquadreTableAdapter squadreTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn squadraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn giocateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vinteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pareggiateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn perseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn golFattiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn golSubitiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn puntiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn differenzaRetiDataGridViewTextBoxColumn;
        private CampionatoDataSet campionatoDataSet;
        private CampionatoDataSetTableAdapters.SquadreTableAdapter squadreTableAdapter1;
    }
}