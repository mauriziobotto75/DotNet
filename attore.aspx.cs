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

public partial class attore : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int idatt = int.Parse(Request.QueryString["id"]);

        DataTable dt = GestioneDb.RecuperaDatiAttoreDaId(idatt);
        lblCognome.Text = (dt.Rows[0])[2].ToString();
        lblNome.Text = (dt.Rows[0])[1].ToString();
        lblData.Text = (dt.Rows[0])[3].ToString();
        grid_film.DataSource = GestioneDb.RecuperaFilmDaIdAttore(idatt);
        grid_film.DataBind();
    }
    protected void grid_film_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = int.Parse(grid_film.Rows[grid_film.SelectedIndex].Cells[1].Text);
        Response.Redirect("dettaglio_film.aspx?id=" + id);
    }
}
