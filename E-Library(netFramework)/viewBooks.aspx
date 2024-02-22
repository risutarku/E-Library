<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewBooks.aspx.cs" Inherits="E_Library_netFramework_.viewBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">



        <div class="row">
            <div class="col">
                <center>
                    <h3>Book Inventory List</h3>
                </center>
            </div>
        </div>


        <div class="row">
            <div class="col">
                <asp:GridView class="table table-striped table-bordered"
                    ID="GridView1" runat="server">
                </asp:GridView>
            </div>
        </div>
        <a href="homepage.aspx"><< Back to Home</a><br><br>

    </div>

</asp:Content>
