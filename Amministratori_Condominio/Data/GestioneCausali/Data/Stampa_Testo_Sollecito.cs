private void btnGenera_Click(
    object sender,
    EventArgs e)
{
    decimal importo =
        Convert.ToDecimal(
            txtImporto.Text);

    string testo =
@"OGGETTO : SOLLECITO DI PAGAMENTO

Spett.le " +
txtDestinatario.Text +

@",

da una verifica contabile
risulta uno scoperto ad oggi
pari ad Euro "
+
importo.ToString("N2")

+
@".

La preghiamo pertanto
di provvedere con cortese
sollecitudine al saldo.

Distinti saluti.

L'Amministratore";

    rtfTesto.Text = testo;
}
private void btnPDF_Click(
    object sender,
    EventArgs e)
{
    SaveFileDialog dlg =
        new SaveFileDialog();

    dlg.Filter =
        "File PDF (*.pdf)|*.pdf";

    dlg.FileName =
        "Sollecito_" +
        _idRata +
        ".pdf";

    if(dlg.ShowDialog()
       == DialogResult.OK)
    {
        PdfSollecito.GeneraPDF(
            dlg.FileName,
            txtDestinatario.Text,
            txtIndirizzo.Text,
            Convert.ToDecimal(
                txtImporto.Text),
            rtfTesto.Text);

        MessageBox.Show(
            "PDF generato correttamente.");
    }
}
