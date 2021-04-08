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
                    <asp:TextBox ID="txtFullName" runat="server" Class="form-control" placeholder="Name"></asp:TextBox>
                </div><!-- /.form-group -->
                
                <div class="form-group">
                  <label>Company Address</label>
                    <asp:TextBox ID="txtUserName" runat="server" Class="form-control" placeholder="Address"></asp:TextBox>
                </div><!-- /.form-group --> 
                  
                   <div class="form-group">
                  <label>Company Phone Number</label>
                    <asp:TextBox ID="TextBox1" runat="server" Class="form-control" placeholder="Phone Number"></asp:TextBox>
                </div><!-- /.form-group -->

                   <div class="form-group">
                  <label>Company Email</label>
                    <asp:TextBox ID="TextBox2" runat="server" Class="form-control" placeholder="Email"></asp:TextBox>
                </div><!-- /.form-group -->
              </div><!-- /.col -->

              
              <div class="col-md-6">
                 <div class="form-group">
                  <label>Rep Name</label>
                    <asp:TextBox ID="TextBox3" runat="server" Class="form-control" placeholder="Name"></asp:TextBox>
                </div><!-- /.form-group -->
                
                <div class="form-group">
                  <label>Phone Number</label>
                    <asp:TextBox ID="txtPassword" runat="server" Class="form-control" TextMode="Phone" placeholder="Phone Number"></asp:TextBox>
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
                          <asp:TextBox ID="TextBox4" runat="server" Class="form-control" placeholder="0.00"></asp:TextBox>
                      </div>
                      <!-- /.form-group -->

                      <div class="form-group">
                          <label>Credit Period</label>
                          <asp:DropDownList ID="ddlUserLevel" runat="server" Class="form-control">
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
              <asp:Button ID="btnSave" runat="server" Class="btn btn-primary" Text="Save"/>
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
               <%-- <table class="table table-head-fixed text-nowrap">
                  <thead>
                    <tr>
                      <th>ID</th>
                      <th>User</th>
                      <th>Date</th>
                      <th>Status</th>
                      <th>Reason</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                      <td>183</td>
                      <td>John Doe</td>
                      <td>11-7-2014</td>
                      <td><span class="tag tag-success">Approved</span></td>
                      <td>Bacon ipsum dolor sit amet salami venison chicken flank fatback doner.</td>
                    </tr>
                    <tr>
                      <td>219</td>
                      <td>Alexander Pierce</td>
                      <td>11-7-2014</td>
                      <td><span class="tag tag-warning">Pending</span></td>
                      <td>Bacon ipsum dolor sit amet salami venison chicken flank fatback doner.</td>
                    </tr>
                    <tr>
                      <td>657</td>
                      <td>Bob Doe</td>
                      <td>11-7-2014</td>
                      <td><span class="tag tag-primary">Approved</span></td>
                      <td>Bacon ipsum dolor sit amet salami venison chicken flank fatback doner.</td>
                    </tr>
                    <tr>
                      <td>175</td>
                      <td>Mike Doe</td>
                      <td>11-7-2014</td>
                      <td><span class="tag tag-danger">Denied</span></td>
                      <td>Bacon ipsum dolor sit amet salami venison chicken flank fatback doner.</td>
                    </tr>
                    <tr>
                      <td>134</td>
                      <td>Jim Doe</td>
                      <td>11-7-2014</td>
                      <td><span class="tag tag-success">Approved</span></td>
                      <td>Bacon ipsum dolor sit amet salami venison chicken flank fatback doner.</td>
                    </tr>
                    <tr>
                      <td>494</td>
                      <td>Victoria Doe</td>
                      <td>11-7-2014</td>
                      <td><span class="tag tag-warning">Pending</span></td>
                      <td>Bacon ipsum dolor sit amet salami venison chicken flank fatback doner.</td>
                    </tr>
                    <tr>
                      <td>832</td>
                      <td>Michael Doe</td>
                      <td>11-7-2014</td>
                      <td><span class="tag tag-primary">Approved</span></td>
                      <td>Bacon ipsum dolor sit amet salami venison chicken flank fatback doner.</td>
                    </tr>
                    <tr>
                      <td>982</td>
                      <td>Rocky Doe</td>
                      <td>11-7-2014</td>
                      <td><span class="tag tag-danger">Denied</span></td>
                      <td>Bacon ipsum dolor sit amet salami venison chicken flank fatback doner.</td>
                    </tr>
                  </tbody>
                </table>--%>
              </div> <!-- /.card-body -->
             
            </div><!-- /.card -->
            
          </div>
        </div><!-- /.row -->
          
          
        </div><!--container-fluid-->
        </div><!--/.content-wrapper-->
      </form> 
    </asp:Content>
