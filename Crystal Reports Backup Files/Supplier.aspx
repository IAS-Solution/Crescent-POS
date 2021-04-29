<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Supplier.aspx.cs" Inherits="Crescent_POS.Supplier" %>

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
      

           <div class="alert alert-warning alert-dismissible" id="wrningex" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-exclamation-triangle"></i> Alert!</h5>
                    
               <asp:Label id="lblex" runat="server"></asp:Label>
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
            <h3 class="card-title">Add Company</h3>

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
                  <label>Company ID</label>
                    <asp:Label ID="lblcid1" runat="server"></asp:Label>
                   <asp:TextBox ID="txtcid" runat="server" Class="form-control" placeholder="Company Name" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="form-group">
                  <label>Company Address</label>
                    <asp:TextBox ID="txtcaddress" runat="server" Class="form-control" placeholder="Address"></asp:TextBox>
                </div><!-- /.form-group --> 
                  
                  

                   <div class="form-group">
                  <label>Company Email</label>
                    <asp:TextBox ID="txtcemail" runat="server" Class="form-control" placeholder="Email"></asp:TextBox>
                </div><!-- /.form-group -->
              </div><!-- /.col -->
   
              <div class="col-md-6">
                  <div class="form-group">
                  <label>Company Name</label>
                    <asp:TextBox ID="txtcname" runat="server" Class="form-control" placeholder="Company Name"></asp:TextBox>
                </div><!-- /.form-group -->
                
                <div class="form-group">
                  <label>Company Phone Number</label>
                    <asp:TextBox ID="txtcphone" runat="server" Class="form-control" placeholder="Phone Number"></asp:TextBox>
                </div><!-- /.form-group -->
                  
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
                  <label id="Label1" runat="server">Supplier ID</label>                            
                 <asp:TextBox ID="txtsid" runat="server" Class="form-control"  ReadOnly="true"></asp:TextBox>
                </div>
                
               <div class="form-group">
                  <label>Phone Number</label>
                    <asp:TextBox ID="txtsphone" runat="server" Class="form-control" TextMode="Phone" placeholder="Phone Number" ReadOnly="true"></asp:TextBox>
                </div><!-- /.form-group -->
                  
                  

               
              </div><!-- /.col -->

              
              <div class="col-md-6">
                 <div class="form-group">
                  <label>Rep Name</label>
                    <asp:TextBox ID="txtsname" runat="server" Class="form-control" placeholder="Rep Name" ReadOnly="true"></asp:TextBox>
                </div><!-- /.form-group -->
                
                
                  
                  <div class="form-group">
                     <%-- <div class="icheck-primary">--%>
                          <%--<input type="checkbox" id="cbCredit">--%>
                          <asp:CheckBox ID="cbCredit" runat="server"  Checked="false" AutoPostBack="true" Enabled="false" OnCheckedChanged="cbCredit_CheckedChanged" />
                          <label for="remember">
                              Credit Supplier
                          </label>
                      <%--</div>--%>
                  </div><!-- /.form-group --> 
                  
                  <asp:Panel ID="pnl1" runat="server" Visible="false">
                      <div class="form-group">
                          <label>Credit Amount</label>
                          <asp:TextBox ID="txtcamount" runat="server" Class="form-control" placeholder="0.00"></asp:TextBox>
                      </div>
                      <!-- /.form-group -->

                      <div class="form-group">
                          <label>Credit Period</label>
                          <asp:DropDownList ID="ddlcperiod" runat="server" Class="form-control">
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
              <asp:Button ID="btn" runat="server" Class="btn btn-primary"  Text="ADD" OnClick="btn_Click"/>
               <asp:Button ID="Button3" runat="server" Class="btn btn-warning" Text="Update"/>
              <asp:Button ID="Button4" runat="server" Class="btn btn-danger" Text="Delete"/>
              <%--<button type="button" class="btn btn-primary">Primary</button>--%>
            <%--  <button type="button" class="btn btn-secondary">Secondary</button>
              <button type="button" class="btn btn-success">Success</button>
              <button type="button" class="btn btn-danger">Danger</button>--%>
          </div>
               
               <div style="height:250px;">
                <asp:GridView ID="gvsupp" runat="server" Class="table table-head-fixed text-nowrap"  GridLines="Horizontal" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" AutoGenerateSelectButton="true" >
                      <Columns>
                          <asp:BoundField DataField="id" HeaderText="ID" />
                          <asp:BoundField DataField="repname" HeaderText="Ref Name" />
                          <asp:BoundField DataField="repphonenum" HeaderText="Phone No." />
                          <asp:BoundField DataField="creditperiod" HeaderText="Period" />
                          <asp:BoundField DataField="creditamt" HeaderText="Amount" />
                      </Columns>
                  </asp:GridView>
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
                  <asp:GridView ID="gvcompany" runat="server" Class="table table-head-fixed text-nowrap" GridLines="Horizontal" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" AutoGenerateSelectButton="true" OnSelectedIndexChanged="gvcompany_SelectedIndexChanged">
                      <Columns>
                          <asp:BoundField DataField="id" HeaderText="ID" />
                          <asp:BoundField DataField="cName" HeaderText="Company Name" />
                          <asp:BoundField DataField="cAddress" HeaderText="Address" />
                          <asp:BoundField DataField="cemail" HeaderText="Email" />
                          <asp:BoundField DataField="cnumber" HeaderText="Phone No." />
                      </Columns>
                  </asp:GridView>
              
              </div> <!-- /.card-body -->
             
            </div><!-- /.card -->
            
          </div>
        </div><!-- /.row -->
          
        </div><!--container-fluid-->
        </div><!--/.content-wrapper-->
              </ContentTemplate>
          </asp:UpdatePanel>
      </form> 
    </asp:Content>
