﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;

public partial class Account_Register : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
    }

    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
        //FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);

        //string continueUrl = RegisterUser.ContinueDestinationPageUrl;
        //if (!OpenAuth.IsLocalUrl(continueUrl))
        //{
        //    continueUrl = "~/";
        //}
        //Response.Redirect(continueUrl);
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        pgDBWorker dbWorker = new pgDBWorker();
        dbWorker.Register(1234, "2706986730092","milan", "1234567", "zikic.milan@gmail.com", "123456", "123456");
    }
}