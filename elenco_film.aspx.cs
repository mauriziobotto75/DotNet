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

public partial class elenco_film : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grid_film.DataSource = GestioneDb.RecuperaFilm();
        grid_film.DataBind();
        
        

    }
    protected void grid_film_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = int.Parse(grid_film.Rows[grid_film.SelectedIndex].Cells[1].Text);
        //string titolo = grid_film.Rows[grid_film.SelectedIndex].Cells[2].Text;
        //int anno = int.Parse(grid_film.Rows[grid_film.SelectedIndex].Cells[3].Text);
        Response.Redirect("dettaglio_film.aspx?id=" + id);
    }
}
