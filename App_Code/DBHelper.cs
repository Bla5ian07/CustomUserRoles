using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DBHelper
/// </summary>
public class DBHelper
{
    public static bool CheckUser(string username, string password)
    {
        DataTable result = null;
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["userDbConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select password from Users where username = @uname";
                    cmd.Parameters.Add(new SqlParameter("@uname", username));

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        result = new DataTable();
                        da.Fill(result);
                    }

                    if (password.Trim() == result.Rows[0]["password"].ToString().Trim())
                    {
                        //user id found and password is matched too so lets do soemthing now
                        return true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //Pokemon exception handling
        }

        //user id not found, lets treat him as a guest        
        return false;
    }


    public static string GetUserRoles(string username)
    {
        DataTable result = null;
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["userDbConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select roles from Users where username = @uname";
                    cmd.Parameters.Add(new SqlParameter("@uname", username));

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        result = new DataTable();
                        da.Fill(result);
                    }

                    if(result.Rows.Count == 1)
                    {
                        return result.Rows[0]["roles"].ToString().Trim();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //Pokemon exception handling
        }

        //user id not found, lets treat him as a guest        
        return "guest";
    }
}
