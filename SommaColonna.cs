
private void Form1_Load(object sender, EventArgs e)
{
//Caricamento dei dati
DataTable dttDati = new DataTable();
dttDati.Columns.AddRange(new DataColumn[3] {
new DataColumn("CodiceProdotto", typeof(int)),
new DataColumn("Descrizione", typeof(string)),
new DataColumn("Prezzo", typeof(int))
});
dttDati.Rows.Add(1, "Miele",   10);
dttDati.Rows.Add(2, "Acqua",   5);
dttDati.Rows.Add(3, "Pasta",   3);
dttDati.Rows.Add(4, "Pesce",  20000);
dttDati.Rows.Add(5, "Dolci",   12000);
int Totale = dttDati.AsEnumerable().Sum(row => row.Field<int>("Prezzo"));
int TotaleConFiltro = dttDati.AsEnumerable().Where(row => row.Field<int>("CodiceProdotto") < 4).Sum(row => row.Field<int>("Prezzo"));
//Aggiungo il totale al datatable
dttDati.Rows.Add(0, "Totale",   Totale);
dttDati.Rows.Add(0, "Totale 2",  TotaleConFiltro);
//Carico i dati
dataGridView1.DataSource = dttDati;
//formatto i totali
dataGridView1.Rows[dttDati.Rows.Count - 1].Cells[1].Style.ForeColor = Color.Blue;
dataGridView1.Rows[dttDati.Rows.Count - 1].Cells[1].Style.Font = new Font("Tahoma", 16, FontStyle.Bold);
dataGridView1.Rows[dttDati.Rows.Count - 2].Cells[1].Style.ForeColor = Color.Blue;
dataGridView1.Rows[dttDati.Rows.Count - 2].Cells[1].Style.Font = new Font("Tahoma", 16, FontStyle.Bold);
}
