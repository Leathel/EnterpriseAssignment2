<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="JobsTracker.MainMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="/css/masterStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Main Menu</h1>

    <div class="well" id="customWell">
        <h3>Jobs</h3>
        <ul class="list-group">
            <li class="list-group-item"><a href="Jobs.aspx">Job List</a></li>
            <li class="list-group-item"><a href="AddJob.aspx">Add Job</a></li>
        </ul>
    </div>

    <div class="well" id="customWell">
        <h3>Employees</h3>
        <ul class="list-group">
            <li class="list-group-item"><a href="Employees.aspx">Employee List</a></li>
            <li class="list-group-item"><a href="AddEmployee.aspx">Add Employee</a></li>
        </ul>
    </div>

    <div class="well" id="customWell">
        <h3>Customers</h3>
        <ul class="list-group">
            <li class="list-group-item"><a href="ShowCustomers.aspx">Customer List</a></li>
            <li class="list-group-item"><a href="AddCustomer.aspx">Add Customer</a></li>
        </ul>
    </div>

    <div class="well" id="customWell">
        <h3>Contractors</h3>
        <ul class="list-group">
            <li class="list-group-item"><a href="ShowContractors.aspx">Contractor List</a></li>
            <li class="list-group-item"><a href="AddContractor.aspx">Add Contractor</a></li>
        </ul>
    </div>
</asp:Content>
