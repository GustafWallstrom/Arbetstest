<%@ control language="C#" autoeventwireup="true" codebehind="TreeMenu.ascx.cs" inherits="DeveloperTest.Controls.TreeView" %>
<core:extreepagelist runat="server" id="exTopMenu" ParentLevel="1" showonlyactive="False">
    <HeaderTemplate>
        <ul class="nav-bar top-nav">
    </HeaderTemplate>
    <ItemTemplate>
        <li><%# Container.Page.GetLink(true,true) %></li>
    </ItemTemplate>
    <ContainerTemplate>
        <li class="parent has-flyout"><%# Container.Page.GetLink(true,true) %><a href="#" class="flyout-toggle"><span></span></a><ul class="flyout large">
    </ContainerTemplate>
    <ContainerEndTemplate></ul></li></ContainerEndTemplate>
    <ClosedContainerTemplate>
        <li class="parent"><%# Container.Page.GetLink(true,true) %></li>
    </ClosedContainerTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</core:extreepagelist>
