protected void Page_Load(object sender, EventArgs e)
{
    Auth.RequireDiritto("GEST_PERSONE");

    if (!IsPostBack)
    {
        using (SqlConnection cn = Db.Conn())
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT IdPersona, Nome, Cognome FROM Persone", cn);
            cn.Open();
            gv.DataSource = cmd.ExecuteReader();
            gv.DataBind();
        }
    }
}
