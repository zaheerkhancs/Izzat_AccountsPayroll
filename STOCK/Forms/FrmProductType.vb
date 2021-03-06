Imports System.Data.SqlClient
Imports LanguageSelector
Public Class FrmProductType
    Dim a As Integer
    Dim EditValue As Integer
    Dim cnt As Integer
    Private Sub FrmProductType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Module1.Opencn()
        Me.Top = Frm.Height / 4
        Me.Left = Frm.Width / 4
        'Me.Width = Screen.PrimaryScreen.Bounds.Width
        'Me.Height = Screen.PrimaryScreen.Bounds.Height
        'Me.CenterToScreen()
        ''Me.Panel6.Top = Me.Height / 2 - (Me.Panel6.Height / 2)
        'Me.Panel6.Left = Me.Width / 2 - (Me.Panel6.Width / 2)

        Module1.DatasetFill("Select * from ProductType", "ProductType")
        Call txtfill()
        If Frm.GID.Text > 2 Then
            Module1.CMStatusDisable(CM)
        End If
    End Sub

#Region "Sub Functions txtclear,txtfill,OpenGrid,CMStatus,CMStatusDefault,CStatusDefault"
    Public Sub CStatusDefault()
        txtID.Enabled = False
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
        txtID.Enabled = Not txtID.Enabled
        txtName.Enabled = Not txtName.Enabled
        txtNameEnglish.Enabled = Not txtNameEnglish.Enabled
    End Sub
    Sub txtclear()
        'Dim C As Control
        'For Each C In Me.Controls
        '    If TypeOf C Is ComboBox Or TypeOf C Is TextBox Then
        '        C.Text = ""
        '    End If
        'Next


        Me.txtID.Text = ""
        Me.txtName.Text = ""
        Me.txtNameEnglish.Text = ""
    End Sub
    Sub txtfill()
        Try
            Module1.DatasetFill("Select * from ProductType Order by ProdTypeID", "ProductType")

            If ds.Tables("ProductType").Rows.Count = 0 Then Exit Sub


            Me.txtID.Text = ds.Tables("ProductType").Rows(cnt).Item("ProdTypeID")
            Me.txtName.Text = ds.Tables("ProductType").Rows(cnt).Item("ProdTypeName")
            Me.txtNameEnglish.Text = ds.Tables("ProductType").Rows(cnt).Item("ProdTypeNameEnglish")

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

        SetupListForAll.GridFill2("Select * from ProductType Order by ProdTypeID", "ProductType")
        SetupListForAll.Obj = Me
        SetupListForAll.Show()

        SetupListForAll.MdiParent = Frm

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
            cmd.CommandText = "Select Max(ProdTypeID) from ProductType"
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
        cmdsave.CommandText = "InsertUpdateProductType"
        cmdsave.Connection = cn
        cmdsave.Parameters.Add("@ProdTypeID", SqlDbType.Int)
        cmdsave.Parameters("@ProdTypeID").Value = Me.TxtID.Text

        cmdsave.Parameters.Add("@ProdTypeName", SqlDbType.VarChar)
        cmdsave.Parameters("@ProdTypeName").Value = Me.txtName.Text

        cmdsave.Parameters.Add("@ProdTypeNameEnglish", SqlDbType.VarChar)
        cmdsave.Parameters("@ProdTypeNameEnglish").Value = Me.txtNameEnglish.Text

        cmdsave.Parameters.Add("@Flag", SqlDbType.Bit)
        cmdsave.Parameters("@Flag").Value = EditValue
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

        'SetupListForAll.GridFill2("Select * from ProductType Order by ProdTypeID", "ProductType")

        CMStatus()

        OpenGrid()


    End Sub

    Private Sub MnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuEdit.Click
        Call CStutus()
        EditValue = 0
        CMStatus()
    End Sub


    Private Sub MnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDelete.Click
        If Not Me.txtID.Text = "" Then

            If MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then

                Module1.DeleteRecord("ProductType", "ProdTypeID = " & TxtID.Text)

                SetupListForAll.GridFill("Select * from ProductType order by ProdTypeID", "ProductType")
                cnt = ds.Tables("ProductType").Rows.Count
                If cnt = 0 Then
                    txtID.Text = ""
                    txtName.Text = ""
                    txtNameEnglish.Text = ""
                    Exit Sub
                End If

                'cnt = cnt - 1
                Call TxtFillAfterDeletion()
                OpenGrid()


            End If
        End If

    End Sub
    Private Sub TxtFillAfterDeletion()

        If cnt <> Module1.ds.Tables("ProductType").Rows.Count Then
            ' MsgBox(Module1.ds.Tables("ProductType").Rows.Count)

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
        If cnt = ds.Tables("ProductType").Rows.Count - 1 Then Exit Sub
        cnt = cnt + 1
        Call txtfill()
        CMStatusDefault()
        CStatusDefault()
    End Sub



    Private Sub TSLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSLast.Click
        cnt = ds.Tables("ProductType").Rows.Count - 1
        Call txtfill()
        CMStatusDefault()
        CStatusDefault()
    End Sub
#End Region

   
    Private Sub LLProductTypesList_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LLProductTypesList.LinkClicked
        For Each fr As Form In Frm.MdiChildren
            If fr.Name = "SetupListForAll" Then
                fr.WindowState = FormWindowState.Normal
                fr.BringToFront()
            Else
                If SetupListForAll.Var_AlreadyDisplayed.Equals(False) Then
                    OpenGrid()
                End If

            End If
        Next
    End Sub
    Private Sub txtName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
        If e.KeyChar = Chr(13) Then
            MnuSave_Click(MnuSave, e)
        End If
    End Sub

    Private Sub FrmProductType_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        SetupListForAll.Close()
    End Sub



    Private Sub FrmProductType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        Me.TopMost = True
        Me.BringToFront()
    End Sub

    Private Sub txtName_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.Enter

        If Not KeyboardLayout.getName() = "00000429" Then
            KeyboardLayout.Farsi()
        End If
        'Dim PC As New System.Globalization.PersianCalendar

        'txtName.Text = PC.ToDateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day, System.DateTime.Now.Hour, System.DateTime.Now.Minute, System.DateTime.Now.Second, System.DateTime.Now.Millisecond)
    End Sub

    Private Sub txtNameEnglish_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNameEnglish.Enter
        'Dim PC As New System.Globalization.HijriCalendar
        'txtNameEnglish.Text = PC.ToDateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day, System.DateTime.Now.Hour, System.DateTime.Now.Minute, System.DateTime.Now.Second, System.DateTime.Now.Millisecond)
      
        If KeyboardLayout.getName() = "00000429" Then
            KeyboardLayout.English()
        End If
    End Sub
End Class