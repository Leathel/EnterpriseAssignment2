<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="ShowCustomers.aspx.cs" Inherits="JobsTracker.Admin.ShowCustomers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Customers</h1>
    <div class="well well-sm">
        
        <%--<div class="well">--%>
        <asp:GridView ID="grdShowCustomers" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="false" OnRowDeleting="grdShowCustomers_RowDeleting" DataKeyNames="CustomerID">
            <Columns>
                <asp:BoundField DataField="CustomerID" HeaderText="Customer ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="~/Admin/AddEmployee.aspx" DataNavigateUrlFields="CustomerID"
                    DataNavigateUrlFormatString="AddEmployee.aspx?EmployeeID={0}&Name={0}" />
                <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />
            </Columns>
            
        </asp:GridView>
        <a href="/Admin/AddCustomer.aspx">Add Customer</a>
    </div>

    <%--</div>--%>
</asp:Content>
