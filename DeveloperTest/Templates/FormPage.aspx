<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormPage.aspx.cs" EnableSessionState="False"
    Inherits="DeveloperTest.Templates.FormPage" Title="Untitled Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="headcp" runat="server"></asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="server">
    <div class="row">
        <div class="c12 clms">
            <div class="pageform">
                <h1>
                    <Core:TextField runat="server" ID="pageName" AffectPage="Title" />
                </h1>

                <div class="content">
                    <Core:RichEditArea ID="body" runat="server" />
                    <div class="field">
                        <asp:TextBox runat="server" ID="excompany"></asp:TextBox>
                        <asp:Label runat="server" AssociatedControlID="excompany" Text="Företag"></asp:Label>
                    </div>
                    <div class="field">
                        <asp:TextBox runat="server" ID="exContactPerson"></asp:TextBox>
                        <asp:Label runat="server" AssociatedControlID="exContactPerson" Text="Kontaktperson"></asp:Label>
                    </div>
                    <div style="display:flex;flex-direction:row">
                        <div class="field">
                            <asp:TextBox runat="server" ID="exPhoneOne"></asp:TextBox>
                            <asp:Label runat="server" AssociatedControlID="exPhoneOne" Text="Telefon 1"></asp:Label>
                        </div>
                        <div class="field">
                            <asp:TextBox runat="server" ID="exPhoneTwo"></asp:TextBox>
                            <asp:Label runat="server" AssociatedControlID="exPhoneTwo" Text="Telefon 2"></asp:Label>
                        </div>
                    </div>
                    <div class="field">
                        <asp:TextBox runat="server" ID="exEmail"></asp:TextBox>
                        <asp:Label runat="server" AssociatedControlID="exEmail" Text="E-post"></asp:Label>
                    </div>
                    <div class="field">
                        <asp:TextBox runat="server" ID="exQuestion" TextMode="MultiLine"></asp:TextBox>
                        <asp:Label runat="server" AssociatedControlID="exQuestion" Text="Fråga"></asp:Label>
                    </div>
                    <div class="field">
                        <asp:TextBox runat="server" ID="exAnswer" TextMode="MultiLine"></asp:TextBox>
                        <asp:Label runat="server" AssociatedControlID="exAnswer" Text="Svar"></asp:Label>
                    </div>
                    <div class="field">
                        <asp:TextBox runat="server" ID="exComment" TextMode="MultiLine"></asp:TextBox>
                        <asp:Label runat="server" AssociatedControlID="exComment" Text="Åtgärd/Kommentar"></asp:Label>
                    </div>
                    <div class="cf mt20">
                        <asp:Button runat="server" ID="exSendform" Text="Skicka" OnClick="HandleSendClick"/>
                    </div>

                    <Core:DynamicControlContainer runat="server" ID="dcMain" />  
                </div>
            </div>
        </div>
    </div>
</asp:Content>
