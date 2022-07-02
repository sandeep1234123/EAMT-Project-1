<%@ Page Title="" Language="VB" MasterPageFile="~/MasterFrontPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="page-wrapper">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-xs-9 text-left">
                        <h4>Energy Audit </h4>
                    </div>
                    <div class="col-xs-3 text-right">
                        <i class="fa fa-tasks fa-2x"></i>
                    </div>
                </div>
            </div>
            <div class="panel-footer">

                <div class="col-12">

                    <div class="row">
                        <div class="col-lg-3 col-md-6">
                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <i class="fa fa-keyboard-o fa-5x"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">
                                            <div class="huge">26%</div>
                                            <div>Input Energy Level 1</div>
                                        </div>
                                    </div>
                                </div>
                                <a href="frmLevel1.aspx">
                                    <div class="panel-footer">
                                        <span class="pull-left">33KV to 11KV Feeder</span>
                                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                        <div class="clearfix"></div>
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6">
                            <div class="panel panel-green">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <i class="fa fa-keyboard-o fa-5x"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">
                                            <div class="huge">12%</div>
                                            <div>Input energy Level 2</div>
                                        </div>
                                    </div>
                                </div>
                                <a href="frmLevel2.aspx">
                                    <div class="panel-footer">
                                        <span class="pull-left">Feeder to DT</span>
                                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                        <div class="clearfix"></div>
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6">
                            <div class="panel panel-yellow">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <i class="fa fa-keyboard-o fa-5x"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">
                                            <div class="huge">32%</div>
                                            <div>Input energy Level 3</div>
                                        </div>
                                    </div>
                                </div>
                                <a href="frmLevel3.aspx">
                                    <div class="panel-footer">
                                        <span class="pull-left">DT to Consumer</span>
                                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                        <div class="clearfix"></div>
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6">
                            <div class="panel panel-red">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <i class="fa fa-keyboard-o fa-5x"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">
                                            <div class="huge">56%</div>
                                            <div>Input energy Level 4</div>
                                        </div>
                                    </div>
                                </div>
                                <a href="frmLevel4.aspx">
                                    <div class="panel-footer">
                                        <span class="pull-left">Feeder to Consumer</span>
                                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                        <div class="clearfix"></div>
                                    </div>
                                </a>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-12">

                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <i class="fa fa-bar-chart-o fa-fw"></i>Bar Chart Example
                           
                                    <%--<div class="pull-right">
                                        <div class="btn-group">
                                            <button type="button" class="btn btn-default btn-xs dropdown-toggle" data-toggle="dropdown">
                                                Actions
                                       
                                                <span class="caret"></span>
                                            </button>
                                            <ul class="dropdown-menu pull-right" role="menu">
                                                <li><a href="#">Action</a>
                                                </li>
                                                <li><a href="#">Another action</a>
                                                </li>
                                                <li><a href="#">Something else here</a>
                                                </li>
                                                <li class="divider"></li>
                                                <li><a href="#">Separated link</a>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>--%>
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class="table-responsive">
                                                <table class="table table-bordered table-hover table-striped">
                                                    <thead>
                                                        <tr>
                                                            <th>#</th>
                                                            <th>Date</th>
                                                            <th>Time</th>
                                                            <th>Amount</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td>3326</td>
                                                            <td>10/21/2013</td>
                                                            <td>3:29 PM</td>
                                                            <td>$321.33</td>
                                                        </tr>
                                                        <tr>
                                                            <td>3325</td>
                                                            <td>10/21/2013</td>
                                                            <td>3:20 PM</td>
                                                            <td>$234.34</td>
                                                        </tr>
                                                        <tr>
                                                            <td>3324</td>
                                                            <td>10/21/2013</td>
                                                            <td>3:03 PM</td>
                                                            <td>$724.17</td>
                                                        </tr>
                                                        <tr>
                                                            <td>3323</td>
                                                            <td>10/21/2013</td>
                                                            <td>3:00 PM</td>
                                                            <td>$23.71</td>
                                                        </tr>
                                                        <tr>
                                                            <td>3322</td>
                                                            <td>10/21/2013</td>
                                                            <td>2:49 PM</td>
                                                            <td>$8345.23</td>
                                                        </tr>
                                                        <tr>
                                                            <td>3321</td>
                                                            <td>10/21/2013</td>
                                                            <td>2:23 PM</td>
                                                            <td>$245.12</td>
                                                        </tr>
                                                        <tr>
                                                            <td>3320</td>
                                                            <td>10/21/2013</td>
                                                            <td>2:15 PM</td>
                                                            <td>$5663.54</td>
                                                        </tr>
                                                        <tr>
                                                            <td>3319</td>
                                                            <td>10/21/2013</td>
                                                            <td>2:13 PM</td>
                                                            <td>$943.45</td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                            <!-- /.table-responsive -->
                                        </div>
                                        <!-- /.col-lg-4 (nested) -->
                                        <div class="col-lg-8">
                                            <div id="morris-bar-chart" style="position: relative; -webkit-tap-highlight-color: rgba(0, 0, 0, 0);">
                                                <svg height="347" version="1.1" width="438" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" style="overflow: hidden; position: relative; left: -0.65625px; top: -0.734375px;">
                                                    <desc style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0);">Created with Raphaël 2.2.0</desc><defs style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0);"></defs><text x="32.84765625" y="313" text-anchor="end" font-family="sans-serif" font-size="12px" stroke="none" fill="#888888" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0); text-anchor: end; font-family: sans-serif; font-size: 12px; font-weight: normal;" font-weight="normal"><tspan dy="4" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0);">0</tspan>
                                                    </text><path fill="none" stroke="#aaaaaa" d="M45.34765625,313H413" stroke-width="0.5" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0);"></path><text x="32.84765625" y="241" text-anchor="end" font-family="sans-serif" font-size="12px" stroke="none" fill="#888888" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0); text-anchor: end; font-family: sans-serif; font-size: 12px; font-weight: normal;" font-weight="normal"><tspan dy="4" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0);">25</tspan>
                                                    </text><path fill="none" stroke="#aaaaaa" d="M45.34765625,241H413" stroke-width="0.5" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0);"></path><text x="32.84765625" y="169" text-anchor="end" font-family="sans-serif" font-size="12px" stroke="none" fill="#888888" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0); text-anchor: end; font-family: sans-serif; font-size: 12px; font-weight: normal;" font-weight="normal"><tspan dy="4" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0);">50</tspan>
                                                    </text><path fill="none" stroke="#aaaaaa" d="M45.34765625,169H413" stroke-width="0.5" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0);"></path><text x="32.84765625" y="97" text-anchor="end" font-family="sans-serif" font-size="12px" stroke="none" fill="#888888" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0); text-anchor: end; font-family: sans-serif; font-size: 12px; font-weight: normal;" font-weight="normal"><tspan dy="4" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0);">75</tspan>
                                                    </text><path fill="none" stroke="#aaaaaa" d="M45.34765625,97H413" stroke-width="0.5" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0);"></path><text x="32.84765625" y="25" text-anchor="end" font-family="sans-serif" font-size="12px" stroke="none" fill="#888888" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0); text-anchor: end; font-family: sans-serif; font-size: 12px; font-weight: normal;" font-weight="normal"><tspan dy="4" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0);">100</tspan>
                                                    </text><path fill="none" stroke="#aaaaaa" d="M45.34765625,25H413" stroke-width="0.5" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0);"></path><text x="386.73911830357144" y="325.5" text-anchor="middle" font-family="sans-serif" font-size="12px" stroke="none" fill="#888888" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0); text-anchor: middle; font-family: sans-serif; font-size: 12px; font-weight: normal;" font-weight="normal" transform="matrix(1,0,0,1,0,7)"><tspan dy="4" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0);">2012</tspan>
                                                    </text><text x="281.6955915178571" y="325.5" text-anchor="middle" font-family="sans-serif" font-size="12px" stroke="none" fill="#888888" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0); text-anchor: middle; font-family: sans-serif; font-size: 12px; font-weight: normal;" font-weight="normal" transform="matrix(1,0,0,1,0,7)"><tspan dy="4" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0);">2010</tspan>
                                                    </text><text x="176.65206473214286" y="325.5" text-anchor="middle" font-family="sans-serif" font-size="12px" stroke="none" fill="#888888" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0); text-anchor: middle; font-family: sans-serif; font-size: 12px; font-weight: normal;" font-weight="normal" transform="matrix(1,0,0,1,0,7)"><tspan dy="4" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0);">2008</tspan>
                                                    </text><text x="71.60853794642857" y="325.5" text-anchor="middle" font-family="sans-serif" font-size="12px" stroke="none" fill="#888888" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0); text-anchor: middle; font-family: sans-serif; font-size: 12px; font-weight: normal;" font-weight="normal" transform="matrix(1,0,0,1,0,7)"><tspan dy="4" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0);">2006</tspan>
                                                    </text><rect x="51.91287667410714" y="25" width="18.19566127232143" height="288" rx="0" ry="0" fill="#0b62a4" stroke="none" fill-opacity="1" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0); fill-opacity: 1;"></rect><rect x="73.10853794642857" y="53.80000000000001" width="18.19566127232143" height="259.2" rx="0" ry="0" fill="#7a92a3" stroke="none" fill-opacity="1" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0); fill-opacity: 1;"></rect><rect x="104.43464006696428" y="97" width="18.19566127232143" height="216" rx="0" ry="0" fill="#0b62a4" stroke="none" fill-opacity="1" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0); fill-opacity: 1;"></rect><rect x="125.63030133928571" y="125.80000000000001" width="18.19566127232143" height="187.2" rx="0" ry="0" fill="#7a92a3" stroke="none" fill-opacity="1" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0); fill-opacity: 1;"></rect><rect x="156.95640345982142" y="169" width="18.19566127232143" height="144" rx="0" ry="0" fill="#0b62a4" stroke="none" fill-opacity="1" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0); fill-opacity: 1;"></rect><rect x="178.15206473214283" y="197.8" width="18.19566127232143" height="115.19999999999999" rx="0" ry="0" fill="#7a92a3" stroke="none" fill-opacity="1" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0); fill-opacity: 1;"></rect><rect x="209.47816685267858" y="97" width="18.19566127232143" height="216" rx="0" ry="0" fill="#0b62a4" stroke="none" fill-opacity="1" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0); fill-opacity: 1;"></rect><rect x="230.673828125" y="125.80000000000001" width="18.19566127232143" height="187.2" rx="0" ry="0" fill="#7a92a3" stroke="none" fill-opacity="1" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0); fill-opacity: 1;"></rect><rect x="261.9999302455357" y="169" width="18.19566127232143" height="144" rx="0" ry="0" fill="#0b62a4" stroke="none" fill-opacity="1" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0); fill-opacity: 1;"></rect><rect x="283.19559151785717" y="197.8" width="18.19566127232143" height="115.19999999999999" rx="0" ry="0" fill="#7a92a3" stroke="none" fill-opacity="1" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0); fill-opacity: 1;"></rect><rect x="314.5216936383929" y="97" width="18.19566127232143" height="216" rx="0" ry="0" fill="#0b62a4" stroke="none" fill-opacity="1" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0); fill-opacity: 1;"></rect><rect x="335.71735491071433" y="125.80000000000001" width="18.19566127232143" height="187.2" rx="0" ry="0" fill="#7a92a3" stroke="none" fill-opacity="1" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0); fill-opacity: 1;"></rect><rect x="367.04345703125006" y="25" width="18.19566127232143" height="288" rx="0" ry="0" fill="#0b62a4" stroke="none" fill-opacity="1" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0); fill-opacity: 1;"></rect><rect x="388.2391183035715" y="53.80000000000001" width="18.19566127232143" height="259.2" rx="0" ry="0" fill="#7a92a3" stroke="none" fill-opacity="1" style="-webkit-tap-highlight-color: rgba(0, 0, 0, 0); fill-opacity: 1;"></rect></svg><div class="morris-hover morris-default-style" style="left: 188.486px; top: 138px; display: none;">
                                                        <div class="morris-hover-row-label">2009</div>
                                                        <div class="morris-hover-point" style="color: #0b62a4">
                                                            Series A:
  75
                                                        </div>
                                                        <div class="morris-hover-point" style="color: #7a92a3">
                                                            Series B:
  65
                                                        </div>
                                                    </div>
                                            </div>
                                        </div>
                                        <!-- /.col-lg-8 (nested) -->
                                    </div>
                                    <!-- /.row -->
                                </div>
                                <!-- /.panel-body -->
                            </div>
                            <!-- /.panel -->

                        </div>
                        <!-- /.col-lg-12 -->
                        
                    </div>


                </div>
            </div>
        </div>

    </div>
</asp:Content>

