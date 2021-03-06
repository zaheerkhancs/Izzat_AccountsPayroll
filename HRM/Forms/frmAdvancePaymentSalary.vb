Imports System.Data.SqlClient
Imports System.IO
Imports LanguageSelector
Public Class frmAdvancePaymentSalary
    Dim z As Integer
    Dim Str As String
    Dim calcBalance As Decimal
    Dim actualBalance As Decimal
    Public AdvancePayment As Decimal
    Private Sub frmAdvancePaymentSalary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Module1.Opencn()

        Module1.DatasetFill("Select EmpID,Name from VuEmp2", "VuEmp2")
        cmbReceiveEmpName.DataSource = ds.Tables("VuEmp2")
        cmbReceiveEmpName.DisplayMember = ("Name")
        cmbReceiveEmpName.ValueMember = ("EmpID")

        cmbReceiveEmpName.Text = frmSalaries.cmbEmpName.Text


        dtFromRecieve.Value = Now
        dtToRecieve.Value = Now
    End Sub
    Sub ClearRecieve()
        dtFromRecieve.Value = Now
        dtToRecieve.Value = Now
        txtEmpName.Text = ""
        txtRemaining.Text = ""
        txtTakenAmount.Text = ""
        txtGivenAmount.Text = ""
        txtRecieveRemarks.Text = ""
        DGRecieveSearch.Rows.Clear()
        lbIDR.Text = "Nothing"
    End Sub
    Sub GridFillRecieve()
        Try
            DGRecieveSearch.Rows.Clear()
            cmd.Connection = cn
            da.SelectCommand = cmd
            cmd.CommandText = Str
            If (ds.Tables.Contains("VuEmpAdvancePaymentGivenSalary")) Then
                ds.Tables("VuEmpAdvancePaymentGivenSalary").Clear()
                DGRecieveSearch.Rows.Clear()
            End If
            da.Fill(ds, "VuEmpAdvancePaymentGivenSalary")

            For z = 0 To ds.Tables("VuEmpAdvancePaymentGivenSalary").Rows.Count - 1
                Try

                    DGRecieveSearch.Rows.Add()
                    DGRecieveSearch.Rows(z).Cells(0).Value = ds.Tables("VuEmpAdvancePaymentGivenSalary").Rows(z).Item("APGID")
                    DGRecieveSearch.Rows(z).Cells(1).Value = ds.Tables("VuEmpAdvancePaymentGivenSalary").Rows(z).Item("dtDate")
                    DGRecieveSearch.Rows(z).Cells(2).Value = ds.Tables("VuEmpAdvancePaymentGivenSalary").Rows(z).Item("Amount")
                    DGRecieveSearch.Rows(z).Cells(3).Value = ds.Tables("VuEmpAdvancePaymentGivenSalary").Rows(z).Item("Remaining")
                    DGRecieveSearch.Rows(z).Cells(4).Value = ds.Tables("VuEmpAdvancePaymentGivenSalary").Rows(z).Item("Remarks")

                Catch ex As Exception
                End Try

            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub Checker()
        If AdvancePayment <> 0 Then
            AdvancePayment = AdvancePayment + Val(txtGivenAmount.Text)
        Else
            AdvancePayment = Val(txtGivenAmount.Text)
        End If
    End Sub
    'Sub SaveAdvancePaymentRecieved()
    '    Try

    '        Dim cmdsave As New SqlCommand

    '        cmdsave.CommandType = CommandType.StoredProcedure
    '        cmdsave.CommandText = "InsertAdvancePaymentRecieved"
    '        cmdsave.Connection = cn
    '        cmdsave.Parameters.Add("@APGID", SqlDbType.Int).Value = Me.lbIDR.Text
    '        cmdsave.Parameters.Add("@EmpID", SqlDbType.Int).Value = Me.cmbReceiveEmpName.SelectedValue
    '        cmdsave.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Me.dtRecieveDate.Value.Date.ToString
    '        cmdsave.Parameters.Add("@Amount", SqlDbType.Int).Value = Me.txtGivenAmount.Text
    '        cmdsave.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = Me.txtRecieveRemarks.Text

    '        cmdsave.ExecuteNonQuery()
    '        cmdsave.Parameters.Clear()
    '        Module1.UpdateRecord("EmpAdvancePaymentGiven", "Remaining=" & txtRemaining.Text & "", "APGID = " & lbIDR.Text & "")
    '        Module1.Opencn()
    '        MsgBox("THE RECORD HAS BEEN SAVED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & "ریکارد شما موفقانه ثبت گردید", MsgBoxStyle.Information)
    '        Call Checker()
    '    Catch ex As Exception
    '    End Try
    'End Sub
    'Private Sub TSRecieveUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSRecieveUndo.Click
    '    Call ClearRecieve()
    'End Sub

    'Private Sub TSRecieveSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSRecieveSave.Click
    '    If txtEmpName.Text = "" Then
    '        MsgBox("PLEASE INSERT AN EMPLOYEE NAME FIRST" & Chr(13) & " " & Chr(13) & "لطفآ اول اسم کارمند را درج کنید", MsgBoxStyle.Critical)
    '        Exit Sub
    '    Else
    '        If txtGivenAmount.Text = "" Then
    '            MsgBox("PLEASE ASSIGN THE VALUE FIRST" & Chr(13) & " " & Chr(13) & "لطفآ اول مقدار را درج نمائید", MsgBoxStyle.Critical)
    '            Exit Sub
    '        Else
    '            Call SaveAdvancePaymentRecieved()
    '            Call ClearRecieve()
    '        End If
    '    End If
    'End Sub
    Private Sub TSRecieveClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSRecieveClose.Click
        Me.Close()
    End Sub
    Private Sub btnRecieveSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecieveSearch.Click
        If cmbReceiveEmpName.Text = "" Then
            MsgBox("PLEASE SELECT AN EMPLOYEE FIRST" & Chr(13) & " " & Chr(13) & "لطفآ اول کارمند را انتخاب کنید", MsgBoxStyle.Critical)
            Exit Sub
        Else
            Str = "Select APGID,dtDate,Amount,Remarks,Remaining from VuEmpAdvancePaymentGivenSalary where Name = N'" & cmbReceiveEmpName.Text & "' And dtDate between '" & dtFromRecieve.Value.Date.ToString & "' And '" & dtToRecieve.Value.Date.ToString & "'and Remaining > 0"
            Call GridFillRecieve()
        End If
    End Sub

    Private Sub DGRecieveSearch_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGRecieveSearch.CellDoubleClick
        Try

            txtEmpName.Text = cmbReceiveEmpName.Text
            lbIDR.Text = DGRecieveSearch.CurrentRow.Cells(0).Value
            txtTakenAmount.Text = DGRecieveSearch.CurrentRow.Cells(2).Value
            txtRemaining.Text = DGRecieveSearch.CurrentRow.Cells(3).Value
            'txtGivenAmount.Text = DGRecieveSearch.CurrentRow.Cells(3).Value

            actualBalance = txtRemaining.Text
            calcBalance = txtRemaining.Text

            dtFromRecieve.Value = Now
            dtToRecieve.Value = Now
            DGRecieveSearch.Rows.Clear()

        Catch ex As Exception
        End Try
    End Sub
    Sub calc()
        Dim abc As Decimal
        abc = calcBalance - Val(txtGivenAmount.Text)
        txtRemaining.Text = abc
    End Sub
    Private Sub txtGivenAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGivenAmount.TextChanged
        If txtGivenAmount.Text = "" Then
            txtRemaining.Text = actualBalance
        Else
            Call calc()
        End If

        If txtRemaining.Text < 0 Then
            MsgBox("INVALID AMOUNT" & Chr(13) & " " & Chr(13) & "مقدار درج شده صحیح نیست", MsgBoxStyle.Information)
            txtRemaining.Text = actualBalance
            txtGivenAmount.Text = ""
        End If
    End Sub

    Private Sub cmbReceiveEmpName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbReceiveEmpName.SelectedIndexChanged
        Call ClearRecieve()
    End Sub
    
    Private Sub frmAdvancePaymentSalary_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'frmSalaries.txtAdvancePayment.Text = AdvancePayment
        frmSalaries.chbAdvancePayment.Checked = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If txtEmpName.Text = "" Then
            MsgBox("PLEASE INSERT AN EMPLOYEE NAME FIRST" & Chr(13) & " " & Chr(13) & "لطفآ اول اسم کارمند را درج کنید", MsgBoxStyle.Critical)
            Exit Sub
        Else
            If txtGivenAmount.Text = "" Then
                MsgBox("PLEASE ASSIGN THE VALUE FIRST" & Chr(13) & " " & Chr(13) & "لطفآ اول مقدار را درج نمائید", MsgBoxStyle.Critical)
                Exit Sub
            Else
                'frmSalaries.lbIDAdvancePayment.Text = lbIDR.Text
                frmSalaries.AdvancePaymentID = lbIDR.Text
                'frmSalaries.lbRemarksAdvancePayment.Text = txtRecieveRemarks.Text
                frmSalaries.AdvancePaymentRemark = txtRecieveRemarks.Text
                'frmSalaries.lbRemaining.Text = txtRemaining.Text
                frmSalaries.AdvancePaymentRemaining = txtRemaining.Text
                Call Checker()
                frmSalaries.txtAdvancePayment.Text = AdvancePayment
                Me.Close()
            End If
        End If
    End Sub

    Private Sub txtGivenAmount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGivenAmount.KeyPress
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

    Private Sub txtRecieveRemarks_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRecieveRemarks.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
        If txtRecieveRemarks.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub cmbReceiveEmpName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbReceiveEmpName.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub
End Class