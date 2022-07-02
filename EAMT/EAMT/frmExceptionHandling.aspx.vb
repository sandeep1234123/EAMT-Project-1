Imports System.Configuration
Imports System.Text.RegularExpressions
Imports System.Drawing
Imports System.IO
Imports System.Data


Partial Class frmExceptionHandling
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim objMainCLS As New maincls
    Dim s1 As New cls_link_to_database
    Dim strSql As String
    Dim dt As New System.Data.DataTable
    Dim Query As String
    Dim masterdt As New DataTable
    Dim discom, zone, circle, division, subdivision, substation, feeder, drpString As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Session("login") = "true"
        If Page.IsPostBack = False Then
            If Session("login") = "false" Then
                Response.Redirect("Login.aspx")
            End If
            If Session("login") Is Nothing Then
                Response.Redirect("Login.aspx")
            End If

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
                bind_SubDivision()
                Try
                    If ddlSubDivision.SelectedItem.Text.ToString <> "Select" Then
                        subdivision = ddlSubDivision.SelectedItem.Text.ToString()
                        Session("Division") = subdivision
                        Session("flag") = 3
                    Else
                        ddlSubDivision.SelectedIndex = 1
                        Session("SubDivision") = ddlSubDivision.SelectedItem.Text.ToString()
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
        btnShow.Visible = True

    End Sub

    Protected Sub bind_SubDivision()
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
        ddlSubDivision.DataTextField = dt1.Columns(0).ToString()
        ddlSubDivision.DataValueField = dt1.Columns(0).ToString()
        ddlSubDivision.DataSource = dt1
        ddlSubDivision.DataBind()
        ddlSubDivision.Items.Insert(0, "Select")

    End Sub

    Protected Sub bindSubstation()
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
        'ddlCircle.SelectedValue = Session("Month")
        'ddlCircle.SelectedIndex = 1
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

    'Protected Sub bindgrid()
    '    Dim dt1 As New DataTable
    '    Dim query As String = ""
    '    If Session("AccessFeeder") = "NONE" Then
    '        query = "select distinct Feeder from tblEAMT_StructureOmninetIE where Discom in (" & Session("AccessDiscom") & ") and Zone in (" & Session("AccessZone") & ") and Circle in (" & Session("AccessCircle") & ") and Division in (" & Session("AccessDivision") & ")  and SubDivision in (" & Session("AccessSubDivision") & ") and Substation in (" & Session("AccessSubstation") & ")"
    '    ElseIf Session("AccessDiscom") = "ALL" Then
    '        query = "select distinct Feeder from tblEAMT_StructureOmninetIE where Discom ='" & ddlDiscom.SelectedItem.Text & "' and Zone = '" & ddlZone.SelectedItem.Text & "' and Circle='" & ddlCircle.SelectedItem.Text & "' and Division='" & ddlDivision.SelectedItem.Text & "'  "
    '    ElseIf Session("AccessDiscom") <> "ALL" Then
    '        query = "select distinct Feeder from tblEAMT_StructureOmninetIE where Discom in (" & Session("AccessDiscom") & ") and Zone in (" & Session("AccessZone") & ") and Circle in (" & Session("AccessCircle") & ") and Division in (" & Session("AccessDivision") & ") and SubDivision in (" & Session("AccessSubDivision") & ") and Substation in (" & Session("AccessSubstation") & ")  and Division='" & ddlDivision.SelectedValue & "' "
    '    End If
    '    dt1 = s1.GetDataTable(query)
    '    ddlFeeder.DataTextField = dt1.Columns(0).ToString()
    '    ddlFeeder.DataValueField = dt1.Columns(0).ToString()
    '    ddlFeeder.DataSource = dt1
    '    ddlFeeder.DataBind()
    '    ddlFeeder.Items.Insert(0, "Select")
    '    'ddlFeeder.SelectedValue = Session("Month")
    '    'ddlFeeder.SelectedIndex = 1
    'End Sub

    Protected Sub ddlDiscom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlDiscom.SelectedIndexChanged
        BindData("Zone")
        ddlCircle.Items.Clear()
        ddlDivision.Items.Clear()
        ddlSubDivision.Items.Clear()
        ddlSubstation.Items.Clear()
        ddlFeeder.Items.Clear()

    End Sub

    Protected Sub ddlZone_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlZone.SelectedIndexChanged
        BindData("Circle")
        ddlDivision.Items.Clear()
        ddlSubDivision.Items.Clear()
        ddlSubstation.Items.Clear()
        ddlFeeder.Items.Clear()
    End Sub

    Protected Sub ddlCircle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCircle.SelectedIndexChanged
        BindData("Division")
        ddlSubDivision.Items.Clear()
        ddlSubstation.Items.Clear()
        ddlFeeder.Items.Clear()
    End Sub

    Protected Sub ddlDivision_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlDivision.SelectedIndexChanged
        BindData("SubDivision")
        ddlSubstation.Items.Clear()
        ddlFeeder.Items.Clear()
    End Sub

    Protected Sub ddlSubdivision_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSubDivision.SelectedIndexChanged
        BindData("Substation")
        ddlFeeder.Items.Clear()
    End Sub

    Protected Sub ddlSubstation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSubstation.SelectedIndexChanged
        BindData("Feeder")
    End Sub

    Protected Sub BindData(GetVale As String)
        Dim mode As String = ""
        Dim dtval As New DataTable
        Dim query As String = ""
        mode = GetVale
        Select Case mode
            Case "Discom"
                dtval = s1.Exceptionbind_dropdown("Discom", "", "", "", "", "", "", "")
                ddlDiscom.DataTextField = dtval.Columns(0).ToString()
                ddlDiscom.DataValueField = dtval.Columns(0).ToString()
                ddlDiscom.DataSource = dtval
                ddlDiscom.DataBind()
                ddlDiscom.Items.Insert(0, "Select")
                ddlDiscom.SelectedIndex = 0
            Case "Zone"
                dtval = s1.Exceptionbind_dropdown("Zone", ddlDiscom.SelectedItem.Text, "", "", "", "", "", "")
                ddlZone.DataTextField = dtval.Columns(1).ToString()
                ddlZone.DataValueField = dtval.Columns(1).ToString()
                ddlZone.DataSource = dtval
                ddlZone.DataBind()
                ddlZone.Items.Insert(0, "Select")
                ddlZone.SelectedIndex = 0
            Case "Circle"
                dtval = s1.Exceptionbind_dropdown("Circle", ddlDiscom.SelectedItem.Text, ddlZone.SelectedItem.Text, "", "", "", "", "")
                ddlCircle.DataTextField = dtval.Columns(2).ToString()
                ddlCircle.DataValueField = dtval.Columns(2).ToString()
                ddlCircle.DataSource = dtval
                ddlCircle.DataBind()
                ddlCircle.Items.Insert(0, "Select")
                ddlCircle.SelectedIndex = 0
            Case "Division"

                dtval = s1.Exceptionbind_dropdown("Division", ddlDiscom.SelectedItem.Text, ddlZone.SelectedItem.Text, ddlCircle.SelectedItem.Text, "", "", "", "")
                ddlDivision.DataTextField = dtval.Columns(3).ToString()
                ddlDivision.DataValueField = dtval.Columns(3).ToString()
                ddlDivision.DataSource = dtval
                ddlDivision.DataBind()
                ddlDivision.Items.Insert(0, "Select")
                btnShow.Visible = True

            Case "SubDivision"
                dtval = s1.Exceptionbind_dropdown("Subdivision", ddlDiscom.SelectedItem.Text, ddlZone.SelectedItem.Text, ddlCircle.SelectedItem.Text, ddlDivision.SelectedItem.Text, "", "", "")
                ddlSubDivision.DataTextField = dtval.Columns(4).ToString()
                ddlSubDivision.DataValueField = dtval.Columns(4).ToString()
                ddlSubDivision.DataSource = dtval
                ddlSubDivision.DataBind()
                ddlSubDivision.Items.Insert(0, "Select")

            Case "Substation"
                dtval = s1.Exceptionbind_dropdown("Substation", ddlDiscom.SelectedItem.Text, ddlZone.SelectedItem.Text, ddlCircle.SelectedItem.Text, ddlDivision.SelectedItem.Text, ddlSubDivision.SelectedItem.Text, "", "")
                ddlSubstation.DataTextField = dtval.Columns(5).ToString()
                ddlSubstation.DataValueField = dtval.Columns(5).ToString()
                ddlSubstation.DataSource = dtval
                ddlSubstation.DataBind()
                ddlSubstation.Items.Insert(0, "Select")

            Case "Feeder"
                dtval = s1.Exceptionbind_dropdown("Feeder", ddlDiscom.SelectedItem.Text, ddlZone.SelectedItem.Text, ddlCircle.SelectedItem.Text, ddlDivision.SelectedItem.Text, ddlSubDivision.SelectedItem.Text, ddlSubstation.SelectedItem.Text, "")
                ddlFeeder.DataTextField = dtval.Columns(6).ToString()
                ddlFeeder.DataValueField = dtval.Columns(6).ToString()
                ddlFeeder.DataSource = dtval
                ddlFeeder.DataBind()
                ddlFeeder.Items.Insert(0, "Select")
        End Select
        'If dtval.Rows.Count > 0 Then
        '    Session("drpString") = ""
        '    If dtval.Rows(0)(0).ToString() <> "" Then
        '        Session("drpString") = "g.Discom='" + dtval.Rows(0)(0).ToString() + "' and g.Zone='" + dtval.Rows(0)(1).ToString() + "' and g.Circle='" + dtval.Rows(0)(2).ToString() + "' and g.Division='" + dtval.Rows(0)(3).ToString() + "' and g.SubDivision='" + dtval.Rows(0)(4).ToString() + "' and g.Substation='" + dtval.Rows(0)(5).ToString() + "'"

        '        'Session("drpString") = "g.Discom=''" + dt1.Rows(0)(0).ToString() + "'' and g.Zone=''" + dt1.Rows(0)(1).ToString() + "'' and g.Circle=''" + dt1.Rows(0)(2).ToString() + "'' and g.Division=''" + dt1.Rows(0)(3).ToString() + "'' and g.SubDivision=''" + dt1.Rows(0)(4).ToString() + "'' and g.Substation=''" + dt1.Rows(0)(5).ToString() + "''"
        '    End If


        'End If
    End Sub



    Protected Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        Dim dtgrid As New DataTable
        Dim Discom, Zone, Circle, Division As String
        If ddlDiscom.SelectedItem Is Nothing Then
            Discom = "Select"
        Else
            Discom = ddlDiscom.SelectedItem.ToString()
        End If
        If ddlZone.SelectedItem Is Nothing Then
            Zone = "Select"
        Else
            Zone = ddlZone.SelectedItem.ToString()

        End If
        If ddlCircle.SelectedItem Is Nothing Then
            Circle = "Select"
        Else
            Circle = ddlCircle.SelectedItem.ToString()
        End If
        If ddlDivision.SelectedItem Is Nothing Then
            Division = "Select"
        Else
            Division = ddlDivision.SelectedItem.ToString()
        End If
        'If Session("drpString") <> "" Then
        '    drpString = Session("drpString")
        dtgrid = s1.bind_exceptionGrid(Discom, Zone, Circle, Division)
        If dtgrid.Rows.Count > 0 Then
            gridViewException.DataSource = dtgrid
            gridViewException.DataBind()
        End If
        'End If

    End Sub

    Protected Sub gridViewException_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gridViewException.RowCommand
        Try
            For i As Integer = 0 To gridViewException.Rows.Count - 1
                Dim dataKeyValueID As String = gridViewException.DataKeys(e.CommandArgument).Values(0).ToString()
                Dim dataKeyValueDivID As String = gridViewException.DataKeys(e.CommandArgument).Values(1).ToString()
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                If e.CommandName = "edit2" Then
                    btnUpdate.Visible = True
                    btnDTAddNew.Visible = False
                    'Set OmninetStructure ID
                    Session("UpdateStrucID") = dataKeyValueID.ToString
                    Session("UpdateDivisionID") = dataKeyValueDivID.ToString
                    'lblmsg.Text = ""
                    txtDiscom.Text = row.Cells(1).Text.ToString
                    txtZone.Text = row.Cells(2).Text.ToString
                    txtCircle.Text = row.Cells(3).Text.ToString
                    txtDivision.Text = row.Cells(4).Text.ToString

                    divDTInputEnergy.Visible = True
                    btnUpdate.Focus()

                End If
            Next
            'Bind_grid_DT_View()
        Catch ex As Exception
            'lblmsg.Text = ""
        End Try
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim dtUDF As New DataTable
        If ddlUpdateFeeder.SelectedValue <> "Select" Then
            dtUDF = s1.UpdateOmninet_BillingMapping(Integer.Parse(Session("UpdateStrucID")), Integer.Parse(ddlUpdateFeeder.SelectedValue), Session("UserName").ToString)
            divDTInputEnergy.Visible = False
            Session("UpdateStrucID") = ""
            Session("UpdateDivisionID") = ""
        End If

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        divDTInputEnergy.Visible = False
        Session("UpdateStrucID") = ""
        Session("UpdateDivisionID") = ""
    End Sub

    Protected Sub ddlUpdateSubStation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlUpdateSubStation.SelectedIndexChanged

        'Feeder ID bind For Mapping in Feeder_Audit_Report Table
        If ddlUpdateSubStation.SelectedValue <> "Select" And ddlsourceN.SelectedValue <> "Select" Then
            Dim dtUDF As New DataTable
            Dim query As String = ""
            query = "select DISTINCT BilledUnitId,FeederName from Feeder_Audit_Report where  billable_count > 0 and FeederName IS NOT NULL and FeederName <>'' and Division_ID='" & Session("UpdateDivisionID") & "' and Substation_Name='" & ddlUpdateSubStation.SelectedValue & "' and Source='" & ddlsourceN.SelectedItem.Text.ToString & "'"
            dtUDF = s1.GetDataTable(query)
            ddlUpdateFeeder.DataTextField = dtUDF.Columns("FeederName").ToString()
            ddlUpdateFeeder.DataValueField = dtUDF.Columns("BilledUnitId").ToString()
            ddlUpdateFeeder.DataSource = dtUDF
            ddlUpdateFeeder.DataBind()
            ddlUpdateFeeder.Items.Insert(0, "Select")
            ddlUpdateFeeder.SelectedIndex = -1
            ddlUpdateFeeder.Focus()
        Else
            ddlUpdateFeeder.Items.Clear()
        End If


    End Sub

    Protected Sub ddlsourceN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlsourceN.SelectedIndexChanged
        If ddlsourceN.SelectedValue <> "Select" Then
            Dim dtUDSS As New DataTable
            Dim query As String = ""
            Try
                If Session("UpdateDivisionID") <> "NONE" Then
                    query = "select DISTINCT  Substation_Name from Feeder_Audit_Report where  billable_count > 0 and Substation_Name IS NOT NULL and Substation_Name <> '' and Division_ID='" & Session("UpdateDivisionID") & "' and Source='" & ddlsourceN.SelectedItem.Text.ToString & "'"
                    dtUDSS = s1.GetDataTable(query)
                    ddlUpdateSubStation.DataTextField = dtUDSS.Columns(0).ToString()
                    ddlUpdateSubStation.DataValueField = dtUDSS.Columns(0).ToString()
                    ddlUpdateSubStation.DataSource = dtUDSS
                    ddlUpdateSubStation.DataBind()
                    ddlUpdateSubStation.Items.Insert(0, "Select")
                    ddlUpdateSubStation.SelectedIndex = -1
                    ddlUpdateSubStation.Focus()
                End If
            Catch ex As Exception
            End Try
        Else
            ddlUpdateSubStation.Items.Clear()
            ddlUpdateFeeder.Items.Clear()
        End If
    End Sub

    Protected Sub ddlUpdateFeeder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlUpdateFeeder.SelectedIndexChanged
        btnUpdate.Focus()

    End Sub
End Class
