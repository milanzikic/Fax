using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Member
/// </summary>
public class Member
{

#region properties

    public enum MemberTypes
    {
        User = 1,
        Admin = 2,
        Undefined = -1,
        God = 99
    };

    private int memberId;
    private MemberTypes memberType;
    private string memberName;
    private string memberSurname;
    private string memberUsername;
    private bool isLoggedIn;
    

    public int MemberId {
        get { return this.memberId; }
        set { this.memberId = value; }
    }

    public MemberTypes MemberType {
        get { return this.memberType; }
        set { this.memberType = value; }
    }

    public string MemberName {
        get { return this.memberName; }
        set { this.memberName = value; }
    }

    public string MemberSurname {
        get { return this.memberSurname; }
        set { this.memberSurname = value; }
    }

    public string MemberUsername {
        get { return this.memberUsername; }
        set { this.memberUsername = value; }
    }

    public bool IsLogggedIn {
        get { return this.isLoggedIn; }
        set { this.isLoggedIn = value; }
    }
#endregion

	public Member()
	{
		//
		// TODO: Add constructor logic here
		//
        MemberId = 0;
        MemberName = string.Empty;
        MemberSurname = string.Empty;
        MemberType = MemberTypes.Undefined;
        MemberUsername = string.Empty;
	}
    public Member(MemberTypes memberType) 
    {
        switch (memberType)
        {
            case MemberTypes.Admin:
                this.MemberType = MemberTypes.Admin;
                break;
            case MemberTypes.God:
                this.MemberType = MemberTypes.God;
                break;
            case MemberTypes.User:
                this.MemberType = MemberTypes.User;
                break;
        }    

    }
}