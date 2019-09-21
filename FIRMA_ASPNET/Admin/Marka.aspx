<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Yonetim.Master" AutoEventWireup="true" CodeBehind="Marka.aspx.cs" Inherits="FIRMA_ASPNET.Admin.Marka" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 151px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlMarkaListe" runat="server">
        <table cellspacing="0" class="auto-style1">
            <tr>
                <td>
                     <div id="arayenibar">
                    <asp:Label ID="Label1" runat="server" Text="Marka Adı: "></asp:Label>
                    <asp:TextBox ID="txtMarkaAra" runat="server"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="Ara" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Yeni" OnClick="Button2_Click" />
                         </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="MARKA_REFNO" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="5">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="MARKA_REFNO" HeaderText="Marka Refno" />
                            <asp:BoundField DataField="MARKA_ADI" HeaderText="Marka Adı" />
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
    <asp:Panel ID="pnlMarkaKayit" runat="server" Visible="False">
        <table cellspacing="0" class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="MARKA KAYIT FORMU"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label3" runat="server" Text="Marka Refno"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMARKA_REFNO" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label4" runat="server" Text="Marka Adı"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMARKA_ADI" runat="server" MaxLength="20" ValidationGroup="MarkaKayitForm"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMARKA_ADI" ErrorMessage="Marka adı giriniz." ValidationGroup="MarkaKayitForm"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="Button3" runat="server" Text="Kaydet" ValidationGroup="MarkaKayitForm" OnClick="Button3_Click" />
                    <asp:Button ID="Button4" runat="server" Text="Vazgeç" OnClick="Button4_Click" />
                    <asp:Button ID="Button5" runat="server" Text="Sil" OnClick="Button5_Click" OnClientClick="return confirm('Marka silinsin mi?');"/>
                </td>
            </tr>
        </table>

    </asp:Panel>
        </div>
</asp:Content>
