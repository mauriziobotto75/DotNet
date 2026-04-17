protected void btn_Click(object sender, EventArgs e)
{
    using (SqlConnection cn = Db.Conn())
    {
        SqlCommand cmd = new SqlCommand(
        "SELECT IdUtente FROM UTENTI WHERE Username=@u AND Password=@p", cn);
        cmd.Parameters.AddWithValue("@u", txtUser.Text);
        cmd.Parameters.AddWithValue("@p", txtPwd.Text);
        cn.Open();
        object id = cmd.ExecuteScalar();

        if (id != null)
        {
            Session["utente"] = id;
            Response.Redirect("~/Default.aspx");
        }
    }
}
