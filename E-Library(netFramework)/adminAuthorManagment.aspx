<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminAuthorManagment.aspx.cs" Inherits="E_Library_netFramework_.adminauthormanagment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="container">

      <div class="row">

         <div class="col-md-5">

            <div class="card">
               <div class="card-body d-grid gap-2">
                 
                 <div class="row">
                     <div class="col">
                        <center>
                           <h3>Author Details</h3>
                        </center>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col">
                         <center>
                             <img width="100px" src="imgs/writer.png" />
                         </center>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                   <div class="row">

                       <div class="col-md-4">
                           <label>Author ID</label>
                           <div class="form-group">
                               <div class="input-group">
                                   
                                <asp:TextBox CssClass="form-control" ID="TextBox3"
                                    runat="server" placeholder="ID"></asp:TextBox>

                               <asp:Button class="btn btn-primary" ID="Button1" 
                                    runat="server" Text="Go" />
                               </div>
                           </div>
                       </div>
                       
                       <div class="col-md-8">
                           <label>Author Name</label>
                           <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox4"
                                    runat="server" placeholder="Author Name" ></asp:TextBox>
                           </div>
                       </div>

                   </div>

                   <div class="row">

                       <div class="col-md-4">
                           <asp:Button ID="Button2" class="btn btn-lg btn-block btn-success"
                               runat="server" Text="Add" />
                       </div>
                       <div class="col-md-4">
                           <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning"
                               runat="server" Text="Update" />
                       </div>
                       <div class="col-md-4">
                           <asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger"
                               runat="server" Text="Delete" />
                       </div>

                   </div>

                   

               



               </div>
            </div>

            <a href="homepage.aspx"><< Back to Home</a><br><br>
         </div>

          <div class="col-md-7">

               <div class="card">
               <div class="card-body d-grid gap-2">


                  <div class="row">
                     <div class="col">
                        <center>
                           <h3>Author List</h3>
                        </center>
                     </div>
                  </div>


                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                   
                  <div class="row">
                     <div class="col">
                         <asp:GridView class="table table-striped table-bordered"
                             ID="GridView1" runat="server"></asp:GridView>
                     </div>
                  </div>
            
               </div>
            </div>

          </div>

      </div>

    </div>

</asp:Content>
