<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GRN.aspx.cs" Inherits="Crescent_POS.GRN" %>


<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" tagPrefix="ajax" %> 


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" Class="content-wrapper"> 
    <form runat="server">  
        <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="updatepnl" runat="server">
            <ContentTemplate>
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
    
         <div class="alert alert-success alert-dismissible" ID="savealert" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px; "> 
        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-check"></i> Alert!</h5>
                  GRN Data inserted successfully!
   </div>
         <div class="alert alert-success alert-dismissible" ID="savealert2" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px; "> 
        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-check"></i> Alert!</h5>
                  Stock Data inserted successfully!
   </div>
         <div class="alert alert-success alert-dismissible" ID="savealert1" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px; "> 
        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-check"></i> Alert!</h5>
                  Product Data inserted successfully!
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
                BarCode is Empty!
                </div>
          
        <div class="alert alert-warning alert-dismissible" id="wrningex" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-exclamation-triangle"></i> Alert!</h5>
                    
               <asp:Label id="lblex" runat="server"></asp:Label>
                </div>
         <div class="alert alert-warning alert-dismissible" id="wrningtxtQty" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-exclamation-triangle"></i> Alert!</h5>
                 Please Give a QTY to Add!
                </div>
        
         <div class="alert alert-warning alert-dismissible" id="wrningtxtCostPrice" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-exclamation-triangle"></i> Alert!</h5>
                 Please give a Cost Price to Add!
                </div>
         <div class="alert alert-warning alert-dismissible" id="wrningdes" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-exclamation-triangle"></i> Alert!</h5>
                 Please give a Description to Add!
                </div>
         <div class="alert alert-warning alert-dismissible" id="wrningtxtTotalPrice" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-exclamation-triangle"></i> Alert!</h5>
                 Please give a Total Price to Add!
                </div>
          <div class="alert alert-warning alert-dismissible" id="wrningamt" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-exclamation-triangle"></i> Alert!</h5>
                 Please give a Selling Price to save!
                </div>
         <div class="alert alert-warning alert-dismissible" id="wrningbarcodedup" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-exclamation-triangle"></i> Alert!</h5>
                 Bar Code is Duplicated!
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
                  <label>Company Name</label>
                    <asp:DropDownList ID="ddlSupplierID" runat="server" Class="form-control" DataTextField="cname" AppendDataBoundItems="true" DataValueField="id" OnTextChanged="ddlSupplierID_TextChanged" AutoPostBack="true">
                        <asp:ListItem Value="0">--Select Company Name--</asp:ListItem>
                    </asp:DropDownList>
                </div><!-- /.form-group -->
                
                <%--<div class="form-group">
                  <label>Company Name</label>
                    <asp:TextBox ID="txtUserName" runat="server" Class="form-control" placeholder="Company Name"></asp:TextBox>
                </div><!-- /.form-group --> --%>  
              </div><!-- /.col -->

              
              <div class="col-md-6">
                <div class="form-group">
                  <label>Rep Name</label>
                    <asp:DropDownList ID="ddlUserLevel" runat="server" DataValueField="id" DataTextField="repname" AppendDataBoundItems="true" Class="form-control">
                         <asp:ListItem Value="0">--Select Rep Name--</asp:ListItem>
                            <%--<asp:ListItem>Admin</asp:ListItem>
                            <asp:ListItem>Cashier</asp:ListItem>
                            <asp:ListItem>Manager</asp:ListItem>--%>
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
                  <label>Product ID</label>
                    <asp:TextBox ID="txtprdctid" runat="server" Class="form-control" placeholder="Product ID" ReadOnly="false"></asp:TextBox>
                </div><!-- /.form-group -->
              </div><!-- /.col -->


                      <div class="col-md-3">
                          <div class="form-group">
                  <label>Bar Code</label>
                    <asp:TextBox ID="txtbarcode" runat="server" Class="form-control" placeholder="Barcode"></asp:TextBox>
                </div><!-- /.form-group -->
              </div><!-- /.col -->


                      <div class="col-md-3">
                          <div class="form-group">
                  <label>Brand</label>
                    <asp:TextBox ID="txtBrand" runat="server" Class="form-control"></asp:TextBox>
                           <ajax:AutoCompleteExtender ServiceMethod="SearchBrand" MinimumPrefixLength="1" CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="txtBrand" ID="AutoCompleteExtender1" runat="server">
                           </ajax:AutoCompleteExtender> 
                          
                </div><!-- /.form-group -->
                      </div><!-- /.col -->

                        <div class="col-md-3">
                         <div class="form-group">
                  <label>Category</label>
                             <asp:TextBox ID="txtCategory" runat="server" Class="form-control"></asp:TextBox>
                              <ajax:AutoCompleteExtender ServiceMethod="SearchCategory" MinimumPrefixLength="1" CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="txtCategory" ID="AutoCompleteExtender2" runat="server">
                              </ajax:AutoCompleteExtender>
                    <%--<asp:DropDownList ID="DropDownList3" runat="server" Class="form-control">
                            <asp:ListItem>Admin</asp:ListItem>
                            <asp:ListItem>Cashier</asp:ListItem>
                            <asp:ListItem>Manager</asp:ListItem>
                    </asp:DropDownList>--%>
                </div><!-- /.form-group -->
                      </div><!-- /.col -->


                      <div class="col-md-12">
                          <div class="form-group">
                              <label>Description</label>
                              <asp:TextBox ID="txtdes" runat="server" Class="form-control" placeholder="Description"></asp:TextBox>
                          </div>
                          <!-- /.form-group -->
                      </div><!-- /.col -->

              
              <div class="col-md-3">
                     <div class="form-group">
                  <label>Cost Price</label>
                    <asp:TextBox ID="txtCostPrice" runat="server" Class="form-control" placeholder="0.00" Width="175px" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
                </div><!-- /.form-group --> 
              </div><!-- /.col -->

                      <div class="col-md-3">
                       <div class="form-group">
                  <label>QTY</label>
                           
                    <asp:TextBox ID="txtQty" runat="server" Class="form-control" onchange="calctxtboxes()" placeholder="0" Width="75px" TextMode="Number" ></asp:TextBox>
              <%-- <script type="text/javascript">
    function calctxtboxes() {
        var cp = document.getElementById('<%=txtCostPrice.ClientID%>').value;
        var qty = document.getElementById('<%=txtQty.ClientID%>').value;
      
        if (cp != "" && qty !="") {
            var tot = cp * qty;
            document.getElementById('<%=txtTotalPrice.ClientID%>').value = tot;
           
            
        }
    }
</script>--%>
        </div>
                          <!-- /.form-group -->

              </div><!-- /.col -->

                      <div class="col-md-3">
                       <div class="form-group">
                  <label>Total Price</label>
                    <asp:TextBox ID="txtTotalPrice" runat="server" Class="form-control" placeholder="0.00" Width="175px" ReadOnly="true" ></asp:TextBox>
                          
                </div><!-- /.form-group -->
              </div><!-- /.col -->

                      <div class="col-md-3">
                      <div class="form-group">
                  <label>Selling Price</label>
                    <asp:TextBox ID="TextBox8" runat="server" Class="form-control" placeholder="0.00" Width="175px" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
                </div><!-- /.form-group --> 
              </div><!-- /.col -->


                <%-- <div class="col-md-3">    
              </div><!-- /.col -->--%>
                
            </div><!-- /.row -->
                      
          </div><!-- /.card-body -->
          
          <div class="card-footer">  
              <asp:Button ID="addbtn" runat="server" Class="btn btn-primary" Text="Add Product" OnClick="addbtn_Click" />
               <asp:Button ID="updatebtn" runat="server" Class="btn btn-warning" Text="Update Product"/>
             
              <br /> <br />
              <div id="gvprdctdiv1" runat="server"  Visible="false" >
           <div class="card" >
              <div class="card-header" id="gvprdctdiv" runat="server"  Visible="false">
                <h3 class="card-title">Product Table</h3>
                 </div><!-- /.card-header -->
              
              <div class="card-body table-responsive p-0" style="height: 300px;" >
                  <asp:GridView ID="prdctgv" runat="server" Class="table table-head-fixed text-nowrap" GridLines="Horizontal"  AutoGenerateSelectButton="true" AutoGenerateDeleteButton="true" OnRowDeleting="prdctgv_RowDeleting">
                    
                  </asp:GridView>
              </div> <!-- /.card-body -->
              
            </div>
                  </div>
               <div>


                   <asp:Button ID="Button2" runat="server" Class="btn btn-primary" Text="Save" OnClick="savebtn_Click" />
               <asp:Button ID="Button3" runat="server" Class="btn btn-warning" Text="Update"/>
              <asp:Button ID="Button4" runat="server" Class="btn btn-danger" Text="Delete"/>
               </div>


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
                  <asp:GridView ID="gvgrn" runat="server" Class="table table-head-fixed text-nowrap" GridLines="Horizontal" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                      <Columns>
                          <asp:BoundField DataField="GRNID" HeaderText="GRN ID" />
                          <asp:BoundField DataField="Date" HeaderText="Date" />
                          <asp:BoundField DataField="Company" HeaderText="Company Name" />
                          <asp:BoundField DataField="refname" HeaderText="Ref Name" />
                      </Columns>
                  </asp:GridView>
              </div> <!-- /.card-body -->
             
            </div><!-- /.card -->
            
          </div>
        </div><!-- /.row -->
      </div>    
            </div><!-- /SELECT2 EXAMPLE --> 
        </div><!--container-fluid-->
        </div><!--/.content-wrapper-->
                </ContentTemplate>
            </asp:UpdatePanel>
      </form> 
    </asp:Content>


