 int id;

protected void Page_Load(object sender, EventArgs e)
{
    Auth.RequireDiritto("ADMIN_PANEL");
    id = Request["id"] != null ? int.Parse(Request["id"]) : 0;

    if (!IsPostBack && id > 0)
    {
        using (SqlConnection cn = Db.Conn())
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT NomeRuolo FROM Ruoli WHERE IdRuolo=@id", cn);
            cmd.Parameters.AddWithValue("@id", id);
            cn.Open();
            txtNome.Text = cmd.ExecuteScalar().ToString();
        }
    }
}

protected void btn_Click(object sender, EventArgs e)
{
    using (SqlConnection cn = Db.Conn())
    {
        SqlCommand cmd;

        if (id == 0)
            cmd = new SqlCommand(
                "INSERT INTO Ruoli (NomeRuolo) VALUES (@n)", cn);
        else
        {
            cmd = new SqlCommand(
                "UPDATE Ruoli SET NomeRuolo=@n WHERE IdRuolo=@id", cn);
            cmd.Parameters.AddWithValue("@id", id);
        }

        cmd.Parameters.AddWithValue("@n", txtNome.Text);
        cn.Open();
        cmd.ExecuteNonQuery();
    }

    Response.Redirect("Ruoli.aspx");
}
