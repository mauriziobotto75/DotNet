
private void btnConto_Click(object sender, EventArgs e)
{
    int idComanda = _comanda.Id;

    FormConto frm = new FormConto(idComanda);
    frm.ShowDialog();
}
