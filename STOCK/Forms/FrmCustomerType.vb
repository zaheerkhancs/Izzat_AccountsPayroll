Imports System.Data.SqlClient
Imports LanguageSelector
Public Class FrmCustomerType
    Dim a As Integer
    Dim EditValue As Integer
    Dim cnt As Integer
    Private Sub FrmCustomerType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Module1.Opencn()
        Me.Top = Frm.Height / 4
        Me.Left = Frm.Width / 4
        'Me.Width = Screen.PrimaryScreen.Bounds.Width
        'Me.Height = Screen.PrimaryScreen.Bounds.Height
        'Me.CenterToScreen()
        ''Me.Panel6.Top = Me.Height / 2 - (Me.Panel6.Height / 2)
        'Me.Panel6.Left = Me.Width / 2 - (Me.Panel6.Width / 2)

        Module1.DatasetFill("Select * from CustomerType", "CustomerType")
        Call txtfill()

        If Frm.GID.Text > 2 Then
            Module1.CMStatusDisable(CM)
        End If
    End Sub
#Region "Sub Functions txtclear,txtfill,OpenGrid,CMStatus,CMStatusDefault,CStatusDefault"
    Public Sub CStatusDefault()
        TxtID.Enabled = False
        txtName.Enabled = False

    End Sub
    Public Sub CMStatusDefault()
        MnuNew.Enabled = True
        MnuEdit.Enabled = True
        MnuSave.Enabled = False
        MnuDelete.Enabled = True
        MnuUndo.Enabled = False


    End Sub
    Sub CStutus()
        TxtID.Enabled = Not TxtID.Enabled
        txtName.Enabled = Not txtName.Enabled
    End Sub
    Sub txtclear()
        'Dim C As Control
        'For Each C In Me.Controls
        '    If TypeOf C Is ComboBox Or TypeOf C Is TextBox Then
        '        C.Text = ""
        '    End If
        'Next


        Me.TxtID.Text = ""
        Me.txtName.Text = ""

    End Sub
    Sub txtfill()
        Try
            Module1.DatasetFill("Select * from CustomerType Order by CustomerTypeID", "CustomerType")

            If ds.Tables("CustomerType").Rows.Count = 0 Then Exit Sub


            Me.TxtID.Text = ds.Tables("CustomerType").Rows(cnt).Item("CustomerTypeID")
            Me.txtName.Text = ds.Tables("CustomerType").Rows(cnt).Item("CustomerTypeName")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CMStatus()
        MnuNew.Enabled = Not MnuNew.Enabled
        MnuEdit.Enabled = Not MnuEdit.Enabled
        MnuSave.Enabled = Not MnuSave.Enabled
        MnuDelete.Enabled = Not MnuDelete.Enabled
        MnuUndo.Enabled = Not MnuUndo.Enabled

    End Sub
    Sub OpenGrid()
        Try

            SetupListForAll.GridFill("Select * from CustomerType Order by CustomerTypeID", "CustomerType")
            SetupListForAll.Obj = Me
            SetupListForAll.Show()

            SetupListForAll.MdiParent = Frm

        Catch ex As Exception

        End Try
    End Sub
#End Region


#Region "ContextMenuButtons"


    Private Sub MnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuNew.Click
        Me.RightToLeft = Windows.Forms.RightToLeft.Yes
        Try

            Dim sqldreader As SqlDataReader

            Call txtclear()
            Call CStutus()
            EditValue = 1
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select Max(CustomerTypeID) from CustomerType"
            cmd.Connection = cn

            sqldreader = cmd.ExecuteReader()
            While sqldreader.Read

                If IsDBNull(sqldreader.Item(0)) = True Then
                    Me.TxtID.Text = 1
                Else
                    Me.TxtID.Text = Val(sqldreader.Item(0)) + 1

                End If
            End While
            sqldreader.Close()
            txtName.Focus()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        CMStatus()
    End Sub

    Private Sub MnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSave.Click
        If txtName.Text.Trim = "" Then Exit Sub
        Call CStutus()
        Dim cmdsave As New SqlCommand
        cmdsave.CommandType = CommandType.StoredProcedure
        cmdsave.CommandText = "InsertUpdateCustomerType"
        cmdsave.Connection = cn
        cmdsave.Parameters.Add("@CustomerTypeID", SqlDbType.Int).Value = Me.txtID.Text
        cmdsave.Parameters.Add("@CustomerTypeName", SqlDbType.VarChar).Value = Me.txtName.Text
        cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = EditValue
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmdsave.ExecuteNonQuery()

        cmdsave.Parameters.Clear()
        If EditValue = 1 Then
            lblMessage.Text = "ریکارد شما موفقانه ثبت گردید"
            ' MsgBox("Your Record has been saved successfully..")
        Else

            lblMessage.Text = "ریکارد شما موفقانه تجدید گردید"

            'MsgBox("Your Record has been updated successfully..")

        End If

        SetupListForAll.GridFill("Select * from CustomerType Order by CustomerTypeID", "CustomerType")

        CMStatus()

        OpenGrid()


    End Sub

    Private Sub MnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuEdit.Click
        If Me.txtID.Text = 1 Or txtID.Text = 2 Or txtID.Text = 3 Then Exit Sub
        Call CStutus()
        EditValue = 0
        CMStatus()
    End Sub


    Private Sub MnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDelete.Click
        If Me.txtID.Text = 1 Or txtID.Text = 2 Or txtID.Text = 3 Then Exit Sub
        If Not Me.txtID.Text = "" Then

            If MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then

                Module1.DeleteRecord("CustomerType", "CustomerTypeID = " & txtID.Text)

                SetupListForAll.GridFill("Select * from CustomerType order by CustomerTypeID", "CustomerType")
                cnt = ds.Tables("CustomerType").Rows.Count
                If cnt = 0 Then
                    txtID.Text = ""
                    txtName.Text = ""
                    Exit Sub
                End If

                'cnt = cnt - 1
                Call TxtFillAfterDeletion()
                OpenGrid()


            End If
        End If

    End Sub
    Private Sub TxtFillAfterDeletion()

        If cnt <> Module1.ds.Tables("CustomerType").Rows.Count Then
            ' MsgBox(Module1.ds.Tables("CustomerType").Rows.Count)

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
        Call txtfill()
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
        CStatusDefault()
    End Sub
    Private Sub TSPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSPrevious.Click
        If cnt = 0 Then Exit Sub
        cnt = cnt - 1
        Call txtfill()
        CMStatusDefault()
        CStatusDefault()
    End Sub

    Private Sub TSNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSNext.Click
        If cnt = ds.Tables("CustomerType").Rows.Count - 1 Then Exit Sub
        cnt = cnt + 1
        Call txtfill()
        CMStatusDefault()
        CStatusDefault()
    End Sub



    Private Sub TSLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSLast.Click
        cnt = ds.Tables("CustomerType").Rows.Count - 1
        Call txtfill()
        CMStatusDefault()
        CStatusDefault()
    End Sub
#End Region

    Private Sub LLCustomerTypesList_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LLCustomerTypesList.LinkClicked
        For Each fr As Form In Frm.MdiChildren
            If fr.Name = "SetupListForAll" Then
                fr.WindowState = FormWindowState.Normal
                fr.BringToFront()
            Else
                OpenGrid()
            End If
        Next
    End Sub

    Private Sub txtName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
        If e.KeyChar = Chr(13) Then
            MnuSave_Click(MnuSave, e)
        End If
    End Sub

    Private Sub FrmCustomerType_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        SetupListForAll.Close()
    End Sub

    Private Sub FrmCustomerType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        Me.TopMost = True
        Me.BringToFront()
    End Sub
End Class