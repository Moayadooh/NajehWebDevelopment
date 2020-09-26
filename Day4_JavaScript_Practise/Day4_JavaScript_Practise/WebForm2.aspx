<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Day4_JavaScript_Practise.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%
                var name = Request.Params["name"];
                var field = Request.Params["field"];
                Response.Write("Name is " + name + "<br/>Field is " + field);
                %>
        </div>
    </form>
</body>
</html>
