using System.Web; using System.Data.SqlClient;
namespace PoloFormativo.Mvc.Infrastructure 
{ public static class AuditService 
{ public static void Log(string a,string e,string k)
{ if(HttpContext.Current.Session["IdUtente"]==null) return;
 using(SqlConnection cn=Db.Conn())
 { SqlCommand cmd=new SqlCommand("INSERT INTO AUDIT_LOG (IdUtente,DataOra,Azione,Entita,ChiaveEntita,Pagina,IndirizzoIP) 
 VALUES (@u,GETDATE(),@a,@e,@k,@p,@ip)",cn); 
 cmd.Parameters.AddWithValue("@u",HttpContext.Current.Session["IdUtente"]); 
 cmd.Parameters.AddWithValue("@a",a); 
 cmd.Parameters.AddWithValue("@e",e);
  cmd.Parameters.AddWithValue("@k",k); 
  cmd.Parameters.AddWithValue("@p",HttpContext.Current.Request.RawUrl); 
  cmd.Parameters.AddWithValue("@ip",HttpContext.Current.Request.UserHostAddress); 
  cn.Open(); cmd.ExecuteNonQuery();
   }
   }
   }
   }