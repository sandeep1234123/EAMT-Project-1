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

Partial Class frmLevel3
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
        qry = "select distinct source from DT_Audit_Report where source <> 'MIXED'"
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
            query = "Select distinct g.Discom from tblUPPCL_GlobalMasterMAP g,DT_Audit_Report i where i.Division_ID=g.Division_ID"
        ElseIf Session("AccessDiscom") <> "ALL" Then
            query = "Select distinct g.Discom from tblUPPCL_GlobalMasterMAP g,DT_Audit_Report i where i.Division_ID=g.Division_ID and g.Discom in (" & Session("AccessDiscom") & ")"
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
            query = "Select distinct g.Zone from tblUPPCL_GlobalMasterMAP g,DT_Audit_Report i where i.Division_ID=g.Division_ID and g.Discom ='" & ddlDiscom.SelectedItem.Text & "'"
        ElseIf Session("AccessZone") <> "ALL" Then
            query = "Select distinct g.Zone from tblUPPCL_GlobalMasterMAP g,DT_Audit_Report i where i.Division_ID=g.Division_ID and g.Discom in (" & Session("AccessDiscom") & ") and g.Zone in (" & Session("AccessZone") & ")  and g.Discom='" & ddlDiscom.SelectedValue & "'"
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
            query = "Select distinct g.Circle from tblUPPCL_GlobalMasterMAP g,DT_Audit_Report i where i.Division_ID=g.Division_ID and g.Discom ='" & ddlDiscom.SelectedItem.Text & "' and g.Zone = '" & ddlZone.SelectedItem.Text & "' "
        ElseIf Session("AccessCircle") <> "ALL" Then
            query = "Select distinct g.Circle from tblUPPCL_GlobalMasterMAP g,DT_Audit_Report i where i.Division_ID=g.Division_ID and g.Discom in (" & Session("AccessDiscom") & ") and g.Zone in (" & Session("AccessZone") & ") and g.Circle in (" & Session("AccessCircle") & ")   and g.Zone='" & ddlZone.SelectedValue & "' "
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
            query = "Select distinct g.Division from tblUPPCL_GlobalMasterMAP g,DT_Audit_Report i where i.Division_ID=g.Division_ID and g.Discom ='" & ddlDiscom.SelectedItem.Text & "' and g.Zone = '" & ddlZone.SelectedItem.Text & "' and g.Circle='" & ddlCircle.SelectedItem.Text & "'    "
        ElseIf Session("AccessDivision") <> "ALL" Then
            query = "Select distinct g.Division from tblUPPCL_GlobalMasterMAP g,DT_Audit_Report i where i.Division_ID=g.Division_ID and g.Discom in (" & Session("AccessDiscom") & ") and g.Zone in (" & Session("AccessZone") & ") and g.Circle in (" & Session("AccessCircle") & ") and g.Division in (" & Session("AccessDivision") & ")   and g.Circle='" & ddlCircle.SelectedValue & "' "
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
            query = "Select distinct g.SubDivision from tblUPPCL_GlobalMasterMAP g,DT_Audit_Report i where i.Division_ID=g.Division_ID and g.Discom in (" & Session("AccessDiscom") & ") and g.Zone in (" & Session("AccessZone") & ") and g.Circle in (" & Session("AccessCircle") & ") and g.Division in (" & Session("AccessDivision") & ") and g.Division='" & ddlDivision.SelectedValue & "'"
        ElseIf Session("AccessSubDivision") = "ALL" Then
            query = "Select distinct g.SubDivision from tblUPPCL_GlobalMasterMAP g,DT_Audit_Report i where i.Division_ID=g.Division_ID and g.Discom ='" & ddlDiscom.SelectedItem.Text & "' and g.Zone = '" & ddlZone.SelectedItem.Text & "' and g.Circle='" & ddlCircle.SelectedItem.Text & "' and g.Division='" & ddlDivision.SelectedItem.Text & "'  "
        ElseIf Session("AccessDiscom") <> "ALL" Then
            query = "Select distinct g.SubDivision from tblUPPCL_GlobalMasterMAP g,DT_Audit_Report i where i.Division_ID=g.Division_ID and g.Discom in (" & Session("AccessDiscom") & ") and g.Zone in (" & Session("AccessZone") & ") and g.Circle in (" & Session("AccessCircle") & ") and g.Division in (" & Session("AccessDivision") & ") and g.SubDivision in (" & Session("AccessSubDivision") & ")  and g.Division='" & ddlDivision.SelectedValue & "' "
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
                query = "Select distinct g.Substation from tblUPPCL_GlobalMasterMAP g,DT_Audit_Report i where i.Division_ID=g.Division_ID and g.Discom in (" & Session("AccessDiscom") & ") and g.Zone in (" & Session("AccessZone") & ") and g.Circle in (" & Session("AccessCircle") & ") and g.Division in (" & Session("AccessDivision") & ") and g.Division='" & ddlDivision.SelectedValue & "'"
            ElseIf Session("AccessSubstation") = "ALL" Then
                query = "Select distinct g.Substation from tblUPPCL_GlobalMasterMAP g,DT_Audit_Report i where i.Division_ID=g.Division_ID and g.Discom ='" & ddlDiscom.SelectedItem.Text & "' and g.Zone = '" & ddlZone.SelectedItem.Text & "' and g.Circle='" & ddlCircle.SelectedItem.Text & "' and g.Division='" & ddlDivision.SelectedItem.Text & "'  "
            ElseIf Session("AccessSubstation") <> "ALL" Then
                query = "Select distinct g.Substation from tblUPPCL_GlobalMasterMAP g,DT_Audit_Report i where i.Division_ID=g.Division_ID and g.Discom in (" & Session("AccessDiscom") & ") and g.Zone in (" & Session("AccessZone") & ") and g.Circle in (" & Session("AccessCircle") & ") and g.Division in (" & Session("AccessDivision") & ") and g.SubDivision in (" & Session("AccessSubDivision") & ") and g.Substation in (" & Session("AccessSubstation") & ")  and g.Division='" & ddlDivision.SelectedValue & "' "
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
            query = "Select distinct g.Feeder_ID from tblUPPCL_GlobalMasterMAP g,DT_Audit_Report i where i.Division_ID=g.Division_ID and g.Discom in (" & Session("AccessDiscom") & ") and g.Zone in (" & Session("AccessZone") & ") and g.Circle in (" & Session("AccessCircle") & ") and g.Division in (" & Session("AccessDivision") & ")  and g.SubDivision in (" & Session("AccessSubDivision") & ") and g.Substation in (" & Session("AccessSubstation") & ") and g.Substation='" & ddlSubstation.SelectedValue & "'"
        ElseIf Session("AccessFeeder") = "ALL" Then
            query = "Select distinct g.Feeder_ID from tblUPPCL_GlobalMasterMAP g,DT_Audit_Report i where i.Division_ID=g.Division_ID and g.Discom ='" & ddlDiscom.SelectedItem.Text & "' and g.Zone = '" & ddlZone.SelectedItem.Text & "' and g.Circle='" & ddlCircle.SelectedItem.Text & "' and g.Division='" & ddlDivision.SelectedItem.Text & "'  "
        ElseIf Session("AccessFeeder") <> "ALL" Then
            query = "Select distinct g.Feeder_ID from tblUPPCL_GlobalMasterMAP g,DT_Audit_Report i where i.Division_ID=g.Division_ID and g.Discom in (" & Session("AccessDiscom") & ") and g.Zone in (" & Session("AccessZone") & ") and g.Circle in (" & Session("AccessCircle") & ") and g.Division in (" & Session("AccessDivision") & ") and g.SubDivision in (" & Session("AccessSubDivision") & ") and g.Substation in (" & Session("AccessSubstation") & ")  and g.Division='" & ddlDivision.SelectedValue & "' "
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

    Protected Sub ddlmonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlmonth.SelectedIndexChanged
        BindData("Discom")
        ddlZone.Items.Clear()
        ddlCircle.Items.Clear()
        ddlDivision.Items.Clear()
        ddlSubdivision.Items.Clear()
        ddlSubstation.Items.Clear()
        ddlFeeder.Items.Clear()
    End Sub

    Protected Sub ddlDiscom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlDiscom.SelectedIndexChanged
        BindData("Zone")
        ddlCircle.Items.Clear()
        ddlDivision.Items.Clear()
        ddlSubdivision.Items.Clear()
        ddlSubstation.Items.Clear()
        ddlFeeder.Items.Clear()
    End Sub

    Protected Sub ddlZone_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlZone.SelectedIndexChanged
        BindData("Circle")
        ddlDivision.Items.Clear()
        ddlSubdivision.Items.Clear()
        ddlSubstation.Items.Clear()
        ddlFeeder.Items.Clear()
    End Sub

    Protected Sub ddlCircle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCircle.SelectedIndexChanged
        BindData("Division")
        ddlSubdivision.Items.Clear()
        ddlSubstation.Items.Clear()
        ddlFeeder.Items.Clear()
    End Sub

    Protected Sub ddlDivision_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlDivision.SelectedIndexChanged
        BindData("SubDivision")
        ddlSubstation.Items.Clear()
        ddlFeeder.Items.Clear()
    End Sub

    Protected Sub ddlSubdivision_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSubdivision.SelectedIndexChanged
        BindData("Substation")
        ddlFeeder.Items.Clear()
    End Sub

    Protected Sub ddlSubstation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSubstation.SelectedIndexChanged
        BindData("Feeder")
    End Sub

    Protected Sub ddlFeeder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlFeeder.SelectedIndexChanged
        If ddlFeeder.SelectedIndex > 0 Then
            bind_Grid()
            pnllevel4.Visible = True
            pnlFeeder.Visible = False
        Else
            'bind_Grid()
            'pnllevel4.Visible = True
            'pnlFeeder.Visible = False
        End If
    End Sub

    Protected Sub BindData(GetVale As String)
        Dim mode As String = ""
        Dim dt1 As New DataTable
        Dim query As String = ""
        mode = GetVale
        Select Case mode
            Case "Discom"
                dt1 = s1.bind_DT_dropdown("Discom", "", "", "", "", "", "", "")
                ddlDiscom.DataTextField = dt1.Columns(0).ToString()
                ddlDiscom.DataValueField = dt1.Columns(0).ToString()
                ddlDiscom.DataSource = dt1
                ddlDiscom.DataBind()
                ddlDiscom.Items.Insert(0, "Select")
                ddlDiscom.SelectedIndex = 0
                pnllevel4.Visible = True
                pnlFeeder.Visible = False
            Case "Zone"
                dt1 = s1.bind_DT_dropdown("Zone", ddlDiscom.SelectedItem.Text, "", "", "", "", "", "")
                ddlZone.DataTextField = dt1.Columns(1).ToString()
                ddlZone.DataValueField = dt1.Columns(1).ToString()
                ddlZone.DataSource = dt1
                ddlZone.DataBind()
                ddlZone.Items.Insert(0, "Select")
                ddlZone.SelectedIndex = 0
                pnllevel4.Visible = True
                pnlFeeder.Visible = False
            Case "Circle"
                dt1 = s1.bind_DT_dropdown("Circle", ddlDiscom.SelectedItem.Text, ddlZone.SelectedItem.Text, "", "", "", "", "")
                ddlCircle.DataTextField = dt1.Columns(2).ToString()
                ddlCircle.DataValueField = dt1.Columns(2).ToString()
                ddlCircle.DataSource = dt1
                ddlCircle.DataBind()
                ddlCircle.Items.Insert(0, "Select")
                ddlCircle.SelectedIndex = 0
                pnllevel4.Visible = False
                pnlFeeder.Visible = False
            Case "Division"
                dt1 = s1.bind_DT_dropdown("Division", ddlDiscom.SelectedItem.Text, ddlZone.SelectedItem.Text, ddlCircle.SelectedItem.Text, "", "", "", "")
                ddlDivision.DataTextField = dt1.Columns(3).ToString()
                ddlDivision.DataValueField = dt1.Columns(3).ToString()
                ddlDivision.DataSource = dt1
                ddlDivision.DataBind()
                ddlDivision.Items.Insert(0, "Select")
                pnllevel4.Visible = False
                pnlFeeder.Visible = False

            Case "SubDivision"
                dt1 = s1.bind_DT_dropdown("Subdivision", ddlDiscom.SelectedItem.Text, ddlZone.SelectedItem.Text, ddlCircle.SelectedItem.Text, ddlDivision.SelectedItem.Text, "", "", "")
                ddlSubdivision.DataTextField = dt1.Columns(4).ToString()
                ddlSubdivision.DataValueField = dt1.Columns(4).ToString()
                ddlSubdivision.DataSource = dt1
                ddlSubdivision.DataBind()
                ddlSubdivision.Items.Insert(0, "Select")
                pnllevel4.Visible = False
                pnlFeeder.Visible = False

            Case "Substation"
                dt1 = s1.bind_DT_dropdown("Substation", ddlDiscom.SelectedItem.Text, ddlZone.SelectedItem.Text, ddlCircle.SelectedItem.Text, ddlDivision.SelectedItem.Text, ddlSubdivision.SelectedItem.Text, "", "")
                ddlSubstation.DataTextField = dt1.Columns(5).ToString()
                ddlSubstation.DataValueField = dt1.Columns(5).ToString()
                ddlSubstation.DataSource = dt1
                ddlSubstation.DataBind()
                ddlSubstation.Items.Insert(0, "Select")
                pnllevel4.Visible = False
                pnlFeeder.Visible = False

            Case "Feeder"
                dt1 = s1.bind_DT_dropdown("Feeder", ddlDiscom.SelectedItem.Text, ddlZone.SelectedItem.Text, ddlCircle.SelectedItem.Text, ddlDivision.SelectedItem.Text, ddlSubdivision.SelectedItem.Text, ddlSubstation.SelectedItem.Text, "")
                ddlFeeder.DataTextField = dt1.Columns(6).ToString()
                ddlFeeder.DataValueField = dt1.Columns(6).ToString()
                ddlFeeder.DataSource = dt1
                ddlFeeder.DataBind()
                ddlFeeder.Items.Insert(0, "Select")
                pnllevel4.Visible = False
                pnlFeeder.Visible = False
        End Select
    End Sub

    Public Sub bind_Grid_Simmary()
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

        cmd.CommandText = "[dbo].[proc_Level3_DTAuditedReport]"
        'cmd.Parameters.Add("@MonthStart", SqlDbType.VarChar).Value = txtStartMonth.Text
        'cmd.Parameters.Add("@MonthEnd", SqlDbType.VarChar).Value = txtEndMonth.Text
        cmd.Parameters.Add("@Parameter", SqlDbType.VarChar).Value = ddlParameters.SelectedValue
        cmd.Parameters.Add("@Source", SqlDbType.VarChar).Value = ddlSource.SelectedValue
        cmd.Parameters.Add("@Month", SqlDbType.VarChar).Value = ddlmonth.SelectedValue
        cmd.Parameters.Add("@Discom", SqlDbType.VarChar).Value = discom
        cmd.Parameters.Add("@Zone", SqlDbType.VarChar).Value = zone
        cmd.Parameters.Add("@Circle", SqlDbType.VarChar).Value = circle
        cmd.Parameters.Add("@Division", SqlDbType.VarChar).Value = division
        cmd.Parameters.Add("@Subdivision", SqlDbType.VarChar).Value = subdivision
        cmd.Parameters.Add("@Substation", SqlDbType.VarChar).Value = substation
        cmd.Parameters.Add("@Feeder", SqlDbType.VarChar).Value = "Select"
        cmd.Connection = con
        Try
            con.Open()
            cmd.CommandTimeout = 250
            Using sda As New SqlDataAdapter(cmd)
                sda.Fill(dt)
            End Using
            If dt.Rows.Count > 0 Then
                gridviewSummary.DataSource = dt
                'gridViewDetails.Columns().HeaderText = "Sandeep"
                gridviewSummary.DataBind()
                lblMISReports.Text = ""
                'btnExportExcel.Visible = True
                'btnPrint.Visible = True
                'lblmsg.Text = ""
            Else
                lblMISReports.Text = " Data Not Found "
                gridviewSummary.DataSource = Nothing
                gridviewSummary.DataBind()
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

    Public Sub bind_Grid()
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

        Dim dt As New DataTable()

        dt = s1.bing_Level3DTwiseGrid(ddlmonth.SelectedValue, discom, zone, circle, division, subdivision, substation, feeder, ddlSource.SelectedValue)
        If dt.Rows.Count > 0 Then
            gridViewLevel1details.DataSource = dt
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

    End Sub

    Protected Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If ddlFeeder.SelectedIndex > 0 Then
            bind_Grid()
            bind_Grid_Simmary()
            pnllevel4.Visible = True
            pnlFeeder.Visible = False
        Else
            bind_Grid()
            bind_Grid_Simmary()
            pnllevel4.Visible = True
            pnlFeeder.Visible = False
            'pnllevel4.Visible = True
            'pnlFeeder.Visible = False
        End If
    End Sub

    Protected Sub ddlParameters_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlParameters.SelectedIndexChanged
        If ddlFeeder.SelectedIndex > 0 Then
            pnllevel4.Visible = True
            pnlFeeder.Visible = False
        Else
            'bind_Grid()
            'pnllevel4.Visible = True
            'pnlFeeder.Visible = False
        End If
    End Sub

    

    
End Class
