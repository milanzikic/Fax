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

    enum MemberTypes
    {
        User = 1,
        Admin = 2,
        God = 99
    };

    private int memberId;
    private int memberType;
    private string memberName;
    private string memberSurname;
    private string memberUsername;
    

    protected int MemberId {
        get { return this.memberId; }
        set { this.memberId = value; }
    }

    protected int MemberType {
        get { return this.memberType; }
        set { this.memberType = value; }
    }

    protected string MemberName {
        get { return this.memberName; }
        set { this.memberName = value; }
    }

    protected string MemberSurname {
        get { return this.memberSurname; }
        set { this.memberSurname = value; }
    }

    protected string MemberUsername {
        get { return this.memberUsername; }
        set { this.memberUsername = value; }
    }
#endregion

	public Member()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public Member(int memberType) 
    {
        //switch(memberType){
        //    case MemberTypes.User: this.MemberType = MemberTypes.User;
        //}    

    }
}