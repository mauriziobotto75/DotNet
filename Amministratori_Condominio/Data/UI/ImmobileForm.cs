csharp UI/ImmobileForm.cs
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyApp.Data;
using MyApp.Repositories;

namespace MyApp.UI
{
    public partial class ImmobileForm : Form
    {
        private readonly AppDbContext _db;
        private readonly GenericRepository<Immobile> _repo;

        public ImmobileForm(AppDbContext db)
        {
            InitializeComponent();
            _db = db;
            _repo = new GenericRepository<Immobile>(_db);
        }

        private async void ImmobileForm_Load(object sender, EventArgs e)
        {
            await LoadList();
        }

        private async Task LoadList()
        {
            var items = await _repo.GetAllAsync();
            listBoxImmobili.DataSource = items;
            listBoxImmobili.DisplayMember = "Indirizzo";
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var imm = new Immobile { Indirizzo = txtIndirizzo.Text, Note = txtNote.Text };
            await _repo.AddAsync(imm);
            await LoadList();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (listBoxImmobili.SelectedItem is Immobile sel)
            {
                sel.Indirizzo = txtIndirizzo.Text;
                sel.Note = txtNote.Text;
                await _repo.UpdateAsync(sel);
                await LoadList();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxImmobili.SelectedItem is Immobile sel)
            {
                await _repo.DeleteAsync(sel);
                await LoadList();
            }
        }
    }
}
