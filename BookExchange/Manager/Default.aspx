﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Manager_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <ul>
        <li>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Manager/ManageHome.aspx">Manage Home</asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Manager/ManageAbout.aspx">Manage About</asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Manager/ManageUsers.aspx">Manage Users</asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Manager/AllPostings.aspx">All Postings</asp:HyperLink>
        </li>        
        <li>
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Manager/ManageTradeRequests.aspx">Trade Requests</asp:HyperLink>
        </li>                 
    </ul>
</asp:Content>

