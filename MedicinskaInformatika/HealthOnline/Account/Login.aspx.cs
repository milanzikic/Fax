using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Login : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterHyperLink.NavigateUrl = "Register.aspx";
        //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
        GwAllLogins.DataSource = new pgDBWorker().GetAllLogins();
        GwAllLogins.DataBind();
        var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        if (!String.IsNullOrEmpty(returnUrl))
        {
            RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
        }
    }

    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        String _username = UserName.Text.Trim();
        String _pass = Password.Text.Trim();

        pgDBWorker dbWorker = new pgDBWorker();
        DataSet ds = dbWorker.Login(_username, _pass);
        if (!ds.HasErrors)
        {
            DataTable dt = ds.Tables["DataSet"];
            if (dt.Rows.Count > 0)
            {
                FailureText.Text = dt.Rows[0]["Username"].ToString();
            }
            else
                FailureText.Text = "Wrong credentials!";
        }
        else
        {
            FailureText.Text = "Something went wrong. Try again.";
        }
    }
}