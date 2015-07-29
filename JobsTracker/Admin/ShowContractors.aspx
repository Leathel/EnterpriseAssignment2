<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="ShowContractors.aspx.cs" Inherits="JobsTracker.Admin.ShowContractors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <h1>Contractors</h1>
    <div class="well well-sm">
        
        <asp:GridView ID="grdContractors" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="false" OnRowDeleting="grdContractors_RowDeleting"
            DataKeyNames="ContractorID">
            <Columns>
                <asp:BoundField DataField="ContractorID" HeaderText="Contractor ID" />
                <asp:BoundField DataField="Service" HeaderText="Service" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                
                <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="~/addContractor.aspx" DataNavigateUrlFields="ContractorID"
                    DataNavigateUrlFormatString="ShowContractors.aspx?ContractorID={0}" />
                <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />
            </Columns>
            
        </asp:GridView>


        <a href="AddContractor.aspx">Add Contractor</a>
    </div>
</asp:Content>
