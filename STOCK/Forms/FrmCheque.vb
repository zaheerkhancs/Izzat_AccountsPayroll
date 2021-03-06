Imports System.Data.SqlClient

Imports LanguageSelector
Public Class FrmCheque
    Dim a As Integer
    Public EditValue As Integer
    Dim cnt As Integer
    Public Var_ChequeID As String
    Dim AddEdit As Boolean
    Dim azizkhanqarabaghi As Boolean
    Dim CurrentRowsPType As String
    Dim CurrentRowsProdCode As String
    Dim CurrentRowCrtnPcs As String
    Dim CityID As Integer
    Dim CityBasedID As String
    Dim QtyOfEachProductInPiece As Integer
    Dim QtyOfEachProductInCarton As Integer
    Dim CheqNoChange As String
    Dim IssueTrue_ReceiveFalse As Boolean
    Private Sub FrmCheque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Module1.Opencn()
        CityID = Frm.lbLocationID.Text
        CityBasedID = Frm.lbLocationName.Text
        Module1.DatasetFill("Select * from ChequeMain", "ChequeMain")
        ' Filling Comboes of CustomerType,ProductType and Product ..Customer Combo will be filled later in type change.
        Module1.DatasetFill("Select * from Customer", "Customer")
        Call ComboFillerOfFahimshekaib(cmbCustomerName, "Customer", "CustomerName", "CustomerID")
        cmbCustomerName.SelectedIndex = -1



        Module1.DatasetFill("Select * from SaleMain", "SaleMain")
        Call ComboFillerOfFahimshekaib(cmbInvoiceNo, "SaleMain", "InvoiceNo", "SaleID")

        cmbInvoiceNo.SelectedIndex = -1

        Module1.DatasetFill("Select * from OrderFromCustomerMain", "OrderFromCustomerMain")
        Call ComboFillerOfFahimshekaib(cmbOrderNo, "OrderFromCustomerMain", "SalOrderNo", "SalOrderID")
        cmbOrderNo.SelectedIndex = -1


        Module1.DatasetFill("Select * from GoDown", "GoDown")
        Call ComboFillerOfFahimshekaib(cmbGodownName, "GoDown", "GoDownName", "GoDownID")
        cmbGodownName.SelectedIndex = -1

        Module1.DatasetFill("Select * from ProductType", "ProductType")
        Call ComboFillerOfFahimshekaib(DGPType, "ProductType", "ProdTypeName", "ProdTypeID")

        Module1.DatasetFill("Select * from VuProduct", "VuProduct")
        Call ComboFillerOfFahimshekaib(DGProductCode, "VuProduct", "Product", "ProdCode")

        Module1.DatasetFill("Select * from CartonPiece", "CartonPiece")
        Call ComboFillerOfFahimshekaib(DGCrtnPcs, "CartonPiece", "Name", "ID")
        'DGCrtnPcs.DataSource = ds.Tables("CartonPiece")
        'DGCrtnPcs.DisplayMember = "Name"
        'DGCrtnPcs.ValueMember = "ID"

        Call txtfill()
        azizkhanqarabaghi = True
        Me.MaximizeBox = False

        TB1.Left = pnlcentre.Width / 2 - (TB1.Width / 2)
        TB1.Top = pnlcentre.Height / 2 - (TB1.Height / 2)
        pnlcentre.Left = Me.Width / 2 - (pnlcentre.Width / 2)
        pnlcentre.Top = Me.Height / 2 - (pnlcentre.Height / 2)
        If Frm.GID.Text > 2 Then
            Module1.CMStatusDisable(CM)
        End If
    End Sub

    Private Sub cmbInvoiceNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbInvoiceNo.SelectedIndexChanged

        Try
            If AddEdit.Equals(True) Then
                Module1.DatasetFill("Select CustomerID,SalOrderID from VuSaleMain where SaleID = " & cmbInvoiceNo.SelectedValue, "VuSaleMain")
                If ds.Tables("VuSaleMain").Rows.Count = 0 Then Exit Sub
                cmbOrderNo.SelectedIndex = -1
                cmbCustomerName.SelectedIndex = -1
                cmbOrderNo.SelectedValue = ds.Tables("VuSaleMain").Rows(0).Item("SalOrderID")
                cmbCustomerName.SelectedValue = ds.Tables("VuSaleMain").Rows(0).Item("CustomerID")
                'MsgBox(cmbCustomerName.Text)
                GridFillFromSales()
                txtCurrentProdAmount.Text = 0
            Else

                '  GridFill()
            End If
        Catch ex As Exception

        End Try


    End Sub

   
#Region "Sub Functions IDPicker,txtclear,txtfill,OpenGrid,CMStatus,CMStatusDefault,CStatusDefault"
    Sub IDPicker()
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
            Dim sqldreader As SqlDataReader
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select Max(CheqID) from ChequeMain"
            cmd.Connection = cn

            sqldreader = cmd.ExecuteReader()
            While sqldreader.Read

                If IsDBNull(sqldreader.Item(0)) = True Then
                    Me.Var_ChequeID = 1
                Else
                    Me.Var_ChequeID = Val(sqldreader.Item(0)) + 1

                End If
            End While
            sqldreader.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub CStatusDefault(ByVal Frm As Form, ByVal pnlcenter As Panel, ByVal TB As TabControl, ByVal tp As TabPage)
        Dim A As Control
        For Each A In Frm.Controls
            If TypeOf A Is Panel Then
                Dim C As Control
                For Each C In A.Controls
                    If TypeOf C Is TabControl Then
                        Dim D As Control
                        For Each D In C.Controls
                            If TypeOf D Is TabPage Then
                                If D.Name = "TP1" Then
                                    Dim E As Control
                                    For Each E In D.Controls
                                        If TypeOf E Is TextBox Or TypeOf E Is ComboBox Or TypeOf E Is DateTimePicker Then

                                            E.Enabled = False

                                        End If
                                    Next
                                End If
                            End If
                        Next
                    End If
                Next
            End If
        Next
    End Sub
    Public Sub CMStatusDefault()
        MnuNew.Enabled = True
        'MnuEdit.Enabled = True
        MnuSave.Enabled = False
        MnuDelete.Enabled = True
        MnuUndo.Enabled = False
    End Sub
   
    Sub CStutus(ByVal Frm As Form, ByVal pnlcenter As Panel, ByVal TB As TabControl, ByVal tp As TabPage)
        Dim A As Control
        For Each A In Frm.Controls
            If TypeOf A Is Panel Then
                Dim C As Control
                For Each C In A.Controls
                    If TypeOf C Is TabControl Then
                        Dim D As Control
                        For Each D In C.Controls
                            If TypeOf D Is TabPage Then
                                If D.Name = "TP1" Then
                                    Dim E As Control
                                    For Each E In D.Controls
                                        If TypeOf E Is TextBox Or TypeOf E Is ComboBox Or TypeOf E Is DateTimePicker Then

                                            E.Enabled = Not E.Enabled

                                        End If
                                    Next
                                End If
                            End If
                        Next
                    End If
                Next
            End If
        Next
    End Sub
    Sub txtclear(ByVal Frm As Form, ByVal pnlcenter As Panel, ByVal TB As TabControl, ByVal tp As TabPage)
        Dim A As Control
        For Each A In Frm.Controls
            If TypeOf A Is Panel Then
                Dim C As Control
                For Each C In A.Controls
                    If TypeOf C Is TabControl Then
                        Dim D As Control
                        For Each D In C.Controls
                            If TypeOf D Is TabPage Then
                                If D.Name = "TP1" Then
                                    Dim E As Control
                                    For Each E In D.Controls
                                        If TypeOf E Is TextBox Or TypeOf E Is ComboBox Or TypeOf E Is DateTimePicker Then

                                            E.Text = ""

                                        End If
                                    Next
                                End If
                            End If
                        Next
                    End If
                Next
            End If
        Next
    End Sub
    Sub txtfill()
a:
        Try
            Module1.DatasetFill("Select * from ChequeMain Order by CheqID", "ChequeMain")

            If ds.Tables("ChequeMain").Rows.Count = 0 Then
                Var_ChequeID = 0
                txtclear(Me, pnlcentre, TB1, TP1)
                DG.Rows.Clear()
                Exit Sub
            End If

            Me.Var_ChequeID = Val(ds.Tables("ChequeMain").Rows(cnt).Item("CheqID"))
            txtChequeNo.Text = ds.Tables("ChequeMain").Rows(cnt).Item("CheqNo")
            dtChkDate.Value = ds.Tables("ChequeMain").Rows(cnt).Item("CheqDate")
            cmbInvoiceNo.SelectedValue = ds.Tables("ChequeMain").Rows(cnt).Item("SaleID")
            Call OrderNo_And_CustomerName()
            cmbCustomerName.SelectedValue = ds.Tables("ChequeMain").Rows(cnt).Item("CustomerID")
            cmbGodownName.SelectedValue = ds.Tables("ChequeMain").Rows(cnt).Item("GodownID")
            txtGodownKeeper.Text = ds.Tables("ChequeMain").Rows(cnt).Item("GoDownKeeperName")
            txtGodownPhoneNo.Text = ds.Tables("ChequeMain").Rows(cnt).Item("GoDownPhone")
            txtGodownAddress.Text = ds.Tables("ChequeMain").Rows(cnt).Item("GoDownAddress")

            ' cmbCustomerName.SelectedValue = ds.Tables("ChequeMain").Rows(cnt).Item("TotalAmount")

            cmbGodownName.SelectedValue = ds.Tables("ChequeMain").Rows(cnt).Item("GodownID")
            txtRemarks.Text = ds.Tables("ChequeMain").Rows(cnt).Item("Remarks")


            Call GridFill()
        Catch ex As Exception
            cnt = cnt - 1
            GoTo a
        End Try
      
    End Sub
    Sub OrderNo_And_CustomerName()
        Try
            Module1.DatasetFill("Select SalOrderID,CustomerID from VuSaleMain where InvoiceNo ='" & cmbInvoiceNo.Text & "'", "VuSaleMain")
            cmbOrderNo.SelectedValue = Val(ds.Tables("VuSaleMain").Rows(0).Item("SalOrderID"))
            cmbCustomerName.SelectedValue = ds.Tables("VuSaleMain").Rows(0).Item("CustomerID")
        Catch ex As Exception

        End Try


    End Sub
    Sub CMStatus()
        MnuNew.Enabled = Not MnuNew.Enabled
        'MnuEdit.Enabled = Not MnuEdit.Enabled
        MnuSave.Enabled = Not MnuSave.Enabled
        MnuDelete.Enabled = Not MnuDelete.Enabled
        MnuUndo.Enabled = Not MnuUndo.Enabled

    End Sub

#End Region


#Region "ContextMenuButtons"


    Private Sub MnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuNew.Click
        'Me.RightToLeft = Windows.Forms.RightToLeft.Yes
        Call txtclear(Me, pnlcentre, TB1, TP1)
        Call CStutus(Me, pnlcentre, TB1, TP1)
        EditValue = 1
        txtChequeNo.Focus()
        CMStatus()
        DG.ReadOnly = False
        AddEdit = True
        lblMessage.Text = ""
        cmbInvoiceNo.SelectedIndex = -1
        cmbGodownName.SelectedIndex = -1
    End Sub

    Private Sub MnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSave.Click
        If DG.Rows(0).Cells("DGQty").Value = 0 Then Exit Sub
        IssueTrue_ReceiveFalse = True
        If txtChequeNo.Text.Trim.Equals("") Then
            MsgBox("Please enter a check number")
            Exit Sub
        End If
        If cmbGodownName.Text.Trim.Equals("") Then
            MsgBox("No Godown is selected")
            Exit Sub
        End If
        If EditValue = 1 Then
            IDPicker()
        End If
        'Dim twice As Integer = 0
        'For twice = 0 To 1


        Dim cmdsave As New SqlCommand
        cmdsave.CommandType = CommandType.StoredProcedure
        cmdsave.CommandText = "InsertUpdateChequeMain"
        cmdsave.Connection = cn
        cmdsave.Parameters.Add("@CheqID", SqlDbType.VarChar).Value = Me.Var_ChequeID
        cmdsave.Parameters.Add("@CheqNo", SqlDbType.NVarChar).Value = Me.txtChequeNo.Text.Trim() & CheqNoChange
        cmdsave.Parameters.Add("@CheqDate", SqlDbType.SmallDateTime).Value = Me.dtChkDate.Value.Date
        cmdsave.Parameters.Add("@SaleID", SqlDbType.Int).Value = Me.cmbInvoiceNo.SelectedValue
        cmdsave.Parameters.Add("@SalOrderID", SqlDbType.Int).Value = Me.cmbOrderNo.SelectedValue
        cmdsave.Parameters.Add("@CustomerID", SqlDbType.Int).Value = Me.cmbCustomerName.SelectedValue
        cmdsave.Parameters.Add("@GodownID", SqlDbType.Int).Value = Me.cmbGodownName.SelectedValue
        'cmdsave.Parameters.Add("@keeperName", SqlDbType.NVarChar).Value = Me.txtGodownKeeper.Text.Trim()
        cmdsave.Parameters.Add("@GoDownKeeperName", SqlDbType.NVarChar).Value = Me.txtGodownKeeper.Text.Trim()
        cmdsave.Parameters.Add("@GoDownPhone", SqlDbType.NVarChar).Value = Me.txtGodownPhoneNo.Text.Trim()
        cmdsave.Parameters.Add("@GoDownAddress", SqlDbType.NVarChar).Value = Me.txtGodownAddress.Text.Trim()
        cmdsave.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = Me.txtRemarks.Text
        cmdsave.Parameters.Add("@CityID", SqlDbType.Int).Value = Val("1")
        cmdsave.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = "KBL" & "-" & Me.Var_ChequeID

        cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = EditValue
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmdsave.ExecuteNonQuery()

        cmdsave.Parameters.Clear()

        If EditValue = 1 Then
            Call GridSave()
            Call SaveGodownIGL()
            'GridSaveIntoGodownStock()
            lblMessage.Text = "ریکارد شما موفقانه ثبت گردید"
        Else
            Call DeleteGrid()
            Call GridSave()
            lblMessage.Text = "ریکارد شما موفقانه تجدید گردید"

        End If
        '    If twice = 0 Then


        '        Me.Var_ChequeID = Me.Var_ChequeID & " - Copy"
        '        Me.CheqNoChange = Me.CheqNoChange & " - Copy"
        '    Else
        '        Me.Var_ChequeID = Var_ChequeID.Substring(0, 1)
        '        Me.CheqNoChange = CheqNoChange.Substring(0, 1)
        '    End If
        'Next

        Call CStutus(Me, pnlcentre, TB1, TP1)
        CMStatus()
        DG.ReadOnly = True
        AddEdit = False
        Module1.DatasetFill("Select * from RptVuCheqMain", "RptVuCheqMain")
        Dim z As Integer = 0
        For Each dtr As DataRow In ds.Tables("RptVuCheqMain").Rows

            If Me.Var_ChequeID = dtr(0) Then
                cnt = z
            End If
            z = z + 1
        Next
        ShowProductAmount()
    End Sub

    Private Sub MnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'On 04 Sep 08 Fahim decided to remove Edit from Cheque Form. That is because if you 
        'made a mistake in a cheque then delete it and make a new cheque.
        'In real world if u do a mistake ,then the cheque becomes useless.(Actually this is not our reason for us,here we get problem with GodownIGL so this is the rule we defined.)
        'If Module1.ds.Tables("ChequeMain").Rows.Count = 0 Then Exit Sub
        'Call CStutus(Me, pnlcentre, TB1, TP1)
        'EditValue = 0
        'CMStatus()

        'DG.ReadOnly = False
        ''DGProductCode.Visible = True
        'AddEdit = True
        'lblMessage.Text = ""
    End Sub


    Private Sub MnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDelete.Click
        IssueTrue_ReceiveFalse = False
        'It will restore the quantity of products issued it deleting chequeNo.

        If Not Me.Var_ChequeID.Equals(0) Then

            If MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then
                Module1.DeleteRecord("ChequeMain", "CheqID=" & Me.Var_ChequeID)
                Module1.DeleteRecord("ChequeDetail", "CheqID=" & Me.Var_ChequeID)
                'but why we write date in following condition ?? it left one thing in GodownIGL after deleting all.check it once.
                Module1.DeleteRecord("GoDownIGL", "RecordID=" & Me.Var_ChequeID & " And Type='Issued' And dtDate='" & dtChkDate.Value.Date & "'")

                'SaveGodownIGL()
                Try

                    Dim No_OF_Rows_Present As Integer = Module1.ds.Tables("ChequeMain").Rows.Count


                    If No_OF_Rows_Present = cnt Then

                    ElseIf No_OF_Rows_Present < cnt Then
                        cnt = cnt + 2
                    ElseIf cnt < No_OF_Rows_Present Then
                        If cnt = 0 Then
                            cnt = cnt + 1
                        End If

                    End If

                    If cnt = 0 Then
                        Call ClearTheWholeForm()

                        Exit Sub
                    Else
                        cnt = cnt - 1
                        Call txtfill()
                        ShowProductAmount()
                    End If

                    ' Call TxtFillAfterDeletion()
                    lblMessage.Text = "ریکارد مذکور موفقانه حذف گردید "
                Catch ex As Exception

                End Try
            End If
        End If

    End Sub
    Sub ClearTheWholeForm()
        txtclear(Me, pnlcentre, TB1, TP1)
        cmbOrderNo.SelectedIndex = -1
        DG.Rows.Clear()
    End Sub
    Private Sub TxtFillAfterDeletion()

        If cnt <> Module1.ds.Tables("OrderFromCustomerMain").Rows.Count Then
            ' MsgBox(Module1.ds.Tables("OrderFromCustomerMain").Rows.Count)

            cnt = cnt - 1
            txtfill()
        Else
            If cnt <> 0 Then
                cnt = cnt - 1
                txtfill()
            Else
                MsgBox("There is no more record")
            End If
        End If
    End Sub



    Private Sub MnuUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuUndo.Click

        Call CStutus(Me, pnlcentre, TB1, TP1)
        txtclear(Me, pnlcentre, TB1, TP1)
        CMStatus()
        Call txtfill()
        DG.ReadOnly = True
        'DGProductCode.Visible = False
        AddEdit = False
    End Sub

    Private Sub MnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuExit.Click

        Me.Close()
    End Sub
#End Region
#Region "Navigation"
    Private Sub TSFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSFirst.Click
        cnt = 0
        Call txtfill()
        CMStatusDefault()
        CStatusDefault(Me, pnlcentre, TB1, TP1)
    End Sub
    Private Sub TSPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSPrevious.Click
        If cnt = 0 Then Exit Sub
        cnt = cnt - 1
        Call txtfill()
        CMStatusDefault()
        CStatusDefault(Me, pnlcentre, TB1, TP1)
    End Sub

    Private Sub TSNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSNext.Click
        If cnt = ds.Tables("ChequeMain").Rows.Count - 1 Then Exit Sub
        cnt = cnt + 1
        Call txtfill()
        CMStatusDefault()
        CStatusDefault(Me, pnlcentre, TB1, TP1)
    End Sub

    Sub ComboFillerOfFahimshekaib(ByVal ComboName As ComboBox, ByVal NameOfTable As String, ByVal DisplayMember As String, ByVal ValueMember As String)
        ComboName.DataSource = Nothing
        ComboName.Items.Clear()
        ComboName.DataSource = ds.Tables(NameOfTable)
        ComboName.DisplayMember = DisplayMember
        ComboName.ValueMember = ValueMember
        ' MsgBox(ComboName.Name & " contains " & ComboName.Items.Count)
    End Sub
    Sub ComboFillerOfFahimshekaib(ByVal ComboName As DataGridViewComboBoxColumn, ByVal NameOfTable As String, ByVal DisplayMember As String, ByVal ValueMember As String)

        ComboName.DataSource = ds.Tables(NameOfTable)
        ComboName.DisplayMember = DisplayMember
        ComboName.ValueMember = ValueMember
    End Sub
    Private Sub TSLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSLast.Click
        cnt = ds.Tables("ChequeMain").Rows.Count - 1
        Call txtfill()
        CMStatusDefault()
        CStatusDefault(Me, pnlcentre, TB1, TP1)
    End Sub
#End Region
    Sub GridSave()
        Dim cmdsaveGrid As New SqlCommand
        cmdsaveGrid.CommandType = CommandType.StoredProcedure
        cmdsaveGrid.CommandText = "InsertUpdateChequeDetail"
        cmdsaveGrid.Connection = cn
        Try

            For a = 0 To DG.Rows.Count - 1
                'Trans = cn.BeginTransaction("Fahim")
                cmdsaveGrid.Parameters.Add("@CheqID", SqlDbType.VarChar).Value = Var_ChequeID
                cmdsaveGrid.Parameters.Add("@SNo", SqlDbType.Int).Value = DG.Rows(a).Cells("DGSno").Value
                cmdsaveGrid.Parameters.Add("@ProdTypeID", SqlDbType.Int).Value = DG.Rows(a).Cells("DGPType").Value
                cmdsaveGrid.Parameters.Add("@ProdCode", SqlDbType.Int).Value = DG.Rows(a).Cells("DGProductCode").Value
                cmdsaveGrid.Parameters.Add("@CrtnPcs", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGCrtnPcs").Value)
                cmdsaveGrid.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGQty").Value)
                If DG.Rows(a).Cells("DGDescription").Value = Nothing Then
                    cmdsaveGrid.Parameters.Add("@ProdDescription", SqlDbType.NVarChar).Value = "---"
                Else
                    cmdsaveGrid.Parameters.Add("@ProdDescription", SqlDbType.NVarChar).Value = DG.Rows(a).Cells("DGDescription").Value

                End If
                'Trans.Commit()
                cmdsaveGrid.ExecuteNonQuery()
                cmdsaveGrid.Parameters.Clear()
            Next
        Catch ex As Exception
            'Trans.Rollback()
        End Try


    End Sub
    Sub DeleteGrid()

        Dim cmdsave As New SqlCommand
        cmdsave.CommandType = CommandType.StoredProcedure
        cmdsave.CommandText = "DeleteChequeDetail"
        cmdsave.Connection = cn
        cmdsave.Parameters.Add("@CheqID", SqlDbType.Int).Value = Var_ChequeID
        cmdsave.ExecuteNonQuery()

    End Sub
    Sub SaveGodownIGL()
        Dim IssueQuantity As Decimal = 0
        Dim ReceiveQuantity As Decimal = 0
      
        Dim k As Integer
        Dim cmdsaveGridIGL As New SqlCommand
        cmdsaveGridIGL.CommandType = CommandType.StoredProcedure
        cmdsaveGridIGL.CommandText = "InsertGoDownIGL"
        cmdsaveGridIGL.Connection = cn
        Try
            For k = 0 To DG.Rows.Count - 1

                cmdsaveGridIGL.Parameters.Add("@RecordID", SqlDbType.Int)
                cmdsaveGridIGL.Parameters("@RecordID").Value = Var_ChequeID

                cmdsaveGridIGL.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Me.dtChkDate.Value.Date
                cmdsaveGridIGL.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "Issued"
                cmdsaveGridIGL.Parameters.Add("@GodownID", SqlDbType.Int).Value = cmbGodownName.SelectedValue

                cmdsaveGridIGL.Parameters.Add("@ProductType", SqlDbType.Int).Value = DG.Rows(k).Cells("DGPType").Value
                cmdsaveGridIGL.Parameters.Add("@ProductCode", SqlDbType.Int).Value = DG.Rows(k).Cells("DGProductCode").Value
                Try
                    Dim smallint As Int16 = DG.Rows(k).Cells("DGCrtnPcs").Value
                    cmdsaveGridIGL.Parameters.Add("@CrtnPcs", SqlDbType.SmallInt).Value = smallint
                Catch ex As Exception
                    Dim CrtnPcsID As Integer

                    For Each dtr As DataRow In Module1.ds.Tables("CartonPiece").Rows
                        If dtr(1) = DG.CurrentRow.Cells("DGCrtnPcs").Value Then
                            CrtnPcsID = dtr(0)
                        End If
                    Next
                    cmdsaveGridIGL.Parameters.Add("@CrtnPcs", SqlDbType.SmallInt).Value = CrtnPcsID
                End Try

        'DG.Rows(k).Cells("DGCrtnPcs").Value
        'Takes decision whether the record is being inserted or deleted.
        If IssueTrue_ReceiveFalse = True Then
            IssueQuantity = DG.Rows(k).Cells("DGQty").Value
            ReceiveQuantity = 0
        Else
            IssueQuantity = 0
            ReceiveQuantity = DG.Rows(k).Cells("DGQty").Value

        End If
        cmdsaveGridIGL.Parameters.Add("@RecQty", SqlDbType.Decimal).Value = ReceiveQuantity
        cmdsaveGridIGL.Parameters.Add("@IssueQty", SqlDbType.Decimal).Value = IssueQuantity


        Try
            If DG.Rows(k).Cells("DGDescription").Value = "" Then
                If IssueTrue_ReceiveFalse = True Then
                    cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = " "
                Else
                    cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = " Deleted from Cheque Form"
                End If

            Else
                If IssueTrue_ReceiveFalse = True Then
                    cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = DG.Rows(k).Cells("DGDescription").Value
                Else
                    cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = " Deleted from Cheque Form"
                End If

            End If
        Catch ex As Exception

        End Try

        cmdsaveGridIGL.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
        cmdsaveGridIGL.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & Var_ChequeID

        cmdsaveGridIGL.ExecuteNonQuery()
        cmdsaveGridIGL.Parameters.Clear()
            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub GridFill()
        Try
            Dim i As Integer = 0

            DG.Rows.Clear()

            Module1.DatasetFill("Select * from ChequeDetail where CheqID = '" & Var_ChequeID & "'", "ChequeDetail")
            For i = 0 To ds.Tables("ChequeDetail").Rows.Count - 1
                DG.Rows.Add()
                DG.Rows(i).Cells("DGSNo").Value = ds.Tables("ChequeDetail").Rows(i).Item("SNo")
                DG.Rows(i).Cells("DGPType").Value = ds.Tables("ChequeDetail").Rows(i).Item("ProdTypeID")
                DG.Rows(i).Cells("DGProductCode").Value = ds.Tables("ChequeDetail").Rows(i).Item("ProdCode")
                DG.Rows(i).Cells("DGCrtnPcs").Value = ds.Tables("ChequeDetail").Rows(i).Item("CrtnPcs")
                If DG.Rows(i).Cells("DGCrtnPcs").Value = 2 Then
                    DG.Rows(i).Cells("DGCrtnPcs").Value = ds.Tables("CartonPiece").Rows(1).Item("Name")
                Else
                    DG.Rows(i).Cells("DGCrtnPcs").Value = ds.Tables("CartonPiece").Rows(0).Item("Name")
                End If
                DG.Rows(i).Cells("DGQty").Value = ds.Tables("ChequeDetail").Rows(i).Item("Qty")
                DG.Rows(i).Cells("DGDescription").Value = ds.Tables("ChequeDetail").Rows(i).Item("ProdDescription")

            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub GridFillFromSales()
        Try
            Dim i As Integer = 0

            DG.Rows.Clear()

            Module1.DatasetFill("Select * from SaleDetail where SaleID = " & cmbInvoiceNo.SelectedValue, "SaleDetail")
            For i = 0 To ds.Tables("SaleDetail").Rows.Count - 1
                DG.Rows.Add()
                DG.Rows(i).Cells("DGSNo").Value = ds.Tables("SaleDetail").Rows(i).Item("SNo")
                DG.Rows(i).Cells("DGPType").Value = ds.Tables("SaleDetail").Rows(i).Item("ProdTypeID")
                DG.Rows(i).Cells("DGProductCode").Value = ds.Tables("SaleDetail").Rows(i).Item("ProdCode")
                DG.Rows(i).Cells("DGCrtnPcs").Value = ds.Tables("SaleDetail").Rows(i).Item("CrtnPcs")
                'DG.Rows(i).Cells("DGQty").Value = ds.Tables("SaleDetail").Rows(i).Item("RemainingQty") 
                ' I don't want to let the user see the remaining quantity, security issue. on calculation
                DG.Rows(i).Cells("DGDescription").Value = "---"
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbGodownName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGodownName.SelectedIndexChanged
        Try
           
            If AddEdit.Equals(True) Then
                Module1.DatasetFill("Select GoDownKepperName,GoDownPhone,GoDownAddress from VuGodown where GodownID =" & cmbGodownName.SelectedValue, "VuGodown")
                'If ds.Tables("VuGodown").Rows.Count = 0 Then Exit Sub
                txtGodownKeeper.Text = ds.Tables("VuGodown").Rows(0).Item("GoDownKepperName")
                txtGodownPhoneNo.Text = ds.Tables("VuGodown").Rows(0).Item("GoDownPhone")
                txtGodownAddress.Text = ds.Tables("VuGodown").Rows(0).Item("GoDownAddress")
            Else

            End If

        Catch ex As Exception
            'txtGodownKeeper.Text = ""
            'txtGodownPhoneNo.Text = ""
            'txtGodownAddress.Text = ""
        End Try
        Call ShowProductAmount()
        For Each dgcol As DataGridViewColumn In DG.Columns
            If dgcol.Name = "DGQty" Then
                For Each dgrow As DataGridViewRow In DG.Rows
                    dgrow.Cells("DGQty").Value = 0
                Next
            End If
        Next

    End Sub
    Private Sub NumericKeys(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGQty" Then
            If IsNumeric(Me.ActiveControl.Text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Then e.Handled = True
            Me.DG.CurrentRow.Cells("DGQty").Value = Me.ActiveControl.Text & e.KeyChar
            'If DG.CurrentRow.Cells("DGCrtnPcs").Value = 1 Then
            'Else
            If Val(Me.DG.CurrentRow.Cells("DGQty").Value) > Val(txtCurrentProdAmount.Text) Then e.Handled = True

            'End If

        End If

        If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGDescription" Then
            Me.DG.CurrentRow.Cells("DGDescription").Value = Me.ActiveControl.Text & e.KeyChar
        End If
    End Sub
    Private Sub DelegateCellData(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Me.DG.CurrentCell.Value = Me.ActiveControl.Text & e.KeyChar
    End Sub
    Private Sub DG_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DG.EditingControlShowing
        Try

            If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGQty" Then

                Dim ltxt As New TextBox
                ltxt = CType(e.Control, TextBox)
                AddHandler ltxt.KeyPress, AddressOf NumericKeys
            End If

            If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGDescription" Then
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
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try

            If Var_ChequeID = "0" Then
                Exit Sub
            Else

                Dim frm1 As New ChequeCriteriaForPrint(Var_ChequeID)
                frm1.Show()
                frm1.BringToFront()
                frm1.TopMost = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DG_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DG.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbInvoiceNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbInvoiceNo.KeyPress
        If e.KeyChar = Chr(13) Then
            'Dim ee As System.EventArgs
            cmbInvoiceNo_SelectedIndexChanged(cmbInvoiceNo, e)
        End If
    End Sub

    Private Sub cmbGodownName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbGodownName.KeyPress
        If e.KeyChar = Chr(13) Then
            'Dim ee As System.EventArgs
            cmbGodownName_SelectedIndexChanged(cmbInvoiceNo, e)
        End If
    End Sub

    Private Sub DG_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.RowEnter
        'Try
        '    CurrentRowsPType = DG.CurrentRow.Cells("DGPType").Value
        '    CurrentRowsProdCode = DG.CurrentRow.Cells("DGProductCode").Value
        '    CurrentRowCrtnPcs = DG.CurrentRow.Cells("DGCrtnPcs").Value
        'Catch ex As Exception

        'End Try

        'ShowProductAmount()
    End Sub
    Sub ShowProductAmount()
        Try


            Module1.DatasetFill("Select Sum(RecQty)-Sum(IssueQty) as RemainingQty from GoDownIGL where GodownID=" & cmbGodownName.SelectedValue & " And ProductType=" & CurrentRowsPType & " And ProductCode=" & CurrentRowsProdCode & " And CrtnPcs = " & CurrentRowCrtnPcs, "GoDownIGL")
            If ds.Tables("GoDownIGL").Rows(0).IsNull("RemainingQty") Then
                txtCurrentProdAmount.Text = 0
            Else
                txtCurrentProdAmount.Text = ds.Tables("GoDownIGL").Rows(0).Item("RemainingQty")

            End If
            'incase it is in piece or Dana then the following portion will run.
            'MsgBox(DG.CurrentRow.Cells(0).Value)
            Dim CP As String = DG.CurrentRow.Cells("DGCrtnPcs").Value
            Dim CPID As Integer
            Try

                For Each dtr As DataRow In Module1.ds.Tables("CartonPiece").Rows
                    If dtr(1) = CP Then
                        CPID = dtr(0)
                    End If
                Next

            Catch ex As Exception
                If CPID = 0 Then
                    CPID = CP
                End If
            End Try
            'All what I did are all because we needed,infact sometimes it gets the value of the grid cell as 1 0r 2 and sometimes it Dari Name.
            If CPID = 0 Then
                CPID = CP
            End If
            If CPID = 1 Then
                GetTotalQtyInPiece()

                txtCurrentProdAmount.Text = QtyOfEachProductInPiece

                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub GetTotalQtyInPiece()

        Module1.DatasetFill("Select PcsInCtrn from VuProductForIGL where ProdCode = " & DG.CurrentRow.Cells("DGProductCode").Value, "VuProductForIGL")
        QtyOfEachProductInPiece = Val(ds.Tables("VuProductForIGL").Rows(0).Item("PcsInCtrn"))

        'Gets the carton portion
        Module1.DatasetFill("Select Sum(RecQty)-Sum(IssueQty) as RemainingQty from GoDownIGL where GodownID=" & cmbGodownName.SelectedValue & " And ProductType=" & CurrentRowsPType & " And ProductCode=" & CurrentRowsProdCode & " And CrtnPcs =2", "GoDownIGL")
        QtyOfEachProductInCarton = ds.Tables("GoDownIGL").Rows(0).Item("RemainingQty")

        'Gets the piece portion
        Module1.DatasetFill("Select Sum(RecQty)-Sum(IssueQty) as RemainingQty from GoDownIGL where GodownID=" & cmbGodownName.SelectedValue & " And ProductType=" & CurrentRowsPType & " And ProductCode=" & CurrentRowsProdCode & " And CrtnPcs =1", "GoDownIGL")
        Dim soldInPiece As Integer = 0
        If IsDBNull(ds.Tables("GoDownIGL").Rows(0).Item("RemainingQty")) Then
            soldInPiece = 0
        Else
            soldInPiece = ds.Tables("GoDownIGL").Rows(0).Item("RemainingQty")
        End If
        'Dim soldInPiece As Integer = If(IsDBNull(ds.Tables("GoDownIGL").Rows(0).Item("RemainingQty"),0)
        If soldInPiece < 0 Then

            soldInPiece = -1 * (soldInPiece)
        End If
        QtyOfEachProductInPiece = (QtyOfEachProductInPiece * QtyOfEachProductInCarton) - soldInPiece
    End Sub
    Private Sub DG_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellEnter
        If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGQty" Then
            If cmbGodownName.SelectedValue = Nothing Then
                MsgBox("Please select the Godown first")
                DG.CurrentCell.ReadOnly = True
                Exit Sub
            Else
                DG.CurrentCell.ReadOnly = False


            End If
        End If
    End Sub

    Private Sub DG_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellEndEdit
        'If Val(Me.DG.CurrentRow.Cells("DGQty").Value) > Val(txtCurrentProdAmount.Text) Then
        '    Me.DG.CurrentRow.Cells("DGQty").Value = 0
        'End If
    End Sub

    Private Sub txtRemarks_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemarks.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub DG_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellClick
        Try
            CurrentRowsPType = DG.CurrentRow.Cells("DGPType").Value
            CurrentRowsProdCode = DG.CurrentRow.Cells("DGProductCode").Value
            Try
                For Each dtr As DataRow In Module1.ds.Tables("CartonPiece").Rows
                    If dtr(1) = DG.CurrentRow.Cells("DGCrtnPcs").Value Then
                        CurrentRowCrtnPcs = dtr(0)
                    End If
                Next
            Catch ex As Exception
                CurrentRowCrtnPcs = DG.CurrentRow.Cells("DGCrtnPcs").Value
            End Try


        Catch ex As Exception

        End Try

        ShowProductAmount()
    End Sub

  
    Private Sub cmbGodownName_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGodownName.Enter
        ' This is a part of our validation. whenever someone writes a quantity
        ' while a gowdown that didn't have that item was selected. It didn't let us 
        ' write something, but as soon as the user would try to change the godown
        ' Then the entered quantity was entered which was not permitted.
        ' Not it has been controlled.
        Try
            If cmbGodownName.Enabled = True Then
                DG.CurrentRow.Cells("DGQty").Value = 0
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class