Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class maincls
    'Public myconnection As String = "Data Source=.;Initial Catalog=CCDashboard;Integrated Security=True"
    Public myconnection As String = "server=100.110.1.74;initial catalog=EAMT;user id=amr_agra1;pwd=12345@agra;"
    '"server=192.168.117.62;initial catalog=uppcl_staging;user id=uppcl_staging;pwd=bond@1234;"
    'System.Configuration.ConfigurationManager.ConnectionStrings("conMIS_String").ConnectionString.ToString
    Public Function getDataTableReturn(ByVal sql As String) As DataTable
        Dim da As New SqlDataAdapter
        Dim con As New SqlConnection(myconnection)
        Dim cmd As New SqlCommand
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        da = New SqlDataAdapter(sql, con)
        Dim dt As New DataTable
        da.Fill(dt)
        con.Close()
        Return (dt)
    End Function
    Public Function getselectcountValues(ByVal sql As String) As Decimal
        Dim da As New SqlDataAdapter
        Dim con As New SqlConnection(myconnection)
        Dim cmd As New SqlCommand
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        da = New SqlDataAdapter(sql, con)
        Dim dt As New DataTable
        da.Fill(dt)

        con.Close()
        Return dt.Rows(0)(0)
    End Function

    Public Function gfgetdata(ByVal sql As String) As DataTable
        Dim da As New SqlDataAdapter
        Dim con As New SqlConnection(myconnection)
        Dim cmd As New SqlCommand
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        da = New SqlDataAdapter(sql, con)
        Dim dt As New DataTable
        da.Fill(dt)
        con.Close()
        Return (dt)
    End Function

    Public Function gfexecutedata(ByVal sql As String) As Integer

        Dim constr As String
        constr = myconnection
        Dim con As New SqlConnection(constr)
        Dim cmd As New SqlCommand
        Dim i As Integer
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        With cmd
            .Connection = con
            .CommandText = sql
            .CommandType = CommandType.Text
        End With
        i = cmd.ExecuteNonQuery
        con.Close()
        Return i
    End Function

End Class
