int id;

protected void Page_Load(object sender, EventArgs e)
{
    Auth.RequireDiritto("GEST_UTENTI");

    id = Request["id"] != null ? int.Parse(Request["id"]) : 0;

    if (!IsPostBack)
    {
        CaricaRuoli();

        if (id > 0)
            CaricaUtente();
    }
}

void CaricaRuoli()
{
    using (SqlConnection cn = Db.Conn())
    {
        SqlCommand cmd = new SqlCommand(
            "SELECT IdRuolo, NomeRuolo FROM RUOLI", cn);
        cn.Open();
        ddlRuolo.DataSource = cmd.ExecuteReader();
        ddlRuolo.DataValueField = "IdRuolo";
        ddlRuolo.DataTextField = "NomeRuolo";
        ddlRuolo.DataBind();
    }
}

void CaricaUtente()
{
    using (SqlConnection cn = Db.Conn())
    {
        SqlCommand cmd = new SqlCommand(
            "SELECT * FROM UTENTI WHERE IdUtente=@id", cn);
        cmd.Parameters.AddWithValue("@id", id);
        cn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            txtUser.Text = dr["Username"].ToString();
            chkAttivo.Checked = (bool)dr["Attivo"];
            ddlRuolo.SelectedValue = dr["IdRuolo"].ToString();
        }
    }
}

protected void btnSalva_Click(object sender, EventArgs e)
{
    using (SqlConnection cn = Db.Conn())
    {
        SqlCommand cmd;

        if (id == 0)
            cmd = new SqlCommand(
            "INSERT INTO UTENTI VALUES (@u,@p,@a,@r)", cn);
        else
        {
            cmd = new SqlCommand(
            @"UPDATE UTENTI SET Username=@u, Password=@p,
              Attivo=@a, IdRuolo=@r WHERE IdUtente=@id", cn);
            cmd.Parameters.AddWithValue("@id", id);
        }

        cmd.Parameters.AddWithValue("@u", txtUser.Text);
        cmd.Parameters.AddWithValue("@p", txtPwd.Text);
        cmd.Parameters.AddWithValue("@a", chkAttivo.Checked);
        cmd.Parameters.AddWithValue("@r", ddlRuolo.SelectedValue);

        cn.Open();
        cmd.ExecuteNonQuery();
    }

    Response.Redirect("Utenti.aspx");
}
