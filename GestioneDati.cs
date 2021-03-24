using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.SqlTypes;
using System.Windows.Forms;
using System.IO;
using System.Data.Sql;

//class GestioneDati
//    {
//        SqlConnection conn;
//
//        public GestioneDati()
//        {
//            string connString = @"Data Source=Maurizio-B1163e\sqlexpress2005;Initial Catalog=DbFilm;Integrated Security=True";
//            conn = new SqlConnection(connString);
 // 
// }

 //        public  List<string> RecuperaAttori()
  //       {
  //           string queryString = "SELECT NomeAttore + ' '+ CognomeAttore AS 'Nome', " +
  //               "DataNascitaAttore as 'DataNascita', IsAlive as 'Stato' " +
  //               "FROM dbo.tbAttori";
  //           SqlCommand cmd = new SqlCommand(queryString,conn);
   //          SqlDataReader dr;
  //           List<string> listaAttori = new List<string>();

  //           try
  //           {
  //               conn.Open();
   //              dr = cmd.ExecuteReader();

   //              while (dr.Read())
   //              {
   //                  StringBuilder sb = new StringBuilder();
   //                  sb.Append(dr["Nome"].ToString() + ", ");
   //                  DateTime data = DateTime.parse(dr[1]);
   //                  sb.Append(data.ToShortDateString()+ ", ");
   //                  bool vivo = Convert.ToBoolean(dr[2]);
   //                  if (vivo)
    //                     sb.Append("VIVENTE");
   //                  else
     //                    sb.Append("DECEDUTO");
    //                 string mioAttore = sb.ToString();
    //                 listaAttori.Add(mioAttore);
   //              }

    //             dr.Close();

    //         }
    //         catch(Exception ex)
    //         {
   //              string errore = String.Format("Errore inaspettato: {0}",ex.Message);
    //             listaAttori.Add(errore);
    //         }
    //         finally
     //        {
     //            conn.Close();
     //        }

    //         return listaAttori;
   //      }

    //     public int? NumeroAttori
    //     {
    //         get
     //        {
   //             string queryString = "SELECT COUNT(*) FROM dbo.tbAttori";
    //            SqlCommand cmd = new SqlCommand(queryString, conn);
                
    //            int? num;

  //              try
   //             {
    //                conn.Open();

     //               num= (int)cmd.ExecuteScalar();
     //           }
     //           catch
      //          {
       //             num = null;
       //         }
       //         finally
        //        {
        //            conn.Close();
        //        }

        //        return num;
        //    }
        //}

        //public string RecuperaAttoreById(int id)
        //{
        //    string queryString = "SELECT NomeAttore + ' '+ CognomeAttore AS 'Nome', " +
         //       "DataNascitaAttore as 'DataNascita', IsAlive as 'Stato' " +
         //       "FROM dbo.tbAttori WHERE idAttore = @Id";
         //   SqlCommand cmd = new SqlCommand(queryString, conn);
         //   SqlDataReader dr;
         //   string dettaglioAttore="";

        //    SqlParameter par0 = new SqlParameter("@Id", SqlDbType.Int);
        //    par0.Value = id;
         //   cmd.Parameters.Add(par0);

         //   try
         //   {
         //       conn.Open();
          //      dr = cmd.ExecuteReader();

         //       while (dr.Read())
          //      {
           //         StringBuilder sb = new StringBuilder();
           //         sb.Append(dr["Nome"].ToString() + ", ");
          //          DateTime data = (DateTime)dr[1];
          //          sb.Append(data.ToShortDateString() + ", ");
           //         bool vivo = Convert.ToBoolean(dr[2]);
           //         if (vivo)
           //             sb.Append("VIVENTE");
           //         else
             //           sb.Append("DECEDUTO");
            //        string mioAttore = sb.ToString();
            //        dettaglioAttore += mioAttore;
            //    }

            //    dr.Close();

         //   }
          //  catch (Exception ex)
         //   {
         //       string errore = String.Format("Errore inaspettato: {0}", ex.Message);
         //       dettaglioAttore=errore;
         //   }
         //   finally
         //   {
         //       conn.Close();
         //   }

         //   return dettaglioAttore;
      //  }

      //  public string RecuperaAttoreConStoreProcedure(int id)
      //  {
      //      string queryString = "GetDettaglioAttore";
      //      SqlCommand cmd = new SqlCommand(queryString, conn);
       //     cmd.CommandType = CommandType.StoredProcedure;

       //     SqlParameter parId = new SqlParameter("@id", SqlDbType.Int);
      //      parId.Value = id;
       //     parId.Direction = ParameterDirection.Input;

       //     cmd.Parameters.Add(parId);

       //     SqlParameter ritorno = new SqlParameter();
       //     ritorno.Direction = ParameterDirection.ReturnValue;

       //     cmd.Parameters.Add(ritorno);

       //     string dettAttore = "";
       //     SqlDataReader dr;

        //    try
       //     {
        //        conn.Open();
        //        dr = cmd.ExecuteReader();

        //        int valoreRitorno = Convert.ToInt32(ritorno.Value);
         //       while (dr.Read())
         //       {
         //           try
           //         {
           //             dettAttore += dr["Nome"].ToString() + ", ";
           //             DateTime dt = (DateTime)dr[1];
            //            dettAttore += dt.ToShortDateString() + ", ";
            //            bool vivo = (bool)dr[2];
            //            if (vivo)
            //            {
            //                dettAttore += "VIVO";
             //           }
             //           else
             //           {
             //               dettAttore += "DECEDUTO";
             //           }
              //      }
              //      catch
              //      {
              //          try
               //         {
               //             dettAttore += dr[0].ToString();
               
               //           }
               //         catch
                //        {
               //             dettAttore = "Errore inaspettato";
               //         }
                //    }
                    //if (valoreRitorno == 1)
                    //{
                    //    dettAttore += dr["Nome"].ToString() + ", ";
                    //    DateTime dt = (DateTime)dr[1];
                    //    dettAttore += dt.ToShortDateString() + ", ";
                    //    bool vivo = (bool)dr[2];
                    //    if (vivo)
                    //    {
                    //        dettAttore += "VIVO";
                    //    }
                    //    else
                    //    {
                    //        dettAttore += "DECEDUTO";
                    //    }
                    //}
                    //else if (valoreRitorno == -1)
                    //{
                    //    dettAttore += dr[0].ToString();
                    //}
           //     }
          //  }
          //  catch
          //  {
           //     dettAttore = "C'e' stato un problema....";
           // }
          //  finally
          //  {
          //      conn.Close();
          //  }

         //   return dettAttore;
      //  }

    //    public bool InserisciAttore(string nome, string cognome, 
     //       DateTime dataNascita, bool vivo, out int? idNuovo)
     //   {
     //       string queryString = "InserisciAttore";
     //       SqlCommand cmd = new SqlCommand(queryString, conn);
     //       cmd.CommandType = CommandType.StoredProcedure;

      //      SqlParameter par0 = new SqlParameter("@nome", SqlDbType.NVarChar, 100);
      //      par0.Value = nome;

       //     SqlParameter par1 = new SqlParameter("@cognome", SqlDbType.NVarChar, 100);
        //    par1.Value = cognome;

       //     SqlParameter par2 = new SqlParameter("@dataNascita", SqlDbType.DateTime);
       //     par2.Value = dataNascita;

       //     SqlParameter par3 = new SqlParameter("@isAlive", SqlDbType.Bit);
       //     par3.Value = vivo;

       //     SqlParameter newId = new SqlParameter("@idAssegnato", SqlDbType.Int);
       //     newId.Direction = ParameterDirection.Output;

       //     SqlParameter rit = new SqlParameter();
       //     rit.Direction = ParameterDirection.ReturnValue;

       //     cmd.Parameters.Add(par0);
       //     cmd.Parameters.Add(par1);
       //     cmd.Parameters.Add(par2);
       //     cmd.Parameters.Add(par3);
       //     cmd.Parameters.Add(rit);
//    cmd.Parameters.Add(newId);

       //     idNuovo = null;
       //     bool tuttoBene = false;
       //     try
       //     {
       //         conn.Open();

       //         cmd.ExecuteNonQuery();

     //           int ritorno = Convert.ToInt32(rit.Value);

     //           if (ritorno == 1)
      //          {
     //               idNuovo = Convert.ToInt32(newId.Value);
        //            tuttoBene = true;
        //        }
      //      }
     //       catch
    //        {

    //        }
    //        finally
    //        {
    //            conn.Close();
    //        }

    //        return tuttoBene;
   //     }
//    }
 

