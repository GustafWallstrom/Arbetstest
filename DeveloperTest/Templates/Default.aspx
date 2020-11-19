<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" EnableSessionState="False"
    Inherits="DeveloperTest.Templates.Default" Title="Untitled Page" %>

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
                    <Core:DynamicControlContainer runat="server" ID="dcMain" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
