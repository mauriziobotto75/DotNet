using System.Web;
 using System.Data.SqlClient;
namespace PoloFormativo.Mvc.Infrastructure 
{ public static class AuthService 
{ public static bool HasDiritto(string c)
{ if(HttpContext.Current.Session["IdRuolo"]==null)
 return false; 
 using(SqlConnection cn=Db.Conn())
 { 
    SqlCommand cmd=new SqlCommand("SELECT COUNT(*) 
    FROM Ruoli_Diritti RD JOIN DIRITTI D ON RD.IdDiritto=D.IdDiritto WHERE RD.IdRuolo=@r AND D.Codice=@c",cn); 
    cmd.Parameters.AddWithValue("@r",HttpContext.Current.Session["IdRuolo"]);
     cmd.Parameters.AddWithValue("@c",c);
      cn.Open();
       return (int)cmd.ExecuteScalar()>0; 
      }
      }
      }
      }