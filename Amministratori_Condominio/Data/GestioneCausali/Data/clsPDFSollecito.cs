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
