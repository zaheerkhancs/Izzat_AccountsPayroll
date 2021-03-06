Imports System.Data.SqlClient
Imports System.IO
Imports LanguageSelector
Public Class frmDamages
    Dim Var_DamageID As Integer
    Dim CurrowIndex As Integer
    Dim CityID As Integer
    Dim CityBasedID As String
    Dim EditValue As Integer
    Dim a As Integer
    Dim cnt As Integer
    Dim StrSearch As String
    Dim ComboIsfilly As Boolean = True
    Dim AddEdit As Boolean = False
    Dim k As Integer

    Private Sub frmDamages_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False

        'TC.Left = pnlcentre.Width / 2 - (TC.Width / 2)
        'TC.Top = pnlcentre.Height / 2 - (TC.Height / 2)
        'pnlcentre.Left = Me.Width / 2 - (pnlcentre.Width / 2)
        'pnlcentre.Top = Me.Height / 2 - (pnlcentre.Height / 2)

        Module1.Opencn()
        CityID = Frm.lbLocationID.Text
        CityBasedID = Frm.lbLocationName.Text
        Module1.DatasetFill("Select * from CustomerType", "CustomerType")
        Call ComboFillerOfFahimshekaib(cmbCustomerType, "CustomerType", "CustomerTypeName", "CustomerTypeID")
        Call ComboFillerOfFahimshekaib(CmbCustomerTypeSearch, "CustomerType", "CustomerTypeName", "CustomerTypeID")

        Module1.DatasetFill("Select * from Customer", "Customer")
        Call ComboFillerOfFahimshekaib(cmbCustomerName, "Customer", "CustomerName", "CustomerID")

        Module1.DatasetFill("Select * from ProductType", "ProductType")
        Call ComboFillerOfFahimshekaib(DGPType, "ProductType", "ProdTypeName", "ProdTypeID")

        Module1.DatasetFill("Select * from VuProduct", "VuProduct")
        Call ComboFillerOfFahimshekaib(DGProductCode, "VuProduct", "Product", "ProdCode")

        Module1.DatasetFill("Select * from ProductType", "ProductType")
        Call ComboFillerOfFahimshekaib(CmbProductTypeSearch, "ProductType", "ProdTypeName", "ProdTypeID")

        Module1.DatasetFill("Select * from CartonPiece", "CartonPiece")
        Call ComboFillerOfFahimshekaib(DGCrtnPcs, "CartonPiece", "Name", "ID")
        'CmbProductTypeSearch.SelectedIndex = -1

        EditValue = 1
        dtDate.Value = Now

        Module1.DatasetFill("Select * from VuReturnForCombOnly", "VuReturnForCombOnly")

        For Each drow As DataRow In ds.Tables("VuReturnForCombOnly").Rows
            cmbInvoiceNo.Items.Add(drow(0))
        Next
        ComboIsfilly = False
        EmpPB.Image = My.Resources.IALResources.w
        fill()
        If Frm.GID.Text > 2 Then
            Module1.CMStatusDisable(CM)
        End If
    End Sub

#Region " FUNCTIONS ................ "
    Sub CMStatus()
        MnuNew.Enabled = Not MnuNew.Enabled
        MnuSave.Enabled = Not MnuSave.Enabled
        MnuUndo.Enabled = Not MnuUndo.Enabled
        MnuEdit.Enabled = Not MnuEdit.Enabled
        MnuDelete.Enabled = Not MnuDelete.Enabled
        MnuExit.Enabled = Not MnuExit.Enabled
    End Sub
    Sub CStatus()
        dtDates.Enabled = Not dtDates.Enabled
        txtRemarks.Enabled = Not txtRemarks.Enabled
        cmbInvoiceNo.Enabled = Not cmbInvoiceNo.Enabled
        RBUs.Enabled = Not RBUs.Enabled
        RBCustomer.Enabled = Not RBCustomer.Enabled
        DG.ReadOnly = Not DG.ReadOnly
        DGTotalQty.ReadOnly = True
        DGPrice.ReadOnly = True
        DGPcsInCrtn.ReadOnly = True
        DGPricePerCrtn.ReadOnly = True
        DGPricePerPcs.ReadOnly = True
        DGProductName.ReadOnly = True
    End Sub
    Public Sub CStatusDefault()
        cmbInvoiceNo.Enabled = False
        dtDates.Enabled = False
        cmbInvoiceNo.Enabled = False
        RBUs.Enabled = False
        RBCustomer.Enabled = False
        txtRemarks.Enabled = False
    End Sub
    Public Sub CMStatusDefault()
        MnuNew.Enabled = True
        MnuEdit.Enabled = True
        MnuSave.Enabled = False
        MnuDelete.Enabled = True
        MnuUndo.Enabled = False
    End Sub
    Sub Clear()
        lblMessage.Text = ""
        dtDates.Value = Now
        txtRemarks.Text = ""
        DG.Rows.Clear()

        DGProductCode.Visible = True
    End Sub
    Sub calc()
        Dim Total As Double = 0
        Dim TotalQty As Double = 0
        Dim aa As Integer
        Try
            For aa = 0 To DG.Rows.Count - 1
                Total = Total + Val(DG.Rows(aa).Cells("DGPrice").Value)
                TotalQty = TotalQty + Val(DG.Rows(aa).Cells("DGTotalQty").Value)
            Next
            Me.txtTotalToPay.Text = Total
            Me.txtTotalReturn.Text = TotalQty
        Catch ex As Exception
        End Try
    End Sub
    Sub CalcQty()
        Dim Total As Double = 0
        Dim TotalPrice As Double = 0
        Try
            Total = Total + Val(DG.CurrentRow.Cells("DGBroken").Value) + Val(DG.CurrentRow.Cells("DGLeak").Value) + Val(DG.CurrentRow.Cells("DGShort").Value) + Val(DG.CurrentRow.Cells("DGDent").Value) + Val(DG.CurrentRow.Cells("DGExpired").Value) + Val(DG.CurrentRow.Cells("DGDecayedBeforeExpiration").Value)
            DG.CurrentRow.Cells("DgTotalQty").Value = Total
        Catch ex As Exception
        End Try
    End Sub
    Private Sub NumericKeys(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If DG.CurrentCell.ColumnIndex = 8 Or DG.CurrentCell.ColumnIndex = 9 Or DG.CurrentCell.ColumnIndex = 10 Or DG.CurrentCell.ColumnIndex = 11 Or DG.CurrentCell.ColumnIndex = 12 Then
            If IsNumeric(Me.ActiveControl.Text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Then e.Handled = True
        End If
    End Sub
    Sub k1(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If DG.CurrentCell.ColumnIndex = 1 Then
                DG.CurrentRow.Cells(1).Value = sender.text
                Module1.DatasetFill("Select ProdCode,Product from VuProduct where ProdTypeName = N'" & DG.CurrentRow.Cells(1).Value & "'", "VuProduct")
                DGProductCode.DataSource = ds.Tables("VuProduct")
                DGProductCode.DisplayMember = ("Product")
                DGProductCode.ValueMember = ("ProdCode")
                CurrowIndex = DG.CurrentRow.Index
                DG.CurrentRow.Cells(3).Value = ""
                DG.CurrentRow.Cells(4).Value = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub K2(ByVal sender As Object, ByVal e As System.EventArgs)
        If DG.CurrentCell.ColumnIndex = 2 Then
            DG.CurrentRow.Cells(3).Value = sender.text
            DG.CurrentRow.Cells(4).Value = sender.selectedvalue
            CurrowIndex = DG.CurrentRow.Index
            If RBUs.Checked.Equals(True) Then
                Try
                    GridFillForPrice()
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub

    Sub SaveIGL()
        Dim MinusFromDGRowsCount As Integer
        Dim cmdsaveGridIGL As New SqlCommand
        cmdsaveGridIGL.CommandType = CommandType.StoredProcedure
        cmdsaveGridIGL.CommandText = "InsertIGL"
        cmdsaveGridIGL.Connection = cn
        If RBCustomer.Checked.Equals(True) Then
            MinusFromDGRowsCount = 1
        Else
            MinusFromDGRowsCount = 2
        End If
        Try
            For k = 0 To DG.Rows.Count - MinusFromDGRowsCount

                cmdsaveGridIGL.Parameters.Add("@ID", SqlDbType.Int)
                cmdsaveGridIGL.Parameters("@ID").Value = Var_DamageID

                cmdsaveGridIGL.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Me.dtDate.Value.Date
                cmdsaveGridIGL.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "Damage"
                cmdsaveGridIGL.Parameters.Add("@ProductType", SqlDbType.Int).Value = DG.Rows(k).Cells("DGPType").Value
                If RBCustomer.Checked = True Then
                    cmdsaveGridIGL.Parameters.Add("@ProductCode", SqlDbType.Int).Value = DG.Rows(k).Cells("DGProductCode").Value
                Else
                    cmdsaveGridIGL.Parameters.Add("@ProductCode", SqlDbType.Int).Value = DG.Rows(k).Cells("ID").Value
                End If
                cmdsaveGridIGL.Parameters.Add("@PurchaseQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@SaleQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@ReturnQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@ClaimQty", SqlDbType.Decimal).Value = 0

                cmdsaveGridIGL.Parameters.Add("@DamageQty", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DGTotalQty").Value)
                Dim Var As String = DG.Rows(k).Cells("DGCrtnPcs").Value
                If Var = "2" Or Var = "کارتن" Then
                    cmdsaveGridIGL.Parameters.Add("@CrtnPcs", SqlDbType.SmallInt).Value = Convert.ToInt16(ds.Tables("CartonPiece").Rows(1).Item("ID"))

                Else
                    cmdsaveGridIGL.Parameters.Add("@CrtnPcs", SqlDbType.SmallInt).Value = ds.Tables("CartonPiece").Rows(0).Item("ID")
                End If
                'cmdsaveGridIGL.Parameters.Add("@CrtnPcs", SqlDbType.SmallInt).Value = DG.Rows(k).Cells("DGCrtnPcs").Value
                cmdsaveGridIGL.Parameters.Add("@Broken", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DGBroken").Value)
                cmdsaveGridIGL.Parameters.Add("@Leak", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DGLeak").Value)
                cmdsaveGridIGL.Parameters.Add("@Short", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DGShort").Value)
                cmdsaveGridIGL.Parameters.Add("@Dent", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DGDent").Value)
                cmdsaveGridIGL.Parameters.Add("@Expired", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DGExpired").Value)
                cmdsaveGridIGL.Parameters.Add("@DecayedBeforeExpiration", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DGDecayedBeforeExpiration").Value)
                cmdsaveGridIGL.Parameters.Add("@Etc", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DgEtc").Value)
                cmdsaveGridIGL.Parameters.Add("@Ok", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DGOk").Value)

                Try
                    If DG.Rows(k).Cells("DGDescription").Value = "" Then
                        cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = " "
                    Else
                        cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = DG.Rows(k).Cells("DGDescription").Value
                    End If
                Catch ex As Exception
                    cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = " "
                End Try

                cmdsaveGridIGL.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
                cmdsaveGridIGL.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & Var_DamageID

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
        Dim OldBroken As Decimal = 0
        Dim NewBroken As Decimal = 0
        Dim TotalBroken As Decimal = 0
        Dim OldLeak As Decimal = 0
        Dim NewLeak As Decimal = 0
        Dim TotalLeak As Decimal = 0
        Dim OldShort As Decimal = 0
        Dim NewShort As Decimal = 0
        Dim TotalShort As Decimal = 0
        Dim OldDent As Decimal = 0
        Dim NewDent As Decimal = 0
        Dim TotalDent As Decimal = 0
        Dim TotalExpired As Decimal = 0
        Dim OldExpired As Decimal = 0
        Dim NewExpired As Decimal = 0
        Dim TotalDecayedBeforeExpiration As Decimal = 0
        Dim OldDecayedBeforeExpiration As Decimal = 0
        Dim NewDecayedBeforeExpiration As Decimal = 0

        Dim cmdsaveGridIGL As New SqlCommand
        cmdsaveGridIGL.CommandType = CommandType.StoredProcedure
        cmdsaveGridIGL.CommandText = "InsertIGL"
        cmdsaveGridIGL.Connection = cn

        Try

            Module1.DatasetFill("Select Sum(DamageQty)as DamageQuantity from VuIGL where ID=" & Var_DamageID & " and ProductType =" & DG.Rows(a).Cells("DGPType").Value & " and ProductCode=" & DG.Rows(a).Cells("ID").Value & " And Type='Damage'", "VuIGL")
            OldQty = ds.Tables("VuIGL").Rows(0).Item("DamageQuantity")
            NewQty = Val(DG.Rows(a).Cells("DGTotalQty").Value)
            TotalQty = NewQty - OldQty
        Catch ex As Exception
        End Try

        If TotalQty = 0 Then
            Exit Sub
        End If


        Try

            Module1.DatasetFill("Select Sum(Broken)as BrokenQuantity from VuIGL where ID=" & Var_DamageID & " and ProductType =" & DG.Rows(a).Cells("DGPType").Value & " and ProductCode=" & DG.Rows(a).Cells("ID").Value & " And Type='Damage'", "VuIGL")
            OldBroken = ds.Tables("VuIGL").Rows(0).Item("BrokenQuantity")
            NewBroken = Val(DG.Rows(a).Cells("DGBroken").Value)
            TotalBroken = NewBroken - OldBroken
        Catch ex As Exception
        End Try

        Try

            Module1.DatasetFill("Select Sum(Leak)as LeakQuantity from VuIGL where ID=" & Var_DamageID & " and ProductType =" & DG.Rows(a).Cells("DGPType").Value & " and ProductCode=" & DG.Rows(a).Cells("ID").Value & " And Type='Damage'", "VuIGL")
            OldLeak = ds.Tables("VuIGL").Rows(0).Item("LeakQuantity")
            NewLeak = Val(DG.Rows(a).Cells("DGLeak").Value)
            TotalLeak = NewLeak - OldLeak
        Catch ex As Exception
        End Try

        Try

            Module1.DatasetFill("Select Sum(Short)as ShortQuantity from VuIGL where ID=" & Var_DamageID & " and ProductType =" & DG.Rows(a).Cells("DGPType").Value & " and ProductCode=" & DG.Rows(a).Cells("ID").Value & " And Type='Damage'", "VuIGL")
            OldShort = ds.Tables("VuIGL").Rows(0).Item("ShortQuantity")
            NewShort = Val(DG.Rows(a).Cells("DGShort").Value)
            TotalShort = NewShort - OldShort
        Catch ex As Exception
        End Try

        Try

            Module1.DatasetFill("Select Sum(Dent)as DentQuantity from VuIGL where ID=" & Var_DamageID & " and ProductType =" & DG.Rows(a).Cells("DGPType").Value & " and ProductCode=" & DG.Rows(a).Cells("ID").Value & " And Type='Damage'", "VuIGL")
            OldDent = ds.Tables("VuIGL").Rows(0).Item("DentQuantity")
            NewDent = Val(DG.Rows(a).Cells("DGDent").Value)
            TotalDent = NewDent - OldDent
        Catch ex As Exception
        End Try

        Try

            Module1.DatasetFill("Select Sum(Expired)as ExpiredQuantity from VuIGL where ID=" & Var_DamageID & " and ProductType =" & DG.Rows(a).Cells("DGPType").Value & " and ProductCode=" & DG.Rows(a).Cells("DGProductCode").Value & " And Type='Claim'", "VuIGL")
            OldExpired = ds.Tables("VuIGL").Rows(0).Item("ExpiredQuantity")
            NewExpired = Val(DG.Rows(a).Cells("DGExpired").Value)
            TotalExpired = NewExpired - OldExpired
        Catch ex As Exception
        End Try

        Try

            Module1.DatasetFill("Select Sum(DecayedBeforeExpiration)as DecayedBeforeExpirationQuantity from VuIGL where ID=" & Var_DamageID & " and ProductType =" & DG.Rows(a).Cells("DGPType").Value & " and ProductCode=" & DG.Rows(a).Cells("DGProductCode").Value & " And Type='Claim'", "VuIGL")
            OldDecayedBeforeExpiration = ds.Tables("VuIGL").Rows(0).Item("DecayedBeforeExpirationQuantity")
            NewDecayedBeforeExpiration = Val(DG.Rows(a).Cells("DGDecayedBeforeExpiration").Value)
            TotalDecayedBeforeExpiration = NewDecayedBeforeExpiration - OldDecayedBeforeExpiration
        Catch ex As Exception
        End Try

        Try
            For k = 0 To 1 - 1

                cmdsaveGridIGL.Parameters.Add("@ID", SqlDbType.Int)
                cmdsaveGridIGL.Parameters("@ID").Value = Var_DamageID
                cmdsaveGridIGL.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = dtDate.Value.Date
                cmdsaveGridIGL.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "Damage"
                cmdsaveGridIGL.Parameters.Add("@ProductType", SqlDbType.Int).Value = DG.Rows(a).Cells("DGPType").Value
                cmdsaveGridIGL.Parameters.Add("@ProductCode", SqlDbType.Int).Value = DG.Rows(a).Cells("ID").Value
                cmdsaveGridIGL.Parameters.Add("@PurchaseQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@SaleQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@ReturnQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@ClaimQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@DamageQty", SqlDbType.Decimal).Value = TotalQty

                Dim Var As String = DG.Rows(k).Cells("DGCrtnPcs").Value
                If Var = "2" Or Var = "کارتن" Then
                    cmdsaveGridIGL.Parameters.Add("@CrtnPcs", SqlDbType.SmallInt).Value = ds.Tables("CartonPiece").Rows(1).Item("ID")
                Else
                    cmdsaveGridIGL.Parameters.Add("@CrtnPcs", SqlDbType.SmallInt).Value = ds.Tables("CartonPiece").Rows(0).Item("ID")
                End If

                'cmdsaveGridIGL.Parameters.Add("@CrtnPcs", SqlDbType.SmallInt).Value = Val(DG.Rows(k).Cells("DGCrtnPcs").Value)
                cmdsaveGridIGL.Parameters.Add("@Broken", SqlDbType.Decimal).Value = TotalBroken
                cmdsaveGridIGL.Parameters.Add("@Leak", SqlDbType.Decimal).Value = TotalLeak
                cmdsaveGridIGL.Parameters.Add("@Short", SqlDbType.Decimal).Value = TotalShort
                cmdsaveGridIGL.Parameters.Add("@Dent", SqlDbType.Decimal).Value = TotalDent
                cmdsaveGridIGL.Parameters.Add("@Expired", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DGExpired").Value)
                cmdsaveGridIGL.Parameters.Add("@DecayedBeforeExpiration", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DGDecayedBeforeExpiration").Value)

                Try
                    If DG.Rows(a).Cells("DGDescription").Value = "" Then
                        cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = " "
                    Else
                        cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = DG.Rows(a).Cells("DGDescription").Value
                    End If
                Catch ex As Exception
                    cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = " "
                End Try


                'cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = "Purchase"
                cmdsaveGridIGL.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
                cmdsaveGridIGL.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & Var_DamageID

                cmdsaveGridIGL.ExecuteNonQuery()
                cmdsaveGridIGL.Parameters.Clear()
            Next
        Catch ex As Exception
        End Try


    End Sub

    Sub IDPICKER()
        Module1.DatasetFill("Select * from DamageMain", "DamageMain")
        cmd.CommandText = "Select isnull(Max(DamID),0) from DamageMain"
        Var_DamageID = cmd.ExecuteScalar + 1
    End Sub
    Sub SaveUpdateDamageMainCustomer()

        Try
            'If EditValue.Equals(1) Then

            '    If cmbInvoiceNo.Visible.Equals(True) Then


            '        Module1.DatasetFill("Select * from VuReturnForComboOnlyCheckForDuplicateEntry where InvoiceNo='" & cmbInvoiceNo.Text & "'", "VuReturnForComboOnlyCheckForDuplicateEntry")
            '        If ds.Tables("VuReturnForComboOnlyCheckForDuplicateEntry").Rows.Count.Equals(1) Then
            '            MsgBox("Duplicate entry for same Invoice No is not allowed, but u can edit it")
            '            Exit Sub
            '        End If
            '    End If

            'End If
            Dim cmdsave As New SqlCommand

            cmdsave.CommandType = CommandType.StoredProcedure
            cmdsave.CommandText = "InsertUpdateDamageMain"
            cmdsave.Connection = cn


            If EditValue = 1 Then
                IDPICKER()
            End If
            ' This is main sectiond data so there is no for loop etc.
            cmdsave.Parameters.Add("@DamID", SqlDbType.Int).Value = Var_DamageID
            cmdsave.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Me.dtDates.Value.Date
            cmdsave.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = txtRemarks.Text.Trim()
            If RBCustomer.Checked = True Then
                cmdsave.Parameters.Add("@RBFrom", SqlDbType.Bit).Value = 1
                cmdsave.Parameters.Add("@InvoiceNo", SqlDbType.NVarChar).Value = Me.cmbInvoiceNo.Text
                cmdsave.Parameters.Add("@CustomerTypeID", SqlDbType.Int).Value = Me.cmbCustomerType.SelectedValue
                cmdsave.Parameters.Add("@CustomerID", SqlDbType.Int).Value = Me.cmbCustomerName.SelectedValue

            Else
                cmdsave.Parameters.Add("@RBFrom", SqlDbType.Bit).Value = 0
                cmdsave.Parameters.Add("@InvoiceNo", SqlDbType.NVarChar).Value = "999999"
                cmdsave.Parameters.Add("@CustomerTypeID", SqlDbType.Int).Value = "999999"
                cmdsave.Parameters.Add("@CustomerID", SqlDbType.Int).Value = "999999"

            End If

            cmdsave.Parameters.Add("@TotalQty", SqlDbType.Decimal).Value = Me.txtTotalToPay.Text
            cmdsave.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = Me.txtTotalReturn.Text

            cmdsave.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
            cmdsave.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & Var_DamageID
            cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = EditValue

            cmdsave.ExecuteNonQuery()
            cmdsave.Parameters.Clear()

            AddEdit = False ' It means that saving or updation is successful and now we need to assign it false before calling fill().

            If EditValue = 1 Then
                SaveUpdateDamageDetail()
                SaveIGL()
                CMStatus()
                CStatus()

                'fill()
                lblMessage.Text = "ریکارد شما موفقانه ثبت گردید"
                'MsgBox("THE RECORD HAS BEEN SAVED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & "ریکارد شما موفقانه ثبت گردید", MsgBoxStyle.Information)
            Else
                DeleteDamageDetail()
                SaveUpdateDamageDetail()
                CMStatus()
                CStatus()
                fill()
                lblMessage.Text = "ریکارد شما موفقانه تجدید گردید"
                'MsgBox("THE RECORD HAS BEEN UPDATED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & "ریکارد شما موفقانه تنظیم گردید", MsgBoxStyle.Information)
                EditValue = 1
            End If

        Catch ex As Exception
        End Try
    End Sub
    Sub DeleteDamageDetail()
        Dim cmdDelete As New SqlCommand
        cmdDelete.Connection = cn
        cmdDelete.Transaction = Trans
        cmdDelete.CommandType = CommandType.StoredProcedure
        cmdDelete.CommandText = "DeleteDamageDetail"
        cmdDelete.Parameters.Add("@DamID", SqlDbType.Int).Value = Var_DamageID
        cmdDelete.ExecuteNonQuery()
    End Sub
    Sub SaveUpdateDamageDetail()
        Dim MinusFromDGRowsCount As Integer
        Dim cmdsaveGrid As New SqlCommand
        cmdsaveGrid.CommandType = CommandType.StoredProcedure
        cmdsaveGrid.CommandText = "InsertUpdateDamageDetail"
        cmdsaveGrid.Connection = cn
        Try
            If RBCustomer.Checked.Equals(True) Then
                MinusFromDGRowsCount = 1
            Else
                MinusFromDGRowsCount = 2
            End If
            For a = 0 To DG.Rows.Count - MinusFromDGRowsCount
                cmdsaveGrid.Parameters.Add("@DamID", SqlDbType.Int)
                cmdsaveGrid.Parameters("@DamID").Value = Var_DamageID


                cmdsaveGrid.Parameters.Add("@SNO", SqlDbType.Int).Value = DG.Rows(a).Cells("DGSno").Value
                cmdsaveGrid.Parameters.Add("@ProdTypeID", SqlDbType.Int).Value = DG.Rows(a).Cells("DGPType").Value
                If RBCustomer.Checked = True Then
                    cmdsaveGrid.Parameters.Add("@ProdCode", SqlDbType.Int).Value = DG.Rows(a).Cells("DGProductCode").Value
                Else
                    cmdsaveGrid.Parameters.Add("@ProdCode", SqlDbType.Int).Value = DG.Rows(a).Cells("ID").Value
                End If
                cmdsaveGrid.Parameters.Add("@PcsInCrtn", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGPcsInCrtn").Value
                cmdsaveGrid.Parameters.Add("@PricePerPcs", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGPricePerPcs").Value
                cmdsaveGrid.Parameters.Add("@PricePerCrtn", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGPricePerCrtn").Value
                'cmdsaveGrid.Parameters.Add("@CartonPiece", SqlDbType.SmallInt).Value = DG.Rows(a).Cells("DGCrtnPcs").Value
                Dim Var As String = DG.Rows(a).Cells("DGCrtnPcs").Value
                If Var = "2" Or Var = "کارتن" Then
                    cmdsaveGrid.Parameters.Add("@CartonPiece", SqlDbType.SmallInt).Value = ds.Tables("CartonPiece").Rows(1).Item("ID")

                Else
                    cmdsaveGrid.Parameters.Add("@CartonPiece", SqlDbType.SmallInt).Value = ds.Tables("CartonPiece").Rows(0).Item("ID")
                End If
                '' cmdsaveGrid.Parameters.Add("@CartonPiece", SqlDbType.SmallInt).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGCrtnPcs").Value)
                cmdsaveGrid.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGQty").Value)
                cmdsaveGrid.Parameters.Add("@Broken", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGBroken").Value)
                cmdsaveGrid.Parameters.Add("@Leak", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGLeak").Value)
                cmdsaveGrid.Parameters.Add("@Short", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGShort").Value)
                cmdsaveGrid.Parameters.Add("@Dent", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGDent").Value)
                cmdsaveGrid.Parameters.Add("@Expired", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGExpired").Value)
                cmdsaveGrid.Parameters.Add("@DecayedBeforeExpiration", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGDecayedBeforeExpiration").Value)
                cmdsaveGrid.Parameters.Add("@TotalQty", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGTotalQty").Value)
                cmdsaveGrid.Parameters.Add("@Price", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DgPrice").Value)
                If DG.Rows(a).Cells("DgDescription").Value = "" Then
                    cmdsaveGrid.Parameters.Add("@ReturnReason", SqlDbType.NVarChar).Value = " "
                Else
                    cmdsaveGrid.Parameters.Add("@ReturnReason", SqlDbType.NVarChar).Value = DG.Rows(a).Cells("DgDescription").Value
                End If


                If RBCustomer.Checked.Equals(True) Then
                    cmdsaveGrid.Parameters.Add("@ReturnDate", SqlDbType.SmallDateTime).Value = DG.Rows(a).Cells("DGReturnDate").Value

                Else
                    cmdsaveGrid.Parameters.Add("@ReturnDate", SqlDbType.SmallDateTime).Value = dtDates.Value.Date

                End If
                cmdsaveGrid.ExecuteNonQuery()
                cmdsaveGrid.Parameters.Clear()

                If EditValue <> 1 Then
                    UpdateIGL()
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub GridFillForPrice()
        Try
            Module1.DatasetFill("Select PcsInCtrn,PricePerCrtn,PricePerPcs,SalPerPiece,SalPerCrtn from VuProductPrices where ProdTypeID = " & DG.CurrentRow.Cells("DGPType").Value & " and ProdCode =" & DG.CurrentRow.Cells("ID").Value & "", "VuProductPrices")
            DG.CurrentRow.Cells("DGPcsInCrtn").Value = ds.Tables("VuProductPrices").Rows(0).Item("PcsInCtrn")
            If RBUs.Checked = True Then
                DG.CurrentRow.Cells("DGPricePerPcs").Value = ds.Tables("VuProductPrices").Rows(0).Item("PricePerPcs")
                DG.CurrentRow.Cells("DGPricePerCrtn").Value = ds.Tables("VuProductPrices").Rows(0).Item("PricePerCrtn")
            ElseIf RBCustomer.Checked = True Then
                DG.CurrentRow.Cells("DGPricePerPcs").Value = ds.Tables("VuProductPrices").Rows(0).Item("SalPerPiece")
                DG.CurrentRow.Cells("DGPricePerCrtn").Value = ds.Tables("VuProductPrices").Rows(0).Item("SalPerCrtn")
            End If
            
        Catch ex As Exception
        End Try
    End Sub

    Sub fill()
        Try

            lblMessage.Text = ""
            If cnt < 0 Then
                cnt = 0
            End If
            Module1.DatasetFill("Select * from VuDamageMain", "VuDamageMain")
            If ds.Tables("VuDamageMain").Rows.Count = 0 Then
                Var_DamageID = 0
                Clear()
                RBUs.Checked = True
                Exit Sub
            End If

            DGProductCode.Visible = False
            Var_DamageID = ds.Tables("VuDamageMain").Rows(cnt).Item("DamID")
            dtDates.Value = ds.Tables("VuDamageMain").Rows(cnt).Item("dtDate")
            Dim RBValue As Boolean = ds.Tables("VuDamageMain").Rows(cnt).Item("RBFrom")
            If RBValue = True Then
                RBCustomer.Checked = True
                cmbInvoiceNo.Visible = True
                cmbCustomerType.Visible = True
                cmbCustomerName.Visible = True
                cmbInvoiceNo.Text = ds.Tables("VuDamageMain").Rows(cnt).Item("InvoiceNo")
                cmbCustomerType.SelectedValue = ds.Tables("VuDamageMain").Rows(cnt).Item("CustomerTypeID")
                cmbCustomerName.SelectedValue = ds.Tables("VuDamageMain").Rows(cnt).Item("CustomerID")
            Else
                RBUs.Checked = True
                cmbInvoiceNo.Visible = False
                cmbCustomerType.Visible = False
                cmbCustomerName.Visible = False
            End If
            txtTotalToPay.Text = ds.Tables("VuDamageMain").Rows(cnt).Item("TotalQty")
            txtTotalReturn.Text = ds.Tables("VuDamageMain").Rows(cnt).Item("TotalAmount")
            txtRemarks.Text = ds.Tables("VuDamageMain").Rows(cnt).Item("Remarks")
            Call Gridfill()
        Catch ex As Exception
        End Try
    End Sub
    Sub Gridfill()
        Try

            Module1.DatasetFill("Select * from VuDamageDetail where DamId=" & Var_DamageID & "", "VuDamageDetail")

            DG.Rows.Clear()
            For a = 0 To ds.Tables("VuDamageDetail").Rows.Count - 1
                Try
                    DG.Rows.Add()
                    DG.Rows(a).Cells("DGSNo").Value = ds.Tables("VuDamageDetail").Rows(a).Item("SNo")
                    DG.Rows(a).Cells("DGPType").Value = ds.Tables("VuDamageDetail").Rows(a).Item("ProdTypeID")
                    DG.Rows(a).Cells("DGProductName").Value = ds.Tables("VuDamageDetail").Rows(a).Item("Product")
                    DG.Rows(a).Cells("DGProductCode").Value = ds.Tables("VuDamageDetail").Rows(a).Item("ProdCode")
                    DG.Rows(a).Cells("ID").Value = ds.Tables("VuDamageDetail").Rows(a).Item("ProdCode")
                    DG.Rows(a).Cells("DGPcsInCrtn").Value = ds.Tables("VuDamageDetail").Rows(a).Item("PcsInCrtn")
                    DG.Rows(a).Cells("DGPricePerPcs").Value = ds.Tables("VuDamageDetail").Rows(a).Item("PricePerPcs")
                    DG.Rows(a).Cells("DGPricePerCrtn").Value = ds.Tables("VuDamageDetail").Rows(a).Item("PricePerCrtn")
                    ' Dim x As Integer = ds.Tables("VuDamageDetail").Rows(a).Item("PricePerCrtn")

                    DG.Rows(a).Cells("DGCrtnPcs").Value = Convert.ToInt16(ds.Tables("VuDamageDetail").Rows(a).Item("CartonPiece"))
                    DG.Rows(a).Cells("DGCrtnPcs").Value = ds.Tables("VuDamageDetail").Rows(a).Item("CartonPiece")
                    ' this one is inverse of return. lol
                    If DG.Rows(a).Cells("DGCrtnPcs").FormattedValue = "1" Then
                        DG.Rows(a).Cells("DGCrtnPcs").Value = ds.Tables("CartonPiece").Rows(0).Item("ID")
                    Else
                        DG.Rows(a).Cells("DGCrtnPcs").Value = ds.Tables("CartonPiece").Rows(1).Item("ID")
                    End If
                    DG.Rows(a).Cells("DGQty").Value = ds.Tables("VuDamageDetail").Rows(a).Item("Qty")
                    DG.Rows(a).Cells("DGBroken").Value = ds.Tables("VuDamageDetail").Rows(a).Item("Broken")
                    DG.Rows(a).Cells("DGLeak").Value = ds.Tables("VuDamageDetail").Rows(a).Item("Leak")
                    DG.Rows(a).Cells("DGShort").Value = ds.Tables("VuDamageDetail").Rows(a).Item("Short")
                    DG.Rows(a).Cells("DGDent").Value = ds.Tables("VuDamageDetail").Rows(a).Item("Dent")
                    DG.Rows(a).Cells("DGTotalQty").Value = ds.Tables("VuDamageDetail").Rows(a).Item("TotalQty")
                    DG.Rows(a).Cells("DGPrice").Value = ds.Tables("VuDamageDetail").Rows(a).Item("Price")
                    DG.Rows(a).Cells("DGDescription").Value = ds.Tables("VuDamageDetail").Rows(a).Item("ReturnReason")
                    DG.Rows(a).Cells("DGReturnDate").Value = ds.Tables("VuDamageDetail").Rows(a).Item("ReturnDate")
                    DG.Rows(a).Cells("DGExpired").Value = ds.Tables("VuDamageDetail").Rows(a).Item("Expired")
                    DG.Rows(a).Cells("DGDecayedBeforeExpiration").Value = ds.Tables("VuDamageDetail").Rows(a).Item("DecayedBeforeExpiration")

                Catch ex As Exception
                End Try
            Next

        Catch ex As Exception
        End Try
    End Sub
    Sub GridFillFromVuReturnMainDetail()
        Try

            Module1.DatasetFill("Select * from VuReturnMainDetail where InvoiceNo='" & cmbInvoiceNo.Text & "' And Status=1", "VuReturnMainDetail")

            DG.Rows.Clear()
            For a = 0 To ds.Tables("VuReturnMainDetail").Rows.Count - 1
                Try
                    DG.Rows.Add()
                    DG.Rows(a).Cells("DGSNo").Value = ds.Tables("VuReturnMainDetail").Rows(a).Item("SNo")
                    DG.Rows(a).Cells("DGPType").Value = ds.Tables("VuReturnMainDetail").Rows(a).Item("ProdTypeID")
                    DG.Rows(a).Cells("DGProductName").Value = ds.Tables("VuReturnMainDetail").Rows(a).Item("Product")
                    DG.Rows(a).Cells("DGProductCode").Value = ds.Tables("VuReturnMainDetail").Rows(a).Item("ProdCode")
                    DG.Rows(a).Cells("DGPcsInCrtn").Value = ds.Tables("VuReturnMainDetail").Rows(a).Item("PcsInCrtn")
                    DG.Rows(a).Cells("DGPricePerPcs").Value = ds.Tables("VuReturnMainDetail").Rows(a).Item("PricePerPcs")
                    DG.Rows(a).Cells("DGPricePerCrtn").Value = ds.Tables("VuReturnMainDetail").Rows(a).Item("PricePerCrtn")
                    DG.Rows(a).Cells("DGCrtnPcs").Value = ds.Tables("VuReturnMainDetail").Rows(a).Item("CartonPiece")
                    'MsgBox(DGCrtnPcs.Items.Count)
                    DG.Rows(a).Cells("DGCrtnPcs").Value = ds.Tables("VuReturnMainDetail").Rows(0).Item("CartonPiece")

                    If DG.Rows(a).Cells("DGCrtnPcs").FormattedValue = "1" Then
                        DG.Rows(a).Cells("DGCrtnPcs").Value = ds.Tables("CartonPiece").Rows(0).Item("Name")
                    Else
                        DG.Rows(a).Cells("DGCrtnPcs").Value = ds.Tables("CartonPiece").Rows(1).Item("Name")
                    End If
                    DG.Rows(a).Cells("DGQty").Value = ds.Tables("VuReturnMainDetail").Rows(a).Item("Qty")
                    DG.Rows(a).Cells("DGBroken").Value = ds.Tables("VuReturnMainDetail").Rows(a).Item("Broken")
                    DG.Rows(a).Cells("DGLeak").Value = ds.Tables("VuReturnMainDetail").Rows(a).Item("Leak")
                    DG.Rows(a).Cells("DGShort").Value = ds.Tables("VuReturnMainDetail").Rows(a).Item("Short")
                    DG.Rows(a).Cells("DGDent").Value = ds.Tables("VuReturnMainDetail").Rows(a).Item("Dent")
                    DG.Rows(a).Cells("DGTotalQty").Value = ds.Tables("VuReturnMainDetail").Rows(a).Item("TotalQty")
                    DG.Rows(a).Cells("DGPrice").Value = ds.Tables("VuReturnMainDetail").Rows(a).Item("Price")
                    DG.Rows(a).Cells("DGDescription").Value = ds.Tables("VuReturnMainDetail").Rows(a).Item("ReturnReason")
                    DG.Rows(a).Cells("DGReturnDate").Value = ds.Tables("VuReturnMainDetail").Rows(a).Item("ReturnDate")
                    DG.Rows(a).Cells("DGExpired").Value = ds.Tables("VuReturnMainDetail").Rows(a).Item("Expired")
                    DG.Rows(a).Cells("DGDecayedBeforeExpiration").Value = ds.Tables("VuReturnMainDetail").Rows(a).Item("DecayedBeforeExpiration")

                Catch ex As Exception
                End Try
            Next

        Catch ex As Exception
        End Try
    End Sub
    Sub GridfillFromVuDamageDetail()
        Try

            Module1.DatasetFill("Select * from VuDamageDetail where DamID=" & Var_DamageID, "VuDamageDetail")
            If ds.Tables("VuDamageDetail").Rows.Count.Equals(0) Then Exit Sub
            DG.Rows.Clear()
            For a = 0 To ds.Tables("VuDamageDetail").Rows.Count - 1
                Try
                    DG.Rows.Add()
                    DG.Rows(a).Cells("DGSNo").Value = ds.Tables("VuDamageDetail").Rows(a).Item("SNo")
                    DG.Rows(a).Cells("DGPType").Value = ds.Tables("VuDamageDetail").Rows(a).Item("ProdTypeName")
                    DG.Rows(a).Cells("DGProductName").Value = ds.Tables("VuDamageDetail").Rows(a).Item("Product")
                    DG.Rows(a).Cells("DGPcsInCrtn").Value = ds.Tables("VuDamageDetail").Rows(a).Item("PcsInCrtn")
                    DG.Rows(a).Cells("DGPricePerPcs").Value = ds.Tables("VuDamageDetail").Rows(a).Item("PricePerPcs")
                    DG.Rows(a).Cells("DGPricePerCrtn").Value = ds.Tables("VuDamageDetail").Rows(a).Item("PricePerCrtn")
                    DG.Rows(a).Cells("DGQty").Value = ds.Tables("VuDamageDetail").Rows(a).Item("Qty")
                    DG.Rows(a).Cells("DGBroken").Value = ds.Tables("VuDamageDetail").Rows(a).Item("Broken")
                    DG.Rows(a).Cells("DGLeak").Value = ds.Tables("VuDamageDetail").Rows(a).Item("Leak")
                    DG.Rows(a).Cells("DGShort").Value = ds.Tables("VuDamageDetail").Rows(a).Item("Short")

                    DG.Rows(a).Cells("DGDent").Value = ds.Tables("VuDamageDetail").Rows(a).Item("Dent")
                    DG.Rows(a).Cells("DGTotalQty").Value = ds.Tables("VuDamageDetail").Rows(a).Item("TotalQty")
                    DG.Rows(a).Cells("DGPrice").Value = ds.Tables("VuDamageDetail").Rows(a).Item("Price")
                    DG.Rows(a).Cells("DGDescription").Value = ds.Tables("VuDamageDetail").Rows(a).Item("ReturnReason")
                    DG.Rows(a).Cells("DGReturnDate").Value = ds.Tables("VuDamageDetail").Rows(a).Item("ReturnDate")

                Catch ex As Exception
                End Try
            Next

        Catch ex As Exception
        End Try
    End Sub
    Sub GridFillSearch()
        Dim i As Integer
        Try
            DGSearch.Rows.Clear()
            cmd.Connection = cn
            da.SelectCommand = cmd
            cmd.CommandText = StrSearch
            If (ds.Tables.Contains("VuDamageSearchForAll")) Then
                ds.Tables("VuDamageSearchForAll").Clear()
                DGSearch.Rows.Clear()
            End If
            da.Fill(ds, "VuDamageSearchForAll")

            For i = 0 To ds.Tables("VuDamageSearchForAll").Rows.Count - 1
                Try
                    DGSearch.Rows.Add()
                    'DGSearch.Rows(a).Cells(0).Value = ds.Tables("VuDamageSearch").Rows(a).Item("SNo")

                    DGSearch.Rows(i).Cells("DGDateSearch").Value = ds.Tables("VuDamageSearchForAll").Rows(i).Item("ReturnDate")

                    If RbCustomerSearch.Checked = True Then
                        DGSearch.Rows(i).Cells("DGPTypeSearch").Value = ds.Tables("VuDamageSearchForAll").Rows(i).Item("ProdTypeName")
                        DGSearch.Rows(i).Cells("DGProdNameSearch").Value = ds.Tables("VuDamageSearchForAll").Rows(i).Item("Product")
                    End If

                    DGSearch.Rows(i).Cells("DGCrtnPcsSearch").Value = ds.Tables("VuDamageSearchForAll").Rows(i).Item("Name")
                    DGSearch.Rows(i).Cells("DGBrokenSearch").Value = ds.Tables("VuDamageSearchForAll").Rows(i).Item("Broken")
                    DGSearch.Rows(i).Cells("DGLeakSearch").Value = ds.Tables("VuDamageSearchForAll").Rows(i).Item("Leak")
                    DGSearch.Rows(i).Cells("DGShortSearch").Value = ds.Tables("VuDamageSearchForAll").Rows(i).Item("Short")
                    DGSearch.Rows(i).Cells("DGDentSearch").Value = ds.Tables("VuDamageSearchForAll").Rows(i).Item("Dent")

                    DGSearch.Rows(i).Cells("DGExpiredSearch").Value = ds.Tables("VuDamageSearchForAll").Rows(i).Item("Expired")
                    DGSearch.Rows(i).Cells("DGDecayedBeforeExpirationSearch").Value = ds.Tables("VuDamageSearchForAll").Rows(i).Item("DecayedBeforeExpiration")
                    DGSearch.Rows(i).Cells("DGTotalQtySearch").Value = ds.Tables("VuDamageSearchForAll").Rows(i).Item("TotalQty")
                    DGSearch.Rows(i).Cells("DGPriceSearch").Value = ds.Tables("VuDamageSearchForAll").Rows(i).Item("Price")
                    DGSearch.Rows(i).Cells("DGDescriptionSearch").Value = ds.Tables("VuDamageSearchForAll").Rows(i).Item("ReturnReason")

                Catch ex As Exception
                End Try
            Next
            btnPrint.Enabled = True
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region " Context Menu "
    Private Sub MnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuNew.Click
        Call CMStatus()
        Call CStatus()
        Call Clear()
        DG.ReadOnly = False
        If RBUs.Checked.Equals(True) Then
            DGProductCode.Visible = True
        Else
            DGProductCode.Visible = False
        End If
        DG.Rows.Clear()
        lblMessage.Text = ""
        EditValue = 1
        AddEdit = True
    End Sub
    Private Sub MnuUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuUndo.Click
        Call CMStatus()
        Call CStatus()
        EditValue = 1
        AddEdit = False
        Call fill()
    End Sub
    Private Sub MnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSave.Click
        SaveUpdateDamageMainCustomer()
    End Sub
    Private Sub MnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuEdit.Click
        CMStatus()
        CStatus()
        EditValue = 0
        AddEdit = True
        If RBUs.Checked.Equals(True) Then
            DGProductCode.Visible = True
        Else
            DGProductCode.Visible = False

        End If
    End Sub
    Private Sub MnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDelete.Click
        Dim a As VariantType
        a = MsgBox("Are you Sure.?" & Chr(13) & "  " & Chr(13) & " آیا شما مطمئن هستید  ", MsgBoxStyle.YesNo)
        If a = vbYes Then
            cmd.CommandText = " Delete from DamageMain where DamID = " & Var_DamageID
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

            cmd.CommandText = " Delete from IGL where ID=" & Var_DamageID & "  And Type='Damage'"
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

            'MsgBox("THE RECORD HAS BEEN DELETED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & " ریکارد مذکور موفقانه فسخ شد ", MsgBoxStyle.Information)
            If cnt = ds.Tables("VuDamageMain").Rows.Count - 1 Then
                cnt = cnt - 1
            End If
            If cnt < 0 Then
                Clear()
            End If
            Call fill()
            lblMessage.Text = "ریکارد مذکور موفقانه حذف گردید "
        End If
    End Sub
    Private Sub MnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuExit.Click
        Me.Close()
    End Sub
#End Region

#Region " Navigations "
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        cnt = 0
        Call fill()
        CMStatusDefault()
        CStatusDefault()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If cnt = 0 Then Exit Sub
        cnt = cnt - 1
        Call fill()
        CMStatusDefault()
        CStatusDefault()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If cnt = ds.Tables("VuDamageMain").Rows.Count - 1 Then Exit Sub
        cnt = cnt + 1
        Call fill()
        CMStatusDefault()
        CStatusDefault()
    End Sub
    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        cnt = ds.Tables("VuDamageMain").Rows.Count - 1
        Call fill()
        CMStatusDefault()
        CStatusDefault()
    End Sub
#End Region

#Region " Data Grid View "

    Private Sub DG_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellClick
        'DG.CurrentRow.Cells(0).Value = DG.CurrentRow.Index + 1
        'If DG.CurrentRow.Index = CurrowIndex Then
        '    DG.CurrentRow.Cells(2).ReadOnly = False
        '    DG.CurrentRow.Cells(1).ReadOnly = False
        'Else
        '    DG.CurrentRow.Cells(2).ReadOnly = True
        'End If
        DG.CurrentRow.Cells(0).Value = DG.CurrentRow.Index + 1

        If DG.CurrentRow.Index = CurrowIndex Then
            DG.CurrentRow.Cells(2).ReadOnly = False
            DG.CurrentRow.Cells(1).ReadOnly = False
        Else
            DG.CurrentRow.Cells(2).ReadOnly = True
        End If
    End Sub

    Private Sub DG_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellEnter
        Dim z As Integer = 0
        If DG.CurrentRow.Index = 0 And DG.CurrentCell.ColumnIndex = 0 Then
            z = DG.CurrentRow.Index + 1
        End If
        If DG.CurrentCell.ColumnIndex = 0 Then
            DG.CurrentRow.Cells(0).Value = z.ToString
        End If
        If DG.CurrentRow.Index <> 0 And DG.CurrentCell.ColumnIndex = 0 Then
            DG.CurrentRow.Cells(0).Value = DG.CurrentRow.Index + 1
        End If
    End Sub
    Private Sub DelegateCellData(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Me.DG.CurrentCell.Value = Me.ActiveControl.Text & e.KeyChar
    End Sub
    Private Sub DG_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DG.EditingControlShowing
        'DG.CurrentRow.Cells(0).Value = DG.CurrentRow.Index + 1
        'If DG.CurrentCell.ColumnIndex = 1 Then
        '    Try
        '        Dim cmb As ComboBox
        '        cmb = CType(e.Control, ComboBox)
        '        AddHandler cmb.SelectionChangeCommitted, AddressOf k1
        '    Catch ex As Exception
        '    End Try
        'End If
        'If DG.CurrentRow.Index = CurrowIndex Then
        '    Try
        '        Dim cmb As ComboBox
        '        cmb = CType(e.Control, ComboBox)
        '        AddHandler cmb.SelectionChangeCommitted, AddressOf K2

        '    Catch ex As Exception
        '    End Try
        'End If
        'If DG.CurrentCell.ColumnIndex = 5 Then
        '    Dim ltxt As New TextBox
        '    ltxt = CType(e.Control, TextBox)
        '    AddHandler ltxt.KeyPress, AddressOf NumericKeys
        'End If
        DG.CurrentRow.Cells(0).Value = DG.CurrentRow.Index + 1
        'Validation of Datagrid Cell Quantity:
        Try
            If DG.CurrentCell.ColumnIndex = 15 Then ' it was 8 i donlt know why
                Dim ltxt As New TextBox
                ltxt = CType(e.Control, TextBox)
                AddHandler ltxt.KeyPress, AddressOf NumericKeys
            End If
            'Ended here
            If DG.CurrentCell.ColumnIndex = 1 Then
                Try
                    Dim cmb As ComboBox
                    cmb = CType(e.Control, ComboBox)
                    AddHandler cmb.SelectionChangeCommitted, AddressOf k1
                Catch ex As Exception
                End Try
            End If
            'End If
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
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DG_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellValueChanged
        Dim TotalPrice As Double = 0
        Try
            calc()
        Catch ex As Exception
        End Try

        Try
            ' I think a should be currentvalue
            If DG.CurrentRow.Cells("DGCrtnPcs").Value = 2 Then
                TotalPrice = Val(DG.CurrentRow.Cells("DGTotalQty").Value) * Val(DG.CurrentRow.Cells("DGPricePerCrtn").Value)
                DG.CurrentRow.Cells("DGPrice").Value = TotalPrice
            Else

                TotalPrice = Val(DG.CurrentRow.Cells("DGTotalQty").Value) * Val(DG.CurrentRow.Cells("DGPricePerPcs").Value)
                DG.CurrentRow.Cells("DGPrice").Value = TotalPrice
            End If

        Catch ex As Exception

        End Try



        Dim indexcount As Integer
        Try
            For indexcount = 0 To DGSearch.Rows.Count - 1
                DGSearch.Rows(indexcount).Cells(0).Value = DGSearch.Rows(indexcount).Index + 1
            Next
        Catch ex As Exception
        End Try
        '''''
        Try


            If RBUs.Checked.Equals(True) Then
                DG.Columns("DGQty").Visible = False
            Else
                DG.Columns("DGQty").Visible = True
                'Module1.DatasetFill("Select Sum(PurchaseQty)-Sum(SaleQty) + Sum(ReturnQty)-Sum(ClaimQty) as 'RemainingQty'  from IGL where ProductCode='" & DG.CurrentRow.Cells("DGProductCode").Value & "'", "IGL")
                'DG.CurrentRow.Cells("DGQty").Value = ds.Tables("IGL").Rows(0).Item("RemainingQty")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DG_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DG.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DG_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellEndEdit
        Try
            CalcQty()
        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If CmbProductTypeSearch.Text = "" Or CmbProductNameSearch.Text = "" Then
            MsgBox("PLEASE SELECT THE PRODUCTS", MsgBoxStyle.Information)
            Exit Sub
        Else
            StrSearch = "Select * from VuDamageSearchForAll where ProdTypeID = " & CmbProductTypeSearch.SelectedValue & " and ProdCode=" & CmbProductNameSearch.SelectedValue & " and ReturnDate between '" & dtFrom.Value.Date.ToString & "' and '" & dtTo.Value.Date.ToString & "' and RBFrom=0"
            GridFillSearch()
        End If
    End Sub

    Private Sub TC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TC.SelectedIndexChanged
        If TC.SelectedIndex = 0 Then
            CM.Enabled = True
            ToolStrip1.Enabled = True
            If MnuNew.Enabled <> True Then
                Call CMStatus()
                Call CStatus()
            End If
            Call Clear()
            Call fill()
            btnPrint.Enabled = False
        Else
            DGSearch.Rows.Clear()
            RbCustomerSearch.Checked = False
            RbUsSearch.Checked = False
            CmbProductTypeSearch.SelectedIndex = -1
            CmbCustomerTypeSearch.SelectedIndex = -1
            dtFrom.Value = Now
            dtTo.Value = Now
            dtFromCustomer.Value = Now
            dtToCustomer.Value = Now
            GBSearchFromCustomer.Visible = False
            GBSearchFromOurs.Visible = False
            DGSearch.Visible = False
            CM.Enabled = False
            ToolStrip1.Enabled = False
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try

            If RbCustomerSearch.Checked.Equals(True) Then

                Module1.DatasetFill("Select * from RptVuDamageFromCustomer where CustomerTypeID=" & CmbCustomerTypeSearch.SelectedValue & " And CustomerID=" & CmbCustomerNameSearch.SelectedValue & " and Returndate between '" & dtFromCustomer.Value.Date & "' and '" & dtToCustomer.Value.Date & "'", "RptVuDamageFromCustomer")
                Dim rpt As New RptDamageFromCustomer
                rpt.SetDataSource(Module1.ds.Tables("RptVuDamageFromCustomer"))
                frmRptSetup.CV.ReportSource = rpt
                Frm.RptShow()

            Else

                Module1.DatasetFill("Select * from RptVuDamageFromUs where ProdTypeID=" & CmbProductTypeSearch.SelectedValue & " And ProdCode=" & CmbProductNameSearch.SelectedValue & " and Returndate between '" & dtFrom.Value.Date & "' and '" & dtTo.Value.Date & "'", "RptVuDamageFromUs")
                Dim rpt As New RptDamageFromUs
                rpt.SetDataSource(Module1.ds.Tables("RptVuDamageFromUs"))
                frmRptSetup.CV.ReportSource = rpt
                Frm.RptShow()

            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGSearch_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DGSearch.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RBUs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBUs.CheckedChanged
        DG.Rows.Clear()
        txtTotalToPay.Text = ""
        txtTotalReturn.Text = ""
        Try
            If RBUs.Checked.Equals(True) Then
                EmpPB.Image = My.Resources.IALResources.w
                'DG.Columns("DGTotalQty").ReadOnly = True
                'DG.Columns("DGPrice").ReadOnly = True
                DGTotalQty.ReadOnly = True
                DGPrice.ReadOnly = True
                DGProductName.ReadOnly = True
                DGProductCode.Visible = True
            Else
                EmpPB.Image = My.Resources.IALResources.m
            End If
        Catch ex As Exception

        End Try
        a = 0 ' I made it zero because it was getting value 2 in celvaluechange of dg.
    End Sub

    Private Sub RBCustomer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBCustomer.CheckedChanged
        DG.Rows.Clear()
        txtTotalToPay.Text = ""
        txtTotalReturn.Text = ""
        Try
            If RBCustomer.Checked.Equals(True) Then

                EmpPB.Image = My.Resources.IALResources.m
                CustomerVisible()

                If DG.ReadOnly = False Then
                    DG.ReadOnly = True
                End If
                DGProductCode.Visible = False
            Else
                EmpPB.Image = My.Resources.IALResources.w
                CustomerVisible()
                If DG.ReadOnly = True Then
                    DG.ReadOnly = False
                    DGPcsInCrtn.ReadOnly = True
                    DGPricePerCrtn.ReadOnly = True
                    DGPricePerPcs.ReadOnly = True
                    DGTotalQty.ReadOnly = True
                    DGPrice.ReadOnly = True
                    DGProductCode.Visible = True
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Sub CustomerVisible()
        cmbInvoiceNo.Visible = Not cmbInvoiceNo.Visible
        cmbCustomerType.Visible = Not cmbCustomerType.Visible
        cmbCustomerName.Visible = Not cmbCustomerName.Visible
        DGProductCode.Visible = Not DGProductCode.Visible
        DG.AllowUserToAddRows = Not DG.AllowUserToAddRows
        DG.AllowUserToDeleteRows = Not DG.AllowUserToDeleteRows
        Label25.Visible = Not Label25.Visible
        Label26.Visible = Not Label26.Visible
        Label27.Visible = Not Label27.Visible
        DGReturnDate.Visible = Not DGReturnDate.Visible
    End Sub

    Private Sub cmbInvoiceNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbInvoiceNo.SelectedIndexChanged
        If ComboIsfilly.Equals(True) Then
        Else

            cmbCustomerType.SelectedIndex = -1
            cmbCustomerName.SelectedIndex = -1

            Module1.DatasetFill("Select ReturnID,InvoiceNo,CustomerTypeID,CustomerID from VuReturnMainDetail where InvoiceNo = '" & cmbInvoiceNo.Text & "'", "VuReturnMainDetail")
            ' Call ComboFillerOfFahimshekaib(cmbInvoiceNo, "ReturnMain", "InvoiceNo", "ReturnID")


            For Each rw As DataRow In ds.Tables("VuReturnMainDetail").Rows
                If rw("InvoiceNo") = cmbInvoiceNo.Text Then
                    cmbCustomerType.SelectedIndex = -1
                    cmbCustomerName.SelectedIndex = -1
                    cmbCustomerType.SelectedValue = rw("CustomerTypeID")
                    cmbCustomerName.SelectedValue = rw("CustomerID")
                End If
            Next
            If AddEdit = True Then
                GridFillFromVuReturnMainDetail()

            Else
                GridfillFromVuDamageDetail()
            End If
        End If
    End Sub



#Region "Fahimshekaib Special ComboFiller"
    Sub ComboFillerOfFahimshekaib(ByVal ComboName As ComboBox, ByVal NameOfTable As String, ByVal DisplayMember As String, ByVal ValueMember As String)
        ComboName.DataSource = Nothing
        ComboName.Items.Clear()
        ComboName.DataSource = ds.Tables(NameOfTable)
        ComboName.DisplayMember = DisplayMember
        ComboName.ValueMember = ValueMember
        ComboName.SelectedIndex = -1
    End Sub
    Sub ComboFillerOfFahimshekaib(ByVal ComboName As DataGridViewComboBoxColumn, ByVal NameOfTable As String, ByVal DisplayMember As String, ByVal ValueMember As String)

        ComboName.DataSource = ds.Tables(NameOfTable)
        ComboName.DisplayMember = DisplayMember
        ComboName.ValueMember = ValueMember
    End Sub
#End Region


    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click

    End Sub

    Private Sub CmbProductTypeSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbProductTypeSearch.SelectedIndexChanged
        Try
            Module1.DatasetFill("Select * from VuProductForDamageSearchCombo where ProdTypeID=" & CmbProductTypeSearch.SelectedValue & "", "VuProductForDamageSearchCombo")
            Call ComboFillerOfFahimshekaib(CmbProductNameSearch, "VuProductForDamageSearchCombo", "ProductName", "ProdCode")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RbUsSearch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbUsSearch.CheckedChanged
        GBSearchFromOurs.Visible = True
        GBSearchFromCustomer.Visible = False
        DGSearch.Rows.Clear()
        DGPTypeSearch.Visible = False
        DGProdNameSearch.Visible = False
        DGSearch.Visible = True
    End Sub

    Private Sub RbCustomerSearch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbCustomerSearch.CheckedChanged
        GBSearchFromOurs.Visible = False
        GBSearchFromCustomer.Visible = True
        DGSearch.Rows.Clear()
        DGPTypeSearch.Visible = True
        DGProdNameSearch.Visible = True
        DGSearch.Visible = True
    End Sub

    Private Sub DGSearch_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGSearch.CellValueChanged
        Try
            Dim azizkhan As Integer
            For azizkhan = 0 To DGSearch.Rows.Count - 2
                DGSearch.Rows(azizkhan).Cells("DGSNOSearch").Value = DG.Rows(azizkhan).Index + 1
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CmbCustomerTypeSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCustomerTypeSearch.SelectedIndexChanged
        Try

            Module1.DatasetFill("Select * from Customer where CustomerTypeID= " & CmbCustomerTypeSearch.SelectedValue, "Customer")
            Call ComboFillerOfFahimshekaib(CmbCustomerNameSearch, "Customer", "CustomerName", "CustomerID")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSearchCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchCustomer.Click
        If CmbCustomerTypeSearch.Text = "" Or CmbCustomerNameSearch.Text = "" Then
            MsgBox("PLEASE SELECT THE NAMES", MsgBoxStyle.Information)
            Exit Sub
        Else
            StrSearch = "Select * from VuDamageSearchForAll where CustomerTypeID = " & CmbCustomerTypeSearch.SelectedValue & " and CustomerID=" & CmbCustomerNameSearch.SelectedValue & " and ReturnDate between '" & dtFromCustomer.Value.Date.ToString & "' and '" & dtToCustomer.Value.Date.ToString & "' and RBFrom=1"
            GridFillSearch()
        End If
    End Sub

    Private Sub txtRemarks_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemarks.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub
End Class