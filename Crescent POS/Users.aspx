<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Crescent_POS.Users" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" Class="content-wrapper">
    <form runat="server">
    <div class="content-wrapper"><!--Content Wrapper. Contains page content-->   
    <div class="content-header"><!-- Content Header (Page header) -->
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">Users</h1>
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
        <div class="alert alert-warning alert-dismissible" ID="wrninguname" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-exclamation-triangle"></i> Alert!</h5>
                 Please give a User Name to save!
                </div>
         <div class="alert alert-warning alert-dismissible" id="wrningpword" runat="server"  Visible="false" style="margin-left: 8px;
    margin-right: 8px;">
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-exclamation-triangle"></i> Alert!</h5>
                 Please give a Password to save!
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
            <h3 class="card-title">Add Users</h3>

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
                  <label id="uidlbl" runat="server">User ID</label>
                 <%--<asp:TextBox ID="txtuid" runat="server" Class="form-control" placeholder="User ID" Enabled="false"></asp:TextBox>--%>
                 <input type="text" runat="server" class="form-control" id="txtuid" placeholder="User ID" disabled>
                </div>
                <div class="form-group">
                  <label>Full Name</label>
                    <asp:TextBox ID="txtFullName" runat="server" Class="form-control" placeholder="Full Name"></asp:TextBox>
                </div><!-- /.form-group -->
                
                <div class="form-group">
                  <label>User Name</label>
                    <asp:TextBox ID="txtUserName" runat="server" Class="form-control" placeholder="User Name"></asp:TextBox>
                </div><!-- /.form-group -->   
              </div><!-- /.col -->

              
              <div class="col-md-6">
                <div class="form-group">
                  <label>User Level</label>
                    <asp:DropDownList ID="ddlUserLevel" runat="server" Class="form-control">
                            <asp:ListItem>Admin</asp:ListItem>
                            <asp:ListItem>Cashier</asp:ListItem>
                            <asp:ListItem>Manager</asp:ListItem>
                    </asp:DropDownList>
                </div><!-- /.form-group -->
                
                <div class="form-group">
                  <label>Password</label>
                    <asp:TextBox ID="txtPassword" runat="server" Class="form-control" placeholder="Password"></asp:TextBox>
                </div><!-- /.form-group -->       
              </div><!-- /.col -->        
            </div><!-- /.row -->          
          </div><!-- /.card-body -->
          
          <div class="card-footer">  
              <asp:Button ID="btnSave" runat="server" Class="btn btn-primary" Text="Save" OnClick="btnSave_Click"/>
               <asp:Button ID="btnupdate" runat="server" Class="btn btn-warning" Text="Update" OnClick="btnupdate_Click"/>
              <asp:Button ID="btndelete" runat="server" Class="btn btn-danger" Text="Delete" OnClick="btndelete_Click"/>
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
                      <button type="submit" id="Button1" runat="server" Class="btn btn-default" onserverclick="btnsrch_Click">
                        <%--<asp:Button ID="Button1" runat="server" Class="btn btn-default" OnClick="btnsrch_Click">--%>
                        <i class="fas fa-search"></i>
                       </button>
                     
                    </div>
                  </div>
                </div>
              </div><!-- /.card-header -->
              
              <div class="card-body table-responsive p-0" style="height: 300px;">
                  <asp:GridView ID="gvUsers" runat="server" Class="table table-head-fixed text-nowrap" GridLines="Horizontal" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" AutoGenerateSelectButton="true" OnSelectedIndexChanged="gvUsers_SelectedIndexChanged">
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