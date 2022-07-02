Imports System.Data
Imports System.Net
Imports System.IO

Partial Class Login
    Inherits System.Web.UI.Page
    Dim s1 As New cls_link_to_database
    Dim s2 As New maincls

    Protected Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        If txtuser.Text.Trim = "" Then
            lbl_message.Visible = True
            lbl_message.Text = "Please Enter UserName!!!"
            Session("login") = "false"
            Exit Sub
        End If
        If txtpass.Text.Trim = "" Then
            lbl_message.Visible = True
            lbl_message.Text = "Please Enter Password!!!"
            Session("login") = "false"
            Exit Sub
        End If
        Dim sql As String = ""
        Dim dt As New DataTable
        sql = ""
        sql = "Select UserName,DisplayName,Password,Discom,Zone,Circle,Division,SubDivision,Substation,Feeder,Status,Role from tblUPPCL_UserDetails where status <> 'Inactive' and Role <> 'SUBSTATION' and upper(UserName)=upper('" & txtuser.Text.Trim & "') and upper(Password)=upper('" & txtpass.Text.Trim & "')"
        dt.Clear()
        dt = s1.GetDataTable(sql)
        If dt.Rows.Count = 0 Then
            lbl_message.Visible = True
            lbl_message.Text = "UserID Does Not Exist in Database!!!"
            Session("login") = "false"
            Exit Sub
        Else
            If txtpass.Text <> dt.Rows(0).Item("Password").ToString() Then
                lbl_message.Visible = True
                lbl_message.Text = "Please Enter Valid Password!!!"
                Session("login") = "false"
                Exit Sub
            End If
        End If
        Session("Login") = "true"
        Session("AccessDiscom") = dt.Rows(0).Item("Discom").ToString.ToUpper
        Session("AccessZone") = dt.Rows(0).Item("Zone").ToString.ToUpper
        Session("AccessCircle") = dt.Rows(0).Item("Circle").ToString.ToUpper
        Session("AccessDivision") = dt.Rows(0).Item("Division").ToString.ToUpper
        Session("AccessSubDivision") = dt.Rows(0).Item("SubDivision").ToString.ToUpper
        Session("AccessSubstation") = dt.Rows(0).Item("Substation").ToString.ToUpper
        Session("AccessFeeder") = dt.Rows(0).Item("Feeder").ToString.ToUpper
        Session("Status") = dt.Rows(0).Item("Status").ToString()
        Session("Display") = dt.Rows(0).Item("DisplayName").ToString.ToUpper
        Session("UserName") = dt.Rows(0).Item("UserName").ToString.ToUpper
        Session("Role") = dt.Rows(0).Item("Role").ToString.ToUpper
        'Session("Designation") = dt.Rows(0).Item("Designation").ToString.ToUpper
        'Session("Name") = dt.Rows(0).Item("Name").ToString.ToUpper
        'Session("Phone") = dt.Rows(0).Item("Phone").ToString.ToUpper
        Dim strsql As String = "INSERT INTO [dbo].[AuditTable_EAMT]([LoginName],[InsertedDate],Role,UserName) VALUES('" & Session("display") & "',getdate(),'" & Session("Role") & "','" & dt.Rows(0).Item("UserName").ToString.ToUpper & "')"
        'strsql = "INSERT INTO [dbo].[Program]([ProgramName],[InsertedDate],[InsertedBy])VALUES('" & txtVenue.Text.Trim.Replace("'", "''") & "',getdate(),'Abc Name')"
        s2.gfexecutedata(strsql)

        Dim role As String = Session("Role").ToString.ToUpper

        Response.Redirect("Default.aspx")

        'If role = "SUBSTATION" Then
        '    Response.Redirect("UPPCL.aspx")
        'ElseIf role = "DIVISION" Then
        '    Response.Redirect("UPPCLDivision.aspx")
        'ElseIf role = "SUBDIVISION" Then
        '    Response.Redirect("UPPCLSubDivision.aspx")
        'ElseIf role = "CIRCLE" Then
        '    Response.Redirect("UPPCLCircle.aspx")
        'ElseIf role = "ZONE" Then
        '    Response.Redirect("UPPCLZone.aspx")
        'ElseIf role = "UPPCL" Then
        '    Response.Redirect("UPPCLCPD.aspx")
        'ElseIf role = "DISCOM" Then
        '    Response.Redirect("UPPCLDiscom.aspx")
        'ElseIf role = "DIRECTOR DISTRIBUTION" Then
        '    Response.Redirect("UPPCLDiscom.aspx")
        'ElseIf role = "DIRECTOR TECHNICAL" Then
        '    Response.Redirect("UPPCLDiscom.aspx")
        'ElseIf role = "DIRECTOR COMMERCIAL" Then
        '    Response.Redirect("UPPCLDiscom.aspx")
        'ElseIf role = "ADMIN" Then
        '    Response.Redirect("UPPCLRole.aspx")
        'ElseIf role = "DBA" And Session("Status").ToString.ToUpper = "DATA" Then
        '    Response.Redirect("DownloadTemplate.aspx")
        'End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    'Private Function fetchDiscom(ByVal UserName As String) As DataTable
    '    Dim sql As String = ""
    '    If UserName = "admin" Then
    '        sql = "select distinct Discom,Zone from UserAccessDetails" 'where upper(LoginName)=upper('" & txtuser.Text.Trim & "') and status='A'"
    '    Else
    '        sql = "select distinct Discom,Zone from UserAccessDetails where upper(UserName)=upper('" & txtuser.Text.Trim & "') and status=1"
    '    End If
    '    Dim dt As New DataTable
    '    dt = s1.GetDataTable(sql)
    '    Return dt
    'End Function

    
End Class
