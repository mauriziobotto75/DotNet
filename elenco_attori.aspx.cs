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

public partial class elenco_attori : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grid_elenco_attori.DataSource = GestioneDb.RecuperaAttori();
        grid_elenco_attori.DataBind();
    }
    protected void grid_elenco_attori_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = int.Parse(grid_elenco_attori.Rows[grid_elenco_attori.SelectedIndex].Cells[1].Text);
        Response.Redirect("attore.aspx?id="+id);
    }
}
