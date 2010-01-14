<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web stranica s preporukama glazbenika</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;<br />
        <asp:Literal ID="litText" runat="server"></asp:Literal>
        <br />
        <asp:Button ID="btnGrantPermission" runat="server" 
            onclick="btnGrantPermission_Click" 
            Text="Redirect to Last.fm to grant permission" />
        
        <asp:Literal ID="litIHaveHeardAbout" runat="server">Ocjena : </asp:Literal>
        <br />
        <asp:DropDownList ID="ddlFirst" runat="server"></asp:DropDownList>
        &nbsp;&nbsp;
        <asp:DropDownList ID="ddlSecond" runat="server"></asp:DropDownList>
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Send" 
            onclick="btnSubmit_Click" />
    </div>
    </form>
</body>
</html>
