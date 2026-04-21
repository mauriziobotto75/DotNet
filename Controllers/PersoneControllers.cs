using System.Collections.Generic; 
using System.Web.Mvc; 
using System.Data.SqlClient; 
using PoloFormativo.Mvc.Infrastructure;
public class PersoneController:Controller{ [RequireDiritto("GEST_PERSONE")] 
public ActionResult Index()
{var l=new List<dynamic>(); 
using(SqlConnection cn=Db.Conn())
{ SqlCommand cmd=new SqlCommand("SELECT IdPersona,Nome,Cognome FROM Persone",cn);
 cn.Open(); 
 var dr=cmd.ExecuteReader(); 
 while(dr.Read())
  l.Add(new{IdPersona=dr[0],
  Nome=dr[1],Cognome=dr[2]}); 
  } 
  return View(l);} 
  }
