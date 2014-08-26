using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
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

        DataSelector dataSelector = new DataSelector();
        Member LoginMember = dataSelector.LoginMember(_username, _pass);
        try
        {
            if (LoginMember.IsLogggedIn)
            {
                FailureText.Text = "You are logged in!";
                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;
                tkt = new FormsAuthenticationTicket(1, _username, DateTime.Now,
                    DateTime.Now.AddMinutes(30), RememberMe.Checked, "your custom data");
                cookiestr = FormsAuthentication.Encrypt(tkt);
                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                if (RememberMe.Checked)
                    ck.Expires = tkt.Expiration;
                ck.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(ck);

                string strRedirect;
                strRedirect = Request["ReturnUrl"];
                if (strRedirect == null)
                    strRedirect = "/HealthOnline/Default.aspx";
                Response.Redirect(strRedirect, true);
            }
            else {
                FailureText.Text = "Wrong credentials!";
                //Response.Redirect("logon.aspx", true);
            }
        }
        catch(Exception ex) 
        {
            FailureText.Text = "Something went wrong. Try again.";
            //Response.Redirect("logon.aspx", true);
        }
        

        //pgDBWorker dbWorker = new pgDBWorker();
        //DataSet ds = dbWorker.Login(_username, _pass);
        //if (!ds.HasErrors)
        //{
        //    DataTable dt = ds.Tables["DataSet"];
        //    if (dt.Rows.Count > 0)
        //    {
        //        FailureText.Text = dt.Rows[0]["Username"].ToString();
        //    }
        //    else
        //        FailureText.Text = "Wrong credentials!";
        //}
        //else
        //{
        //    FailureText.Text = "Something went wrong. Try again.";
        //}
        
    }
}