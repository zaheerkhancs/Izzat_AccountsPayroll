Imports System.Data.SqlClient
Imports System.IO
Imports LanguageSelector
Public Class FrmSaleOfSaleman
    Dim Index As Boolean
    Dim IndexforShop As Boolean
    Dim CurrowIndex As Integer
    Dim azizkhanqarabaghi As Boolean
    Dim cnt As Integer
    Dim EditValue As Integer
    Public SaleIDOfSaleMan As Integer
    Dim CityID As Integer
    Dim CityBasedID As String
    Dim Var_ExpDate As DateTime
    Dim Var_ManDate As DateTime
    Dim a As Integer
    Dim SalInvoiceNo As String
    Dim AddEdit As Boolean

    Private Sub FrmSaleOfSaleman_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        TB1.Left = pnlcentre.Width / 2 - (TB1.Width / 2)
        TB1.Top = pnlcentre.Height / 2 - (TB1.Height / 2)
        pnlcentre.Left = Me.Width / 2 - (pnlcentre.Width / 2)
        pnlcentre.Top = Me.Height / 2 - (pnlcentre.Height / 2)

        Module1.Opencn()
        CityID = Frm.lbLocationID.Text
        CityBasedID = Frm.lbLocationName.Text
        Index = False
        IndexforShop = False
        azizkhanqarabaghi = False
        Module1.DatasetFill("Select * from Customer Where CustomerTypeID = 1", "Customer")
        cmbCustomerName.DataSource = ds.Tables("Customer")
        cmbCustomerName.DisplayMember = ("CustomerName")
        cmbCustomerName.ValueMember = ("CustomerID")

        Module1.DatasetFill("Select * from PaymentType ", "PaymentType")
        cmbPaymentType.DataSource = ds.Tables("PaymentType")
        cmbPaymentType.DisplayMember = ("PaymentTypeName")
        cmbPaymentType.ValueMember = ("PaymentTypeID")

        Module1.DatasetFill("Select * from Location", "Location")
        cmbLocation.DataSource = ds.Tables("Location")
        cmbLocation.DisplayMember = ("LocName")
        cmbLocation.ValueMember = ("LocID")
        cmbLocation.SelectedIndex = -1

        Module1.DatasetFill("Select * from ProductType", "ProductType")
        DGPType.DataSource = ds.Tables("ProductType")
        DGPType.DisplayMember = ("ProdTypeName")
        DGPType.ValueMember = ("ProdTypeID")

        Module1.DatasetFill("Select * from CartonPiece", "CartonPiece")
        DGCrtnPcs.DataSource = ds.Tables("CartonPiece")
        DGCrtnPcs.DisplayMember = ("Name")
        DGCrtnPcs.ValueMember = ("ID")

        Module1.DatasetFill("Select * from VuCustomerForSearch Where CustomerTypeID = 1", "VuCustomerForSearch")
        cmbCustomerSearch.DataSource = ds.Tables("VuCustomerForSearch")
        cmbCustomerSearch.DisplayMember = ("CustomerName")
        cmbCustomerSearch.ValueMember = ("CustomerID")


        Module1.DatasetFill("Select * from Shop", "Shop")
        cmbShopKeeper.DataSource = ds.Tables("Shop")
        cmbShopKeeper.DisplayMember = ("ShopName")
        cmbShopKeeper.ValueMember = ("ShopID")


        EditValue = 1
        Index = True
        azizkhanqarabaghi = True
        FillAllTXT()
        If Frm.GID.Text = 1 Then
            MnuEdit.Visible = True
        ElseIf Frm.GID.Text = 2 Then
            MnuEdit.Visible = False
        Else
            Module1.CMStatusDisable(CM)
        End If
    End Sub

#Region "FUCTIONS"

    Sub CMStatus()
        MnuNew.Enabled = Not MnuNew.Enabled
        MnuSave.Enabled = Not MnuSave.Enabled
        MnuUndo.Enabled = Not MnuUndo.Enabled
        MnuEdit.Enabled = Not MnuEdit.Enabled
        MnuDelete.Enabled = Not MnuDelete.Enabled
        MnuExit.Enabled = Not MnuExit.Enabled
    End Sub

    Sub GridFillForPrice()
        Try
            Module1.DatasetFill("Select PcsInCtrn,SalMobileCrtn,SalMobilePcs from VuProductPrices where ProdTypeID = " & DG.CurrentRow.Cells("DGPType").Value & " and ProdCode =" & DG.CurrentRow.Cells("DGColProductID").Value & "", "VuProductPrices")
            DG.CurrentRow.Cells("DGPcsInCrtn").Value = ds.Tables("VuProductPrices").Rows(0).Item("PcsInCtrn")
            DG.CurrentRow.Cells("DGPricePerPcs").Value = ds.Tables("VuProductPrices").Rows(0).Item("SalMobilePcs")
            DG.CurrentRow.Cells("DGPricePerCrtn").Value = ds.Tables("VuProductPrices").Rows(0).Item("SalMobileCrtn")
        Catch ex As Exception
        End Try
    End Sub

    Sub k1(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If DG.CurrentCell.ColumnIndex = 1 Then
                DG.CurrentRow.Cells("DGPType").Value = sender.text
                Module1.DatasetFill("Select ProdCode,Product from VuProduct where ProdTypeName = N'" & DG.CurrentRow.Cells("DGPType").Value & "'", "VuProduct")
                DGProductCode.DataSource = ds.Tables("VuProduct")
                DGProductCode.DisplayMember = ("Product")
                DGProductCode.ValueMember = ("ProdCode")
                CurrowIndex = DG.CurrentRow.Index
                DG.CurrentRow.Cells(3).Value = ""
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Sub K2(ByVal sender As Object, ByVal e As System.EventArgs)
        If DG.CurrentCell.ColumnIndex = 2 Then
            DG.CurrentRow.Cells("DGProductName").Value = sender.text
            DG.CurrentRow.Cells("DGColProductID").Value = sender.selectedvalue
            CurrowIndex = DG.CurrentRow.Index
            Try
                GridFillForPrice()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Sub Clear(ByVal Frm As Form)
        Dim A As Control
        For Each A In Frm.Controls
            If TypeOf A Is Panel Then
                Dim B As Control
                For Each B In A.Controls
                    If TypeOf B Is TabControl Then
                        Dim C As Control
                        For Each C In B.Controls
                            If TypeOf C Is TabPage Then
                                Dim D As Control
                                For Each D In C.Controls
                                    If TypeOf D Is TextBox Then
                                        D.Text = ""
                                    ElseIf TypeOf D Is DateTimePicker Then
                                        D.Text = Now
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
            End If
        Next
        DG.Rows.Clear()
        cmbCustomerName.SelectedIndex = -1
        cmbLocation.SelectedIndex = -1
        cmbPaymentType.SelectedIndex = -1
        cmbShopKeeper.SelectedIndex = -1
    End Sub
    Sub WashUp()
        FrmSalePaymentDialogueBox.P = True
        FrmSalePaymentDialogueBox.Var_PaymentFormIsOpen = False
        FrmSalePaymentDialogueBox.Close()
        If ds.Tables.Contains("SalePaymentOfSaleMan") Then
            ds.Tables.Remove("SalePaymentOfSaleMan")
        End If
    End Sub
    Sub CStatus(ByVal frm As Form)
        Dim A As Control
        For Each A In frm.Controls
            If TypeOf A Is Panel Then
                Dim B As Control
                For Each B In A.Controls
                    If TypeOf B Is TabControl Then
                        Dim C As Control
                        For Each C In B.Controls
                            If TypeOf C Is TabPage Then
                                Dim D As Control
                                For Each D In C.Controls
                                    If TypeOf D Is ComboBox Or TypeOf D Is DateTimePicker Or TypeOf D Is Button Then
                                        D.Enabled = Not D.Enabled
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
            End If
        Next

        txtInvoice.ReadOnly = Not txtInvoice.ReadOnly
        txtDiscount.ReadOnly = Not txtDiscount.ReadOnly
        txtRemarks.ReadOnly = Not txtRemarks.ReadOnly
        DG.ReadOnly = Not DG.ReadOnly
    End Sub

    Sub FillAllTXT()
        Try
            DG.Columns("DGProductCode").Visible = False
            Module1.DatasetFill("Select * from SaleMainOfSaleMan", "SaleMainOfSaleMan")
            lblMessage.Text = ""
            If cnt < 0 Then
                cnt = 0
            End If
            SaleIDOfSaleMan = ds.Tables("SaleMainOfSaleMan").Rows(cnt).Item("SaleID")
            txtInvoice.Text = ds.Tables("SaleMainOfSaleMan").Rows(cnt).Item("InvoiceNo")
            cmbCustomerName.SelectedValue = ds.Tables("SaleMainOfSaleMan").Rows(cnt).Item("CustomerID")
            cmbPaymentType.SelectedValue = ds.Tables("SaleMainOfSaleMan").Rows(cnt).Item("PaymentTypeID")
            cmbLocation.SelectedValue = ds.Tables("SaleMainOfSaleMan").Rows(cnt).Item("LocID")
            cmbShopKeeper.SelectedValue = ds.Tables("SaleMainOfSaleMan").Rows(cnt).Item("ShopID")
            dtDate.Value = ds.Tables("SaleMainOfSaleMan").Rows(cnt).Item("SaleDate")
            txtTotalToPayWithoutDiscount.Text = ds.Tables("SaleMainOfSaleMan").Rows(cnt).Item("TotalWithOutDiscount")
            txtDiscount.Text = ds.Tables("SaleMainOfSaleMan").Rows(cnt).Item("Discount")
            txtTotalToPay.Text = ds.Tables("SaleMainOfSaleMan").Rows(cnt).Item("TotalToPay")
            txtPaid.Text = ds.Tables("SaleMainOfSaleMan").Rows(cnt).Item("TotalPaid")
            txtBalance.Text = ds.Tables("SaleMainOfSaleMan").Rows(cnt).Item("Balance")
            txtRemarks.Text = ds.Tables("SaleMainOfSaleMan").Rows(cnt).Item("Remarks")

            FILLALLGRID()
        Catch ex As Exception
        End Try
    End Sub

    Sub FILLALLGRID()
        Try
            Module1.DatasetFill("Select * from VuSaleDetailOfSaleMan where saleID=" & SaleIDOfSaleMan & "", "VuSaleDetailOfSaleMan")
            DG.Rows.Clear()
            For a = 0 To ds.Tables("VuSaleDetailOfSaleMan").Rows.Count - 1
                Try
                    DG.Rows.Add()
                    DG.Rows(a).Cells("DGSNO").Value = ds.Tables("VuSaleDetailOfSaleMan").Rows(a).Item("SNo")
                    DG.Rows(a).Cells("DGPType").Value = ds.Tables("VuSaleDetailOfSaleMan").Rows(a).Item("ProdTypeID")
                    DG.Rows(a).Cells("DGProductName").Value = ds.Tables("VuSaleDetailOfSaleMan").Rows(a).Item("Product")
                    DG.Rows(a).Cells("DGColProductID").Value = ds.Tables("VuSaleDetailOfSaleMan").Rows(a).Item("ProdCode")
                    DG.Rows(a).Cells("DGPcsInCrtn").Value = ds.Tables("VuSaleDetailOfSaleMan").Rows(a).Item("PcsInCrtn")
                    DG.Rows(a).Cells("DGPricePerPcs").Value = ds.Tables("VuSaleDetailOfSaleMan").Rows(a).Item("PricePerPcs")
                    DG.Rows(a).Cells("DGPricePerCrtn").Value = ds.Tables("VuSaleDetailOfSaleMan").Rows(a).Item("PricePerCrtn")
                    DG.Rows(a).Cells("DGCrtnPcs").Value = ds.Tables("VuSaleDetailOfSaleMan").Rows(a).Item("CrtnPcs")
                    DG.Rows(a).Cells("DGQty").Value = ds.Tables("VuSaleDetailOfSaleMan").Rows(a).Item("Qty")
                    DG.Rows(a).Cells("DGPrice").Value = ds.Tables("VuSaleDetailOfSaleMan").Rows(a).Item("Price")
                    DG.Rows(a).Cells("DGDesciption").Value = ds.Tables("VuSaleDetailOfSaleMan").Rows(a).Item("ProdDescription")
                    DG.Rows(a).Cells("DGManDate").Value = ds.Tables("VuSaleDetailOfSaleMan").Rows(a).Item("ManDate")
                    DG.Rows(a).Cells("DGExpDate").Value = ds.Tables("VuSaleDetailOfSaleMan").Rows(a).Item("ExpDate")
                Catch ex As Exception
                End Try
            Next

        Catch ex As Exception
        End Try
    End Sub

    Sub IDPicker()
        Try
            Dim SqlReader As SqlDataReader
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select Max(SaleID) from SaleMainOfSaleMan"
            cmd.Connection = cn
            If cn.State = ConnectionState.Closed Then cn.Open()
            SqlReader = cmd.ExecuteReader
            While SqlReader.Read
                If IsDBNull(SqlReader.Item(0)) = True Then
                    SaleIDOfSaleMan = 1
                Else
                    SaleIDOfSaleMan = Val(SqlReader.Item(0)) + 1
                End If
            End While
            SqlReader.Close()
        Catch ex As Exception
        End Try
    End Sub

    Sub InsertUpdateSaleMainOfSaleMan()
        Try
            Dim cmdsave As New SqlCommand

            cmdsave.CommandType = CommandType.StoredProcedure
            cmdsave.CommandText = "InsertUpdateSaleMainOfSaleMan"
            cmdsave.Connection = cn

            If EditValue = 1 Then
                IDPicker()
            End If

            cmdsave.Parameters.Add("@SaleID", SqlDbType.Int).Value = SaleIDOfSaleMan
            cmdsave.Parameters.Add("@InvoiceNo", SqlDbType.NVarChar).Value = Me.txtInvoice.Text
            cmdsave.Parameters.Add("@CustomerID", SqlDbType.Int).Value = Me.cmbCustomerName.SelectedValue
            cmdsave.Parameters.Add("@PaymentTypeID", SqlDbType.Int).Value = Me.cmbPaymentType.SelectedValue
            cmdsave.Parameters.Add("@LocID", SqlDbType.Int).Value = Me.cmbLocation.SelectedValue
            cmdsave.Parameters.Add("@ShopID", SqlDbType.Int).Value = Me.cmbShopKeeper.SelectedValue
            cmdsave.Parameters.Add("@SaleDate", SqlDbType.SmallDateTime).Value = Me.dtDate.Value.Date.ToString
            cmdsave.Parameters.Add("@TotalWithOutDiscount", SqlDbType.Decimal).Value = txtTotalToPayWithoutDiscount.Text
            If txtDiscount.Text = "" Then
                cmdsave.Parameters.Add("@Discount", SqlDbType.Decimal).Value = 0
            Else
                cmdsave.Parameters.Add("@Discount", SqlDbType.Decimal).Value = txtDiscount.Text
            End If

            cmdsave.Parameters.Add("@TotalToPay", SqlDbType.Decimal).Value = txtTotalToPay.Text
            cmdsave.Parameters.Add("@TotalPaid", SqlDbType.Decimal).Value = txtPaid.Text
            cmdsave.Parameters.Add("@Balance", SqlDbType.Decimal).Value = txtBalance.Text
            cmdsave.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = Me.txtRemarks.Text
            cmdsave.Parameters.Add("@CounterForObraye", SqlDbType.Int).Value = 0
            cmdsave.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
            cmdsave.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & SaleIDOfSaleMan
            cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = EditValue

            cmdsave.ExecuteNonQuery()
            cmdsave.Parameters.Clear()

            If EditValue = 1 Then
                SaveSaleDetailOfSaleMan()
                SavePayment()
                CMStatus()
                CStatus(Me)
                'FillAllTXT()
                'MsgBox("THE RECORD HAS BEEN SAVED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & "ریکارد شما موفقانه ثبت گردید", MsgBoxStyle.Information)
                lblMessage.Text = "ریکارد شما موفقانه ثبت گردید"
            Else
                If ds.Tables.Contains("SalePaymentOfSaleMan") Then
                    DeleteSalePaymentOfSaleMan()
                    SavePayment()
                    ds.Tables.Remove("SalePaymentOfSaleMan")
                End If
                DeleteSaleDetailOfSaleMan()
                SaveSaleDetailOfSaleMan()

                CMStatus()
                CStatus(Me)
                FillAllTXT()
                'MsgBox("THE RECORD HAS BEEN UPDATED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & "ریکارد شما موفقانه تنظیم گردید", MsgBoxStyle.Information)
                lblMessage.Text = "ریکارد شما موفقانه تجدید گردید"
                EditValue = 1
            End If

        Catch ex As Exception
        End Try
        FrmSalePaymentDialogueBox.Dispose()
        If ds.Tables.Contains("SalePaymentOfSaleMan") Then
            ds.Tables.Remove("SalePaymentOfSaleMan")
        End If
        WashUp()
    End Sub

    Sub DeleteSaleDetailOfSaleMan()
        Dim cmdDelete As New SqlCommand
        cmdDelete.Connection = cn
        cmdDelete.Transaction = Trans
        cmdDelete.CommandType = CommandType.StoredProcedure
        cmdDelete.CommandText = "DeleteSaleDetailOfSaleMan"
        cmdDelete.Parameters.Add("@SaleID", SqlDbType.Int).Value = SaleIDOfSaleMan
        cmdDelete.ExecuteNonQuery()
    End Sub

    Sub SaveSaleDetailOfSaleMan()
        Dim cmdsaveGrid As New SqlCommand
        cmdsaveGrid.CommandType = CommandType.StoredProcedure
        cmdsaveGrid.CommandText = "InsertUpdateSaleDetailOfSaleMan"
        cmdsaveGrid.Connection = cn
        Try
            For a = 0 To DG.Rows.Count - 2
                cmdsaveGrid.Parameters.Add("@SaleID", SqlDbType.Int)
                cmdsaveGrid.Parameters("@SaleID").Value = SaleIDOfSaleMan


                cmdsaveGrid.Parameters.Add("@SNo", SqlDbType.Int).Value = DG.Rows(a).Cells("DGSNO").Value
                cmdsaveGrid.Parameters.Add("@ProdTypeID", SqlDbType.Int).Value = DG.Rows(a).Cells("DGPType").Value
                cmdsaveGrid.Parameters.Add("@ProdCode", SqlDbType.Int).Value = DG.Rows(a).Cells("DGColProductID").Value
                cmdsaveGrid.Parameters.Add("@PcsInCrtn", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGPcsInCrtn").Value
                cmdsaveGrid.Parameters.Add("@PricePerPcs", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGPricePerPcs").Value
                cmdsaveGrid.Parameters.Add("@PricePerCrtn", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGPricePerCrtn").Value
                cmdsaveGrid.Parameters.Add("@CrtnPcs", SqlDbType.Int).Value = DG.Rows(a).Cells("DGCrtnPcs").Value
                cmdsaveGrid.Parameters.Add("@Qty", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGQty").Value
                cmdsaveGrid.Parameters.Add("@Price", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGPrice").Value)
                If DG.Rows(a).Cells("DGDesciption").Value = Nothing Then
                    cmdsaveGrid.Parameters.Add("@ProdDescription", SqlDbType.NVarChar).Value = " "

                Else
                    cmdsaveGrid.Parameters.Add("@ProdDescription", SqlDbType.NVarChar).Value = DG.Rows(a).Cells("DGDesciption").Value

                End If


                Try
                    If DG.Rows(a).Cells("DGManDate").Value = #12:00:00 AM# Then
                        Var_ManDate = "01/01/1900"
                        cmdsaveGrid.Parameters.Add("@ManDate", SqlDbType.SmallDateTime).Value = Var_ManDate
                    Else
                        Var_ManDate = Convert.ToDateTime(DG.Rows(a).Cells("DGManDate").Value)
                        cmdsaveGrid.Parameters.Add("@ManDate", SqlDbType.SmallDateTime).Value = Var_ManDate
                    End If
                Catch ex As Exception
                    Var_ManDate = "01/01/1900"
                    cmdsaveGrid.Parameters.Add("@ManDate", SqlDbType.SmallDateTime).Value = Var_ManDate
                End Try



                Try
                    If DG.Rows(a).Cells("DGExpDate").Value = #12:00:00 AM# Then
                        Var_ExpDate = "01/01/1900"
                        cmdsaveGrid.Parameters.Add("@ExpDate", SqlDbType.SmallDateTime).Value = Var_ExpDate
                    Else
                        Var_ExpDate = Convert.ToDateTime(DG.Rows(a).Cells("DGExpDate").Value)
                        cmdsaveGrid.Parameters.Add("@ExpDate", SqlDbType.SmallDateTime).Value = Var_ExpDate
                    End If
                Catch ex As Exception
                    Var_ExpDate = "01/01/1900"
                    cmdsaveGrid.Parameters.Add("@ExpDate", SqlDbType.SmallDateTime).Value = Var_ExpDate
                End Try
                cmdsaveGrid.ExecuteNonQuery()
                cmdsaveGrid.Parameters.Clear()
            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub DeleteSalePaymentOfSaleMan()

        Dim cmdsave As New SqlCommand
        cmdsave.CommandType = CommandType.StoredProcedure
        cmdsave.CommandText = "DeleteSalePaymentOfSaleMan"
        cmdsave.Connection = cn
        cmdsave.Parameters.Add("@SaleID", SqlDbType.Int).Value = SaleIDOfSaleMan
        cmdsave.ExecuteNonQuery()

    End Sub

    Sub SavePayment()
        Dim cmdsaveGrid As New SqlCommand
        cmdsaveGrid.CommandType = CommandType.StoredProcedure
        cmdsaveGrid.CommandText = "InsertSalePaymentOfSaleMan"
        cmdsaveGrid.Connection = cn
        Try

            For a = 0 To FrmSalePaymentDialogueBox.DGDiag.Rows.Count - 2
                cmdsaveGrid.Parameters.Add("@SaleID", SqlDbType.Int).Value = SaleIDOfSaleMan
                cmdsaveGrid.Parameters.Add("@InvioceNo", SqlDbType.NVarChar).Value = txtInvoice.Text
                cmdsaveGrid.Parameters.Add("@SNo", SqlDbType.Int).Value = FrmSalePaymentDialogueBox.DGDiag.Rows(a).Cells(0).Value
                cmdsaveGrid.Parameters.Add("@Amount", SqlDbType.Decimal).Value = FrmSalePaymentDialogueBox.DGDiag.Rows(a).Cells(1).Value

                Dim Var_PaymentDate As DateTime
                Try
                    If FrmSalePaymentDialogueBox.DGDiag.Rows(a).Cells(2).Value = #12:00:00 AM# Then
                        Var_PaymentDate = "01/01/1900"
                        cmdsaveGrid.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Var_PaymentDate

                    Else
                        Var_PaymentDate = FrmSalePaymentDialogueBox.DGDiag.Rows(a).Cells(2).Value
                        cmdsaveGrid.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Var_PaymentDate

                    End If
                Catch ex As Exception
                    Var_PaymentDate = "01/01/1900"
                    cmdsaveGrid.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Var_PaymentDate

                End Try

                If cn.State = ConnectionState.Closed Then cn.Open()
                cmdsaveGrid.ExecuteNonQuery()
                cmdsaveGrid.Parameters.Clear()
            Next
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region " CONTEXT MENUS ..................."

    Private Sub MnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuNew.Click
        CMStatus()
        CStatus(Me)
        Clear(Me)
        DG.Columns("DGProductCode").Visible = True
        AddEdit = True
    End Sub

    Private Sub MnuUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuUndo.Click
        AddEdit = False
        CMStatus()
        CStatus(Me)
        Clear(Me)
        FillAllTXT()
        WashUp()
        EditValue = 1

    End Sub

    Private Sub MnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSave.Click
        AddEdit = False
        InsertUpdateSaleMainOfSaleMan()

    End Sub

    Private Sub MnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuEdit.Click
        CMStatus()
        CStatus(Me)
        EditValue = 0
        DG.Columns("DGProductCode").Visible = True
        AddEdit = True
    End Sub

    Private Sub MnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDelete.Click
        Dim a As VariantType
        a = MsgBox("Are you Sure.?" & Chr(13) & "  " & Chr(13) & " آیا شما مطمئن هستید  ", MsgBoxStyle.YesNo)
        If a = vbYes Then
            cmd.CommandText = " Delete from SaleMainOfSaleMan where SaleId = " & SaleIDOfSaleMan
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

            'MsgBox("THE RECORD HAS BEEN DELETED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & " ریکارد مذکور موفقانه فسخ شد ", MsgBoxStyle.Information)
            If cnt = ds.Tables("SaleMainOfSaleMan").Rows.Count - 1 Then
                cnt = cnt - 1
            End If
            If cnt < 0 Then
                Clear(Me)
            End If
            FillAllTXT()
            lblMessage.Text = "ریکارد مذکور موفقانه حذف گردید "
        End If
    End Sub

    Private Sub MnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuExit.Click
        WashUp()
        Me.Close()
    End Sub

#End Region

#Region " Navigations "

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        AddEdit = False
        cnt = 0
        Call FillAllTXT()
        WashUp()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        AddEdit = False
        If cnt = 0 Then Exit Sub
        cnt = cnt - 1
        Call FillAllTXT()
        WashUp()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        AddEdit = False
        If cnt = ds.Tables("SaleMainOfSaleMan").Rows.Count - 1 Then Exit Sub
        cnt = cnt + 1
        Call FillAllTXT()
        WashUp()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        AddEdit = False
        cnt = ds.Tables("SaleMainOfSaleMan").Rows.Count - 1
        Call FillAllTXT()
        WashUp()
    End Sub

#End Region

#Region "EVENTS"

    Private Sub cmbLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLocation.SelectedIndexChanged
        'Try
        '    If Index = True Then
        '        cmbShopKeeper.SelectedIndex = -1
        '        Module1.DatasetFill("Select ShopID,ShopName from Shop where LocID = " & cmbLocation.SelectedValue, "Shop")
        '        cmbShopKeeper.DataSource = ds.Tables("Shop")
        '        cmbShopKeeper.DisplayMember = ("ShopName")
        '        cmbShopKeeper.ValueMember = ("ShopID")
        '        IndexforShop = True
        '        txtShopKeeper.Text = ""
        '        txtAddress.Text = ""
        '        cmbShopKeeper_SelectedIndexChanged(cmbShopKeeper, e)
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub cmbShopKeeper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbShopKeeper.SelectedIndexChanged
        'If IndexforShop = True Then
        '    Try
        '        Module1.DatasetFill("Select * from VuShopForCustomer where ShopID = " & cmbShopKeeper.SelectedValue, "VuShopForCustomer")
        '        txtShopKeeper.Text = ds.Tables("VuShopForCustomer").Rows(0).Item("ConcernPName")
        '        txtAddress.Text = ds.Tables("VuShopForCustomer").Rows(0).Item("Address")
        '    Catch ex As Exception
        '        txtShopKeeper.Text = ""
        '        txtAddress.Text = ""
        '    End Try
        'End If
    End Sub

    Private Sub DTManForGrid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTManForGrid.KeyPress
        'If Asc(e.KeyChar) = 13 Then
        Try
            DG.CurrentRow.Cells("DGManDate").Value = DTManForGrid.Value.Date
        Catch ex As Exception
        End Try
        'End If
    End Sub

    Private Sub DTExpForGrid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTExpForGrid.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Try
                DG.CurrentRow.Cells("DGExpDate").Value = DTExpForGrid.Value.Date
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub txtTotalToPay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalToPay.TextChanged
        Try
            txtBalance.Text = Val(txtTotalToPay.Text) - Val(txtPaid.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtPaid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPaid.TextChanged
        Dim HalfTotal As Double
        Try
            HalfTotal = Val(txtTotalToPay.Text) - Val(txtPaid.Text)
            HalfTotal = HalfTotal - Val(txtDiscount.Text)
            txtBalance.Text = HalfTotal
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPayment.Click
        Try
            If FrmSalePaymentDialogueBox.Var_PaymentFormIsOpen = True Then
                FrmSalePaymentDialogueBox.Visible = True
            Else
                FrmSalePaymentDialogueBox.Call_Is_From_FormName = Me.Name
                FrmSalePaymentDialogueBox.Visible = True
                FrmSalePaymentDialogueBox.TopMost = True
                Try
                    If Me.EditValue = 0 Then
                        Call FrmSalePaymentDialogueBox.GridFillFromSaleOfSaleManTable()
                    End If
                Catch ex As Exception

                End Try
                FrmSalePaymentDialogueBox.txtInvoice.Text = Me.txtInvoice.Text
                FrmSalePaymentDialogueBox.txtTotalToPay.Text = Me.txtTotalToPay.Text
                FrmSalePaymentDialogueBox.txtTotalPaid.Text = Me.txtPaid.Text
                FrmSalePaymentDialogueBox.txtBalance.Text = Me.txtBalance.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "DATA GRID VIEW"

    Private Sub DelegateCellData(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Me.DG.CurrentCell.Value = Me.ActiveControl.Text & e.KeyChar
    End Sub
    Private Sub DG_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DG.EditingControlShowing
        DG.CurrentRow.Cells(0).Value = DG.CurrentRow.Index + 1
        If DG.CurrentCell.ColumnIndex = 1 Then
            Try
                Dim cmb As ComboBox
                cmb = CType(e.Control, ComboBox)
                AddHandler cmb.SelectionChangeCommitted, AddressOf k1
            Catch ex As Exception
            End Try
        End If
        If DG.CurrentRow.Index = CurrowIndex Then
            Try
                Dim cmb As ComboBox
                cmb = CType(e.Control, ComboBox)
                AddHandler cmb.SelectionChangeCommitted, AddressOf K2

            Catch ex As Exception
            End Try
        End If

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
    End Sub

    Private Sub DG_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DG.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DG_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellClick
        DG.CurrentRow.Cells(0).Value = DG.CurrentRow.Index + 1
        If DG.CurrentRow.Index = CurrowIndex Then
            DG.CurrentRow.Cells(2).ReadOnly = False
            DG.CurrentRow.Cells(1).ReadOnly = False
        Else
            DG.CurrentRow.Cells(2).ReadOnly = True
        End If
    End Sub

    Private Sub DG_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellEndEdit
        Try
            If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGCrtnPcs" Or DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGQty" Then
                If DG.CurrentRow.Cells("DGCrtnPcs").Value = 1 Then
                    DG.CurrentRow.Cells("DGPrice").Value = Val(DG.CurrentRow.Cells("DGPricePerPcs").Value) * Val(DG.CurrentRow.Cells("DGQty").Value)
                Else
                    DG.CurrentRow.Cells("DGPrice").Value = Val(DG.CurrentRow.Cells("DGPricePerCrtn").Value) * Val(DG.CurrentRow.Cells("DGQty").Value)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DG_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellValueChanged
        Dim CalculateAmount As Decimal = 0
        Dim Increamenter As Integer = 0
        Try

            If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGCrtnPcs" Or DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGQty" Then


                If azizkhanqarabaghi = True Then
                    For Each Row As DataGridViewRow In DG.Rows

                        CalculateAmount = Val(CalculateAmount) + Val(Convert.ToDecimal(DG.Rows(Increamenter).Cells("DGPrice").Value))
                        Increamenter = Increamenter + 1
                    Next
                    txtTotalToPayWithoutDiscount.Text = CalculateAmount
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            If SaleIDOfSaleMan = 0 Then
                Exit Sub
            Else
                Module1.DatasetFill("Select * from RptVuSaleMainOfSaleMan where SaleID=" & SaleIDOfSaleMan, "RptVuSaleMainOfSaleMan")
                Dim rpt As New RptSaleOfSaleMan
                rpt.SetDataSource(Module1.ds.Tables("RptVuSaleMainOfSaleMan"))
                frmRptSetup.CV.ReportSource = rpt
                Frm.RptShow()
                'Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Dim TempTableName As DataTable
    Dim TempTableMoney As DataTable
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim i As Integer
        DGSearch.Rows.Clear()

        'Module1.DatasetFill("Select * from VuSaleMainOfSaleManSearch where CustomerID = " & cmbCustomerSearch.SelectedValue & " and SaleDate between '" & dtFromSearch.Value.Date.ToString & "' and '" & dtToSearch.Value.Date.ToString & "'", "VuSaleMainOfSaleManSearch")
        Module1.DatasetFill("Select Distinct ShopID,ShopName,ConcernPName,Address from VuSaleMainOfSaleManSearch where CustomerID = " & cmbCustomerSearch.SelectedValue & " and SaleDate between '" & dtFromSearch.Value.Date.ToString & "' and '" & dtToSearch.Value.Date.ToString & "'", "VuSaleMainOfSaleManSearch")

        TempTableName = ds.Tables("VuSaleMainOfSaleManSearch").Copy
        TempTableName.TableName = "TempTableName"

        'TempTableMoney = ds.Tables("VuSaleMainOfSaleManSearch").Copy()
        'TempTableMoney.TableName = "TempTableMoney"

        If ds.Tables.Contains("TempTableName") Then ds.Tables.Remove("TempTableName")
        ds.Tables.Add(TempTableName)
        
        'If ds.Tables.Contains("TempTableMoney") Then ds.Tables.Remove("TempTableMoney")
        'ds.Tables.Add(TempTableMoney)

        'For Each dttable As DataTable In ds.Tables
        '    MsgBox(dttable.TableName)
        '    MsgBox(dttable.Rows.Count)
        'Next

        For Each drow As DataRow In ds.Tables("TempTableName").Rows
            DGSearch.Rows.Add()
            DGSearch.Rows(i).Cells("DGShopIDSearch").Value = drow("ShopID")
            DGSearch.Rows(i).Cells("DGShopNameSearch").Value = drow("ShopName")
            DGSearch.Rows(i).Cells("DGShopKeeperNameSearch").Value = drow("ConcernPName")
            DGSearch.Rows(i).Cells("DGAddressSearch").Value = drow("Address")
            Try
                Module1.DatasetFill("Select Sum(TotalToPay) as TotalToPay,Sum(TotalPaid) as TotalPaid,Sum(Balance) as Balance from VuSaleMainOfSaleManSearch where ShopID=" & drow("ShopID") & " and CustomerID = " & cmbCustomerSearch.SelectedValue & " and SaleDate between '" & dtFromSearch.Value.Date.ToString & "' and '" & dtToSearch.Value.Date.ToString & "'", "VuSaleMainOfSaleManSearch")
                DGSearch.Rows(i).Cells("DGTotalToPaySearch").Value = ds.Tables("VuSaleMainOfSaleManSearch").Rows(0).Item("TotalToPay")
                DGSearch.Rows(i).Cells("DGPaidSearch").Value = ds.Tables("VuSaleMainOfSaleManSearch").Rows(0).Item("TotalPaid")
                DGSearch.Rows(i).Cells("DGBalanceSearch").Value = ds.Tables("VuSaleMainOfSaleManSearch").Rows(0).Item("Balance")
            Catch ex As Exception
            End Try
            i = i + 1
        Next
    End Sub

    Sub InvoiceNoGenerator()
        Dim _m As String
        Dim _y As String
        Dim _MaxID As String
        Dim _Criteria As String
        _m = Date.Now.Month
        _y = Date.Now.Year
        _y = _y.Substring(2, 2)
        Dim SaleMan_InvNo As String
        Dim currentsaleman As String
        Module1.DatasetFill("Select InvoiceCode from VuCustomer where CustomerID =" & cmbCustomerName.SelectedValue, "VuCustomer")
        currentsaleman = ds.Tables("VuCustomer").Rows(0).Item("InvoiceCode")

        If _m.Length = 1 Then
            _m = "0" & _m
        End If
        _Criteria = currentsaleman & "-SAL-" & _m & "-" & _y & "-"

        Try

            Dim sqldreader As SqlDataReader
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select Max(Convert(INT,Substring(InvoiceNo,15,len(InvoiceNo)))) from SaleMainOfSaleMan where InvoiceNo Like('" & _Criteria & "%'" & ")"
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

            SalInvoiceNo = currentsaleman & "-SAL-" & _m & "-" & _y & "-" & _MaxID
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomerName.SelectedIndexChanged
        Try
            If AddEdit.Equals(True) Then
                Call InvoiceNoGenerator()
                txtInvoice.Text = SalInvoiceNo
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtDiscount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscount.TextChanged
        Try
            Try
                Dim azizkhan As Double
                azizkhan = Val(txtTotalToPayWithoutDiscount.Text) - Val(txtDiscount.Text)
                If azizkhan < 0 Then
                    Dim abc As String = txtDiscount.Text
                    abc = abc.Remove(abc.Length - 1, 1)
                    txtDiscount.Text = txtDiscount.Text.Replace(txtDiscount.Text, abc)
                    Me.txtDiscount.Select(0, Me.txtDiscount.Text.Length)
                Else
                    txtTotalToPay.Text = azizkhan
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTotalToPayWithoutDiscount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalToPayWithoutDiscount.TextChanged
        Try
            Dim azizkhan As Double
            azizkhan = Val(txtTotalToPayWithoutDiscount.Text) - Val(txtDiscount.Text)
            If azizkhan < 0 Then
            Else
                txtTotalToPay.Text = azizkhan
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtDiscount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscount.KeyPress

        Try

            If IsNumeric(sender.text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Then
                e.Handled = True
            Else


                Dim aziz As Int32
                If Asc(e.KeyChar) = 8 Then
                Else
                    'If btext Then
                    ' txtDiscount.Text = Me.ActiveControl.Text & e.KeyChar
                    aziz = Val(txtTotalToPayWithoutDiscount.Text) - Val(txtDiscount.Text)
                    If Val(txtDiscount.Text) > Val(aziz) Then
                        e.Handled = True
                    End If
                    'Dim str As String = Convert.ToString(txtDiscount.Text)
                    'str.Remove(str.Length - 2, 2)
                    'txtDiscount.Text = str
                    ' btext = False
                    'Me.txtDiscount.Text = txtDiscount.Text.Substring(Me.txtDiscount.Text.Length - 1)
                End If
                ' End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbCustomerName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCustomerName.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub cmbLocation_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbLocation.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub cmbShopKeeper_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbShopKeeper.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub txtRemarks_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemarks.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub TP2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TP2.Enter
        CM.Enabled = False
    End Sub

    Private Sub TP1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TP1.Enter
        CM.Enabled = True
    End Sub

    Private Sub btnPrintSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintSearch.Click
        Try

            Dim p As Integer
            Module1.DeleteRecord("SaleManReport")
            For p = 0 To DGSearch.Rows.Count - 2
                Module1.InsertRecord("SaleManReport", "'" & cmbCustomerSearch.Text & "','" & DGSearch.Rows(p).Cells("DGShopNameSearch").Value & "','" & DGSearch.Rows(p).Cells("DGShopKeeperNameSearch").Value & "','" & DGSearch.Rows(p).Cells("DGAddressSearch").Value & "'," & DGSearch.Rows(p).Cells("DGTotalToPaySearch").Value & "," & DGSearch.Rows(p).Cells("DGPaidSearch").Value & "," & DGSearch.Rows(p).Cells("DGBalanceSearch").Value & "")
            Next

        Catch ex As Exception
        End Try

        Try
            Module1.DatasetFill("Select * from SaleManReport", "SaleManReport")
            Dim rpt As New RptSaleManSearch
            rpt.SetDataSource(Module1.ds.Tables("SaleManReport"))
            frmRptSetup.CV.ReportSource = rpt
            Frm.RptShow()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDisplayShops_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplayShops.Click
        Try
            If Index = True Then
                cmbShopKeeper.SelectedIndex = -1
                Module1.DatasetFill("Select ShopID,ShopName from Shop where LocID = " & cmbLocation.SelectedValue, "Shop")
                cmbShopKeeper.DataSource = ds.Tables("Shop")
                cmbShopKeeper.DisplayMember = ("ShopName")
                cmbShopKeeper.ValueMember = ("ShopID")
                IndexforShop = True
                txtShopKeeper.Text = ""
                txtAddress.Text = ""
                cmbShopKeeper_SelectedIndexChanged(cmbShopKeeper, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDisplayShopDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplayShopDetail.Click
        If IndexforShop = True Then
            Try
                Module1.DatasetFill("Select * from VuShopForCustomer where ShopID = " & cmbShopKeeper.SelectedValue, "VuShopForCustomer")
                txtShopKeeper.Text = ds.Tables("VuShopForCustomer").Rows(0).Item("ConcernPName")
                txtAddress.Text = ds.Tables("VuShopForCustomer").Rows(0).Item("Address")
            Catch ex As Exception
                txtShopKeeper.Text = ""
                txtAddress.Text = ""
            End Try
        End If
    End Sub
End Class