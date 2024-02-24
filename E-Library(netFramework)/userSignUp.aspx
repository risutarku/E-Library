<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userSignUp.aspx.cs" Inherits="E_Library_netFramework_.userSignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
    
    <div class="container">

      <div class="row">
         <div class="col-md-8 mx-auto ">

            <div class="card">
               <div class="card-body d-grid gap-2">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="imgs/generaluser.png"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h3>User Sign Up</h3>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                   <div class="row">

                       <div class="col-md-6">
                           <label>Full Name</label>
                           <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox3"
                                    runat="server" placeholder="Full Name"></asp:TextBox>
                           </div>
                       </div>
                       
                       <div class="col-md-6">
                           <label>Date of Birth</label>
                           <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox4"
                                    runat="server" placeholder="Date of Birth" TextMode="Date"></asp:TextBox>
                           </div>
                       </div>

                   </div>

                   
                   <div class="row">

                       <div class="col-md-6">
                           <label>Contact Number</label>
                           <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox5"
                                    runat="server" placeholder="Contact Number"></asp:TextBox>
                           </div>
                       </div>
                       
                       <div class="col-md-6">
                           <label>Email ID</label>
                           <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox6"
                                    runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                           </div>
                       </div>

                   </div>

                   <div class="row">

                       <div class="col-md-4">
                           <label>State</label>
                           <div class="form-group">
                               <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                   
                                   <asp:ListItem Text="Select" Value="select" />
                                   <asp:ListItem Text="Altai Kray" Value="Altai Kray" />
                                   <asp:ListItem Text="Altai Republic" Value="Altai Republic" />
                                   <asp:ListItem Text="Khackasy republic" Value="Khackasy republic" />
                                   <asp:ListItem Text="Krasnoyarsk region" Value="Krasnoyarsk region" />
                                   <asp:ListItem Text="Kuzzzzzzzzzbas" Value="Kuzzzzzzzzzbas" />
                                   <asp:ListItem Text="Novosibirsk region" Value="Novosibirsk region" />
                                   <asp:ListItem Text="Omsk region" Value="Omsk region" />
                                   <asp:ListItem Text="Tomsk region" Value="Tomsk region" />

                               </asp:DropDownList>
                           </div>
                       </div>
                       
                       <div class="col-md-4">
                           <label>City</label>
                           <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox8"
                                    runat="server" placeholder="City"></asp:TextBox>
                           </div>
                       </div>

                       <div class="col-md-4">
                           <label>Pincode</label>
                           <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox9"
                                    runat="server" placeholder="Pincode"></asp:TextBox>
                           </div>
                       </div>

                   </div>

                   <div class="row">

                       <div class="col">
                           <label>Full Address</label>
                           <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox10"
                                    runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                           </div>
                       </div>

                   </div>

                  <div class="row">
                      <center>
                        <div class="form-group">
                            <span class="badge rounded-pill text-bg-info">Login Credentials</span>
                        </div>
                      </center>
                  </div>

                   <div class="row">

                       <div class="col">
                           <label>User ID</label>
                           <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox1"
                                    runat="server" placeholder="User ID"></asp:TextBox>
                           </div>
                       </div>
                       
                       <div class="col">
                           <label>Password</label>
                           <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox2"
                                    runat="server" placeholder="Password" ></asp:TextBox>
                           </div>
                       </div>

                   </div>

                  <div class="row">
                    <div class="form-group d-grid gap-2">
                            
                           <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1"
                               runat="server" Text="Sign Up" OnClick="Button1_Click" />
                    </div>
                  </div>

               </div>
            </div>

            <a href="homepage.aspx"><< Back to Home</a><br><br>
         </div>
      </div>

    </div>

</asp:Content>
