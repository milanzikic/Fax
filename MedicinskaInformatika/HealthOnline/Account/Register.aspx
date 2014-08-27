<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Use the form below to create a new account.</h2>
    </hgroup>
    <asp:Panel ID="PnlRegisterForm" runat="server">
        <div>
            <p class="message-info">
                Passwords are required to be a minimum of <%: Membership.MinRequiredPasswordLength %> characters in length.
            </p>

            <p class="validation-summary-errors">
                <asp:Literal runat="server" ID="ErrorMessage" />
            </p>

            <fieldset>
                <legend>Registration Form</legend>
                <ol>
                    <li>
                        <asp:Label ID="lblPin" runat="server" AssociatedControlID="txtPinCode">PIN</asp:Label>
                        <asp:TextBox ID="txtPinCode" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPin" runat="server" ControlToValidate="txtPinCode" 
                            CssClass="field-validation-error" ErrorMessage="Niste uneli PIN!" ></asp:RequiredFieldValidator>
                    </li>
                    <li>
                        <asp:Label ID="lblJmbg" runat="server" AssociatedControlID="txtJMBG">JMBG</asp:Label>
                        <asp:TextBox ID="txtJMBG" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvJmbg" runat="server" ControlToValidate="txtJMBG"
                            CssClass="field-validation-error" ErrorMessage="Niste uneli JMBG!" ></asp:RequiredFieldValidator>
                    </li>
                    <li>
                        <asp:Label ID="lblUsername" runat="server" AssociatedControlID="txtUserName">Korisnicko Ime</asp:Label>
                        <asp:TextBox runat="server" ID="txtUserName" />
                        <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUserName"
                            CssClass="field-validation-error" ErrorMessage="Niste uneli Korisniko Ime!" />
                    </li>                    
                    <li>
                        <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword">Lozinka</asp:Label>
                        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" />
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                            CssClass="field-validation-error" ErrorMessage="Niste uneli Lozinku!" />
                    </li>
                    <li>
                        <asp:Label ID="lblConfirmPassword" runat="server" AssociatedControlID="txtConfirmPassword">Potvrdite lozinku</asp:Label>
                        <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" />
                        <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
                                CssClass="field-validation-error" Display="Dynamic" ErrorMessage="Niste potvrdili lozinku!" />
                        <asp:CompareValidator ID="cmpvPassword" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"
                                CssClass="field-validation-error" Display="Dynamic" ErrorMessage="Uneta Lozinka nije potvrdjena!" />
                    </li>
                    <li>
                        <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail">Email address</asp:Label>
                        <asp:TextBox runat="server" ID="txtEmail" TextMode="Email" />
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                            CssClass="field-validation-error" ErrorMessage="Niste uneli Email adresu!" />
                    </li>
                    <li>
                        <asp:Label ID="lblTelefon" runat="server" AssociatedControlID="txtTelefon">Telefon</asp:Label>
                        <asp:TextBox ID="txtTelefon" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTelefon" runat="server" ControlToValidate="txtTelefon"
                            CssClass="field-validation-error" ErrorMessage="Niste uneli Telefon!"></asp:RequiredFieldValidator>
                    </li>
                    <li>
                        <asp:Label ID="lblMobilni" runat="server" AssociatedControlID="txtMobilni">Mobilni</asp:Label>
                        <asp:TextBox ID="txtMobilni" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMobilni" runat="server" ControlToValidate="txtMobilni"
                            CssClass="field-validation-error" ErrorMessage="Niste uneli Mobilni!"></asp:RequiredFieldValidator>
                    </li>
                </ol>
                <asp:Button ID="btnRegister" runat="server" CommandName="MoveNext" Text="Register" OnClick="btnRegister_Click" />
            </fieldset>
        </div>
    </asp:Panel>
    <%--<asp:CreateUserWizard runat="server" ID="RegisterUser" ViewStateMode="Disabled" OnCreatedUser="RegisterUser_CreatedUser">
        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="wizardStepPlaceholder" />
            <asp:PlaceHolder runat="server" ID="navigationPlaceholder" />
        </LayoutTemplate>
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" ID="RegisterUserWizardStep">
                <ContentTemplate>
                    <p class="message-info">
                        Passwords are required to be a minimum of <%: Membership.MinRequiredPasswordLength %> characters in length.
                    </p>

                    <p class="validation-summary-errors">
                        <asp:Literal runat="server" ID="ErrorMessage" />
                    </p>

                    <fieldset>
                        <legend>Registration Form</legend>
                        <ol>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="UserName">User name</asp:Label>
                                <asp:TextBox runat="server" ID="UserName" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                    CssClass="field-validation-error" ErrorMessage="The user name field is required." />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="Email">Email address</asp:Label>
                                <asp:TextBox runat="server" ID="Email" TextMode="Email" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                    CssClass="field-validation-error" ErrorMessage="The email address field is required." />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                    CssClass="field-validation-error" ErrorMessage="The password field is required." />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Confirm password</asp:Label>
                                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                     CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                     CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                            </li>
                        </ol>
                        <asp:Button runat="server" CommandName="MoveNext" Text="Register" />
                    </fieldset>
                </ContentTemplate>
                <CustomNavigationTemplate />
            </asp:CreateUserWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>--%>
</asp:Content>