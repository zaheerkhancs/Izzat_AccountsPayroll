Imports System.Data.SqlClient
Imports LanguageSelector
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmReturn
    Dim a As Integer ' it has been used in all places , so do not ever create any local dim "a" inside a sub,use some other name.
    Public EditValue As Integer
    Dim cnt As Integer
    Public Var_ReturnID As Integer
    Dim AddEdit As Boolean
    Dim k As Integer = 0
    Dim CityID As Integer
    Dim CityBasedID As String
    Dim azizkhanqarabaghi As Boolean
    Dim DontLetDGSelectIndexChange As Boolean = False
    Dim CheckForChecker As Boolean
    Dim OldTotal As Integer
    Dim AvoidGridValidation As Boolean = True ' use it in all grid's events for not to occur will record is navigating.
    Private Sub FrmReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Module1.Opencn()
        azizkhanqarabaghi = False
        Me.MaximizeBox = False
        CityID = Frm.lbLocationID.Text
        CityBasedID = Frm.lbLocationName.Text
        ' Module1.DatasetFill("Select * from ReturnMain Order by ReturnID", "ReturnMain")
        ' Filling Comboes of CustomerType,ProductType and Product ..Customer Combo will be filled later in type change.
        Module1.DatasetFill("Select * from SaleMain", "SaleMain")
        Call ComboFillerOfFahimshekaib(cmbInvoiceNo, "SaleMain", "InvoiceNo", "SaleID")

        cmbInvoiceNo.SelectedIndex = -1

        Module1.DatasetFill("Select * from CustomerType", "CustomerType")
        Call ComboFillerOfFahimshekaib(cmbCustomerType, "CustomerType", "CustomerTypeName", "CustomerTypeID")
        cmbCustomerType.SelectedIndex = -1

        Module1.DatasetFill("Select * from Customer", "Customer")
        Call ComboFillerOfFahimshekaib(cmbCustomerName, "Customer", "CustomerName", "CustomerID")
        cmbCustomerName.SelectedIndex = -1

        Module1.DatasetFill("Select * from ProductType", "ProductType")
        Call ComboFillerOfFahimshekaib(DGPType, "ProductType", "ProdTypeName", "ProdTypeID")

        Module1.DatasetFill("Select * from VuProduct", "VuProduct")
        Call ComboFillerOfFahimshekaib(DGProductCode, "VuProduct", "Product", "ProdCode")

        Module1.DatasetFill("Select * from CartonPiece", "CartonPiece")
        Call ComboFillerOfFahimshekaib(DGCrtnPcs, "CartonPiece", "Name", "ID")
       

        Call txtfill()
        azizkhanqarabaghi = True
        TB1.Left = pnlcentre.Width / 2 - (TB1.Width / 2)
        TB1.Top = pnlcentre.Height / 2 - (TB1.Height / 2)
        pnlcentre.Left = Me.Width / 2 - (pnlcentre.Width / 2)
        pnlcentre.Top = Me.Height / 2 - (pnlcentre.Height / 2)

        If Frm.GID.Text > 2 Then
            Module1.CMStatusDisable(CM)
        End If
    End Sub

#Region "ContextMenuButtons"
    Private Sub MnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuNew.Click
        'Me.RightToLeft = Windows.Forms.RightToLeft.Yes
        Call ClearTheWholeForm()
        FrmSalePaymentDialogueBox.Dispose()
        Call Module1.CStatus(Me, pnlcentre, TB1, TP1)
        CMStatus()
        DG.ReadOnly = False
        AddEdit = True
        lblMessage.Text = ""
        EditValue = 1
        DGCrtnPcs.ReadOnly = False
        AvoidGridValidation = False
    End Sub

    Private Sub MnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSave.Click
        If Val(txtBalance.Text) < 0 Then
            MessageBox.Show("میزان نباید کمتر از صفر باشد", "تخطی از قانون", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        If EditValue = 1 Then
            IDPicker()
        End If

        Dim cmdsave As New SqlCommand
        cmdsave.CommandType = CommandType.StoredProcedure
        cmdsave.CommandText = "InsertUpdateReturnMain"
        cmdsave.Connection = cn
        cmdsave.Parameters.Add("@ReturnID", SqlDbType.Int).Value = Me.Var_ReturnID
        cmdsave.Parameters.Add("@InvoiceNo", SqlDbType.NVarChar).Value = Me.cmbInvoiceNo.Text
        cmdsave.Parameters.Add("@CustomerTypeID", SqlDbType.Int).Value = Me.cmbCustomerType.SelectedValue
        cmdsave.Parameters.Add("@CustomerID", SqlDbType.Int).Value = Me.cmbCustomerName.SelectedValue
        cmdsave.Parameters.Add("@ReturnDate", SqlDbType.SmallDateTime).Value = Me.dtReturnDate.Value.Date
        cmdsave.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = Val(Me.txtTotalToPay.Text.Trim())
        cmdsave.Parameters.Add("@TotalPaid", SqlDbType.Decimal).Value = Val(Me.txtTotalPaid.Text.Trim())
        cmdsave.Parameters.Add("@Balance", SqlDbType.Decimal).Value = Val(Me.txtBalance.Text.Trim())
        cmdsave.Parameters.Add("@TotalQtyReturnCrtn", SqlDbType.Decimal).Value = Val(Me.txtTotalReturnCrtn.Text.Trim())
        cmdsave.Parameters.Add("@TotalQtyReturnPcs", SqlDbType.Decimal).Value = Val(Me.txtTotalReturnPcs.Text.Trim())
        cmdsave.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = Me.txtRemarks.Text
        cmdsave.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
        cmdsave.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & Me.Var_ReturnID

        cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = EditValue
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmdsave.ExecuteNonQuery()

        cmdsave.Parameters.Clear()

        If EditValue = 1 Then
            Call ReturnPaymentSave()
            Call GridSave()
            SaveIGL()
            'Call GridSubDetailUpdate()

            lblMessage.Text = "ریکارد شما موفقانه ثبت گردید"
            ' MsgBox("Your Record has been saved successfully..")
        Else
            If ds.Tables.Contains("ReturnPayment") Then
                DeleteReturnPayment()
                Call ReturnPaymentSave()
                ds.Tables.Remove("ReturnPayment")
            End If
            Call DeleteGrid()
            Call GridSave()
            txtfill()
            lblMessage.Text = "ریکارد شما موفقانه تجدید گردید"

            'MsgBox("Your Record has been updated successfully..")
        End If
        Call Module1.CStatus(Me, pnlcentre, TB1, TP1)
        CMStatus()
        DG.ReadOnly = True
        AddEdit = False
        WashUp()
        AvoidGridValidation = True ' this is for not letting the grid events to be executed over and over while navigation which makes the form slow.
    End Sub


    Private Sub MnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuEdit.Click
        Call Module1.CStatus(Me, pnlcentre, TB1, TP1)
        EditValue = 0
        CMStatus()
        ' Var_ReturnID = ds.Tables("ReturnMain").Rows(cnt).Item("ReturnID")
        DG.ReadOnly = False
        AddEdit = True
        lblMessage.Text = ""
        DGCrtnPcs.ReadOnly = False
        AvoidGridValidation = False
    End Sub


    Private Sub MnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDelete.Click
        Try


            If Not Me.Var_ReturnID.Equals("") Then

                If MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then
                    Module1.DeleteRecord("ReturnMain", "ReturnID = " & Me.Var_ReturnID)
                    Module1.Opencn()

                    cmd.CommandText = " Delete from IGL where ID=" & Var_ReturnID & "  And Type='Sale Return'"
                    cmd.Connection = cn
                    cmd.ExecuteNonQuery()

                    cnt = ds.Tables("ReturnMain").Rows.Count - 1
                    If cnt = 0 Then
                        Call ClearTheWholeForm()

                        Exit Sub
                    Else
                        cnt = cnt - 1
                        Call txtfill()
                    End If
                    lblMessage.Text = "ریکارد مذکور موفقانه حذف گردید "
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub MnuUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuUndo.Click

        WashUp()
        Call Module1.CStatus(Me, pnlcentre, TB1, TP1)

        CMStatus()
        Call txtfill()
        DG.ReadOnly = True
        AddEdit = False
        AvoidGridValidation = True
    End Sub

    Private Sub MnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuExit.Click
        WashUp()
        Me.Close()
    End Sub
#End Region


#Region "Sub Functions IDPicker,txtclear,txtfill,OpenGrid,CMStatus,CMStatusDefault,CStatusDefault"
    Sub IDPicker()
        Try

            Dim sqldreader As SqlDataReader
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select Max(ReturnID) from ReturnMain"
            cmd.Connection = cn
            If cn.State = ConnectionState.Closed Then cn.Open()
            sqldreader = cmd.ExecuteReader()
            While sqldreader.Read

                If IsDBNull(sqldreader.Item(0)) = True Then
                    Me.Var_ReturnID = 1
                Else
                    Me.Var_ReturnID = Val(sqldreader.Item(0)) + 1

                End If
            End While
            sqldreader.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub WashUp()

        If FrmSalePaymentDialogueBox.Visible = True Then
            FrmSalePaymentDialogueBox.P = True
            FrmSalePaymentDialogueBox.Close()
        End If
        If ds.Tables.Contains("ReturnPayment") Then
            ds.Tables.Remove("ReturnPayment")
        End If
    End Sub
    Public Sub CStatusDefault()
        cmbInvoiceNo.Enabled = False

        cmbCustomerType.Enabled = False
        cmbCustomerName.Enabled = False
        dtReturnDate.Enabled = False
        txtTotalToPay.Enabled = False
        txtBalance.Enabled = False
        txtRemarks.Enabled = False
    End Sub
    Public Sub CMStatusDefault()
        MnuNew.Enabled = True
        MnuEdit.Enabled = True
        MnuSave.Enabled = False
        MnuDelete.Enabled = True
        MnuUndo.Enabled = False
        btnPayment.Enabled = False
    End Sub




    Sub txtfill()
        Try
            FrmSalePaymentDialogueBox.Var_PaymentFormIsOpen = False
            Module1.DatasetFill("Select * from VuReturn Order by ReturnID", "VuReturn")

            If ds.Tables("VuReturn").Rows.Count = 0 Then
                Var_ReturnID = 0
                Call ClearTheWholeForm()

                Exit Sub
            End If

            Me.Var_ReturnID = Val(ds.Tables("VuReturn").Rows(cnt).Item("ReturnID"))
            cmbInvoiceNo.Text = ds.Tables("VuReturn").Rows(cnt).Item("InvoiceNo")

            cmbCustomerType.SelectedValue = ds.Tables("VuReturn").Rows(cnt).Item("CustomerTypeID")
            cmbCustomerName.SelectedValue = ds.Tables("VuReturn").Rows(cnt).Item("CustomerID")
            dtReturnDate.Value = ds.Tables("VuReturn").Rows(cnt).Item("ReturnDate")
            txtTotalToPay.Text = ds.Tables("VuReturn").Rows(cnt).Item("TotalAmount")
            txtTotalPaid.Text = ds.Tables("VuReturn").Rows(cnt).Item("TotalPaid")
            txtBalance.Text = ds.Tables("VuReturn").Rows(cnt).Item("Balance")
            txtTotalReturnCrtn.Text = ds.Tables("VuReturn").Rows(cnt).Item("TotalQtyReturnCrtn")
            txtTotalReturnPcs.Text = ds.Tables("VuReturn").Rows(cnt).Item("TotalQtyReturnPcs")
            txtRemarks.Text = ds.Tables("VuReturn").Rows(cnt).Item("Remarks")

            Call GridFill()
            txtTotalReturnCrtn.Text = ds.Tables("VuReturn").Rows(cnt).Item("TotalQtyReturnCrtn")
            txtTotalReturnPcs.Text = ds.Tables("VuReturn").Rows(cnt).Item("TotalQtyReturnPcs")
        Catch ex As Exception

        End Try
    End Sub
    Sub ClearTheWholeForm()

        Module1.txtclear(Me, pnlcentre, TB1, TP1)
        cmbInvoiceNo.SelectedIndex = -1
        DG.Rows.Clear()
    End Sub
    Sub CMStatus()
        MnuNew.Enabled = Not MnuNew.Enabled
        MnuEdit.Enabled = Not MnuEdit.Enabled
        MnuSave.Enabled = Not MnuSave.Enabled
        MnuDelete.Enabled = Not MnuDelete.Enabled
        MnuUndo.Enabled = Not MnuUndo.Enabled
        btnPayment.Enabled = Not btnPayment.Enabled
    End Sub

#End Region
#Region "Navigation"
    Private Sub TSFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSFirst.Click
        Try

            WashUp()
            cnt = 0
            Call txtfill()
            CMStatusDefault()
            CStatusDefault()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub TSPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSPrevious.Click
        Try

            WashUp()
            If cnt = 0 Then
                Call txtfill()
                If ds.Tables("VuReturn").Rows.Count = 0 Then Exit Sub
                CMStatusDefault()
                CStatusDefault()


            Else
                cnt = cnt - 1
                Call txtfill()
                CMStatusDefault()
                CStatusDefault()

            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub TSNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSNext.Click
        Try

            WashUp()
            If cnt = ds.Tables("VuReturn").Rows.Count - 1 Then Exit Sub
            cnt = cnt + 1
            Call txtfill()
            CMStatusDefault()
            CStatusDefault()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub TSLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSLast.Click
        Try


            WashUp()
            cnt = ds.Tables("VuReturn").Rows.Count - 1
            Call txtfill()
            CMStatusDefault()
            CStatusDefault()
        Catch ex As Exception

        End Try
    End Sub
#End Region
#Region "Fahimshekaib Special ComboFiller"
    Sub ComboFillerOfFahimshekaib(ByVal ComboName As ComboBox, ByVal NameOfTable As String, ByVal DisplayMember As String, ByVal ValueMember As String)

        ComboName.DataSource = ds.Tables(NameOfTable)
        ComboName.DisplayMember = DisplayMember
        ComboName.ValueMember = ValueMember
    End Sub
    Sub ComboFillerOfFahimshekaib(ByVal ComboName As DataGridViewComboBoxColumn, ByVal NameOfTable As String, ByVal DisplayMember As String, ByVal ValueMember As String)

        ComboName.DataSource = ds.Tables(NameOfTable)
        ComboName.DisplayMember = DisplayMember
        ComboName.ValueMember = ValueMember
    End Sub
#End Region


    Sub SaveIGL()
        Dim cmdsaveGridIGL As New SqlCommand
        cmdsaveGridIGL.CommandType = CommandType.StoredProcedure
        cmdsaveGridIGL.CommandText = "InsertIGL"
        cmdsaveGridIGL.Connection = cn
        Try
            For k = 0 To DG.Rows.Count - 1

                cmdsaveGridIGL.Parameters.Add("@ID", SqlDbType.Int)
                cmdsaveGridIGL.Parameters("@ID").Value = Var_ReturnID

                cmdsaveGridIGL.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Me.dtReturnDate.Value.Date
                cmdsaveGridIGL.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "Sale Return"
                cmdsaveGridIGL.Parameters.Add("@ProductType", SqlDbType.Int).Value = DG.Rows(k).Cells("DGPType").Value
                cmdsaveGridIGL.Parameters.Add("@ProductCode", SqlDbType.Int).Value = DG.Rows(k).Cells("DGProductCode").Value
                cmdsaveGridIGL.Parameters.Add("@PurchaseQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@SaleQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@ReturnQty", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DGTotalQty").Value)
                cmdsaveGridIGL.Parameters.Add("@ClaimQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@DamageQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@CrtnPcs", SqlDbType.SmallInt).Value = Val(DG.Rows(k).Cells("DGCrtnPcs").Value)
                cmdsaveGridIGL.Parameters.Add("@Broken", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DGBroken").Value)
                cmdsaveGridIGL.Parameters.Add("@Leak", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DGLeak").Value)
                cmdsaveGridIGL.Parameters.Add("@Short", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DGShort").Value)
                cmdsaveGridIGL.Parameters.Add("@Dent", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DGDent").Value)
                cmdsaveGridIGL.Parameters.Add("@Expired", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(k).Cells("DGExpired").Value)
                cmdsaveGridIGL.Parameters.Add("@DecayedBeforeExpiration", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(k).Cells("DGDecayedBeforeExpiration").Value)
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
                cmdsaveGridIGL.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & Me.Var_ReturnID

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

        Dim OldEtc As Decimal = 0
        Dim NewEtc As Decimal = 0
        Dim TotalEtc As Decimal = 0

        Dim OldOk As Decimal = 0
        Dim NewOk As Decimal = 0
        Dim TotalOk As Decimal = 0

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

            Module1.DatasetFill("Select Sum(ReturnQty)as ReturnQuantity from VuIGL where ID=" & Var_ReturnID & " and ProductType =" & DG.Rows(a).Cells(1).Value & " and ProductCode=" & DG.Rows(a).Cells(2).Value & " And Type='Sale Return'", "VuIGL")
            OldQty = ds.Tables("VuIGL").Rows(0).Item("ReturnQuantity")
            NewQty = Val(DG.Rows(a).Cells("DGTotalQty").Value)
            TotalQty = NewQty - OldQty
        Catch ex As Exception
        End Try

        If TotalQty = 0 Then
            Exit Sub
        End If


        Try

            Module1.DatasetFill("Select Sum(Broken)as BrokenQuantity from VuIGL where ID=" & Var_ReturnID & " and ProductType =" & DG.Rows(a).Cells(1).Value & " and ProductCode=" & DG.Rows(a).Cells(2).Value & " And Type='Sale Return'", "VuIGL")
            OldBroken = ds.Tables("VuIGL").Rows(0).Item("BrokenQuantity")
            NewBroken = Val(DG.Rows(a).Cells("DGBroken").Value)
            TotalBroken = NewBroken - OldBroken
        Catch ex As Exception
        End Try

        Try

            Module1.DatasetFill("Select Sum(Leak)as LeakQuantity from VuIGL where ID=" & Var_ReturnID & " and ProductType =" & DG.Rows(a).Cells(1).Value & " and ProductCode=" & DG.Rows(a).Cells(2).Value & " And Type='Sale Return'", "VuIGL")
            OldLeak = ds.Tables("VuIGL").Rows(0).Item("LeakQuantity")
            NewLeak = Val(DG.Rows(a).Cells("DGLeak").Value)
            TotalLeak = NewLeak - OldLeak
        Catch ex As Exception
        End Try

        Try

            Module1.DatasetFill("Select Sum(Short)as ShortQuantity from VuIGL where ID=" & Var_ReturnID & " and ProductType =" & DG.Rows(a).Cells(1).Value & " and ProductCode=" & DG.Rows(a).Cells(2).Value & " And Type='Sale Return'", "VuIGL")
            OldShort = ds.Tables("VuIGL").Rows(0).Item("ShortQuantity")
            NewShort = Val(DG.Rows(a).Cells("DGShort").Value)
            TotalShort = NewShort - OldShort
        Catch ex As Exception
        End Try

        Try

            Module1.DatasetFill("Select Sum(Dent)as DentQuantity from VuIGL where ID=" & Var_ReturnID & " and ProductType =" & DG.Rows(a).Cells(1).Value & " and ProductCode=" & DG.Rows(a).Cells(2).Value & " And Type='Sale Return'", "VuIGL")
            OldDent = ds.Tables("VuIGL").Rows(0).Item("DentQuantity")
            NewDent = Val(DG.Rows(a).Cells("DGDent").Value)
            TotalDent = NewDent - OldDent
        Catch ex As Exception
        End Try

        Try

            Module1.DatasetFill("Select Sum(Expired)as ExpiredQuantity from VuIGL where ID=" & Var_ReturnID & " and ProductType =" & DG.Rows(a).Cells("DGPType").Value & " and ProductCode=" & DG.Rows(a).Cells("DGProductCode").Value & " And Type='Claim'", "VuIGL")
            OldExpired = ds.Tables("VuIGL").Rows(0).Item("ExpiredQuantity")
            NewExpired = Val(DG.Rows(a).Cells("DGExpired").Value)
            TotalExpired = NewExpired - OldExpired
        Catch ex As Exception
        End Try

        Try

            Module1.DatasetFill("Select Sum(DecayedBeforeExpiration)as DecayedBeforeExpirationQuantity from VuIGL where ID=" & Var_ReturnID & " and ProductType =" & DG.Rows(a).Cells("DGPType").Value & " and ProductCode=" & DG.Rows(a).Cells("DGProductCode").Value & " And Type='Claim'", "VuIGL")
            OldDecayedBeforeExpiration = ds.Tables("VuIGL").Rows(0).Item("DecayedBeforeExpirationQuantity")
            NewDecayedBeforeExpiration = Val(DG.Rows(a).Cells("DGDecayedBeforeExpiration").Value)
            TotalDecayedBeforeExpiration = NewDecayedBeforeExpiration - OldDecayedBeforeExpiration
        Catch ex As Exception
        End Try

        Try

            Module1.DatasetFill("Select Sum(Etc)as EtcQuantity from VuIGL where ID=" & Var_ReturnID & " and ProductType =" & DG.Rows(a).Cells(1).Value & " and ProductCode=" & DG.Rows(a).Cells(2).Value & " And Type='Sale Return'", "VuIGL")
            OldEtc = ds.Tables("VuIGL").Rows(0).Item("EtcQuantity")
            NewEtc = Val(DG.Rows(a).Cells("DGEtc").Value)
            TotalEtc = NewEtc - OldEtc
        Catch ex As Exception
        End Try

        Try

            Module1.DatasetFill("Select Sum(Ok)as OkQuantity from VuIGL where ID=" & Var_ReturnID & " and ProductType =" & DG.Rows(a).Cells(1).Value & " and ProductCode=" & DG.Rows(a).Cells(2).Value & " And Type='Sale Return'", "VuIGL")
            OldOk = ds.Tables("VuIGL").Rows(0).Item("OkQuantity")
            NewOk = Val(DG.Rows(a).Cells("DGOk").Value)
            TotalOk = NewOk - OldOk
        Catch ex As Exception
        End Try

        Try
            For k = 0 To 1 - 1

                cmdsaveGridIGL.Parameters.Add("@ID", SqlDbType.Int)
                cmdsaveGridIGL.Parameters("@ID").Value = Var_ReturnID
                cmdsaveGridIGL.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = dtReturnDate.Value.Date
                cmdsaveGridIGL.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "Sale Return"
                cmdsaveGridIGL.Parameters.Add("@ProductType", SqlDbType.Int).Value = DG.Rows(a).Cells("DGPType").Value
                cmdsaveGridIGL.Parameters.Add("@ProductCode", SqlDbType.Int).Value = DG.Rows(a).Cells("DGProductCode").Value


                cmdsaveGridIGL.Parameters.Add("@PurchaseQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@SaleQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@ReturnQty", SqlDbType.Decimal).Value = TotalQty
                cmdsaveGridIGL.Parameters.Add("@ClaimQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@DamageQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Broken", SqlDbType.Decimal).Value = TotalBroken
                cmdsaveGridIGL.Parameters.Add("@Leak", SqlDbType.Decimal).Value = TotalLeak
                cmdsaveGridIGL.Parameters.Add("@Short", SqlDbType.Decimal).Value = TotalShort
                cmdsaveGridIGL.Parameters.Add("@Dent", SqlDbType.Decimal).Value = TotalDent
                cmdsaveGridIGL.Parameters.Add("@Expired", SqlDbType.Decimal).Value = TotalExpired
                cmdsaveGridIGL.Parameters.Add("@DecayedBeforeExpiration", SqlDbType.Decimal).Value = TotalDecayedBeforeExpiration
                cmdsaveGridIGL.Parameters.Add("@Etc", SqlDbType.Decimal).Value = TotalEtc
                cmdsaveGridIGL.Parameters.Add("@Ok", SqlDbType.Decimal).Value = TotalOk
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
                cmdsaveGridIGL.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & Me.Var_ReturnID

                cmdsaveGridIGL.ExecuteNonQuery()
                cmdsaveGridIGL.Parameters.Clear()
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPayment.Click

        Try
            If FrmSalePaymentDialogueBox.Var_PaymentFormIsOpen = True Then
                FrmSalePaymentDialogueBox.Visible = True
            Else
                FrmSalePaymentDialogueBox.txtInvoice.Text = Me.cmbInvoiceNo.Text
                FrmSalePaymentDialogueBox.txtTotalToPay.Text = Me.txtTotalToPay.Text
                FrmSalePaymentDialogueBox.txtTotalPaid.Text = Me.txtTotalPaid.Text
                FrmSalePaymentDialogueBox.txtBalance.Text = Me.txtBalance.Text
                FrmSalePaymentDialogueBox.Visible = True
                FrmSalePaymentDialogueBox.TopMost = True
                FrmSalePaymentDialogueBox.MdiParent = Frm
                Try
                    If Me.EditValue = 0 Then
                        Call FrmSalePaymentDialogueBox.GridFillFromReturnTable()
                    End If

                Catch ex As Exception

                End Try
                FrmSalePaymentDialogueBox.Call_Is_From_FormName = Me.Name
            End If
        Catch ex As Exception

            FrmSalePaymentDialogueBox.ShowDialog()
        End Try
    End Sub

    Private Sub cmbInvoiceNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbInvoiceNo.SelectedIndexChanged
        Dim aa As Integer
        Try
            If AddEdit.Equals(True) Then
                Module1.DatasetFill("Select SalOrderID,CustomerTypeID,CustomerID From VuSaleMain where SaleID = " & cmbInvoiceNo.SelectedValue, "VuSaleMain")
                cmbCustomerType.SelectedIndex = -1
                cmbCustomerType.SelectedValue = ds.Tables("VuSaleMain").Rows(0).Item("CustomerTypeID")
                'MsgBox(cmbCustomerName.Items.Count)
                cmbCustomerName.SelectedIndex = -1
                cmbCustomerName.SelectedValue = ds.Tables("VUSaleMain").Rows(0).Item("CustomerID")
                'MsgBox(cmbCustomerName.Text)
                GridFillFromInvoiceNo()
            End If
        Catch ex As Exception
        End Try
        'If DG.Rows.Count > 0 Then
        '    Try
        '        For aa = 0 To DG.Rows.Count - 1
        '            DG.Rows(aa).Cells("DGCrtnPcs").Value = ds.Tables("CartonPiece").Rows(aa).Item("ID")
        '        Next

        '    Catch ex As Exception

        '    End Try
        'End If
    End Sub
    Sub DeleteReturnPayment()

        Dim cmdsave As New SqlCommand
        cmdsave.CommandType = CommandType.StoredProcedure
        cmdsave.CommandText = "DeleteReturnPayment"
        cmdsave.Connection = cn
        cmdsave.Parameters.Add("@ReturnID", SqlDbType.Int).Value = Var_ReturnID
        cmdsave.ExecuteNonQuery()

    End Sub

    Sub DeleteGrid()

        Dim cmdsave As New SqlCommand
        cmdsave.CommandType = CommandType.StoredProcedure
        cmdsave.CommandText = "DeleteReturnDetail"
        cmdsave.Connection = cn
        cmdsave.Parameters.Add("@ReturnID", SqlDbType.Int).Value = Var_ReturnID
        cmdsave.ExecuteNonQuery()

    End Sub
    Sub GridFillFromInvoiceNo()
        Try
            Dim i As Integer = 0
            DG.Rows.Clear()
            Module1.DatasetFill("Select * from SaleDetail where SaleID = " & cmbInvoiceNo.SelectedValue, "SaleDetail")
            For i = 0 To ds.Tables("SaleDetail").Rows.Count - 1
                DG.Rows.Add()
                DG.Rows(i).Cells("DGSNo").Value = ds.Tables("SaleDetail").Rows(i).Item("SNo")
                DG.Rows(i).Cells("DGPType").Value = ds.Tables("SaleDetail").Rows(i).Item("ProdTypeID")
                DG.Rows(i).Cells("DGProductCode").Value = ds.Tables("SaleDetail").Rows(i).Item("ProdCode")
                DG.Rows(i).Cells("DGPcsInCrtn").Value = ds.Tables("SaleDetail").Rows(i).Item("PcsInCrtn")
                DG.Rows(i).Cells("DGPricePerPcs").Value = ds.Tables("SaleDetail").Rows(i).Item("PricePerPcs")
                DG.Rows(i).Cells("DGPricePerCrtn").Value = ds.Tables("SaleDetail").Rows(i).Item("PricePerCrtn")
                DG.Rows(i).Cells("DGCrtnPcs").Value = ds.Tables("SaleDetail").Rows(i).Item("CrtnPcs")
                DG.Rows(i).Cells("DGQty").Value = ds.Tables("SaleDetail").Rows(i).Item("DeliveredQty")
                DG.Rows(i).Cells("DGPrice").Value = "0"
                DG.Rows(i).Cells("DGDescription").Value = "---"

                DG.Columns("DGPrice").ReadOnly = True
                'DG.Columns("DGTotalQty").ReadOnly = True
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub GridFill()

        Try
            Dim i As Integer = 0

            DG.Rows.Clear()

            Module1.DatasetFill("Select * from ReturnDetail where ReturnID = " & Var_ReturnID, "ReturnDetail")
            'For Each Row As DataRow In ds.Tables("OrderFromCustomerDetail").Rows
            '    DG.Rows.Add()
            '    i = +1
            '    DG.Rows(i).Cells("DGSNo").Value = Row("SNo")
            '    DG.Rows(i).Cells("DGPType").Value = Row("ProdTypeID")
            '    DG.Rows(i).Cells("DGProductName").Value = Row("ProdCode")
            '    DG.Rows(i).Cells("DGQty").Value = Row("Qty")
            '    DG.Rows(i).Cells("DGDesc").Value = Row("ProdDescription")

            'Next
            For i = 0 To ds.Tables("ReturnDetail").Rows.Count - 1
                DG.Rows.Add()
                'i = DG.Rows.Count

                DG.Rows(i).Cells("DGSNo").Value = ds.Tables("ReturnDetail").Rows(i).Item("SNo")
                DG.Rows(i).Cells("DGPType").Value = ds.Tables("ReturnDetail").Rows(i).Item("ProdTypeID")
                DG.Rows(i).Cells("DGProductCode").Value = ds.Tables("ReturnDetail").Rows(i).Item("ProdCode")
                DG.Rows(i).Cells("DGPcsInCrtn").Value = ds.Tables("ReturnDetail").Rows(i).Item("PcsInCrtn")
                DG.Rows(i).Cells("DGPricePerPcs").Value = ds.Tables("ReturnDetail").Rows(i).Item("PricePerPcs")
                DG.Rows(i).Cells("DGPricePerCrtn").Value = ds.Tables("ReturnDetail").Rows(i).Item("PricePerCrtn")
                'Dim CP As Integer = Convert.ToInt16(ds.Tables("ReturnDetail").Rows(i).Item("CartonPiece"))
                '' If CP = 1 Then
                DG.Rows(i).Cells("DGCrtnPcs").Value = ds.Tables("ReturnDetail").Rows(i).Item("CartonPiece")

                If DG.Rows(i).Cells("DGCrtnPcs").FormattedValue = "1" Then
                    DG.Rows(i).Cells("DGCrtnPcs").Value = ds.Tables("CartonPiece").Rows(0).Item("Name")
                Else
                    DG.Rows(i).Cells("DGCrtnPcs").Value = ds.Tables("CartonPiece").Rows(1).Item("Name")
                End If



                DG.Rows(i).Cells("DGQty").Value = ds.Tables("ReturnDetail").Rows(i).Item("Qty")
                If ds.Tables("ReturnDetail").Rows(i).Item("Status") = 0 Then
                    DG.Rows(i).Cells("DGchbDefective").Value = DGchbDefective.TrueValue = True
                Else
                    DG.Rows(i).Cells("DGchbDefective").Value = DGchbDefective.FalseValue = False
                End If
                DG.Rows(i).Cells("DGBroken").Value = ds.Tables("ReturnDetail").Rows(i).Item("Broken")
                DG.Rows(i).Cells("DGLeak").Value = ds.Tables("ReturnDetail").Rows(i).Item("Leak")
                DG.Rows(i).Cells("DGShort").Value = ds.Tables("ReturnDetail").Rows(i).Item("Short")
                DG.Rows(i).Cells("DGDent").Value = ds.Tables("ReturnDetail").Rows(i).Item("Dent")
                DG.Rows(i).Cells("DGExpired").Value = ds.Tables("ReturnDetail").Rows(i).Item("Expired")
                DG.Rows(i).Cells("DGDecayedBeforeExpiration").Value = ds.Tables("ReturnDetail").Rows(i).Item("DecayedBeforeExpiration")
                DG.Rows(i).Cells("DGEtc").Value = ds.Tables("ReturnDetail").Rows(i).Item("Etc")
                DG.Rows(i).Cells("DGOk").Value = ds.Tables("ReturnDetail").Rows(i).Item("Ok")
                DG.Rows(i).Cells("DGTotalQty").Value = ds.Tables("ReturnDetail").Rows(i).Item("TotalQty")
                DG.Rows(i).Cells("DGPrice").Value = ds.Tables("ReturnDetail").Rows(i).Item("Price")
                DG.Rows(i).Cells("DGDescription").Value = ds.Tables("ReturnDetail").Rows(i).Item("ReturnReason")

            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub GridSave()
        Dim cmdsaveGrid As New SqlCommand
        cmdsaveGrid.CommandType = CommandType.StoredProcedure
        cmdsaveGrid.CommandText = "InsertUpdateReturnDetail"
        cmdsaveGrid.Connection = cn
        Try

            For a = 0 To DG.Rows.Count - 1 ' This is 1 because I haven't allowed an extra row at the end of the DataGrid.
                'Trans = cn.BeginTransaction("Fahim")
                cmdsaveGrid.Parameters.Add("@ReturnID", SqlDbType.Int).Value = Var_ReturnID
                cmdsaveGrid.Parameters.Add("@Sno", SqlDbType.Int).Value = DG.Rows(a).Cells("DGSno").Value
                cmdsaveGrid.Parameters.Add("@ProdTypeID", SqlDbType.Int).Value = DG.Rows(a).Cells("DGPType").Value
                cmdsaveGrid.Parameters.Add("@ProdCode", SqlDbType.Int).Value = DG.Rows(a).Cells("DGProductCode").Value

                cmdsaveGrid.Parameters.Add("@PcsInCrtn", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGPcsInCrtn").Value
                cmdsaveGrid.Parameters.Add("@PricePerPcs", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGPricePerPcs").Value
                cmdsaveGrid.Parameters.Add("@PricePerCrtn", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGPricePerCrtn").Value
                cmdsaveGrid.Parameters.Add("@CartonPiece", SqlDbType.SmallInt).Value = DG.Rows(a).Cells("DGCrtnPcs").Value

                cmdsaveGrid.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGQty").Value)


                If DG.Rows(a).Cells("DGchbDefective").Value = DGchbDefective.TrueValue = False Then
                    cmdsaveGrid.Parameters.Add("@Status", SqlDbType.Bit).Value = 1
                Else
                    cmdsaveGrid.Parameters.Add("@Status", SqlDbType.Bit).Value = 0
                End If
                cmdsaveGrid.Parameters.Add("@Broken", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGBroken").Value)
                cmdsaveGrid.Parameters.Add("@Leak", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGLeak").Value)
                cmdsaveGrid.Parameters.Add("@Short", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGShort").Value)
                cmdsaveGrid.Parameters.Add("@Dent", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGDent").Value)
                cmdsaveGrid.Parameters.Add("@Expired", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGExpired").Value)
                cmdsaveGrid.Parameters.Add("@DecayedBeforeExpiration", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGDecayedBeforeExpiration").Value)

                cmdsaveGrid.Parameters.Add("@Etc", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGEtc").Value)
                cmdsaveGrid.Parameters.Add("@Ok", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGOk").Value)
                cmdsaveGrid.Parameters.Add("@TotalQty", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGTotalQty").Value)
                cmdsaveGrid.Parameters.Add("@Price", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGPrice").Value)

                If DG.Rows(a).Cells("DGDescription").Value = Nothing Then
                    cmdsaveGrid.Parameters.Add("@ReturnReason", SqlDbType.NVarChar).Value = "---"
                Else
                    cmdsaveGrid.Parameters.Add("@ReturnReason", SqlDbType.NVarChar).Value = DG.Rows(a).Cells("DGDescription").Value

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
    Sub ReturnPaymentSave()

        ' FrmSalePaymentDialogueBox.Visible = True


        Dim cmdsaveGrid As New SqlCommand
        cmdsaveGrid.CommandType = CommandType.StoredProcedure
        cmdsaveGrid.CommandText = "InsertUpdateReturnPayment"
        cmdsaveGrid.Connection = cn
        Try

            For a = 0 To FrmSalePaymentDialogueBox.DGDiag.Rows.Count - 1
                'Trans = cn.BeginTransaction("Fahim")
                cmdsaveGrid.Parameters.Add("@ReturnID", SqlDbType.Int).Value = Var_ReturnID



                cmdsaveGrid.Parameters.Add("@SNo", SqlDbType.Int).Value = FrmSalePaymentDialogueBox.DGDiag.Rows(a).Cells(0).Value
                cmdsaveGrid.Parameters.Add("@Amount", SqlDbType.Int).Value = FrmSalePaymentDialogueBox.DGDiag.Rows(a).Cells(1).Value

                Dim Var_PaymentDate As DateTime
                Try
                    If FrmSalePaymentDialogueBox.DGDiag.Rows(a).Cells(2).Value = #12:00:00 AM# Then
                        Var_PaymentDate = "01/01/1900"
                        cmdsaveGrid.Parameters.Add("@PaymentDate", SqlDbType.SmallDateTime).Value = Var_PaymentDate

                    Else
                        Var_PaymentDate = FrmSalePaymentDialogueBox.DGDiag.Rows(a).Cells(2).Value
                        cmdsaveGrid.Parameters.Add("@PaymentDate", SqlDbType.SmallDateTime).Value = Var_PaymentDate

                    End If
                Catch ex As Exception
                    Var_PaymentDate = "01/01/1900"
                    cmdsaveGrid.Parameters.Add("@PaymentDate", SqlDbType.SmallDateTime).Value = Var_PaymentDate

                End Try

                'cmdsaveGrid.Parameters.Add("@PaymentDate", SqlDbType.SmallDateTime).Value = FrmSalePaymentDialogueBox.DGDiag.Rows(a).Cells(2).Value
                ''cmdsaveGrid.Parameters.Add("@PaymentDate", SqlDbType.NVarChar).Value = FrmSalePaymentDialogueBox.DGDiag.Rows(a).Cells(2).Value
                cmdsaveGrid.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
                cmdsaveGrid.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & Me.Var_ReturnID
                'Trans.Commit()

                If cn.State = ConnectionState.Closed Then cn.Open()
                cmdsaveGrid.ExecuteNonQuery()
                cmdsaveGrid.Parameters.Clear()
            Next
            'For Each frm As Form In Me.Controls
            '    If frm.Name = FrmSaleQtyTranfered.ToString() Then
            '        frm.Close()
            '    End If
            'Next

        Catch ex As Exception
            'Trans.Rollback()
        End Try
    End Sub

    Private Sub DG_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellValueChanged
        If AvoidGridValidation = False Then


            'If DontLetDGSelectIndexChange.Equals(True) Then
            Dim CalculateAmount As Decimal = 0
            Dim Increamenter As Integer = 0
            Dim CellValidator As Integer

            Dim TotalQtyCrtn As Double = 0
            Dim TotalQtyPcs As Double = 0

            Dim a As Integer

            Try

                For a = 0 To DG.Rows.Count - 1
                    If DG.Rows(a).Cells("DGCrtnPcs").Value = 1 Then
                        'If DG.Rows(a).Cells("DGCrtnPcs").Value = 1 Or DG.Rows(a).Cells("DGCrtnPcs").Value = "دانه" Then
                        'MsgBox(DG.Rows(a).Cells("DGCrtnPcs").Value)
                        TotalQtyPcs = TotalQtyPcs + Val(DG.Rows(a).Cells("DGTotalQty").Value)
                    Else
                        TotalQtyCrtn = TotalQtyCrtn + Val(DG.Rows(a).Cells("DGTotalQty").Value)
                        'MsgBox(DG.Rows(a).Cells("DGCrtnPcs").Value)
                    End If
                Next
                Me.txtTotalReturnCrtn.Text = TotalQtyCrtn
                Me.txtTotalReturnPcs.Text = TotalQtyPcs

            Catch ex As Exception
            End Try


            Try
                If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGCrtnPcs" Or DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGBroken" Or DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGDent" Or DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGLeak" Or DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGShort" Or DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGDent" Or DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGExpired" Or DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGDecayedBeforeExpiration" Or DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGQty " Or DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGTotalQty" Then
                    'If azizkhanqarabaghi = True Then
                    For Each Row As DataGridViewRow In DG.Rows
                        'Only for validation I using CellValidator Variable here.
                        CellValidator = DG.CurrentCell.Value
                        CalculateAmount = Val(CalculateAmount) + Val(Convert.ToDecimal(DG.Rows(Increamenter).Cells("DGPrice").Value))
                        Increamenter = Increamenter + 1
                    Next
                    txtTotalToPay.Text = CalculateAmount
                End If
                'End If
                '    Try
                '        Dim TotalPrice As Integer
                '        TotalPrice = Val(DG.CurrentRow.Cells("DGTotalQty").Value) * Val(DG.CurrentRow.Cells("DGPricePerPcs").Value)
                '        DG.CurrentRow.Cells("DGPrice").Value = TotalPrice
                '    Catch ex As Exception

                '    End Try
            Catch ex As Exception
                'If azizkhanqarabaghi = True Then
                '    DG.CurrentCell.Value = "0"
                '    MessageBox.Show("فقط اعداد قابل قبول میباشد", "تخطی از قانون", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'End If
            End Try



            'Try
            '    Dim h As Integer
            '    For h = 0 To DG.Rows.Count - 1
            '        If DG.Rows(h).Cells("DGchbDefective").Value = DGchbDefective.TrueValue = False Then
            '            DG.Rows(h).Cells("DGBroken").ReadOnly = False
            '            DG.Rows(h).Cells("DGLeak").ReadOnly = False
            '            DG.Rows(h).Cells("DGShort").ReadOnly = False
            '            DG.Rows(h).Cells("DGDent").ReadOnly = False
            '            DG.Rows(h).Cells("DGTotalQty").ReadOnly = True
            '            DG.Rows(h).Cells("DGExpired").ReadOnly = False
            '            DG.Rows(h).Cells("DGDecayedBeforeExpiration").ReadOnly = False
            '        Else
            '            DG.Rows(h).Cells("DGBroken").ReadOnly = True
            '            DG.Rows(h).Cells("DGBroken").Value = "0"
            '            DG.Rows(h).Cells("DGLeak").ReadOnly = True
            '            DG.Rows(h).Cells("DGLeak").Value = "0"
            '            DG.Rows(h).Cells("DGShort").ReadOnly = True
            '            DG.Rows(h).Cells("DGShort").Value = "0"
            '            DG.Rows(h).Cells("DGDent").ReadOnly = True
            '            DG.Rows(h).Cells("DGDent").Value = "0"
            '            DG.Rows(h).Cells("DGExpired").ReadOnly = True
            '            DG.Rows(h).Cells("DGExpired").Value = "0"
            '            DG.Rows(h).Cells("DGDecayedBeforeExpiration").ReadOnly = True
            '            DG.Rows(h).Cells("DGDecayedBeforeExpiration").Value = "0"
            '            DG.Rows(h).Cells("DGTotalQty").ReadOnly = False
            '        End If
            '    Next
            'Catch ex As Exception

            'End Try
            'End If
        End If
    End Sub

    Private Sub DG_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DG.DataError
        Try
        Catch ex As Exception
        End Try
    End Sub

    Private Sub NumericKeys(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim TotalForCheck As Double = 0
        If DG.CurrentCell.ColumnIndex = 9 Or DG.CurrentCell.ColumnIndex = 10 Or DG.CurrentCell.ColumnIndex = 11 Or DG.CurrentCell.ColumnIndex = 12 Or DG.CurrentCell.ColumnIndex = 13 Or DG.CurrentCell.ColumnIndex = 14 Then
            If IsNumeric(Me.ActiveControl.Text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Then e.Handled = True
        End If
    End Sub
    Private Sub DelegateCellData(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Me.DG.CurrentCell.Value = Me.ActiveControl.Text & e.KeyChar
        Dim Total As Double = 0

        Try
            Total = Total + Val(DG.CurrentRow.Cells("DGBroken").Value) + Val(DG.CurrentRow.Cells("DGLeak").Value) + Val(DG.CurrentRow.Cells("DGShort").Value) + Val(DG.CurrentRow.Cells("DGDent").Value) + Val(DG.CurrentRow.Cells("DGExpired").Value) + Val(DG.CurrentRow.Cells("DGDecayedBeforeExpiration").Value) + Val(DG.CurrentRow.Cells("DGEtc").Value) + Val(DG.CurrentRow.Cells("DGOk").Value)

            If Val(Me.DG.CurrentRow.Cells("DGQty").Value) < Val(Total) Then
                DG.CurrentCell.Value = 0
                e.Handled = True
                Total = OldTotal
            Else
                e.Handled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DG_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DG.EditingControlShowing
        If AvoidGridValidation = False Then
            If DG.CurrentCell.ColumnIndex = 9 Then
                Dim ltxt As New TextBox
                ltxt = CType(e.Control, TextBox)
                AddHandler ltxt.KeyPress, AddressOf NumericKeys
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
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            If Var_ReturnID = 0 Then
                Exit Sub
            Else
                Module1.DatasetFill("Select * from RptVuReturnMain where ReturnID=" & Var_ReturnID, "RptVuReturnMain")
                Dim rpt As New RptReturn
                rpt.SetDataSource(Module1.ds.Tables("RptVuReturnMain"))
                frmRptSetup.CV.ReportSource = rpt
                Frm.RptShow()
                'Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DG_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellEndEdit
        If AvoidGridValidation = False Then


            'If DG.CurrentRow.Cells("DgChbDefective").Value = DGchbDefective.FalseValue = False Then
            Dim Total As Double = 0
            Try
                'For a = 0 To DG.Rows.Count - 1
                Total = Total + Val(DG.CurrentRow.Cells("DGBroken").Value) + Val(DG.CurrentRow.Cells("DGLeak").Value) + Val(DG.CurrentRow.Cells("DGShort").Value) + Val(DG.CurrentRow.Cells("DGDent").Value) + Val(DG.CurrentRow.Cells("DGExpired").Value) + Val(DG.CurrentRow.Cells("DGDecayedBeforeExpiration").Value) + Val(DG.CurrentRow.Cells("DGEtc").Value) + Val(DG.CurrentRow.Cells("DGOk").Value)
                'Next
                DG.CurrentRow.Cells("DGTotalQty").Value = Total
                OldTotal = Total
            Catch ex As Exception
            End Try
            'End If

            Try
                If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGCrtnPcs" Or DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGTotalQty" Or DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGBroken" Or DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGLeak" Or DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGShort" Or DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGDent" Or DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGExpired" Or DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGDecayedBeforeExpiration" Or DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGEtc" Or DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGOk" Then
                    If DG.CurrentRow.Cells("DGCrtnPcs").Value = 1 Then
                        DG.CurrentRow.Cells("DGPrice").Value = Val(DG.CurrentRow.Cells("DGPricePerPcs").Value) * Val(DG.CurrentRow.Cells("DGTotalQty").Value)
                    Else
                        ' DontLetDGSelectIndexChange = False
                        DG.CurrentRow.Cells("DGPrice").Value = Val(DG.CurrentRow.Cells("DGPricePerCrtn").Value) * Val(DG.CurrentRow.Cells("DGTotalQty").Value)
                        'DontLetDGSelectIndexChange = True
                    End If
                End If
                'Conversion's second method..other that convert.todecimal etc.
                'Dim a As Decimal
                'Dim b As String
                'a = 0.34567788
                'b = CType(a, String)
                'Dim c As Decimal
                'c = b.Substring(1, 4)
                'MsgBox(c)
                'MsgBox(c.GetType().ToString())
            Catch ex As Exception

            End Try
        End If
    End Sub
    Sub DGDisabler()
        DGSNo.ReadOnly = True
        DGPType.ReadOnly = True
        DGProductCode.ReadOnly = True
        DGPcsInCrtn.ReadOnly = True
        DGPricePerPcs.ReadOnly = True
        DGPricePerCrtn.ReadOnly = True
        DGQty.ReadOnly = True
    End Sub

    Private Sub txtTotalToPay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalToPay.TextChanged
        txtBalance.Text = Val(txtTotalToPay.Text) - Val(txtTotalPaid.Text)
    End Sub

    Private Sub txtRemarks_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemarks.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub TP2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TP2.Enter
        Try

            Module1.DatasetFill("Select Distinct InvoiceNo from ReturnMain", "ReturnMain")
            cmbSearch.DataSource = ds.Tables("ReturnMain")
            cmbSearch.DisplayMember = ("InvoiceNo")
            cmbSearch.ValueMember = ("InvoiceNo")

            txtCustomerType.Text = ""
            txtCustomerName.Text = ""

            DGSearch.Rows.Clear()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Module1.DatasetFill("Select * from VuCustomerNameForReturnSearch where InvoiceNo='" & cmbSearch.Text & "'", "VuCustomerNameForReturnSearch")
            txtCustomerType.Text = ds.Tables("VuCustomerNameForReturnSearch").Rows(0).Item(1)
            txtCustomerName.Text = ds.Tables("VuCustomerNameForReturnSearch").Rows(0).Item(2)

            Module1.DatasetFill("Select * from VuReturnDetailForReturnSearch where InvoiceNo='" & cmbSearch.Text & "'", "VuReturnDetailForReturnSearch")
            Dim m As Integer
            DGSearch.Rows.Clear()
            For m = 0 To ds.Tables("VuReturnDetailForReturnSearch").Rows.Count - 1

                DGSearch.Rows.Add()
                DGSearch.Rows(m).Cells("DGSSNO").Value = DGSearch.Rows(m).Index + 1
                DGSearch.Rows(m).Cells("DGSPType").Value = ds.Tables("VuReturnDetailForReturnSearch").Rows(m).Item("ProdTypeName")
                DGSearch.Rows(m).Cells("DGSPName").Value = ds.Tables("VuReturnDetailForReturnSearch").Rows(m).Item("Product")
                DGSearch.Rows(m).Cells("DGSCrtnPcs").Value = ds.Tables("VuReturnDetailForReturnSearch").Rows(m).Item("Name")
                DGSearch.Rows(m).Cells("DGSQty").Value = ds.Tables("VuReturnDetailForReturnSearch").Rows(m).Item("Qty")
                If Convert.ToBoolean(ds.Tables("VuReturnDetailForReturnSearch").Rows(m).Item("Status")) = True Then
                    DGSearch.Rows(m).Cells("DGSDamage").Value = " موجود "
                Else
                    DGSearch.Rows(m).Cells("DGSDamage").Value = " "
                End If
                'DGSearch.Rows(m).Cells("DGSDamage").Value = ds.Tables("VuReturnDetailForReturnSearch").Rows(m).Item("Status")
                DGSearch.Rows(m).Cells("DGSBroken").Value = ds.Tables("VuReturnDetailForReturnSearch").Rows(m).Item("Broken")
                DGSearch.Rows(m).Cells("DGSLeak").Value = ds.Tables("VuReturnDetailForReturnSearch").Rows(m).Item("Leak")
                DGSearch.Rows(m).Cells("DGSShort").Value = ds.Tables("VuReturnDetailForReturnSearch").Rows(m).Item("Short")
                DGSearch.Rows(m).Cells("DGSDent").Value = ds.Tables("VuReturnDetailForReturnSearch").Rows(m).Item("Dent")
                DGSearch.Rows(m).Cells("DGSExpired").Value = ds.Tables("VuReturnDetailForReturnSearch").Rows(m).Item("Expired")
                DGSearch.Rows(m).Cells("DGSBeforeExpired").Value = ds.Tables("VuReturnDetailForReturnSearch").Rows(m).Item("DecayedBeforeExpiration")

                DGSearch.Rows(m).Cells("DGSEtc").Value = ds.Tables("VuReturnDetailForReturnSearch").Rows(m).Item("Etc")
                DGSearch.Rows(m).Cells("DGSOk").Value = ds.Tables("VuReturnDetailForReturnSearch").Rows(m).Item("Ok")
                DGSearch.Rows(m).Cells("DGSTotalReturn").Value = ds.Tables("VuReturnDetailForReturnSearch").Rows(m).Item("TotalQty")
                DGSearch.Rows(m).Cells("DGSPrice").Value = ds.Tables("VuReturnDetailForReturnSearch").Rows(m).Item("Price")
                DGSearch.Rows(m).Cells("DGSDesc").Value = ds.Tables("VuReturnDetailForReturnSearch").Rows(m).Item("ReturnReason")

            Next
        Catch ex As Exception

        End Try
    End Sub
    Dim InvoiceNo As String
    Dim PType As String
    Dim na As Integer

    Private Sub BtnPrintAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintAll.Click
        Try
            If DGSearch.Rows.Count = 0 Then

            Else
                Module1.DeleteRecord("ReturnAllReport")
                For na = 0 To DGSearch.Rows.Count - 1
                    Module1.InsertRecord("ReturnAllReport", "N'" & cmbSearch.Text & "',N'" & txtCustomerType.Text & "',N'" & txtCustomerName.Text & "'," & DGSearch.Rows(na).Cells("DGSSNO").Value & ",N'" & DGSearch.Rows(na).Cells("DGSPType").Value & "',N'" & DGSearch.Rows(na).Cells("DGSPName").Value & "',N'" & DGSearch.Rows(na).Cells("DGSCrtnPcs").Value & "',N'" & DGSearch.Rows(na).Cells("DGSDamage").Value & "'," & DGSearch.Rows(na).Cells("DGSBroken").Value & "," & DGSearch.Rows(na).Cells("DGSLeak").Value & "," & DGSearch.Rows(na).Cells("DGSShort").Value & "," & DGSearch.Rows(na).Cells("DGSDent").Value & "," & DGSearch.Rows(na).Cells("DGSExpired").Value & "," & DGSearch.Rows(na).Cells("DGSBeforeExpired").Value & "," & DGSearch.Rows(na).Cells("DGSTotalReturn").Value & "," & DGSearch.Rows(na).Cells("DGSPrice").Value & ",N'" & DGSearch.Rows(na).Cells("DGSDesc").Value & "'")
                Next

                Module1.DatasetFill("Select * from ReturnAllReport where InvoiceNo='" & cmbSearch.Text & "'", "ReturnAllReport")
                Dim rpt As New RptReturnAll
                rpt.SetDataSource(Module1.ds.Tables("ReturnAllReport"))
                frmRptSetup.CV.ReportSource = rpt
                Frm.RptShow()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chbStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbStatus.CheckedChanged
        Try
            If chbStatus.Checked.Equals(True) Then
                cmbCustomerTypeSearch.Enabled = True
                cmbCustomerNameSearch.Enabled = True
                Module1.DatasetFill("Select * from CustomerType", "CustomerType")
                cmbCustomerTypeSearch.DataSource = ds.Tables("CustomerType")
                cmbCustomerTypeSearch.DisplayMember = ("CustomerTypeName")
                cmbCustomerTypeSearch.ValueMember = ("CustomerTypeID")
            Else
                Module1.DatasetFill("Select Distinct InvoiceNo from ReturnMain", "ReturnMain")
                cmbSearch.DataSource = ds.Tables("ReturnMain")
                cmbSearch.DisplayMember = ("InvoiceNo")
                cmbSearch.ValueMember = ("InvoiceNo")

                txtCustomerType.Text = ""
                txtCustomerName.Text = ""

                DGSearch.Rows.Clear()

                cmbCustomerTypeSearch.Enabled = False
                cmbCustomerNameSearch.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCustomerTypeSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomerTypeSearch.SelectedIndexChanged
        Try
            If chbStatus.Checked.Equals(True) Then
                Module1.DatasetFill("select * from Customer where CustomerTypeID=" & cmbCustomerTypeSearch.SelectedValue, "Customer")
                cmbCustomerNameSearch.DataSource = ds.Tables("Customer")
                cmbCustomerNameSearch.DisplayMember = ("CustomerName")
                cmbCustomerNameSearch.ValueMember = ("CustomerID")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCustomerNameSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomerNameSearch.SelectedIndexChanged
        Try
            If chbStatus.Checked.Equals(True) Then
                Module1.DatasetFill("Select Distinct InvoiceNo from ReturnMain where CustomerID=" & cmbCustomerNameSearch.SelectedValue, "ReturnMain")
                cmbSearch.DataSource = ds.Tables("ReturnMain")
                cmbSearch.DisplayMember = ("InvoiceNo")
                cmbSearch.ValueMember = ("InvoiceNo")
            End If
        Catch ex As Exception

        End Try
    End Sub

 
End Class