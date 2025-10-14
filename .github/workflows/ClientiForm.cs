
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RistoranteWinForms
{
    public partial class ClientiForm : Form
    {
        public ClientiForm()
        {
            InitializeComponent();
        }

        private void ClientiForm_Load(object sender, EventArgs e)
        {
            CaricaClienti();
        }

        private void CaricaClienti()
        {
            using (var db = new RistoranteEntities())
            {
                var clienti = db.Clienti
                    .Select(c => new {
                        c.ClienteID,
                        c.Nome,
                        c.Telefono,
                        c.Email
                    }).ToList();

                dataGridView1.DataSource = clienti;
            }
        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            using (var db = new RistoranteEntities())
            {
                var nuovo = new Clienti
                {
                    Nome = "Nuovo Cliente",
                    Telefono = "0000000000",
                    Email = "email@example.com"
                };
                db.Clienti.Add(nuovo);
                db.SaveChanges();
            }
            CaricaClienti();
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funzione di modifica non ancora implementata.");
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["ClienteID"].Value;
                using (var db = new RistoranteEntities())
                {
                    var cliente = db.Clienti.Find(id);
                    if (cliente != null)
                    {
                        db.Clienti.Remove(cliente);
                        db.SaveChanges();
                    }
                }
                CaricaClienti();
            }
        }
    }
}
