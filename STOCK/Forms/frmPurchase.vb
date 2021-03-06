Imports System.Data.SqlClient
Imports System.IO
Imports LanguageSelector
Public Class frmPurchase
    Dim Index As Boolean
    Dim OrderID As Integer
    Dim a As Integer
    Dim k As Integer
    Dim RowWanted As Integer = 0
    Public EditValue As Integer
    Public PurchaseID As Integer
    Dim cnt As Integer
    Dim CityID As Integer
    Dim CityBasedID As String
    Dim Var_ManDate As DateTime
    Dim Var_ExpDate As DateTime
    Public CurrentRowKaTable As String
    Dim TableKaName_ForInsertion As String
    Dim Var_TransferDate As DateTime
    Dim MyComputerName As String
    Dim MyComputerIP As String
    Dim DateEntry As DateTime
    Dim bChangedToTime As DateTime
    Dim PurchaseCode As String
    Dim CashCode As String
    Dim vCode As String
    Dim ExpenseCode As String

    Dim SearchChecker As Boolean
    Dim Search As Boolean
    Dim TotalToPayToCompanyOnly As Decimal
    Private Sub frmPurchase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False

        TB1.Left = pnlcentre.Width / 2 - (TB1.Width / 2)
        TB1.Top = pnlcentre.Height / 2 - (TB1.Height / 2)
        pnlcentre.Left = Me.Width / 2 - (pnlcentre.Width / 2)
        pnlcentre.Top = Me.Height / 2 - (pnlcentre.Height / 2)


        Module1.Opencn()
        CityID = Frm.lbLocationID.Text
        CityBasedID = Frm.lbLocationName.Text
        Index = False

        Module1.DatasetFill("Select VID,Name from Vendor", "Vendor")
        cmbCompanyName.DataSource = ds.Tables("Vendor")
        cmbCompanyName.DisplayMember = ("Name")
        cmbCompanyName.ValueMember = ("VID")
        cmbCompanyName.SelectedIndex = -1

        Module1.DatasetFill("Select * from ProductType", "ProductType")
        DGPType.DataSource = ds.Tables("ProductType")
        DGPType.DisplayMember = ("ProdTypeName")
        DGPType.ValueMember = ("ProdTypeID")

        Module1.DatasetFill("Select ProdCode,Product from VuProduct", "VuProduct")
        DGProductCode.DataSource = ds.Tables("VuProduct")
        DGProductCode.DisplayMember = ("Product")
        DGProductCode.ValueMember = ("ProdCode")

        dtOrder.Value = Now
        dtRecieve.Value = Now

        FillAllTXT()

        Index = True
        EditValue = 1
        MnuReturn.Visible = False
        Label1.Visible = False
        cmbPurchaseInvoiceSearch.Visible = False
        Label28.Visible = False
        cmbCompanySearch.Visible = False
        If Frm.GID.Text > 2 Then
            Module1.CMStatusDisable(CM)
        End If
    End Sub

#Region " FUNCTIONS ........................ "
    Sub CMStatus()
        MnuNew.Enabled = Not MnuNew.Enabled
        MnuSave.Enabled = Not MnuSave.Enabled
        MnuUndo.Enabled = Not MnuUndo.Enabled
        MnuEdit.Enabled = Not MnuEdit.Enabled
        MnuDelete.Enabled = Not MnuDelete.Enabled
        'MnuExit.Enabled = Not MnuExit.Enabled
    End Sub

    Sub Clear()
        lblMessage.Text = ""
        'cmbOrderNo.SelectedIndex = -1
        cmbCompanyName.SelectedIndex = -1
        txtPersonName.Text = ""
        txtJobTilte.Text = ""
        dtOrder.Value = Now
        dtRecieve.Value = Now
        DTManForGrid.Value = Now
        DTExpForGrid.Value = Now
        txtInvoiceNo.Text = ""
        txtToBePaid.Text = ""
        txtTotalQty.Text = ""
        txtPaid.Text = ""
        txtBalance.Text = ""
        txtRemarks.Text = ""
        txtOtherExpenses.Text = ""
        DG.Rows.Clear()

        Module1.DatasetFill("Select OrderID,OrderNo from OrderMain where OrderID Not In(Select OrderID from PurchaseMain)", "OrderMain")
        cmbOrderNo.DataSource = ds.Tables("OrderMain")
        cmbOrderNo.DisplayMember = ("OrderNo")
        cmbOrderNo.ValueMember = ("OrderID")
        cmbOrderNo.SelectedIndex = -1

        EditValue = 1

    End Sub

    Sub Status()
        cmbOrderNo.Enabled = Not cmbOrderNo.Enabled
        txtInvoiceNo.ReadOnly = Not txtInvoiceNo.ReadOnly
        btnPayment.Enabled = Not btnPayment.Enabled
        txtRemarks.ReadOnly = Not txtRemarks.ReadOnly
        dtOrder.Enabled = Not dtOrder.Enabled
        dtRecieve.Enabled = Not dtRecieve.Enabled
        DTManForGrid.Enabled = Not DTManForGrid.Enabled
        DTExpForGrid.Enabled = Not DTExpForGrid.Enabled
        ToolStrip1.Enabled = Not ToolStrip1.Enabled
        btnOtherExpenses.Enabled = Not btnOtherExpenses.Enabled
    End Sub
    Sub IDPICKER()
        Module1.DatasetFill("Select PurchaseID from PurchaseMain", "PurchaseMain")
        cmd.CommandText = "Select isnull(Max(PurchaseID),0) from PurchaseMain"
        PurchaseID = cmd.ExecuteScalar + 1
    End Sub

    Private Sub NumericKeys(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If DG.CurrentCell.ColumnIndex = 4 Then
            If IsNumeric(Me.ActiveControl.Text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Then e.Handled = True
        End If
    End Sub

    Sub calc()
        Dim Total As Double = 0
        Dim TotalQty As Double = 0
        TotalToPayToCompanyOnly = 0
        Dim a As Integer
        Try
            For a = 0 To DG.Rows.Count - 1
                Total = Total + Val(DG.Rows(a).Cells("DGPrice").Value)
                TotalQty = TotalQty + Val(DG.Rows(a).Cells("DgRecQty").Value)
            Next
            Me.txtToBePaid.Text = Total
            Me.txtTotalQty.Text = TotalQty
            'txtToBePaid.Text = Val(txtToBePaid.Text) + Val(txtOtherExpenses.Text)
            Me.TotalToPayToCompanyOnly = Total ' Now this is the amount that is only payable to company, without the extra expenses,
            ' found out on 26th september in Mustafa's testing (The computer operator of Izat Afghan Limited).
        Catch ex As Exception

        End Try
    End Sub

    Sub calculate()
        Dim Advance As Double = 0
        Dim a As Integer
        Try
            'txtToBePaid.Text = Val(txtToBePaid.Text) + Val(txtOtherExpenses.Text)
        Catch ex As Exception

        End Try
        Try
            For a = 0 To DG.Rows.Count - 1
                Advance = txtToBePaid.Text - txtPaid.Text
            Next
            Me.txtBalance.Text = Advance
        Catch ex As Exception

        End Try
    End Sub

    Sub WashUp()
        'If DfrmPurchasePayment.Visible = True Then
        'DfrmPurchasePayment.P = True

        DfrmPurchasePayment.Close()
        'End If

        'If DfrmOtherExpenses.Visible = True Then
        DfrmOtherExpenses.Var_FormIsOpen = False
        DfrmOtherExpenses.Close()
        'End If

        If DfrmPurchaseQty.Visible = True Then
            DfrmPurchaseQty.P = True
            DfrmPurchaseQty.Close()
        End If
        'DfrmPurchasePayment.Dispose()
        'DfrmPurchasePayment.Close()
        'DfrmPurchaseQty.Dispose()
        'DfrmPurchaseQty.Close()
        Dim arr(ds.Tables.Count) As String
        Dim index As Integer = 0
        For Each datatbl As DataTable In ds.Tables
            If datatbl.TableName.StartsWith("TableOfRowNo") Then
                arr(index) = datatbl.TableName
                index = index + 1
            End If
        Next
        Dim intloop As Integer = 0
        Dim strTableName As String = ""
        For intloop = 0 To index - 1
            strTableName = arr(intloop)
            'MsgBox(strTableName)
            ds.Tables.Remove(strTableName)
        Next
    End Sub

    Sub GridFillOrder()
        Try
            Module1.DatasetFill("Select SNo,ProdTypeID,ProdCode,Qty from VuOrderDetail where OrderID = " & OrderID & "", "VuOrderDetail")
            DG.Rows.Clear()
            For a = 0 To ds.Tables("VuOrderDetail").Rows.Count - 1
                DG.Rows.Add()
                DG.Rows(a).Cells("DGSNO").Value = ds.Tables("VuOrderDetail").Rows(a).Item("SNo")
                DG.Rows(a).Cells("DGPType").Value = ds.Tables("VuOrderDetail").Rows(a).Item("ProdTypeID")
                DG.Rows(a).Cells("DGProductCode").Value = ds.Tables("VuOrderDetail").Rows(a).Item("ProdCode")
                DG.Rows(a).Cells("DGQty").Value = ds.Tables("VuOrderDetail").Rows(a).Item("Qty")
                DG.Rows(a).Cells("DGRemain").Value = ds.Tables("VuOrderDetail").Rows(a).Item("Qty")
                DG.Rows(a).Cells("DGPrice").Value = "0"
                DG.Rows(a).Cells("DGRecQty").Value = "0"
                DG.Rows(a).Cells("dgdescription").Value = "------"
                DG.Columns("DGSNO").ReadOnly = True
                DG.Columns("DGPType").ReadOnly = True
                DG.Columns("DGProductCode").ReadOnly = True
                DG.Columns("DGQty").ReadOnly = True
                DG.Columns("DGRemain").ReadOnly = True
                DG.Columns("DGRecQty").ReadOnly = True
                DG.Columns("DGManDate").ReadOnly = True
                DG.Columns("DGExpDate").ReadOnly = True
                DG.Columns("DGPrice").ReadOnly = True
                ProductPriceFill()
            Next

        Catch ex As Exception
        End Try
    End Sub

    Sub ProductPriceFill()
        Try
            Module1.DatasetFill("Select PcsInCtrn,PricePerPcs,PricePerCrtn from VuProductPrices where ProdTypeID = " & DG.Rows(a).Cells("DGPType").Value & " and ProdCode =" & DG.Rows(a).Cells("DGProductCode").Value & "", "VuProductPrices")
            DG.Rows(a).Cells("DGPcsInCrtn").Value = ds.Tables("VuProductPrices").Rows(0).Item("PcsInCtrn")
            DG.Rows(a).Cells("DGPricePerPcs").Value = ds.Tables("VuProductPrices").Rows(0).Item("PricePerPcs")
            DG.Rows(a).Cells("DGPricePerCrtn").Value = ds.Tables("VuProductPrices").Rows(0).Item("PricePerCrtn")
        Catch ex As Exception
        End Try
    End Sub

    Sub SaveUpdatePurchaseMain()
        Try
            'For Each dt As DataTable In ds.Tables
            '    MsgBox(dt.TableName)
            'Next
            If EditValue = 1 Then
                IDPICKER()
            End If
            Dim cmdsave As New SqlCommand

            cmdsave.CommandType = CommandType.StoredProcedure
            cmdsave.CommandText = "InsertUpdatePurchaseMain"
            cmdsave.Connection = cn

            cmdsave.Parameters.Add("@PurchaseID", SqlDbType.Int).Value = PurchaseID
            cmdsave.Parameters.Add("@InvoiceNo", SqlDbType.NVarChar).Value = Me.txtInvoiceNo.Text
            cmdsave.Parameters.Add("@OrderNo", SqlDbType.NVarChar).Value = Me.cmbOrderNo.Text
            cmdsave.Parameters.Add("@VID", SqlDbType.Int).Value = Convert.ToInt32(Me.cmbCompanyName.SelectedValue)
            cmdsave.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID
            cmdsave.Parameters.Add("@PersonName", SqlDbType.NVarChar).Value = Me.txtPersonName.Text
            cmdsave.Parameters.Add("@JobTitle", SqlDbType.NVarChar).Value = Me.txtJobTilte.Text
            cmdsave.Parameters.Add("@ShipDate", SqlDbType.SmallDateTime).Value = Me.dtOrder.Value.Date.ToString
            cmdsave.Parameters.Add("@RecDate", SqlDbType.SmallDateTime).Value = Me.dtRecieve.Value.Date.ToString
            cmdsave.Parameters.Add("@Expenses", SqlDbType.Decimal).Value = Val(txtOtherExpenses.Text)
            cmdsave.Parameters.Add("@TotalToPay", SqlDbType.Decimal).Value = Val(txtToBePaid.Text)
            cmdsave.Parameters.Add("@TotalPaid", SqlDbType.Decimal).Value = Val(txtPaid.Text)
            cmdsave.Parameters.Add("@Balance", SqlDbType.Decimal).Value = Val(txtBalance.Text)
            cmdsave.Parameters.Add("@TotalQty", SqlDbType.Decimal).Value = Val(txtTotalQty.Text)
            cmdsave.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Me.txtRemarks.Text
            cmdsave.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
            cmdsave.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & PurchaseID
            cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = EditValue

            cmdsave.ExecuteNonQuery()
            cmdsave.Parameters.Clear()

            If EditValue = 1 Then
                SaveUpdatePurchaseDetail()
                SaveUpdatePurchasePayment()
                SavePurchaseOtherExpenses()
                SaveIGL()
                Call SaveVoucher()
                CMStatus()
                Status()
                'FillAllTXT()
                'MsgBox("THE RECORD HAS BEEN SAVED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & "ریکارد شما موفقانه ثبت گردید", MsgBoxStyle.Information)
                lblMessage.Text = "ریکارد شما موفقانه ثبت گردید"
            Else
                If ds.Tables.Contains("vuPurchasePayment") Then
                    DeletePurchasePayment()
                    SaveUpdatePurchasePayment()
                    ds.Tables.Remove("VuPurchasePayment")
                End If
                If ds.Tables.Contains("vuPurchaseOtherExpenses") Then
                    DeletePurchaseOtherExpenses()
                    SavePurchaseOtherExpenses()
                    ds.Tables.Remove("vuPurchaseOtherExpenses")
                End If
                DeletePurchaseDetail()
                SaveUpdatePurchaseDetail()
                SaveVoucher()
                CMStatus()
                Status()
                FillAllTXT()
                'MsgBox("THE RECORD HAS BEEN UPDATED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & "ریکارد شما موفقانه تنظیم گردید", MsgBoxStyle.Information)
                lblMessage.Text = "ریکارد شما موفقانه تجدید گردید"

                EditValue = 1
            End If

        Catch ex As Exception
        End Try
        'MnuSearch.Enabled = True
        DfrmPurchasePayment.Dispose()
        If ds.Tables.Contains("vuPurchasePayment") Then
            ds.Tables.Remove("VuPurchasePayment")
        End If
        If ds.Tables.Contains("vuPurchaseOtherExpenses") Then
            ds.Tables.Remove("vuPurchaseOtherExpenses")
        End If

        If cmbOrderNo.Enabled = True Then
            cmbOrderNo.Enabled = False
        End If

        If txtInvoiceNo.ReadOnly = False Then
            txtInvoiceNo.ReadOnly = True
        End If
        MnuSearch.Enabled = True
    End Sub

    Sub DeletePurchaseDetail()
        Dim cmdDelete As New SqlCommand
        cmdDelete.Connection = cn
        cmdDelete.Transaction = Trans
        cmdDelete.CommandType = CommandType.StoredProcedure
        cmdDelete.CommandText = "DeletePurchaseDetail"
        cmdDelete.Parameters.Add("@PurchaseID", SqlDbType.Int).Value = PurchaseID
        cmdDelete.ExecuteNonQuery()
    End Sub

    Sub SaveUpdatePurchaseDetail()
        Dim cmdsaveGrid As New SqlCommand
        cmdsaveGrid.CommandType = CommandType.StoredProcedure
        cmdsaveGrid.CommandText = "InsertUpdatePurchaseDetail"
        cmdsaveGrid.Connection = cn
        Try
            For a = 0 To DG.Rows.Count - 1
                cmdsaveGrid.Parameters.Add("@PurchaseID", SqlDbType.Int)
                cmdsaveGrid.Parameters("@PurchaseID").Value = PurchaseID


                cmdsaveGrid.Parameters.Add("@SNO", SqlDbType.Int).Value = DG.Rows(a).Cells("DGSNO").Value
                cmdsaveGrid.Parameters.Add("@ProdTypeID", SqlDbType.Int).Value = DG.Rows(a).Cells("DGPType").Value
                cmdsaveGrid.Parameters.Add("@ProdCode", SqlDbType.Int).Value = DG.Rows(a).Cells("DGProductCode").Value
                cmdsaveGrid.Parameters.Add("@PcsInCrtn", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGPcsInCrtn").Value
                cmdsaveGrid.Parameters.Add("@PricePerPcs", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGPricePerPcs").Value
                cmdsaveGrid.Parameters.Add("@PricePerCrtn", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGPricePerCrtn").Value
                cmdsaveGrid.Parameters.Add("@Qty", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGQty").Value
                cmdsaveGrid.Parameters.Add("@Price", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGPrice").Value)
                cmdsaveGrid.Parameters.Add("@RecQty", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGRecQty").Value)
                cmdsaveGrid.Parameters.Add("@RemainQty", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGRemain").Value)
                cmdsaveGrid.Parameters.Add("@ProdDescription", SqlDbType.NVarChar).Value = DG.Rows(a).Cells("dgdescription").Value


                'Try
                '    If DG.Rows(a).Cells(8).Value = "" Then
                '        cmdsaveGrid.Parameters.Add("@ProdDescription", SqlDbType.NVarChar).Value = " "
                '    Else
                '        cmdsaveGrid.Parameters.Add("@ProdDescription", SqlDbType.NVarChar).Value = DG.Rows(a).Cells(8).Value
                '    End If
                'Catch ex As Exception
                '    cmdsaveGrid.Parameters.Add("@ProdDescription", SqlDbType.NVarChar).Value = " "
                'End Try




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

                Call GetHostComputerInformation()
                ' Now for each successful insertion of grid row we call its sub detail grid insertion.

                Dim RowNum As String = Me.DG.Rows(a).Cells("DGSNO").Value
                TableKaName_ForInsertion = "TableOfRowNo " & RowNum
                RowWanted = RowNum - 1
                If ds.Tables.Contains(TableKaName_ForInsertion) Then


                    Call DeletePurchaseSubDetailGrid()
                    Call SavePurchaseSubDetailGrid()
                End If

            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub DeletePurchasePayment()
        Dim cmdDelete As New SqlCommand
        cmdDelete.Connection = cn
        cmdDelete.Transaction = Trans
        cmdDelete.CommandType = CommandType.StoredProcedure
        cmdDelete.CommandText = "DeletePurchasePayment"
        cmdDelete.Parameters.Add("@PurchaseID", SqlDbType.Int).Value = PurchaseID
        cmdDelete.ExecuteNonQuery()
    End Sub

    Sub SaveUpdatePurchasePayment()
        Dim cmdsaveGrid1 As New SqlCommand
        cmdsaveGrid1.CommandType = CommandType.StoredProcedure
        cmdsaveGrid1.CommandText = "InsertPurchasePayment"
        cmdsaveGrid1.Connection = cn
        Try
            For a = 0 To DfrmPurchasePayment.DGDiag.Rows.Count - 2
                cmdsaveGrid1.Parameters.Add("@PurchaseID", SqlDbType.Int)
                cmdsaveGrid1.Parameters("@PurchaseID").Value = PurchaseID

                cmdsaveGrid1.Parameters.Add("@InvioceNo", SqlDbType.NVarChar).Value = txtInvoiceNo.Text
                cmdsaveGrid1.Parameters.Add("@SNO", SqlDbType.Int).Value = DfrmPurchasePayment.DGDiag.Rows(a).Cells(0).Value
                cmdsaveGrid1.Parameters.Add("@Amount", SqlDbType.Decimal).Value = DfrmPurchasePayment.DGDiag.Rows(a).Cells(1).Value
                'cmdsaveGrid1.Parameters.Add("@dtDate", SqlDbType.NVarChar).Value = DfrmPurchasePayment.DGDiag.Rows(a).Cells(2).Value

                Dim Var_PaymentDate As DateTime
                Try
                    If DfrmPurchasePayment.DGDiag.Rows(a).Cells(2).Value = #12:00:00 AM# Then
                        Var_PaymentDate = "01/01/1900"
                        cmdsaveGrid1.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Var_PaymentDate

                    Else
                        Var_PaymentDate = DfrmPurchasePayment.DGDiag.Rows(a).Cells(2).Value
                        cmdsaveGrid1.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Var_PaymentDate

                    End If
                Catch ex As Exception
                    Var_PaymentDate = "01/01/1900"
                    cmdsaveGrid1.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Var_PaymentDate

                End Try

                cmdsaveGrid1.ExecuteNonQuery()
                cmdsaveGrid1.Parameters.Clear()

            Next

        Catch ex As Exception
        End Try
    End Sub

    Sub DeletePurchaseOtherExpenses()
        Dim cmdDelete As New SqlCommand
        cmdDelete.Connection = cn
        cmdDelete.Transaction = Trans
        cmdDelete.CommandType = CommandType.StoredProcedure
        cmdDelete.CommandText = "DeletePurchaseOtherExpenses"
        cmdDelete.Parameters.Add("@PurchaseID", SqlDbType.Int).Value = PurchaseID
        cmdDelete.ExecuteNonQuery()
    End Sub

    Sub SavePurchaseOtherExpenses()
        Dim cmdsaveGrid1 As New SqlCommand
        cmdsaveGrid1.CommandType = CommandType.StoredProcedure
        cmdsaveGrid1.CommandText = "InsertPurchaseOtherExpenses"
        cmdsaveGrid1.Connection = cn
        Try
            For a = 0 To DfrmOtherExpenses.DGDiag.Rows.Count - 2
                cmdsaveGrid1.Parameters.Add("@PurchaseID", SqlDbType.Int)
                cmdsaveGrid1.Parameters("@PurchaseID").Value = PurchaseID

                cmdsaveGrid1.Parameters.Add("@InvoiceNo", SqlDbType.NVarChar).Value = txtInvoiceNo.Text
                cmdsaveGrid1.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = DfrmOtherExpenses.dtPayment.Value.Date
                cmdsaveGrid1.Parameters.Add("@DGSNO", SqlDbType.Int).Value = DfrmOtherExpenses.DGDiag.Rows(a).Cells(0).Value
                cmdsaveGrid1.Parameters.Add("@Type", SqlDbType.Int).Value = DfrmOtherExpenses.DGDiag.Rows(a).Cells(3).Value
                'MsgBox(DfrmOtherExpenses.DGDiag.Rows(a).Cells(1).FormattedValueType)
                'MsgBox(DfrmOtherExpenses.DGDiag.Rows(a).Cells(1).Value)
                'MsgBox(DfrmOtherExpenses.DGDiag.Rows(a).Cells(3).Value)
                cmdsaveGrid1.Parameters.Add("@Amount", SqlDbType.Decimal).Value = DfrmOtherExpenses.DGDiag.Rows(a).Cells(2).Value
                cmdsaveGrid1.ExecuteNonQuery()
                cmdsaveGrid1.Parameters.Clear()
            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub SaveIGL()
        Dim cmdsaveGridIGL As New SqlCommand
        cmdsaveGridIGL.CommandType = CommandType.StoredProcedure
        cmdsaveGridIGL.CommandText = "InsertIGL"
        cmdsaveGridIGL.Connection = cn
        Try
            For k = 0 To DG.Rows.Count - 1

                cmdsaveGridIGL.Parameters.Add("@ID", SqlDbType.Int)
                cmdsaveGridIGL.Parameters("@ID").Value = PurchaseID

                cmdsaveGridIGL.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Me.dtRecieve.Value.Date
                cmdsaveGridIGL.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "Purchase"
                cmdsaveGridIGL.Parameters.Add("@ProductType", SqlDbType.Int).Value = DG.Rows(k).Cells("DGPType").Value
                cmdsaveGridIGL.Parameters.Add("@ProductCode", SqlDbType.Int).Value = DG.Rows(k).Cells("DGProductCode").Value
                cmdsaveGridIGL.Parameters.Add("@PurchaseQty", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DGRecQty").Value)
                cmdsaveGridIGL.Parameters.Add("@SaleQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@ReturnQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@ClaimQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@DamageQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@CrtnPcs", SqlDbType.SmallInt).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Broken", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Leak", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Short", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Dent", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Expired", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@DecayedBeforeExpiration", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Etc", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Ok", SqlDbType.Decimal).Value = 0

                Try
                    If DG.Rows(k).Cells("dgdescription").Value = "" Then
                        cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = " "
                    Else
                        cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = DG.Rows(k).Cells("dgdescription").Value
                    End If
                Catch ex As Exception
                    cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = " "
                End Try

                cmdsaveGridIGL.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
                cmdsaveGridIGL.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & PurchaseID

                cmdsaveGridIGL.ExecuteNonQuery()
                cmdsaveGridIGL.Parameters.Clear()
            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub UpdateIGL()
        Dim OldQty As Decimal = 0
        Dim NewQty As Decimal = 0
        Dim TotalQty As Decimal = 0
        Dim cmdsaveGridIGL As New SqlCommand
        cmdsaveGridIGL.CommandType = CommandType.StoredProcedure
        cmdsaveGridIGL.CommandText = "InsertIGL"
        cmdsaveGridIGL.Connection = cn
        Try

            Module1.DatasetFill("Select Sum(PurchaseQty)as PurchaseQuantity from VuIGL where ID=" & PurchaseID & " and ProductType =" & DG.Rows(a).Cells("DGPType").Value & " and ProductCode=" & DG.Rows(a).Cells("DGProductCode").Value & " And Type='Purchase'", "VuIGL")
            OldQty = ds.Tables("VuIGL").Rows(0).Item("PurchaseQuantity")
            NewQty = Val(DG.Rows(RowWanted).Cells("DGRecQty").Value)
            TotalQty = NewQty - OldQty
        Catch ex As Exception
        End Try
        If TotalQty = 0 Then
            Exit Sub
        End If
        Try
            For k = 0 To 1 - 1

                cmdsaveGridIGL.Parameters.Add("@ID", SqlDbType.Int)
                cmdsaveGridIGL.Parameters("@ID").Value = PurchaseID
                'For Each dtTable As DataTable In ds.Tables
                '    MsgBox(dtTable.TableName)
                'Next
                'Try
                '    'DateEntry = ds.Tables(TableKaName_ForInsertion).Rows(a).Item("trdate")

                'Catch ex As Exception

                'End Try
                'Try
                '    If DateEntry = #12:00:00 AM# Then
                '        Var_TransferDate = "01/01/1900"
                '        cmdsaveGridIGL.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Var_TransferDate
                '    Else
                '        Var_TransferDate = DateEntry
                '        cmdsaveGridIGL.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Var_TransferDate
                '    End If
                'Catch ex As Exception
                'End Try
                cmdsaveGridIGL.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Var_TransferDate
                cmdsaveGridIGL.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "Purchase"
                cmdsaveGridIGL.Parameters.Add("@ProductType", SqlDbType.Int).Value = DG.Rows(RowWanted).Cells("DGPType").Value
                cmdsaveGridIGL.Parameters.Add("@ProductCode", SqlDbType.Int).Value = DG.Rows(RowWanted).Cells("DGProductCode").Value


                cmdsaveGridIGL.Parameters.Add("@PurchaseQty", SqlDbType.Decimal).Value = TotalQty
                cmdsaveGridIGL.Parameters.Add("@SaleQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@ReturnQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@ClaimQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@DamageQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@CrtnPcs", SqlDbType.SmallInt).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Broken", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Leak", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Short", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Dent", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Expired", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@DecayedBeforeExpiration", SqlDbType.Decimal).Value = 0

                Try
                    If DG.Rows(k).Cells("dgdescription").Value = "" Then
                        cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = " "
                    Else
                        cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = DG.Rows(RowWanted).Cells("dgdescription").Value
                    End If
                Catch ex As Exception
                    cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = " "
                End Try


                'cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = "Purchase"
                cmdsaveGridIGL.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
                cmdsaveGridIGL.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & PurchaseID

                cmdsaveGridIGL.ExecuteNonQuery()
                cmdsaveGridIGL.Parameters.Clear()
            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub FillAllTXT()
        Try
            EditValue = 1
            lblMessage.Text = ""
            Module1.DatasetFill("Select OrderID,OrderNo from OrderMain ", "OrderMain")
            cmbOrderNo.DataSource = ds.Tables("OrderMain")
            cmbOrderNo.DisplayMember = ("OrderNo")
            cmbOrderNo.ValueMember = ("OrderID")
            cmbOrderNo.SelectedIndex = -1

            Module1.DatasetFill("Select * from VuPurchaseMain", "VuPurchaseMain")
            If cnt < 0 Then
                cnt = 0
            End If
            Module1.DatasetFill("Select * from VuPurchaseMain", "VuPurchaseMain")
            If Module1.ds.Tables("VuPurchaseMain").Rows.Count = 0 Then Exit Sub
                PurchaseID = ds.Tables("VuPurchaseMain").Rows(cnt).Item("PurchaseID")
                txtInvoiceNo.Text = ds.Tables("VuPurchaseMain").Rows(cnt).Item("InvoiceNo")
                cmbOrderNo.Text = ds.Tables("VuPurchaseMain").Rows(cnt).Item("OrderNo")
                cmbCompanyName.Text = ds.Tables("VuPurchaseMain").Rows(cnt).Item("Name")
                OrderID = ds.Tables("VuPurchaseMain").Rows(cnt).Item("OrderID")
                txtPersonName.Text = ds.Tables("VuPurchaseMain").Rows(cnt).Item("PersonName")
                txtJobTilte.Text = ds.Tables("VuPurchaseMain").Rows(cnt).Item("JobTitle")
                dtOrder.Value = ds.Tables("VuPurchaseMain").Rows(cnt).Item("ShipDate")
                dtRecieve.Value = ds.Tables("VuPurchaseMain").Rows(cnt).Item("RecDate")
                txtOtherExpenses.Text = ds.Tables("VuPurchaseMain").Rows(cnt).Item("Expenses")
                txtToBePaid.Text = ds.Tables("VuPurchaseMain").Rows(cnt).Item("TotalToPay")
                txtPaid.Text = ds.Tables("VuPurchaseMain").Rows(cnt).Item("TotalPaid")
                txtBalance.Text = ds.Tables("VuPurchaseMain").Rows(cnt).Item("Balance")
                txtTotalQty.Text = ds.Tables("VuPurchaseMain").Rows(cnt).Item("TotalQty")
                txtRemarks.Text = ds.Tables("VuPurchaseMain").Rows(cnt).Item("Description")

                Call FILLALLGRID()
        Catch ex As Exception
        End Try
    End Sub

    Sub FILLALLGRID()
        Try

            Module1.DatasetFill("Select * from VuPurchaseDetail where PurchaseID=" & PurchaseID & "", "VuPurchaseDetail")

            DG.Rows.Clear()
            For a = 0 To ds.Tables("VuPurchaseDetail").Rows.Count - 1
                Try
                    DG.Rows.Add()
                    DG.Rows(a).Cells("DGSNO").Value = ds.Tables("VuPurchaseDetail").Rows(a).Item("SNo")
                    DG.Rows(a).Cells("DGPType").Value = ds.Tables("VuPurchaseDetail").Rows(a).Item("ProdTypeID")
                    DG.Rows(a).Cells("DGProductCode").Value = ds.Tables("VuPurchaseDetail").Rows(a).Item("ProdCode")
                    DG.Rows(a).Cells("DGPcsInCrtn").Value = ds.Tables("VuPurchaseDetail").Rows(a).Item("PcsInCrtn")
                    DG.Rows(a).Cells("DGPricePerPcs").Value = ds.Tables("VuPurchaseDetail").Rows(a).Item("PricePerPcs")
                    DG.Rows(a).Cells("DGPricePerCrtn").Value = ds.Tables("VuPurchaseDetail").Rows(a).Item("PricePerCrtn")
                    DG.Rows(a).Cells("DGQty").Value = ds.Tables("VuPurchaseDetail").Rows(a).Item("Qty")
                    DG.Rows(a).Cells("DGPrice").Value = ds.Tables("VuPurchaseDetail").Rows(a).Item("Price")
                    DG.Rows(a).Cells("DGRecQty").Value = ds.Tables("VuPurchaseDetail").Rows(a).Item("RecQty")
                    DG.Rows(a).Cells("DGRemain").Value = ds.Tables("VuPurchaseDetail").Rows(a).Item("RemainQty")
                    DG.Rows(a).Cells("dgdescription").Value = ds.Tables("VuPurchaseDetail").Rows(a).Item("ProdDescription")
                    DG.Rows(a).Cells("DGManDate").Value = ds.Tables("VuPurchaseDetail").Rows(a).Item("ManDate")
                    DG.Rows(a).Cells("DGExpDate").Value = ds.Tables("VuPurchaseDetail").Rows(a).Item("ExpDate")
                    DG.Columns("DGSNO").ReadOnly = True
                    DG.Columns("DGPType").ReadOnly = True
                    DG.Columns("DGProductCode").ReadOnly = True
                    DG.Columns("DGQty").ReadOnly = True
                    DG.Columns("DGRecQty").ReadOnly = True
                    DG.Columns("DGRemain").ReadOnly = True
                    DG.Columns("DGManDate").ReadOnly = True
                    DG.Columns("DGExpDate").ReadOnly = True
                    DG.Columns("DGPrice").ReadOnly = True
                    DG.Columns("btnGrid").Visible = False
                    DG.Columns("DGPcsInCrtn").ReadOnly = True
                    DG.Columns("DGPricePerPcs").ReadOnly = True
                    DG.Columns("DGPricePerCrtn").ReadOnly = True
                Catch ex As Exception
                End Try
            Next

        Catch ex As Exception
        End Try
    End Sub

    Sub GridPaymentFill()
        Try

            Module1.DatasetFill("Select * from VuPurchasePayment where PurchaseID=" & PurchaseID & "", "VuPurchasePayment")

            DfrmPurchasePayment.DGDiag.Rows.Clear()
            For a = 0 To ds.Tables("VuPurchasePayment").Rows.Count - 1
                Try
                    DfrmPurchasePayment.DGDiag.Rows.Add()
                    DfrmPurchasePayment.DGDiag.Rows(a).Cells(0).Value = ds.Tables("VuPurchasePayment").Rows(a).Item("SNO")
                    DfrmPurchasePayment.DGDiag.Rows(a).Cells(1).Value = ds.Tables("VuPurchasePayment").Rows(a).Item("Amount")
                    DfrmPurchasePayment.DGDiag.Rows(a).Cells(2).Value = ds.Tables("VuPurchasePayment").Rows(a).Item("dtDate")
                Catch ex As Exception
                End Try
            Next
            DfrmPurchasePayment.Var_FormIsOpen = True
        Catch ex As Exception
        End Try
    End Sub

    Sub GridOtherExpensesFill()
        Try

            Module1.DatasetFill("Select * from VuPurchaseOtherExpenses where PurchaseID=" & PurchaseID & "", "VuPurchaseOtherExpenses")
            DfrmOtherExpenses.txtInvoice.Text = ds.Tables("VuPurchaseOtherExpenses").Rows(0).Item("InvoiceNo")
            DfrmOtherExpenses.dtPayment.Value = ds.Tables("VuPurchaseOtherExpenses").Rows(0).Item("dtDate")
            DfrmOtherExpenses.DGDiag.Rows.Clear()
            For a = 0 To ds.Tables("VuPurchaseOtherExpenses").Rows.Count - 1
                Try
                    DfrmOtherExpenses.DGDiag.Rows.Add()
                    DfrmOtherExpenses.DGDiag.Rows(a).Cells(0).Value = ds.Tables("VuPurchaseOtherExpenses").Rows(a).Item("DGSNo")
                    DfrmOtherExpenses.DGDiag.Rows(a).Cells(1).Value = ds.Tables("VuPurchaseOtherExpenses").Rows(a).Item("ExpenseName")
                    DfrmOtherExpenses.DGDiag.Rows(a).Cells(2).Value = ds.Tables("VuPurchaseOtherExpenses").Rows(a).Item("Amount")
                    DfrmOtherExpenses.DGDiag.Rows(a).Cells(3).Value = ds.Tables("VuPurchaseOtherExpenses").Rows(a).Item("Type")
                Catch ex As Exception
                End Try
            Next
            DfrmOtherExpenses.Var_FormIsOpen = True
        Catch ex As Exception
        End Try
    End Sub

    Sub GetHostComputerInformation()
        Try

        
            'For retieving computer name and IP.
            'MsgBox(System.Net.Dns.GetHostEntry("localhost").HostName) ' Just for getting the host computer name.
            MyComputerName = System.Net.Dns.GetHostEntry("localhost").HostName
            Dim MyPCName As System.Net.IPHostEntry

            MyPCName = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())
            Dim IP() As System.Net.IPAddress
            IP = MyPCName.AddressList
            MyComputerIP = IP(0).ToString()
        Catch ex As Exception
            MyComputerIP = "Could Not Get it"
        End Try
    End Sub


#Region "ACCOUNT SECTION ENTRY"

    Sub SaveVoucher()
        If cn.State = ConnectionState.Closed Then cn.Open()

        'cmd.CommandText = "Select CashCode from Impheads"
        'CashCode = cmd.ExecuteScalar

        'cmd.CommandText = "Select RpurchaseCode from Impheads"
        'PurchaseCode = cmd.ExecuteScalar

        Module1.DatasetFill("Select CashCode,RpurchaseCode,vendorSuccode,ExpenseCode from Impheads where CompanyID = " & Frm.LBCompanyID.Text & "", "Impheads")
        CashCode = ds.Tables("Impheads").Rows(0).Item("CashCode")
        PurchaseCode = ds.Tables("Impheads").Rows(0).Item("RpurchaseCode")
        vCode = ds.Tables("Impheads").Rows(0).Item("vendorSuccode")
        ExpenseCode = ds.Tables("Impheads").Rows(0).Item("ExpenseCode")

        Try
            Trans = cn.BeginTransaction
            Dim cmdSave As New SqlCommand
            cmdSave.Transaction = Trans
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmdSave.Connection = cn
            cmdSave.CommandType = CommandType.StoredProcedure
            cmdSave.CommandText = "InsertUpdateVMain"
            cmdSave.Parameters.Add("@Vno", SqlDbType.NVarChar)
            cmdSave.Parameters("@Vno").Value = Me.txtInvoiceNo.Text
            cmdSave.Parameters.Add("@Vtype", SqlDbType.NVarChar)
            cmdSave.Parameters("@Vtype").Value = "Purchase Invoice"
            cmdSave.Parameters.Add("@Date", SqlDbType.SmallDateTime)
            cmdSave.Parameters("@Date").Value = Me.dtRecieve.Value.Date
            cmdSave.Parameters.Add("@descr", SqlDbType.NVarChar)
            cmdSave.Parameters("@descr").Value = Me.txtRemarks.Text
            cmdSave.Parameters.Add("@UserID", SqlDbType.Int)
            cmdSave.Parameters("@UserID").Value = Frm.LbUserID.Text
            cmdSave.Parameters.Add("@CompanyID", SqlDbType.Int)
            cmdSave.Parameters("@CompanyID").Value = Frm.LBCompanyID.Text
            cmdSave.Parameters.Add("@WName", SqlDbType.VarChar)
            cmdSave.Parameters("@WName").Value = Frm.WName.Text
            cmdSave.Parameters.Add("@PID", SqlDbType.VarChar)
            cmdSave.Parameters("@PID").Value = Frm.LblPeriod.Text
            cmdSave.Parameters.Add("@Remarks", SqlDbType.NVarChar)
            cmdSave.Parameters("@Remarks").Value = Me.txtRemarks.Text
            cmdSave.Parameters.Add("@VKey", SqlDbType.SmallDateTime)
            cmdSave.Parameters("@VKey").Value = Me.dtRecieve.Value.Date.AddDays(3)
            cmdSave.Parameters.Add("@VPost", SqlDbType.Bit)
            cmdSave.Parameters("@VPost").Value = 0

            cmdSave.Parameters.Add("@Flag", SqlDbType.Bit)
            cmdSave.Parameters("@Flag").Value = EditValue

            ''''''''''''@Received Varchar(50)
            ''@paid varchar(50)
            ''''@Cheque varchar(50)

            cmdSave.Parameters.Add("@Received", SqlDbType.NVarChar)
            cmdSave.Parameters("@Received").Value = "Nil"

            cmdSave.Parameters.Add("@paid", SqlDbType.NVarChar)
            cmdSave.Parameters("@paid").Value = "Nil"

            cmdSave.Parameters.Add("@Cheque", SqlDbType.NVarChar)
            cmdSave.Parameters("@Cheque").Value = "Nil"

            ' MsgBox(Me.DtDate.Value.AddDays(3))


            If EditValue = 1 Then
                cmdSave.ExecuteNonQuery()

                GridSave()
                Trans.Commit()
                'Dim frmm As New FrmBox("Your Record has been saved successfully..")
                'frmm.ShowDialog()
            Else
                'If EditFlag = False Then
                '    MsgBox("Sorry :  you cannot do entry on wrong date..", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                '    Exit Sub
                'End If

                cmdSave.ExecuteNonQuery()
                DeleteGrid()
                GridSave()
                Trans.Commit()
                'MsgBox("Your Record has been Updated successfully..")
                'frmm.ShowDialog()
            End If

            'Module1.DatasetFill("Select * from VoucherMain where Vtype=N'" & GroupBox1.Text & "' and CompanyID=" & Frm.LBCompanyID.Text & " and PID=N'" & Frm.LblPeriod.Text & "'", "VoucherMain")
            'Call txtfill()
            'StatusMnu()


        Catch ex As Exception
            Trans.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub DeleteGrid()
        Dim cmdDelete As New SqlCommand

        '  If cn.State = ConnectionState.Closed Then cn.Open()
        cmdDelete.Connection = cn
        cmdDelete.Transaction = Trans
        cmdDelete.CommandType = CommandType.StoredProcedure
        cmdDelete.CommandText = "DeleteDetail"
        cmdDelete.Parameters.Add("@Vno", SqlDbType.NVarChar)
        cmdDelete.Parameters("@Vno").Value = Me.txtInvoiceNo.Text
        cmdDelete.ExecuteNonQuery()

    End Sub

    Sub GridSave()
        '   Try


        Dim a As Integer
        '  For a = 0 To DG.Rows.Count - 2
        Dim cmdSave As New SqlCommand
        cmdSave.Transaction = Trans
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmdSave.Connection = cn
        cmdSave.CommandType = CommandType.StoredProcedure
        cmdSave.CommandText = "SaveDetail"
        cmdSave.Parameters.Add("@Vno", SqlDbType.NVarChar)
        cmdSave.Parameters("@Vno").Value = Me.txtInvoiceNo.Text
        ''@VNo, @HeadID, @SubID, @Remarks, @ChequeNo, @ChequeDate, @Dr, @Cr
        cmdSave.Parameters.Add("@HeadID", SqlDbType.Char)
        cmdSave.Parameters("@HeadID").Value = PurchaseCode
        cmdSave.Parameters.Add("@SubID", SqlDbType.BigInt)
        cmdSave.Parameters("@SubID").Value = cmbCompanyName.SelectedValue
        cmdSave.Parameters.Add("@Remarks", SqlDbType.NVarChar)
        cmdSave.Parameters("@Remarks").Value = "From Purchase"
        cmdSave.Parameters.Add("@ChequeNo", SqlDbType.NVarChar)
        cmdSave.Parameters("@ChequeNo").Value = " "     '(IIf(IsNothing(DG.Rows(a).Cells(5).Value) = True, " ", DG.Rows(a).Cells(5).Value))
        cmdSave.Parameters.Add("@ChequeDate", SqlDbType.SmallDateTime)
        cmdSave.Parameters("@ChequeDate").Value = "01/01/1900"       '(IIf(IsDate(DG.Rows(a).Cells(6).Value) = False, "01/01/1900", DG.Rows(a).Cells(6).Value))
        cmdSave.Parameters.Add("@Dr", SqlDbType.Decimal)
        cmdSave.Parameters("@Dr").Value = TotalToPayToCompanyOnly
        cmdSave.Parameters.Add("@Cr", SqlDbType.Decimal)
        cmdSave.Parameters("@Cr").Value = 0


        cmdSave.ExecuteNonQuery()
        If EditValue = 1 Then
            Module1.InsertRecord("CompanyRecordDetail", "" & PurchaseID & ",'" & txtInvoiceNo.Text & "','" & Me.dtRecieve.Value.Date & "'," & Frm.LBCompanyID.Text & ",'" & PurchaseCode & "'," & cmbCompanyName.SelectedValue & "," & TotalToPayToCompanyOnly & ",0,'" & Frm.LblPeriod.Text & "'", Trans)
        End If
        '''''''''''''''''''''''''
        Dim cmdSave1 As New SqlCommand
        cmdSave1.Transaction = Trans
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmdSave1.Connection = cn
        cmdSave1.CommandType = CommandType.StoredProcedure
        cmdSave1.CommandText = "SaveDetail"
        cmdSave1.Parameters.Add("@Vno", SqlDbType.NVarChar)
        cmdSave1.Parameters("@Vno").Value = Me.txtInvoiceNo.Text
        ''@VNo, @HeadID, @SubID, @Remarks, @ChequeNo, @ChequeDate, @Dr, @Cr
        cmdSave1.Parameters.Add("@HeadID", SqlDbType.Char)
        cmdSave1.Parameters("@HeadID").Value = CashCode
        cmdSave1.Parameters.Add("@SubID", SqlDbType.BigInt)
        cmdSave1.Parameters("@SubID").Value = cmbCompanyName.SelectedValue
        cmdSave1.Parameters.Add("@Remarks", SqlDbType.NVarChar)
        cmdSave1.Parameters("@Remarks").Value = "From Purchase"
        cmdSave1.Parameters.Add("@ChequeNo", SqlDbType.NVarChar)
        cmdSave1.Parameters("@ChequeNo").Value = " "     '(IIf(IsNothing(DG.Rows(a).Cells(5).Value) = True, " ", DG.Rows(a).Cells(5).Value))
        cmdSave1.Parameters.Add("@ChequeDate", SqlDbType.SmallDateTime)
        cmdSave1.Parameters("@ChequeDate").Value = "01/01/1900"       '(IIf(IsDate(DG.Rows(a).Cells(6).Value) = False, "01/01/1900", DG.Rows(a).Cells(6).Value))
        cmdSave1.Parameters.Add("@Dr", SqlDbType.Decimal)
        cmdSave1.Parameters("@Dr").Value = 0
        cmdSave1.Parameters.Add("@Cr", SqlDbType.Decimal)
        cmdSave1.Parameters("@Cr").Value = Me.txtPaid.Text

        cmdSave1.ExecuteNonQuery()
        'Module1.InsertRecord("CompanyRecordDetail", "'" & txtInvoiceNo.Text & "','" & Me.dtRecieve.Value.ToShortDateString & "'," & Frm.LBCompanyID.Text & ",'" & CashCode & "'," & cmbCompanyName.SelectedValue & ",0," & txtPaid.Text & ",'" & Frm.LblPeriod.Text & "'", Trans)


        Dim cmdSave2 As New SqlCommand
        cmdSave2.Transaction = Trans
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmdSave2.Connection = cn
        cmdSave2.CommandType = CommandType.StoredProcedure
        cmdSave2.CommandText = "SaveDetail"
        cmdSave2.Parameters.Add("@Vno", SqlDbType.NVarChar)
        cmdSave2.Parameters("@Vno").Value = Me.txtInvoiceNo.Text
        ''@VNo, @HeadID, @SubID, @Remarks, @ChequeNo, @ChequeDate, @Dr, @Cr
        cmdSave2.Parameters.Add("@HeadID", SqlDbType.Char)
        cmdSave2.Parameters("@HeadID").Value = vCode
        cmdSave2.Parameters.Add("@SubID", SqlDbType.BigInt)
        cmdSave2.Parameters("@SubID").Value = Me.cmbCompanyName.SelectedValue
        cmdSave2.Parameters.Add("@Remarks", SqlDbType.NVarChar)
        cmdSave2.Parameters("@Remarks").Value = "From Purchase"
        cmdSave2.Parameters.Add("@ChequeNo", SqlDbType.NVarChar)
        cmdSave2.Parameters("@ChequeNo").Value = " "     '(IIf(IsNothing(DG.Rows(a).Cells(5).Value) = True, " ", DG.Rows(a).Cells(5).Value))
        cmdSave2.Parameters.Add("@ChequeDate", SqlDbType.SmallDateTime)
        cmdSave2.Parameters("@ChequeDate").Value = "01/01/1900"       '(IIf(IsDate(DG.Rows(a).Cells(6).Value) = False, "01/01/1900", DG.Rows(a).Cells(6).Value))
        cmdSave2.Parameters.Add("@Dr", SqlDbType.Decimal)
        cmdSave2.Parameters("@Dr").Value = 0
        cmdSave2.Parameters.Add("@Cr", SqlDbType.Decimal)
        cmdSave2.Parameters("@Cr").Value = txtBalance.Text

        cmdSave2.ExecuteNonQuery()

        '''''''''''''' This is for saving Expenses Ccode By Aziz
        Dim cmdSave3 As New SqlCommand
        cmdSave3.Transaction = Trans
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmdSave3.Connection = cn
        cmdSave3.CommandType = CommandType.StoredProcedure
        cmdSave3.CommandText = "SaveDetail"
        cmdSave3.Parameters.Add("@Vno", SqlDbType.NVarChar)
        cmdSave3.Parameters("@Vno").Value = Me.txtInvoiceNo.Text
        ''@VNo, @HeadID, @SubID, @Remarks, @ChequeNo, @ChequeDate, @Dr, @Cr
        cmdSave3.Parameters.Add("@HeadID", SqlDbType.Char)
        cmdSave3.Parameters("@HeadID").Value = ExpenseCode
        cmdSave3.Parameters.Add("@SubID", SqlDbType.BigInt)
        cmdSave3.Parameters("@SubID").Value = Me.cmbCompanyName.SelectedValue
        cmdSave3.Parameters.Add("@Remarks", SqlDbType.NVarChar)
        cmdSave3.Parameters("@Remarks").Value = "Expenses On Purchase"
        cmdSave3.Parameters.Add("@ChequeNo", SqlDbType.NVarChar)
        cmdSave3.Parameters("@ChequeNo").Value = " "     '(IIf(IsNothing(DG.Rows(a).Cells(5).Value) = True, " ", DG.Rows(a).Cells(5).Value))
        cmdSave3.Parameters.Add("@ChequeDate", SqlDbType.SmallDateTime)
        cmdSave3.Parameters("@ChequeDate").Value = "01/01/1900"       '(IIf(IsDate(DG.Rows(a).Cells(6).Value) = False, "01/01/1900", DG.Rows(a).Cells(6).Value))
        cmdSave3.Parameters.Add("@Dr", SqlDbType.Decimal)
        cmdSave3.Parameters("@Dr").Value = 0
        cmdSave3.Parameters.Add("@Cr", SqlDbType.Decimal)
        cmdSave3.Parameters("@Cr").Value = txtOtherExpenses.Text

        cmdSave3.ExecuteNonQuery()



        'Next


        '  Catch ex As Exception
        'MsgBox(ex.Message)
        'Trans.Rollback()

        'End Try


    End Sub

#End Region

#End Region

#Region " CONTEXT MENUS ..................."

    Private Sub MnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuNew.Click
        CMStatus()
        Status()
        Clear()
        DG.Columns("btnGrid").Visible = True

        If MnuSearch.Visible = False Then
            Label1.Visible = False
            cmbPurchaseInvoiceSearch.Visible = False
            MnuSearch.Visible = True
            Label28.Visible = False
            cmbCompanySearch.Visible = False
            MnuReturn.Visible = False
        End If

        MnuSearch.Enabled = False
        'I have written this back because the clear() cleared all the textboxes and if user doesn't pay and save it would give error.
        txtOtherExpenses.Text = 0
        txtPaid.Text = 0
    End Sub

    Private Sub MnuUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuUndo.Click

        CMStatus()
        Status()
        Clear()
        FillAllTXT()
        DfrmPurchasePayment.Var_FormIsOpen = False
        DfrmAdvancePaymentForReport.Close()
        WashUp()
        'MnuSearch.Enabled = True
        If cmbOrderNo.Enabled = True Then
            cmbOrderNo.Enabled = False
        End If

        If txtInvoiceNo.ReadOnly = False Then
            txtInvoiceNo.ReadOnly = True
        End If
        MnuSearch.Enabled = True
    End Sub

    Private Sub MnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSave.Click
        If txtInvoiceNo.Text = "" Or cmbOrderNo.Text = "" Or DG.Rows.Count = 0 Then
            MsgBox("PLEASE FILL THE REQUIRED FIELDS" & Chr(13) & " " & Chr(13) & "لطفآ خانه های ضرورت را پر کنید", MsgBoxStyle.Critical)
            Exit Sub
        Else
            SaveUpdatePurchaseMain()
            DfrmPurchasePayment.Var_FormIsOpen = False
            DfrmPurchasePayment.Close()
            DfrmOtherExpenses.Close()
        End If
    End Sub

    Private Sub MnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuEdit.Click
        If cmbOrderNo.Text = "" Then
            Exit Sub
        Else
            CMStatus()
            Status()
            EditValue = 0
            DG.Columns("btnGrid").Visible = True
            txtInvoiceNo.ReadOnly = True
            cmbOrderNo.Enabled = False
            'MnuSearch.Enabled = False

            If MnuSearch.Visible = False Then
                Label1.Visible = False
                cmbPurchaseInvoiceSearch.Visible = False
                Label28.Visible = False
                cmbCompanySearch.Visible = False
                MnuSearch.Visible = True
                MnuReturn.Visible = False
            End If

            MnuSearch.Enabled = False
        End If
    End Sub

    Private Sub MnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDelete.Click
        Dim a As VariantType
        If cmbOrderNo.Text = "" Then
            Exit Sub
        Else
            a = MsgBox("Are you Sure.?" & Chr(13) & "  " & Chr(13) & " آیا شما مطمئن هستید  ", MsgBoxStyle.YesNo)
            If a = vbYes Then
                cmd.CommandText = " Delete from PurchaseMain where PurchaseID = " & PurchaseID
                cmd.Connection = cn
                cmd.ExecuteNonQuery()

                cmd.CommandText = " Delete from PurchaseOtherExpenses where PurchaseID = " & PurchaseID
                cmd.Connection = cn
                cmd.ExecuteNonQuery()

                cmd.CommandText = " Delete from IGL where ID=" & PurchaseID & "  And Type='Purchase'"
                cmd.Connection = cn
                cmd.ExecuteNonQuery()

                cmd.CommandText = " Delete from VoucherMain where Vno='" & txtInvoiceNo.Text & "'"
                cmd.Connection = cn
                cmd.ExecuteNonQuery()

                cmd.CommandText = " Delete from CompanyRecordDetail where PurchaseID=" & PurchaseID
                cmd.Connection = cn
                cmd.ExecuteNonQuery()

                'MsgBox("THE RECORD HAS BEEN DELETED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & " ریکارد مذکور موفقانه فسخ شد ", MsgBoxStyle.Information)
                If cnt = ds.Tables("VuPurchaseMain").Rows.Count - 1 Then
                    cnt = cnt - 1
                End If
                If cnt <= 0 Then
                    Clear()
                End If
                Call FillAllTXT()
                lblMessage.Text = "ریکارد مذکور موفقانه حذف گردید "

                If MnuSearch.Visible = False Then
                    Label1.Visible = False
                    cmbPurchaseInvoiceSearch.Visible = False
                    MnuSearch.Visible = True
                    MnuReturn.Visible = False
                End If
            End If
        End If
    End Sub

    Private Sub MnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuExit.Click
        Me.Close()
        DfrmPurchaseQty.P = True
        DfrmPurchasePayment.Dispose()
        DfrmPurchasePayment.Close()
        DfrmPurchaseQty.Dispose()
        DfrmPurchaseQty.Close()
        Dim arr(ds.Tables.Count) As String
        Dim index As Integer = 0
        For Each datatbl As DataTable In ds.Tables
            If datatbl.TableName.StartsWith("TableOfRowNo") Then
                arr(index) = datatbl.TableName
                index = index + 1
            End If
        Next


        Dim intloop As Integer = 0
        Dim strTableName As String = ""
        For intloop = 0 To index - 1
            strTableName = arr(intloop)
            'MsgBox(strTableName)
            ds.Tables.Remove(strTableName)
        Next


        For Each dtt As DataTable In ds.Tables
            If dtt.TableName.StartsWith("TableOfRowNo") Then
                MsgBox(ds.Tables.IndexOf(dtt))
                ds.Tables.Remove(dtt)
            End If

        Next
    End Sub

#End Region

#Region "New experiment"
    Sub SavePurchaseSubDetailGrid()

        Dim cmdsaveGrid As New SqlCommand
        cmdsaveGrid.CommandType = CommandType.StoredProcedure
        cmdsaveGrid.CommandText = "OnlyInsertPurchaseSubDetail"
        cmdsaveGrid.Connection = cn
        Try

            For Each dtable As DataTable In ds.Tables
                If dtable.TableName = TableKaName_ForInsertion Then
                    For Each tr As DataRow In dtable.Rows

                        cmdsaveGrid.Parameters.Add("@PurchaseID", SqlDbType.Int).Value = PurchaseID 'tr("PurchaseID")  we better get Var_SaleID data here, althow in temporary table it is present,but in network it can be assigned to some other pc's record entry.
                        cmdsaveGrid.Parameters.Add("@DGSNo", SqlDbType.Int).Value = tr("DGSno")
                        cmdsaveGrid.Parameters.Add("@DGTransferredSNo", SqlDbType.Int).Value = tr("Sno")
                        cmdsaveGrid.Parameters.Add("@DGTransferredQty", SqlDbType.Decimal).Value = tr("Qty")
                        Try

                            If tr("trdate") = #12:00:00 AM# Then
                                Var_TransferDate = "01/01/1900"
                                cmdsaveGrid.Parameters.Add("@DGTransferredDate", SqlDbType.SmallDateTime).Value = Var_TransferDate

                            Else
                                Var_TransferDate = tr("trdate")
                                cmdsaveGrid.Parameters.Add("@DGTransferredDate", SqlDbType.SmallDateTime).Value = Var_TransferDate

                            End If

                        Catch ex As Exception
                            'Var_TransferDate = "01/01/1900"
                            'cmdsaveGrid.Parameters.Add("@DGTransferredDate", SqlDbType.SmallDateTime).Value = Var_TransferDate
                            Dim fahim As String
                            fahim = tr("trdate")
                            Dim hh() As String
                            hh = Split(fahim, "/")
                            Dim b As String

                            b = hh(1) & "/" & hh(0) & "/" & hh(2)

                            bChangedToTime = Convert.ToDateTime(b)
                            Var_TransferDate = bChangedToTime
                            cmdsaveGrid.Parameters.Add("@DGTransferredDate", SqlDbType.SmallDateTime).Value = Var_TransferDate
                            'MsgBox(bChangedToTime.ToString)
                            'MsgBox(b)
                        End Try
                        cmdsaveGrid.Parameters.Add("@ComputerName", SqlDbType.NVarChar).Value = Me.MyComputerName
                        cmdsaveGrid.Parameters.Add("@ComputerIP", SqlDbType.NVarChar).Value = Me.MyComputerIP


                        'Trans.Commit()
                        If cn.State = ConnectionState.Closed Then cn.Open()
                        cmdsaveGrid.ExecuteNonQuery()
                        cmdsaveGrid.Parameters.Clear()
                    Next
                End If
            Next
            If EditValue <> 1 Then
                For Each dtable As DataTable In ds.Tables
                    If dtable.TableName = TableKaName_ForInsertion Then

                        UpdateIGL()
                    End If
                Next
            End If
                    ' What I am doing here is that I am removing that temporary table which was created only because of this
                    ' row, so as everything is saved all the temporary tables will be removed from the dataset.
w:
                    If ds.Tables.Contains(TableKaName_ForInsertion) = True Then
                        ds.Tables.Remove(TableKaName_ForInsertion)

                        '                    datatable()
                    End If

        Catch ex As Exception
            'Trans.Rollback()
            GoTo w
        End Try
        'Sub SplitTheDate()

        '    End Sub

    End Sub
    Sub DeletePurchaseSubDetailGrid()

        Dim cmdDeleteSub As New SqlCommand
        cmdDeleteSub.CommandType = CommandType.StoredProcedure
        cmdDeleteSub.CommandText = "DeletePurchaseSubDetail"
        cmdDeleteSub.Connection = cn
        If EditValue = 1 Then
            'Dim VarNew_SaleID As Integer
            'VarNew_SaleID = Var_SaleID + 1
            'cmdsave.Parameters.Add("@SaleID", SqlDbType.Int).Value = VarNew_SaleID
            Exit Sub
        Else
            cmdDeleteSub.Parameters.Add("@PurchaseID", SqlDbType.Int).Value = PurchaseID
            cmdDeleteSub.Parameters.Add("@DGSNo", SqlDbType.Int).Value = Me.DG.Rows(a).Cells(0).Value
            cmdDeleteSub.ExecuteNonQuery()
        End If


    End Sub
#End Region

#Region " Navigations "
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        cnt = 0
        FillAllTXT()
        WashUp()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If cnt = 0 Then
            Exit Sub
            WashUp()
        Else
            cnt = cnt - 1
            FillAllTXT()
            WashUp()
        End If
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If cnt = ds.Tables("VuPurchaseMain").Rows.Count - 1 Then Exit Sub
        cnt = cnt + 1
        FillAllTXT()
        WashUp()
    End Sub
    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        cnt = ds.Tables("VuPurchaseMain").Rows.Count - 1
        FillAllTXT()
        WashUp()
    End Sub
#End Region

#Region " DATA GRID VIEW "
    Private Sub DG_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DG.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DG_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellValueChanged
        Try
            calc()
        Catch ex As Exception

        End Try


        Dim Total As Double = 0
        Try
            Total = Total + Val(DG.CurrentRow.Cells("DGPricePerCrtn").Value) * Val(DG.CurrentRow.Cells("DGRecQty").Value)
            DG.CurrentRow.Cells("DGPrice").Value = Total
        Catch ex As Exception
        End Try


        Try
            If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "btnGrid" Then
                txtBalance.Text = Val(txtToBePaid.Text) - Val(txtPaid.Text)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DTManForGrid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTManForGrid.KeyPress
        Try
            DG.CurrentRow.Cells("DGManDate").Value = DTManForGrid.Value.Date
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DTExpForGrid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTExpForGrid.KeyPress
        Try
            DG.CurrentRow.Cells("DGExpDate").Value = DTExpForGrid.Value.Date
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DG_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DG.RowsAdded
        Try

            DG.Rows(e.RowIndex).Cells("btnGrid").Value = "انتقال"

        Catch ex As Exception
        End Try
    End Sub

    Private Sub DG_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellClick
        'If DG.CurrentCell.ColumnIndex = 8 Then

        Try
            If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "btnGrid" Then


                'DfrmPurchaseQty.txtProdType.Text = ""
                'DfrmPurchaseQty.txtProdName.Text = ""
                'DfrmPurchaseQty.txtTotalQty.Text = ""
                'DfrmPurchaseQty.txtRemainingQty.Text = ""
                'DfrmPurchaseQty.txtTransferredQty.Text = ""
                'DfrmPurchaseQty.DGTransfer.Rows.Clear()
                DfrmPurchaseQty.txtProdType.Text = DG.CurrentRow.Cells("DGPType").FormattedValue
                DfrmPurchaseQty.txtProdName.Text = DG.CurrentRow.Cells("DGProductCode").FormattedValue
                DfrmPurchaseQty.txtTotalQty.Text = DG.CurrentRow.Cells("DGQty").Value
                'DfrmPurchaseQty.txtTransferredQty.Text = DG.CurrentRow.Cells(5).Value
                DfrmPurchaseQty.txtRemainingQty.Text = DG.CurrentRow.Cells("DGQty").Value
                DfrmPurchaseQty.Visible = True
                DfrmPurchaseQty.TopMost = True
                Dim RowNumberForConcatination As String = Me.DG.CurrentRow.Cells("DGSNO").Value
                CurrentRowKaTable = "TableOfRowNo " & RowNumberForConcatination

                If ds.Tables.Contains(CurrentRowKaTable) Then
                    ' MsgBox("apne table se bhar do")
                    DfrmPurchaseQty.DGTransfer.Rows.Clear()
                    Call DfrmPurchaseQty.GridFillFrom_CurrentRowKaTable()
                Else
                    ' I commented this because as the form was called to become visible, it automatically called that forms load,
                    ' so this GridFill was being called two time, no need for that.
                    DfrmPurchaseQty.GridFill()
                End If
            End If
        Catch ex As Exception
            'DfrmPurchaseQty.ShowDialog()
        End Try

    End Sub

    Private Sub DG_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DG.EditingControlShowing
        Try
            If DG.CurrentCell.ColumnIndex = 4 Then
                Dim ltxt As New TextBox
                ltxt = CType(e.Control, TextBox)
                AddHandler ltxt.KeyPress, AddressOf NumericKeys
            End If

            'Delegation for setting data in a cell without having to leave that cell.
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
    Private Sub DelegateCellData(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Me.DG.CurrentCell.Value = Me.ActiveControl.Text & e.KeyChar
    End Sub
#End Region

#Region " EVENTS ......................"

    Private Sub cmbOrderNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOrderNo.SelectedIndexChanged
        'If Search = False Then
        If Index = True Then
            Try
                Module1.DatasetFill("Select * from VuOrderMainForPurchase where OrderNo = N'" & cmbOrderNo.Text & "'", "VuOrderMainForPurchase")
                OrderID = ds.Tables("VuOrderMainForPurchase").Rows(0).Item("OrderID")
                cmbCompanyName.Text = ds.Tables("VuOrderMainForPurchase").Rows(0).Item("Name")
                txtPersonName.Text = ds.Tables("VuOrderMainForPurchase").Rows(0).Item("PersonName")
                txtJobTilte.Text = ds.Tables("VuOrderMainForPurchase").Rows(0).Item("JobTitle")
                GridFillOrder()
            Catch ex As Exception
            End Try
        End If
        'End If
    End Sub
    Private Sub btnPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPayment.Click
        If txtInvoiceNo.Text = "" Then
            MsgBox("PLEASE GIVE A VALID INVOICE NO", MsgBoxStyle.Critical)
            Exit Sub
        Else
            If EditValue <> 1 Then
                DfrmPurchasePayment.txtInvoice.Text = txtInvoiceNo.Text
                DfrmPurchasePayment.txtTotalToPay.Text = txtToBePaid.Text
                DfrmPurchasePayment.txtBalance.Text = txtToBePaid.Text
                DfrmPurchasePayment.Visible = True
                DfrmPurchasePayment.TopMost = True
                If DfrmPurchasePayment.Var_FormIsOpen = True Then
                    DfrmPurchasePayment.txtInvoice.Text = txtInvoiceNo.Text
                    DfrmPurchasePayment.txtTotalToPay.Text = txtToBePaid.Text
                    DfrmPurchasePayment.txtBalance.Text = txtToBePaid.Text
                Else
                    GridPaymentFill()
                End If
            Else
                If DfrmPurchasePayment.Var_FormIsOpen = True Then
                    DfrmPurchasePayment.txtInvoice.Text = txtInvoiceNo.Text
                    DfrmPurchasePayment.txtTotalToPay.Text = txtToBePaid.Text
                    DfrmPurchasePayment.txtBalance.Text = txtToBePaid.Text
                    DfrmPurchasePayment.Visible = True
                Else
                    DfrmPurchasePayment.txtInvoice.Text = txtInvoiceNo.Text
                    DfrmPurchasePayment.txtTotalToPay.Text = txtToBePaid.Text
                    DfrmPurchasePayment.txtBalance.Text = txtToBePaid.Text
                    DfrmPurchasePayment.DGDiag.Rows.Clear()
                    DfrmPurchasePayment.Visible = True
                    DfrmPurchasePayment.TopMost = True
                    DfrmPurchasePayment.Var_FormIsOpen = True
                End If
            End If
        End If
    End Sub
    Private Sub txtInvoiceNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInvoiceNo.KeyPress

        If KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.English()
        End If

        Try
            If txtInvoiceNo.Text = "" Then
                If e.KeyChar = Chr(32) Then
                    e.Handled = True
                End If
            End If
        Catch ex As Exception
        End Try
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
#End Region

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            If PurchaseID = 0 Then
                Exit Sub
            Else

                Module1.DatasetFill("Select * from RptVuPurchaseMain where PurchaseID=" & PurchaseID, "RptVuPurchaseMain")
                Module1.DatasetFill("Select Sum(Amount) as Amount from PurchaseOtherExpenses where PurchaseID=" & PurchaseID, "PurchaseOtherExpenses")

                Dim rpt As New RptPurchase
                'rpt.SetDataSource(Module1.ds.Tables("RptVuPurchaseMain"))
                rpt.SetDataSource(ds)
                frmRptSetup.CV.ReportSource = rpt
                Frm.RptShow()
                'Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnOtherExpenses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtherExpenses.Click

        If txtInvoiceNo.Text = "" Then
            MsgBox("PLEASE GIVE A VALID INVOICE NO", MsgBoxStyle.Critical)
            Exit Sub
        Else
            If EditValue <> 1 Then
                'DfrmOtherExpenses.txtInvoice.Text = txtInvoiceNo.Text
                DfrmOtherExpenses.Visible = True
                DfrmOtherExpenses.TopMost = True
                If DfrmOtherExpenses.Var_FormIsOpen = True Then
                    'DfrmOtherExpenses.Visible = True
                Else
                    GridOtherExpensesFill()
                End If
            Else
                If DfrmOtherExpenses.Var_FormIsOpen = True Then
                    DfrmOtherExpenses.Visible = True
                Else
                    DfrmOtherExpenses.txtInvoice.Text = txtInvoiceNo.Text
                    DfrmOtherExpenses.txtTotal.Text = ""
                    DfrmOtherExpenses.DGDiag.Rows.Clear()
                    'DfrmPurchasePayment.ShowDialog()
                    DfrmOtherExpenses.Visible = True
                    DfrmOtherExpenses.TopMost = True
                    DfrmOtherExpenses.Var_FormIsOpen = True
                End If
            End If
        End If
    End Sub

    Private Sub txtOtherExpenses_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOtherExpenses.TextChanged
        Try
            txtTotalAll.Text = Val(txtToBePaid.Text) + Val(txtOtherExpenses.Text)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtToBePaid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtToBePaid.TextChanged

        Try
            txtTotalAll.Text = Val(txtToBePaid.Text) + Val(txtOtherExpenses.Text)
            txtBalance.Text = Val(txtToBePaid.Text) - Val(txtPaid.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSearch.Click
        Try

            Module1.DatasetFill("Select VID,Name from VuVendorForSearchPurchase", "VuVendorForSearchPurchase")
            cmbCompanySearch.DataSource = ds.Tables("VuVendorForSearchPurchase")
            cmbCompanySearch.DisplayMember = ("Name")
            cmbCompanySearch.ValueMember = ("VID")

            Clear()

            Label1.Visible = True
            cmbPurchaseInvoiceSearch.Visible = True
            Label28.Visible = True
            cmbCompanySearch.Visible = True

            MnuReturn.Visible = True
            MnuSearch.Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MnuReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuReturn.Click
        If DG.Rows.Count = 0 And cmbOrderNo.Text = "" Then
            FillAllTXT()
        End If
        cmbPurchaseInvoiceSearch.Visible = False
        Label1.Visible = False
        Label28.Visible = False
        cmbCompanySearch.Visible = False

        MnuSearch.Visible = True
        MnuReturn.Visible = False
    End Sub

    Private Sub cmbPurchaseInvoiceSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbPurchaseInvoiceSearch.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Module1.DatasetFill("Select * from VuPurchaseMain", "VuPurchaseMain")
                Dim Var_numberOfOccurance As Integer = 0
                Dim Var_PostionFound As Integer = 0
                Dim Var_loopLength As Integer = 0
                Dim Var_LetAssignment As Boolean = True
                For Each dtr As DataRow In ds.Tables("VuPurchaseMain").Rows
                    If cmbPurchaseInvoiceSearch.SelectedValue = dtr("PurchaseID") Then
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
                    ' Module1.DatasetFill("Select * from VuPurchaseMain where PurchaseID=" & cmbPurchaseInvoiceSearch.SelectedValue, "VuPurchaseMain")
                    lblMessage.Text = ""
                    Module1.DatasetFill("Select OrderID,OrderNo from OrderMain ", "OrderMain")
                    cmbOrderNo.DataSource = ds.Tables("OrderMain")
                    cmbOrderNo.DisplayMember = ("OrderNo")
                    cmbOrderNo.ValueMember = ("OrderID")
                    cmbOrderNo.SelectedIndex = -1
                    PurchaseID = ds.Tables("VuPurchaseMain").Rows(cnt).Item("PurchaseID")
                    txtInvoiceNo.Text = ds.Tables("VuPurchaseMain").Rows(cnt).Item("InvoiceNo")
                    cmbOrderNo.Text = ds.Tables("VuPurchaseMain").Rows(cnt).Item("OrderNo")
                    cmbCompanyName.Text = ds.Tables("VuPurchaseMain").Rows(cnt).Item("Name")
                    OrderID = ds.Tables("VuPurchaseMain").Rows(cnt).Item("OrderID")
                    txtPersonName.Text = ds.Tables("VuPurchaseMain").Rows(cnt).Item("PersonName")
                    txtJobTilte.Text = ds.Tables("VuPurchaseMain").Rows(cnt).Item("JobTitle")
                    dtOrder.Value = ds.Tables("VuPurchaseMain").Rows(cnt).Item("ShipDate")
                    dtRecieve.Value = ds.Tables("VuPurchaseMain").Rows(cnt).Item("RecDate")
                    txtOtherExpenses.Text = ds.Tables("VuPurchaseMain").Rows(cnt).Item("Expenses")
                    txtToBePaid.Text = ds.Tables("VuPurchaseMain").Rows(cnt).Item("TotalToPay")
                    txtPaid.Text = ds.Tables("VuPurchaseMain").Rows(cnt).Item("TotalPaid")
                    txtBalance.Text = ds.Tables("VuPurchaseMain").Rows(cnt).Item("Balance")
                    txtTotalQty.Text = ds.Tables("VuPurchaseMain").Rows(cnt).Item("TotalQty")
                    txtRemarks.Text = ds.Tables("VuPurchaseMain").Rows(cnt).Item("Description")
                    FILLALLGRID()

                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbPurchaseInvoiceSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbPurchaseInvoiceSearch.KeyPress
        If KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.English()
        End If
    End Sub

    Private Sub cmbCompanySearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCompanySearch.SelectedIndexChanged
        Try
            Module1.DatasetFill("Select PurchaseID,InvoiceNo from PurchaseMain where VID=" & cmbCompanySearch.SelectedValue, "PurchaseMain")
            cmbPurchaseInvoiceSearch.DataSource = ds.Tables("PurchaseMain")
            cmbPurchaseInvoiceSearch.DisplayMember = ("InvoiceNo")
            cmbPurchaseInvoiceSearch.ValueMember = ("PurchaseID")
        Catch ex As Exception
        End Try
    End Sub
End Class