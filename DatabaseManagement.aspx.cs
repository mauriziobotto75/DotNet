 
Using System;
using System.Web.UI;

namespace GestioneFormazione
{
    public partial class DatabaseManagement : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void rblSezioni_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selezione = rblSezioni.SelectedValue;

switch (selezione)
            {
                case "Polo Formativo":
                    Response.Redirect("PoloFormativo.aspx");
                    break;
                case "Contatti":
                    Response.Redirect("Contatti.aspx");
                    break;
                case "Partners":
                    Response.Redirect("Partners.aspx");
                    break;
                case "Utenti":
                    Response.Redirect("Utenti.aspx");
                    break;
                case "Corsi":
                    Response.Redirect("Corsi.aspx");
                    break;
            }

        }
    }
}

