protected void cmdIscriviti_Click(
object sender,
EventArgs e)
{
    Response.Redirect(
    "Iscrizione.aspx?id=" +
    Request["id"]);
}
