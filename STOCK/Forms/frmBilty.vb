Imports System.Data.SqlClient
Imports System.IO
Imports LanguageSelector
Public Class frmBilty
    Dim BiltyID As Integer
    Dim EditValue As Integer
    Dim cnt As Integer
    Dim StrSearch As String
    Dim z As Integer
    Dim CityID As Integer
    Dim CityBasedID As String
    Dim Index As Boolean
    Dim a As Integer
    Dim RowCount As Integer = 0
    Private Sub frmBilty_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.MaximizeBox = False

        TC.Left = pnlcentre.Width / 2 - (TC.Width / 2)
        TC.Top = pnlcentre.Height / 2 - (TC.Height / 2)
        pnlcentre.Left = Me.Width / 2 - (pnlcentre.Width / 2)
        pnlcentre.Top = Me.Height / 2 - (pnlcentre.Height / 2)

        Module1.Opencn()
        Index = False

        Module1.DatasetFill("Select * from VuPurchaseInvoiceForBilty", "VuPurchaseInvoiceForBilty")
        cmbInvoicepurchase.DataSource = ds.Tables("VuPurchaseInvoiceForBilty")
        cmbInvoicepurchase.DisplayMember = ("InvoiceNo")
        cmbInvoicepurchase.ValueMember = ("PurchaseID")
        cmbInvoicepurchase.SelectedIndex = -1


        Module1.DatasetFill("Select * from ProductType", "ProductType")
        DGPType.DataSource = ds.Tables("ProductType")
        DGPType.DisplayMember = ("ProdTypeName")
        DGPType.ValueMember = ("ProdTypeID")

        Module1.DatasetFill("Select ProdCode,Product from VuProduct", "VuProduct")
        DGProdCode.DataSource = ds.Tables("VuProduct")
        DGProdCode.DisplayMember = ("Product")
        DGProdCode.ValueMember = ("ProdCode")

        CityID = Frm.lbLocationID.Text
        CityBasedID = Frm.lbLocationName.Text
        dtDate.Value = Now
        dtTransferDate.Value = Now
        EditValue = 1
        Fill()
        Index = True
        If Frm.GID.Text > 2 Then
            Module1.CMStatusDisable(CM)
        End If
    End Sub

#Region " FUNCTIONS .............................."

    Sub calcGrid()
        Dim TotalQty As Double = 0
        Dim a As Integer
        Try
            For a = 0 To DG.Rows.Count - 1
                TotalQty = TotalQty + Val(DG.Rows(a).Cells("DGTotalQty").Value)
            Next
            txtQtyTotal.Text = TotalQty
        Catch ex As Exception
        End Try
    End Sub

    Sub Calc()
        Try
            txtTotal.Text = Val(txtBalanceRent.Text) + Val(txtTax.Text) + Val(txtLoadUnload.Text) + Val(txtOtherExpenses.Text)
        Catch ex As Exception

        End Try
    End Sub

    Sub calcGridSearch()
        Dim TotalQty As Double = 0
        Dim a As Integer
        Try
            For a = 0 To DGSearch.Rows.Count - 1
                TotalQty = TotalQty + Val(DGSearch.Rows(a).Cells("DGQtySearch").Value)
            Next
            txtTotalQtySearch.Text = TotalQty
        Catch ex As Exception
        End Try
    End Sub

    Sub CalcSearch()
        Try
            txtTotalSearch.Text = Val(txtRentSearch.Text) + Val(txtTaxSearch.Text) + Val(txtLoadunLoadSearch.Text) + Val(txtOtherExpensesSearch.Text)
        Catch ex As Exception

        End Try
    End Sub

    Sub CMStatus()
        MnuNew.Enabled = Not MnuNew.Enabled
        MnuSave.Enabled = Not MnuSave.Enabled
        MnuUndo.Enabled = Not MnuUndo.Enabled
        MnuEdit.Enabled = Not MnuEdit.Enabled
        MnuDelete.Enabled = Not MnuDelete.Enabled
        MnuExit.Enabled = Not MnuExit.Enabled
    End Sub

    Sub CStatus()
        dtDate.Enabled = Not dtDate.Enabled
        'txtBiltyNo.ReadOnly = Not txtBiltyNo.ReadOnly
        txtVehicle.ReadOnly = Not txtVehicle.ReadOnly
        txtVehicleNo.ReadOnly = Not txtVehicleNo.ReadOnly
        dtTransferDate.Enabled = Not dtTransferDate.Enabled
        txtRent.ReadOnly = Not txtRent.ReadOnly
        txtTax.ReadOnly = Not txtTax.ReadOnly
        txtLoadUnload.ReadOnly = Not txtLoadUnload.ReadOnly
        txtOtherExpenses.ReadOnly = Not txtOtherExpenses.ReadOnly
        txtRemarks.ReadOnly = Not txtRemarks.ReadOnly
        txtAdvRent.ReadOnly = Not txtAdvRent.ReadOnly
        GB.Enabled = Not GB.Enabled
        txtDriverName.ReadOnly = Not txtDriverName.ReadOnly
    End Sub

    Sub Clear()
        lblMessage.Text = ""
        dtDate.Value = Now
        txtBiltyNo.Text = ""
        txtVehicle.Text = ""
        txtVehicleNo.Text = ""
        txtDriverName.Text = ""
        dtTransferDate.Value = Now
        txtRent.Text = ""
        txtTax.Text = ""
        txtLoadUnload.Text = ""
        txtOtherExpenses.Text = ""
        txtQtyTotal.Text = ""
        txtAdvRent.Text = ""
        txtBalanceRent.Text = ""
        txtRemarks.Text = "------"
        cmbInvoicepurchase.SelectedIndex = -1
        txtTotalQtyPurchased.Text = ""
        DG.Rows.Clear()
    End Sub

    Sub IDPicker()
        Module1.DatasetFill("Select BiltyID from BiltyMain", "BiltyMain")
        cmd.CommandText = "Select isnull(Max(BiltyID),0) from BiltyMain"
        BiltyID = cmd.ExecuteScalar + 1
    End Sub

    Sub InvoiceNoGenerator()
        Dim _m As String
        Dim _y As String
        Dim _MaxID As String
        Dim _Criteria As String
        _m = Date.Now.Month
        _y = Date.Now.Year
        _y = _y.Substring(2, 2)

        If _m.Length = 1 Then
            _m = "0" & _m
        End If
        _Criteria = "IAL-BLTY-" & _m & "-" & _y & "-"

        Try

            Dim sqldreader As SqlDataReader
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select Max(Substring(BiltyNo,16,len(BiltyNo))) from BiltyMain where BiltyNo Like('" & _Criteria & "%'" & ")"
            cmd.Connection = cn
            If cn.State = ConnectionState.Closed Then cn.Open()
            sqldreader = cmd.ExecuteReader()
            While sqldreader.Read

                If IsDBNull(sqldreader.Item(0)) = True Then
                    _MaxID = 1
                Else
                    _MaxID = Val(sqldreader.Item(0)) + 1

                End If
            End While
            sqldreader.Close()

            If _m.Length = 1 Then
                _m = "0" & _m
            End If
            If _MaxID.Length = 1 Then
                _MaxID = "0" & _MaxID
            End If
            txtBiltyNo.Text = "IAL-BLTY-" & _m & "-" & _y & "-" & _MaxID
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub SaveUpdateBilty()
        Try

            Dim cmdsave As New SqlCommand

            cmdsave.CommandType = CommandType.StoredProcedure
            cmdsave.CommandText = "InsertUpdateBiltyMain"
            cmdsave.Connection = cn

            If EditValue = 1 Then
                IDPicker()
            End If
            cmdsave.Parameters.Add("@BiltyID", SqlDbType.Int).Value = BiltyID
            cmdsave.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Me.dtDate.Value.Date.ToString
            cmdsave.Parameters.Add("@BiltyNo", SqlDbType.NVarChar).Value = Me.txtBiltyNo.Text
            cmdsave.Parameters.Add("@TransportVehicle", SqlDbType.NVarChar).Value = Me.txtVehicle.Text
            cmdsave.Parameters.Add("@DriverName", SqlDbType.NVarChar).Value = Me.txtDriverName.Text
            cmdsave.Parameters.Add("@PlateNo", SqlDbType.NVarChar).Value = Me.txtVehicleNo.Text
            cmdsave.Parameters.Add("@BiltyDate", SqlDbType.SmallDateTime).Value = Me.dtTransferDate.Value.Date.ToString
            cmdsave.Parameters.Add("@Rent", SqlDbType.Decimal).Value = Val(txtRent.Text)
            cmdsave.Parameters.Add("@Tax", SqlDbType.Decimal).Value = Val(txtTax.Text)
            cmdsave.Parameters.Add("@LoadUnload", SqlDbType.Decimal).Value = Val(txtLoadUnload.Text)
            cmdsave.Parameters.Add("@OtherExpenses", SqlDbType.Decimal).Value = Val(txtOtherExpenses.Text)
            cmdsave.Parameters.Add("@Total", SqlDbType.Decimal).Value = Val(txtTotal.Text)
            cmdsave.Parameters.Add("@AdvpaidRent", SqlDbType.Decimal).Value = Val(txtAdvRent.Text)
            cmdsave.Parameters.Add("@BalanceRent", SqlDbType.Decimal).Value = Val(txtBalanceRent.Text)
            cmdsave.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = Me.txtRemarks.Text
            cmdsave.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
            cmdsave.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & BiltyID
            cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = EditValue

            cmdsave.ExecuteNonQuery()
            cmdsave.Parameters.Clear()

            If EditValue = 1 Then
                InsertBiltyDetail()
                CMStatus()
                CStatus()
                'Fill()
                'MsgBox("THE RECORD HAS BEEN SAVED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & "ریکارد شما موفقانه ثبت گردید", MsgBoxStyle.Information)
                lblMessage.Text = "ریکارد شما موفقانه ثبت گردید"
            Else
                DeleteBilty()
                InsertBiltyDetail()
                CMStatus()
                CStatus()
                Fill()
                'MsgBox("THE RECORD HAS BEEN UPDATED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & "ریکارد شما موفقانه تنظیم گردید", MsgBoxStyle.Information)
                lblMessage.Text = "ریکارد شما موفقانه تجدید گردید"
                EditValue = 1
            End If

        Catch ex As Exception
        End Try
    End Sub

    Sub DeleteBilty()
        Dim cmdDelete As New SqlCommand
        cmdDelete.Connection = cn
        cmdDelete.Transaction = Trans
        cmdDelete.CommandType = CommandType.StoredProcedure
        cmdDelete.CommandText = "DeleteBiltyDetail"
        cmdDelete.Parameters.Add("@BiltyID", SqlDbType.Int).Value = BiltyID
        cmdDelete.ExecuteNonQuery()
    End Sub

    Sub InsertBiltyDetail()
        Try

            Dim cmdsave As New SqlCommand

            cmdsave.CommandType = CommandType.StoredProcedure
            cmdsave.CommandText = "InsertUpdateBiltyDetail"
            cmdsave.Connection = cn

            For a = 0 To DG.Rows.Count - 1

                cmdsave.Parameters.Add("@BiltyID", SqlDbType.Int).Value = BiltyID
                cmdsave.Parameters.Add("@SNO", SqlDbType.Int).Value = DG.Rows(a).Cells("DGSNO").Value
                cmdsave.Parameters.Add("@InvoiceNo", SqlDbType.NVarChar).Value = DG.Rows(a).Cells("DGInvoiceNo").Value
                cmdsave.Parameters.Add("@ProductType", SqlDbType.Int).Value = DG.Rows(a).Cells("DGpType").Value
                cmdsave.Parameters.Add("@ProductCode", SqlDbType.Int).Value = DG.Rows(a).Cells("DGProdCode").Value
                cmdsave.Parameters.Add("@Qty", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGTotalQty").Value
                cmdsave.Parameters.Add("@Description", SqlDbType.NVarChar).Value = DG.Rows(a).Cells("DGDesc").Value

                cmdsave.ExecuteNonQuery()
                cmdsave.Parameters.Clear()
            Next
        Catch ex As Exception
        End Try

    End Sub

    Sub Fill()
        Try
            cmbInvoicepurchase.SelectedIndex = -1
            txtTotalQtyPurchased.Text = ""
            lblMessage.Text = ""
            If cnt < 0 Then
                cnt = 0
            End If
            Module1.DatasetFill("Select * from VuBiltyMain", "VuBiltyMain")
            BiltyID = ds.Tables("VuBiltyMain").Rows(cnt).Item("BiltyID")
            dtDate.Value = ds.Tables("VuBiltyMain").Rows(cnt).Item("dtDate")
            txtBiltyNo.Text = ds.Tables("VuBiltyMain").Rows(cnt).Item("BiltyNo")
            txtVehicle.Text = ds.Tables("VuBiltyMain").Rows(cnt).Item("TransportVehicle")
            txtDriverName.Text = ds.Tables("VuBiltyMain").Rows(cnt).Item("DriverName")
            txtVehicleNo.Text = ds.Tables("VuBiltyMain").Rows(cnt).Item("PlateNo")
            dtTransferDate.Value = ds.Tables("VuBiltyMain").Rows(cnt).Item("BiltyDate")
            txtRent.Text = ds.Tables("VuBiltyMain").Rows(cnt).Item("Rent")
            txtTax.Text = ds.Tables("VuBiltyMain").Rows(cnt).Item("Tax")
            txtLoadUnload.Text = ds.Tables("VuBiltyMain").Rows(cnt).Item("LoadUnload")
            txtOtherExpenses.Text = ds.Tables("VuBiltyMain").Rows(cnt).Item("OtherExpenses")
            txtTotal.Text = ds.Tables("VuBiltyMain").Rows(cnt).Item("Total")
            'txtQtyTotal.Text = ds.Tables("VuBiltyMain").Rows(cnt).Item("OtherExpenses")
            txtAdvRent.Text = ds.Tables("VuBiltyMain").Rows(cnt).Item("AdvPaidRent")
            txtBalanceRent.Text = ds.Tables("VuBiltyMain").Rows(cnt).Item("BalanceRent")
            txtRemarks.Text = ds.Tables("VuBiltyMain").Rows(cnt).Item("Remarks")
            GridFill()
        Catch ex As Exception
        End Try
    End Sub

    Sub GridFill()
        Dim c As Integer
        Try
            Module1.DatasetFill("Select * from VuBiltyDetail where BiltyID = " & BiltyID & "", "VuBiltyDetail")
            DG.Rows.Clear()
            For c = 0 To ds.Tables("VuBiltyDetail").Rows.Count - 1
                DG.Rows.Add()
                DG.Rows(c).Cells("DGSNO").Value = ds.Tables("VuBiltyDetail").Rows(c).Item("SNO")
                DG.Rows(c).Cells("DgInvoiceNo").Value = ds.Tables("VuBiltyDetail").Rows(c).Item("InvoiceNo")
                DG.Rows(c).Cells("DGPType").Value = ds.Tables("VuBiltyDetail").Rows(c).Item("ProductType")
                DG.Rows(c).Cells("DGProdCode").Value = ds.Tables("VuBiltyDetail").Rows(c).Item("ProductCode")
                DG.Rows(c).Cells("DGTotalQty").Value = ds.Tables("VuBiltyDetail").Rows(c).Item("Qty")
                DG.Rows(c).Cells("DGDesc").Value = ds.Tables("VuBiltyDetail").Rows(c).Item("Description")
            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub GridFillFromPurchaseDetail()
        Try
            'If DG.Rows.Count <> 0 Then
            RowCount = DG.Rows.Count
            'End If
            Dim bb As Integer
            Module1.DatasetFill("Select * from VuPurchaseDetailForBilty where PurchaseID = " & cmbInvoicepurchase.SelectedValue & "", "VuPurchaseDetailForBilty")

            For bb = 0 To ds.Tables("VuPurchaseDetailForBilty").Rows.Count - 1
                DG.Rows.Add()
                DG.Rows(RowCount).Cells("DGPType").Value = ds.Tables("VuPurchaseDetailForBilty").Rows(bb).Item("ProdTypeID")
                DG.Rows(RowCount).Cells("DGProdCode").Value = ds.Tables("VuPurchaseDetailForBilty").Rows(bb).Item("ProdCode")
                DG.Rows(RowCount).Cells("DGTotalQty").Value = ds.Tables("VuPurchaseDetailForBilty").Rows(bb).Item("RecQty")
                DG.Rows(RowCount).Cells("DGInvoiceNo").Value = cmbInvoicepurchase.Text
                DG.Rows(RowCount).Cells("DGDesc").Value = "------"
                RowCount = RowCount + 1
            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub GridFillSearch()
        Try
            Module1.DatasetFill("Select * from VuBiltyDetailSearch where BiltyID = " & cmbSearch.SelectedValue, "VuBiltyDetailSearch")
            DGSearch.Rows.Clear()
            For z = 0 To ds.Tables("VuBiltyDetailSearch").Rows.Count - 1
                DGSearch.Rows.Add()
                DGSearch.Rows(z).Cells("DGSNOSearch").Value = ds.Tables("VuBiltyDetailSearch").Rows(z).Item("SNO")
                DGSearch.Rows(z).Cells("DGInvoiceNoSearch").Value = ds.Tables("VuBiltyDetailSearch").Rows(z).Item("InvoiceNo")
                DGSearch.Rows(z).Cells("DGPTypeSearch").Value = ds.Tables("VuBiltyDetailSearch").Rows(z).Item("ProdTypeName")
                DGSearch.Rows(z).Cells("DGProductSearch").Value = ds.Tables("VuBiltyDetailSearch").Rows(z).Item("Product")
                DGSearch.Rows(z).Cells("DGQtySearch").Value = ds.Tables("VuBiltyDetailSearch").Rows(z).Item("Qty")
                DGSearch.Rows(z).Cells("DGDescSearch").Value = ds.Tables("VuBiltyDetailSearch").Rows(z).Item("Description")
            Next

        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region " Context Menu ......................."

    Private Sub MnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuNew.Click
        Try

       
            Call CMStatus()
            Call CStatus()
            Call Clear()
            txtRent.Text = 0
            txtAdvRent.Text = 0
            txtBalanceRent.Text = 0
            txtLoadUnload.Text = 0
            txtOtherExpenses.Text = 0
            txtQtyTotal.Text = 0
            txtTax.Text = 0
            txtVehicle.Focus()
            InvoiceNoGenerator()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MnuUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuUndo.Click
        Call CMStatus()
        Call CStatus()
        Call Clear()
        Fill()
        EditValue = 1
    End Sub

    Private Sub MnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSave.Click
        If txtBiltyNo.Text = "" Or txtVehicle.Text = "" Or txtVehicleNo.Text = "" Or DG.Rows.Count = 0 Then
            MsgBox("PLEASE FILL THE REQUIRED FIELDS" & Chr(13) & " " & Chr(13) & "لطفآ خانه های ضرورت را پر کنید", MsgBoxStyle.Critical)
        Else
            SaveUpdateBilty()
        End If
    End Sub

    Private Sub MnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuEdit.Click
        CMStatus()
        CStatus()
        EditValue = 0
    End Sub

    Private Sub MnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDelete.Click
        Dim a As VariantType
        a = MsgBox("Are you Sure.?" & Chr(13) & "  " & Chr(13) & " آیا شما مطمئن هستید  ", MsgBoxStyle.YesNo)
        If a = vbYes Then
            cmd.CommandText = " Delete from BiltyMain where BiltyID = " & BiltyID
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

            'MsgBox("THE RECORD HAS BEEN DELETED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & " ریکارد مذکور موفقانه فسخ شد ", MsgBoxStyle.Information)
            If cnt = ds.Tables("VuBiltyMain").Rows.Count - 1 Then
                cnt = cnt - 1
            End If
            If cnt < 0 Then
                Clear()
            End If
            Fill()
            lblMessage.Text = "ریکارد مذکور موفقانه حذف گردید "
        End If
    End Sub

    Private Sub MnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuExit.Click
        Me.Close()
    End Sub

#End Region

#Region " Navigations ..........................."

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        cnt = 0
        Fill()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If cnt = 0 Then Exit Sub
        cnt = cnt - 1
        Fill()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If cnt = ds.Tables("VuBiltyMain").Rows.Count - 1 Then Exit Sub
        cnt = cnt + 1
        Fill()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        cnt = ds.Tables("VuBiltyMain").Rows.Count - 1
        Fill()
    End Sub

#End Region

#Region " EVENTS ........................ "

    Private Sub TC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TC.SelectedIndexChanged
        If TC.SelectedIndex = 0 Then
            CM.Enabled = True
            ToolStrip1.Enabled = True
            If MnuNew.Enabled <> True Then
                Call CMStatus()
            End If
            If txtBiltyNo.ReadOnly <> True Then
                Call CStatus()
            End If
            Call Clear()
            Call Fill()
        Else
            'chbBiltyNo.Checked = False
            DGSearch.Rows.Clear()
            'cmbSearch.SelectedIndex = -1
            CM.Enabled = False
            ToolStrip1.Enabled = False
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        ''If chbBiltyNo.Checked.Equals(True) Then
        ''    StrSearch = " Select * from VuBilty where BiltyNo = N'" & txtSearch.Text & "'"
        ''    GridFillSearch()
        ''Else
        ''StrSearch = "Select * from VuBilty where dtDate between '" & dtFrom.Value.Date.ToString & "' And '" & dtToo.Value.Date.ToString & "'"
        'GridFillSearch()
        ''End If
        Try

            Module1.DatasetFill("Select * from VuBiltyMain where BiltyID = " & cmbSearch.SelectedValue, "VuBiltyMain")
            txtVechileSearch.Text = ds.Tables("VuBiltyMain").Rows(0).Item("TransportVehicle")
            txtDriverSearch.Text = ds.Tables("VuBiltyMain").Rows(0).Item("DriverName")
            txtPlateNoSearch.Text = ds.Tables("VuBiltyMain").Rows(0).Item("PlateNo")
            dtDateSearch.Value = ds.Tables("VuBiltyMain").Rows(0).Item("BiltyDate")
            txtRentSearch.Text = ds.Tables("VuBiltyMain").Rows(0).Item("Rent")
            txtOtherExpensesSearch.Text = ds.Tables("VuBiltyMain").Rows(0).Item("OtherExpenses")
            txtTaxSearch.Text = ds.Tables("VuBiltyMain").Rows(0).Item("Tax")
            txtLoadunLoadSearch.Text = ds.Tables("VuBiltyMain").Rows(0).Item("LoadUnload")
            txtAdvRentSearch.Text = ds.Tables("VuBiltyMain").Rows(0).Item("AdvPaidRent")
            txtRemainRentSearch.Text = ds.Tables("VuBiltyMain").Rows(0).Item("BalanceRent")
            'txtTotalSearch.Text = ds.Tables("VuBiltyMain").Rows(0).Item("")
            'txtTotalQtySearch.Text = ds.Tables("VuBiltyMain").Rows(0).Item("")
            txtRemarksSearch.Text = ds.Tables("VuBiltyMain").Rows(0).Item("Remarks")
            GridFillSearch()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            If BiltyID = 0 Then
                Exit Sub
            Else
                Module1.DatasetFill("Select * from RptBiltyMain where BiltyID=" & BiltyID, "RptBiltyMain")
                Dim rpt As New RptBilty
                rpt.SetDataSource(Module1.ds.Tables("RptBiltyMain"))
                frmRptSetup.CV.ReportSource = rpt
                Frm.RptShow()
                'Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtRent_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRent.TextChanged
        Try
            txtBalanceRent.Text = Val(txtRent.Text) - Val(txtAdvRent.Text)
        Catch ex As Exception
        End Try

        Try
            Calc()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtAdvRent_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdvRent.TextChanged
        Try
            txtBalanceRent.Text = Val(txtRent.Text) - Val(txtAdvRent.Text)
            Calc()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtTax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTax.TextChanged
        Try
            Calc()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtLoadUnload_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoadUnload.TextChanged
        Try
            Calc()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtOtherExpenses_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOtherExpenses.TextChanged
        Try
            Calc()
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " KeyPress.................. "

    Private Sub txtRent_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRent.KeyPress
        If IsNumeric(sender.text & e.KeyChar) = False Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 8 Then
            e.Handled = False
        End If
    End Sub

    Private Sub txtTax_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTax.KeyPress
        If IsNumeric(sender.text & e.KeyChar) = False Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 8 Then
            e.Handled = False
        End If
    End Sub

    Private Sub txtLoadUnload_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLoadUnload.KeyPress
        If IsNumeric(sender.text & e.KeyChar) = False Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 8 Then
            e.Handled = False
        End If
    End Sub

    Private Sub txtOtherExpenses_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOtherExpenses.KeyPress
        If IsNumeric(sender.text & e.KeyChar) = False Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 8 Then
            e.Handled = False
        End If
    End Sub

    Private Sub txtBiltyNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBiltyNo.KeyPress
        If txtBiltyNo.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtVehicle_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVehicle.KeyPress
        If txtVehicle.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtVehicleNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVehicleNo.KeyPress
        If txtVehicleNo.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtRemarks_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemarks.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
        If txtRemarks.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtAdvRent_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdvRent.KeyPress
        If IsNumeric(sender.text & e.KeyChar) = False Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 8 Then
            e.Handled = False
        End If
    End Sub

#End Region

    Private Sub cmbInvoicepurchase_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbInvoicepurchase.SelectedIndexChanged
        Try
            If Index = True Then
                Module1.DatasetFill("Select * from VuQtyForBilty where PurchaseID = " & cmbInvoicepurchase.SelectedValue & " ", "VuQtyForBilty")
                txtTotalQtyPurchased.Text = ds.Tables("VuQtyForBilty").Rows(0).Item("TotalQty")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DG_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellValueChanged
        Try
            calcGrid()
        Catch ex As Exception

        End Try

        Try
            DG.CurrentRow.Cells("DGSNO").Value = DG.CurrentRow.Index + 1
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DG_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DG.RowsAdded
        Try
            DG.Rows(RowCount).Cells("DGSNO").Value = DG.Rows(RowCount).Index + 1
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

    Private Sub txtDriverName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDriverName.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub DGSearch_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DGSearch.DataError
        Try

        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGSearch_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGSearch.CellValueChanged
        Try
            calcGridSearch()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtOtherExpensesSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOtherExpensesSearch.TextChanged
        Try
            CalcSearch()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtRentSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRentSearch.TextChanged
        Try
            CalcSearch()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTaxSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTaxSearch.TextChanged
        Try
            CalcSearch()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtLoadunLoadSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoadunLoadSearch.TextChanged
        Try
            CalcSearch()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TP2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TP2.Enter

        Module1.DatasetFill("Select * from BiltyMain", "BiltyMain")
        cmbSearch.DataSource = ds.Tables("BiltyMain")
        cmbSearch.DisplayMember = ("BiltyNo")
        cmbSearch.ValueMember = ("BiltyID")

        For Each a As Control In Me.TP2.Controls
            If TypeOf a Is TextBox Then
                a.Text = ""
            End If
        Next
    End Sub

    Private Sub cmbInvoicepurchase_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbInvoicepurchase.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then

                GridFillFromPurchaseDetail()

            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbInvoicepurchase_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbInvoicepurchase.KeyPress
        If KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.English()
        End If
    End Sub

    Private Sub cmbSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbSearch.KeyPress
        If KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.English()
        End If
    End Sub

    Private Sub DG_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DG.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DG_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DG.RowsRemoved
        calcGrid()
    End Sub
End Class
