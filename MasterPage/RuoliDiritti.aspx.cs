 int idRuolo;

protected void Page_Load(object sender, EventArgs e)
{
    Auth.RequireDiritto("ADMIN_PANEL");

    idRuolo = int.Parse(Request["id"]);

    if (!IsPostBack)
    {
        CaricaDiritti();
        CaricaDirittiRuolo();
    }
}

void CaricaDiritti()
{
    using (SqlConnection cn = Db.Conn())
    {
        SqlCommand cmd = new SqlCommand(
            "SELECT IdDiritto, Descrizione FROM DIRITTI", cn);
        cn.Open();
        chkDiritti.DataSource = cmd.ExecuteReader();
        chkDiritti.DataBind();
    }
}

void CaricaDirittiRuolo()
{
    using (SqlConnection cn = Db.Conn())
    {
        SqlCommand cmd = new SqlCommand(
            "SELECT IdDiritto FROM RUOLI_DIRITTI WHERE IdRuolo=@r", cn);
        cmd.Parameters.AddWithValue("@r", idRuolo);
        cn.Open();

        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ListItem item = chkDiritti.Items.FindByValue(
                dr["IdDiritto"].ToString());
            if (item != null) item.Selected = true;
        }
    }
}

protected void btnSalva_Click(object sender, EventArgs e)
{
    using (SqlConnection cn = Db.Conn())
    {
        cn.Open();

        SqlCommand del = new SqlCommand(
            "DELETE FROM RUOLI_DIRITTI WHERE IdRuolo=@r", cn);
        del.Parameters.AddWithValue("@r", idRuolo);
        del.ExecuteNonQuery();

        foreach (ListItem item in chkDiritti.Items)
        {
            if (item.Selected)
            {
                SqlCommand ins = new SqlCommand(
                "INSERT INTO RUOLI_DIRITTI VALUES (@r,@d)", cn);
                ins.Parameters.AddWithValue("@r", idRuolo);
                ins.Parameters.AddWithValue("@d", item.Value);
                ins.ExecuteNonQuery();
            }
        }
    }
}
