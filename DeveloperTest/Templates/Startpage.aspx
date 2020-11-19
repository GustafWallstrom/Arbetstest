<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Startpage.aspx.cs" EnableSessionState="False"
    Inherits="DeveloperTest.Templates.Startpage" Title="Untitled Page" %>

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

    <script>
        ql.postload(function() {
            $('.login .password, .login .username').each(function() {
                $(this).find('label').insertAfter($(this).find('input'));
            });
        });
    </script>
</asp:Content>
