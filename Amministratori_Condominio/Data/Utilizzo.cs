// Nel form principale oppure dove vuoi aprire la form dei consumi
private void ApriFrmConsumiContatore()
{
    string connectionString = ConfigurationManager.ConnectionStrings["AmministratoriDB"].ConnectionString;
    int idCondominio = 1; // ID del condominio
    int idContatore = 5;  // ID del contatore

    FrmConsumiContatore frmConsumi = new FrmConsumiContatore(connectionString, idCondominio, idContatore);
    frmConsumi.ShowDialog();
}
