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

public partial class inserisci_film : System.Web.UI.Page
{
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
       dt  = GestioneDb.RecuperaAttori();

        foreach (DataRow var in dt.Rows)
        {
            list_attori.Items.Add(var[2].ToString() + " " +var[1].ToString());
            Session[var[1].ToString() + var[2].ToString()] = var[0].ToString();   
                
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        int idfilm = GestioneDb.InserisciFilm(txttitolo.Text.ToString(),Convert.ToInt32(txtanno.Text));
        for (int i = 0; i < list_attori.Items.Count; i++)
        {
            if (list_attori.Items[i].Selected)
            {

                GestioneDb.InserisciCross(idfilm, int.Parse(Session[(dt.Rows[i])[1].ToString() + (dt.Rows[i])[2].ToString()].ToString()));

            }

        }
    }
}
