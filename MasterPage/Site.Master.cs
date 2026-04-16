protected void Page_Load(object sender, EventArgs e)
{
    if (Session["IdUtente"] == null)
        Response.Redirect("~/Login.aspx");

    lblUser.Text = Session["Username"].ToString();

    if (!Auth.HasDiritto("GEST_UTENTI"))
        menu.Items[2].Enabled = false;

    if (!Auth.HasDiritto("GEST_RUOLI"))
        menu.Items[3].Enabled = false;

    if (!Auth.HasDiritto("GEST_DIRITTI"))
        menu.Items[4].Enabled = false;
}

protected void Logout_Click(object sender, EventArgs e)
{
    Audit.Log("LOGOUT", "UTENTI", Session["IdUtente"].ToString());
    Session.Clear();
    Session.Abandon();
    Response.Redirect("~/Login.aspx");
}
