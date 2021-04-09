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
                  <label>Customer Name</label>
                    <asp:TextBox ID="txtFullName" runat="server" Class="form-control" placeholder="Name"></asp:TextBox>
                </div><!-- /.form-group -->
                
                <div class="form-group">
                  <label>Mobile Number</label>
                    <asp:TextBox ID="txtUserName" runat="server" Class="form-control" placeholder="Mobile"></asp:TextBox>
                </div><!-- /.form-group --> 
                  
                  <div class="form-group">
                  <label>Address</label>
                    <asp:TextBox ID="TextBox1" runat="server" Class="form-control" placeholder="Address"></asp:TextBox>
                </div><!-- /.form-group -->

              </div><!-- /.col -->

              
              <div class="col-md-6">
                <div class="form-group">
                  <label>Gender</label>
                    <asp:DropDownList ID="ddlUserLevel" runat="server" Class="form-control">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                            <%--<asp:ListItem>Manager</asp:ListItem>--%>
                    </asp:DropDownList>
                </div><!-- /.form-group -->
                
                <div class="form-group">
                  <label>Amount</label>
                    <asp:TextBox ID="txtPassword" runat="server" Class="form-control" placeholder="0.00"></asp:TextBox>
                </div><!-- /.form-group -->       
              </div><!-- /.col -->        
            </div><!-- /.row -->          
          </div><!-- /.card-body -->
          
          <div class="card-footer">  
              <asp:Button ID="btnSave" runat="server" Class="btn btn-primary" Text="Save" />
               <asp:Button ID="btnupdate" runat="server" Class="btn btn-warning" Text="Update"/>
              <asp:Button ID="btndelete" runat="server" Class="btn btn-danger" Text="Delete"/>
          </div>            
        </div><!-- /.card -->
       
          
        </div><!--container-fluid-->
        </div><!--/.content-wrapper-->
      </form> 
    </asp:Content>

