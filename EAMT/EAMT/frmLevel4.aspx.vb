Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text.RegularExpressions
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html
Imports iTextSharp.text.html.simpleparser
Imports System.IO
Imports System.Web.Services
Imports System.Drawing

Partial Class frmLevel4
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim objMainCLS As New maincls
    Dim s1 As New cls_link_to_database
    Dim strSql As String
    Dim dt As New System.Data.DataTable
    Dim Query As String
    Dim masterdt As New DataTable
   Dim discom, zone, circle, division, subdivision, substation, feeder As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        '    Dim script As String = "$(document).ready(function () { $('[id*=btnViewDetails]').click(); });"
        '    ClientScript.RegisterStartupScript(Me.GetType, "load", script, True)
        '    TabName.Value = Request.Form(TabName.UniqueID)
        'End If
        If Session("login") = "false" Then
            Response.Redirect("Login.aspx")
        End If
        If Session("login") Is Nothing Then
            Response.Redirect("Login.aspx")
        End If

        If Session("Role") Is Nothing Then
            Response.Redirect("Login.aspx")
        End If
        If Session("Role") = "false" Then
            Response.Redirect("Login.aspx")
        End If
        If Page.IsPostBack = False Then
            'TabName.Value = Request.Form(TabName.UniqueID)
            source_bind()
            bind_month()
            bind_role()

            If Session("AccessDiscom") <> "NONE" Then
                bind_discom()

                Try
                    If ddlDiscom.SelectedItem.Text.ToString <> "Select" Then
                        discom = ddlDiscom.SelectedItem.Text.ToString()
                        Session("Discom") = discom
                        Session("flag") = 0
                    Else
                        If Session("Role") = "UPPCL" Then
                            ddlDiscom.SelectedIndex = -1

                        Else
                            ddlDiscom.SelectedIndex = 1


                        End If
                        Session("Discom") = ddlDiscom.SelectedItem.Text.ToString()

                    End If
                Catch ex As Exception
                End Try
            Else
                ddlDiscom.SelectedIndex = -1
                Session("Discom") = ddlDiscom.SelectedItem.Text.ToString()
            End If

            If Session("AccessZone") <> "NONE" Then
                bind_zone()
                Try
                    If ddlZone.SelectedItem.Text.ToString <> "Select" Then
                        zone = ddlZone.SelectedItem.Text.ToString()
                        Session("Zone") = zone
                        Session("flag") = 1
                    Else
                        ddlZone.SelectedIndex = 1
                        Session("Zone") = ddlZone.SelectedItem.Text.ToString()
                    End If
                Catch ex As Exception
                End Try
            Else
                If Session("Discom") <> "NONE" Then
                    BindData("Zone")
                End If
            End If


            If Session("AccessCircle") <> "NONE" Then
                bind_Circle()
                Try
                    If ddlCircle.SelectedItem.Text.ToString <> "Select" Then
                        circle = ddlCircle.SelectedItem.Text.ToString()
                        Session("Circle") = circle
                        Session("flag") = 2
                    Else
                        ddlCircle.SelectedIndex = 1
                        Session("Circle") = ddlCircle.SelectedItem.Text.ToString()
                    End If
                Catch ex As Exception
                End Try
            Else
                If Session("Zone") <> "NONE" Then
                    BindData("Circle")
                End If

            End If

            If Session("AccessDivision") <> "NONE" Then
                bind_Division()
                Try
                    If ddlDivision.SelectedItem.Text.ToString <> "Select" Then
                        division = ddlDivision.SelectedItem.Text.ToString()
                        Session("Division") = division
                        Session("flag") = 3
                    Else
                        ddlDivision.SelectedIndex = 1
                        Session("Division") = ddlDivision.SelectedItem.Text.ToString()
                    End If
                Catch ex As Exception
                End Try
            Else
                If Session("Circle") <> "NONE" Then
                    BindData("Division")
                End If
                '    ddlDivision.SelectedIndex = -1
                '    Session("Division") = ddlDivision.SelectedItem.Text.ToString()
            End If


            If Session("AccessSubDivision") <> "NONE" Then
                bindSubDivision()
                Try
                    If ddlSubdivision.SelectedItem.Text.ToString <> "Select" Then
                        subdivision = ddlSubdivision.SelectedItem.Text.ToString()
                        Session("Division") = subdivision
                        Session("flag") = 3
                    Else
                        ddlSubdivision.SelectedIndex = 1
                        Session("SubDivision") = ddlSubdivision.SelectedItem.Text.ToString()
                    End If
                Catch ex As Exception
                End Try
            Else
                If Session("Division") <> "NONE" Then
                    BindData("SubDivision")
                End If

            End If

            If Session("AccessSubstation") <> "NONE" Then
                bindSubstation()
                Try
                    If ddlSubstation.SelectedItem.Text.ToString <> "Select" Then
                        substation = ddlSubstation.SelectedItem.Text.ToString()
                        Session("Substation") = substation
                    Else
                        ddlSubstation.SelectedIndex = 1
                        Session("Substation") = ddlSubstation.SelectedItem.Text.ToString()
                    End If
                Catch ex As Exception
                End Try
            Else
                If Session("Substation") <> "NONE" Then
                    BindData("SubDivision")
                End If
            End If

            If Session("AccessSubstation") <> "NONE" Then
                bindFeeder()
                Try
                    If ddlFeeder.SelectedItem.Text.ToString <> "Select" Then
                        feeder = ddlFeeder.SelectedItem.Text.ToString()
                        Session("Feeder") = feeder
                    Else
                        ddlFeeder.SelectedIndex = 1
                        Session("Feeder") = ddlFeeder.SelectedItem.Text.ToString()
                    End If
                Catch ex As Exception
                End Try
                If Session("Substation") <> "NONE" Then
                    BindData("Substation")
                End If

            End If

        End If

    End Sub

    Protected Sub source_bind()
        Dim qry As String
        'qry = "select 'Select' source union all select distinct source from uppcl_staging.dbo.billed_unit_rapdrp where source <> 'MIXED'"
        qry = "select distinct source from uppcl_staging.dbo.billed_unit_rapdrp where source <> 'MIXED'"
        dt = Nothing
        dt = s1.GetDataTable(qry)
        ddlSource.DataTextField = dt.Columns(0).ToString()
        ddlSource.DataSource = dt
        ddlSource.DataBind()
        Try
            If Session("Source") <> Nothing Then
                ddlSource.SelectedValue = Session("Source")
            End If

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub bind_month()
        Dim dt1 As New DataTable
        Dim query As String
        query = "select distinct DisplayMonth,MonthValue from tblUPPCL_Month  order by 2 desc"
        dt1 = s1.GetDataTable(query)
        ddlmonth.DataTextField = dt1.Columns(0).ToString()
        ddlmonth.DataValueField = dt1.Columns(1).ToString()
        ddlmonth.DataSource = dt1
        ddlmonth.DataBind()
        'ddlmonth.Items.Insert(0, "Select")
        'Dim i As Integer = 0
        ddlmonth.SelectedValue = Session("Month")
        ddlmonth.SelectedIndex = 0

        'details month
        ddlmonth.DataTextField = dt1.Columns(0).ToString()
        ddlmonth.DataValueField = dt1.Columns(1).ToString()
        ddlmonth.DataSource = dt1
        ddlmonth.DataBind()
        ddlmonth.SelectedValue = Session("Month")
        ddlmonth.SelectedIndex = 0
    End Sub

    Protected Sub bind_discom()
       Dim dt1 As New DataTable
        Dim query As String = ""
        If Session("AccessDiscom") = "ALL" Then
            query = "Select distinct Discom from tblUPPCL_GlobalMasterMAP g,tblEAMT_StructureOmninetIE i where i.Division_ID=g.Division_ID"
        ElseIf Session("AccessDiscom") <> "ALL" Then
            query = "Select distinct Discom from tblUPPCL_GlobalMasterMAP g,tblEAMT_StructureOmninetIE i where i.Division_ID=g.Division_ID and Discom in (" & Session("AccessDiscom") & ")"
        End If
        dt1 = s1.GetDataTable(query)
        ddlDiscom.DataTextField = dt1.Columns(0).ToString()
        ddlDiscom.DataValueField = dt1.Columns(0).ToString()
        ddlDiscom.DataSource = dt1
        ddlDiscom.DataBind()
        ddlDiscom.Items.Insert(0, "Select")
        ddlDiscom.SelectedValue = Session("Discom")
        ddlDiscom.SelectedIndex = -1

    End Sub

    Protected Sub bind_zone()
         Dim dt1 As New DataTable
        Dim query As String = ""
        If Session("AccessZone") = "ALL" Then
            query = "Select distinct Zone from tblUPPCL_GlobalMasterMAP g,tblEAMT_StructureOmninetIE i where i.Division_ID=g.Division_ID and Discom ='" & ddlDiscom.SelectedItem.Text & "'"
        ElseIf Session("AccessZone") <> "ALL" Then
            query = "Select distinct Zone from tblUPPCL_GlobalMasterMAP g,tblEAMT_StructureOmninetIE i where i.Division_ID=g.Division_ID and Discom in (" & Session("AccessDiscom") & ") and Zone in (" & Session("AccessZone") & ")  and Discom='" & ddlDiscom.SelectedValue & "'"
        End If
        dt1 = s1.GetDataTable(query)
        ddlZone.DataTextField = dt1.Columns(0).ToString()
        ddlZone.DataValueField = dt1.Columns(0).ToString()
        ddlZone.DataSource = dt1
        ddlZone.DataBind()
        ddlZone.Items.Insert(0, "Select")
    End Sub

    Protected Sub bind_Circle()
        Dim dt1 As New DataTable
        Dim query As String = ""
        If Session("AccessCircle") = "ALL" Then
            query = "Select distinct Circle from tblUPPCL_GlobalMasterMAP g,tblEAMT_StructureOmninetIE i where i.Division_ID=g.Division_ID and Discom ='" & ddlDiscom.SelectedItem.Text & "' and Zone = '" & ddlZone.SelectedItem.Text & "' "
        ElseIf Session("AccessCircle") <> "ALL" Then
            query = "Select distinct Circle from tblUPPCL_GlobalMasterMAP g,tblEAMT_StructureOmninetIE i where i.Division_ID=g.Division_ID and Discom in (" & Session("AccessDiscom") & ") and Zone in (" & Session("AccessZone") & ") and Circle in (" & Session("AccessCircle") & ")   and Zone='" & ddlZone.SelectedValue & "' "
        End If
        dt1 = s1.GetDataTable(query)
        ddlCircle.DataTextField = dt1.Columns(0).ToString()
        ddlCircle.DataValueField = dt1.Columns(0).ToString()
        ddlCircle.DataSource = dt1
        ddlCircle.DataBind()
        ddlCircle.Items.Insert(0, "Select")
    End Sub


    Protected Sub bind_Division()
         Dim dt1 As New DataTable
        Dim query As String = ""
        If Session("AccessDivision") = "ALL" Then
            query = "Select distinct Division from tblUPPCL_GlobalMasterMAP g,tblEAMT_StructureOmninetIE i where i.Division_ID=g.Division_ID and Discom ='" & ddlDiscom.SelectedItem.Text & "' and Zone = '" & ddlZone.SelectedItem.Text & "' and Circle='" & ddlCircle.SelectedItem.Text & "'    "
        ElseIf Session("AccessDivision") <> "ALL" Then
            query = "Select distinct Division from tblUPPCL_GlobalMasterMAP g,tblEAMT_StructureOmninetIE i where i.Division_ID=g.Division_ID and Discom in (" & Session("AccessDiscom") & ") and Zone in (" & Session("AccessZone") & ") and Circle in (" & Session("AccessCircle") & ") and Division in (" & Session("AccessDivision") & ")   and Circle='" & ddlCircle.SelectedValue & "' "
        End If
        dt1 = s1.GetDataTable(query)
        ddlDivision.DataTextField = dt1.Columns(0).ToString()
        ddlDivision.DataValueField = dt1.Columns(0).ToString()
        ddlDivision.DataSource = dt1
        ddlDivision.DataBind()
        ddlDivision.Items.Insert(0, "Select")
    End Sub

    Protected Sub bindSubDivision()
         Dim dt1 As New DataTable
        Dim query As String = ""
        If Session("AccessSubDivision") = "NONE" Then
            query = "Select distinct SubDivision from tblUPPCL_GlobalMasterMAP g,tblEAMT_StructureOmninetIE i where i.Division_ID=g.Division_ID and Discom in (" & Session("AccessDiscom") & ") and Zone in (" & Session("AccessZone") & ") and Circle in (" & Session("AccessCircle") & ") and Division in (" & Session("AccessDivision") & ") and Division='" & ddlDivision.SelectedValue & "'"
        ElseIf Session("AccessSubDivision") = "ALL" Then
            query = "Select distinct SubDivision from tblUPPCL_GlobalMasterMAP g,tblEAMT_StructureOmninetIE i where i.Division_ID=g.Division_ID and Discom ='" & ddlDiscom.SelectedItem.Text & "' and Zone = '" & ddlZone.SelectedItem.Text & "' and Circle='" & ddlCircle.SelectedItem.Text & "' and Division='" & ddlDivision.SelectedItem.Text & "'  "
        ElseIf Session("AccessDiscom") <> "ALL" Then
            query = "Select distinct SubDivision from tblUPPCL_GlobalMasterMAP g,tblEAMT_StructureOmninetIE i where i.Division_ID=g.Division_ID and Discom in (" & Session("AccessDiscom") & ") and Zone in (" & Session("AccessZone") & ") and Circle in (" & Session("AccessCircle") & ") and Division in (" & Session("AccessDivision") & ") and SubDivision in (" & Session("AccessSubDivision") & ")  and Division='" & ddlDivision.SelectedValue & "' "
        End If
        dt1 = s1.GetDataTable(query)
        ddlSubdivision.DataTextField = dt1.Columns(0).ToString()
        ddlSubdivision.DataValueField = dt1.Columns(0).ToString()
        ddlSubdivision.DataSource = dt1
        ddlSubdivision.DataBind()
        ddlSubdivision.Items.Insert(0, "Select")
    End Sub

    Protected Sub bindSubstation()
        Try
         Dim dt1 As New DataTable
            Dim query As String = ""
            If Session("AccessSubstation") = "NONE" Then
                query = "Select distinct Substation from tblUPPCL_GlobalMasterMAP g,tblEAMT_StructureOmninetIE i where i.Division_ID=g.Division_ID and Discom in (" & Session("AccessDiscom") & ") and Zone in (" & Session("AccessZone") & ") and Circle in (" & Session("AccessCircle") & ") and Division in (" & Session("AccessDivision") & ") and Division='" & ddlDivision.SelectedValue & "'"
            ElseIf Session("AccessSubstation") = "ALL" Then
                query = "Select distinct Substation from tblUPPCL_GlobalMasterMAP g,tblEAMT_StructureOmninetIE i where i.Division_ID=g.Division_ID and Discom ='" & ddlDiscom.SelectedItem.Text & "' and Zone = '" & ddlZone.SelectedItem.Text & "' and Circle='" & ddlCircle.SelectedItem.Text & "' and Division='" & ddlDivision.SelectedItem.Text & "'  "
            ElseIf Session("AccessSubstation") <> "ALL" Then
                query = "Select distinct Substation from tblUPPCL_GlobalMasterMAP g,tblEAMT_StructureOmninetIE i where i.Division_ID=g.Division_ID and Discom in (" & Session("AccessDiscom") & ") and Zone in (" & Session("AccessZone") & ") and Circle in (" & Session("AccessCircle") & ") and Division in (" & Session("AccessDivision") & ") and SubDivision in (" & Session("AccessSubDivision") & ") and Substation in (" & Session("AccessSubstation") & ")  and Division='" & ddlDivision.SelectedValue & "' "
            End If
            dt1 = s1.GetDataTable(query)
            ddlSubstation.DataTextField = dt1.Columns(0).ToString()
            ddlSubstation.DataValueField = dt1.Columns(0).ToString()
            ddlSubstation.DataSource = dt1
            ddlSubstation.DataBind()
            ddlSubstation.Items.Insert(0, "Select")
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub bindFeeder()
        Dim dt1 As New DataTable
        Dim query As String = ""
        If Session("AccessFeeder") = "NONE" Then
            query = "Select distinct g.Feeder_ID from tblUPPCL_GlobalMasterMAP g,tblEAMT_StructureOmninetIE i where i.Division_ID=g.Division_ID and Discom in (" & Session("AccessDiscom") & ") and Zone in (" & Session("AccessZone") & ") and Circle in (" & Session("AccessCircle") & ") and Division in (" & Session("AccessDivision") & ")  and SubDivision in (" & Session("AccessSubDivision") & ") and Substation in (" & Session("AccessSubstation") & ") and Substation='" & ddlSubstation.SelectedValue & "'"
        ElseIf Session("AccessFeeder") = "ALL" Then
            query = "Select distinct g.Feeder_ID from tblUPPCL_GlobalMasterMAP g,tblEAMT_StructureOmninetIE i where i.Division_ID=g.Division_ID and Discom ='" & ddlDiscom.SelectedItem.Text & "' and Zone = '" & ddlZone.SelectedItem.Text & "' and Circle='" & ddlCircle.SelectedItem.Text & "' and Division='" & ddlDivision.SelectedItem.Text & "'  "
        ElseIf Session("AccessFeeder") <> "ALL" Then
            query = "Select distinct g.Feeder_ID from tblUPPCL_GlobalMasterMAP g,tblEAMT_StructureOmninetIE i where i.Division_ID=g.Division_ID and Discom in (" & Session("AccessDiscom") & ") and Zone in (" & Session("AccessZone") & ") and Circle in (" & Session("AccessCircle") & ") and Division in (" & Session("AccessDivision") & ") and SubDivision in (" & Session("AccessSubDivision") & ") and Substation in (" & Session("AccessSubstation") & ")  and Division='" & ddlDivision.SelectedValue & "' "
        End If
        dt1 = s1.GetDataTable(query)
        ddlFeeder.DataTextField = dt1.Columns(0).ToString()
        ddlFeeder.DataValueField = dt1.Columns(0).ToString()
        ddlFeeder.DataSource = dt1
        ddlFeeder.DataBind()
        ddlFeeder.Items.Insert(0, "Select")
        'ddlFeeder.SelectedValue = Session("Month")
        'ddlFeeder.SelectedIndex = 1
    End Sub


    Protected Sub ddlDiscom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlDiscom.SelectedIndexChanged
        Dim dt1 As New DataTable
        Dim query As String = ""
        dt1 = s1.bind_dropdown("Zone", ddlDiscom.SelectedItem.Text, "", "", "", "", "", "", ddlSource.SelectedValue.ToString)
        ddlZone.DataTextField = dt1.Columns(1).ToString()
        ddlZone.DataValueField = dt1.Columns(1).ToString()
        ddlZone.DataSource = dt1
        ddlZone.DataBind()
        ddlZone.Items.Insert(0, "Select")
        'ddlZone.SelectedValue = Session("Month")
        ddlZone.SelectedIndex = 0
        ddlCircle.Items.Clear()
        ddlDivision.Items.Clear()
        ddlSubdivision.Items.Clear()
        ddlSubstation.Items.Clear()
        ddlFeeder.Items.Clear()
        If ddlFeeder.SelectedIndex > 0 Then
            pnllevel4.Visible = False
            pnlFeeder.Visible = True
            'bind_Grid_FeederDetails()
        Else
            'bind_Grid()
            pnllevel4.Visible = True
            pnlFeeder.Visible = False
        End If
    End Sub

    Protected Sub ddlZone_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlZone.SelectedIndexChanged
        Dim dt1 As New DataTable
        Dim query As String = ""
        dt1 = s1.bind_dropdown("Circle", ddlDiscom.SelectedItem.Text, ddlZone.SelectedItem.Text, "", "", "", "", "", ddlSource.SelectedValue.ToString)
        ddlCircle.DataTextField = dt1.Columns(2).ToString()
        ddlCircle.DataValueField = dt1.Columns(2).ToString()
        ddlCircle.DataSource = dt1
        ddlCircle.DataBind()
        ddlCircle.Items.Insert(0, "Select")
        'ddlCircle.SelectedValue = Session("Month")
        ddlCircle.SelectedIndex = 0
        ddlDivision.Items.Clear()
        ddlSubdivision.Items.Clear()
        ddlSubstation.Items.Clear()
        ddlFeeder.Items.Clear()
        If ddlFeeder.SelectedIndex > 0 Then
            pnllevel4.Visible = False
            pnlFeeder.Visible = True
            'bind_Grid_FeederDetails()
        Else
            'bind_Grid()
            pnllevel4.Visible = True
            pnlFeeder.Visible = False
        End If
    End Sub

    Protected Sub ddlCircle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCircle.SelectedIndexChanged
        Dim dt1 As New DataTable
        Dim query As String = ""
        dt1 = s1.bind_dropdown("Division", ddlDiscom.SelectedItem.Text, ddlZone.SelectedItem.Text, ddlCircle.SelectedItem.Text, "", "", "", "", ddlSource.SelectedValue.ToString)
        ddlDivision.DataTextField = dt1.Columns(3).ToString()
        ddlDivision.DataValueField = dt1.Columns(3).ToString()
        ddlDivision.DataSource = dt1
        ddlDivision.DataBind()
        ddlDivision.Items.Insert(0, "Select")
        'ddlCircle.SelectedValue = Session("Month")
        ddlDivision.SelectedIndex = 0
        ddlSubdivision.Items.Clear()
        ddlSubstation.Items.Clear()
        ddlFeeder.Items.Clear()
        If ddlFeeder.SelectedIndex > 0 Then
            pnllevel4.Visible = False
            pnlFeeder.Visible = True
            'bind_Grid_FeederDetails()
        Else
            'bind_Grid()
            pnllevel4.Visible = True
            pnlFeeder.Visible = False
        End If
    End Sub

    Protected Sub ddlDivision_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlDivision.SelectedIndexChanged
        Dim dt1 As New DataTable
        Dim query As String = ""
        dt1 = s1.bind_dropdown("Subdivision", ddlDiscom.SelectedItem.Text, ddlZone.SelectedItem.Text, ddlCircle.SelectedItem.Text, ddlDivision.SelectedItem.Text, "", "", "", ddlSource.SelectedValue.ToString)
        ddlSubdivision.DataTextField = dt1.Columns(4).ToString()
        ddlSubdivision.DataValueField = dt1.Columns(4).ToString()
        ddlSubdivision.DataSource = dt1
        ddlSubdivision.DataBind()
        ddlSubdivision.Items.Insert(0, "Select")
        'ddlCircle.SelectedValue = Session("Month")
        ddlSubdivision.SelectedIndex = 0
        ddlSubstation.Items.Clear()
        ddlFeeder.Items.Clear()
        If ddlFeeder.SelectedIndex > 0 Then
            pnllevel4.Visible = False
            pnlFeeder.Visible = True
            'bind_Grid_FeederDetails()
        Else
            'bind_Grid()
            pnllevel4.Visible = True
            pnlFeeder.Visible = False
        End If
    End Sub

    Protected Sub ddlSubdivision_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSubdivision.SelectedIndexChanged
        Dim dt1 As New DataTable
        Dim query As String = ""
        dt1 = s1.bind_dropdown("Substation", ddlDiscom.SelectedItem.Text, ddlZone.SelectedItem.Text, ddlCircle.SelectedItem.Text, ddlDivision.SelectedItem.Text, ddlSubdivision.SelectedItem.Text, "", "", ddlSource.SelectedValue.ToString)
        ddlSubstation.DataTextField = dt1.Columns(5).ToString()
        ddlSubstation.DataValueField = dt1.Columns(5).ToString()
        ddlSubstation.DataSource = dt1
        ddlSubstation.DataBind()
        ddlSubstation.Items.Insert(0, "Select")
        ddlSubstation.SelectedIndex = 0
        ddlFeeder.Items.Clear()
        If ddlFeeder.SelectedIndex > 0 Then
            pnllevel4.Visible = False
            pnlFeeder.Visible = True
            'bind_Grid_FeederDetails()
        Else
            'bind_Grid()
            pnllevel4.Visible = True
            pnlFeeder.Visible = False
        End If
    End Sub

    Protected Sub ddlSubstation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSubstation.SelectedIndexChanged
        Dim dt1 As New DataTable
        Dim query As String = ""
        dt1 = s1.bind_dropdown("Feeder", ddlDiscom.SelectedItem.Text, ddlZone.SelectedItem.Text, ddlCircle.SelectedItem.Text, ddlDivision.SelectedItem.Text, ddlSubdivision.SelectedItem.Text, ddlSubstation.SelectedItem.Text, "", ddlSource.SelectedValue.ToString)
        ddlFeeder.DataTextField = dt1.Columns(6).ToString()
        ddlFeeder.DataValueField = dt1.Columns(6).ToString()
        ddlFeeder.DataSource = dt1
        ddlFeeder.DataBind()
        ddlFeeder.Items.Insert(0, "Select")
        ddlFeeder.SelectedIndex = 0
        If ddlFeeder.SelectedIndex > 0 Then
            pnllevel4.Visible = False
            pnlFeeder.Visible = True
            bind_Grid_FeederDetails()
        Else
            bind_Grid()
            pnllevel4.Visible = True
            pnlFeeder.Visible = False
        End If
    End Sub

    Protected Sub BindData(GetVale As String)
        Dim mode As String = ""
        Dim dt1 As New DataTable
        Dim query As String = ""
        mode = GetVale
        Select Case mode
            Case "Discome"
                dt1 = s1.bind_dropdown("Discom", "", "", "", "", "", "", "", ddlSource.SelectedValue.ToString)
                ddlDiscom.DataTextField = dt1.Columns(0).ToString()
                ddlDiscom.DataValueField = dt1.Columns(0).ToString()
                ddlDiscom.DataSource = dt1
                ddlDiscom.DataBind()
                ddlDiscom.Items.Insert(0, "Select")
                ddlDiscom.SelectedIndex = 0
            Case "Zone"
                dt1 = s1.bind_dropdown("Zone", ddlDiscom.SelectedItem.Text, "", "", "", "", "", "", ddlSource.SelectedValue.ToString)
                ddlZone.DataTextField = dt1.Columns(1).ToString()
                ddlZone.DataValueField = dt1.Columns(1).ToString()
                ddlZone.DataSource = dt1
                ddlZone.DataBind()
                ddlZone.Items.Insert(0, "Select")
                ddlZone.SelectedIndex = 0
            Case "Circle"
                dt1 = s1.bind_dropdown("Circle", ddlDiscom.SelectedItem.Text, ddlZone.SelectedItem.Text, "", "", "", "", "", ddlSource.SelectedValue.ToString)
                ddlCircle.DataTextField = dt1.Columns(2).ToString()
                ddlCircle.DataValueField = dt1.Columns(2).ToString()
                ddlCircle.DataSource = dt1
                ddlCircle.DataBind()
                ddlCircle.Items.Insert(0, "Select")
                ddlCircle.SelectedIndex = 0
            Case "Division"

                dt1 = s1.bind_dropdown("Division", ddlDiscom.SelectedItem.Text, ddlZone.SelectedItem.Text, ddlCircle.SelectedItem.Text, "", "", "", "", ddlSource.SelectedValue.ToString)
                ddlDivision.DataTextField = dt1.Columns(3).ToString()
                ddlDivision.DataValueField = dt1.Columns(3).ToString()
                ddlDivision.DataSource = dt1
                ddlDivision.DataBind()
                ddlDivision.Items.Insert(0, "Select")

            Case "SubDivision"
                dt1 = s1.bind_dropdown("Subdivision", ddlDiscom.SelectedItem.Text, ddlZone.SelectedItem.Text, ddlCircle.SelectedItem.Text, ddlDivision.SelectedItem.Text, "", "", "", ddlSource.SelectedValue.ToString)
                ddlSubDivision.DataTextField = dt1.Columns(4).ToString()
                ddlSubDivision.DataValueField = dt1.Columns(4).ToString()
                ddlSubDivision.DataSource = dt1
                ddlSubDivision.DataBind()
                ddlSubDivision.Items.Insert(0, "Select")

            Case "Substation"
                dt1 = s1.bind_dropdown("Substation", ddlDiscom.SelectedItem.Text, ddlZone.SelectedItem.Text, ddlCircle.SelectedItem.Text, ddlDivision.SelectedItem.Text, ddlSubdivision.SelectedItem.Text, "", "", ddlSource.SelectedValue.ToString)
                ddlSubstation.DataTextField = dt1.Columns(5).ToString()
                ddlSubstation.DataValueField = dt1.Columns(5).ToString()
                ddlSubstation.DataSource = dt1
                ddlSubstation.DataBind()
                ddlSubstation.Items.Insert(0, "Select")

            Case "Feeder"
                dt1 = s1.bind_dropdown("Feeder", ddlDiscom.SelectedItem.Text, ddlZone.SelectedItem.Text, ddlCircle.SelectedItem.Text, ddlDivision.SelectedItem.Text, ddlSubdivision.SelectedItem.Text, ddlSubstation.SelectedItem.Text, "", ddlSource.SelectedValue.ToString)
                ddlFeeder.DataTextField = dt1.Columns(6).ToString()
                ddlFeeder.DataValueField = dt1.Columns(6).ToString()
                ddlFeeder.DataSource = dt1
                ddlFeeder.DataBind()
                ddlFeeder.Items.Insert(0, "Select")
        End Select
    End Sub

    Public Sub bind_Grid()
        If ddlDiscom.SelectedValue = "" Then
            Discom = "Select"
        Else
            Discom = ddlDiscom.SelectedValue
        End If
        If ddlZone.SelectedValue = "" Then
            Zone = "Select"
        Else
            Zone = ddlZone.SelectedValue
        End If
        If ddlCircle.SelectedValue = "" Then
            Circle = "Select"
        Else
            Circle = ddlCircle.SelectedValue
        End If
        If ddlDivision.SelectedValue = "" Then
            Division = "Select"
        Else
            Division = ddlDivision.SelectedValue
        End If
        If ddlSubdivision.SelectedValue = "" Then
            Subdivision = "Select"
        Else
            Subdivision = ddlSubdivision.SelectedValue
        End If
        If ddlSubstation.SelectedValue = "" Then
            Substation = "Select"
        Else
            Substation = ddlSubstation.SelectedValue
        End If
        If ddlFeeder.SelectedValue = "" Then
            Feeder = "Select"
        Else
            Feeder = ddlFeeder.SelectedValue
        End If

        Dim strConnString As String = objMainCLS.myconnection
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()
        Dim dt As New DataTable()
        cmd.CommandType = CommandType.StoredProcedure

        cmd.CommandText = "[dbo].[proc_Level4_FeederAuditetReport]"
        'cmd.Parameters.Add("@MonthStart", SqlDbType.VarChar).Value = txtStartMonth.Text
        'cmd.Parameters.Add("@MonthEnd", SqlDbType.VarChar).Value = txtEndMonth.Text
        cmd.Parameters.Add("@Parameter", SqlDbType.VarChar).Value = ddlParameters.SelectedValue
        cmd.Parameters.Add("@Source", SqlDbType.VarChar).Value = ddlSource.SelectedValue
        cmd.Parameters.Add("@Month", SqlDbType.VarChar).Value = ddlmonth.SelectedValue
        cmd.Parameters.Add("@Discom", SqlDbType.VarChar).Value = Discom
        cmd.Parameters.Add("@Zone", SqlDbType.VarChar).Value = Zone
        cmd.Parameters.Add("@Circle", SqlDbType.VarChar).Value = Circle
        cmd.Parameters.Add("@Division", SqlDbType.VarChar).Value = Division
        cmd.Parameters.Add("@Subdivision", SqlDbType.VarChar).Value = Subdivision
        cmd.Parameters.Add("@Substation", SqlDbType.VarChar).Value = Substation
        cmd.Parameters.Add("@Feeder", SqlDbType.VarChar).Value = "Select"
        cmd.Connection = con
        Try
            con.Open()
            cmd.CommandTimeout = 250
            Using sda As New SqlDataAdapter(cmd)
                sda.Fill(dt)
            End Using
            If dt.Rows.Count > 0 Then
                gridViewLevel1details.DataSource = dt
                'gridViewDetails.Columns().HeaderText = "Sandeep"
                gridViewLevel1details.DataBind()
                lblMISReports.Text = ""
                'btnExportExcel.Visible = True
                'btnPrint.Visible = True
                'lblmsg.Text = ""
            Else
                lblMISReports.Text = " Data Not Found "
                gridViewLevel1details.DataSource = Nothing
                gridViewLevel1details.DataBind()
                'btnExportExcel.Visible = False
                'btnPrint.Visible = False
                Exit Sub
            End If
        Catch ex As Exception
            lblMISReports.Text = ex.ToString
            Response.Redirect("Login.aspx")
        Finally
            con.Close()
            con.Dispose()
        End Try
    End Sub
    Public Sub bind_role()

        Dim role As String = Session("Role").ToString.ToUpper

        If role = "DISCOM" Then
            ddlDiscom.Enabled = False

        ElseIf role = "DIVISION" Then
            ddlDiscom.Enabled = False
            ddlZone.Enabled = False
            ddlCircle.Enabled = False


        ElseIf role = "CIRCLE" Then
            ddlDiscom.Enabled = False
            ddlZone.Enabled = False

        ElseIf role = "ZONE" Then

        ElseIf role = "UPPCL" Then

        ElseIf role = "SUBDIVISION" Then
            ddlDiscom.Enabled = False
            ddlZone.Enabled = False
            ddlCircle.Enabled = False
            ddlDivision.Enabled = False
        ElseIf role = "SUBSTATION" Then
            ddlDiscom.Enabled = False
            ddlZone.Enabled = False
            ddlCircle.Enabled = False
            ddlDivision.Enabled = False
            ddlSubdivision.Enabled = False
        ElseIf role = "FEEDER" Then
            ddlDiscom.Enabled = False
            ddlZone.Enabled = False
            ddlCircle.Enabled = False
            ddlDivision.Enabled = False
            ddlSubdivision.Enabled = False
            ddlSubstation.Enabled = False

        End If
    End Sub
    Public Sub bind_Grid_FeederDetails()
        If ddlDiscom.SelectedValue = "" Then
            discom = "Select"
        Else
            discom = ddlDiscom.SelectedValue
        End If
        If ddlZone.SelectedValue = "" Then
            zone = "Select"
        Else
            zone = ddlZone.SelectedValue
        End If
        If ddlCircle.SelectedValue = "" Then
            circle = "Select"
        Else
            circle = ddlCircle.SelectedValue
        End If
        If ddlDivision.SelectedValue = "" Then
            division = "Select"
        Else
            division = ddlDivision.SelectedValue
        End If
        If ddlSubdivision.SelectedValue = "" Then
            subdivision = "Select"
        Else
            subdivision = ddlSubdivision.SelectedValue
        End If
        If ddlSubstation.SelectedValue = "" Then
            substation = "Select"
        Else
            substation = ddlSubstation.SelectedValue
        End If
        If ddlFeeder.SelectedValue = "" Then
            feeder = "Select"
        Else
            feeder = ddlFeeder.SelectedValue
        End If

        Dim strConnString As String = objMainCLS.myconnection
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()
        Dim dt As New DataTable()
        cmd.CommandType = CommandType.StoredProcedure

        cmd.CommandText = "[dbo].[proc_Level4_DetailsFeeder]"
        'cmd.Parameters.Add("@MonthStart", SqlDbType.VarChar).Value = txtStartMonth.Text
        'cmd.Parameters.Add("@MonthEnd", SqlDbType.VarChar).Value = txtEndMonth.Text
        'cmd.Parameters.Add("@Parameter", SqlDbType.VarChar).Value = ddlParameters.SelectedValue
        cmd.Parameters.Add("@Month", SqlDbType.VarChar).Value = ddlmonth.SelectedValue
        cmd.Parameters.Add("@Discom", SqlDbType.VarChar).Value = discom
        cmd.Parameters.Add("@Zone", SqlDbType.VarChar).Value = zone
        cmd.Parameters.Add("@Circle", SqlDbType.VarChar).Value = circle
        cmd.Parameters.Add("@Division", SqlDbType.VarChar).Value = division
        cmd.Parameters.Add("@Subdivision", SqlDbType.VarChar).Value = subdivision
        cmd.Parameters.Add("@Substation", SqlDbType.VarChar).Value = substation
        cmd.Parameters.Add("@Feeder", SqlDbType.VarChar).Value = feeder
        cmd.Parameters.Add("@Source", SqlDbType.VarChar).Value = ddlSource.SelectedValue
        cmd.Connection = con
        Try
            con.Open()
            cmd.CommandTimeout = 250
            Using sda As New SqlDataAdapter(cmd)
                sda.Fill(dt)
            End Using
            If dt.Rows.Count > 0 Then
                'gridViewLevel1details.DataSource = dt
                'gridViewDetails.Columns().HeaderText = "Sandeep"
                'gridViewLevel1details.DataBind()
                lblMISReports.Text = ""
                'lblSubSationName.Text = dt.Rows(0)(1).ToString
                lblSancationLoad.Text = dt.Rows(0)(2).ToString
                lblInputEnergy.Text = dt.Rows(0)(3).ToString
                lblBilledUnit.Text = dt.Rows(0)(4).ToString
                lblBillingEfficency.Text = dt.Rows(0)(5).ToString
                lblLineLoss.Text = dt.Rows(0)(6).ToString
                lblBillableConsumer.Text = dt.Rows(0)(7).ToString
                lblBilledConsumer.Text = dt.Rows(0)(8).ToString
                lblBillingPer.Text = dt.Rows(0)(9).ToString
                lblReadingBasedBilledConsumer.Text = dt.Rows(0)(10).ToString
                lblMeteredBilling.Text = dt.Rows(0)(11).ToString
                lblAssessment.Text = dt.Rows(0)(12).ToString
                lblRealization.Text = dt.Rows(0)(13).ToString
                lblCollectionEfficency.Text = dt.Rows(0)(14).ToString
                lblATCLoss.Text = dt.Rows(0)(15).ToString
                lblTurnUpConsumer.Text = dt.Rows(0)(16).ToString
                lblTurnUpRation.Text = dt.Rows(0)(17).ToString
                lblThrRate.Text = dt.Rows(0)(18).ToString
                lblABR.Text = dt.Rows(0)(19).ToString
                'btnExportExcel.Visible = True
                'btnPrint.Visible = True
                'lblmsg.Text = ""
            Else
                lblMISReports.Text = " Data Not Found "
                'gridViewLevel1details.DataSource = Nothing
                'gridViewLevel1details.DataBind()
                lblSancationLoad.Text = ""
                lblInputEnergy.Text = ""
                lblBilledUnit.Text = ""
                lblBillingEfficency.Text = ""
                lblLineLoss.Text = ""
                lblBillableConsumer.Text = ""
                lblBilledConsumer.Text = ""
                lblBillingPer.Text = ""
                lblReadingBasedBilledConsumer.Text = ""
                lblMeteredBilling.Text = ""
                lblAssessment.Text = ""
                lblRealization.Text = ""
                lblCollectionEfficency.Text = ""
                lblATCLoss.Text = ""
                lblTurnUpConsumer.Text = ""
                lblTurnUpRation.Text = ""
                lblThrRate.Text = ""
                lblABR.Text = ""


                'btnExportExcel.Visible = False
                'btnPrint.Visible = False
                Exit Sub
            End If
        Catch ex As Exception
            lblMISReports.Text = ex.ToString
            Response.Redirect("Login.aspx")
        Finally
            con.Close()
            con.Dispose()
        End Try
    End Sub

    Protected Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If ddlFeeder.SelectedIndex > 0 Then
            pnllevel4.Visible = False
            pnlFeeder.Visible = True
            bind_Grid_FeederDetails()
        Else
            bind_Grid()
            pnllevel4.Visible = True
            pnlFeeder.Visible = False
        End If
    End Sub

    Protected Sub ddlParameters_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlParameters.SelectedIndexChanged
        If ddlFeeder.SelectedIndex > 0 Then
            pnllevel4.Visible = False
            pnlFeeder.Visible = True
            'bind_Grid_FeederDetails()
        Else
            'bind_Grid()
            pnllevel4.Visible = True
            pnlFeeder.Visible = False
        End If
    End Sub

    Protected Sub ddlmonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlmonth.SelectedIndexChanged
        If ddlFeeder.SelectedIndex > 0 Then
            pnllevel4.Visible = False
            pnlFeeder.Visible = True
            'bind_Grid_FeederDetails()
        Else
            'bind_Grid()
            pnllevel4.Visible = True
            pnlFeeder.Visible = False
        End If
    End Sub

    Protected Sub ddlFeeder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlFeeder.SelectedIndexChanged
        If ddlFeeder.SelectedIndex > 0 Then
            pnllevel4.Visible = False
            pnlFeeder.Visible = True
            bind_Grid_FeederDetails()
        Else
            bind_Grid()
            pnllevel4.Visible = True
            pnlFeeder.Visible = False
        End If
    End Sub

    Protected Sub ddlSource_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSource.SelectedIndexChanged
        If ddlFeeder.SelectedIndex > 0 Then
            pnllevel4.Visible = False
            pnlFeeder.Visible = True
            'bind_Grid_FeederDetails()
        Else
            'bind_Grid()
            pnllevel4.Visible = True
            pnlFeeder.Visible = False
        End If
    End Sub
End Class
