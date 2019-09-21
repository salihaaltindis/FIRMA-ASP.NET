<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Yonetim.Master" AutoEventWireup="true" CodeBehind="Proje.aspx.cs" Inherits="FIRMA_ASPNET.Admin.Proje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 150px;
        }
    </style>
    <script src="/ckeditor/ckeditor.js"></script>
    <script src="/ckfinder/ckfinder.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlProjeListe" runat="server">
        <table cellspacing="0" class="auto-style1">
            <tr>
                <td>
                    <div id="arayenibar">
                    <asp:Label ID="Label1" runat="server" Text="Adı : "></asp:Label>
                    <asp:TextBox ID="txtProjeAra" runat="server"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ara" />
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Yeni" />
                        </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="PROJE_REFNO" ForeColor="#333333" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="100%" PageSize="5">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:CommandField HeaderText="Seç" ShowSelectButton="True" />
                            <asp:BoundField DataField="PROJE_REFNO" HeaderText="Proje Refno" />
                            <asp:BoundField DataField="ADI" HeaderText="Adı" />
                            <asp:ImageField DataImageUrlField="RESIM" DataImageUrlFormatString="~\Images\{0}" HeaderText="Resim">
                            </asp:ImageField>
                            <asp:BoundField DataField="ACIKLAMA" HeaderText="Açıklama" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlProjeKayit" runat="server" Visible="False">
        <table cellspacing="0" class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="SAYFA KAYIT FORMU"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label3" runat="server" Text="Proje Refno"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPROJE_REFNO" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label4" runat="server" Text="Adı"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtADI" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtADI" ErrorMessage="Adını giriniz." ValidationGroup="ProjeKayitForm"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label5" runat="server" Text="Resim"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload ID="fuRESIM" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="fuRESIM" ErrorMessage="Resim ekleyiniz." ValidationGroup="ProjeKayitForm"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label6" runat="server" Text="Açıklama"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtACIKLAMA" runat="server" MaxLength="1000" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Açıklama giriniz." ValidationGroup="ProjeKayitForm" ControlToValidate="txtACIKLAMA"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Kaydet" ValidationGroup="ProjeKayitForm" />
                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Vazgeç" />
                    <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Sil" OnClientClick="return confirm('Proje silinsin mi?');" />
                </td>
            </tr>
        </table>

    </asp:Panel>
    <script>
        var editor = CKEDITOR.replace('ContentPlaceHolder1_txtACIKLAMA');
        CKFinder.setupCKEditor(editor, '/ckfinder/');
    </script>
</asp:Content>
