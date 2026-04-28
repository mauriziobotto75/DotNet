using System.Data.SqlClient;

protected void Page_Load(object sender, EventArgs e)
{
    if (!IsPostBack)
    {
        hidId.Value = Request.QueryString["id"];
        CaricaCorso();
    }
}

private void CaricaCorso()
{
    using (SqlConnection cn = Db.Conn())
    {
        SqlCommand cmd = new SqlCommand(
            "SELECT * FROM CORSI WHERE id=@id", cn);
        cmd.Parameters.AddWithValue("@id", hidId.Value);

        cn.Open();
        SqlDataReader r = cmd.ExecuteReader();
        if (r.Read())
        {
            txtTitolo.Text = r["titolo"].ToString();
            txtDescrizione.Text = r["descrizione"].ToString();
            txtDurata.Text = r["durata_ore"].ToString();
            txtProgramma.Text = r["Programma"].ToString();
            txtFormatori.Text = r["Formatori"].ToString();
            txtInizio.Text = Convert.ToDateTime(r["Data_inizio_iscrizioni"]).ToString("yyyy-MM-dd");
            txtFine.Text = Convert.ToDateTime(r["Data_fine_iscrizioni"]).ToString("yyyy-MM-dd");
        }
    }
}

protected void btnSalva_Click(object sender, EventArgs e)
{
    using (SqlConnection cn = Db.Conn())
    {
        SqlCommand cmd = new SqlCommand(@"
            UPDATE CORSI SET
                titolo = @titolo,
                descrizione = @descrizione,
                durata_ore = @durata,
                Programma = @programma,
                Formatori = @formatori,
                Data_inizio_iscrizioni = @inizio,
                Data_fine_iscrizioni = @fine
            WHERE id = @id", cn);

        cmd.Parameters.AddWithValue("@titolo", txtTitolo.Text);
        cmd.Parameters.AddWithValue("@descrizione", txtDescrizione.Text);
        cmd.Parameters.AddWithValue("@durata", int.Parse(txtDurata.Text));
        cmd.Parameters.AddWithValue("@programma", txtProgramma.Text);
        cmd.Parameters.AddWithValue("@formatori", txtFormatori.Text);
        cmd.Parameters.AddWithValue("@inizio", DateTime.Parse(txtInizio.Text));
        cmd.Parameters.AddWithValue("@fine", DateTime.Parse(txtFine.Text));
        cmd.Parameters.AddWithValue("@id", hidId.Value);

        cn.Open();
        cmd.ExecuteNonQuery();
    }

    Response.Redirect("Corsi.aspx");
}
