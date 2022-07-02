Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class cls_link_to_database

    Public loadflag As String
    Public user_id As String

    Dim trn As SqlTransaction
    Public connect As New SqlConnection
    'Dim constr As String = "server=192.168.117.62;initial catalog=uppcl_staging;user id=uppcl_staging;pwd=bond@1234;"
    'Dim constr As String = "Data Source=.;Initial Catalog=CCDashboard;Integrated Security=True"
    Dim constr As String = "server=100.110.1.74;initial catalog=EAMT;user id=amr_agra1;pwd=12345@agra;"
    'Dim constr As String = "Data Source=DESKTOP-83ATBNS;Initial Catalog=EAMT;Integrated Security=True"
    '"server=100.110.1.74;initial catalog=Uppcl_Staging;user id=amr_agra1;pwd=12345@agra;"
    '"Data Source=.;Initial Catalog=TrendwiseMIS;Integrated Security=True"
    'old  string Dim constr As String = "server=192.168.117.62;initial catalog=AMR_AGRA;user id=amr_agra;pwd=agra@1234;"
    'Dim constr As String = TpddlDLL.secureclass.Decrypt(System.Configuration.ConfigurationManager.ConnectionStrings("constr").ToString)

    Public Function InsertUpdateData(ByVal cmd As SqlCommand) As Boolean
        Dim strConnString As String = constr
        Dim con As New SqlConnection(strConnString)
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            'Response.Write(ex.Message)
            Return False
        Finally
            con.Close()
            con.Dispose()
        End Try
    End Function

    'Dim constr As String = "server=192.168.117.62;initial catalog=AMR_BD;user id=bd_read;pwd=bdread"
    Dim Sqlconn As New SqlConnection(constr)


    Public Function GetDataTable(ByVal str As String) As DataTable
        Dim dt As New DataTable
        Try
            If ConnectionState.Open Then
                Sqlconn.Close()
            End If
            Sqlconn.Open()
            Dim da As New SqlDataAdapter(str, Sqlconn)

            da.Fill(dt)
            Sqlconn.Close()
            Return dt
            Exit Function
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
        End Try
        Return dt
    End Function

    Public Function Returnval(ByVal str As String) As Integer
        Dim i As New Integer
        Try
            If ConnectionState.Open Then
                Sqlconn.Close()
            End If
            Sqlconn.Open()
            Dim cmd As New SqlCommand
            cmd.Connection = Sqlconn
            cmd.CommandText = str

            i = cmd.ExecuteScalar
            If Sqlconn.State = ConnectionState.Open Then
                Sqlconn.Close()
            End If
            Return i
            Exit Function
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
        ' Return dt
    End Function

    Public Function executedata_batchmode(ByVal stringarray As ArrayList) As Integer

        If ConnectionState.Open Then
            Sqlconn.Close()
        End If
        Sqlconn.Open()
        Dim Command As SqlCommand = Sqlconn.CreateCommand()
        Dim Trans As SqlTransaction
        Trans = Sqlconn.BeginTransaction(IsolationLevel.ReadCommitted)
        Command.Transaction = Trans
        Dim i As Integer
        i = 0
        Dim j As Integer
        Try
            For j = 0 To stringarray.Count - 1
                Command.CommandText = stringarray(j).ToString
                Command.ExecuteNonQuery()
                i = i + 1
            Next
            Trans.Commit()
        Catch e As Exception
            Trans.Rollback()
            If ConnectionState.Open Then
                Sqlconn.Close()
            End If
            MsgBox(e.Message)

            j = 0
        Finally
            Sqlconn.Close()
        End Try
        Return i
    End Function

    Public Function upload_exceldata_sub(ByVal dt As DataTable, user_name As String, utilityname As String) As Integer
        Dim Sql As String
        Dim Zone, Circle, sub_station, Account_ID, Division_Name, consumer_name, Sanction_Load, Process, Voltage, SEMeter_No, SEMeter_Make, SEMF As String

        Dim DPMeterNo, DPMeter_Make, DPMF, CEPMeterNo, CEPMeter_Make, CEPMF, CEMeterNo, CEMeter_Make, CEMF, Feeder_category As String



        Dim i As Integer
        i = 0
        Dim Flag_feeder As String = "Y"
        Dim myAL As New ArrayList()
        Dim dtquery As New DataTable
        dtquery.Columns.Add("query", Type.GetType("System.String"))

        Dim row_upd As Integer
        For Each row In dt.Rows
            Try
                Zone = row("Zone").ToString
                Circle = row("Circle").ToString()
                Division_Name = row("Division").ToString()
                sub_station = row("Name of Sub-station").ToString()
                consumer_name = row("Name of Consumer").ToString()
                Account_ID = row("Account ID").ToString()
                Sanction_Load = row("Sanction Load").ToString()
                Process = row("Process").ToString()
                Voltage = row("Supply Voltage").ToString()



                SEMeter_No = row("SEMeter No").ToString()
                SEMeter_Make = row("SEMeter Make").ToString()
                SEMF = row("SEMF").ToString()
                DPMeterNo = row("DPMeterNo").ToString()
                DPMeter_Make = row("DPMeter_Make").ToString()
                DPMF = row("DPMF").ToString()
                CEPMeterNo = row("CEPMeterNo").ToString()
                CEPMeter_Make = row("CEPMeter Make").ToString()
                CEPMF = row("CEPMF").ToString()
                CEMeterNo = row("CEMeterNo").ToString()
                CEMeter_Make = row("CEMeter Make").ToString()
                CEMF = row("CEMF").ToString()
                Feeder_category = row("Feeder_category").ToString
                If Flag_feeder = "Y" Then
                    Dim sql1 As String = "delete from independent_feeder where Feeder_category ='" + Feeder_category + "'"
                    myAL.Add(sql1)
                    Flag_feeder = "N"
                End If
                If SEMeter_No.ToString = "" And DPMeterNo.ToString = "" And CEPMeterNo.ToString = "" And CEMeterNo.ToString = "" Then
                    Return i
                End If

                SEMeter_No = SEMeter_No.PadLeft(8, "0")
                DPMeterNo = DPMeterNo.PadLeft(8, "0")
                CEPMeterNo = CEPMeterNo.PadLeft(8, "0")
                CEMeterNo = CEMeterNo.PadLeft(8, "0")

                Zone = Zone.Trim

                Circle = Circle.Trim
                sub_station = sub_station.Trim
                Account_ID = Account_ID.Trim
                Division_Name = Division_Name.Trim
                consumer_name = consumer_name.Trim
                Sanction_Load = Sanction_Load.Trim
                Process = Process.Trim
                Voltage = Voltage.Trim
                Process = Process.Trim

                Dim i1 As Integer

                i1 = Len(Consumer_name)
                If i1 > 200 Then
                    i1 = 199
                End If
                If i1 >= 1 Then
                    Consumer_name = Consumer_name.Substring(0, i1 - 1)
                End If

                i1 = Len(Process)
                If i1 >= 30 Then
                    i1 = 30
                End If


                If i1 >= 1 Then
                    Process = Process.Substring(0, i1 - 1)
                End If


                Zone = row("Zone").ToString
                Circle = row("Circle").ToString
 
                Sql = ""
                Sql = Sql + "insert into independent_feeder (Zone, Circle, Division, Substation_name, consumer_name, Account_ID, Sanction_Load_in_KVA, Process, volt_level, SE_meter_no, SE_make, SE_mf, se_pole_meter_no, se_pole_make, se_pole_mf, consumer_end_pole_meterno, consumer_end_pole_metermake, consumer_end_pole_mf, consumer_end_meterno, consumer_end_metermake, consumer_end_mf,Feeder_category,utility,insertedon,insertedby )"
                Sql = Sql + " values( '" + Zone + "','" + Circle + "','" + Division_Name + "','" + sub_station + "','" + consumer_name + "','" + Account_ID + "','" + Sanction_Load
                Sql = Sql + "','" + Process + "','" + Voltage + "','" + SEMeter_No + "','" + SEMeter_Make + "','" + SEMF

                Sql = Sql + "','" + DPMeterNo + "','" + DPMeter_Make + "','" + DPMF + "','" + CEPMeterNo + "','" + CEPMeter_Make + "','" + CEPMF + "','" + CEMeterNo + "','" + CEMeter_Make + "','" + CEMF + "','" + Feeder_category + "','" + utilityname + "',getdate(),'" + user_name + "')"




                myAL.Add(Sql)
                dtquery.Columns.Add(Sql)
                If myAL.Count >= 1 Then
                    executedata_batchmode(myAL)

                    myAL.Clear()
                End If
            Catch ex As Exception

            End Try

        Next row
        executedata_batchmode(myAL)
        myAL.Clear()

        row_upd = dt.Rows.Count

        Return row_upd

        'Dim validrec As Integer

        'validrec = validate1(dt, did)

    End Function

    Public Function upload_energyauditdata_sub(ByVal dt As DataTable, user_name As String, utilityname As String) As Integer
        Dim Sql As String
        Dim i As Integer
        i = 0
        'Dim Flag_feeder As String = "Y"
        Dim myAL As New ArrayList()
        'Dim dtquery As New DataTable
        'dtquery.Columns.Add("query", Type.GetType("System.String"))
        dt.Rows(0).Delete()
        Dim KV_11_Incomer_MF, KV_11_Outgoing_Feeder_MF, DT_MF As String
        Dim row_upd As Integer
        For Each row In dt.Rows
            Try
                
                KV_11_Incomer_MF = row(11).ToString()
                KV_11_Outgoing_Feeder_MF = row(16).ToString()
                DT_MF = row(25).ToString()
                If KV_11_Incomer_MF = "" Then
                    KV_11_Incomer_MF = "0"
                End If
                If KV_11_Outgoing_Feeder_MF = "" Then
                    KV_11_Outgoing_Feeder_MF = "0"
                End If
                If DT_MF = "" Then
                    DT_MF = "0"
                End If
                Sql = ""
                Sql = Sql + "insert into energyauditmaster (zone,circle,division,town,SUBDIVISION ,KV_33_SUBSTATION_ID,KV_33_SUBSTATION_Name,KV_33_Transformer,KV_11_Incomer_Name,KV_11_Incomer_Meter_No,KV_11_Incomer_METER_MAKE,KV_11_Incomer_MF,KV_11_Outgoing_Feeder_Feeder_Name,KV_11_Outgoing_Feeder_Feeder_ID,KV_11_Outgoing_Feeder_Meter_No,KV_11_Outgoing_Feeder_METER_MAKE,KV_11_Outgoing_Feeder_MF,Outgoing_Feeders,Feeder_Type,DT_ID,DT_Name,DT_KVA_Rating,DT_Location,DT_Meter_No,DT_METER_MAKE,DT_MF,Pole_No)"
                Sql = Sql + " values( '" + row(0).ToString() + "','" + row(1).ToString() + "','" + row(2).ToString() + "','" + row(3).ToString() + "','" + row(4).ToString() + "','" + row(5).ToString() + "','" + row(6).ToString()
                Sql = Sql + "','" + row(7).ToString() + "','" + row(8).ToString() + "','" + row(9).ToString() + "','" + row(10).ToString() + "'," + KV_11_Incomer_MF
                Sql = Sql + ",'" + row(12).ToString() + "','" + row(13).ToString() + "','" + row(14).ToString() + "','" + row(15).ToString() + "'," + KV_11_Outgoing_Feeder_MF + ",'" + row(17).ToString() + "','" + row(18).ToString() + "','" + row(19).ToString() + "','" + row(20).ToString() + "','" + row(21).ToString() + "','" + row(22).ToString() + "','" + row(23).ToString() + "','" + row(24).ToString() + "'," + DT_MF + ",'" + row(26).ToString() + "')"
                myAL.Add(Sql)
                'dtquery.Columns.Add(Sql)
                If myAL.Count >= 1 Then
                    executedata_batchmode(myAL)

                    myAL.Clear()
                End If
            Catch ex As Exception

            End Try

        Next row
        executedata_batchmode(myAL)
        myAL.Clear()

        row_upd = dt.Rows.Count

        Return row_upd

        'Dim validrec As Integer

        'validrec = validate1(dt, did)

    End Function

    Public Function GetDataSet(ByVal StrSql As String) As DataSet
        Dim ds As New DataSet
        Try
            If ConnectionState.Open Then
                Sqlconn.Close()
            End If
            Sqlconn.Open()
            Dim da As New SqlDataAdapter(StrSql, Sqlconn)

            da.Fill(ds)
            Sqlconn.Close()
            Return ds
            Exit Function
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
        Return ds
    End Function

    Public Function Get_Users(ByVal Userid As String, ByVal Pwd As String, ByVal company1 As String) As DataTable
        Dim dt As New DataTable
        Try
            If ConnectionState.Open Then
                Sqlconn.Close()
            End If
            Sqlconn.Open()



            Dim Sql1 As String = "OPEN SYMMETRIC KEY MySymmetricKeyName DECRYPTION BY CERTIFICATE MyCertificateName"
            Dim da1 As New SqlDataAdapter(Sql1, Sqlconn)
            da1.Fill(dt)


            Dim Sql As String = "SELECT a.* FROM user_mst a, company_master b Where  a.agency_id=b.agency_id and cast(dbo.Decrypt(valid_From_encryption) as date)<=getdate()  and (getdate()-1)<=cast(dbo.Decrypt(valid_to_encryption)as date) and user_id='<Userid>' and password ='<Pwd>'  and [utility_name]='<comp>'  "
            Sql = Sql + ""

            Sql = Sql.Replace("<Userid>", Userid)
            Sql = Sql.Replace("<Pwd>", Pwd)
            Sql = Sql.Replace("<comp>", company1)
            Dim da As New SqlDataAdapter(Sql, Sqlconn)

            da.Fill(dt)
            Sqlconn.Close()
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
        Get_Users = dt
    End Function

    Public Function GetUserRole(ByVal roleid As String) As String
        Dim dt As New DataTable
        Try
            If ConnectionState.Open Then
                Sqlconn.Close()
            End If
            Sqlconn.Open()

            Dim Sql As String = "SELECT ROLE_NAME FROM ROLE_MASTER Where ROLE_ID='<roleid>' "
            Sql = Sql.Replace("<roleid>", roleid)

            Dim da As New SqlDataAdapter(Sql, Sqlconn)

            da.Fill(dt)
            Sqlconn.Close()
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0).Item(0).ToString()
            Else
                Return ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function

    Public Function GetcheckMeter(ByVal mtrno As String) As String

        Dim dt As New DataTable
        Dim str As String = "select distinct check_meter_no from amr_meter_mst where Meternumber='" & mtrno.ToString() & "'"
        Try
            If ConnectionState.Open Then
                Sqlconn.Close()
            End If
            Sqlconn.Open()
            Dim da As New SqlDataAdapter(str, Sqlconn)

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0).Item(0).ToString()
            Else
                Return ""
            End If

            Sqlconn.Close()

        Catch ex As Exception
            Sqlconn.Close()
        End Try
    End Function

    Public Function MainPloeMeterStatus(ByVal mtrno As String) As DataSet

        Dim ds As New DataSet
        Dim Str As String = ""
        Dim strmain As String = "select distinct Meternumber,MF_Main from amr_meter_mst where meter_status='Y' and Meternumber <>'00000000' and Meternumber like '%" & mtrno.ToString() & "'"
        Dim strpole As String = "select distinct check_meter_no,MF_Pole from amr_meter_mst where meter_status='Y' and  check_meter_no<>'00000000' and  check_meter_no like '%" & mtrno.ToString() & "'"

        Str = strmain & ";" & strpole

        'Try
        '    If ConnectionState.Open Then
        '        Sqlconn.Close()
        '    End If
        '    Sqlconn.Open()
        '    Dim da As New SqlDataAdapter(Str, Sqlconn)

        '    da.Fill(ds)

        '    Sqlconn.Close()
        'Catch ex As Exception
        '    Sqlconn.Close()
        'End Try
        'Return ds


        Try
            Dim da As New SqlDataAdapter
            Dim cmd As New SqlCommand
            Dim con As SqlConnection

            If ConnectionState.Open Then
                Sqlconn.Close()
            End If

            con = OpenConnection()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandText = Str
            'cmd.CommandTimeout = 900
            da.SelectCommand = cmd
            da.Fill(ds)

            Sqlconn.Close()

        Catch ex As Exception
            Sqlconn.Close()
        End Try
        Return ds
    End Function

    Public Function GetMainPloeMeterNumber(ByVal mtrno As String, ByVal Mtrtyp As String) As DataTable

        Dim dt As New DataTable
        Dim Str As String = ""
        Dim strmain As String = ""

        If Mtrtyp = "Main" Then

            Str = "select distinct check_meter_no,MF_Pole  from amr_meter_mst where meter_status='Y' and Meternumber <>'00000000' and  Meternumber='" & mtrno.ToString() & "'"

        ElseIf Mtrtyp = "Chk" Then

            Str = "select distinct Meternumber,MF_Main  from amr_meter_mst where meter_status='Y' and  check_meter_no<>'00000000' and  check_meter_no='" & mtrno.ToString() & "'"

        End If

        Try
            If ConnectionState.Open Then
                Sqlconn.Close()
            End If
            Sqlconn.Open()
            Dim da As New SqlDataAdapter(Str, Sqlconn)

            da.Fill(dt)

            Sqlconn.Close()
        Catch ex As Exception
            Sqlconn.Close()
        End Try
        Return dt
    End Function

    Public Function MeterUtiliybasedPermision(ByVal Mtrno As String, ByVal utilityid As String) As DataTable

        Dim dt As New DataTable
        Dim str As String = "select 1 from amr_meter_mst where  meter_status='Y' and utility_id='" & utilityid.ToString() & "' and (Meternumber = '" & Mtrno.ToString() & "' Or check_meter_no = '" & Mtrno.ToString() & "') "
        Try
            If ConnectionState.Open Then
                Sqlconn.Close()
            End If
            Sqlconn.Open()
            Dim da As New SqlDataAdapter(str, Sqlconn)

            da.Fill(dt)

            Sqlconn.Close()

        Catch ex As Exception
            Sqlconn.Close()
        End Try
        Return dt
    End Function

    Public Function UtiliybasedPermision(ByVal userid As String, ByVal PortalNm As String) As DataTable

        Dim dt As New DataTable
        Dim str As String = "select Portal from user_mst where  Portal='" & PortalNm.ToString() & "' and user_id = '" & userid.ToString() & "' "
        Try
            If ConnectionState.Open Then
                Sqlconn.Close()
            End If
            Sqlconn.Open()
            Dim da As New SqlDataAdapter(str, Sqlconn)

            da.Fill(dt)

            Sqlconn.Close()

        Catch ex As Exception
            Sqlconn.Close()
        End Try
        Return dt
    End Function

    Public Function ExecuteNonQuery(ByVal SQL As String) As String
        Dim cmd As New SqlCommand
        Dim Status = "Fail"
        Try
            'If cmd.Connection.State = ConnectionState.Open Then
            '    cmd.Connection.Close()
            'End If

            cmd.Connection = Sqlconn
            cmd.CommandText = SQL
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()

            Status = "Sucess"
        Catch ex As Exception
            Status = ex.Message
            trn.Rollback()
            Sqlconn.Close()
        End Try
        Return Status
    End Function

    Public Function OpenConnection() As SqlConnection

        connect = New SqlConnection(constr)

        Try
            If connect.State = ConnectionState.Open Then
                connect.Close()
            End If
            connect.Open()
            loadflag = "YES"
        Catch exp As Exception
            Dim msg As String
            msg = "Error in Connecting........." & vbCrLf
            msg = msg + "Please Contact Your System Administrator"
            MsgBox(msg, MsgBoxStyle.Critical, "MIS & 5S Audit")
            loadflag = "NO"
        Finally
            If connect Is Nothing Then
                connect.Close()
            End If
        End Try
        OpenConnection = connect

    End Function

    Public Function GetDataSet(ByVal strSql As String, ByRef conn As SqlConnection) As DataSet
        GetDataSet = Nothing
        Dim ds As New DataSet
        Try
            Dim adptr As New SqlDataAdapter
            Dim cmd As New SqlCommand
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = strSql
            'cmd.CommandTimeout = 300
            adptr.SelectCommand = cmd
            adptr.Fill(ds)
            GetDataSet = ds
            conn.Close()
            Exit Function
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
        End Try
    End Function

    Public Function GetDataProcedure(ByVal strSql As String, ByRef conn As SqlConnection) As DataSet
        GetDataProcedure = Nothing
        Dim ds As New DataSet
        Try
            Dim adptr As New SqlDataAdapter
            Dim cmd As New SqlCommand
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = strSql
            'cmd.CommandTimeout = 300
            adptr.SelectCommand = cmd
            adptr.Fill(ds)
            GetDataProcedure = ds
            conn.Close()
            Exit Function
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
        End Try
    End Function

    Public Function savedata(ByVal str As String) As Boolean
        Dim cmd As New SqlCommand
        Dim con As New SqlConnection
        Try
            con = OpenConnection()
            trn = con.BeginTransaction
            cmd.Transaction = trn
            cmd.Connection = con
            cmd.CommandText = str
            cmd.ExecuteNonQuery()
            trn.Commit()
            con.Close()
            Return True
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information, msgtitle)
            trn.Rollback()
            con.Close()
            Return False
        End Try
    End Function

    Public Function ExecuteScaler(ByVal QueryStr As String) As Object

        Dim adptr As New SqlDataAdapter
        Dim cmd As New SqlCommand
        Dim con As New SqlConnection
        Dim dt As New DataTable
        Try
            con = OpenConnection()
            cmd.Connection = con
            cmd.CommandText = QueryStr
            adptr.SelectCommand = cmd
            adptr.Fill(dt)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0).Item(0).ToString()
            Else
                Return Nothing
            End If
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
    End Function

    '' Stored Procedure*************************************
    Public Function GetDataTable_SP(ByVal strProc As String, ByVal sqlParam As SqlParameter()) As DataTable
        GetDataTable_SP = Nothing
        Dim dt As New DataTable
        Dim adp As New SqlDataAdapter
        Dim cmd As New SqlCommand

        Try
            If ConnectionState.Open Then
                Sqlconn.Close()
            End If
            Sqlconn.Open()

            For Each param As SqlParameter In sqlParam
                cmd.Parameters.Add(param)
            Next

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = strProc
            cmd.Connection = Sqlconn
            'cmd.CommandTimeout = 480
            adp.SelectCommand = cmd

            adp.Fill(dt)
            GetDataTable_SP = dt
            Sqlconn.Close()
            Exit Function
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function
    ' GetDataSet_SP
    Public Function GetDataSet_SP(ByVal strProc As String, ByVal sqlParam As SqlParameter()) As DataSet
        GetDataSet_SP = Nothing
        Dim ds As New DataSet
        Dim adp As New SqlDataAdapter
        Dim cmd As New SqlCommand

        Try
            If ConnectionState.Open Then
                Sqlconn.Close()
            End If
            Sqlconn.Open()

            For Each param As SqlParameter In sqlParam
                cmd.Parameters.Add(param)
            Next

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = strProc
            cmd.Connection = Sqlconn
            'cmd.CommandTimeout = 480
            adp.SelectCommand = cmd
            adp.Fill(ds)
            GetDataSet_SP = ds
            Sqlconn.Close()
            Exit Function
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function

    Public Function upload_exceldata(ByVal dt As DataTable, user_name As String, utilityname As String) As Integer
        Dim Sqlquery1, Sqlquery2, Sql As String
        Dim Service_No, Book_No, Connection_No, Account_ID, Consumer_name As String
        Dim Address, Process, ST_Name, MF_Pole, Sanction_Load, Consumer_Categories As String
        Dim check_meter_removal_Date, Division_Name, MainMeter, MF_Main, PoleMeter, main_installaldate, main_removal_Date, check_meter_install_Date, meter_Reference_key As String
        Dim Zone, Circle, Consumer_key As String

        Dim i As Integer
        i = 0

        Dim myAL As New ArrayList()
        Dim row_upd As Integer
        For Each row In dt.Rows
            Try

                Service_No = row("Service_No").ToString

                Book_No = row("Book_No").ToString
                Connection_No = row("Connection_No").ToString
                Account_ID = row("Account_ID").ToString
                Consumer_name = row("Consumer_name").ToString

                i = i + 1


                Address = row("Address").ToString
                Process = row("Process").ToString
                ST_Name = row("ST_Name").ToString
                MF_Pole = row("MF_Pole").ToString
                Consumer_Categories = row("Consumer_Categories").ToString
                Service_No = row("Service_No").ToString
                Sanction_Load = row("Sanction_Load").ToString

                Division_Name = row("Division_Name").ToString
                MainMeter = row("MainMeter").ToString

                MainMeter = MainMeter.PadLeft(8, "0")

                Consumer_name.Replace("'", "")
                Consumer_name.Replace(",", "")
                Process.Replace(",", "")

                Dim i1 As Integer

                i1 = Len(Consumer_name)
                If i1 > 200 Then
                    i1 = 199
                End If
                If i1 >= 1 Then
                    Consumer_name = Consumer_name.Substring(0, i1 - 1)
                End If
                i1 = Len(Address)
                If i1 >= 199 Then
                    i1 = 199
                End If

                If i1 >= 1 Then
                    Address = Address.Substring(0, i1 - 1)
                End If
                i1 = Len(Process)
                If i1 >= 30 Then
                    i1 = 30
                End If


                If i1 >= 1 Then
                    Process = Process.Substring(0, i1 - 1)
                End If

                Address.Replace("'", "")
                Address.Replace(",", "")
                Consumer_Categories.Replace("'", "")
                Consumer_Categories.Replace(",", "")


                MF_Main = row("MF_Main").ToString
                PoleMeter = row("PoleMeter").ToString

                main_installaldate = row("main_installaldate").ToString
                main_removal_Date = row("main_removal_Date").ToString
                check_meter_install_Date = row("check_meter_install_Date").ToString
                check_meter_removal_Date = row("check_meter_removal_Date").ToString
                Zone = row("Zone").ToString
                Circle = row("Circle").ToString
                Consumer_key = row("Consumer_key").ToString

                meter_Reference_key = row("meter_Reference_key").ToString


                If MainMeter.ToString = "" And Consumer_key = "" Then
                    Return i
                End If


                Sqlquery1 = "update amr_meter_mst set meter_status='N' ,updated_on=getdate(),updated_by='" + user_name + "'  where meter_status='Y' and (Meternumber='" + MainMeter + "' or  Consumer_key = '" +  Consumer_key + " ') and utility_id= '" + utilityname + "';"
                If PoleMeter <> "NA" And PoleMeter <> "000000NA" And PoleMeter <> "00000000" And PoleMeter <> "Not Installed" And PoleMeter <> "N" And PoleMeter <> "0000000N" And PoleMeter <> "Y" And PoleMeter <> "L&T(WHITEBOX)" And PoleMeter <> "0" Then
                    Sqlquery2 = "update amr_meter_mst set meter_status='N' ,updated_on=getdate(),updated_by='" + user_name + "'  where meter_status='Y' and (check_meter_no='" + PoleMeter + "' or  Consumer_key = '" + Consumer_key + " ')  and utility_id= '" + utilityname + "';"
                End If
                PoleMeter = PoleMeter.PadLeft(8, "0")
                Sql = ""
                Sql = Sql + "insert into amr_meter_mst(Service_No,	Book_No,	Connection_No,	Account_ID,	Consumer_name,	Address,"
                Sql = Sql + "Process, ST_Name, Consumer_Categories, Sanction_Load, Division_Name, Meternumber, MF_Main, check_meter_no, MF_Pole,"
                Sql = Sql + "main_installaldate, main_removal_Date, check_meter_install_Date, check_meter_removal_Date, meter_status, "
                Sql = Sql + "inserted_on, inserted_by, updated_on, updated_by,utility_id,Zone,circle, consumer_key, meter_Reference_key) values( '"
                Sql = Sql + Service_No + "','" + Book_No + "','" + Connection_No + "','" + Account_ID + "','" + Consumer_name + "','" + Address + "','"
                Sql = Sql + Process + "','" + ST_Name + "','" + Consumer_Categories + "','" + Sanction_Load + "','" + Division_Name + "','" + MainMeter + "','" + MF_Main + "','" + PoleMeter + "','" + MF_Pole + "',"
                Sql = Sql + "convert(datetime,'" + main_installaldate + "',103)," + "convert(datetime,'" + main_removal_Date + "',103),"
                Sql = Sql + "convert(datetime,'" + check_meter_install_Date + "',103)," + "convert(datetime,'" + check_meter_removal_Date + "',103),'Y',"
                Sql = Sql + "getdate(),'" + user_name + "', getdate(),'" + user_name + "','" + utilityname + "','" + Zone + "','" + Circle + "'," + " dbo.master_key('" + MainMeter + "','" + utilityname + "','" + Consumer_key + "','" + Division_Name + "'),'" + meter_Reference_key + "');"

                myAL.Add(Sqlquery1)
                If Sqlquery2.ToString <> "" Then
                    myAL.Add(Sqlquery2)
                End If

                myAL.Add(Sql)
                Sql = ""
                Sqlquery2 = ""
                Sqlquery1 = ""

                If myAL.Count >= 1 Then
                    executedata_batchmode(myAL)

                    myAL.Clear()
                End If
            Catch ex As Exception

            End Try

        Next row
        executedata_batchmode(myAL)
        myAL.Clear()

        row_upd = dt.Rows.Count

        Return row_upd

        'Dim validrec As Integer

        'validrec = validate1(dt, did)

    End Function

    Public Function upload_exceldata1(ByVal dt As DataTable, user_name As String, utilityname As String) As Integer
        Dim Sqlquery1, Sqlquery2, Sql As String
        Dim Zone As String
        Dim Circle As String
        Dim Division As String
        Dim t33_KV_Sub_station_Name As String
        Dim Transformer As String
        Dim t11_KV_Incomer_name As String
        Dim t11_KV_Incomer_meterno As String
        Dim t11_KV_Incomer_metermake As String
        Dim t11_KV_Incomer_mf As String
        Dim t11_KV_Outgoing_name As String
        Dim t11_KV_Outgoing_meterno As String
        Dim t11_KV_Outgoing_Feede_metermake As String
        Dim t11_KV_Outgoing_Feeder_mf As String


        Dim i As Integer
        i = 0

        Dim myAL As New ArrayList()
        Dim row_upd As Integer
        Dim trn_sql As String = "truncate table ea_voltage_11"
        myAL.Add(trn_sql)
        For Each row In dt.Rows
            Try

                Zone = row("Zone").ToString
                Circle = row("Circle").ToString
                Division = row("Division").ToString
                t33_KV_Sub_station_Name = row("33_KV_Sub-station_Name").ToString
                Transformer = row("Transformer").ToString
                t11_KV_Incomer_name = row("11_KV_Incomer_name").ToString
                t11_KV_Incomer_meterno = row("11_KV_Incomer_meterno").ToString
                t11_KV_Incomer_metermake = row("11_KV_Incomer_metermake").ToString
                t11_KV_Incomer_mf = row("11_KV_Incomer_mf").ToString

                t11_KV_Outgoing_name = row("11_KV_Outgoing_name").ToString
                t11_KV_Outgoing_meterno = row("11_KV_Outgoing_meterno").ToString
                t11_KV_Outgoing_Feede_metermake = row("11_KV_Outgoing_Feede_metermake").ToString
                t11_KV_Outgoing_Feeder_mf = row("11_KV_Outgoing_Feeder_mf").ToString




                Sql = ""
                Sql = Sql + "insert into dbo.ea_voltage_11 (zone, circle, division, kv_33, transformer, kv_11_name, "
                Sql = Sql + " kv_11_meter_no, kv_11_meter_make, kv_11_mf, kv_11_out_name, kv_11_out_meter_no, kv_11_out_meter_make, kv_11_out_mf) values ('"


                Sql = Sql + Zone + "','" + Circle + "','" + Division + "','" + t33_KV_Sub_station_Name + "','" + Transformer + "','" + t11_KV_Incomer_name + "','"
                Sql = Sql + t11_KV_Incomer_meterno + "','" + t11_KV_Incomer_metermake + "','" + t11_KV_Incomer_mf + "','" + t11_KV_Outgoing_name + "','" + t11_KV_Outgoing_meterno + "','" + t11_KV_Outgoing_Feede_metermake + "','" + t11_KV_Outgoing_Feeder_mf + "');"
                myAL.Add(Sql)



                Sql = ""


                If myAL.Count >= 100 Then
                    executedata_batchmode(myAL)
                    myAL.Clear()
                End If
            Catch ex As Exception

            End Try

        Next row
        executedata_batchmode(myAL)
        myAL.Clear()

        row_upd = dt.Rows.Count

        Return row_upd

        'Dim validrec As Integer

        'validrec = validate1(dt, did)

    End Function


    Public Function upload_exceldata_33kv(ByVal dt As DataTable, user_name As String, utilityname As String) As Integer
        Dim Sqlquery1, Sqlquery2, Sql As String
        Dim Zone As String
        Dim Circle As String
        Dim Division As String
        Dim primary_sub_station As String
        Dim Name_of_33_KV_circuit As String
        Dim PSMeter_No As String
        Dim PSMeter_Make As String
        Dim PSMF As String
        Dim Name_of_33KV_sub_station As String
        Dim receiving_End_Subsation_Name As String
        Dim RecvingMeter_No As String
        Dim Meter_Make As String
        Dim MF As String
        Dim i As Integer
        i = 0

        Dim myAL As New ArrayList()
        Dim row_upd As Integer
        Dim trn_sql As String = "truncate table ea_voltage_33"
        myAL.Add(trn_sql)
        For Each row In dt.Rows
            Try

                Zone = row("Zone").ToString
                Circle = row("Circle").ToString
                Division = row("Division").ToString
                primary_sub_station = row("primary_sub_station").ToString
                Name_of_33_KV_circuit = row("Name_of_33_KV_circuit").ToString
                ' receiving_End_Subsation_Name = row("receiving_End_Subsation_Name").ToString
                PSMeter_No = row("PSMeter_No")
                PSMeter_Make = row("PSMeter_Make").ToString
                PSMF = row("PSMF").ToString
                Name_of_33KV_sub_station = row("Name_of_33KV_sub_station").ToString
                receiving_End_Subsation_Name = row("receiving_End_Subsation_Name").ToString
                RecvingMeter_No = row("RecvingMeter_No").ToString
                Meter_Make = row("Meter_Make").ToString
                MF = row("MF").ToString

                Sql = ""
                Sql = Sql + "insert into dbo.ea_voltage_33 (Zone, Circle, Division, primary_substation, Name_33KV_circuit, PSMeter_No, PSMeter_Make, PSMF, susbstaion_feeded, sunstation_receiving, RecvingMeterno, MeterMake, MF) values ('"
                Sql = Sql + Zone + "','" + Circle + "','" + Division + "','" + primary_sub_station + "','" + Name_of_33_KV_circuit + "','" + PSMeter_No + "','"
                Sql = Sql + PSMeter_Make + "','" + PSMF + "','" + Name_of_33KV_sub_station + "','" + receiving_End_Subsation_Name + "','" + RecvingMeter_No + "','" + Meter_Make + "','" + MF + "');"
                myAL.Add(Sql)



                Sql = ""


                If myAL.Count >= 100 Then
                    executedata_batchmode(myAL)
                    myAL.Clear()
                End If
            Catch ex As Exception

            End Try

        Next row
        executedata_batchmode(myAL)
        myAL.Clear()

        row_upd = dt.Rows.Count

        Return row_upd

        'Dim validrec As Integer

        'validrec = validate1(dt, did)

    End Function
    Public Function ExecuteGraph(ByVal QueryStr As String) As DataTable

        Dim adptr As New SqlDataAdapter
        Dim cmd As New SqlCommand
        Dim con As New SqlConnection
        Dim dt As New DataTable
        Dim res As String
        Try
            con = OpenConnection()
            cmd.Connection = con
            cmd.CommandText = QueryStr
            adptr.SelectCommand = cmd
            dt.Clear()
            adptr.Fill(dt)
            ' res = cmd.ExecuteScalar

            con.Close()
            Return dt
        Catch ex As Exception
            con.Close()
        End Try
    End Function
    Public Function ExecuteScalar(ByVal QueryStr As String) As String

        Dim adptr As New SqlDataAdapter
        Dim cmd As New SqlCommand
        Dim con As New SqlConnection
        Dim dt As New DataTable
        Dim res As String
        Try
            con = OpenConnection()
            cmd.Connection = con
            cmd.CommandText = QueryStr

            res = cmd.ExecuteScalar

            con.Close()
            Return res
        Catch ex As Exception
            con.Close()
        End Try
    End Function
    Public Function upload_referred_cases(ByVal dt As DataTable, user_name As String, utilityname As String) As Integer
        Dim Sqlquery1, Sqlquery2, Sql As String
        Dim meternumber, change_meternumber, referred_month, read_month As String
        Dim Address, Process, ST_Name, MF_Pole, Sanction_Load, Consumer_Categories As String
       
        Dim i As Integer
        i = 0

        Dim myAL As New ArrayList()
        Dim row_upd As Integer
        For Each row In dt.Rows
            Try



                meternumber = row("meternumber").ToString

                meternumber = meternumber.PadLeft(8, "0")
                change_meternumber = row("change_meternumber").ToString
                change_meternumber = change_meternumber.PadLeft(8, "0")

                referred_month = row("referred_month").ToString
                read_month = row("read_month").ToString



                '                create table referred_Cases
                '(
                'consumer_key	varchar(30),
                'meternumber		varchar(30), 
                'change_meternumber	varchar(30),
                'referred_month		date,
                'read_month			date,
                'insertedon			datetime,
                'reading_kw_referred_month	integer,
                'reading_kw_readmonth	integer
                ')

                Sql = ""
                Sql = Sql + "insert into referred_Cases(consumer_key,meternumber,change_meternumber,referred_month,read_month,insertedon,inserted_by,updatedon) values ('', '"
                Sql = Sql + meternumber + "','" + change_meternumber + "','" + referred_month + "','" + read_month + "',getdate(),'" + user_name + "',getdate() )"
              
                myAL.Add(Sql)
                If Sql.ToString <> "" Then
                    myAL.Add(Sql)
                End If

                myAL.Add(Sql)
                Sql = ""
                Sqlquery2 = ""
                Sqlquery1 = ""

                'If myAL.Count >= 1 Then
                '    executedata_batchmode(myAL)

                '    myAL.Clear()
                'End If
            Catch ex As Exception

            End Try

        Next row
        executedata_batchmode(myAL)
        myAL.Clear()

        row_upd = dt.Rows.Count

        Return row_upd

        'Dim validrec As Integer

        'validrec = validate1(dt, did)

    End Function

    Public Function upload_referred_cases1(ByVal dt As DataTable, user_name As String, utilityname As String, ddl_input As String, curr_month As String) As Integer
        Dim Sqlquery1, Sqlquery2, Sql As String
        Dim key, change_meternumber, referred_month, read_month As String
        Dim start_Date As String

        Dim i As Integer
        i = 0

        Dim myAL As New ArrayList()
        Dim row_upd As Integer
        For Each row In dt.Rows
            Try


                If ddl_input.ToString = "Meternumber" Then
                    key = row("meternumber").ToString
                Else
                    key = row("UniqueID").ToString
                End If

                referred_month = row("reffered_month").ToString

                '                create table referred_Cases
                '(
                'consumer_key	varchar(30),
                'meternumber		varchar(30), 
                'change_meternumber	varchar(30),
                'referred_month		date,
                'read_month			date,
                'insertedon			datetime,
                'reading_kw_referred_month	integer,
                'reading_kw_readmonth	integer
                ')]

                change_meternumber = ""


                If ddl_input.ToString = "Meternumber" Then
                    'meternumber, referred_month, change_meternumber, current_month, reading_kvah_referred_month, reading_kvah_currentmonth
                    Sql = Sql + "insert into referred_Cases_new ( meternumber, referred_month,insrtd_on ) values ('"
                    Sql = Sql + key + "','" + referred_month.ToString + "',getdate() )"
                Else
                    'meternumber, referred_month, change_meternumber, current_month, reading_kvah_referred_month, reading_kvah_currentmonth
                    Sql = Sql + "insert into referred_Cases_new ( [consumer_key, referred_month,insrtd_on ) values ('"
                    Sql = Sql + key + "','" + referred_month.ToString + "',getdate() )"
                End If


                'myAL.Add(Sql)
                If Sql.ToString <> "" Then
                    myAL.Add(Sql)
                End If

                'myAL.Add(Sql)
                Sql = ""
                Sqlquery2 = ""
                Sqlquery1 = ""

                'If myAL.Count >= 1 Then
                '    executedata_batchmode(myAL)

                '    myAL.Clear()
                'End If
            Catch ex As Exception

            End Try

        Next row
        executedata_batchmode(myAL)
        myAL.Clear()

        row_upd = dt.Rows.Count

        Return row_upd

        'Dim validrec As Integer

        'validrec = validate1(dt, did)

    End Function

    'Bind Drop Down Discom,Zone,Circle,Division,SubDivision,Substation,Feeder

    Public Function bind_dropdown(role As String, discom As String, zone As String, circle As String, division As String, subdivision As String, substation As String, feeder As String, source As String) As DataTable
        Dim dt1 As New DataTable
        'Dim query As String = ""
        'If Session("AccessDiscom") = "ALL" Then
        '    query = "exec proc_DynamicDropdownBind 'Discom','','','','','','','' "
        'ElseIf Session("AccessDiscom") <> "ALL" Then
        '    query = "exec proc_DynamicDropdownBind " & Session("AccessDiscom") & ",'','','','','','',''"
        'End If
        'dt1 = s1.GetDataTable(query)
        'Dim strConnString As String = maincls.myconnection 'ConfigurationManager.ConnectionStrings("conMIS_String").ConnectionString
        'Dim con As New SqlConnection(strConnString)
        'Dim cmd As New SqlCommand()
        'Dim dt1 As New DataTable
        Dim adptr As New SqlDataAdapter
        Dim cmd As New SqlCommand
        Dim con As New SqlConnection
        Dim dt As New DataTable
        ' Dim discom, zone, circle, division, subdivision, substation, feeder As String
        con = OpenConnection()
        cmd.Connection = con
        'cmd.CommandText = QueryStr
        If role = Nothing Then
            role = ""
        End If
        If discom = Nothing Then
            discom = ""
        End If
        If circle = Nothing Then
            circle = ""
        End If
        If division = Nothing Then
            division = ""
        End If
        If subdivision = Nothing Then
            subdivision = ""
        End If
        If substation = Nothing Then
            substation = ""
        End If
        If feeder = Nothing Then
            feeder = ""
        End If
        If source = Nothing Then
            source = ""
        End If

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "proc_DynamicDropdownBind"
        cmd.Parameters.Add("@Role", SqlDbType.VarChar).Value = role
        'cmd.Parameters.Add("@Month", SqlDbType.VarChar).Value = ddlMonthDetails.SelectedValue
        cmd.Parameters.Add("@Discom", SqlDbType.VarChar).Value = discom
        cmd.Parameters.Add("@Zone", SqlDbType.VarChar).Value = zone
        cmd.Parameters.Add("@Circle", SqlDbType.VarChar).Value = circle
        cmd.Parameters.Add("@Division", SqlDbType.VarChar).Value = division
        cmd.Parameters.Add("@SubDivision", SqlDbType.VarChar).Value = subdivision
        cmd.Parameters.Add("@Substation", SqlDbType.VarChar).Value = substation
        cmd.Parameters.Add("@Feeder", SqlDbType.VarChar).Value = feeder
        cmd.Parameters.Add("@Source", SqlDbType.VarChar).Value = source
        'cmd.Parameters.Add("@ColumnIndex", SqlDbType.Int).Value = Convert.ToInt64(ColumnIndex)
        'cmd.Connection = con
        'con.Open()
        cmd.CommandTimeout = 300
        Using sda As New SqlDataAdapter(cmd)
            sda.Fill(dt1)
        End Using
        Return dt1
    End Function

    Public Function bind_exceptionGrid(discom As String, zone As String, circle As String, division As String) As DataTable
        Dim dt1 As New DataTable
        Dim adptr As New SqlDataAdapter
        Dim cmd As New SqlCommand
        Dim con As New SqlConnection
        Dim dt As New DataTable
        con = OpenConnection()
        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "proc_ExceptionDataBinding"
        'cmd.Parameters.Add("@parm", SqlDbType.VarChar).Value = strgrid
        cmd.Parameters.Add("@Discom", SqlDbType.VarChar).Value = discom
        cmd.Parameters.Add("@Zone", SqlDbType.VarChar).Value = zone
        cmd.Parameters.Add("@Circle", SqlDbType.VarChar).Value = circle
        cmd.Parameters.Add("@Division", SqlDbType.VarChar).Value = division
        'con.Open()
        cmd.CommandTimeout = 300
        Using sda As New SqlDataAdapter(cmd)
            sda.Fill(dt1)
        End Using
        Return dt1
    End Function

    Public Function UpdateOmninet_BillingMapping(StrucID As Integer, BilliID As Integer, RollName As String) As DataTable
        Dim dt1 As New DataTable
        Dim adptr As New SqlDataAdapter
        Dim cmd As New SqlCommand
        Dim con As New SqlConnection
        Dim dt As New DataTable
        con = OpenConnection()
        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "proc_OmninetExceptionInsertUpdate"
        cmd.Parameters.Add("@Struc_ID", SqlDbType.Int).Value = StrucID
        cmd.Parameters.Add("@Billid_ID", SqlDbType.Int).Value = BilliID
        cmd.Parameters.Add("@RollName", SqlDbType.VarChar).Value = RollName
        'con.Open()
        cmd.CommandTimeout = 300
        Using sda As New SqlDataAdapter(cmd)
            sda.Fill(dt1)
        End Using
        Return dt1
    End Function

    'Level3 DropDown Data Binding
    Public Function bind_DT_dropdown(role As String, discom As String, zone As String, circle As String, division As String, subdivision As String, substation As String, feeder As String) As DataTable
        Dim dt1 As New DataTable
        Dim adptr As New SqlDataAdapter
        Dim cmd As New SqlCommand
        Dim con As New SqlConnection
        Dim dt As New DataTable
        con = OpenConnection()
        cmd.Connection = con
        If role = Nothing Then
            role = ""
        End If
        If discom = Nothing Then
            discom = ""
        End If
        If circle = Nothing Then
            circle = ""
        End If
        If division = Nothing Then
            division = ""
        End If
        If subdivision = Nothing Then
            subdivision = ""
        End If
        If substation = Nothing Then
            substation = ""
        End If
        If feeder = Nothing Then
            feeder = ""
        End If

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "proc_DT_DynamicDropdownBind"
        cmd.Parameters.Add("@Role", SqlDbType.VarChar).Value = role
        cmd.Parameters.Add("@Discom", SqlDbType.VarChar).Value = discom
        cmd.Parameters.Add("@Zone", SqlDbType.VarChar).Value = zone
        cmd.Parameters.Add("@Circle", SqlDbType.VarChar).Value = circle
        cmd.Parameters.Add("@Division", SqlDbType.VarChar).Value = division
        cmd.Parameters.Add("@SubDivision", SqlDbType.VarChar).Value = subdivision
        cmd.Parameters.Add("@Substation", SqlDbType.VarChar).Value = substation
        cmd.Parameters.Add("@Feeder", SqlDbType.VarChar).Value = feeder
        cmd.CommandTimeout = 300
        Using sda As New SqlDataAdapter(cmd)
            sda.Fill(dt1)
        End Using
        Return dt1
    End Function
    'Level3 Data Binding
    Public Function bing_Level3DTwiseGrid(month As String, discom As String, zone As String, circle As String, division As String, subdivision As String, substation As String, feeder As String, source As String) As DataTable
        Dim dt1 As New DataTable
        Dim adptr As New SqlDataAdapter
        Dim cmd As New SqlCommand
        Dim con As New SqlConnection
        Dim dt As New DataTable
        con = OpenConnection()
        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "proc_Level3_DTSummary"
        cmd.Parameters.Add("@Month", SqlDbType.VarChar).Value = month
        cmd.Parameters.Add("@Discom", SqlDbType.VarChar).Value = discom
        cmd.Parameters.Add("@Zone", SqlDbType.VarChar).Value = zone
        cmd.Parameters.Add("@Circle", SqlDbType.VarChar).Value = circle
        cmd.Parameters.Add("@Division", SqlDbType.VarChar).Value = division
        cmd.Parameters.Add("@Subdivision", SqlDbType.VarChar).Value = subdivision
        cmd.Parameters.Add("@Substation", SqlDbType.VarChar).Value = substation
        cmd.Parameters.Add("@Feeder", SqlDbType.VarChar).Value = feeder
        cmd.Parameters.Add("@Source", SqlDbType.VarChar).Value = source
        'con.Open()
        cmd.CommandTimeout = 300
        Using sda As New SqlDataAdapter(cmd)
            sda.Fill(dt1)
        End Using
        Return dt1
    End Function


    'HV DropDown Data Binding
    Public Function bing_HV_wiseDropdown(role As String, discom As String, zone As String, circle As String, division As String, subdivision As String, substation As String, feeder As String) As DataTable
        Dim dt1 As New DataTable
        Dim adptr As New SqlDataAdapter
        Dim cmd As New SqlCommand
        Dim con As New SqlConnection
        Dim dt As New DataTable
        con = OpenConnection()
        cmd.Connection = con
        If role = Nothing Then
            role = ""
        End If
        If discom = Nothing Then
            discom = ""
        End If
        If circle = Nothing Then
            circle = ""
        End If
        If division = Nothing Then
            division = ""
        End If
        If subdivision = Nothing Then
            subdivision = ""
        End If
        If substation = Nothing Then
            substation = ""
        End If
        If feeder = Nothing Then
            feeder = ""
        End If

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "proc_HV_DynamicDropdownBind"
        cmd.Parameters.Add("@Role", SqlDbType.VarChar).Value = role
        cmd.Parameters.Add("@Discom", SqlDbType.VarChar).Value = discom
        cmd.Parameters.Add("@Zone", SqlDbType.VarChar).Value = zone
        cmd.Parameters.Add("@Circle", SqlDbType.VarChar).Value = circle
        cmd.Parameters.Add("@Division", SqlDbType.VarChar).Value = division
        cmd.Parameters.Add("@SubDivision", SqlDbType.VarChar).Value = subdivision
        cmd.Parameters.Add("@Substation", SqlDbType.VarChar).Value = substation
        cmd.Parameters.Add("@Feeder", SqlDbType.VarChar).Value = feeder
        cmd.CommandTimeout = 300
        Using sda As New SqlDataAdapter(cmd)
            sda.Fill(dt1)
        End Using
        Return dt1
    End Function

    Public Function Exceptionbind_dropdown(role As String, discom As String, zone As String, circle As String, division As String, subdivision As String, substation As String, feeder As String) As DataTable
        Dim dt1 As New DataTable
        Dim adptr As New SqlDataAdapter
        Dim cmd As New SqlCommand
        Dim con As New SqlConnection
        Dim dt As New DataTable
        ' Dim discom, zone, circle, division, subdivision, substation, feeder As String
        con = OpenConnection()
        cmd.Connection = con
        'cmd.CommandText = QueryStr
        If role = Nothing Then
            role = ""
        End If
        If discom = Nothing Then
            discom = ""
        End If
        If circle = Nothing Then
            circle = ""
        End If
        If division = Nothing Then
            division = ""
        End If
        If subdivision = Nothing Then
            subdivision = ""
        End If
        If substation = Nothing Then
            substation = ""
        End If
        If feeder = Nothing Then
            feeder = ""
        End If

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "proc_Excep_DynamicDropdownBind"
        cmd.Parameters.Add("@Role", SqlDbType.VarChar).Value = role
        'cmd.Parameters.Add("@Month", SqlDbType.VarChar).Value = ddlMonthDetails.SelectedValue
        cmd.Parameters.Add("@Discom", SqlDbType.VarChar).Value = discom
        cmd.Parameters.Add("@Zone", SqlDbType.VarChar).Value = zone
        cmd.Parameters.Add("@Circle", SqlDbType.VarChar).Value = circle
        cmd.Parameters.Add("@Division", SqlDbType.VarChar).Value = division
        cmd.Parameters.Add("@SubDivision", SqlDbType.VarChar).Value = subdivision
        cmd.Parameters.Add("@Substation", SqlDbType.VarChar).Value = substation
        cmd.Parameters.Add("@Feeder", SqlDbType.VarChar).Value = feeder
        'cmd.Parameters.Add("@ColumnIndex", SqlDbType.Int).Value = Convert.ToInt64(ColumnIndex)
        'cmd.Connection = con
        'con.Open()
        cmd.CommandTimeout = 300
        Using sda As New SqlDataAdapter(cmd)
            sda.Fill(dt1)
        End Using
        Return dt1
    End Function


End Class

