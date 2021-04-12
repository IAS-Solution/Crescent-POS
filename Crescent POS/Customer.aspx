<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="Crescent_POS.Customer" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" Class="content-wrapper"> 
  <form runat="server">   
    <div class="content-wrapper"><!--Content Wrapper. Contains page content-->   
    <div class="content-header"><!-- Content Header (Page header) -->
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">Customer</h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item active">Customer</li>
            </ol>
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div><!-- /.content-header -->
    
         <div class="alert alert-success alert-dismissible" ID="savealert" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px; "> 
        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-check"></i> Alert!</h5>
                  Data inserted successfully!
   </div>
      


    
       
         <div class="alert alert-danger alert-dismissible" id="deletealert" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-ban"></i> Alert!</h5>
                  Data delete successfully!
                </div>

        
         <div class="alert alert-warning alert-dismissible" id="warningalert" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-exclamation-triangle"></i> Alert!</h5>
                 Customer Name is Empty!
                </div>
          
        <div class="alert alert-warning alert-dismissible" id="wrningex" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-exclamation-triangle"></i> Alert!</h5>
                    
               <asp:Label id="lblex" runat="server"></asp:Label>
                </div>
         <div class="alert alert-warning alert-dismissible" id="wrningphone" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-exclamation-triangle"></i> Alert!</h5>
                 Please Mobile Number to save!
                </div>
        
         <div class="alert alert-warning alert-dismissible" id="wrningemail" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-exclamation-triangle"></i> Alert!</h5>
                 Please give a Email to save!
                </div>
         <div class="alert alert-warning alert-dismissible" id="wrningaddress" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-exclamation-triangle"></i> Alert!</h5>
                 Please give a Address to save!
                </div>
         <div class="alert alert-warning alert-dismissible" id="wrningnic" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-exclamation-triangle"></i> Alert!</h5>
                 Please give a NIC to save!
                </div>
          <div class="alert alert-warning alert-dismissible" id="wrningamt" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-exclamation-triangle"></i> Alert!</h5>
                 Please give a Ammount to save!
                </div>
        
         <div class="alert alert-info alert-dismissible" id="updatealert" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-check"></i> Alert!</h5>
                 Data update successfully!
                </div>
    <!-- Main content -->
      <div class="container-fluid">
           <div class="card card-default"><!-- SELECT2 EXAMPLE -->  
          <div class="card-header">
            <h3 class="card-title">Add Customer</h3>

            <div class="card-tools">
              <button type="button" class="btn btn-tool" data-card-widget="collapse">
                <i class="fas fa-minus"></i>
              </button>
            </div>
          </div><!-- /.card-header -->      
         
            <div class="card-body">
              
            <div class="row">
              <div class="col-md-6"> 
                   <div class="form-group">
                  <label id="supidlbl" runat="server">Customer ID</label>               
                
 <asp:TextBox ID="txtcusid" runat="server" Class="form-control" placeholder="Customer ID" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="form-group">
                  <label>Customer Name</label>
                    <asp:TextBox ID="txtFullName" runat="server" Class="form-control" placeholder="Customer Name"></asp:TextBox>
                </div><!-- /.form-group -->
                
                <div class="form-group">
                  <label>Mobile Number</label>
                    <asp:TextBox ID="txtmobile" runat="server" Class="form-control" placeholder="Mobile"></asp:TextBox>
                </div><!-- /.form-group --> 
                   <div class="form-group">
                  <label>NIC</label>
                    <asp:TextBox ID="txtnic" runat="server" Class="form-control" placeholder="NIC"></asp:TextBox>
                </div>
                <div class="form-group">
                  <label>Email</label>
                    <asp:TextBox ID="txtemail" runat="server" Class="form-control" placeholder="Email"></asp:TextBox>
                </div>                  
                  <div class="form-group">
                  <label>Address</label>
                    <asp:TextBox ID="txtaddress" runat="server" Class="form-control" placeholder="Address"></asp:TextBox>
                </div><!-- /.form-group -->

              </div><!-- /.col -->

              
              <div class="col-md-6">
                <div class="form-group">
                  <label>Gender</label>
                    <asp:DropDownList ID="ddlgender" runat="server" Class="form-control">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                            <%--<asp:ListItem>Manager</asp:ListItem>--%>
                    </asp:DropDownList>
                </div><!-- /.form-group -->
                
                <div class="form-group">
                  <label>Amount</label>
                    <asp:TextBox ID="txtamt" runat="server" Class="form-control" placeholder="0.00"></asp:TextBox>
                </div><!-- /.form-group -->       
              </div><!-- /.col -->        
            </div><!-- /.row -->          
          </div><!-- /.card-body -->
          
          <div class="card-footer">  
              <asp:Button ID="btnSave" runat="server" Class="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
               <asp:Button ID="btnupdate" runat="server" Class="btn btn-warning" Text="Update"/>
              <asp:Button ID="btndelete" runat="server" Class="btn btn-danger" Text="Delete"/>
          </div>            
        </div><!-- /.card -->
       
           <div class="row">
          <div class="col-12">
            <div class="card">
              <div class="card-header">
                <h3 class="card-title">User Table</h3>

                <div class="card-tools">
                  <div class="input-group input-group-sm" style="width: 200px;">
                    <%--<input type="text" name="table_search" class="form-control float-right" placeholder="Search">--%>
                      <asp:TextBox ID="txtSearch" runat="server" Class="form-control float-right" placeholder="Search By Supplier Name" ></asp:TextBox>

                    <div class="input-group-append">
                      <button type="submit" id="Button1" runat="server" Class="btn btn-default">
                        <%--<asp:Button ID="Button1" runat="server" Class="btn btn-default" OnClick="btnsrch_Click">--%>
                        <i class="fas fa-search"></i>
                       </button>
                     
                    </div>
                  </div>
                </div>
              </div><!-- /.card-header -->
              
              <div class="card-body table-responsive p-0" style="height: 300px;">
                  <asp:GridView ID="gvsuplier" runat="server" Class="table table-head-fixed text-nowrap" GridLines="Horizontal" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" AutoGenerateSelectButton="true">
                      <Columns>
                          <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
                          <asp:BoundField DataField="Address" HeaderText="Address" />
                          <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                          <asp:BoundField DataField="email" HeaderText="Email" />
                          <asp:BoundField DataField="gender" HeaderText="Gender" />
                          <asp:BoundField DataField="nic" HeaderText="NIC" />
                          <asp:BoundField DataField="amt" HeaderText="Amount" />
                          
                      </Columns>
                  </asp:GridView>
              
              </div> <!-- /.card-body -->
             
            </div><!-- /.card -->
            
          </div>
        </div><!-- /.row -->
          
          
        </div><!--container-fluid-->
        </div><!--/.content-wrapper-->
      </form> 
    </asp:Content>

