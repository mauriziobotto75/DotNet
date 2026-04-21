using System.Configuration; 
using System.Data.SqlClient;
namespace PoloFormativo.Mvc.Infrastructure 
{ public static class Db 
{ public static SqlConnection Conn()
 { return new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
  } 
  }
  }