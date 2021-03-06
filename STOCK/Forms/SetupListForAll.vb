Public Class SetupListForAll

    Dim a As Integer
    Dim SubstringOfTableName As String
    Dim m As String
    Dim n As String
    Dim o As String
    Dim p As String
    Dim NameOfTableFormCriteria As String
    Dim QueryOfThem As String
    Dim _VarNameOfTable
    Dim _VarPrimeryKey
    Public Var_AlreadyDisplayed As Boolean


    Public Obj As Object

    Private Sub SetupListForAll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Var_AlreadyDisplayed.Equals(True) Then
            Exit Sub
        Else
            Var_AlreadyDisplayed = True
        End If
        Me.DG.AllowUserToAddRows = False
        Me.Left = Frm.Left
        Me.Top = Frm.Top
        ' Me.Parent = NPIW



    End Sub
    Public Sub GridFill(ByVal QueryToUse As String, ByVal NameOfTable As String)
        _VarNameOfTable = NameOfTable
        NameOfTableFormCriteria = NameOfTable
        QueryOfThem = QueryToUse
        DG.Columns.Clear()
        SubstringOfTableName = NameOfTable
        'DG.Columns.Add("DGID", "ID")
        'DG.Columns.Add("DGName", NameOfTable)
        DG.Columns.Add("Sno", "شماره")
        If NameOfTable = "CustomerType" Then
            DG.Columns.Add("DGName", "نوع مشتری")
        ElseIf NameOfTable = "Weight" Then
            DG.Columns.Add("DGName", "انواع اوزان یا  Weight Types  ")
        End If
        Dim DGChkbox As New DataGridViewCheckBoxColumn
        DGChkbox.HeaderText = "حذف"
        DG.Columns.Add(DGChkbox)
        DG.Columns(0).Width = 50
        DG.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DG.Columns(1).Width = 200
        If NameOfTable = "CustomerType" Then
            DG.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        ElseIf NameOfTable = "Weight" Then
            DG.RightToLeft = Windows.Forms.RightToLeft.No
            DG.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If

        'DG.ColumnCount
        DG.Columns(1).Width = 150
        DG.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DG.Columns(0).ReadOnly = True
        DG.Columns(1).ReadOnly = True
        DG.RowHeadersVisible = False
        Module1.DatasetFill(QueryToUse, NameOfTable)
        If Module1.ds.Tables(NameOfTable).Rows.Count = 0 Then Exit Sub
        For a = 0 To ds.Tables(NameOfTable).Rows.Count - 1
            DG.Rows.Add()
            DG.Rows(a).Cells(0).Value = ds.Tables(NameOfTable).Rows(a).Item(0)
            DG.Rows(a).Cells(1).Value = ds.Tables(NameOfTable).Rows(a).Item(1)
        Next
        If NameOfTable = "CustomerType" Then

            DG.Rows(0).Cells(2).ReadOnly = True
            DG.Rows(1).Cells(2).ReadOnly = True
            DG.Rows(2).Cells(2).ReadOnly = True

        End If
    End Sub
    Public Sub GridFill2(ByVal QueryToUse As String, ByVal NameOfTable As String)
        _VarNameOfTable = NameOfTable
        NameOfTableFormCriteria = NameOfTable
        QueryOfThem = QueryToUse
        DG.Columns.Clear()
        SubstringOfTableName = NameOfTable
        'DG.Columns.Add("DGID", "ID")
        'DG.Columns.Add("DGName", NameOfTable)
        'DG.Columns.Add("DGName", NameOfTable)
        DG.Columns.Add("Sno", "شماره")
        DG.Columns.Add("DGName", "نوع محصول")
        DG.Columns.Add("DGName", "Product Type")
        Dim DGChkbox As New DataGridViewCheckBoxColumn
        DGChkbox.HeaderText = "حذف"
        DG.Columns.Add(DGChkbox)
        DG.Columns(0).Width = 50
        DG.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DG.Columns(1).Width = 150
        DG.Columns(2).Width = 150
        DG.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DG.Columns(3).Width = 50
        DG.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DG.RowHeadersVisible = False
        DG.Columns(0).ReadOnly = True
        DG.Columns(1).ReadOnly = True
        DG.Columns(2).ReadOnly = True

        Module1.DatasetFill(QueryToUse, NameOfTable)

        For a = 0 To ds.Tables(NameOfTable).Rows.Count - 1
            DG.Rows.Add()
            DG.Rows(a).Cells(0).Value = ds.Tables(NameOfTable).Rows(a).Item(0)
            DG.Rows(a).Cells(1).Value = ds.Tables(NameOfTable).Rows(a).Item(1)
            DG.Rows(a).Cells(2).Value = ds.Tables(NameOfTable).Rows(a).Item(2)
        Next
        If NameOfTable = "CustomerType" Then

            DG.Rows(0).Cells(2).ReadOnly = True
            DG.Rows(1).Cells(2).ReadOnly = True
            DG.Rows(2).Cells(2).ReadOnly = True

        End If
    End Sub
    Public Sub GridFill3(ByVal QueryToUse As String, ByVal NameOfTable As String, ByVal Relation As String, ByVal FieldToBeDisplayed As String)
        _VarNameOfTable = NameOfTable
        NameOfTableFormCriteria = NameOfTable
        m = QueryToUse
        n = NameOfTable
        o = Relation
        p = FieldToBeDisplayed
        SubstringOfTableName = NameOfTable.Substring(2)
        Module1.DatasetFill(QueryToUse, NameOfTable)
        DG.Columns.Clear()
        Dim fahim As Integer
        For Each dtrow As DataRow In ds.Tables(NameOfTable).Rows
            fahim = fahim + 1
            dtrow.Item(0) = fahim
        Next
        DG.DataSource = Nothing
        DG.DataSource = ds.Tables(NameOfTable)
        DG.RowHeadersVisible = False
        If NameOfTable Is "VuCustomerForSetupList" Then
            Me.Width = 700
            DG.Width = 700
            If DG.Columns.Count.Equals(9) Then
                Dim DGChkbox As New DataGridViewCheckBoxColumn
                DGChkbox.HeaderText = "Delete all"
                DG.Columns.Add(DGChkbox)
                DG.RowHeadersVisible = False
            End If
            For Each dgcol As DataGridViewColumn In DG.Columns
                If dgcol.Name = "CustomerID" Then
                    dgcol.Visible = False
                End If
            Next
        Else
            Me.Width = 700
            DG.Width = 700
            If DG.Columns.Count.Equals(10) Then
                Dim DGChkbox As New DataGridViewCheckBoxColumn
                DGChkbox.HeaderText = "Delete all"
                DG.Columns.Add(DGChkbox)
                DG.RowHeadersVisible = False
            End If
            For Each dgcol As DataGridViewColumn In DG.Columns
                ' DG.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                If dgcol.Name = "نوع" Or dgcol.Name = "محصول" Then
                    'note : it is inverse...left is for farsi and right is for english...this is because of the grid layout
                    dgcol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                ElseIf dgcol.Name = "شماره" Then
                    dgcol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Else
                    dgcol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
            Next
            DG.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
    End Sub
  
    Private Sub DG_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DG.KeyDown

        If e.KeyCode = Keys.Space Then
            Dim ee As KeyPressEventArgs
            DelegateCellData(DG, ee)
        End If
        If e.KeyCode = 46 Then
            Deleter()
            '  MsgBox(e.KeyCode)
        End If
    End Sub
    Sub CheckTableName()
        If NameOfTableFormCriteria = "ProductType" Then
            _VarPrimeryKey = "ProdTypeID"
        ElseIf NameOfTableFormCriteria = "VuProduct" Then
            _VarPrimeryKey = "ProdCode"
        ElseIf NameOfTableFormCriteria = "CustomerType" Then
            _VarPrimeryKey = "CustomerTypeID"
        ElseIf NameOfTableFormCriteria = "VuCustomerForSetupList" Then
            _VarPrimeryKey = "CustomerID"
        ElseIf NameOfTableFormCriteria = "Weight" Then
            _VarPrimeryKey = "WeightID"
        End If
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal ee As System.EventArgs)
        'Dim e As System.Windows.Forms.DataGridViewCellMouseEventArgs

        'DG_ColumnHeaderMouseClick(DG, e)
        For Each column As DataGridViewColumn In DG.Columns
            If column.Name = "" Then
                For Each row As DataGridViewRow In DG.Rows
                    'DG.Rows(s).Cells(3).Value = True
                    If DG.Columns.Count = 3 Then
                        row.Cells(2).Value = True
                    ElseIf DG.Columns.Count = 4 Then
                        row.Cells(3).Value = True
                    ElseIf DG.Columns.Count = 11 Then
                        row.Cells(10).Value = True

                    End If

                    ' s = s + 1
                Next
            End If
        Next
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Deleter()
    End Sub
    Sub Deleter()
        Dim checkSelectAll As Integer = 0
        For Each column As DataGridViewColumn In DG.Columns
            If column.Name = "" Then
                For Each row As DataGridViewRow In DG.Rows
                    'DG.Rows(s).Cells(3).Value = True
                    If DG.Columns.Count = 3 Then
                        If row.Cells(2).Value = True Then
                            checkSelectAll = checkSelectAll + 1
                        End If
                    End If

                    If DG.Columns.Count = 4 Then
                        If row.Cells(3).Value = True Then
                            checkSelectAll = checkSelectAll + 1
                        End If
                    End If


                    If DG.Columns.Count = 11 Then
                        If row.Cells(0).Value = True Then
                            checkSelectAll = checkSelectAll + 1
                        End If
                    End If
                    If DG.Columns.Count = 10 Then
                        If row.Cells("").Value = True Then
                            checkSelectAll = checkSelectAll + 1
                        End If
                    End If


                    ' s = s + 1
                Next
            End If
        Next

        If checkSelectAll = 0 Then Exit Sub

        Dim s As Integer
        Dim t As Integer
        s = 0
        t = 0


        If DG.Columns.Count.Equals(4) Then
            If (MessageBox.Show(" All data will be lost " & Chr(13) & " Are you still going to delete them? ", "Last Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then

                For Each row As DataGridViewRow In DG.Rows
                    Try
                        t = DG.Rows(s).Cells(0).Value
                        ' MsgBox(DG.Rows(s).Cells(2).Value)
                        If DG.Rows(s).Cells(3).Value.Equals(True) Then

                            Dim x As String
                            Call CheckTableName()
                            x = _VarPrimeryKey & "=" & t
                            'Its just because I didn't take it UnionCouncilID


                            Module1.DeleteRecord(SubstringOfTableName, x)
                            ' here delete all records of related ProductType if any type is being deleted
                            If NameOfTableFormCriteria = "ProductType" Then
                                Module1.DeleteRecord("Product", x)
                            End If
                            If NameOfTableFormCriteria = "CustomerType" Then
                                Module1.DeleteRecord("Customer", x)
                            End If

                        Else

                            ' MsgBox("Record with ID " & t & " is not selected")
                        End If
                        s = s + 1
                    Catch ex As Exception
                        ' MsgBox("Record with ID " & t & " is not selected")
                        s = s + 1
                    End Try
                Next

                Call GridFill2(QueryOfThem, NameOfTableFormCriteria)
                'Call GridFill2(m, n)
            Else
            End If ' of confirmation
        ElseIf DG.Columns.Count.Equals(3) Then ' The following code is then for the grid of District,WaterSource and Lining Type.
            '    End If
            'Else

            If (MessageBox.Show(" All data will be lost " & Chr(13) & " Are you still going to delete them? ", "Last Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then


                For Each row As DataGridViewRow In DG.Rows
                    Try
                        t = DG.Rows(s).Cells(0).Value
                        ' MsgBox(DG.Rows(s).Cells(2).Value)
                        If DG.Rows(s).Cells(2).Value.Equals(True) Then

                            Dim x As String
                            Call CheckTableName()
                            x = _VarPrimeryKey & "=" & t
                            'Its just because I didn't take it UnionCouncilID

                            Module1.DeleteRecord(NameOfTableFormCriteria, x)
                            ' here delete all records of related ProductType if any type is being deleted
                            If NameOfTableFormCriteria = "ProductType" Then
                                Module1.DeleteRecord("Product", x)
                            End If
                            If NameOfTableFormCriteria = "CustomerType" Then
                                Module1.DeleteRecord("Customer", x)
                            End If
                        Else

                            ' MsgBox("Record with ID " & t & " is not selected")
                        End If
                        s = s + 1
                    Catch ex As Exception
                        ' MsgBox("Record with ID " & t & " is not selected")
                        s = s + 1
                    End Try
                Next
                Call GridFill(QueryOfThem, NameOfTableFormCriteria)
            Else

            End If




        ElseIf DG.Columns.Count.Equals(11) Then
            If (MessageBox.Show(" All data will be lost " & Chr(13) & " Are you still going to delete them? ", "Last Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then

                For Each row As DataGridViewRow In DG.Rows
                    Try
                        t = DG.Rows(s).Cells(1).Value
                        ' MsgBox(DG.Rows(s).Cells(2).Value)
                        If DG.Rows(s).Cells(0).Value.Equals(True) Then

                            Dim x As String
                            Call CheckTableName()
                            x = _VarPrimeryKey & "=" & t
                            'Its just because I didn't take it UnionCouncilID


                            Module1.DeleteRecord(SubstringOfTableName, x)
                        

                        Else

                            ' MsgBox("Record with ID " & t & " is not selected")
                        End If
                        s = s + 1
                    Catch ex As Exception
                        ' MsgBox("Record with ID " & t & " is not selected")
                        s = s + 1
                    End Try
                Next

                Call GridFill3(m, n, o, p)
            Else
            End If
        ElseIf DG.Columns.Count.Equals(10) Then
            If (MessageBox.Show(" All data will be lost " & Chr(13) & " Are you still going to delete them? ", "Last Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then

                For Each row As DataGridViewRow In DG.Rows
                    Try
                        t = DG.Rows(s).Cells("CustomerID").Value
                        ' MsgBox(DG.Rows(s).Cells(2).Value)
                        If DG.Rows(s).Cells(0).Value.Equals(True) Then

                            Dim x As String
                            Call CheckTableName()
                            x = _VarPrimeryKey & "=" & t
                            'Its just because I didn't take it UnionCouncilID


                            Module1.DeleteRecord("Customer", x)

                         

                        Else

                            ' MsgBox("Record with ID " & t & " is not selected")
                        End If
                        s = s + 1
                    Catch ex As Exception
                        ' MsgBox("Record with ID " & t & " is not selected")
                        s = s + 1
                    End Try
                Next

                Call GridFill3(m, n, o, p)
            Else
            End If
        End If


    End Sub
    Private Sub DelegateCellData(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "" Then
            Me.DG.CurrentCell.Value = True 'Me.ActiveControl.Text & e.KeyChar
        End If
    End Sub

    Private Sub DG_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellClick
        If DG.Columns(1).HeaderText = "نوع مشتری" Then
            If DG.CurrentCell.RowIndex = 0 Or DG.CurrentCell.RowIndex = 1 Or DG.CurrentCell.RowIndex = 2 Then
                Exit Sub
            End If
        End If
        If Not DG.CurrentCell.GetEditedFormattedValue(DG.CurrentRow.Index, DataGridViewDataErrorContexts.Commit).Equals("") Then
            Dim ee As KeyPressEventArgs
            DelegateCellData(DG, ee)
        Else
        End If
        Me.TopMost = True
        Me.BringToFront()
    End Sub

    Private Sub chkCheckAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCheckAll.CheckedChanged
        If chkCheckAll.Checked.Equals(True) Then


            For Each column As DataGridViewColumn In DG.Columns
                If column.Name = "" Then
                    For Each row As DataGridViewRow In DG.Rows
                        'DG.Rows(s).Cells(3).Value = True
                        If DG.Columns.Count = 3 Then
                            row.Cells(2).Value = True
                            If DG.Columns(1).HeaderText = "نوع مشتری" Then


                                If row.Index = 0 Or row.Index = 1 Or row.Index = 2 Then
                                    row.Cells(2).Value = False
                                End If
                            End If

                        ElseIf DG.Columns.Count = 4 Then
                            row.Cells(3).Value = True
                        ElseIf DG.Columns.Count = 10 Then
                            'of customer
                            row.Cells("").Value = True
                        ElseIf DG.Columns.Count = 11 Then
                            For Each columns As DataGridViewColumn In DG.Columns
                                'If columns.Name = "" Then
                                '    MsgBox(columns.Index)
                                'End If
                                'Note when u assign datasource to a datagrid and then add another column to it, then its index will become 0. as here checkbox column has become.
                            Next
                            row.Cells("").Value = True
                        End If

                        ' s = s + 1
                    Next
                End If
            Next
 

        Else
            For Each column As DataGridViewColumn In DG.Columns
                If column.Name = "" Then
                    For Each row As DataGridViewRow In DG.Rows
                        'DG.Rows(s).Cells(3).Value = True
                        If DG.Columns.Count = 3 Then
                            row.Cells(2).Value = False
                        ElseIf DG.Columns.Count = 4 Then
                            row.Cells(3).Value = False
                        ElseIf DG.Columns.Count = 10 Then 'of product
                            row.Cells("").Value = False
                        ElseIf DG.Columns.Count = 11 Then ' of Customer
                            row.Cells("").Value = False
                        End If

                        ' s = s + 1
                    Next
                End If
            Next

        End If
    End Sub

    Private Sub DG_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DG.DataError
        Try


        Catch ex As Exception

        End Try
    End Sub

    Private Sub SetupListForAll_MinimumSizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.MinimumSizeChanged

    End Sub

    Private Sub SetupListForAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        Me.TopMost = True
        Me.BringToFront()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Me.TopMost = True
        Me.BringToFront()
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Me.TopMost = True
        Me.BringToFront()
    End Sub

    Private Sub SetupListForAll_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Var_AlreadyDisplayed = False
    End Sub
End Class