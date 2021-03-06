Imports System.Data.SqlClient
Public Class ChequeCriteriaForPrint
    Dim MyID As String
    Dim GetChequeID As String
    Dim tbl As DataTable
    Dim tbl2 As DataTable
    Dim rowR As DataRow
    Dim rowDetail As DataRow
    Dim row As DataRow
    Dim CheqCopiesToBeDeleted As String
    Dim Arr_GetCheqID As ArrayList
    Dim Arr_GetCheqNo As ArrayList

    Sub New(ByVal ID As String)
        MyID = ID
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Public Class XNAMES
        Dim _fname As String
        Dim _lname As String

        Sub New(ByVal fname As String, ByVal lname As String)
            _fname = fname
            _lname = lname
        End Sub

        Public ReadOnly Property fname() As String
            Get
                Return _fname
            End Get
        End Property

        Public ReadOnly Property lname() As String
            Get
                Return _lname
            End Get
        End Property
    End Class


    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If RBCurrentCheque.Checked = True Then
            Try
                Module1.DatasetFill("Select * from RptVuCheqMain where CheqID=N'" & MyID & "'", "RptVuCheqMain")
                Module1.DatasetFill("Select * from RptVuCheqDetail where CheqID=N'" & MyID & "'", "RptVuCheqDetail")
                Dim rpt As New RptChequeMultiple 'RptCheque
                rpt.SetDataSource(Module1.ds)
                frmRptSetup.CV.ReportSource = rpt
                Frm.RptShow()
                Me.Close()

            Catch ex As Exception

            End Try

        ElseIf RBList.Checked.Equals(True) Or RBSearch.Checked.Equals(True) Then
            Try

                Call CollectSelection()

                Dim flter As String = ""
                For x As Integer = 0 To Arr_GetCheqID.Count - 1
                    flter += "CheqID=" & Arr_GetCheqID.Item(x) & " Or "
                    GetChequeID += Arr_GetCheqID.Item(x) & ","
                Next
                If Not flter = "" Then
                    flter = flter.Substring(0, flter.Length - 4)
                End If
                ' Now for removing the last comma (,) we should do this:
                If Not GetChequeID = "" Then
                    GetChequeID = GetChequeID.Substring(0, GetChequeID.Length - 1)
                End If

                Module1.DatasetFill("Select * from RptVuCheqMain where CheqID in (" & GetChequeID & ")", "RptVuCheqMain")

                Dim dsNewRowR() As DataRow = Module1.ds.Tables("RptVuCheqMain").Select(flter)
                For Each rR As DataRow In dsNewRowR
                    rowR = Module1.ds.Tables("RptVuCheqMain").NewRow()

                    rowR.Item("CheqID") = rR("CheqID")
                    rowR.Item("CheqNo") = rR("CheqNo").ToString & "-Copy"
                    rowR.Item("CheqDate") = rR("CheqDate")
                    rowR("InvoiceNo") = rR("InvoiceNo")
                    rowR("CustomerName") = rR("CustomerName")
                    rowR("SalOrderNo") = rR("SalOrderNo")
                    rowR("GoDownName") = rR("GoDownName")
                    rowR("GoDownKeeperName") = rR("GoDownKeeperName")
                    rowR("GoDownPhone") = rR("GoDownPhone")
                    rowR("GoDownAddress") = rR("GoDownAddress")
                    rowR("Remarks") = rR("Remarks")
                    Module1.ds.Tables("RptVuCheqMain").Rows.Add(rowR)

                Next

                Module1.DatasetFill("Select * from ChequeMain where CheqID in (" & GetChequeID & ")", "ChequeMain")
                Arr_GetCheqNo = New ArrayList
                Dim dsNewRow() As DataRow = Module1.ds.Tables("ChequeMain").Select(flter)
                For Each r As DataRow In dsNewRow
                    row = Module1.ds.Tables("ChequeMain").NewRow()
                    row.Item(0) = r(0).ToString
                    row.Item(1) = r(1).ToString & "-Copy"

                    ' let me note cheque copies that should be deleted after printed.
                    CheqCopiesToBeDeleted += "'" & row.Item(1) & "',"
                    Arr_GetCheqNo.Add(row.Item(1))

                    'Arr_GetCheqNo.Add(New XNAMES((row.Item(0).ToString()), row.Item(1).ToString()))
                    'row(0) = r(0)
                    For i As Integer = 2 To row.ItemArray.Length - 1
                        row(i) = r(i)

                    Next
                    Module1.ds.Tables("ChequeMain").Rows.Add(row)

                Next
                ' we need to save it only in main.
                SaveCopies()


                Module1.DatasetFill("select * from RptVuCheqDetail where CheqID in (" & GetChequeID & ")", "RptVuCheqDetail")

                Dim rpt As New RptChequeMultiple
                rpt.SetDataSource(Module1.ds)
                frmRptSetup.CV.ReportSource = rpt
                Frm.RptShow()

                If Not CheqCopiesToBeDeleted = "" Then
                    CheqCopiesToBeDeleted = CheqCopiesToBeDeleted.Substring(0, CheqCopiesToBeDeleted.Length - 1)
                End If
                Dim Criteria As String = "CheqNo In(" & CheqCopiesToBeDeleted & ")"
                Module1.DeleteRecord("ChequeMain", Criteria)

                Me.Close()

            Catch ex As Exception

            End Try
        End If
    End Sub
    Sub SaveCopies()
        For x As Integer = 0 To Arr_GetCheqNo.Count - 1


            Dim cmdsave As New SqlCommand
            cmdsave.CommandType = CommandType.StoredProcedure
            cmdsave.CommandText = "InsertUpdateChequeMain"
            cmdsave.Connection = cn
            cmdsave.Parameters.Add("@CheqID", SqlDbType.VarChar).Value = Arr_GetCheqID(x) 'row("CheqID")
            cmdsave.Parameters.Add("@CheqNo", SqlDbType.NVarChar).Value = Arr_GetCheqNo(x)
            cmdsave.Parameters.Add("@CheqDate", SqlDbType.SmallDateTime).Value = row("CheqDate")
            cmdsave.Parameters.Add("@SaleID", SqlDbType.Int).Value = row("SaleID")
            cmdsave.Parameters.Add("@SalOrderID", SqlDbType.Int).Value = row("SalOrderID")
            cmdsave.Parameters.Add("@CustomerID", SqlDbType.Int).Value = row("CustomerID")
            cmdsave.Parameters.Add("@GodownID", SqlDbType.Int).Value = row("GodownID")
            'cmdsave.Parameters.Add("@keeperName", SqlDbType.NVarChar).Value = Me.txtGodownKeeper.Text.Trim()
            cmdsave.Parameters.Add("@GoDownKeeperName", SqlDbType.NVarChar).Value = row("GoDownKeeperName")
            cmdsave.Parameters.Add("@GoDownPhone", SqlDbType.NVarChar).Value = row("GoDownPhone")
            cmdsave.Parameters.Add("@GoDownAddress", SqlDbType.NVarChar).Value = row("GoDownAddress")
            cmdsave.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = row("Remarks")
            cmdsave.Parameters.Add("@CityID", SqlDbType.Int).Value = Val("1")
            cmdsave.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = "KBL" & "-" & row("CheqID")

            cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = 1
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmdsave.ExecuteNonQuery()

            cmdsave.Parameters.Clear()
        Next
    End Sub
 
    Sub GetMulticopies()
        Dim query As String = ""
        'query += ""
        'Module1.ExecuteMyQuery("")
        query += "Delete from ChequeDisplayTwice "
        query += "INSERT INTO ChequeDisplayTwice(CheqID,"
        query += "CheqNo,"
        query += "CheqDate,"
        query += "InvoiceNo,"
        query += "CustomerName,"
        query += "SalOrderNo,"
        query += "GoDownName,"
        query += "GoDownKeeperName,"
        query += "GoDownPhone,"
        query += "GoDownAddress,"
        query += "Remarks) "
        query += "SELECT CheqID,"
        query += "CheqNo,"
        query += "CheqDate,"
        query += "InvoiceNo,"
        query += "CustomerName,"
        query += "SalOrderNo,"
        query += "GoDownName,"
        query += "GoDownKeeperName,"
        query += "GoDownPhone,"
        query += "GoDownAddress,"
        query += "Remarks "
        query += "FROM RptVuCheqMain2 "
        query += "WHERE CheqID in( 1,2) "
        query += "INSERT INTO ChequeDisplayTwice(CheqID,"
        query += "CheqNo,"
        query += "CheqDate,"
        query += "InvoiceNo,"
        query += "CustomerName,"
        query += "SalOrderNo,"
        query += "GoDownName,"
        query += "GoDownKeeperName,"
        query += "GoDownPhone,"
        query += "GoDownAddress,"
        query += "Remarks) "
        query += "SELECT CheqID,"
        query += "CheqNo,"
        query += "CheqDate,"
        query += "InvoiceNo,"
        query += "CustomerName,"
        query += "SalOrderNo,"
        query += "GoDownName,"
        query += "GoDownKeeperName,"
        query += "GoDownPhone,"
        query += "GoDownAddress,"
        query += "Remarks "
        query += "FROM RptVuCheqMain2 "
        query += "WHERE CheqID in( 1,2)"

        'query += "select * from ChequeDisplayTwice order by CheqID"
        Module1.ExecuteMyQuery(query)
    End Sub
    Sub CollectSelection()
        Try
            GetChequeID = ""
            Dim Increamenter As Integer = 0
            Arr_GetCheqID = New ArrayList
            For Each row As DataGridViewRow In DG.Rows
                If Not DG.Rows(Increamenter).Cells("DGCheckBox").Value = Nothing Then
                    Arr_GetCheqID.Add(DG.Rows(Increamenter).Cells("DGChequeID").Value)
                    'MsgBox("asdf")
                End If
                Increamenter = Increamenter + 1
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub ClearSelection()
        Try
            Dim Increamenter As Integer = 0
            For Each row As DataGridViewRow In DG.Rows
                DG.Rows(Increamenter).Cells("DGCheckBox").Value = Nothing
                Increamenter = Increamenter + 1
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChequeCriteriaForPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Me.Icon = My.Resources.IALResources.IAL
            Dim cmbCriteriaType_DisplayedValues As String
            Dim cmbCriteriaType_SelectedValues As String
            cmbCriteriaType_DisplayedValues = "اسم مشتری,شمارۀ چک,شمارۀ انوایس"
            cmbCriteriaType_SelectedValues = "1,2,3"

            Dim cmbDisplayedValues(3) As String
            cmbDisplayedValues = cmbCriteriaType_DisplayedValues.Split(",")
            Dim cmbSelectedValues(3) As String
            cmbSelectedValues = cmbCriteriaType_SelectedValues.Split(",")

            Dim SeachComboTable As New DataTable
            SeachComboTable.TableName = "SearchTable"
            SeachComboTable.Columns.Add("ID")
            SeachComboTable.Columns.Add("Name")

            'SeachComboTable.Rows.Add()
            Dim n As Integer
            For n = 0 To cmbDisplayedValues.Length - 1
                Dim datarow As DataRow

                datarow = SeachComboTable.NewRow()
                datarow("ID") = cmbSelectedValues(n)
                datarow("Name") = cmbDisplayedValues(n)
                SeachComboTable.Rows.Add(datarow)
            Next

            If ds.Tables.Contains("SearchTable") Then
                ds.Tables.Remove("SearchTable")
            End If
            ds.Tables.Add(SeachComboTable)

            cmbCriteriaType.Items.Clear()

            '  MsgBox(ds.Tables("SearchTable").Rows.Count)

            cmbCriteriaType.DataSource = ds.Tables("SearchTable")
            cmbCriteriaType.DisplayMember = "Name"
            cmbCriteriaType.ValueMember = "ID"

            'cmbCriteriaType.DisplayMember = cmbDisplayedValues(0)
            'cmbCriteriaType.SelectedValue = cmbSelectedValues()
            ' cmbCriteriaType.SelectedItem = cmbCriteriaType_SelectedValues
            Call GridFill()
        Catch ex As Exception

        End Try
    End Sub
    Sub GridFill()
        Try



            Dim i As Integer = 0
            Module1.DatasetFill("Select CheqID,CustomerName,CheqNo,InvoiceNo from RptVuCheqMain", "RptVuCheqMain")
            DG.Rows.Clear()
            For Each datarow As DataRow In ds.Tables("RptVuCheqMain").Rows
                DG.Rows.Add()
                DG.Rows(i).Cells("DGSNo").Value = i + 1
                DG.Rows(i).Cells("DGChequeID").Value = datarow("CheqID")
                DG.Rows(i).Cells("DGChequeNo").Value = datarow("CheqNo")
                DG.Rows(i).Cells("DGCustomerName").Value = datarow("CustomerName")
                DG.Rows(i).Cells("DGInvoiceNo").Value = datarow("InvoiceNo")
                i = i + 1
            Next

        Catch ex As Exception

        End Try
    End Sub
    Sub GridFillOnSearch()
        Dim i As Integer = 0
        Dim cs As Integer = cmbCriteriaType.SelectedValue
        Dim FieldName As String
        Select Case cs
            Case 1
                FieldName = "CustomerName"
            Case 2
                FieldName = "CheqNo"
            Case 3
                FieldName = "InvoiceNo"
        End Select

        Module1.DatasetFill("Select CheqID,CustomerName,CheqNo,InvoiceNo from RptVuCheqMain where " & FieldName & " = '" & txtCriteriaValue.Text & "'", "RptVuCheqMain")
        DG.Rows.Clear()
        For Each datarow As DataRow In ds.Tables("RptVuCheqMain").Rows
            DG.Rows.Add()
            DG.Rows(i).Cells("DGSNo").Value = i + 1

            DG.Rows(i).Cells("DGChequeID").Value = datarow("CheqID")
            DG.Rows(i).Cells("DGCustomerName").Value = datarow("CustomerName")
            DG.Rows(i).Cells("DGChequeNo").Value = datarow("CheqNo")
            DG.Rows(i).Cells("DGInvoiceNo").Value = datarow("InvoiceNo")
            i = i + 1
        Next
    End Sub

    Private Sub RBCurrentCheque_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBCurrentCheque.CheckedChanged
        If RBCurrentCheque.Checked.Equals(True) Then
            DG.ReadOnly = True
            GroupBox1.Enabled = False
            GridFill()
            ClearSelection()
        End If
    End Sub

    Private Sub RBList_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBList.CheckedChanged
        If RBList.Checked.Equals(True) Then
            DG.ReadOnly = False
            GroupBox1.Enabled = False
            GridFill()
        Else
            DG.ReadOnly = True
        End If
    End Sub

    Private Sub RBSearch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSearch.CheckedChanged
        If RBSearch.Checked.Equals(True) Then
            DG.ReadOnly = False
            GroupBox1.Enabled = True
        Else
            GroupBox1.Enabled = False
            Call GridFill()
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            If Not txtCriteriaValue.Text.Trim() = "" Then
                GridFillOnSearch()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtCriteriaValue_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCriteriaValue.KeyPress
        If e.KeyChar = Chr(13) Then
            btnSearch.PerformClick()
        End If
    End Sub
    Private Sub DelegateCellData(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Me.DG.CurrentCell.Value = Me.ActiveControl.Text & e.KeyChar
    End Sub
    Private Sub DG_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DG.EditingControlShowing
        Try

            Dim cont As Control = e.Control
            Dim tpe As Type = cont.GetType
            If tpe.FullName = "System.Windows.Forms.DataGridViewTextBoxEditingControl" Then
                Try
                    Dim ltxt As New TextBox
                    ltxt = CType(e.Control, TextBox)
                    AddHandler ltxt.KeyPress, AddressOf DelegateCellData

                Catch ex As Exception

                End Try
            ElseIf tpe.FullName = "System.Windows.Forms.DataGridViewComboBoxEditingControl" Then

            End If

        Catch ex As Exception
        End Try
    End Sub
End Class