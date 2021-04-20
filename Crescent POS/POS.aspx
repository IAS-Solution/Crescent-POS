<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="POS.aspx.cs" Inherits="Crescent_POS.POS" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" Class="content-wrapper"> 
  <form runat="server">   
    <div class="content-wrapper"><!--Content Wrapper. Contains page content-->   
    <div class="content-header"><!-- Content Header (Page header) -->
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <%--<h1 class="m-0">POS</h1>--%>
              <p>Invoice No:</p>
              <p>Date :&nbsp;&nbsp;<asp:Label ID="lblDate" runat="server" Text="date"></asp:Label></p>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <%--<li class="breadcrumb-item"><a href="#">Home</a></li>--%>
              <li class="breadcrumb-item active">2,000.00</li>
            </ol>
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div><!-- /.content-header -->
    

    <!-- Main content -->
      <div class="container-fluid">
          
          <div class="row">
          <div class="col-12">
            <div class="card">
              <div class="card-header">
                  <asp:TextBox ID="txtBarCodeSearch" runat="server" Class="form-control" placeholder="Search Bar code Here"  Width="250px" AutoPostBack="true" OnTextChanged="txtBarCodeSearch_TextChanged"></asp:TextBox>
                <%--<h3 class="card-title">Product Table</h3>--%>

                <div class="card-tools">
                  <div class="input-group input-group-sm" style="width: 200px;">
                    <%--<input type="text" name="table_search" class="form-control float-right" placeholder="Search">--%>
                      

                    <div class="input-group-append">
                     <%-- <button type="submit" id="Button1" runat="server" Class="btn btn-default">
                        <i class="fas fa-search"></i>
                       </button>--%>
                    </div>
                  </div>
                </div>
              </div><!-- /.card-header -->
              
              <div class="card-body table-responsive p-0" style="height: 160px;">
                  <asp:GridView ID="gvUsers" runat="server" Class="table table-head-fixed text-nowrap" GridLines="Horizontal" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" AutoGenerateSelectButton="true">
                      <Columns>
                          <asp:BoundField DataField="Full_name" HeaderText="Description" />
                          <asp:BoundField DataField="user_name" HeaderText="Qty" />
                          <asp:BoundField DataField="user_level" HeaderText="Rate" />
                          <asp:BoundField DataField="password" HeaderText="Amount" />
                      </Columns>
                  </asp:GridView>
              </div> <!-- /.card-body -->
             
            </div><!-- /.card -->
            
          </div>
        </div><!-- /.row -->


          <div class="row">
          <div class="col-6">
            <div class="card">
              <div class="card-header">
                  <asp:TextBox ID="txtPhoneSearch" runat="server" Class="form-control float-sm-right" placeholder="Search Customer Phone Number" AutoPostBack="true"  Width="260px" OnTextChanged="txtPhoneSearch_TextChanged"></asp:TextBox>
                  <h5 class="card-title">Customer Type</h5>

                <div class="card-tools">
                  <div class="input-group input-group-sm" style="width: 210px;">
                    <%--<input type="text" name="table_search" class="form-control float-right" placeholder="Search">--%>
                      

                    <div class="input-group-append">
                     <%-- <button type="submit" id="Button1" runat="server" Class="btn btn-default">
                        <i class="fas fa-search"></i>
                       </button>--%>
                    </div>
                  </div>
                </div>
              </div><!-- /.card-header -->
              
              <div class="card-body table-responsive p-0" style="height: 200px;">

                   <div class="form-check form-check-inline m-2">
                          <input class="form-check-input" type="radio" name="inlineRadioOptions" id="rdGuest" value="option1"  runat="server">
                          <label class="form-check-label" for="inlineRadio1">Guest</label>
                      </div>
                      <div class="form-check form-check-inline">
                          <input class="form-check-input" type="radio" name="inlineRadioOptions" id="rdLoyalty" value="option2" runat="server">
                          <label class="form-check-label" for="inlineRadio2">Loyalty Coustomer</label>
                      </div>

                  <div class="form-group form-inline m-2">
                      <label>Customer Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                      <asp:TextBox ID="txtCustomerName" runat="server" Class="form-control" placeholder="Name"></asp:TextBox>
                  </div><!-- /.form-group -->
                  
                  <div class="form-group form-inline m-2">
                  <label>Customer ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                    <asp:TextBox ID="txtCustomerID" runat="server" Class="form-control" placeholder="ID"></asp:TextBox>
                </div><!-- /.form-group -->
                  
                  <div class="form-group form-inline m-2">
                  <label>Previous Receivable&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                    <asp:TextBox ID="txtPreReceivable" runat="server" Class="form-control" placeholder="0.00"></asp:TextBox>
                </div><!-- /.form-group -->
                  
                 <%-- <div class="form-group form-inline m-2">
                  <label>Full Name</label>
                    <asp:TextBox ID="TextBox7" runat="server" Class="form-control" placeholder="Full Name"></asp:TextBox>
                </div><!-- /.form-group -->--%>
                  
              </div> <!-- /.card-body -->
             
            </div><!-- /.card -->
            
          </div>

              <div class="col-6">
            <div class="card">
              <div class="card-header">
                  <%--<asp:TextBox ID="TextBox2" runat="server" Class="form-control" placeholder="Search Bar code Here"  Width="250px"></asp:TextBox>--%>
                <h5 class="card-title">Settle Bill</h5>

                <div class="card-tools">
                  <div class="input-group input-group-sm" style="width: 250px;">
                    <%--<input type="text" name="table_search" class="form-control float-right" placeholder="Search">--%>
                      <div class="form-check form-check-inline">
                          <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio1" value="option1">
                          <label class="form-check-label" for="inlineRadio1">Cash</label>
                      </div>
                      <div class="form-check form-check-inline">
                          <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio2" value="option2">
                          <label class="form-check-label" for="inlineRadio2">Card</label>
                      </div>
                      <div class="form-check form-check-inline">
                          <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio3" value="option3">
                          <label class="form-check-label" for="inlineRadio2">Cheque</label>
                      </div>

                    <div class="input-group-append">
                     <%-- <button type="submit" id="Button1" runat="server" Class="btn btn-default">
                        <i class="fas fa-search"></i>
                       </button>--%>
                    </div>
                  </div>
                </div>
              </div><!-- /.card-header -->
              
              <div class="card-body table-responsive p-0" style="height: 240px;">
                  
                   <div class="form-group form-inline m-2 ">
                  <label>Amount&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                    <asp:TextBox ID="txtAmount" runat="server" Class="form-control" placeholder="0.00"></asp:TextBox>
                </div><!-- /.form-group -->
                  
                  <div class="form-group form-inline m-2 ">
                  <label>Discount %&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                    <asp:DropDownList ID="ddlDiscount" runat="server" Class="form-control" OnSelectedIndexChanged="ddlDiscount_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                    </asp:DropDownList>
                </div><!-- /.form-group -->
                  
                  <div class="form-group form-inline m-2 ">
                  <label>Total Amount&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                    <asp:TextBox ID="txtTotalAmount" runat="server" Class="form-control" placeholder="0.00"></asp:TextBox>
                </div><!-- /.form-group -->
                  
                  <div class="form-group form-inline m-2">
                  <label>Recieved Amount&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                    <asp:TextBox ID="txtRAmount" runat="server" Class="form-control" placeholder="0.00"></asp:TextBox>
                </div><!-- /.form-group -->

                  <div class="form-group form-inline m-2">
                  <label>Balance&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                    <asp:TextBox ID="txtBalance" runat="server" Class="form-control" placeholder="0.00"></asp:TextBox>
                      <asp:Button id="btn1" runat="server" Class="btn btn-primary ml-5" Text="Settle Bill"/>
                </div><!-- /.form-group -->
                  
              </div> <!-- /.card-body -->
             
            </div><!-- /.card -->
            
          </div>


        </div><!-- /.row -->

          
        </div><!--container-fluid-->
        </div><!--/.content-wrapper-->
      </form> 
    </asp:Content>

