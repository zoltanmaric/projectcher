<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThankYou.aspx.cs" Inherits="ThankYou" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Jos samo ovo :)</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Koliko sljedećih preporuka biste ocijenili zadovoljavajućim?
        <br />
        <asp:Literal ID="litReccomendations" runat="server">
        </asp:Literal>
        <br />
        <br />
        <asp:DropDownList ID="ddlRemark" runat="server"></asp:DropDownList>
        <br />
        <br />
        <asp:Button runat="server" ID="btnSubmit" Text="Posalji rezultate" onclick="btnSubmit_Click" />
    </div>
    </form>
</body>
</html>
