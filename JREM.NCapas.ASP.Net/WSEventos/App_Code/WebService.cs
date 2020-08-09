using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string InsertarServicio(double Karaoke, double Licores, double ValetParking, double Dj, double Payaso)
    {
        conn.Open();
        string Query = "InsServicio";
        SqlCommand cmd = new SqlCommand(Query, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Karaoke", Karaoke);
        cmd.Parameters.AddWithValue("@Licores", Licores);
        cmd.Parameters.AddWithValue("@ValetParking", ValetParking);
        cmd.Parameters.AddWithValue("@Dj", Dj);
        cmd.Parameters.AddWithValue("@Payaso", Payaso);
        cmd.ExecuteNonQuery();
        conn.Close();
        return "OK";
    }

}
