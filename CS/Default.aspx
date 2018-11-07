<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxGridView ID="ASPxGridView1" runat="server" DataSourceID="AccessDataSource1"
                ClientInstanceName="grid" EnableRowsCache="false"
                AutoGenerateColumns="False" KeyFieldName="ProductID"
                OnCustomCallback="ASPxGridView1_CustomCallback">
                <SettingsPager PageSize="15">
                </SettingsPager>
                <Settings ShowGroupPanel="True" />
                <SettingsBehavior ProcessSelectionChangedOnServer="true" />
                <Columns>
                    <dx:GridViewCommandColumn Caption="#" ShowSelectCheckbox="true" VisibleIndex="0">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="ProductID" ReadOnly="True" VisibleIndex="1">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="ProductName" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SupplierID" VisibleIndex="3" GroupIndex="0">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="UnitPrice" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="UnitsInStock" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Templates>
                    <GroupRowContent>
                        <dx:ASPxCheckBox ID="cb" runat="server" AllowGrayed="true" OnInit="cb_Init" OnLoad="cb_Load"></dx:ASPxCheckBox>
                    </GroupRowContent>
                </Templates>
            </dx:ASPxGridView>
            <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/nwind.mdb"
                SelectCommand="SELECT [ProductID], [ProductName], [UnitPrice], [UnitsInStock], [SupplierID] FROM [Products]"></asp:AccessDataSource>
        </div>
    </form>
</body>
</html>
