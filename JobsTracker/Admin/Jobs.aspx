<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Jobs.aspx.cs" Inherits="JobsTracker.Admin.Jobs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/css/masterStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Jobs</h1>
    <div class="well well-sm">
        
        <asp:GridView ID="grdJobs" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="false" OnRowDeleting="grdJobs_RowDeleting"
            DataKeyNames="JobID">
            <Columns>
                <asp:BoundField DataField="JobID" HeaderText="Job ID" />
                <asp:BoundField DataField="CustomerID" HeaderText="Customer" />
                <asp:BoundField DataField="Cost" HeaderText="Cost" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="JobDate" HeaderText="Date Started" DataFormatString="{0:dd-MM-yyyy}" />
                <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="~/addJob.aspx" DataNavigateUrlFields="JobID"
                    DataNavigateUrlFormatString="Job.aspx?JobID={0}&Name={0}" />
                <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />
            </Columns>
            
        </asp:GridView>
        <a href="AddJob.aspx">Add Job</a>
    </div>


</asp:Content>
