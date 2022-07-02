<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/3/w3.css"/>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-/Y6pD6FV/Vv2HJnA6t+vslU6fwYXjCFtcEpHbNJ0lyAFsXTsjBbfaDjzALeQsN6M" crossorigin="anonymous" />
	<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
	<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js"></script>
    <title></title>
    <link href="Content/w3.css" rel="stylesheet" />
    <style>
        /*html {
            padding-top: 10px;
            background: url(images/uppcl.jpg) no-repeat center center fixed;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
        }*/
        body {
            padding-top: 10px;
            background: url(images/images-10.jpg) center fixed;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
        }

        h1 {
            color: #af2204;
            font-size: 45px;
            text-align: center;
            font-weight: bold;
            font-family: 'BrushScriptMTItalic';
            width: 65%;
            position: absolute;
            left: 20%;
            top: 0%;
        }

        .enter {
            position: absolute;
            height: 186px;
            width: 150px;
            padding-bottom: 10px;
            left: 43%;
            color: black !IMPORTANT;
            font-family: 'open_sansregular';
        }

            .enter a {
                color: white;
                font-size: 36px;
                text-decoration: none;
                background-color: black;
            }

                .enter a:hover {
                    text-decoration: underline;
                }

        .logo {
        }

        .wrapper {
            margin-top: 80px;
            margin-bottom: 20px;
        }
        /* Fading animation */
        .fade {
            -webkit-animation-name: fade;
            -webkit-animation-duration: 3s;
            animation-name: fade;
            animation-duration: 4s;
            transition-delay: 0.1s;
        }
        /*/*For popup modal*/
        .modal-content {
            background-color: blue;
            margin: auto;
            padding: 20px;
            border: 1px solid #888;
        }

        /*.form-signin {
            max-width: 210px;
            padding: 15px 18px 10px;
            margin: 0 auto;
            background-color: rgba(255, 0, 0, 0.70);
            border: 5px dotted rgba(0,0,0,0.1);
            float: right;
            margin-top: 100px;
        }*/

        /*.form-signin-heading {
            text-align: center;
            margin-bottom: 30px;
        }*/
        .form-signin {
            background-color: #111c;
            border: 5px dotted rgba(0,0,0,0.1);
            margin-top: calc(20vh);
        }
        /*.form-control {
            position: relative;
            font-size: 16px;
            height: auto;
            padding: 10px;
        }*/

        input[type="text"] {
            margin-bottom: 0px;
            border-bottom-left-radius: 0;
            border-bottom-right-radius: 0;
        }

        input[type="password"] {
            margin-bottom: 20px;
            border-top-left-radius: 0;
            border-top-right-radius: 0;
        }

        @media (min-width: 1200px) {
            .container {
                max-width: 1339px !important;
            }
        }
    </style>
    <script>

        $(function () {
            $('body').click(function () {
                $('.errorMsg').hide('slow');
            });
        });

        function Validate() {
            if ($.trim($('#<%=txtuser.ClientID%>').val()) == '') {
                alert('Please fill userid');
                return false;
            }
            if ($.trim($('#<%=txtpass.ClientID%>').val()) == '') {
                alert('Please fill password');
                return false;
            }
            else {
                return true;
            }
        }

    </script>
</head>
<body>
    <div class="container-fluid">
        <div class="mt-5">
            <form id="form1" runat="server">
                <div class="row">
                    <div class="col-12  text-center">
                        <img src="images/Picture1.png" alt="logo" class="img-fluid" style="max-width: 100px" />
                    </div>
                    <div class="col-12">
                        <h1 class="text-white font-weight-bold text-center">EAMT DASHBOARD</h1>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-7 col-lg-9">
                    </div>
                    <div class="col-md-5 col-lg-3">
                        <div class="form-group form-signin p-2">
                            <h4 class="form-signin-heading w3-text-white" style="text-shadow: 1px 1px 0 #444; font-weight: bold">Please Sign In</h4>
                            <a href="#" style="font-size: smaller; font-weight: bold; color: white;">LOGIN TO EAMT PORTAL</a><br />
                            <asp:Label ID="lbl_message" runat="server" Visible="False" CssClass="errorMsg" Font-Bold="True" ForeColor="YellowGreen"></asp:Label>
                            <asp:TextBox ID="txtuser" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
                            <asp:TextBox ID="txtpass" CssClass="form-control" TextMode="Password" runat="server" placeholder="Password"></asp:TextBox>
                            <asp:Button ID="btnlogin" runat="server" Text="Login" CssClass="btn btn-lg btn-primary btn-block" />
                            <%--<h5><a data-toggle="modal" href="#LoginModal2" style="font-size: smaller; font-weight: bold; color: cornsilk;">RESET PASSWORD</a></h5>
                            <h5><a href="#" style="font-size: smaller; font-weight: bold; color: lawngreen;">FORGOT PASSWORD</a></h5>--%>
                        </div>
                    </div>
                </div>
                <div class="modal fade" id="LoginModal2" tabindex="-1" role="dialog" aria-labelledby="ModalTitle" aria-hidden="true">
                <div class="modal-dialog" style="max-width: 814px;">
                    <div class="modal-content" style="background-color: white; color: black;">
                        <div class="modal-header">
                            <h4 class="modal-title" id="ModalTitle2" style="text-align: center;">Account Submitted Upto Details</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="Enter the Username"></asp:TextBox>
                                    <asp:TextBox ID="txtOldPassword" CssClass="form-control" TextMode="Password" runat="server" placeholder="Enter the Old Password"></asp:TextBox>
                                    <asp:TextBox ID="TextNewPassword" CssClass="form-control" TextMode="Password" runat="server" placeholder="Enter the New Password"></asp:TextBox>
                                    <asp:TextBox ID="TextConfirmNewPassword" CssClass="form-control" TextMode="Password" runat="server" placeholder="Enter the Confirm New Password"></asp:TextBox>
                                    <asp:Button ID="btnResetPassword" runat="server" Text="Reset Password" CssClass="btn btn-lg btn-primary btn-block" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" id="Button1" data-dismiss="modal" runat="server">Close</button>
                        </div>
                    </div>
                </div>
            </div>
            </form>
            
        </div>
    </div>
</body>
</html>
