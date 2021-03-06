Imports System.Data.SqlClient
Imports System.IO
Imports LanguageSelector
Public Class FrmGoDown
    Dim EditValue As Integer
    Dim cnt As Integer
    Dim StrSearch As String
    Dim z As Integer
    Dim CityID As Integer
    Dim CityBasedID As String
    Private Sub FrmGoDown_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MinimizeBox = False
        Module1.Opencn()
        CityID = Frm.lbLocationID.Text
        CityBasedID = Frm.lbLocationName.Text
        Module1.DatasetFill("Select * from GoDown", "GoDown")
        cmbGoDownName.DataSource = ds.Tables("GoDown")
        cmbGoDownName.DisplayMember = ("GoDownName")
        cmbGoDownName.ValueMember = ("GoDownID")

        dtDate.Value = Now
        EditValue = 0
        Call Fill()

        'If Frm.GID.Text <= 2 Then
        '    CM.Enabled = True
        'Else
        '    CM.Enabled = False
        'End If
        If Frm.GID.Text > 2 Then
            Module1.CMStatusDisable(CM)
        End If
    End Sub
#Region "MAIN..........."

#Region "FUNSTIONS"

    Sub IDPICKER()
        Module1.DatasetFill("Select * from GoDown", "GoDown")
        cmd.CommandText = "Select isnull(Max(GoDownID),0) from GoDown"
        txtID.Text = cmd.ExecuteScalar + 1
    End Sub

    Sub Status()
        dtDate.Enabled = Not dtDate.Enabled
        txtGName.ReadOnly = Not txtGName.ReadOnly
        txtConcernName.ReadOnly = Not txtConcernName.ReadOnly
        txtphone.ReadOnly = Not txtphone.ReadOnly
        txtAddress.ReadOnly = Not txtAddress.ReadOnly
    End Sub
    Sub Clear()
        lblMessage.Text = ""
        dtDate.Value = Now
        txtGName.Text = ""
        txtConcernName.Text = ""
        txtphone.Text = ""
        txtAddress.Text = ""
    End Sub
    Sub CMStatus()
        TSAdd.Enabled = Not TSAdd.Enabled
        TSSave.Enabled = Not TSSave.Enabled
        TSUndo.Enabled = Not TSUndo.Enabled
        TSUpdate.Enabled = Not TSUpdate.Enabled
        TSDelete.Enabled = Not TSDelete.Enabled
        TSClose.Enabled = Not TSClose.Enabled
    End Sub
    Sub Fill()
        Try
            EditValue = 0
            lblMessage.Text = ""
            If cnt < 0 Then
                cnt = 0
            End If
            Module1.DatasetFill("Select * from VuGoDown", "VuGoDown")
            txtID.Text = ds.Tables("VuGoDown").Rows(cnt).Item("GoDownID")
            txtGName.Text = ds.Tables("VuGoDown").Rows(cnt).Item("GoDownName")
            txtConcernName.Text = ds.Tables("VuGoDown").Rows(cnt).Item("GoDownKepperName")
            txtphone.Text = ds.Tables("VuGoDown").Rows(cnt).Item("GoDownPhone")
            txtAddress.Text = ds.Tables("VuGoDown").Rows(cnt).Item("GoDownAddress")
            dtDate.Value = ds.Tables("VuGoDown").Rows(cnt).Item("dtDate")

        Catch ex As Exception
        End Try
    End Sub
    Sub SaveUpdateGoDown()
        Try

            If EditValue = 0 Then
                IDPICKER()
            End If
            Dim cmdsave As New SqlCommand

            cmdsave.CommandType = CommandType.StoredProcedure
            cmdsave.CommandText = "InsertUpdateGoDown"
            cmdsave.Connection = cn

            cmdsave.Parameters.Add("@GoDownID", SqlDbType.Int).Value = Me.txtID.Text
            cmdsave.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Me.dtDate.Value.Date.ToString
            cmdsave.Parameters.Add("@GoDownName", SqlDbType.NVarChar).Value = Me.txtGName.Text
            cmdsave.Parameters.Add("@GoDownKepperName", SqlDbType.NVarChar).Value = Me.txtConcernName.Text

            If txtphone.Text = "" Then
                cmdsave.Parameters.Add("@GoDownPhone", SqlDbType.NVarChar).Value = " "
            Else
                cmdsave.Parameters.Add("@GoDownPhone", SqlDbType.NVarChar).Value = Me.txtphone.Text
            End If

            If txtAddress.Text = "" Then
                cmdsave.Parameters.Add("@GoDownAddress", SqlDbType.NVarChar).Value = " "
            Else
                cmdsave.Parameters.Add("@GoDownAddress", SqlDbType.NVarChar).Value = Me.txtAddress.Text
            End If

            cmdsave.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
            cmdsave.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & txtID.Text
            cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = EditValue

            cmdsave.ExecuteNonQuery()
            cmdsave.Parameters.Clear()

            If EditValue = 0 Then
                Call CMStatus()
                Call Status()
                'Call Clear()
                'Call Fill()
                lblMessage.Text = "ریکارد شما موفقانه ثبت گردید"
                'MsgBox("THE RECORD HAS BEEN SAVED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & "ریکارد شما موفقانه ثبت گردید", MsgBoxStyle.Information)
            Else
                Call CMStatus()
                Call Status()
                'Call Clear()
                Call Fill()
                lblMessage.Text = "ریکارد شما موفقانه تجدید گردید"
                'MsgBox("THE RECORD HAS BEEN UPDATED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & "ریکارد شما موفقانه تنظیم گردید", MsgBoxStyle.Information)
                EditValue = 0
            End If

        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "CONTEXT MENUS"
    Private Sub TSClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSClose.Click
        Me.Close()
    End Sub
    Private Sub TSAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSAdd.Click
        Call Status()
        Call CMStatus()
        Call Clear()
    End Sub
    Private Sub TSSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSSave.Click
        Call SaveUpdateGoDown()
    End Sub
    Private Sub TSUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSUndo.Click
        Call CMStatus()
        Call Status()
        Call Clear()
        Call Fill()
    End Sub
    Private Sub TSUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSUpdate.Click
        EditValue = 1
        Call Status()
        Call CMStatus()
    End Sub
    Private Sub TSDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSDelete.Click
        Dim a As VariantType
        a = MsgBox("ARE YOU SURE.?" & Chr(13) & "  " & Chr(13) & " آیا شما مطمئن هستید  ", MsgBoxStyle.YesNo)
        If a = vbYes Then
            cmd.CommandText = " Delete from GoDown where GoDownID = " & Me.txtID.Text
            cmd.Connection = cn
            cmd.ExecuteNonQuery()
            'MsgBox("THE RECORD HAS BEEN DELETED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & " ریکارد مذکور موفقانه فسخ شد ", MsgBoxStyle.Information)
            If cnt = ds.Tables("VuGoDown").Rows.Count - 1 Then
                cnt = cnt - 1
            End If
            If cnt < 0 Then
                Clear()
            End If
            Call Fill()
            lblMessage.Text = "ریکارد مذکور موفقانه فسخ شد "
        End If
    End Sub
#End Region

#Region "NAVIGATIONS"
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        cnt = 0
        Call Fill()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If cnt = 0 Then Exit Sub
        cnt = cnt - 1
        Call Fill()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If cnt = ds.Tables("VuGoDown").Rows.Count - 1 Then Exit Sub
        cnt = cnt + 1
        Call Fill()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        cnt = ds.Tables("VuGoDown").Rows.Count - 1
        Call Fill()
    End Sub
#End Region

#Region "EVENTS"
#End Region

#End Region


#Region "SEARCH............"
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        DGSearch.Rows.Clear()
        If chbSingle.Checked.Equals(False) Then
            StrSearch = "Select GoDownName,GoDownKepperName,GoDownPhone,GoDownAddress from VuGoDown"
            Call GridFill()
        Else
            If cmbGoDownName.Text = "" Then
                MsgBox(" PLEASE FILL THE REQUIRED FIELD " & Chr(13) & "  " & Chr(13) & " لطفآ خانه مذکور را خالی نگذارید ", MsgBoxStyle.Critical)
            Else
                StrSearch = "Select GoDownName,GoDownKepperName,GoDownPhone,GoDownAddress from VuGoDown where GoDownID = " & cmbGoDownName.SelectedValue & ""
                Call GridFill()
            End If
        End If
    End Sub
    Sub GridFill()
        Try
            DGSearch.Rows.Clear()
            cmd.Connection = cn
            da.SelectCommand = cmd
            cmd.CommandText = StrSearch
            If (ds.Tables.Contains("VuGoDown")) Then
                ds.Tables("VuGoDown").Clear()
                DGSearch.Rows.Clear()
            End If
            da.Fill(ds, "VuGoDown")

            For z = 0 To ds.Tables("VuGoDown").Rows.Count - 1
                Try
                    DGSearch.Rows.Add()
                    DGSearch.Rows(z).Cells(0).Value = (z + 1).ToString()
                    DGSearch.Rows(z).Cells(1).Value = ds.Tables("VuGoDown").Rows(z).Item("GoDownName")
                    DGSearch.Rows(z).Cells(2).Value = ds.Tables("VuGoDown").Rows(z).Item("GoDownKepperName")
                    DGSearch.Rows(z).Cells(3).Value = ds.Tables("VuGoDown").Rows(z).Item("GoDownPhone")
                    DGSearch.Rows(z).Cells(4).Value = ds.Tables("VuGoDown").Rows(z).Item("GoDownAddress")
                Catch ex As Exception
                End Try

            Next
        Catch ex As Exception

        End Try
    End Sub
#End Region


#Region "KEY PRESS OF BOTH................."
    Private Sub txtphone_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtphone.KeyPress
        If e.KeyChar = Chr(32) Then
            e.Handled = True
        End If
        Dim Mes As Integer
        Mes = Asc(e.KeyChar)
        If (Mes > 47 And Mes < 58) Or e.KeyChar = Chr(32) Or e.KeyChar = Chr(8) Or e.KeyChar = Chr(45) Or e.KeyChar = Chr(40) Or e.KeyChar = Chr(41) Then

        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtConcernName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConcernName.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
        If txtConcernName.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
        If (e.KeyChar < Chr(47) Or e.KeyChar > Chr(58)) Or e.KeyChar = Chr(32) Then
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtGName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGName.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
        If txtGName.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtAddress_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If

        If txtAddress.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
    End Sub

#End Region


    Private Sub TC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TC.SelectedIndexChanged
        If Frm.GID.Text <= 2 Then
            If TC.SelectedIndex = 0 Then
                CM.Enabled = True
                ToolStrip1.Enabled = True
                If TSAdd.Enabled <> True Then
                    Call CMStatus()
                    Call Status()
                End If
                Call Clear()
                Call Fill()
                chbSingle.Checked = False
                cmbGoDownName.Enabled = False
            Else
                DGSearch.Rows.Clear()
                Module1.DatasetFill("Select * from GoDown", "GoDown")
                cmbGoDownName.DataSource = ds.Tables("GoDown")
                cmbGoDownName.DisplayMember = ("GoDownName")
                cmbGoDownName.ValueMember = ("GoDownID")
                cmbGoDownName.SelectedIndex = -1
                CM.Enabled = False
                ToolStrip1.Enabled = False
                chbSingle.Checked = False
                cmbGoDownName.Enabled = False
            End If
        End If
    End Sub

    Private Sub chbSingle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSingle.CheckedChanged
        If chbSingle.Checked.Equals(True) Then
            cmbGoDownName.Enabled = True
        Else
            cmbGoDownName.Enabled = False
        End If
    End Sub
End Class
