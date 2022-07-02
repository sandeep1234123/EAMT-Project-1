<%@ Page Title="" Language="VB" MasterPageFile="~/MasterFrontPage.master" AutoEventWireup="false" CodeFile="frmLevel3.aspx.vb" Inherits="frmLevel3" %>

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
                            <h4>Level 3:(DT to Consumer) </h4>
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
                                <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Type Of Parameter" CssClass="form-control-label" for="txtFeeder" Visible="true"></asp:Label><br />
                                <asp:DropDownList ID="ddlParameters" runat="server" Visible="true" CssClass="form-control">
                                    <asp:ListItem Value="1">Monthly A&TC Loss Slab</asp:ListItem>
                                    <asp:ListItem Value="2">Monthly Line Loss Slab</asp:ListItem>
                                    <asp:ListItem Value="3">Progressive A&TC Loss Slab</asp:ListItem>
                                    <asp:ListItem Value="4">Progressive Line Loss Slab</asp:ListItem>
                                </asp:DropDownList>
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
                            <div class="col-lg-2 col-md-12 col-md-3 col-sm-6 mt-1" runat="server" visible="true">
                                <asp:Label ID="lblSubdivision" runat="server" Text="Subdivision" Font-Bold="true" CssClass="form-control-label" for="txtSubdivision"></asp:Label><br />
                                <asp:DropDownList ID="ddlSubdivision" Enabled="true" placeholder="" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-lg-2 col-md-12 col-md-3 col-sm-6 mt-1" runat="server" visible="true">
                                <asp:Label ID="lblSubstaion" runat="server" Text="Substation" Font-Bold="true" CssClass="form-control-label" for="txtSubstation"></asp:Label><br />
                                <asp:DropDownList ID="ddlSubstation" Enabled="true" placeholder="" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-lg-2 col-md-12 col-md-3 col-sm-6 mt-1" runat="server" visible="true">
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
            <div class="panel panel-default">
                <div class="panel-heading">
                    <i class="fa fa-table fa-fw"></i>Level 3 Summary
                            <div class="pull-right">
                            </div>
                </div>
                <!-- /.panel-heading -->
                <asp:Panel ID="pnllevel4" runat="server" Visible="false">
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="table-responsive">
                                    
                                    <span class="float-left">
                                        <div style="height: 100%;">
                                            <asp:GridView ID="gridviewSummary" runat="server" AllowSorting="false" AutoGenerateColumns="true"
                                                ShowHeader="true" ShowFooter="false" CellSpacing="0" BorderWidth="1" HeaderStyle-CssClass="centerHeaderText"
                                                AllowPaging="false"
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
                     <div class="panel panel-default">
                    <div class="panel-heading">
                        <i class="fa fa-table fa-fw"></i>Level 3 Details 
                            <div class="pull-right">
                            </div>
                    </div>
</div>

                    <div class="panel-body">
                        <div class="row">

                            <div class="col-lg-12">
                                <div class="table-responsive">
                                    <asp:Label ID="lblMISReports" runat="server" CssClass="label label-danger">No Data Found</asp:Label>
                                    <span class="float-left">
                                        <div style="height: 100%;">
                                            <asp:GridView ID="gridViewLevel1details" runat="server" AllowSorting="false" AutoGenerateColumns="true"
                                                ShowHeader="true" ShowFooter="false" CellSpacing="0" BorderWidth="1" HeaderStyle-CssClass="centerHeaderText"
                                                AllowPaging="false"
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

                </asp:Panel>
                
                <asp:Panel ID="pnlFeeder" runat="server" Visible="false">
                    <table class="table-responsive table" style="margin: auto; width: 100%; border: 1px solid #337ab7; background-color: white; color: black; font-weight: bolder">
                        <thead class="thead-dark" style="color: white; background-color: #337ab7; text-align: left;">
                            <tr>
                                <th colspan="4" style="text-align: center; font-size: larger">COMMERCIAL PARAMETERS</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Panel ID="pnlatnclosses" runat="server" Visible="false">
                                <tr style="color: white; background-color: blue; text-align: left;">
                                    <th colspan="4" style="text-align: left; font-size: larger">AT&C Losses</th>
                                </tr>

                                <tr>
                                    <td colspan="2">FY 19-20 Progressive (%)</td>
                                    <td colspan="2">
                                        <asp:Label ID="lblProgressiveATCL" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="2">FY 20-21 Progressive (%)</td>
                                    <td colspan="2">
                                        <asp:Label ID="lblProgressive2021" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="2">FY 21-22 Monthly (<%=Format(Convert.ToDateTime(ddlmonth.SelectedValue.ToString.Trim), "MMM-yyyy")%>) (%)</td>
                                    <td colspan="2">
                                        <asp:Label ID="lblFY2021Monthly" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="2">FY 21-22 Progressive (till <%=Format(Convert.ToDateTime(ddlmonth.SelectedValue.ToString.Trim), "MMM-yyyy")%>) (%)</td>
                                    <td colspan="1">
                                        <asp:Label ID="lblProgressive" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                    <td colspan="1">
                                        <p class="">
                                            <asp:Image CssClass="d-flex mr-3 rounded-circle" ID="Image1" runat="server" ImageUrl="images/noimage.png" Style="height: 30px; width: 30px;" AlternateText="No Image" />
                                        </p>
                                    </td>
                                </tr>
                                <%--<tr>
                                                <th colspan="4" style="text-align: left; font-size: larger">PROGRESSIVE</th>
                                            </tr>
                                            <tr style="color: black; background-color: white; text-align: left;">
                                                <td>Billing Efficiency (%):<b><asp:Label ID="lblProgressiveBE" runat="server"></asp:Label></b></td>
                                                <td>Collection Efficiency (%):<b><asp:Label ID="lblProgressiveCE" runat="server"></asp:Label></b></td>
                                                <td>AT&C Losses (%):<b><asp:Label ID="lblProgressiveATCL" runat="server"></asp:Label></b></td>
                                                <td><p class="blink-two"><asp:Image CssClass="d-flex mr-3 rounded-circle" id="Image1" runat="server" ImageUrl="images/noimage.png" style="height: 25px;width:25px;" AlternateText="No Image" /></p></td>
                                </tr>--%>
                            </asp:Panel>

                            <tr style="color: white; background-color: #337ab7;">
                                <th colspan="4" style="text-align: left; font-size: larger">MONTHLY</th>
                            </tr>
                            <tr>
                                <th><u>Parameters (Unit)</u></th>
                                <th><u>Values</u></th>
                                <th><u>Parameters (Unit)</u></th>
                                <th><u>Values</u></th>
                            </tr>


                            <tr>
                                <td>Sanctioned Load (MW)</td>
                                <td>
                                    <asp:Label ID="lblSancationLoad" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                <td>Metered Billing (%)</td>
                                <td>
                                    <asp:Label ID="lblMeteredBilling" ForeColor="#337ab7" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Input Energy (MU)</td>
                                <td>
                                    <asp:Label ID="lblInputEnergy" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                <td>Assessment (Lacs)</td>
                                <td>
                                    <asp:Label ID="lblAssessment" ForeColor="#337ab7" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Billed Energy (MU)</td>
                                <td>
                                    <asp:Label ID="lblBilledUnit" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                <td>Realization (Lacs)</td>
                                <td>
                                    <asp:Label ID="lblRealization" ForeColor="#337ab7" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Billing Efficiency (%)</td>
                                <td>
                                    <asp:Label ID="lblBillingEfficency" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                <td>Collection Efficiency (%)</td>
                                <td>
                                    <asp:Label ID="lblCollectionEfficency" ForeColor="#337ab7" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Line Loss (%)</td>
                                <td>
                                    <asp:Label ID="lblLineLoss" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                <td>AT&C Loss (%)</td>
                                <td>
                                    <asp:Label ID="lblATCLoss" ForeColor="#337ab7" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Billable Consumer (Nos)</td>
                                <td>
                                    <asp:Label ID="lblBillableConsumer" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                <td>TurnUp Consumer (Nos)</td>
                                <td>
                                    <asp:Label ID="lblTurnUpConsumer" ForeColor="#337ab7" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Billed Consumer (Nos)</td>
                                <td>
                                    <asp:Label ID="lblBilledConsumer" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                <td>TurnUp Ratio (%)</td>
                                <td>
                                    <asp:Label ID="lblTurnUpRation" ForeColor="#337ab7" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Billing (%)</td>
                                <td>
                                    <asp:Label ID="lblBillingPer" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                <td>Thr Rate (Rs/Unit)</td>
                                <td>
                                    <asp:Label ID="lblThrRate" ForeColor="#337ab7" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Reading Based Billed (Nos)</td>
                                <td>
                                    <asp:Label ID="lblReadingBasedBilledConsumer" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                <td>ABR (Rs/Unit)</td>
                                <td>
                                    <asp:Label ID="lblABR" ForeColor="#337ab7" runat="server"></asp:Label></td>
                            </tr>
                            <%--<tr>
                                <td>IDF</td>
                                <td>
                                    <asp:Label ID="lblIDF" ForeColor="#337ab7" runat="server"></asp:Label>
                                </td>
                                <td>Un-Metered</td>
                                <td>
                                    <asp:Label ID="lblUnMetered" ForeColor="#337ab7" runat="server"></asp:Label></td>
                            </tr>--%>

                        </tbody>
                    </table>
                </asp:Panel>

                <asp:Panel ID="pnlarrearstatus" runat="server" Visible="false">
                    <table class="table-responsive w3-striped table" style="margin: auto; width: 100%; border: 3px solid green; border: double; background-color: white; color: black; font-weight: bolder; text-align: center">
                        <thead class="thead-dark" style="color: white; background-color: blue;">
                            <tr>
                                <th colspan="5" style="text-align: center; font-size: larger">ARREAR STATUS</th>
                            </tr>
                            <tr>
                                <th style="text-align: left"><b>TenureWise_Arrear</b></th>
                                <th>
                                    <center><b>OverallArrear NoOfDefaulters</b></center>
                                </th>
                                <th>
                                    <center><b>OverallArrear ArrearAmount(Lacs)</b></center>
                                </th>
                                <th>
                                    <center><b>ARREAR(>=10k) NoOfDefaulters</b></center>
                                </th>
                                <th>
                                    <center><b>ARREAR(>=10k) ArrearAmount(Lacs)</b></center>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr runat="server" visible="false">
                                <td style="text-align: left">Below 3 month</td>
                                <td>
                                    <%--<a href="Substational View.aspx?ColumnIndex=6" runat="server">--%>
                                    <asp:Label ID="Label1" ForeColor="#337ab7" runat="server"></asp:Label>
                                    <%--</a>--%>
                                </td>
                                <td>
                                    <asp:Label ID="Label4" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label5" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label6" ForeColor="#337ab7" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="text-align: left">3-6 month</td>
                                <td>
                                    <asp:Label ID="Label7" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label8" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label9" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label10" ForeColor="#337ab7" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="text-align: left">6-12 month</td>
                                <td>
                                    <asp:Label ID="Label11" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label12" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label13" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label14" ForeColor="#337ab7" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="text-align: left">More than 12 month</td>
                                <td>
                                    <asp:Label ID="Label15" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label16" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label17" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label18" ForeColor="#337ab7" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="text-align: left"><b>Grand Total</b></td>
                                <td>
                                    <asp:Label ID="Label19" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label20" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label21" ForeColor="#337ab7" runat="server"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label22" ForeColor="#337ab7" runat="server"></asp:Label></td>
                            </tr>
                        </tbody>
                    </table>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>

