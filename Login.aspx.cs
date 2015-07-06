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

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string roles;
        string username = TextBox1.Text.Trim();
        if (DBHelper.CheckUser(username, TextBox2.Text.Trim()) == true)
        {
            //These session values are just for demo purpose to show the user details on master page
            Session["User"] = username;
            roles = DBHelper.GetUserRoles(username);
            Session["Roles"] = roles;

            //Let us now set the authentication cookie so that we can use that later.
            FormsAuthentication.SetAuthCookie(username, false);

            //Login successful lets put him to requested page
            string returnUrl = Request.QueryString["ReturnUrl"] as string;

            if (returnUrl != null)
            {
                Response.Redirect(returnUrl);
            }
            else
            {
                //no return URL specified so lets kick him to home page
                Response.Redirect("Default.aspx");
            }
        }
        else
        {
            Label1.Text = "Login Failed";
        }
    }
}
