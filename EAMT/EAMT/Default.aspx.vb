Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text.RegularExpressions
Imports System.Drawing

Partial Class _Default
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim objMainCLS As New maincls
    Dim s1 As New cls_link_to_database
    Dim strSql As String
    Dim dt As New System.Data.DataTable
    Dim Query As String
    Dim masterdt As New DataTable

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'If Session("login") = "false" Then
        '    Response.Redirect("Login.aspx")
        'End If
        'If Session("login") Is Nothing Then
        '    Response.Redirect("Login.aspx")
        'End If
        'If Page.IsPostBack = False Then

        'End If
    End Sub

    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' Verifies that the control is rendered
    End Sub


End Class
