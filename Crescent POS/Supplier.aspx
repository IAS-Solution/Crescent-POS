<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Supplier.aspx.cs" Inherits="Crescent_POS.Supplier" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" Class="content-wrapper"> 
  <form runat="server">   
    <div class="content-wrapper"><!--Content Wrapper. Contains page content-->   
    <div class="content-header"><!-- Content Header (Page header) -->
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">Supplier</h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item active">Supplier</li>
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
                 User Name is Empty!
                </div>
          <div class="alert alert-warning alert-dismissible" id="wrningfullname" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-exclamation-triangle"></i> Alert!</h5>
                 Please give the Full name to save!
                </div>
        <div class="alert alert-warning alert-dismissible" ID="wrningaddress" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-exclamation-triangle"></i> Alert!</h5>
                 Please give a Address to save!
                </div>
         <div class="alert alert-warning alert-dismissible" id="wrningrepphone" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-exclamation-triangle"></i> Alert!</h5>
                 Please give a Rep phone Number to save!
                </div>
         <div class="alert alert-warning alert-dismissible" id="wrningphone" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-exclamation-triangle"></i> Alert!</h5>
                 Please give a phone Number to save!
                </div>
         <div class="alert alert-warning alert-dismissible" id="wrningemail" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-exclamation-triangle"></i> Alert!</h5>
                 Please give a Email to save!
                </div>
         <div class="alert alert-warning alert-dismissible" id="wrningrepname" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-exclamation-triangle"></i> Alert!</h5>
                 Please give a Rep name to save!
                </div>
          <div class="alert alert-warning alert-dismissible" id="wrningamt" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-exclamation-triangle"></i> Alert!</h5>
                 Please give a Ammount to save!
                </div>
         <div class="alert alert-warning alert-dismissible" id="wrningunamechk" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-exclamation-triangle"></i> Alert!</h5>
                The username already exist please select a new one!
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
                  <label id="supidlbl" runat="server">Supplier ID</label>               
                
 <asp:TextBox ID="txtsupid" runat="server" Class="form-control" placeholder="Company Name" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="form-group">
                  <label>Company Name</label>
                    <asp:TextBox ID="txtFullName" runat="server" Class="form-control" placeholder="Company Name"></asp:TextBox>
                </div><!-- /.form-group -->
                
                <div class="form-group">
                  <label>Company Address</label>
                    <asp:TextBox ID="txtaddress" runat="server" Class="form-control" placeholder="Address"></asp:TextBox>
                </div><!-- /.form-group --> 
                  
                   <div class="form-group">
                  <label>Company Phone Number</label>
                    <asp:TextBox ID="txtphone" runat="server" Class="form-control" placeholder="Phone Number"></asp:TextBox>
                </div><!-- /.form-group -->

                   <div class="form-group">
                  <label>Company Email</label>
                    <asp:TextBox ID="txtemail" runat="server" Class="form-control" placeholder="Email"></asp:TextBox>
                </div><!-- /.form-group -->
              </div><!-- /.col -->

              
              <div class="col-md-6">
                 <div class="form-group">
                  <label>Rep Name</label>
                    <asp:TextBox ID="txtrepname" runat="server" Class="form-control" placeholder="Rep Name"></asp:TextBox>
                </div><!-- /.form-group -->
                
                <div class="form-group">
                  <label>Phone Number</label>
                    <asp:TextBox ID="txtrepphone" runat="server" Class="form-control" TextMode="Phone" placeholder="Phone Number"></asp:TextBox>
                </div><!-- /.form-group -->
                  
                  <div class="form-group">
                     <%-- <div class="icheck-primary">--%>
                          <%--<input type="checkbox" id="cbCredit">--%>
                          <asp:CheckBox ID="cbCredi" runat="server"  Checked="false" AutoPostBack="true" OnCheckedChanged="cbCredi_CheckedChanged" />
                          <label for="remember">
                              Credit Supplier
                          </label>
                      <%--</div>--%>
                  </div><!-- /.form-group --> 
                  
                  <asp:Panel ID="pnl1" runat="server" Visible="false">
                      <div class="form-group">
                          <label>Credit Amount</label>
                          <asp:TextBox ID="txtamt" runat="server" Class="form-control" placeholder="0.00"></asp:TextBox>
                      </div>
                      <!-- /.form-group -->

                      <div class="form-group">
                          <label>Credit Period</label>
                          <asp:DropDownList ID="ddlcreditperiod" runat="server" Class="form-control">
                            <asp:ListItem>None</asp:ListItem>
                              <asp:ListItem>1 Month</asp:ListItem>
                            <asp:ListItem>2 Month</asp:ListItem>
                            <asp:ListItem>3 Month</asp:ListItem>
                            <asp:ListItem>4 Month</asp:ListItem>
                            <asp:ListItem>5 Month</asp:ListItem>
                            <asp:ListItem>6 Month</asp:ListItem>
                    </asp:DropDownList>
                      </div>
                      <!-- /.form-group -->
                  </asp:Panel>

              </div><!-- /.col -->        
            </div><!-- /.row -->          
          </div><!-- /.card-body -->
          
          <div class="card-footer">  
              <asp:Button ID="btnSave" runat="server" Class="btn btn-primary" Text="Save"  OnClick="btnSave_Click"/>
               <asp:Button ID="btnupdate" runat="server" Class="btn btn-warning" Text="Update"/>
              <asp:Button ID="btndelete" runat="server" Class="btn btn-danger" Text="Delete"/>
              <%--<button type="button" class="btn btn-primary">Primary</button>--%>
            <%--  <button type="button" class="btn btn-secondary">Secondary</button>
              <button type="button" class="btn btn-success">Success</button>
              <button type="button" class="btn btn-danger">Danger</button>--%>
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
                          <asp:BoundField DataField="SupplierName" HeaderText="Company Name" />
                          <asp:BoundField DataField="MobileNumber" HeaderText="Company Phone No." />
                          <asp:BoundField DataField="Email" HeaderText="Email" />
                          <asp:BoundField DataField="Address" HeaderText="Address" />
                          <asp:BoundField DataField="RepName" HeaderText="Rep Name" />
                          <asp:BoundField DataField="RepPhonenum" HeaderText="Rep Phone No." />
                          <asp:BoundField DataField="Creditamt" HeaderText="Credit Amount" />
                          <asp:BoundField DataField="Creditperiod" HeaderText="Credit Period" />
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
