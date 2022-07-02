<%@ Page Title="" Language="VB" MasterPageFile="~/MasterFrontPage.master" AutoEventWireup="false" CodeFile="frmMethodology.aspx.vb" Inherits="frmMethodology" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page-wrapper">
           <!-- /.panel 1-->
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <i class="fa fa-calculator fa-fw"></i> Methodology Composite Index for Call Centre:
                            <%--<div class="pull-right">
                                <div class="row">
                                    Select Month <asp:DropDownList ID="ddlmonth" placeholder="" runat="server" Width="130px" AutoPostBack="true" CssClass="dropdown-toggle"></asp:DropDownList>
                                </div>
                            </div>--%>
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="table-responsive">
                                        <%--<div class="col-sm-12 col-md-12 col-lg-12" id="divParameter1" runat="server">--%>
                                            <asp:Label ID="lblMISReports" runat="server" CssClass="label label-danger">No Data Found</asp:Label>
                                            <span class="float-left">
                                                <div style="height: 100%;" >
                                                    <asp:GridView ID="gridViewDetails" runat="server" AllowSorting="false" AutoGenerateColumns="true"
                                                        ShowHeader="true" ShowFooter="false" CellSpacing="0" BorderWidth="1" HeaderStyle-CssClass="centerHeaderText"
                                                        OnPageIndexChanging="OnPageIndexChanging" AllowPaging="false"
                                                        CssClass="table table-bordered table-hover table-striped" EmptyDataText="No Data Found">
                                                        <%--<RowStyle HorizontalAlign="center"/>
                                                        <AlternatingRowStyle BackColor="WhiteSmoke" ForeColor="Black" BorderColor="#959595"/>
                                                        <RowStyle BackColor="White" ForeColor="Black" BorderColor="#959595"/>
                                                        <HeaderStyle BackColor="#004085" Font-Bold="True" Font-Size="14px" ForeColor="White" HorizontalAlign="Center" />--%>
                                                    </asp:GridView>
                                                </div>
                                            </span>
                                        <%--</div>--%>
                                    </div>
                                    <!-- /.table-responsive -->
                                </div>
                            </div>
                            <!-- /.row -->
                        </div>
                        <!-- /.panel-body -->
                    </div>
    </div>
</asp:Content>

