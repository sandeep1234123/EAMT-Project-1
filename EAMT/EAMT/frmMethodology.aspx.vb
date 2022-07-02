Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text.RegularExpressions
Partial Class frmMethodology
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim objMainCLS As New maincls
    Dim s1 As New cls_link_to_database
    Dim strSql As String
    Dim dt As New System.Data.DataTable
    Dim Query As String
    Dim masterdt As New DataTable

    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' Verifies that the control is rendered
    End Sub

    Protected Sub OnPaging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        gridViewDetails.PageIndex = e.NewPageIndex
        gridViewDetails.DataBind()
    End Sub

    Protected Sub OnPageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gridViewDetails.PageIndex = e.NewPageIndex
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("login") = "false" Then
            Response.Redirect("Login.aspx")
        End If
        If Session("login") Is Nothing Then
            Response.Redirect("Login.aspx")
        End If
        If Page.IsPostBack = False Then
            bind_to_datagridview_CCMethodology_Report()
        End If
    End Sub

    Public Sub bind_to_datagridview_CCMethodology_Report()
        Dim strConnString As String = objMainCLS.myconnection
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()
        Dim dt As New DataTable()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "[dbo].[proc_CC_Methodlogy]"
        cmd.Connection = con
        Try
            con.Open()
            cmd.CommandTimeout = 950
            Using sda As New SqlDataAdapter(cmd)
                sda.Fill(dt)
            End Using
            If dt.Rows.Count > 0 Then
                gridViewDetails.DataSource = dt
                gridViewDetails.DataBind()
                lblMISReports.Text = ""
            Else
                lblMISReports.Text = " Data Not Found "
                gridViewDetails.DataSource = Nothing
                gridViewDetails.DataBind()
                Exit Sub
            End If
        Catch ex As Exception
            lblMISReports.Text = ex.ToString
        Finally
            con.Close()
            con.Dispose()
        End Try
    End Sub
End Class
