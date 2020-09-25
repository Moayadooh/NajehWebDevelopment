<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="info.aspx.cs" Inherits="Day4_javascript.info" %>

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
                var email = Request.Params["email"];

                Response.Write("User Name is " + name + "<br/> User Email " + email);

                %>

        </div>
    </form>
</body>
</html>
