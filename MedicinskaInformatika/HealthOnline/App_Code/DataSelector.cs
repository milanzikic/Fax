using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataSelector
/// </summary>
public class DataSelector
{
    #region properties



    #endregion
    
    public DataSelector()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Member LoginMember(string username, string password)
    {
        pgDBWorker dbWorker = new pgDBWorker();
        DataSet ds = dbWorker.Login(username, password);

        if (!ds.HasErrors)
        {
            Member LoggedMember = new Member();
            DataTable dt = ds.Tables["DataSet"];
            if (dt.Rows.Count > 0)
            {
                LoggedMember.MemberName = dt.Rows[0]["Username"].ToString();
                LoggedMember.MemberSurname = dt.Rows[0]["Username"].ToString();
                LoggedMember.MemberUsername = dt.Rows[0]["Username"].ToString();
                LoggedMember.IsLogggedIn = true;
                //return true;
            }
            else
            {
                LoggedMember.IsLogggedIn = false;
                //return false;
            }
            return LoggedMember;
        }
        else
        {
            throw new Exception("Error occured while try to log in");
        } 
    }
}