Imports System.Data.SqlClient
Imports LanguageSelector
Public Class Saraaf
    Dim EditCurrencyType As Boolean
    Dim EditValue As Integer
    Dim Var_RecordID As Integer
    Dim Var_NewCurrencyID As Integer
    Dim CityID As Integer
    Dim CItyBasedID As String
    Dim cnt As Integer
    Dim NewRecordIsSaved As Boolean
    Dim AddEdit As Boolean
    Dim JustSaved As Boolean ' It is a variable used only for allowing calculation of Balance only after Saving a recoding New, or Edited.
    Dim ParsedValueForAmount As Double

    Private Sub Saraaf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Module1.Opencn()
        CityID = Frm.lbLocationID.Text
        CItyBasedID = Frm.lbLocationName.Text
        Module1.DatasetFill("Select * from MoneyExchanger", "MoneyExchanger")
        cmbMoneyExchanger.DataSource = ds.Tables("MoneyExchanger")
        cmbMoneyExchanger.DisplayMember = "MoneyExchangerName"
        cmbMoneyExchanger.ValueMember = "MoneyExchangerID"

        Module1.DatasetFill("Select * from MoneyExchanger", "MoneyExchanger")
        cmbMoneyExchangerSearch.DataSource = ds.Tables("MoneyExchanger")
        cmbMoneyExchangerSearch.DisplayMember = "MoneyExchangerName"
        cmbMoneyExchangerSearch.ValueMember = "MoneyExchangerID"
        RBPayment.Checked = True

        Module1.DatasetFill("Select * from SaraafCurrencyTable", "SaraafCurrencyTable")

        cmbCurrencyType.DataSource = ds.Tables("SaraafCurrencyTable")
        cmbCurrencyType.DisplayMember = "CurrencyName"
        cmbCurrencyType.ValueMember = "CurrencyID"

        Call txtfill()
        BalanceCalculator()

    End Sub
    Sub txtfill()
        Try
            EditValue = 0
            lblMessage.Text = ""
            If cnt < 0 Then
                cnt = 0
            End If
            Module1.DatasetFill("Select * from SaraafAccount", "SaraafAccount")

            If ds.Tables("SaraafAccount").Rows.Count = 0 Then Exit Sub
            If NewRecordIsSaved.Equals(True) Then
                cnt = ds.Tables("SaraafAccount").Rows.Count - 1
            End If

            Var_RecordID = ds.Tables("SaraafAccount").Rows(cnt).Item("RecordID")
            cmbMoneyExchanger.SelectedValue = ds.Tables("SaraafAccount").Rows(cnt).Item("MoneyExchangerID")
            txtConcernName.Text = ds.Tables("SaraafAccount").Rows(cnt).Item("ConcernPerson")
            ' txtBalance.Text = ds.Tables("SaraafAccount").Rows(cnt).Item("Balance")
            Dim Pay_Receive As Integer = ds.Tables("SaraafAccount").Rows(cnt).Item("Pay_Receive")
            If Pay_Receive = 1 Then
                RBPayment.Checked = True
                txtAmount.Text = ds.Tables("SaraafAccount").Rows(cnt).Item("AmountWithSaraaf")
            Else
                RBReceive.Checked = True
                txtAmount.Text = ds.Tables("SaraafAccount").Rows(cnt).Item("AmountWithdraw")
            End If


            txtRemarks.Text = ds.Tables("SaraafAccount").Rows(cnt).Item("Remarks")
            cmbCurrencyType.SelectedValue = ds.Tables("SaraafAccount").Rows(cnt).Item("CurrencyID")
            txtFXchangeRate.Text = ds.Tables("SaraafAccount").Rows(cnt).Item("CurrencyValue")
            txtAmountInFX.Text = ds.Tables("SaraafAccount").Rows(cnt).Item("AmountFEx")
            dtDate.Value = ds.Tables("SaraafAccount").Rows(cnt).Item("dtDate")
            If JustSaved.Equals(True) Then
                BalanceCalculator()
                JustSaved = False
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbMoneyExchanger_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMoneyExchanger.SelectedIndexChanged
        Try

    
            If AddEdit.Equals(True) Then
                If btnAddNewFX.Text = "ثبت" Then
                    MsgBox(" PLEASE SAVE THE NEWLY ADDED MONEY " & Chr(13) & "  " & Chr(13) & " لطفآ پولی جدید را که علاوه کرده اید اول ثبت نمایید ", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                Try
                    Module1.DatasetFill("Select ConcernPName from VuMoneyExchanger where MoneyExchangerID =" & cmbMoneyExchanger.SelectedValue, "VuMoneyExchanger")
                    txtConcernName.Text = ds.Tables("VuMoneyExchanger").Rows(0).Item("ConcernPName")



                Catch ex As Exception

                End Try
            End If
            BalanceCalculator()
        Catch ex As Exception

        End Try
    End Sub
    Sub BalanceCalculator()
        Try
            Module1.DatasetFill("Select Sum(AmountWithSaraaf)-Sum(AmountWithdraw) as CurrentBalance from VuSaraafAccount where MoneyExchangerID =" & cmbMoneyExchanger.SelectedValue, "VuSaraafAccount")
            If IsDBNull(ds.Tables("VuSaraafAccount").Rows(0).Item("CurrentBalance")) Then
                txtBalance.Text = 0
            Else
                txtBalance.Text = ds.Tables("VuSaraafAccount").Rows(0).Item("CurrentBalance")
            End If

        Catch ex As Exception

        End Try
    End Sub
#Region "ContextMenuButtons"


    Private Sub MnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuNew.Click
        AddEdit = True
        ToolStrip1.Enabled = False
        Call txtclear()
        Call CStutus()
        EditValue = 1
        cmbMoneyExchanger.Focus()
        CMStatus()
        GBFEx.Enabled = True
        Try
            cmbMoneyExchanger_SelectedIndexChanged(cmbMoneyExchanger, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSave.Click
        If cmbMoneyExchanger.Text = "" Or txtAmount.Text = "" Then
            MsgBox(" PLEASE FILL THE REQUIRED FIELDS " & Chr(13) & "  " & Chr(13) & " لطفآ خانه های مذکور را خالی نگذارید ", MsgBoxStyle.Critical)
            Exit Sub
        Else
            If Not cmbCurrencyType.DropDownStyle = ComboBoxStyle.DropDownList Then
                MsgBox(" PLEASE FILL THE REQUIRED FIELDS " & Chr(13) & "  " & Chr(13) & " لطفآ نخست نوع پول جردید را ثبت و یا فسخ نمایید ", MsgBoxStyle.Critical)
                Exit Sub
            End If
            If EditValue = 1 Then
                IDPicker("SaraafAccount", "RecordID")

            End If

            Dim cmdsave As New SqlCommand
            cmdsave.CommandType = CommandType.StoredProcedure
            cmdsave.CommandText = "InsertUpdateSaraafAccount"
            cmdsave.Connection = cn
            cmdsave.Parameters.Add("@RecordID", SqlDbType.Int).Value = Me.Var_RecordID
            cmdsave.Parameters.Add("@MoneyExchangerID", SqlDbType.Int).Value = Me.cmbMoneyExchanger.SelectedValue
            cmdsave.Parameters.Add("@ConcernPerson", SqlDbType.NVarChar).Value = Me.txtConcernName.Text
            cmdsave.Parameters.Add("@Balance", SqlDbType.Decimal).Value = Me.txtBalance.Text
            If RBPayment.Checked.Equals(True) Then
                cmdsave.Parameters.Add("@Pay_Receive", SqlDbType.Int).Value = 1
                cmdsave.Parameters.Add("@AmountWithSaraaf", SqlDbType.Decimal).Value = txtAmount.Text
                cmdsave.Parameters.Add("@AmountWithdraw", SqlDbType.Decimal).Value = 0
            ElseIf RBReceive.Checked.Equals(True) Then
                cmdsave.Parameters.Add("@Pay_Receive", SqlDbType.Int).Value = 0
                cmdsave.Parameters.Add("@AmountWithdraw", SqlDbType.Decimal).Value = txtAmount.Text
                cmdsave.Parameters.Add("@AmountWithSaraaf", SqlDbType.Decimal).Value = 0

            End If

            cmdsave.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = dtDate.Value.Date
            cmdsave.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = txtRemarks.Text.Trim()
            cmdsave.Parameters.Add("@CurrencyID", SqlDbType.Int).Value = cmbCurrencyType.SelectedValue
            cmdsave.Parameters.Add("@CurrencyValue", SqlDbType.NVarChar).Value = txtFXchangeRate.Text
            cmdsave.Parameters.Add("@AmountFEx", SqlDbType.NVarChar).Value = txtAmountInFX.Text

            cmdsave.Parameters.Add("@CityID", SqlDbType.Decimal).Value = CityID
            cmdsave.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CItyBasedID & "-" & Var_RecordID

            cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = EditValue
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmdsave.ExecuteNonQuery()

            cmdsave.Parameters.Clear()
            JustSaved = True
            Call CStutus()
            If EditValue = 1 Then
                lblMessage.Text = "ریکارد شما موفقانه ثبت گردید"
                NewRecordIsSaved = True
                ' MsgBox("Your Record has been saved successfully..")
            Else
                lblMessage.Text = "ریکارد شما موفقانه تجدید گردید"
                NewRecordIsSaved = False
                'MsgBox("Your Record has been updated successfully..")
            End If

            CMStatus()

            txtfill()
        End If

        ToolStrip1.Enabled = True
        AddEdit = False
        GBFEx.Enabled = False
    End Sub

    Private Sub MnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuEdit.Click
        AddEdit = True
        ToolStrip1.Enabled = False
        Call CStutus()
        EditValue = 0
        CMStatus()
        BalanceCalculator()
    End Sub


    Private Sub MnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDelete.Click
        If Not Me.Var_RecordID = "0" Then

            If MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then

                Module1.DeleteRecord("SaraafAccount", "RecordID = " & Me.Var_RecordID)
                cnt = ds.Tables("SaraafAccount").Rows.Count - 1
                If cnt = 0 Then
                    txtclear()

                    Exit Sub
                End If

                'cnt = cnt - 1
                NewRecordIsSaved = False
                Call TxtFillAfterDeletion()



            End If
        End If
        Module1.Opencn()

    End Sub


    Private Sub TxtFillAfterDeletion()

        If cnt <> Module1.ds.Tables("SaraafAccount").Rows.Count Then
            ' MsgBox(Module1.ds.Tables("SaraafAccount").Rows.Count)

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

        Call CStutus()
        txtclear()
        CMStatus()
        NewRecordIsSaved = False
        Call txtfill()

        AddEdit = False
        ToolStrip1.Enabled = True
        BalanceCalculator()
        GBFEx.Enabled = False
    End Sub

    Private Sub MnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuExit.Click
        Me.Close()
    End Sub
#End Region
#Region "Sub Functions txtclear,txtfill,OpenGrid,CMStatus,CMStatusDefault,CStatusDefault"

    Sub CStutus()
        dtDate.Enabled = Not dtDate.Enabled
        cmbMoneyExchanger.Enabled = Not cmbMoneyExchanger.Enabled
        RBPayment.Enabled = Not RBPayment.Enabled
        RBReceive.Enabled = Not RBReceive.Enabled
        txtAmount.Enabled = Not txtAmount.Enabled
        txtRemarks.Enabled = Not txtRemarks.Enabled
    End Sub
    Sub txtclear()

        txtConcernName.Text = ""
        txtBalance.Text = ""
        RBPayment.Checked = True
        txtAmount.Text = ""
        txtRemarks.Text = ""

        txtFXchangeRate.Text = ""
        txtAmountInFX.Text = ""

    End Sub


    Sub CMStatus()
        MnuNew.Enabled = Not MnuNew.Enabled
        MnuEdit.Enabled = Not MnuEdit.Enabled
        MnuSave.Enabled = Not MnuSave.Enabled
        MnuDelete.Enabled = Not MnuDelete.Enabled
        MnuUndo.Enabled = Not MnuUndo.Enabled

    End Sub

#End Region

    Sub IDPicker(ByVal TableName As String, ByVal FieldID As String)
        Try

            Dim sqldreader As SqlDataReader
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select Max(" & FieldID & ") from " & TableName
            cmd.Connection = cn
            If cn.State = ConnectionState.Closed Then cn.Open()
            sqldreader = cmd.ExecuteReader()
            While sqldreader.Read

                If IsDBNull(sqldreader.Item(0)) = True Then
                    If TableName.Equals("SaraafAccount") Then
                        Me.Var_RecordID = 1
                    Else
                        Me.Var_NewCurrencyID = 1
                    End If
                Else
                    If TableName.Equals("SaraafAccount") Then
                        Me.Var_RecordID = Val(sqldreader.Item(0)) + 1
                    Else
                        Me.Var_NewCurrencyID = Val(sqldreader.Item(0)) + 1
                    End If



                End If
            End While
            sqldreader.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TC.SelectedIndexChanged
        If TC.SelectedTab.Name = "TP1" Then
            CM.Enabled = True
        Else
            CM.Enabled = False
        End If
    End Sub

    Private Sub DGSearch_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGSearch.CellValueChanged



    End Sub
    Sub CalculateAmounts()
        Dim TotalWithSaraaf As Decimal = 0
        Dim TotalWithdraw As Decimal = 0
        For Each dgrow As DataGridViewRow In DGSearch.Rows

            TotalWithSaraaf = TotalWithSaraaf + dgrow.Cells("DGSearchGivenToSaraaf").Value
            TotalWithdraw = TotalWithdraw + dgrow.Cells("DGSearchWithdrawFromSaraaf").Value
        Next
        txtSearchTotalPaid.Text = TotalWithSaraaf
        txtSearchTotalWithdraw.Text = TotalWithdraw
        txtSearchTotalBalance.Text = TotalWithSaraaf - TotalWithdraw
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim i As Integer = 0
        DGSearch.Rows.Clear()
        If cmbMoneyExchangerSearch.Enabled = True Then

            Module1.DatasetFill("Select * from VuSaraafAccountSearch where dtDate between '" & dtFrom.Value.Date & "' And '" & dtTo.Value.Date & "' And MoneyExchangerID =" & cmbMoneyExchangerSearch.SelectedValue, "VuSaraafAccountSearch")
            For Each datarow As DataRow In ds.Tables("VuSaraafAccountSearch").Rows
                DGSearch.Rows.Add()
                DGSearch.Rows(i).Cells("DGSearchName").Value = datarow("MoneyExchangerName")
                DGSearch.Rows(i).Cells("DGSearchCPName").Value = datarow("ConcernPerson")
                DGSearch.Rows(i).Cells("DGSearchDesciption").Value = datarow("Remarks")
                DGSearch.Rows(i).Cells("DGSearchCurrType").Value = datarow("CurrencyName")
                DGSearch.Rows(i).Cells("DGSearchAmountInFEx").Value = datarow("AmountFEx")
                DGSearch.Rows(i).Cells("DGSearchTabadula").Value = datarow("CurrencyValue")

                DGSearch.Rows(i).Cells("DGSearchGivenToSaraaf").Value = datarow("AmountWithSaraaf")
                DGSearch.Rows(i).Cells("DGSearchWithdrawFromSaraaf").Value = datarow("AmountWithdraw")

                Dim datee As String = datarow(4)
                Dim dateee() As String = datee.Split("/")
                datee = dateee(1) & "/" & dateee(0) & "/" & dateee(2)
                DGSearch.Rows(i).Cells("DGSearchDate").Value = datee




                i = i + 1
            Next

        Else
            Module1.DatasetFill("Select * from VuSaraafAccountSearch where dtDate between '" & dtFrom.Value.Date & "' And '" & dtTo.Value.Date & "'", "VuSaraafAccountSearch")
            For Each datarow As DataRow In ds.Tables("VuSaraafAccountSearch").Rows
                DGSearch.Rows.Add()
                DGSearch.Rows(i).Cells("DGSearchName").Value = datarow("MoneyExchangerName")
                DGSearch.Rows(i).Cells("DGSearchCPName").Value = datarow("ConcernPerson")
                DGSearch.Rows(i).Cells("DGSearchDesciption").Value = datarow("Remarks")
                DGSearch.Rows(i).Cells("DGSearchCurrType").Value = datarow("CurrencyName")
                DGSearch.Rows(i).Cells("DGSearchAmountInFEx").Value = datarow("AmountFEx")
                DGSearch.Rows(i).Cells("DGSearchTabadula").Value = datarow("CurrencyValue")

                DGSearch.Rows(i).Cells("DGSearchGivenToSaraaf").Value = datarow("AmountWithSaraaf")
                DGSearch.Rows(i).Cells("DGSearchWithdrawFromSaraaf").Value = datarow("AmountWithdraw")

                Dim datee As String = datarow(4)
                Dim dateee() As String = datee.Split("/")
                datee = dateee(1) & "/" & dateee(0) & "/" & dateee(2)
                DGSearch.Rows(i).Cells("DGSearchDate").Value = datee
                i = i + 1
            Next
        End If
        CalculateAmounts()
        ' The bottom portion is for print.
        If chkbxSaraafname.Checked.Equals(True) Then
            Module1.DatasetFill("Select * from RptVuSarafAccount where MoneyExchangerID=" & cmbMoneyExchangerSearch.SelectedValue & " And dtDate between'" & dtFrom.Value.Date & "' And '" & dtTo.Value.Date & "'", "RptVuSarafAccount")
        Else
            Module1.DatasetFill("Select * from RptVuSarafAccount where dtDate between '" & dtFrom.Value.Date & "' And '" & dtTo.Value.Date & "'", "RptVuSarafAccount")
        End If
    End Sub

    Private Sub chkbxSaraafname_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbxSaraafname.CheckedChanged
        If chkbxSaraafname.Checked.Equals(True) Then
            cmbMoneyExchangerSearch.Enabled = True
        Else
            cmbMoneyExchangerSearch.Enabled = False
        End If
    End Sub

    Private Sub DGSearch_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DGSearch.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub



    Private Sub TSFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSFirst.Click
        cnt = 0
        NewRecordIsSaved = False
        Call txtfill()

    End Sub

    Private Sub TSPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSPrevious.Click

        NewRecordIsSaved = False
        If cnt = 0 Then
            Call txtfill()
        Else
            cnt = cnt - 1
            Call txtfill()
        End If

    End Sub
    Private Sub TSNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSNext.Click
        NewRecordIsSaved = False
        If cnt = ds.Tables("SaraafAccount").Rows.Count - 1 Then Exit Sub
        cnt = cnt + 1
        Call txtfill()

    End Sub
    Private Sub TSLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSLast.Click
        NewRecordIsSaved = False
        cnt = ds.Tables("SaraafAccount").Rows.Count - 1
        Call txtfill()
    End Sub


    Private Sub txtAmount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress

        NumericKeys(txtAmount, e)

    End Sub

    Private Sub NumericKeys(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If IsNumeric(Me.ActiveControl.Text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Then e.Handled = True

    End Sub

    Private Sub txtAmountInFX_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmountInFX.TextChanged
        CalculateAmountInKaldar()
    End Sub

    Sub CalculateAmountInKaldar()
        txtAmount.Text = Val(txtFXchangeRate.Text) * Val(txtAmountInFX.Text)
    End Sub

    Private Sub txtFXchangeRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFXchangeRate.TextChanged
        CalculateAmountInKaldar()
    End Sub

    Private Sub btnCancelFX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelFX.Click
        Try

            Module1.DatasetFill("Select * from SaraafCurrencyTable", "SaraafCurrencyTable")
            cmbCurrencyType.DataSource = ds.Tables("SaraafCurrencyTable")
            cmbCurrencyType.DisplayMember = ("CurrencyName")
            cmbCurrencyType.ValueMember = ("CurrencyID")
            cmbCurrencyType.SelectedIndex = 0
            cmbCurrencyType.DropDownStyle = ComboBoxStyle.DropDownList
            EditCurrencyType = False
            btnAddNewFX.Text = "جدید"
            btnCancelFX.Visible = False
            CM.Enabled = True
            ToolStrip1.Enabled = True

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnAddNewFX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNewFX.Click
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim abc As String
        Dim a As Integer
        Dim aziz As Integer
        Try
            If EditCurrencyType = True Then
                If cmbCurrencyType.Text = "" Then
                    MsgBox(" PLEASE FILL THE REQUIRED FIELD " & Chr(13) & "  " & Chr(13) & " لطفآ خانه مذکور را خالی نگذارید ", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    Try
                        'searching for existing record.
                        For a = 0 To ds.Tables("SaraafCurrencyTable").Rows.Count
                            abc = ds.Tables("SaraafCurrencyTable").Rows(a).Item(1)
                            If cmbCurrencyType.Text = abc Then
                                MsgBox("THE RECORD ALREADY EXIST" & Chr(13) & "  " & Chr(13) & "ریکارد ذکر شده قبلآ موجود است", MsgBoxStyle.Critical)
                                cmbCurrencyType.Text = ""
                                Exit Sub
                            End If
                        Next

                    Catch ex As Exception
                    End Try
                    SaveSaraafCurrency()
                Module1.DatasetFill("Select * from SaraafCurrencyTable", "SaraafCurrencyTable")
                 
                    cmbCurrencyType.DataSource = ds.Tables("SaraafCurrencyTable")
                    cmbCurrencyType.DisplayMember = ("CurrencyName")
                    cmbCurrencyType.ValueMember = ("CurrencyID")
                    aziz = cmbCurrencyType.Items.Count
                    cmbCurrencyType.SelectedIndex = aziz - 1
                    cmbCurrencyType.DropDownStyle = ComboBoxStyle.DropDownList
                    EditCurrencyType = False
                    btnAddNewFX.Text = "جدید"
                    btnCancelFX.Visible = False
                    CM.Enabled = True
                    ToolStrip1.Enabled = True
               
                    cmbCurrencyType.Focus()
                End If
            Else
                cmbCurrencyType.DataSource = Nothing
                cmbCurrencyType.Items.Clear()
                cmbCurrencyType.DropDownStyle = ComboBoxStyle.DropDown
                EditCurrencyType = True
                btnAddNewFX.Text = "ثبت"
                btnAddNewFX.Visible = True
                btnCancelFX.Visible = True
                CM.Enabled = False
                ToolStrip1.Enabled = False
             
                IDPicker("SaraafCurrencyTable", "CurrencyID")

            End If

        Catch ex As Exception
        End Try
    End Sub
    Sub SaveSaraafCurrency()
        Try

            Dim cmdsave As New SqlCommand
            cmdsave.CommandType = CommandType.StoredProcedure
            cmdsave.CommandText = "InsertCurrency"
            cmdsave.Connection = cn
            cmdsave.Parameters.Add("@CurrencyID", SqlDbType.Int).Value = Me.Var_NewCurrencyID
            cmdsave.Parameters.Add("@CurrencyName", SqlDbType.NVarChar).Value = Me.cmbCurrencyType.Text.Trim()
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmdsave.ExecuteNonQuery()
            cmdsave.Parameters.Clear()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LLCurrencyTypeList_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LLCurrencyTypeList.LinkClicked
        Me.OpenGrid("SaraafCurrencyTable", "CurrencyID")
    End Sub
    Sub OpenGrid(ByVal OpenGridTableName As String, ByVal OpenGridOrderBY As String)

        SetupListForAllHRM.GridFill("Select * from " & OpenGridTableName & " Order by " & OpenGridOrderBY, OpenGridTableName)
        SetupListForAllHRM.Obj = Me
        SetupListForAllHRM.Show()

        SetupListForAll.MdiParent = Frm
        SetupListForAllHRM.TopMost = True



    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            If cmbMoneyExchangerSearch.Items.Count = 0 Or DGSearch.RowCount = 0 Then
                Exit Sub
            Else
                ' Query will be filled from jostojo button.
                Dim rpt As New RptSaraaf
                rpt.SetDataSource(Module1.ds.Tables("RptVuSarafAccount"))
                frmRptSetup.CV.ReportSource = rpt
                Frm.RptShow()
                'Me.Close()

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCurrencyType_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCurrencyType.KeyPress
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

    Private Sub txtFXchangeRate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFXchangeRate.KeyPress
        NumericKeys(txtFXchangeRate, e)
    End Sub

    Private Sub txtAmountInFX_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmountInFX.KeyPress
        NumericKeys(txtAmountInFX, e)
    End Sub
End Class