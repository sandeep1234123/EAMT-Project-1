<%@ Page Title="" Language="VB" MasterPageFile="~/MasterFrontPage.master" AutoEventWireup="false" CodeFile="frmHVconsumers.aspx.vb" Inherits="frmHVconsumers" %>

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
                                <h4>High Volume Consumers </h4>
                            </div>
                            <div class="col-xs-3 text-right">
                                <i class="fa fa-tasks fa-2x"></i>
                            </div>
                        </div>
                    </div>
                       <div class="panel-footer">
                    <div class="col-12">
                        <div class="alert alert-light border row">
                            <div class="col-lg-2 col-md-12 col-md-3 col-sm-6 mt-1" runat="server" visible="true">
                                <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Load Parameter" CssClass="form-control-label" for="txtFeeder" Visible="true"></asp:Label><br />
                                <asp:DropDownList ID="ddlParameters" runat="server" AutoPostBack="true" Visible="true" CssClass="form-control"></asp:DropDownList>
                            </div>
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
                                <asp:DropDownList ID="ddlDiscom" Enabled="true" placeholder="" runat="server" AutoPostBack="True" CssClass="form-control"></asp:DropDownList>
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
                                <asp:Label ID="lblSubdivision" runat="server" Text="Subdivision" Font-Bold="true" CssClass="form-control-label" for="txtSubdivision"></asp:Label><br />
                                <asp:DropDownList ID="ddlSubdivision" Enabled="true" placeholder="" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-lg-2 col-md-12 col-md-3 col-sm-6 mt-1" runat="server" visible="false">
                                <asp:Label ID="lblSubstaion" runat="server" Text="Substation" Font-Bold="true" CssClass="form-control-label" for="txtSubstation"></asp:Label><br />
                                <asp:DropDownList ID="ddlSubstation" Enabled="true" placeholder="" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-lg-2 col-md-12 col-md-3 col-sm-6 mt-1" runat="server" visible="false">
                                <asp:Label ID="lblFeeder" runat="server" Font-Bold="true" Text="Feeder" CssClass="form-control-label" for="txtFeeder" Visible="true"></asp:Label><br />
                                <asp:DropDownList ID="ddlFeeder" Enabled="true" placeholder="" runat="server" Visible="true" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-lg-2 col-md-12 col-md-3 col-sm-6 mt-1" runat="server" visible="true">
                                <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="" CssClass="form-control-label" for="txtFeeder" Visible="true"></asp:Label><br />
                                <asp:Button ID="btnView" Enabled="true" Text="View Details" runat="server" CssClass="btn btn-primary form-control"></asp:Button>
                            </div>
                        </div>

                    </div>
                </div>
                </div>
                 <div class="panel panel-default" runat="server" id="gridShow" visible="false">
                        <div class="panel-heading">
                            <i class="fa fa-table fa-fw"></i> HV Consumer Details 
                            <div class="pull-right">
                             
                            </div>
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="table-responsive">
                                            <asp:Label ID="lblMISReports" runat="server" Visible="false" CssClass="label label-danger">No Data Found</asp:Label>
                                            <span class="float-left">
                                                <div style="height: 100%;" >
                                                    <asp:GridView ID="gridViewHVCdetails" runat="server" AllowSorting="false" AutoGenerateColumns="true"
                                                        ShowHeader="true" ShowFooter="false" CellSpacing="0" BorderWidth="1" HeaderStyle-CssClass="centerHeaderText"
                                                        OnPageIndexChanging="gridViewHVCdetails_PageIndexChanging" AllowPaging="false" OnRowDataBound="gridViewHVCdetails_RowDataBound"
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

