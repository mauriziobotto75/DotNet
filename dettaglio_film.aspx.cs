using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class dettaglio_film : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Lbltitolo.Text = Request.QueryString["titolo"];
        //lblanno.Text = Request.QueryString["anno"];
        int idfilm = int.Parse(Request.QueryString["id"]);

        DataTable dt = GestioneDb.RecuperaFilm(idfilm);
        //Label2.Text = (dt.Rows[0])[1].ToString() + " anno " + (dt.Rows[0])[2].ToString();
        Lbltitolo.Text = (dt.Rows[0])[1].ToString();
        lblanno.Text = (dt.Rows[0])[2].ToString();
        grid_attori.DataSource = GestioneDb.RecuperaAttoreDaFilm(idfilm);
        grid_attori.DataBind();
    }

    protected void grid_attori_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = int.Parse(grid_attori.Rows[grid_attori.SelectedIndex].Cells[1].Text);
        Response.Redirect("attore.aspx?id=" + id);

    }
}
