Imports System.Data
Imports System.Data.SqlClient

Partial Class MasterFrontPage
    Inherits System.Web.UI.MasterPage
    Dim objMainCLS As New maincls
    Dim s1 As New cls_link_to_database
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblUser.Text = Session("display")
        Try
            Dim dt1 As New DataTable
            Dim query As String
            query = "select count(*) from AuditTable_EAMT"
            dt1 = s1.GetDataTable(query)
            lblVisitorCount.Text = dt1.Rows(0)(0).ToString
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Session.Abandon()
        Session.RemoveAll()
        Session.Clear()
        Session("login") = "false"
        Response.Redirect("Login.aspx")
    End Sub

    Protected Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Response.Redirect("Default.aspx")
    End Sub
End Class

