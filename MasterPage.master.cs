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

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string user = Session["User"] as string;
        string roles = Session["Roles"] as string;

        if (user != null)
        {
            Label1.Text = user;
            LinkButton1.Text = "Logout";
        }
        else
        {
            Label1.Text = "guest";
            LinkButton1.Text = "Login";
        }

        if (roles != null)
        {
            Label2.Text = roles;
        }
        else
        {
            Label2.Text = "guest";
        }
    }

    public void UpdateMasterPageData()
    {

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string user = Session["User"] as string;
        string roles = Session["Roles"] as string;

        if (user != null)
        {
            //Lets sign out and make the authentication ticket invalid
            FormsAuthentication.SignOut();

            //lets remove our session variables to let the user knoe he has been kicked out
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
        else
        {   
            Response.Redirect("Login.aspx");
        }

        
    }
}
