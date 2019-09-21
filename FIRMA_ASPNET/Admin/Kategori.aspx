<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Yonetim.Master" AutoEventWireup="true" CodeBehind="Kategori.aspx.cs" Inherits="FIRMA_ASPNET.Admin.Kategori" %>
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
        height: 21px;
    }
    .auto-style4 {
        height: 21px;
    }
    
</style>
<link href="~/Content/StyleSheet1.css" rel="stylesheet" />
    
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="pnlKategoriListe" runat="server" >
        <table cellspacing="0" class="auto-style1">
            <tr>
                <td >
                    <div id="arayenibar">
                        <asp:Label ID="Label1" runat="server" Text="Kategori Adı: "></asp:Label>
                        <asp:TextBox ID="txtKategoriAra" runat="server"></asp:TextBox>
                        <asp:Button ID="btnAra" runat="server" Text="Ara" OnClick="Button1_Click" />
                       <asp:Button ID="btnYeni" runat="server" Text="Yeni" OnClick="Button2_Click" />
                       

            
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="KATEGORI_REFNO" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="100%" PageSize="5">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:CommandField HeaderText="Seç" ShowSelectButton="True" />
                            <asp:BoundField DataField="KATEGORI_REFNO" HeaderText="Kategori Refno" />
                            <asp:BoundField DataField="KATEGORI_ADI" HeaderText="Kategori Adı" />
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
    <div class="kayit">
    <asp:Panel ID="pnlKategoriKayit" runat="server" Visible="False">
        <table cellspacing="0" class="auto-style1">
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style4">
                    <asp:Label ID="Label2" runat="server" Text="KATEGORİ KAYIT FORMU"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label3" runat="server" Text="Kategori Refno"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtKATEGORI_REFNO" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label4" runat="server" Text="Kategori Adı"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtKATEGORI_ADI" runat="server" MaxLength="50" ValidationGroup="KategoriKayitForm"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtKATEGORI_ADI" ErrorMessage="Kategori adı giriniz." ValidationGroup="KategoriKayitForm"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="Button3" runat="server" Text="Kaydet" ValidationGroup="KategoriKayitForm" OnClick="Button3_Click" />
                    <asp:Button ID="Button4" runat="server" Text="Vazgeç" OnClick="Button4_Click" />
                    <asp:Button ID="Button5" runat="server" Text="Sil" OnClick="Button5_Click" OnClientClick="return confirm('Kategori silinsin mi?');" />
                </td>
            </tr>
        </table>

    </asp:Panel>
        </div>
</asp:Content>
