<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="AddContractor.aspx.cs" Inherits="JobsTracker.Admin.AddContractor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/css/masterStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Contractor Details</h1>
    <h5>All fields are required</h5>

    <%--This should prompt to select a customer for the job--%>

    <fieldset>
        <label for="txtFirstName" class="col-sm-2">First Name: </label>
        <asp:TextBox ID="txtFirstName" runat="server" required="" MaxLength="50" />
    </fieldset>
    <fieldset>
        <label for="txtLasttName" class="col-sm-2">Last Name: </label>
        <asp:TextBox ID="txtLastName" runat="server" required="" MaxLength="50" />
    </fieldset>
    <fieldset>
        <label for="txtService" class="col-sm-2">Service: </label>
        <asp:TextBox ID="txtService" runat="server" required="" MaxLength="50" />
    </fieldset>

    <div>
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>

</asp:Content>
