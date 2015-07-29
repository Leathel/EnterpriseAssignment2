<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="JobsTracker.Admin.AddCustomers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/css/masterStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Customer Details</h1>
    <h5>All fields are required</h5>

    <%--This should prompt to select a customer for the job--%>

    <fieldset>
        <label for="txtName" class="col-sm-2">Name: </label>
        <asp:TextBox ID="txtName" runat="server" required="" MaxLength="50" />
    </fieldset>

    <fieldset>
        <label for="txtAddress" class="col-sm-2">Address: </label>
        <asp:TextBox ID="txtAddress" runat="server" required="" MaxLength="50" />
    </fieldset>

    <div>
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>

</asp:Content>
