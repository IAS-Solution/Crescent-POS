<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Supplier Payment.aspx.cs" Inherits="Crescent_POS.Supplier_Payment" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" Class="content-wrapper"> 
  <form runat="server">   
    <div class="content-wrapper"><!--Content Wrapper. Contains page content-->   
    <div class="content-header"><!-- Content Header (Page header) -->
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">Supplier Payment</h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item active">Users</li>
            </ol>
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div><!-- /.content-header -->
    

    <!-- Main content -->
      <div class="container-fluid">
           <div class="card card-default"><!-- SELECT2 EXAMPLE -->  
          <div class="card-header">
            <h3 class="card-title">Add Payment</h3>

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
                  <label>GRN ID</label>
                    <asp:DropDownList ID="ddlGRNID" runat="server" Class="form-control" OnSelectedIndexChanged="ddlGRNID_SelectedIndexChanged">
                        <asp:ListItem Value="0">--Select GRN ID--</asp:ListItem>
                    </asp:DropDownList>
                    <%--<asp:TextBox ID="TextBox4" runat="server" Class="form-control" placeholder="Full Name"></asp:TextBox>--%>
                </div><!-- /.form-group -->
                
                <div class="form-group">
                  <label>GRN Date</label>
                    <asp:TextBox ID="TextBox5" runat="server" Class="form-control" placeholder="User Name"></asp:TextBox>
                </div><!-- /.form-group --> 

                   <div class="form-group">
                  <label>Payment Date</label>
                    <asp:TextBox ID="TextBox1" runat="server" Class="form-control" placeholder="User Name"></asp:TextBox>
                </div><!-- /.form-group --> 

                   <div class="form-group">
                  <label>Company Name</label>
                    <asp:TextBox ID="TextBox2" runat="server" Class="form-control" placeholder="User Name"></asp:TextBox>
                </div><!-- /.form-group --> 

                   <div class="form-group">
                  <label>Ref Name</label>
                    <asp:TextBox ID="TextBox3" runat="server" Class="form-control" placeholder="User Name"></asp:TextBox>
                </div><!-- /.form-group --> 
                  
              </div><!-- /.col -->

              
              <div class="col-md-6">
                <div class="form-group">
                  <label>Total Amount</label>
                    <asp:TextBox ID="TextBox10" runat="server" Class="form-control" placeholder="0.00"></asp:TextBox>
                    <%--<asp:DropDownList ID="DropDownList2" runat="server" Class="form-control">
                            <asp:ListItem>Admin</asp:ListItem>
                            <asp:ListItem>Cashier</asp:ListItem>
                            <asp:ListItem>Manager</asp:ListItem>
                    </asp:DropDownList>--%>
                </div><!-- /.form-group -->
                
                <div class="form-group">
                  <label>Earlier payments</label>
                    <asp:TextBox ID="TextBox6" runat="server" Class="form-control" placeholder="0.00"></asp:TextBox>
                </div><!-- /.form-group -->
                  
                  <div class="form-group">
                  <label>Amount to be paid</label>
                    <asp:TextBox ID="TextBox7" runat="server" Class="form-control" placeholder="0.00"></asp:TextBox>
                </div><!-- /.form-group --> 

                  <div class="form-group">
                  <label>Paying Amount</label>
                    <asp:TextBox ID="TextBox8" runat="server" Class="form-control" placeholder="0.00"></asp:TextBox>
                </div><!-- /.form-group --> 

                  <div class="form-group">
                  <label>Balance</label>
                    <asp:TextBox ID="TextBox9" runat="server" Class="form-control" placeholder="0.00"></asp:TextBox>
                </div><!-- /.form-group --> 
                  
              </div><!-- /.col -->        
            </div><!-- /.row -->          
          </div><!-- /.card-body -->
          
          <div class="card-footer">  
              <asp:Button ID="Button5" runat="server" Class="btn btn-primary" Text="Save" />
               <asp:Button ID="Button6" runat="server" Class="btn btn-warning" Text="Update"/>
              <asp:Button ID="Button7" runat="server" Class="btn btn-danger" Text="Delete"/>
          </div>
        </div><!-- /.card -->
       
          
        </div><!--container-fluid-->
        </div><!--/.content-wrapper-->
      </form> 
    </asp:Content>

