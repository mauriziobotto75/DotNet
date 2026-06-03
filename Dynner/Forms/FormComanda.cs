 using System;
using System.Linq;
using System.Windows.Forms;

namespace RistorazionePOS
{
    public partial class FormComanda : Form
    {
        private RistorazioneEntities _db;
        private Comande _comanda;
        private ComandaService _service;

        public FormComanda()
        {
            InitializeComponent();

            _db = new RistorazioneEntities();
            _service = new ComandaService(_db);
        }

        private void FormComanda_Load(object sender, EventArgs e)
        {
            _comanda = _service.CreaNuova();

            CaricaProdotti();
        }

        private void CaricaProdotti()
        {
            var prodotti = _db.Prodotti.ToList();

            flowLayoutPanel1.Controls.Clear();

            foreach (var p in prodotti)
            {
                var btn = new Button
                {
                    Text = p.Nome,
                    Width = 120,
                    Height = 60
                };

                btn.Click += (s, ev) =>
                {
                    _service.AggiungiProdotto(_comanda, p);
                    RefreshGrid();
                };

                flowLayoutPanel1.Controls.Add(btn);
            }
        }

        private void RefreshGrid()
        {
            dgv.DataSource = null;

            dgv.DataSource = _comanda.Comande_Dettaglio
                .Select(d => new
                {
                    Qta = d.Quantita,
                    Nome = d.Prodotti.Nome,
                    Prezzo = d.Prezzo,
                    Importo = d.Importo
                }).ToList();
        }

        private void btnConto_Click(object sender, EventArgs e)
        {
            new FormConto(_comanda.Id).ShowDialog();
        }
    }
}
