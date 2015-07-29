<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="JobsTracker.Admin.Employees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/css/masterStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Employees</h1>
    <div class="well well-sm">
        
        <%--<div class="well">--%>
        <asp:GridView ID="grdEmployees" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="false" OnRowDeleting="grdEmployees_RowDeleting"
            DataKeyNames="EmployeeID">
            <Columns>
                <asp:BoundField DataField="EmployeeID" HeaderText="Employee ID" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="HireDate" HeaderText="Hire Date" DataFormatString="{0:dd-MM-yyyy}" />
                <asp:BoundField DataField="TerminationDate" HeaderText="Termination Date (if applicable)" />
                <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="~/Admin/AddEmployee.aspx" DataNavigateUrlFields="EmployeeID"
                    DataNavigateUrlFormatString="AddEmployee.aspx?EmployeeID={0}&LastName={0}" />
                <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />
            </Columns>
            
        </asp:GridView>
        <a href="/Admin/AddEmployee.aspx">Add Employees</a>
    </div>

    <%--</div>--%>
</asp:Content>
