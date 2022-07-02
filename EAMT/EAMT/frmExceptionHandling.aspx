<%@ Page Title="" Language="VB" MasterPageFile="~/MasterFrontPage.master" AutoEventWireup="false" CodeFile="frmExceptionHandling.aspx.vb" Inherits="frmExceptionHandling" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="page-wrapper">
        <div class="row">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-9 text-left">
                            <%--<div class="huge-">Highlights</div>--%>
                            <h4>Omninent Exception Handling </h4>
                        </div>
                        <div class="col-xs-3 text-right">
                            <i class="fa fa-tasks fa-2x"></i>
                        </div>
                    </div>
                </div>
                <div class="panel-footer">
                    <div class="col-12">
                        <div class="alert alert-light border row">
                            <asp:Panel CssClass="col-lg-2 col-md-12 col-md-3 col-sm-6  mt-1" runat="server" Visible="false">
                                <asp:Label ID="lblSource" runat="server" Font-Bold="true" CssClass="form-control-label" Text="Source" for="txtSource"></asp:Label><br />
                                <asp:DropDownList ID="ddlSource" placeholder="" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                            </asp:Panel>
                            <asp:Panel CssClass="col-lg-2 col-md-12 col-md-3 col-sm-6 mt-1" runat="server" Visible="false">
                                <asp:Label ID="lblMonthStart" runat="server" Font-Bold="true" CssClass="form-control-label" Text="Start Month" for="txtMonth"></asp:Label><br />
                                <asp:DropDownList ID="ddlmonthStart" placeholder="" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                            </asp:Panel>
                            <asp:Panel CssClass="col-lg-2 col-md-12 col-md-3 col-sm-6 mt-1" runat="server" Visible="false">
                                <asp:Label ID="lblmonth" runat="server" Font-Bold="true" CssClass="form-control-label" Text="Month" for="txtMonth"></asp:Label><br />
                                <asp:DropDownList ID="ddlmonth" placeholder="" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                            </asp:Panel>
                            <div class="col-lg-2 col-md-12 col-md-3 col-sm-6 mt-1">
                                <asp:Label ID="lblDiscom" runat="server" Font-Bold="true" CssClass="form-control-label" Text="Discom" for="txtDiscom"></asp:Label><br />
                                <asp:DropDownList ID="ddlDiscom" Enabled="true" placeholder="" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-lg-2 col-md-12 col-md-3 col-sm-6 mt-1">
                                <asp:Label ID="lblZone" runat="server" Text="Zone" Font-Bold="true" CssClass="form-control-label" for="txtZone"></asp:Label><br />
                                <asp:DropDownList ID="ddlZone" Enabled="true" placeholder="" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-lg-2 col-md-12 col-md-3 col-sm-6 mt-1">
                                <asp:Label ID="lblCircle" runat="server" Text="Circle" Font-Bold="true" CssClass="form-control-label" for="txtCircle"></asp:Label><br />
                                <asp:DropDownList ID="ddlCircle" Enabled="true" placeholder="" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-lg-2 col-md-12 col-md-3 col-sm-6 mt-1">
                                <asp:Label ID="lblDivision" runat="server" Text="Division" Font-Bold="true" CssClass="form-control-label" for="txtDivision"></asp:Label><br />
                                <asp:DropDownList ID="ddlDivision" Enabled="true" placeholder="" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-lg-2 col-md-12 col-md-3 col-sm-6 mt-1" runat="server" visible="false">
                                <asp:Label ID="Label2" runat="server" Text="SubDivision" Font-Bold="true" CssClass="form-control-label" for="txtSubDivision"></asp:Label><br />
                                <asp:DropDownList ID="ddlSubDivision" Enabled="true" placeholder="" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-lg-2 col-md-12 col-md-3 col-sm-6 mt-1" runat="server" visible="false">
                                <asp:Label ID="lblSubstaion" runat="server" Text="Substation" Font-Bold="true" CssClass="form-control-label" for="txtSubDivision"></asp:Label><br />
                                <asp:DropDownList ID="ddlSubstation" Enabled="true" placeholder="" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-lg-2 col-md-12 col-md-3 col-sm-6 mt-1" runat="server" visible="false">
                                <asp:Label ID="lblFeeder" runat="server" Text="Feeder" Font-Bold="true" CssClass="form-control-label" for="txtFeeder"></asp:Label><br />
                                <asp:DropDownList ID="ddlFeeder" Enabled="true" placeholder="" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-lg-2 col-md-12 col-md-3 col-sm-6 mt-1" runat="server" visible="true">
                                <asp:Label ID="Label3" runat="server" Text="" Font-Bold="true" CssClass="form-control-label" for=""></asp:Label><br />
                                <asp:Button ID="btnShow" runat="server" Text="Show Exception" Font-Bold="true" CssClass="btn btn-info" />
                            </div>

                            <%--<asp:Panel CssClass="col-lg-2 col-md-12 col-md-3 col-sm-6 mt-1" runat="server" Visible="true" style="text-align:right">
                        <br />
                        <span class="btn btn-secondary w3-dropdown-click w3-border-orange" style="font-size:medium;vertical-align: -webkit-baseline-middle; background-color:green;"><a data-toggle="modal" href="#LoginModal2"><b style="color: white">Feeder Code List</b> </a></span>
                    </asp:Panel>--%>
                            <%--<asp:Panel CssClass="col-lg-2 col-md-12 col-md-3 col-sm-6 mt-1" runat="server" Visible="true">
                                <asp:Label ID="lblFeeder" runat="server" Font-Bold="true" Text="Feeder" CssClass="form-control-label" for="txtFeeder" Visible="true"></asp:Label><br />
                                <asp:DropDownList ID="ddlFeeder" Enabled="true" placeholder="" runat="server" Visible="true" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                            </asp:Panel>--%>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <i class="fa fa-table fa-fw"></i>Omnint Exception Handling
                            <div class="pull-right">
                            </div>
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="table-responsive">
                                <asp:Label ID="Label1" Visible="false" runat="server" CssClass="label label-danger">No Data Found</asp:Label>
                                <span class="float-left">
                                    <div style="height: 100%;">
                                        <asp:GridView ID="gridViewException" DataKeyNames="ID,Division_ID" runat="server" ShowHeader="true" ShowFooter="false" CellSpacing="0" BorderWidth="1"
                                            HeaderStyle-CssClass="centerHeaderText" Width="100%" AutoGenerateColumns="false" CssClass="table table-bordered table-hover table-striped" EmptyDataText="No Data Found">
                                            <Columns>
                                                <asp:BoundField DataField="SNO" HeaderText="SNo" />
                                                <asp:BoundField DataField="DiscomName" HeaderText="Discom" />
                                                <asp:BoundField DataField="ZoneName" HeaderText="Zone" />
                                                <asp:BoundField DataField="CircleName" HeaderText="Circle" />
                                                <asp:BoundField DataField="DivisionName" HeaderText="Division" />
                                                <asp:BoundField DataField="SubstationName" HeaderText="Substation" Visible="true" />
                                                <asp:BoundField DataField="Outgoing" HeaderText="Feeder" Visible="true" />
                                                <asp:BoundField DataField="TotalEnergyAssessed_MWh" HeaderText="TotalEnergyAssessed_MWh" Visible="true" />
                                                <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkBtn" runat="server" CommandArgument="<%# CType(Container, GridViewRow).RowIndex %>" CommandName="edit2">
                                                                        Insert & Update</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle HorizontalAlign="Center" />
                                            <AlternatingRowStyle BackColor="WhiteSmoke" ForeColor="Black" BorderColor="#959595" />
                                            <RowStyle BackColor="White" ForeColor="Black" BorderColor="#959595" />
                                            <HeaderStyle BackColor="#d1ecf1" Font-Bold="True" Font-Size="14px" ForeColor="#01151E" HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </div>

                                    <div class="row" runat="server" visible="false" id="divDTInputEnergy" style="margin-bottom: 15px">
                                        <div class="col-lg-3 col-md-4 col-sm-6  mt-1">
                                            <asp:Label ID="Label5" runat="server" Font-Bold="true" CssClass="form-control-label" Text="Omninet Discom" for=""></asp:Label><br />
                                            <asp:TextBox ID="txtDiscom" runat="server" Enabled="false" class="form-control" Width="100%" />
                                        </div>
                                        <div class="col-lg-3 col-md-4 col-sm-6  mt-1">
                                            <asp:Label ID="Label7" runat="server" Font-Bold="true" CssClass="form-control-label" Text="Omninet Zone" for=""></asp:Label><br />
                                            <asp:TextBox ID="txtZone" runat="server" Enabled="false" class="form-control" Width="100%" />
                                        </div>
                                        <div class="col-lg-3 col-md-4 col-sm-6  mt-1">
                                            <asp:Label ID="Label4" runat="server" Font-Bold="true" CssClass="form-control-label" Text="Omninet Circle" for=""></asp:Label><br />
                                            <asp:TextBox ID="txtCircle" runat="server" Enabled="false" class="form-control" Width="100%" />
                                        </div>
                                        <div class="col-lg-3 col-md-4 col-sm-6  mt-1">
                                            <asp:Label ID="Label6" runat="server" Font-Bold="true" CssClass="form-control-label" Text="Omninet Division" for=""></asp:Label><br />
                                            <asp:TextBox ID="txtDivision" runat="server" Enabled="false" class="form-control" Width="100%" />
                                        </div>
                                        <div class="col-lg-3 col-md-4 col-sm-6  mt-1">
                                            <asp:Label ID="lblsourceN" runat="server" Font-Bold="true" CssClass="form-control-label" Text="Source"></asp:Label><br />
                                            <asp:DropDownList ID="ddlsourceN" placeholder="" runat="server" AutoPostBack="true" CssClass="form-control">
                                               <asp:ListItem Value="0">Select</asp:ListItem>
                                                 <asp:ListItem Value="1">URBAN</asp:ListItem>
                                                <asp:ListItem Value="2">RURAL</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-3 col-md-4 col-sm-6  mt-1">
                                            <asp:Label ID="lblDTMeterNo" runat="server" Font-Bold="true" CssClass="form-control-label" Text="SubStation" for=""></asp:Label><br />
                                            <asp:DropDownList ID="ddlUpdateSubStation" placeholder="" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>

                                        </div>
                                        <div class="col-lg-3 col-md-4 col-sm-6  mt-1">
                                            <asp:Label ID="lblMF" runat="server" Font-Bold="true" CssClass="form-control-label" Text="Feeder" for=""></asp:Label><br />
                                            <asp:DropDownList ID="ddlUpdateFeeder" placeholder="" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>

                                        </div>
                                        <%--<div class="col-lg-3 col-md-4 col-sm-6  mt-1">
                                <asp:Label ID="lblReadingMonth" runat="server" Font-Bold="true" CssClass="form-control-label" Text="For the Month of" for=""></asp:Label><br />
                                <asp:DropDownList ID="ddlReadingMonth" runat="server" class="form-control" />
                            </div>--%>
                                        <br />
                                        <div class="col-lg-2 col-md-12 col-md-3 col-sm-6 mt-1" style="text-align: center;">
                                            <asp:Label ID="Label8" runat="server" Text="" Font-Bold="true" CssClass="form-control-label" for=""></asp:Label><br />
                                            <asp:Button ID="btnDTAddNew" runat="server" Visible="false" CssClass="btn btn-group btn-primary" Text="Add New" />
                                            <asp:Button ID="btnUpdate" Visible="false" CssClass="btn btn-group btn-primary" runat="server" Text="Update" OnClientClick="FinishButtonClick(this);" />
                                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-group btn-primary" Text="Cancel" />
                                        </div>
                                    </div>
                                </span>
                                <%--</div>--%>
                            </div>
                            <!-- /.table-responsive -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.panel-body -->
                </div>
            </div>
        </div>
</asp:Content>

