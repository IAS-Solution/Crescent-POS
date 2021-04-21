<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GRN.aspx.cs" Inherits="Crescent_POS.GRN" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" Class="content-wrapper"> 
    <form runat="server">  
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <div class="content-wrapper"><!--Content Wrapper. Contains page content-->   
    <div class="content-header"><!-- Content Header (Page header) -->
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <%--<h1 class="m-0">GRN</h1>--%>
              <p>GRN ID :&nbsp;&nbsp;<asp:Label ID="lblGRNID" runat="server" Text=""></asp:Label></p>
              <p>Date :&nbsp;&nbsp;<asp:Label ID="lblDate" runat="server" Text="date"></asp:Label></p>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item active">GRN</li>
            </ol>
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div><!-- /.content-header -->
    

    <!-- Main content -->
      <div class="container-fluid">
           <div class="card card-default"><!-- SELECT2 EXAMPLE -->  
          <div class="card-header">
            <h3 class="card-title">Add Supplier</h3>

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
                  <label>Supplier ID</label>
                    <asp:DropDownList ID="ddlSupplierID" runat="server" Class="form-control">
                    </asp:DropDownList>
                </div><!-- /.form-group -->
                
                <div class="form-group">
                  <label>Company Name</label>
                    <asp:TextBox ID="txtUserName" runat="server" Class="form-control" placeholder="Company Name"></asp:TextBox>
                </div><!-- /.form-group -->   
              </div><!-- /.col -->

              
              <div class="col-md-6">
                <div class="form-group">
                  <label>Rep Name</label>
                    <asp:DropDownList ID="ddlUserLevel" runat="server" Class="form-control">
                            <asp:ListItem>Admin</asp:ListItem>
                            <asp:ListItem>Cashier</asp:ListItem>
                            <asp:ListItem>Manager</asp:ListItem>
                    </asp:DropDownList>
                </div><!-- /.form-group -->
                
                <%--<div class="form-group">
                  <label>Password</label>
                    <asp:TextBox ID="txtPassword" runat="server" Class="form-control" placeholder="Password"></asp:TextBox>
                </div><!-- /.form-group --> --%>      
              </div><!-- /.col -->        
            </div><!-- /.row -->          
          </div><!-- /.card-body -->
          
          <%--<div class="card-footer">  
              <asp:Button ID="btnSave" runat="server" Class="btn btn-primary" Text="Save" />
               <asp:Button ID="btnupdate" runat="server" Class="btn btn-warning" Text="Update"/>
              <asp:Button ID="btndelete" runat="server" Class="btn btn-danger" Text="Delete"/>
          </div>--%>
        </div><!-- /.card -->


           <div class="card card-default"><!-- SELECT2 EXAMPLE -->  
          <div class="card-header">
            <h3 class="card-title">Add Product</h3>

            <div class="card-tools">
              <button type="button" class="btn btn-tool" data-card-widget="collapse">
                <i class="fas fa-minus"></i>
              </button>
            </div>
          </div><!-- /.card-header -->      
         
            <div class="card-body">
              
                  <div class="row">

              <div class="col-md-3"> 
                <div class="form-group">
                  <label>Product Code</label>
                    <asp:TextBox ID="TextBox1" runat="server" Class="form-control" placeholder="Product Code"></asp:TextBox>
                </div><!-- /.form-group -->
              </div><!-- /.col -->


                      <div class="col-md-3">
                          <div class="form-group">
                  <label>Bar Code</label>
                    <asp:TextBox ID="TextBox3" runat="server" Class="form-control" placeholder="10012791289"></asp:TextBox>
                </div><!-- /.form-group -->
              </div><!-- /.col -->


                      <div class="col-md-3">
                          <div class="form-group">
                  <label>Brand</label>
                    <asp:TextBox ID="txtBrand" runat="server" Class="form-control"></asp:TextBox>
                              <ajaxToolkit:AutoCompleteExtender ServiceMethod="SearchBrand" MinimumPrefixLength="2" CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="txtBrand" ID="AutoCompleteExtender1" runat="server">
                              </ajaxToolkit:AutoCompleteExtender>
                              <%--<asp:AutoCompleteExtender ServiceMethod="GetCompletionList" MinimumPrefixLength="1"  
   CompletionInterval="10" EnableCaching="false" CompletionSetCount="1" TargetControlID="TextBox1"  
   ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">  
      </asp:AutoCompleteExtender>  --%>

                              <%--<ajaxToolkit:ComboBox ID="cmbBrand" runat="server"  DataSourceID="" DataTextField="brand" DataValueField="brand" AutoCompleteMode="SuggestAppend">
                             <%--</ajaxToolkit:ComboBox>--%>
                              <%--<asp:SqlDataSource ID="sdsBrand" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnection %>" SelectCommand="select distinct [brand] from grnproduct"></asp:SqlDataSource>--%>
                            
                    <%--<asp:DropDownList ID="DropDownList1" runat="server" Class="form-control">
                            <asp:ListItem>Admin</asp:ListItem>
                            <asp:ListItem>Cashier</asp:ListItem>
                            <asp:ListItem>Manager</asp:ListItem>
                    </asp:DropDownList>--%>
                </div><!-- /.form-group -->
                      </div><!-- /.col -->

                        <div class="col-md-3">
                         <div class="form-group">
                  <label>Category</label>
                    <asp:DropDownList ID="DropDownList3" runat="server" Class="form-control">
                            <asp:ListItem>Admin</asp:ListItem>
                            <asp:ListItem>Cashier</asp:ListItem>
                            <asp:ListItem>Manager</asp:ListItem>
                    </asp:DropDownList>
                </div><!-- /.form-group -->
                      </div><!-- /.col -->


                      <div class="col-md-12">
                          <div class="form-group">
                              <label>Description</label>
                              <asp:TextBox ID="TextBox5" runat="server" Class="form-control" placeholder="Description"></asp:TextBox>
                          </div>
                          <!-- /.form-group -->
                      </div><!-- /.col -->

              
              <div class="col-md-3">
                     <div class="form-group">
                  <label>Cost Price</label>
                    <asp:TextBox ID="txtCostPrice" runat="server" Class="form-control" placeholder="0.00" Width="175px"></asp:TextBox>
                </div><!-- /.form-group --> 
              </div><!-- /.col -->

                      <div class="col-md-3">
                       <div class="form-group">
                  <label>QTY</label>
                    <asp:TextBox ID="txtQty" runat="server" Class="form-control" placeholder="0" Width="75px" TextMode="Number" OnTextChanged="txtQty_TextChanged" AutoPostBack="true"></asp:TextBox>
                </div><!-- /.form-group -->
              </div><!-- /.col -->

                      <div class="col-md-3">
                       <div class="form-group">
                  <label>Total Price</label>
                    <asp:TextBox ID="txtTotalPrice" runat="server" Class="form-control" placeholder="0.00" Width="175px"></asp:TextBox>
                </div><!-- /.form-group -->
              </div><!-- /.col -->

                      <div class="col-md-3">
                      <div class="form-group">
                  <label>Selling Price</label>
                    <asp:TextBox ID="TextBox8" runat="server" Class="form-control" placeholder="0.00" Width="175px"></asp:TextBox>
                </div><!-- /.form-group --> 
              </div><!-- /.col -->


                <%-- <div class="col-md-3">    
              </div><!-- /.col -->--%>
                
            </div><!-- /.row -->
                      
          </div><!-- /.card-body -->
          
          <div class="card-footer">  
              <asp:Button ID="Button2" runat="server" Class="btn btn-primary" Text="ADD" />
               <asp:Button ID="Button3" runat="server" Class="btn btn-warning" Text="Update"/>
              <asp:Button ID="Button4" runat="server" Class="btn btn-danger" Text="Delete"/>
          </div>
        </div><!-- /.card -->



          <%-- <div class="card card-default"><!-- SELECT2 EXAMPLE -->  
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
                  <label>Full Name</label>
                    <asp:TextBox ID="TextBox4" runat="server" Class="form-control" placeholder="Full Name"></asp:TextBox>
                </div><!-- /.form-group -->
                
                <div class="form-group">
                  <label>User Name</label>
                    <asp:TextBox ID="TextBox5" runat="server" Class="form-control" placeholder="User Name"></asp:TextBox>
                </div><!-- /.form-group -->   
              </div><!-- /.col -->

              
              <div class="col-md-6">
                <div class="form-group">
                  <label>User Level</label>
                    <asp:DropDownList ID="DropDownList2" runat="server" Class="form-control">
                            <asp:ListItem>Admin</asp:ListItem>
                            <asp:ListItem>Cashier</asp:ListItem>
                            <asp:ListItem>Manager</asp:ListItem>
                    </asp:DropDownList>
                </div><!-- /.form-group -->
                
                <div class="form-group">
                  <label>Password</label>
                    <asp:TextBox ID="TextBox6" runat="server" Class="form-control" placeholder="Password"></asp:TextBox>
                </div><!-- /.form-group -->       
              </div><!-- /.col -->        
            </div><!-- /.row -->          
          </div><!-- /.card-body -->
          
          <div class="card-footer">  
              <asp:Button ID="Button5" runat="server" Class="btn btn-primary" Text="Save" />
               <asp:Button ID="Button6" runat="server" Class="btn btn-warning" Text="Update"/>
              <asp:Button ID="Button7" runat="server" Class="btn btn-danger" Text="Delete"/>
          </div>
        </div><!-- /.card -->--%>



            <div class="row">
          <div class="col-12">
            <div class="card">
              <div class="card-header">
                <h3 class="card-title">GRN Table</h3>

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


