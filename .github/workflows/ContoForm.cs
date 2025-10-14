
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RistoranteWinForms
{
    public partial class ContoForm : Form
    {
        public ContoForm()
        {
            InitializeComponent();
        }

        private void ContoForm_Load(object sender, EventArgs e)
        {
            using (var db = new RistoranteEntities())
            {
                var conti = db.Conto
                    .Select(c => new {
                        c.ContoID,
                        Cliente = c.Commande.Clienti.Nome,
                        Tavolo = c.Commande.Tavoli.NumeroTavolo,
                        c.Totale,
                        c.Pagato
                    }).ToList();

                dataGridView1.DataSource = conti;
            }
        }

        private void btnStampa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funzione di stampa non ancora implementata.");
        }

        private void btnChiudi_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
