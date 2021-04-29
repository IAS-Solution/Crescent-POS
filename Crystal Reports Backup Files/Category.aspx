<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="Crescent_POS.Category" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" Class="content-wrapper"> 
  <form runat="server">   
    <div class="content-wrapper"><!--Content Wrapper. Contains page content-->   
    <div class="content-header"><!-- Content Header (Page header) -->
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">Category</h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item active">Category</li>
            </ol>
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div><!-- /.content-header -->
    

    <!-- Main content -->
      <div class="container-fluid">
           <div class="card card-default"><!-- SELECT2 EXAMPLE -->  
          <div class="card-header">
            <h3 class="card-title">Add Brand</h3>

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
                  <label>Category</label>
                    <asp:TextBox ID="txtFullName" runat="server" Class="form-control" placeholder="Category"></asp:TextBox>
                </div><!-- /.form-group -->
              </div><!-- /.col -->
   
            </div><!-- /.row -->
                
          </div><!-- /.card-body -->
          
          <div class="card-footer">  
              <asp:Button ID="btnSave" runat="server" Class="btn btn-primary" Text="Save"/>
               <asp:Button ID="btnupdate" runat="server" Class="btn btn-warning" Text="Update"/>
              <asp:Button ID="btndelete" runat="server" Class="btn btn-danger" Text="Delete"/>
          </div>            
        </div><!-- /.card -->


           <div class="row">
          <div class="col-12">
            <div class="card">
              <div class="card-header">
                <h3 class="card-title">Category Table</h3>

                <div class="card-tools">
                  <div class="input-group input-group-sm" style="width: 200px;">
                    <%--<input type="text" name="table_search" class="form-control float-right" placeholder="Search">--%>
                      <asp:TextBox ID="txtSearch" runat="server" Class="form-control float-right" placeholder="Search By User Name" ></asp:TextBox>

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
                  <asp:GridView ID="gvUsers" runat="server" Class="table table-head-fixed text-nowrap" GridLines="Horizontal" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" AutoGenerateSelectButton="true">
                      <Columns>
                          <asp:BoundField DataField="Full_name" HeaderText="Full Name" />
                          <asp:BoundField DataField="user_name" HeaderText="User Name" />
                          <asp:BoundField DataField="user_level" HeaderText="User Level" />
                          <asp:BoundField DataField="password" HeaderText="Password" />
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


