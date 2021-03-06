Imports System.Data.SqlClient
Imports LanguageSelector
Public Class FrmIssuedOnReplacement
    Dim a As Integer ' it has been used in all places , so do not ever create any local dim "a" inside a sub,use some other name.
    Public EditValue As Integer
    Dim cnt As Integer
    Public Var_ReplaceID As Integer
    Dim k As Integer = 0
    Dim AddEdit As Boolean
    Dim CityID As Integer
    Dim CityBasedID As String

    Private Sub FrmIssuedOnReplacement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

        
            Module1.Opencn()
            Me.MaximizeBox = False
            CityID = Frm.lbLocationID.Text
            CityBasedID = Frm.lbLocationName.Text

            CustomerTypeNameInvoiceComboesData_Reload()

            Module1.DatasetFill("Select * from ProductType", "ProductType")
            Call ComboFillerOfFahimshekaib(DGPType, "ProductType", "ProdTypeName", "ProdTypeID")

            Module1.DatasetFill("Select * from VuProduct", "VuProduct")
            Call ComboFillerOfFahimshekaib(DGProductCode, "VuProduct", "Product", "ProdCode")

            Module1.DatasetFill("Select * from CartonPiece", "CartonPiece")
            Call ComboFillerOfFahimshekaib(DGCrtnPcs, "CartonPiece", "Name", "ID")
            Call txtfill()

            TB1.Left = pnlcentre.Width / 2 - (TB1.Width / 2)
            TB1.Top = pnlcentre.Height / 2 - (TB1.Height / 2)
            pnlcentre.Left = Me.Width / 2 - (pnlcentre.Width / 2)
            pnlcentre.Top = Me.Height / 2 - (pnlcentre.Height / 2)

            If Frm.GID.Text > 2 Then
                '    Module1.CMStatusDisable(CM)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CustomerTypeNameInvoiceComboesData_Reload()
        Module1.DatasetFill("Select * from ReturnMain", "ReturnMain")
        Call ComboFillerOfFahimshekaib(cmbInvoiceNo, "ReturnMain", "InvoiceNo", "ReturnID")


        Module1.DatasetFill("Select * from CustomerType", "CustomerType")
        Call ComboFillerOfFahimshekaib(cmbCustomerType, "CustomerType", "CustomerTypeName", "CustomerTypeID")


        Module1.DatasetFill("Select * from Customer", "Customer")
        Call ComboFillerOfFahimshekaib(cmbCustomerName, "Customer", "CustomerName", "CustomerID")
    End Sub
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

    Private Sub MnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuNew.Click
        Call ClearTheWholeForm()
        Call Module1.CStatus(Me, pnlcentre, TB1, TP1)
        CMStatus()
        DG.ReadOnly = False
        AddEdit = True
        lblMessage.Text = ""
        EditValue = 1
        DGCrtnPcs.ReadOnly = False
    End Sub

    Private Sub MnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSave.Click

        If EditValue = 1 Then
            IDPicker()
        End If

        Dim cmdsave As New SqlCommand
        cmdsave.CommandType = CommandType.StoredProcedure
        cmdsave.CommandText = "InsertUpdateReplaceMain"
        cmdsave.Connection = cn
        cmdsave.Parameters.Add("@ReplaceID", SqlDbType.Int).Value = Me.Var_ReplaceID
        cmdsave.Parameters.Add("@CustomerTypeID", SqlDbType.Int).Value = Me.cmbCustomerType.SelectedValue
        cmdsave.Parameters.Add("@CustomerID", SqlDbType.Int).Value = Me.cmbCustomerName.SelectedValue
        cmdsave.Parameters.Add("@InvoiceNo", SqlDbType.NVarChar).Value = Me.cmbInvoiceNo.Text
        cmdsave.Parameters.Add("@ReplacementDate", SqlDbType.SmallDateTime).Value = Me.dtReplacementDate.Value.Date
        cmdsave.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = Me.txtTotalAmountToDeduct.Text.Trim()
        cmdsave.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = Me.txtRemarks.Text
        cmdsave.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
        cmdsave.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & Me.Var_ReplaceID

        cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = EditValue
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmdsave.ExecuteNonQuery()

        cmdsave.Parameters.Clear()

        If EditValue = 1 Then
            Call GridSave()
            SaveIGL()
            'Call GridSubDetailUpdate()

            lblMessage.Text = "ریکارد شما موفقانه ثبت گردید"
            ' MsgBox("Your Record has been saved successfully..")
        Else
         
            Call DeleteGrid()
            Call GridSave()
            CustomerTypeNameInvoiceComboesData_Reload()
            txtfill()
            lblMessage.Text = "ریکارد شما موفقانه تجدید گردید"

            'MsgBox("Your Record has been updated successfully..")
        End If
        Call Module1.CStatus(Me, pnlcentre, TB1, TP1)
        CMStatus()
        DG.ReadOnly = True
        AddEdit = False
        WashUp()
    End Sub

    Private Sub MnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuEdit.Click
        Call Module1.CStatus(Me, pnlcentre, TB1, TP1)
        EditValue = 0
        CMStatus()
        DG.ReadOnly = False
        AddEdit = True
        lblMessage.Text = ""
        DGCrtnPcs.ReadOnly = False
    End Sub

    Private Sub MnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDelete.Click
        Try
            If Not Me.Var_ReplaceID.Equals("") Then
                If MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then
                    Module1.DeleteRecord("ReplaceMain", "ReplaceID = " & Me.Var_ReplaceID)
                    Module1.Opencn()

                    cmd.CommandText = " Delete from IGL where ID=" & Var_ReplaceID & "  And Type='Issued On Replacement'"
                    cmd.Connection = cn
                    cmd.ExecuteNonQuery()

                    cnt = ds.Tables("ReplaceMain").Rows.Count - 1
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
    End Sub

    Private Sub MnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuExit.Click
        WashUp()
        Me.Close()
    End Sub
#Region "Sub Functions IDPicker,txtclear,txtfill,OpenGrid,CMStatus,CMStatusDefault,CStatusDefault"
    Sub IDPicker()
        Try

            Dim sqldreader As SqlDataReader
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select Max(ReplaceID) from ReplaceMain"
            cmd.Connection = cn
            If cn.State = ConnectionState.Closed Then cn.Open()
            sqldreader = cmd.ExecuteReader()
            While sqldreader.Read

                If IsDBNull(sqldreader.Item(0)) = True Then
                    Me.Var_ReplaceID = 1
                Else
                    Me.Var_ReplaceID = Val(sqldreader.Item(0)) + 1

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
        dtReplacementDate.Enabled = False
        txtTotalAmountToDeduct.Enabled = False
        txtRemarks.Enabled = False
    End Sub
    Public Sub CMStatusDefault()
        MnuNew.Enabled = True
        MnuEdit.Enabled = True
        MnuSave.Enabled = False
        MnuDelete.Enabled = True
        MnuUndo.Enabled = False

    End Sub




    Sub txtfill()
        Try
            FrmSalePaymentDialogueBox.Var_PaymentFormIsOpen = False
            Module1.DatasetFill("Select * from VuReplace Order by ReplaceID", "VuReplace")

            If ds.Tables("VuReplace").Rows.Count = 0 Then
                Var_ReplaceID = 0
                Call ClearTheWholeForm()

                Exit Sub
            End If

            Me.Var_ReplaceID = Val(ds.Tables("VuReplace").Rows(cnt).Item("ReplaceID"))
            cmbCustomerType.SelectedValue = ds.Tables("VuReplace").Rows(cnt).Item("CustomerTypeID")
            cmbCustomerName.SelectedValue = ds.Tables("VuReplace").Rows(cnt).Item("CustomerID")
            cmbInvoiceNo.Text = ds.Tables("VuReplace").Rows(cnt).Item("InvoiceNo")
            dtReplacementDate.Value = ds.Tables("VuReplace").Rows(cnt).Item("ReplacementDate")
            txtTotalAmountToDeduct.Text = ds.Tables("VuReplace").Rows(cnt).Item("TotalAmount")
            txtRemarks.Text = ds.Tables("VuReplace").Rows(cnt).Item("Remarks")
            Call GridFill()
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
                If ds.Tables("ReplaceMain").Rows.Count = 0 Then Exit Sub
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
            If cnt = ds.Tables("ReplaceMain").Rows.Count - 1 Then Exit Sub
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
            cnt = ds.Tables("ReplaceMain").Rows.Count - 1
            Call txtfill()
            CMStatusDefault()
            CStatusDefault()
        Catch ex As Exception

        End Try
    End Sub
#End Region
    Sub DeleteGrid()

        Dim cmdsave As New SqlCommand
        cmdsave.CommandType = CommandType.StoredProcedure
        cmdsave.CommandText = "DeleteReplaceDetail"
        cmdsave.Connection = cn
        cmdsave.Parameters.Add("@ReplaceID", SqlDbType.Int).Value = Var_ReplaceID
        cmdsave.ExecuteNonQuery()

    End Sub
    Sub GridFill()

        Try
            Dim i As Integer = 0

            DG.Rows.Clear()

            Module1.DatasetFill("Select * from ReplaceDetail where ReplaceID = " & Var_ReplaceID, "ReplaceDetail")

            For i = 0 To ds.Tables("ReplaceDetail").Rows.Count - 1
                DG.Rows.Add()
                DG.Rows(i).Cells("DGSNo").Value = ds.Tables("ReplaceDetail").Rows(i).Item("SNo")
                DG.Rows(i).Cells("DGPType").Value = ds.Tables("ReplaceDetail").Rows(i).Item("ProdTypeID")
                DG.Rows(i).Cells("DGProductCode").Value = ds.Tables("ReplaceDetail").Rows(i).Item("ProdCode")
                DG.Rows(i).Cells("DGPcsInCrtn").Value = ds.Tables("ReplaceDetail").Rows(i).Item("PcsInCrtn")
                DG.Rows(i).Cells("DGPricePerPcs").Value = ds.Tables("ReplaceDetail").Rows(i).Item("PricePerPcs")
                DG.Rows(i).Cells("DGPricePerCrtn").Value = ds.Tables("ReplaceDetail").Rows(i).Item("PricePerCrtn")
                DG.Rows(i).Cells("DGCrtnPcs").Value = ds.Tables("ReplaceDetail").Rows(i).Item("CartonPiece")

                If DG.Rows(i).Cells("DGCrtnPcs").FormattedValue = "1" Then
                    DG.Rows(i).Cells("DGCrtnPcs").Value = ds.Tables("CartonPiece").Rows(0).Item("Name")
                Else
                    DG.Rows(i).Cells("DGCrtnPcs").Value = ds.Tables("CartonPiece").Rows(1).Item("Name")
                End If



                DG.Rows(i).Cells("DGQty").Value = ds.Tables("ReplaceDetail").Rows(i).Item("Qty")
                DG.Rows(i).Cells("DGAmount").Value = ds.Tables("ReplaceDetail").Rows(i).Item("Amount")
                DG.Rows(i).Cells("DGDescription").Value = ds.Tables("ReplaceDetail").Rows(i).Item("Description")


            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub GridSave()
        Dim cmdsaveGrid As New SqlCommand
        cmdsaveGrid.CommandType = CommandType.StoredProcedure
        cmdsaveGrid.CommandText = "InsertUpdateReplaceDetail"
        cmdsaveGrid.Connection = cn
        Try

            For a = 0 To DG.Rows.Count - 1 ' This is 1 because I haven't allowed an extra row at the end of the DataGrid.
                'Trans = cn.BeginTransaction("Fahim")
                cmdsaveGrid.Parameters.Add("@ReplaceID", SqlDbType.Int).Value = Var_ReplaceID
                cmdsaveGrid.Parameters.Add("@Sno", SqlDbType.Int).Value = DG.Rows(a).Cells("DGSno").Value
                cmdsaveGrid.Parameters.Add("@ProdTypeID", SqlDbType.Int).Value = DG.Rows(a).Cells("DGPType").Value
                cmdsaveGrid.Parameters.Add("@ProdCode", SqlDbType.Int).Value = DG.Rows(a).Cells("DGProductCode").Value

                cmdsaveGrid.Parameters.Add("@PcsInCrtn", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGPcsInCrtn").Value
                cmdsaveGrid.Parameters.Add("@PricePerPcs", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGPricePerPcs").Value
                cmdsaveGrid.Parameters.Add("@PricePerCrtn", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGPricePerCrtn").Value
                cmdsaveGrid.Parameters.Add("@CartonPiece", SqlDbType.SmallInt).Value = DG.Rows(a).Cells("DGCrtnPcs").Value

                cmdsaveGrid.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGQty").Value)


                'If DG.Rows(a).Cells("DGchbDefective").Value = DGchbDefective.TrueValue = False Then
                '    cmdsaveGrid.Parameters.Add("@Status", SqlDbType.Bit).Value = 1
                'Else
                '    cmdsaveGrid.Parameters.Add("@Status", SqlDbType.Bit).Value = 0
                'End If
                'cmdsaveGrid.Parameters.Add("@Broken", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGBroken").Value)
                'cmdsaveGrid.Parameters.Add("@Leak", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGLeak").Value)
                'cmdsaveGrid.Parameters.Add("@Short", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGShort").Value)
                'cmdsaveGrid.Parameters.Add("@Dent", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGDent").Value)
                'cmdsaveGrid.Parameters.Add("@Expired", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGExpired").Value)
                'cmdsaveGrid.Parameters.Add("@DecayedBeforeExpiration", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGDecayedBeforeExpiration").Value)

                'cmdsaveGrid.Parameters.Add("@Etc", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGEtc").Value)
                'cmdsaveGrid.Parameters.Add("@Ok", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGOk").Value)
                'cmdsaveGrid.Parameters.Add("@TotalQty", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGTotalQty").Value)
                'cmdsaveGrid.Parameters.Add("@Price", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGPrice").Value)

                'If DG.Rows(a).Cells("DGDescription").Value = Nothing Then
                '    cmdsaveGrid.Parameters.Add("@ReturnReason", SqlDbType.NVarChar).Value = "---"
                'Else
                '    cmdsaveGrid.Parameters.Add("@ReturnReason", SqlDbType.NVarChar).Value = DG.Rows(a).Cells("DGDescription").Value

                'End If
                cmdsaveGrid.ExecuteNonQuery()
                cmdsaveGrid.Parameters.Clear()
                If EditValue <> 1 Then
                    UpdateIGL()
                End If
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
                cmdsaveGridIGL.Parameters("@ID").Value = Var_ReplaceID

                cmdsaveGridIGL.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Me.dtReplacementDate.Value.Date
                cmdsaveGridIGL.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "Issued On Replacement"
                cmdsaveGridIGL.Parameters.Add("@ProductType", SqlDbType.Int).Value = DG.Rows(k).Cells("DGPType").Value
                cmdsaveGridIGL.Parameters.Add("@ProductCode", SqlDbType.Int).Value = DG.Rows(k).Cells("DGProductCode").Value
                cmdsaveGridIGL.Parameters.Add("@PurchaseQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@SaleQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@ReturnQty", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DGTotalQty").Value)
                cmdsaveGridIGL.Parameters.Add("@ClaimQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@DamageQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@CrtnPcs", SqlDbType.SmallInt).Value = Val(DG.Rows(k).Cells("DGCrtnPcs").Value)
                cmdsaveGridIGL.Parameters.Add("@Broken", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Leak", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Short", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Dent", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Expired", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@DecayedBeforeExpiration", SqlDbType.Decimal).Value = 0
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
                cmdsaveGridIGL.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & Me.Var_ReplaceID

                cmdsaveGridIGL.ExecuteNonQuery()
                cmdsaveGridIGL.Parameters.Clear()
            Next
        Catch ex As Exception
        End Try

    End Sub
    Sub UpdateIGL()
        Try

            Dim OldQty As Decimal = 0
            Dim NewQty As Decimal = 0
            Dim TotalQty As Decimal = 0
            Dim cmdsaveGridIGL As New SqlCommand
            cmdsaveGridIGL.CommandType = CommandType.StoredProcedure
            cmdsaveGridIGL.CommandText = "InsertIGL"
            cmdsaveGridIGL.Connection = cn

            Try

                Module1.DatasetFill("Select Sum(SaleQty)as ReturnQuantity from VuIGL where ID=" & Var_ReplaceID & " and ProductType =" & DG.Rows(a).Cells(1).Value & " and ProductCode=" & DG.Rows(a).Cells(2).Value & " And Type='Issued On Replacement'", "VuIGL")
                OldQty = ds.Tables("VuIGL").Rows(0).Item("ReturnQuantity")
                NewQty = Val(DG.Rows(a).Cells("DGTotalQty").Value)
                TotalQty = NewQty - OldQty
            Catch ex As Exception
            End Try

            If TotalQty = 0 Then
                Exit Sub
            End If
            For k = 0 To 1 - 1

                cmdsaveGridIGL.Parameters.Add("@ID", SqlDbType.Int)
                cmdsaveGridIGL.Parameters("@ID").Value = Var_ReplaceID
                cmdsaveGridIGL.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = dtReplacementDate.Value.Date
                cmdsaveGridIGL.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "Issued On Replacement"
                cmdsaveGridIGL.Parameters.Add("@ProductType", SqlDbType.Int).Value = DG.Rows(a).Cells("DGPType").Value
                cmdsaveGridIGL.Parameters.Add("@ProductCode", SqlDbType.Int).Value = DG.Rows(a).Cells("DGProductCode").Value
                cmdsaveGridIGL.Parameters.Add("@PurchaseQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@SaleQty", SqlDbType.Decimal).Value = TotalQty
                cmdsaveGridIGL.Parameters.Add("@ReturnQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@ClaimQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@DamageQty", SqlDbType.Decimal).Value = 0




                'cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = "Purchase"
                cmdsaveGridIGL.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
                cmdsaveGridIGL.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & Var_ReplaceID

                cmdsaveGridIGL.ExecuteNonQuery()
                cmdsaveGridIGL.Parameters.Clear()
            Next
        Catch ex As Exception
        End Try
    End Sub
End Class