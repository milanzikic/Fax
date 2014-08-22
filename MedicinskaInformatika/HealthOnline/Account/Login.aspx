<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" %>
<%--<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>--%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>
    
    <section id="loginForm">
        <h2>Ulogujte se.</h2>
        <asp:Panel ID="PnlLogin" runat="server">
        <%--<asp:LoginView ID="LoginView" runat="server">
            <AnonymousTemplate>
                <asp:Login runat="server" ID="LoginUser" ViewStateMode="Disabled" RenderOuterTable="false">
            <LayoutTemplate>--%>
                <p class="validation-summary-errors">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
                <fieldset>
                    <legend>Log in Form</legend>
                    <ol>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="UserName">User name</asp:Label>
                            <asp:TextBox runat="server" ID="UserName" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="field-validation-error" ErrorMessage="The user name field is required." />
                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="The password field is required." />
                        </li>
                        <li>
                            <asp:CheckBox runat="server" ID="RememberMe" />
                            <asp:Label runat="server" AssociatedControlID="RememberMe" CssClass="checkbox">Remember me?</asp:Label>
                        </li>
                    </ol>
                    <asp:Button runat="server" ID="BtnLogin" CommandName="Login" Text="Log in" OnClick="BtnLogin_Click" />
                </fieldset>
            <%--</LayoutTemplate>
        </asp:Login>
            </AnonymousTemplate>
        </asp:LoginView>--%>
        </asp:Panel>
        <p>
            <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register</asp:HyperLink>
            if you don't have an account.
        </p>
    </section>
    <section id="alllogins">
        <asp:GridView ID="GwAllLogins" runat="server" AutoGenerateColumns="true"></asp:GridView>
    </section>
</asp:Content>