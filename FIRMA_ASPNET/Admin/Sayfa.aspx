<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Yonetim.Master" AutoEventWireup="true" CodeBehind="Sayfa.aspx.cs" Inherits="FIRMA_ASPNET.Admin.Sayfa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 150px;
        }
        .auto-style3 {
            width: 150px;
            height: 24px;
        }
        .auto-style4 {
            height: 24px;
        }
    </style>
    <script src="/ckeditor/ckeditor.js"></script>
    <script src="/ckfinder/ckfinder.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlSayfaListele" runat="server">
        <table cellspacing="0" class="auto-style1">
            <tr>
                <td>
                    <div id="arayenibar">
                    <asp:Label ID="Label1" runat="server" Text="Başlık: "></asp:Label>
                    <asp:TextBox ID="txtSayfaAra" runat="server"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ara" />
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Yeni" />
                        </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="SAYFA_REFNO" ForeColor="#333333" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" Width="100%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="5">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:CommandField HeaderText="Seç" ShowSelectButton="True" />
                            <asp:BoundField DataField="SAYFA_REFNO" HeaderText="Sayfa Refno" />
                            <asp:BoundField DataField="BASLIK" HeaderText="Başlık" />
                            <asp:BoundField DataField="ICERIK" HeaderText="İçerik" />
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
    <asp:Panel ID="pnlSayfaKayit" runat="server" Visible="False">
        <table cellspacing="0" class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="SAYFA KAYIT FORMU"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label3" runat="server" Text="Sayfa Refno"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtSAYFA_REFNO" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label4" runat="server" Text="Başlık"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBASLIK" runat="server" MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBASLIK" ErrorMessage="Başlık giriniz." ValidationGroup="SayfaKayitForm"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label5" runat="server" Text="İçerik"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtICERIK" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtICERIK" ErrorMessage="İçerik giriniz." ValidationGroup="SayfaKayitForm"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Kaydet" ValidationGroup="SayfaKayitForm" />
                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Vazgeç" />
                    <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Sil"  OnClientClick="return confirm('Sayfa silinsin mi?');"/>
                </td>
            </tr>
        </table>

    </asp:Panel>
    <script>
        var editor = CKEDITOR.replace('ContentPlaceHolder1_txtICERIK');
        CKFinder.setupCKEditor(editor, '/ckfinder/');
    </script>
</asp:Content>
