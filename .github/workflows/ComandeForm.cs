
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RistoranteWinForms
{
    public partial class ComandeForm : Form
    {
        public ComandeForm()
        {
            InitializeComponent();
        }

        private void ComandeForm_Load(object sender, EventArgs e)
        {
            using (var db = new RistoranteEntities())
            {
                var comande = db.Commande
                    .Select(c => new {
                        c.ComandaID,
                        Cliente = c.Clienti.Nome,
                        Tavolo = c.Tavoli.NumeroTavolo,
                        Sala = c.Tavoli.Sala.NomeSala,
                        c.DataOra
                    }).ToList();

                dataGridView1.DataSource = comande;
            }
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ordine confermato.");
        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funzione di aggiunta piatto non ancora implementata.");
        }

        private void btnRimuovi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funzione di rimozione piatto non ancora implementata.");
        }
    }
}
