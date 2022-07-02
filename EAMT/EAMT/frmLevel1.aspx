<%@ Page Title="" Language="VB" MasterPageFile="~/MasterFrontPage.master" AutoEventWireup="false" CodeFile="frmLevel1.aspx.vb" Inherits="frmLevel1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page-wrapper">
            <div class="row">
    <div class="panel panel-primary">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-9 text-left">
                                <%--<div class="huge-">Highlights</div>--%>
                                <h4>Level 1:(33KV Feeder to 11KV Feeder) </h4>
                            </div>
                            <div class="col-xs-3 text-right">
                                <i class="fa fa-tasks fa-2x"></i>
                            </div>
                        </div>
                    </div>
                        <div class="panel-footer">
                            <div class="col-12">
                <div class="alert alert-light border row">
                    <asp:Panel CssClass="col-lg-2 col-md-12 col-md-3 col-sm-6  mt-1" runat="server" Visible="true">
                     <asp:Label ID="lblSource" runat="server" Font-Bold="true" CssClass="form-control-label" Text="Source" for="txtSource"></asp:Label><br />
                        <asp:DropDownList ID="ddlSource" placeholder="" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel CssClass="col-lg-2 col-md-12 col-md-3 col-sm-6 mt-1" runat="server" Visible="false">
                        <asp:Label ID="lblMonthStart" runat="server" Font-Bold="true" CssClass="form-control-label" Text="Start Month" for="txtMonth"></asp:Label><br />
                        <asp:DropDownList ID="ddlmonthStart" placeholder="" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                    </asp:Panel>
                    <div class="col-lg-2 col-md-12 col-md-3 col-sm-6 mt-1">
                        <asp:Label ID="lblmonth" runat="server" Font-Bold="true" CssClass="form-control-label" Text="Month" for="txtMonth"></asp:Label><br />
                        <asp:DropDownList ID="ddlmonth" placeholder="" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                    </div>
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
                    <div class="col-lg-2 col-md-12 col-md-3 col-sm-6 mt-1" runat="server" visible="true">
                        <asp:Label ID="lblSubstaion" runat="server" Text="Substation" Font-Bold="true" CssClass="form-control-label" for="txtSubDivision"></asp:Label><br />
                        <asp:DropDownList ID="ddlSubstaion" Enabled="true" placeholder="" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <%--<asp:Panel CssClass="col-lg-2 col-md-12 col-md-3 col-sm-6 mt-1" runat="server" Visible="true" style="text-align:right">
                        <br />
                        <span class="btn btn-secondary w3-dropdown-click w3-border-orange" style="font-size:medium;vertical-align: -webkit-baseline-middle; background-color:green;"><a data-toggle="modal" href="#LoginModal2"><b style="color: white">Feeder Code List</b> </a></span>
                    </asp:Panel>--%>
                    <asp:Panel CssClass="col-lg-2 col-md-12 col-md-3 col-sm-6 mt-1" runat="server" Visible="true">
                        <asp:Label ID="lblFeeder" runat="server" Font-Bold="true" Text="Feeder" CssClass="form-control-label" for="txtFeeder" Visible="true"></asp:Label><br />
                        <asp:DropDownList ID="ddlFeeder" Enabled="true" placeholder="" runat="server" Visible="true" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                    </asp:Panel>
                </div>
                        </div>
                        </div>
                </div>
                 <div class="panel panel-default">
                        <div class="panel-heading">
                            <i class="fa fa-table fa-fw"></i> Level 1 Details 
                            <div class="pull-right">
                             
                            </div>
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="table-responsive">
                                            <asp:Label ID="Label1" runat="server" CssClass="label label-danger">No Data Found</asp:Label>
                                            <span class="float-left">
                                                <div style="height: 100%;" >
                                                    <asp:GridView ID="gridViewLevel1details" runat="server" AllowSorting="false" AutoGenerateColumns="true"
                                                        ShowHeader="true" ShowFooter="false" CellSpacing="0" BorderWidth="1" HeaderStyle-CssClass="centerHeaderText"
                                                        OnPageIndexChanging="gridViewLevel1details_PageIndexChanging" AllowPaging="false" OnRowDataBound="gridViewLevel1details_RowDataBound"
                                                        CssClass="table table-bordered table-hover table-striped" EmptyDataText="No Data Found">
                                                    </asp:GridView>
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
                </div>
</asp:Content>

