Imports System.Data.SqlClient
Imports System.IO
Imports LanguageSelector
Public Class FrmOrder
    Dim OrderID As Integer
    Dim Editvalue As Integer
    Dim cnt As Integer
    Dim Index As Boolean
    Dim DGCheck As Boolean
    Dim CurrowIndex As Integer
    Dim a As Integer
    Dim CityID As Integer
    Dim CityBasedID As String
    Dim EngOrderID As Integer ' This is used only for orderEnglishPrompt From.
    Dim NewRecordIsSaved As Boolean
    Private Sub FrmOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False

        TB1.Left = pnlcentre.Width / 2 - (TB1.Width / 2)
        TB1.Top = pnlcentre.Height / 2 - (TB1.Height / 2)
        pnlcentre.Left = Me.Width / 2 - (pnlcentre.Width / 2)
        pnlcentre.Top = Me.Height / 2 - (pnlcentre.Height / 2)

        Module1.Opencn()
        CityID = Frm.lbLocationID.Text
        CityBasedID = Frm.lbLocationName.Text
        Index = False
        DGCheck = False

        Module1.DatasetFill("Select * from OrderMain Order by OrderNo", "OrderMain")
        cmbOrderNo.DataSource = ds.Tables("OrderMain")
        cmbOrderNo.DisplayMember = "OrderNo"
        cmbOrderNo.ValueMember = "OrderID"
        If cmbOrderNo.Items.Count > 0 Then
            cmbOrderNo.SelectedIndex = -1
        End If

        Module1.DatasetFill("Select * from VuVendorForOrderMain", "VuVendorForOrderMain")
        cmbVendorForOrderMain.DataSource = ds.Tables("VuVendorForOrderMain")
        cmbVendorForOrderMain.DisplayMember = ("Name")
        cmbVendorForOrderMain.ValueMember = ("VID")
        cmbVendorForOrderMain.SelectedIndex = -1

        Module1.DatasetFill("Select * from ProductType", "ProductType")
        DGcmbPType.DataSource = ds.Tables("ProductType")
        DGcmbPType.DisplayMember = ("ProdTypeName")
        DGcmbPType.ValueMember = ("ProdTypeID")

        Module1.DatasetFill("Select * from VuProduct", "VuProduct")
        DGcmbProdName.DataSource = ds.Tables("VuProduct")
        DGcmbProdName.DisplayMember = ("Product")
        DGcmbProdName.ValueMember = ("Prodcode")

        dtOrderDate.Value = Now
        dtReqDate.Value = Now
        Call Clear()
        Call fill()
        Editvalue = 1
        Index = True
        DGCheck = True
        If FrmOrderEnglishPrompt.Visible = True Then
            FrmOrderEnglishPrompt.Close()
        End If

        MnuReturn.Visible = False
        Label2.Visible = False
        cmbOrderNoSearch.Visible = False
        Label3.Visible = False
        cmbCompanySearch.Visible = False
        If Frm.GID.Text > 2 Then
            Module1.CMStatusDisable(CM)
        End If
    End Sub

#Region " Functions "
    Sub CMStatus()
        MnuNew.Enabled = Not MnuNew.Enabled
        MnuSave.Enabled = Not MnuSave.Enabled
        MnuUndo.Enabled = Not MnuUndo.Enabled
        MnuEdit.Enabled = Not MnuEdit.Enabled
        MnuDelete.Enabled = Not MnuDelete.Enabled
        MnuSearch.Enabled = Not MnuSearch.Enabled
        'MnuExit.Enabled = Not MnuExit.Enabled
    End Sub
    Sub CStatus()
        'cmbVendorForOrderMain.Enabled = Not cmbVendorForOrderMain.Enabled
        cmbOrderNo.Enabled = Not cmbOrderNo.Enabled
        dtOrderDate.Enabled = Not dtOrderDate.Enabled
        dtReqDate.Enabled = Not dtReqDate.Enabled
        txtRemarks.ReadOnly = Not txtRemarks.ReadOnly
        'DG.ReadOnly = Not DG.ReadOnly
        ToolStrip1.Enabled = Not ToolStrip1.Enabled
    End Sub
    Sub Clear()
        lblMessage.Text = ""
        txtPersonName.Text = ""
        cmbOrderNo.Text = ""
        txtJobTilte.Text = ""
        dtOrderDate.Value = Now
        dtReqDate.Value = Now
        txtRemarks.Text = ""
        DG.Rows.Clear()
        Module1.DatasetFill("Select * from OrderMain", "OrderMain")
        cmd.CommandText = "Select isnull(Max(OrderID),0) from OrderMain"
        OrderID = cmd.ExecuteScalar + 1

    End Sub
    Private Sub NumericKeys(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If DG.CurrentCell.ColumnIndex = 5 Then
            If IsNumeric(Me.ActiveControl.Text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Then e.Handled = True
        End If
    End Sub

    Sub SaveUpdateOrderMain()
        Try

            Dim cmdsave As New SqlCommand

            cmdsave.CommandType = CommandType.StoredProcedure
            cmdsave.CommandText = "InsertUpdateOrderMain"
            cmdsave.Connection = cn

            cmdsave.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID
            cmdsave.Parameters.Add("@OrderNo", SqlDbType.NVarChar).Value = Me.cmbOrderNo.Text
            cmdsave.Parameters.Add("@CompanyID", SqlDbType.Int).Value = Me.cmbVendorForOrderMain.SelectedValue
            cmdsave.Parameters.Add("@PersonName", SqlDbType.NVarChar).Value = Me.txtPersonName.Text
            cmdsave.Parameters.Add("@JobTitle", SqlDbType.NVarChar).Value = Me.txtJobTilte.Text
            cmdsave.Parameters.Add("@OrderDate", SqlDbType.SmallDateTime).Value = Me.dtOrderDate.Value.Date.ToString
            cmdsave.Parameters.Add("@ReqDate", SqlDbType.SmallDateTime).Value = Me.dtReqDate.Value.Date.ToString
            If txtRemarks.Text.Equals("") Then
                cmdsave.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = " "
            Else
                cmdsave.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = Me.txtRemarks.Text
            End If

            cmdsave.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
            cmdsave.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & OrderID
            cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = Editvalue

            cmdsave.ExecuteNonQuery()
            cmdsave.Parameters.Clear()
          
            'If cmbOrderNo.Items.Count > 0 Then
            '    cmbOrderNo.SelectedIndex = -1
            'End If
            If Editvalue = 1 Then
                SaveUpdateOrderDetail()
                CMStatus()
                CStatus()
                'Module1.DatasetFill("Select * from OrderEnglishMain", "OrderEnglishMain")
                'cmbOrderNo.DataSource = ds.Tables("OrderEnglishMain")
                'cmbOrderNo.DisplayMember = "OrderNo"
                'cmbOrderNo.ValueMember = "OrderNo"
                NewRecordIsSaved = True

                'MsgBox("THE RECORD HAS BEEN SAVED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & "ریکارد شما موفقانه ثبت گردید", MsgBoxStyle.Information)
                lblMessage.Text = "ریکارد شما موفقانه ثبت گردید"
            Else
                DeleteOrderDetail()
                SaveUpdateOrderDetail()
                CMStatus()
                CStatus()
                fill()
                'Module1.DatasetFill("Select * from OrderEnglishMain", "OrderEnglishMain")
                'cmbOrderNo.DataSource = ds.Tables("OrderEnglishMain")
                'cmbOrderNo.DisplayMember = "OrderNo"
                'cmbOrderNo.ValueMember = "OrderNo"

                'MsgBox("THE RECORD HAS BEEN UPDATED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & "ریکارد شما موفقانه تنظیم گردید", MsgBoxStyle.Information)
                lblMessage.Text = "ریکارد شما موفقانه تجدید گردید"
                Editvalue = 1
                NewRecordIsSaved = False
            End If
            cmbOrderNo.Enabled = False 'Necessary, because on edit I changed it to disabled,so cstatus will enable it after save, but we need it to be disabled.

        Catch ex As Exception
        End Try
    End Sub
    Sub DeleteOrderDetail()
        Dim cmdDelete As New SqlCommand
        cmdDelete.Connection = cn
        cmdDelete.Transaction = Trans
        cmdDelete.CommandType = CommandType.StoredProcedure
        cmdDelete.CommandText = "DeleteOrderDetail"
        cmdDelete.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID
        cmdDelete.ExecuteNonQuery()
    End Sub
    Sub SaveUpdateOrderDetail()
        Dim cmdsaveGrid As New SqlCommand
        cmdsaveGrid.CommandType = CommandType.StoredProcedure
        cmdsaveGrid.CommandText = "InsertUpdateOrderDetail"
        cmdsaveGrid.Connection = cn
        Try
            For a = 0 To DG.Rows.Count - 2
                cmdsaveGrid.Parameters.Add("@OrderID", SqlDbType.Int)
                cmdsaveGrid.Parameters("@OrderID").Value = OrderID

                cmdsaveGrid.Parameters.Add("@SNO", SqlDbType.Int).Value = DG.Rows(a).Cells("DGSNo").Value
                cmdsaveGrid.Parameters.Add("@ProdTypeID", SqlDbType.Int).Value = DG.Rows(a).Cells("DGcmbPType").Value
                Try
                    ' I am doing all these because on editing a record it was picking string name instead of value in ProductCode.
                    Dim checkdataifstring As Decimal = Val(DG.Rows(a).Cells("DGcmbProdName").Value)
                    If checkdataifstring.Equals(0) Then
                        cmdsaveGrid.Parameters.Add("@ProdCode", SqlDbType.Int).Value = DG.Rows(a).Cells("DGProductID").Value

                    Else
                        cmdsaveGrid.Parameters.Add("@ProdCode", SqlDbType.Int).Value = Val(DG.Rows(a).Cells("DGcmbProdName").Value)

                    End If

                Catch ex As Exception

                End Try

                cmdsaveGrid.Parameters.Add("@Qty", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGQty").Value
                If DG.Rows(a).Cells("DGDescription").Value = "" Then
                    cmdsaveGrid.Parameters.Add("@ProdDescription", SqlDbType.NVarChar).Value = " "
                Else
                    cmdsaveGrid.Parameters.Add("@ProdDescription", SqlDbType.NVarChar).Value = DG.Rows(a).Cells("DGDescription").Value
                End If

                'Trans.Commit()
                cmdsaveGrid.ExecuteNonQuery()
                cmdsaveGrid.Parameters.Clear()
            Next
        Catch ex As Exception
        End Try

    End Sub
    Sub fill()
        Try
            Editvalue = 1
            If cnt < 0 Then
                cnt = 0
            End If
            lblMessage.Text = ""
            Module1.DatasetFill("Select * from VuOrderMain Order by OrderNo", "VuOrderMain")
            If ds.Tables("VuOrderMain").Rows.Count = 0 Then
                Clear()
                DG.Rows.Clear()
                Exit Sub
            End If
            If NewRecordIsSaved.Equals(True) Then
                cnt = ds.Tables("VuOrderMain").Rows.Count - 1
            End If

            OrderID = ds.Tables("VuOrderMain").Rows(cnt).Item("OrderID")
            cmbOrderNo.Text = ds.Tables("VuOrderMain").Rows(cnt).Item("OrderNo")
            cmbVendorForOrderMain.Text = ds.Tables("VuOrderMain").Rows(cnt).Item("Name")
            txtPersonName.Text = ds.Tables("VuOrderMain").Rows(cnt).Item("PersonName")
            txtJobTilte.Text = ds.Tables("VuOrderMain").Rows(cnt).Item("JobTitle")
            dtOrderDate.Value = ds.Tables("VuOrderMain").Rows(cnt).Item("OrderDate")
            dtReqDate.Value = ds.Tables("VuOrderMain").Rows(cnt).Item("ReqDate")
            txtRemarks.Text = ds.Tables("VuOrderMain").Rows(cnt).Item("Remarks")
            Call Gridfill()
        Catch ex As Exception
            'cmbVendorForOrderMain.Text = ""
            'cmbVendorForOrderMain.SelectedIndex = -1
        End Try
    End Sub
    Sub Gridfill()
        Try

            Module1.DatasetFill("Select * from VuOrderDetail where OrderId=" & OrderID & " Order by SNo", "VuOrderDetail")

            DG.Rows.Clear()
            For a = 0 To ds.Tables("VuOrderDetail").Rows.Count - 1
                Try
                    DG.Rows.Add()
                    DG.Rows(a).Cells("DGSNo").Value = ds.Tables("VuOrderDetail").Rows(a).Item("SNo")
                    DG.Rows(a).Cells("DGcmbPType").Value = ds.Tables("VuOrderDetail").Rows(a).Item("ProdTypeID")
                    DG.Rows(a).Cells("DGcmbProdName").Value = ds.Tables("VuOrderDetail").Rows(a).Item("Product")
                    DG.Rows(a).Cells("DGProductID").Value = ds.Tables("VuOrderDetail").Rows(a).Item("ProdCode")
                    DG.Rows(a).Cells("DGQty").Value = ds.Tables("VuOrderDetail").Rows(a).Item("Qty")
                    DG.Rows(a).Cells("DGDescription").Value = ds.Tables("VuOrderDetail").Rows(a).Item("ProdDescription")
                Catch ex As Exception
                End Try
            Next

        Catch ex As Exception
        End Try
    End Sub
    Sub GridfillFromEnglish()
        Try

            Module1.DatasetFill("Select * from OrderEnglishDetail where OrderId=" & cmbOrderNo.SelectedValue, "OrderEnglishDetail")

            DG.Rows.Clear()
            For a = 0 To ds.Tables("OrderEnglishDetail").Rows.Count - 1
                Try
                    DG.Rows.Add()
                    DG.Rows(a).Cells("DGSNo").Value = ds.Tables("OrderEnglishDetail").Rows(a).Item("SNo")
                    DG.Rows(a).Cells("DGcmbPType").Value = ds.Tables("OrderEnglishDetail").Rows(a).Item("ProdType")
                    DG.Rows(a).Cells("DGcmbProdName").Value = ds.Tables("OrderEnglishDetail").Rows(a).Item("ProdName")
                    DG.Rows(a).Cells("DGQty").Value = ds.Tables("OrderEnglishDetail").Rows(a).Item("Qty")
                    DG.Rows(a).Cells("DGDescription").Value = ds.Tables("OrderEnglishDetail").Rows(a).Item("ProdDescription")
                Catch ex As Exception
                End Try
            Next

        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region " Context Menu "
    Private Sub MnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuNew.Click

        If MnuSearch.Visible = False Then
            MnuReturn.Visible = False
            Label2.Visible = False
            cmbOrderNoSearch.Visible = False
            Label3.Visible = False
            cmbCompanySearch.Visible = False
            MnuSearch.Visible = True
        End If

        Call CMStatus()
        Call CStatus()
        Call Clear()
        cmbVendorForOrderMain.SelectedIndex = -1

        Module1.DatasetFill("Select * from OrderEnglishMain where OrderNo Not In(Select OrderNo From OrderMain)", "OrderEnglishMain")
        cmbOrderNo.DataSource = ds.Tables("OrderEnglishMain")
        cmbOrderNo.DisplayMember = "OrderNo"
        cmbOrderNo.ValueMember = "OrderID"
        If cmbOrderNo.Items.Count > 0 Then
            cmbOrderNo.SelectedIndex = -1
        End If
        If FrmOrderEnglishPrompt.Visible = True Then
            FrmOrderEnglishPrompt.Close()
        End If

    End Sub
    Private Sub MnuUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuUndo.Click
        Call CMStatus()
        Call CStatus()

        cmbOrderNo.Enabled = False
        cmbVendorForOrderMain.Enabled = False
        If cmbOrderNo.DataSource.Equals(ds.Tables("OrderMain")) Then
            ' If only edit is clicked and then undo..then do nothing
        Else

            'else if edit not but add was clicked and then undo is clicked, then fill the combo from this table.
            Module1.DatasetFill("Select * from OrderMain", "OrderMain")
            cmbOrderNo.DataSource = ds.Tables("OrderMain")
            cmbOrderNo.DisplayMember = "OrderNo"
            cmbOrderNo.ValueMember = "OrderID"
        End If
        If cmbOrderNo.Items.Count > 0 Then
            cmbOrderNo.SelectedIndex = -1
        End If
        NewRecordIsSaved = False
        Call fill()
        If FrmOrderEnglishPrompt.Visible = True Then
            FrmOrderEnglishPrompt.Close()
        End If
    End Sub
    Private Sub MnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSave.Click
        If cmbOrderNo.SelectedIndex = -1 Then Exit Sub
        SaveUpdateOrderMain()
        cmbOrderNo.Enabled = False
        cmbVendorForOrderMain.Enabled = False

        If FrmOrderEnglishPrompt.Visible = True Then
            FrmOrderEnglishPrompt.Close()
        End If
    End Sub
    Private Sub MnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuEdit.Click

        If MnuSearch.Visible = False Then
            MnuReturn.Visible = False
            Label2.Visible = False
            cmbOrderNoSearch.Visible = False
            Label3.Visible = False
            cmbCompanySearch.Visible = False
            MnuSearch.Visible = True
        End If

        CMStatus()
        CStatus()
        cmbOrderNo.Enabled = False
        cmbVendorForOrderMain.Enabled = False
        Editvalue = 0
    End Sub
    Private Sub MnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDelete.Click
        Dim a As VariantType
        a = MsgBox("Are you Sure.?" & Chr(13) & "  " & Chr(13) & " آیا شما مطمئن هستید  ", MsgBoxStyle.YesNo)
        If a = vbYes Then
            cmd.CommandText = " Delete from OrderMain where OrderID = " & OrderID
            cmd.Connection = cn
            cmd.ExecuteNonQuery()
            'MsgBox("THE RECORD HAS BEEN DELETED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & " ریکارد مذکور موفقانه فسخ شد ", MsgBoxStyle.Information)
            If cnt = ds.Tables("VuOrderMain").Rows.Count - 1 Then
                cnt = cnt - 1
            End If
            If cnt < 0 Then
                Clear()
            End If
            Call fill()
            lblMessage.Text = "ریکارد مذکور موفقانه حذف گردید "

            If MnuSearch.Visible = False Then
                MnuReturn.Visible = False
                Label2.Visible = False
                cmbOrderNoSearch.Visible = False
                Label3.Visible = False
                cmbCompanySearch.Visible = False
                MnuSearch.Visible = True
            End If
        End If
    End Sub
    Private Sub MnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuExit.Click
        FrmOrderEnglishPrompt.Close()
        Me.Close()
    End Sub
#End Region

#Region " Navigations "
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        cnt = 0
        NewRecordIsSaved = False
        Call fill()
    End Sub
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If cnt = 0 Then Exit Sub
        cnt = cnt - 1
        NewRecordIsSaved = False
        Call fill()
    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If cnt = ds.Tables("VuOrderMain").Rows.Count - 1 Then Exit Sub
        cnt = cnt + 1
        NewRecordIsSaved = False
        Call fill()
    End Sub
    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        cnt = ds.Tables("VuOrderMain").Rows.Count - 1
        NewRecordIsSaved = False
        Call fill()
    End Sub
#End Region

#Region " Data Grid View "

    Private Sub DG_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DG.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub

 
#End Region

#Region " KeyPress "
   

    Private Sub cmbOrderNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbOrderNo.KeyPress
        If cmbOrderNo.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtRemarks_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemarks.KeyPress
        If txtRemarks.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
    End Sub
#End Region


    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            If OrderID = 0 Then
                Exit Sub
            Else
                Module1.DatasetFill("Select * from RptVuOrderMain where OrderID=" & OrderID, "RptVuOrderMain")
                Dim rpt As New RptOrder
                rpt.SetDataSource(Module1.ds.Tables("RptVuOrderMain"))
                frmRptSetup.CV.ReportSource = rpt
                Frm.RptShow()
                'Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbOrderNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOrderNo.SelectedIndexChanged

        Try
            Module1.DatasetFill("Select * from VuOrderEnglishMain where OrderNo ='" & cmbOrderNo.Text & "'", "VuOrderEnglishMain")
            cmbVendorForOrderMain.Text = ds.Tables("VuOrderEnglishMain").Rows(0).Item("Name")
            txtPersonName.Text = ds.Tables("VuOrderEnglishMain").Rows(0).Item("PersonName")
            txtJobTilte.Text = ds.Tables("VuOrderEnglishMain").Rows(0).Item("JobTitle")

            EngOrderID = ds.Tables("VuOrderEnglishMain").Rows(0).Item("OrderID")
            dtOrderDate.Value = ds.Tables("VuOrderEnglishMain").Rows(0).Item("OrderDate")
            dtReqDate.Value = ds.Tables("VuOrderEnglishMain").Rows(0).Item("ReqDate")
        Catch ex As Exception

        End Try
        If cmbOrderNo.Enabled = True Then
            GridfillFromEnglish()
            'FrmOrderEnglishPrompt.Show()
            'FrmOrderEnglishPrompt.BringToFront()
            'FrmOrderEnglishPrompt.TopMost = True
            'FrmOrderEnglishPrompt.MdiParent = Frm
            'FillPromptedForm()

        End If
    End Sub

    Sub FillPromptedForm()

        Try

            Module1.DatasetFill("Select * from VuOrderEnglishDetailForPrompt where OrderID =" & EngOrderID, "VuOrderEnglishDetailForPrompt")

            FrmOrderEnglishPrompt.DG.Rows.Clear()
            For a = 0 To ds.Tables("VuOrderEnglishDetailForPrompt").Rows.Count - 1
                Try
                    FrmOrderEnglishPrompt.DG.Rows.Add()
                    FrmOrderEnglishPrompt.DG.Rows(a).Cells("DGSNo").Value = ds.Tables("VuOrderEnglishDetailForPrompt").Rows(a).Item("SNo")
                    FrmOrderEnglishPrompt.DG.Rows(a).Cells("DGPType").Value = ds.Tables("VuOrderEnglishDetailForPrompt").Rows(a).Item("ProdTypeName")
                    FrmOrderEnglishPrompt.DG.Rows(a).Cells("DGProductName").Value = ds.Tables("VuOrderEnglishDetailForPrompt").Rows(a).Item("Product")
                    FrmOrderEnglishPrompt.DG.Rows(a).Cells("DGQty").Value = ds.Tables("VuOrderEnglishDetailForPrompt").Rows(a).Item("Qty")
                    FrmOrderEnglishPrompt.DG.Rows(a).Cells("DGDecription").Value = ds.Tables("VuOrderEnglishDetailForPrompt").Rows(a).Item("ProdDescription")

                Catch ex As Exception
                End Try
            Next

        Catch ex As Exception
        End Try

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

    Private Sub MnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSearch.Click
        Try
            Module1.DatasetFill("Select VID,Name from Vendor", "Vendor")
            cmbCompanySearch.DataSource = ds.Tables("Vendor")
            cmbCompanySearch.DisplayMember = ("Name")
            cmbCompanySearch.ValueMember = ("VID")
            'cmbOrderNoSearch.SelectedIndex = -1

            Clear()
            cmbOrderNo.SelectedIndex = -1
            cmbVendorForOrderMain.SelectedIndex = -1

            Label2.Visible = True
            cmbOrderNoSearch.Visible = True
            Label3.Visible = True
            cmbCompanySearch.Visible = True

            MnuReturn.Visible = True
            MnuSearch.Visible = False

        Catch ex As Exception

        End Try
    End Sub

    Private Sub MnuReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuReturn.Click
        If DG.Rows.Count = 1 And cmbOrderNo.Text = "" Then
            fill()
        End If

        Label2.Visible = False
        cmbOrderNoSearch.Visible = False
        Label3.Visible = False
        cmbCompanySearch.Visible = False

        MnuSearch.Visible = True
        MnuReturn.Visible = False
    End Sub

    Private Sub cmbOrderNoSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbOrderNoSearch.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then

                Dim Var_numberOfOccurance As Integer = 0
                Dim Var_PostionFound As Integer = 0
                Dim Var_loopLength As Integer = 0
                Dim Var_LetAssignment As Boolean = True
                For Each dtr As DataRow In ds.Tables("VuOrderMain").Rows
                    If cmbOrderNoSearch.SelectedValue = dtr("OrderID") Then
                        Var_numberOfOccurance += 1

                    Else

                    End If
                    If Var_numberOfOccurance = 1 And Var_LetAssignment = True Then
                        Var_PostionFound = Var_loopLength
                        Var_LetAssignment = False
                    End If
                    Var_loopLength += 1
                Next
                If Var_numberOfOccurance = 0 Then
                    txtclear(Me, pnlcentre, TB1, TP1)
                    'Module1.GetMax("SocialDataID", "SocialData")
                    'lblRecNo.Text = Module1.MaxID
                    'CStatusDefault()
                    MnuEdit.Enabled = False
                    MnuNew.Enabled = True

                    Exit Sub
                Else
                    cnt = Var_PostionFound

                    ' Module1.DatasetFill("Select * from VuOrderMain where OrderID=" & cmbOrderNoSearch.SelectedValue, "VuOrderMain")
                    If ds.Tables("VuOrderMain").Rows.Count = 0 Then
                        Clear()
                        DG.Rows.Clear()
                        Exit Sub
                    End If
                    'If NewRecordIsSaved.Equals(True) Then
                    '    cnt = ds.Tables("VuOrderMain").Rows.Count - 1
                    'End If
                    OrderID = ds.Tables("VuOrderMain").Rows(cnt).Item("OrderID")
                    cmbOrderNo.Text = ds.Tables("VuOrderMain").Rows(cnt).Item("OrderNo")
                    cmbVendorForOrderMain.Text = ds.Tables("VuOrderMain").Rows(cnt).Item("Name")
                    txtPersonName.Text = ds.Tables("VuOrderMain").Rows(cnt).Item("PersonName")
                    txtJobTilte.Text = ds.Tables("VuOrderMain").Rows(cnt).Item("JobTitle")
                    dtOrderDate.Value = ds.Tables("VuOrderMain").Rows(cnt).Item("OrderDate")
                    dtReqDate.Value = ds.Tables("VuOrderMain").Rows(cnt).Item("ReqDate")
                    txtRemarks.Text = ds.Tables("VuOrderMain").Rows(cnt).Item("Remarks")
                    Call Gridfill()

                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbOrderNoSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbOrderNoSearch.KeyPress
        If KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.English()
        End If
    End Sub

    Private Sub cmbCompanySearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCompanySearch.SelectedIndexChanged
        Try
            Module1.DatasetFill("Select * from VuOrderNoForSearch where CompanyID=" & cmbCompanySearch.SelectedValue, "VuOrderNoForSearch")
            cmbOrderNoSearch.DataSource = ds.Tables("VuOrderNoForSearch")
            cmbOrderNoSearch.DisplayMember = ("OrderNo")
            cmbOrderNoSearch.ValueMember = ("OrderId")
        Catch ex As Exception
        End Try
    End Sub
End Class