Imports System.Data.SqlClient
Imports System.IO
Imports LanguageSelector
Public Class frmProvinces
    Dim EditValue As Integer
    Dim cnt As Integer
    Dim StrSearch As String
    Dim z As Integer
    Dim CityID As Integer
    Dim CItyBasedID As String
    Private Sub frmProvinces_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Module1.Opencn()
        CityID = Frm.lbLocationID.Text
        CItyBasedID = Frm.lbLocationName.Text

        Module1.DatasetFill("Select * from Province", "Province")
        cmbProviceName.DataSource = ds.Tables("Province")
        cmbProviceName.DisplayMember = ("ProvinceName")
        cmbProviceName.ValueMember = ("ProvinceID")

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
#Region "MAIN..............."

    Sub IDPICKER()
        Module1.DatasetFill("Select * from Province", "Province")
        cmd.CommandText = "Select isnull(Max(ProvinceID),0) from Province"
        txtID.Text = cmd.ExecuteScalar + 1
    End Sub

#Region "FUNCTIONS"
    Sub Status()
        dtDate.Enabled = Not dtDate.Enabled
        txtPName.ReadOnly = Not txtPName.ReadOnly
        txtConcernName.ReadOnly = Not txtConcernName.ReadOnly
        txtphone.ReadOnly = Not txtphone.ReadOnly
        txtCell.ReadOnly = Not txtCell.ReadOnly
        txtFax.ReadOnly = Not txtFax.ReadOnly
        txtAddress.ReadOnly = Not txtAddress.ReadOnly
    End Sub
    Sub Clear()
        lblMessage.Text = ""
        dtDate.Value = Now
        txtPName.Text = ""
        txtConcernName.Text = ""
        txtphone.Text = ""
        txtCell.Text = ""
        txtFax.Text = ""
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
            Module1.DatasetFill("Select * from VuProvince", "VuProvince")
            txtID.Text = ds.Tables("VuProvince").Rows(cnt).Item("ProvinceID")
            txtPName.Text = ds.Tables("VuProvince").Rows(cnt).Item("ProvinceName")
            txtConcernName.Text = ds.Tables("VuProvince").Rows(cnt).Item("ConcernPName")
            txtphone.Text = ds.Tables("VuProvince").Rows(cnt).Item("Phone")
            txtCell.Text = ds.Tables("VuProvince").Rows(cnt).Item("CellNo")
            txtAddress.Text = ds.Tables("VuProvince").Rows(cnt).Item("Address")
            txtFax.Text = ds.Tables("VuProvince").Rows(cnt).Item("Fax")
            dtDate.Value = ds.Tables("VuProvince").Rows(cnt).Item("SinceDate")

        Catch ex As Exception
        End Try
    End Sub
    Sub SaveUpdateProvince()
        Try
            If EditValue = 0 Then
                IDPICKER()
            End If
            Dim cmdsave As New SqlCommand

            cmdsave.CommandType = CommandType.StoredProcedure
            cmdsave.CommandText = "InsertUpdateProvince"
            cmdsave.Connection = cn

            cmdsave.Parameters.Add("@ProvinceID", SqlDbType.Int).Value = Me.txtID.Text
            cmdsave.Parameters.Add("@ProvinceName", SqlDbType.NVarChar).Value = Me.txtPName.Text
            cmdsave.Parameters.Add("@ConcernPName", SqlDbType.NVarChar).Value = Me.txtConcernName.Text
            If txtphone.Text = "" Then
                cmdsave.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = " "
            Else
                cmdsave.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = Me.txtphone.Text
            End If
            cmdsave.Parameters.Add("@CellNo", SqlDbType.NVarChar).Value = Me.txtCell.Text
            cmdsave.Parameters.Add("@Address", SqlDbType.NVarChar).Value = Me.txtAddress.Text
            cmdsave.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = Me.txtFax.Text
            cmdsave.Parameters.Add("@SinceDate", SqlDbType.SmallDateTime).Value = Me.dtDate.Value.Date.ToString
            cmdsave.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
            cmdsave.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CItyBasedID & "-" & txtID.Text
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
        Call SaveUpdateProvince()
    End Sub

    Private Sub TSUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSUndo.Click
        Call CMStatus()
        Call Status()
        Clear()
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
            cmd.CommandText = " Delete from Province where ProvinceID = " & Me.txtID.Text
            cmd.Connection = cn
            cmd.ExecuteNonQuery()
            'MsgBox("THE RECORD HAS BEEN DELETED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & " ریکارد مذکور موفقانه فسخ شد ", MsgBoxStyle.Information)
            If cnt = ds.Tables("VuProvince").Rows.Count - 1 Then
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
        If cnt = ds.Tables("VuProvince").Rows.Count - 1 Then Exit Sub
        cnt = cnt + 1
        Call Fill()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        cnt = ds.Tables("VuProvince").Rows.Count - 1
        Call Fill()
    End Sub
#End Region

#End Region


#Region "SEARCH......................."
    Private Sub btnSearc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearc.Click
        DGSearch.Rows.Clear()
        If chbSingle.Checked.Equals(False) Then
            StrSearch = "Select ProvinceName,ConcernPName,Phone,Fax,Address from VuProvince"
            Call GridFill()
        Else
            If cmbProviceName.Text = "" Then
                MsgBox(" PLEASE FILL THE REQUIRED FIELD " & Chr(13) & "  " & Chr(13) & " لطفآ خانه مذکور را خالی نگذارید ", MsgBoxStyle.Critical)
                Exit Sub
            Else
                StrSearch = "Select ProvinceName,ConcernPName,Phone,Fax,Address from VuProvince where ProvinceID=" & cmbProviceName.SelectedValue & ""
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
            If (ds.Tables.Contains("VuProvince")) Then
                ds.Tables("VuProvince").Clear()
                DGSearch.Rows.Clear()
            End If
            da.Fill(ds, "VuProvince")

            For z = 0 To ds.Tables("VuProvince").Rows.Count - 1
                Try
                    DGSearch.Rows.Add()
                    DGSearch.Rows(z).Cells(0).Value = (z + 1).ToString()
                    DGSearch.Rows(z).Cells(1).Value = ds.Tables("VuProvince").Rows(z).Item("ProvinceName")
                    DGSearch.Rows(z).Cells(2).Value = ds.Tables("VuProvince").Rows(z).Item("ConcernPName")
                    DGSearch.Rows(z).Cells(3).Value = ds.Tables("VuProvince").Rows(z).Item("Phone")
                    DGSearch.Rows(z).Cells(4).Value = ds.Tables("VuProvince").Rows(z).Item("Fax")
                    DGSearch.Rows(z).Cells(5).Value = ds.Tables("VuProvince").Rows(z).Item("Address")
                Catch ex As Exception
                End Try

            Next
        Catch ex As Exception

        End Try
    End Sub
#End Region


#Region "KEY PRESS FOR BOTH.............."
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

    Private Sub txtCell_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCell.KeyPress
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

    Private Sub txtFax_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFax.KeyPress
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

    Private Sub txtPName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPName.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
        If txtPName.Text = "" Then
            If e.KeyChar = Chr(32) Then
                e.Handled = True
            End If
        End If
        If (e.KeyChar < Chr(47) Or e.KeyChar > Chr(58)) Or e.KeyChar = Chr(32) Then
        Else
            e.Handled = True
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
                cmbProviceName.Enabled = False
            Else
                DGSearch.Rows.Clear()
                Module1.DatasetFill("Select * from Province", "Province")
                cmbProviceName.DataSource = ds.Tables("Province")
                cmbProviceName.DisplayMember = ("ProvinceName")
                cmbProviceName.ValueMember = ("ProvinceID")
                cmbProviceName.SelectedIndex = -1
                CM.Enabled = False
                ToolStrip1.Enabled = False
                chbSingle.Checked = False
                cmbProviceName.Enabled = False
            End If
        End If
    End Sub

    Private Sub chbSingle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSingle.CheckedChanged
        If chbSingle.Checked.Equals(True) Then
            cmbProviceName.Enabled = True
        Else
            cmbProviceName.Enabled = False
        End If
    End Sub
End Class