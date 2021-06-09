using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Web.Extensions.Util; 
using System.Xml;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using System.Text;  
using Lezione5.BObjects; 

namespace Lezione5
{
    public partial class Default2 : System.Web.UI.Page
    {
        public List<Prodotto> lc;
        public string lcSerialized;
        public List<Prodotto> lb;
        public string lbSerialized;
        public string jsonLC;
        public string jsonLB;
        public List<RigaOrdine> lro;
        protected void Page_Load(object sender, EventArgs e)
        {
            int a = 5; 
            if (!IsPostBack)
            {
                // 1^ caricamento  ...... 
                ProdottiCucina.caricaProdotti();
                lc = ProdottiCucina.getListaProdotti(); 
                lcSerialized = ProdottiCucina.getListaProdottiSerialized();
                jsonLC = ProdottiCucina.getJSONList(); 
                
                ProdottiBar.caricaProdotti();
                lb = ProdottiBar.getListaProdotti();
                lbSerialized = ProdottiBar.getListaProdottiSerialized();
                jsonLB = ProdottiBar.getJSONList(); 

                lro = new List<RigaOrdine>();
                DBHelper.DBHandler.setConnectionString(); 
            }
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void accettaOrdine(string tavolo, string tipo, string prodotto, string quantita, string costoUnitario)
        {
            /*
             *     this.jsonData = "{ tavolo: '" + this.tavolo +
                       "', tipo: '" + this.tipo +
                       "', prodotto: '" + this.prodotto +
                       "', quantita: '" + this.quantita +
                       "', costoUnitario: '" + this.costoUnitario + "'}"; 
             */
            try
            {
                RigaOrdine ro = new RigaOrdine(); 
                ro.tavolo = tavolo;
                ro.tipo = tipo; 
                ro.prodotto = prodotto; 
                ro.quantita = quantita; 
                ro.costoUnitario = costoUnitario; 
                ro.stato = "A";
                lro.Add(ro); 
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}