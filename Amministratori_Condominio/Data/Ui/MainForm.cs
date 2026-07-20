csharp UI/MainForm.cs
using System;
using System.Windows.Forms;
using MyApp.Data;

namespace MyApp.UI
{
    public partial class MainForm : Form
    {
        private readonly AppDbContext _db = new AppDbContext();

        public MainForm()
        {
            InitializeComponent();
            // build menu/buttons: Immobili, Spese, Contatti, Bollette, Agenda, Parcelle, Solleciti
        }

        private void btnImmobili_Click(object sender, EventArgs e)
        {
            var f = new ImmobileForm(_db);
            f.ShowDialog();
        }

        // add handlers for other forms similarly
    }
}
