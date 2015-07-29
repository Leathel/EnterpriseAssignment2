<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="AddJob.aspx.cs" Inherits="JobsTracker.Admin.AddJob" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Job Details</h1>
    <h5>All fields are required</h5>

    <%--This should prompt to select a customer for the job--%>

    <fieldset>
        <label for="ddlCustomerSearch" class="col-sm-2">Customer: </label>
        <asp:DropDownList runat="server" ID="ddlCustomerSearch" DataTextField="Name"
            DataValueField="CustomerID" AutoPostBack="true" OnSelectedIndexChanged="ddlCustomerSearch_SelectedIndexChanged">
        </asp:DropDownList>
    </fieldset>


    <fieldset>
        <label for="txtCost" class="col-sm-2">Cost: </label>
        <asp:TextBox ID="txtCost" runat="server" required="" MaxLength="50" TextMode="Number" />
    </fieldset>

    <fieldset>
        <label for="txtMaterialCost" class="col-sm-2">Material Cost: </label>
        <asp:TextBox ID="txtMaterialCost" runat="server" required="" MaxLength="50" TextMode="Number" />
    </fieldset>

    <fieldset>
        <label for="txtJobDate" class="col-sm-2">Job Start Date: </label>
        <asp:TextBox ID="txtJobDate" runat="server" required="" TextMode="Date" />
        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Must be a Date" ControlToValidate="txtJobDate"
            CssClass="alert alert-danger" Type="Date" MinimumValue="01/01/2000" MaximumValue="01/01/2099"></asp:RangeValidator>
    </fieldset>

    <fieldset>
        <label for="txtDescription" class="col-sm-2">Description: </label>
        <asp:TextBox ID="txtDescription" runat="server" required="" MaxLength="50" />
    </fieldset>


    <div>
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>

</asp:Content>
