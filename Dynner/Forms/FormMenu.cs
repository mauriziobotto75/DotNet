public event Action<Prodotti> OnProdottoSelezionato;
private void btnProdotto_Click(object sender, EventArgs e)
{
    var prodotto = (Prodotti)((Button)sender).Tag;

    OnProdottoSelezionato?.Invoke(prodotto);
}
