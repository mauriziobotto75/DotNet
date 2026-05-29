private void EliminaRiga()
{
    if (dgvComanda.CurrentRow == null) return;

    int index = dgvComanda.CurrentRow.Index;
    _comandaCorrente.Dettagli.RemoveAt(index);

    RefreshGrid();
    AggiornaTotale();
}
``
