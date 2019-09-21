<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="FIRMA_ASPNET.Admin.Giris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 299px;
        }
        .auto-style2 {
            width: 337px;
        }
        .auto-style3 {
            width: 300px;
        }
    </style>

    <link href="../Content/StyleSheet1.css" rel="stylesheet" />
</head>
<body style="width: 336px">
 <form id="form1" runat="server">
       <div>
            <fieldset>
                 <legend>Giriş Ekranı</legend>
            <table cellspacing="0" class="auto-style1">
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label1" runat="server" Text="Kullanıcı Adı"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox class="kullanici" ID="txtKULLANICIADI" runat="server" MaxLength="20" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Text="Şifre"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox class="parola" ID="txtPAROLA" runat="server" MaxLength="20" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Button ID="btnGiris" runat="server" OnClick="btnGiris_Click" Text="Giriş Yap" />
                    </td>
                </tr>
            </table>
        </div>
   
    </form> 

    </fieldset>
</body>
</html>
