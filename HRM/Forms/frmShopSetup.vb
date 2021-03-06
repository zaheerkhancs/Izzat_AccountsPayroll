Imports System.Data.SqlClient
Imports System.IO
Imports LanguageSelector
Public Class frmShopSetup
    Dim EditValue As Integer
    Dim cnt As Integer
    Dim EditCombo As Boolean
    Dim StrSearch As String
    Dim z As Integer
    Dim a As Integer
    Dim CityID As Integer
    Dim CItyBasedID As String
    Private Sub frmShopSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Module1.Opencn()
        CityID = Frm.lbLocationID.Text
        CItyBasedID = Frm.lbLocationName.Text
        Module1.DatasetFill("Select * from Shop", "Shop")
        cmd.CommandText = "Select isnull(Max(ShopID),0) from Shop"
        txtID.Text = cmd.ExecuteScalar + 1

        ' Newly added in march 07 08
        Module1.DatasetFill("Select * from Location", "Location")
        cmbCity.DataSource = ds.Tables("Location")
        cmbCity.DisplayMember = ("LocName")
        cmbCity.ValueMember = ("LocID")
        cmbCity.SelectedIndex = -1
        '
        Module1.DatasetFill("Select * from ShopType", "ShopType")
        cmbSType.DataSource = ds.Tables("ShopType")
        cmbSType.DisplayMember = ("STypeName")
        cmbSType.ValueMember = ("STypeID")
        cmbSType.SelectedIndex = -1

        Module1.DatasetFill("Select * from Shop", "Shop")
        CmbShop.DataSource = ds.Tables("Shop")
        CmbShop.DisplayMember = ("ShopName")
        CmbShop.ValueMember = ("ShopID")
        CmbShop.SelectedIndex = -1

        dtDate.Value = Now
        EditValue = 0
        EditCombo = False
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


#Region "MAIN.............."

#Region "FUNCTIONS"
    Sub Status()
        dtDate.Enabled = Not dtDate.Enabled
        cmbCity.Enabled = Not cmbCity.Enabled
        cmbSType.Enabled = Not cmbSType.Enabled
        btnAddCity.Enabled = Not btnAddCity.Enabled
        btnAddStype.Enabled = Not btnAddStype.Enabled
        txtShopName.ReadOnly = Not txtShopName.ReadOnly
        txtConcernName.ReadOnly = Not txtConcernName.ReadOnly
        txtphone.ReadOnly = Not txtphone.ReadOnly
        txtCell.ReadOnly = Not txtCell.ReadOnly
        txtFax.ReadOnly = Not txtFax.ReadOnly
        txtAddress.ReadOnly = Not txtAddress.ReadOnly
    End Sub
    Sub Clear()
        lblMessage.Text = ""
        dtDate.Value = Now
        cmbCity.SelectedIndex = -1
        cmbSType.SelectedIndex = -1
        txtShopName.Text = ""
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
            Module1.DatasetFill("Select * from VuShop", "VuShop")
            txtID.Text = ds.Tables("VuShop").Rows(cnt).Item("ShopID")
            cmbCity.Text = ds.Tables("VuShop").Rows(cnt).Item("LocName")
            cmbSType.Text = ds.Tables("VuShop").Rows(cnt).Item("StypeName")
            txtShopName.Text = ds.Tables("VuShop").Rows(cnt).Item("ShopName")
            txtConcernName.Text = ds.Tables("VuShop").Rows(cnt).Item("ConcernPName")
            txtphone.Text = ds.Tables("VuShop").Rows(cnt).Item("Phone")
            txtCell.Text = ds.Tables("VuShop").Rows(cnt).Item("CellNo")
            txtAddress.Text = ds.Tables("VuShop").Rows(cnt).Item("Address")
            txtFax.Text = ds.Tables("VuShop").Rows(cnt).Item("Fax")
           dtDate.Value = ds.Tables("VuShop").Rows(cnt).Item("SinceDate")

        Catch ex As Exception
        End Try
    End Sub
    Sub SaveUpdateShop()
        Try
            ' If edit value is 0 because All HRM is inverse, on editvalue 0 it saves and on editvalue 1 is updates.
            If EditValue = 0 Then
                IDPicker()
            End If

            Dim cmdsave As New SqlCommand

            cmdsave.CommandType = CommandType.StoredProcedure
            cmdsave.CommandText = "InsertUpdateShop"
            cmdsave.Connection = cn

            cmdsave.Parameters.Add("@ShopID", SqlDbType.Int).Value = Me.txtID.Text
            cmdsave.Parameters.Add("@LocID", SqlDbType.Int).Value = Me.cmbCity.SelectedValue
            cmdsave.Parameters.Add("@StypeID", SqlDbType.Int).Value = Me.cmbSType.SelectedValue
            cmdsave.Parameters.Add("@ShopName", SqlDbType.NVarChar).Value = Me.txtShopName.Text
            cmdsave.Parameters.Add("@ConcernPName", SqlDbType.NVarChar).Value = Me.txtConcernName.Text
            cmdsave.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = Me.txtphone.Text
            cmdsave.Parameters.Add("@CellNo", SqlDbType.NVarChar).Value = Me.txtCell.Text
            cmdsave.Parameters.Add("@Address", SqlDbType.NVarChar).Value = Me.txtAddress.Text
            cmdsave.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = Me.txtFax.Text
            cmdsave.Parameters.Add("@SinceDate", SqlDbType.SmallDateTime).Value = Me.dtDate.Value.Date.ToString
            cmdsave.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
            cmdsave.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CItyBasedID & "-" & txtID.Text
            cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = EditValue
            If cn.State = ConnectionState.Closed Then cn.Open()
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
    Private Sub TSAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSAdd.Click
        Call Status()
        Call CMStatus()
        Call Clear()
    End Sub

    Private Sub TSSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSSave.Click
        Call SaveUpdateShop()
    End Sub
    Private Sub TSUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSUndo.Click
        Call CMStatus()
        Call Status()
        btnCancelStype.PerformClick()
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
            cmd.CommandText = " Delete from Shop where ShopID = " & Me.txtID.Text
            cmd.Connection = cn
            cmd.ExecuteNonQuery()
            'MsgBox("THE RECORD HAS BEEN DELETED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & " ریکارد مذکور موفقانه فسخ شد ", MsgBoxStyle.Information)
            If cnt = ds.Tables("VuShop").Rows.Count - 1 Then
                cnt = cnt - 1
            End If
            If cnt < 0 Then
                Clear()
            End If
            Call Fill()
            lblMessage.Text = "ریکارد مذکور موفقانه فسخ شد "
        End If
    End Sub
    Private Sub TSClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSClose.Click
        Me.Close()
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
        If cnt = ds.Tables("VuShop").Rows.Count - 1 Then Exit Sub
        cnt = cnt + 1
        Call Fill()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        cnt = ds.Tables("VuShop").Rows.Count - 1
        Call Fill()
    End Sub
#End Region

#Region "EVENTS"
    Dim aziz As Integer = 0
  
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

    Private Sub txtShopName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtShopName.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
        If txtShopName.Text = "" Then
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

#End Region



#Region "SEARCH..............."
    Sub GridFill()
        Try
            DGSearch.Rows.Clear()
            cmd.Connection = cn
            da.SelectCommand = cmd
            cmd.CommandText = StrSearch
            If (ds.Tables.Contains("VuShop")) Then
                ds.Tables("VuShop").Clear()
                DGSearch.Rows.Clear()
            End If
            da.Fill(ds, "VuShop")

            For z = 0 To ds.Tables("VuShop").Rows.Count - 1
                Try
                    DGSearch.Rows.Add()
                    DGSearch.Rows(z).Cells("SNo").Value = (z + 1).ToString()
                    DGSearch.Rows(z).Cells("SName").Value = ds.Tables("VuShop").Rows(z).Item("ShopName")
                    DGSearch.Rows(z).Cells("SCName").Value = ds.Tables("VuShop").Rows(z).Item("ConcernPName")
                    DGSearch.Rows(z).Cells("SLoc").Value = ds.Tables("VuShop").Rows(z).Item("LocName")
                    DGSearch.Rows(z).Cells("STel").Value = ds.Tables("VuShop").Rows(z).Item("Phone")
                    DGSearch.Rows(z).Cells("SType").Value = ds.Tables("VuShop").Rows(z).Item("STypeName")
                    DGSearch.Rows(z).Cells("SAddress").Value = ds.Tables("VuShop").Rows(z).Item("Address")
                Catch ex As Exception
                End Try

            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        DGSearch.Rows.Clear()
        If chbSingle.Checked.Equals(False) Then
            StrSearch = "Select ShopName,ConcernPName,LocName,Phone,STypeName,Address from VuShop"
            Call GridFill()
        Else
            If CmbShop.Text = "" Then
                MsgBox(" PLEASE FILL THE REQUIRED FIELD " & Chr(13) & "  " & Chr(13) & " لطفآ خانه مذکور را خالی نگذارید ", MsgBoxStyle.Critical)
                Exit Sub
            Else
                StrSearch = "Select ShopName,ConcernPName,LocName,Phone,STypeName,Address from VuShop where ShopID =" & CmbShop.SelectedValue & ""
                Call GridFill()
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
                CmbShop.Enabled = False
            Else
                DGSearch.Rows.Clear()

                Module1.DatasetFill("Select * from Shop", "Shop")
                CmbShop.DataSource = ds.Tables("Shop")
                CmbShop.DisplayMember = ("ShopName")
                CmbShop.ValueMember = ("ShopID")
                CmbShop.SelectedIndex = -1
                CM.Enabled = False
                ToolStrip1.Enabled = False
                chbSingle.Checked = False
                CmbShop.Enabled = False
            End If
        End If
    End Sub

   

  
    Private Sub btnAddCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCity.Click
        Dim abc As String
        If EditCombo = True Then
            If cmbCity.Text = "" Then
                MsgBox(" PLEASE FILL THE REQUIRED FIELD " & Chr(13) & "  " & Chr(13) & " لطفآ خانه مذکور را خالی نگذارید ", MsgBoxStyle.Critical)
                Exit Sub
            Else
                Try
                    For a = 0 To ds.Tables("Location").Rows.Count
                        abc = ds.Tables("Location").Rows(a).Item(1)
                        If cmbCity.Text = abc Then
                            MsgBox("THE RECORD ALREADY EXIST" & Chr(13) & "  " & Chr(13) & "ریکارد ذکر شده قبلآ موجود است", MsgBoxStyle.Critical)
                            cmbCity.Text = ""
                            Exit Sub
                        End If
                    Next

                Catch ex As Exception
                End Try
                cmd.CommandText = "Select isnull(Max(LocID),0) from Location"
                lblLocID.Text = cmd.ExecuteScalar + 1
                Module1.InsertRecord("Location", "LocID,LocName", "'" & lblLocID.Text & "',N'" & cmbCity.Text & "'")
                Module1.DatasetFill("Select * from Location", "Location")

                cmbCity.DataSource = ds.Tables("Location")
                cmbCity.DisplayMember = ("LocName")
                cmbCity.ValueMember = ("LocID")
                aziz = cmbCity.Items.Count
                cmbCity.SelectedIndex = aziz - 1
                cmbCity.DropDownStyle = ComboBoxStyle.DropDownList
                EditCombo = False
                btnAddCity.Text = "جدید"
                btnCancelCity.Visible = False
                CM.Enabled = True
                ToolStrip1.Enabled = True
            End If
        Else
            cmbCity.DataSource = Nothing
            cmbCity.Items.Clear()
            cmbCity.DropDownStyle = ComboBoxStyle.DropDown
            EditCombo = True
            btnAddCity.Text = "ثبت"
            btnCancelCity.Visible = True
            CM.Enabled = False
            ToolStrip1.Enabled = False
        End If
    End Sub



    Private Sub btnCancelStype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelStype.Click
        Module1.DatasetFill("Select * from ShopType", "ShopType")
        cmbSType.DataSource = ds.Tables("ShopType")
        cmbSType.DisplayMember = ("STypeName")
        cmbSType.ValueMember = ("STypeID")
        cmbSType.SelectedIndex = 0
        cmbSType.DropDownStyle = ComboBoxStyle.DropDownList
        EditCombo = False
        btnAddStype.Text = "جدید"
        btnCancelStype.Visible = False
        CM.Enabled = True
        ToolStrip1.Enabled = True
    End Sub

    Private Sub btnAddStype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddStype.Click
        Dim abc As String
        If EditCombo = True Then
            If cmbSType.Text = "" Then
                MsgBox(" PLEASE FILL THE REQUIRED FIELD " & Chr(13) & "  " & Chr(13) & " لطفآ خانه مذکور را خالی نگذارید ", MsgBoxStyle.Critical)
                Exit Sub
            Else
                Try
                    For a = 0 To ds.Tables("ShopType").Rows.Count
                        abc = ds.Tables("ShopType").Rows(a).Item(1)
                        If cmbSType.Text = abc Then
                            MsgBox("THE RECORD ALREADY EXIST" & Chr(13) & "  " & Chr(13) & "ریکارد ذکر شده قبلآ موجود است", MsgBoxStyle.Critical)
                            cmbSType.Text = ""
                            Exit Sub
                        End If
                    Next

                Catch ex As Exception
                End Try
                cmd.CommandText = "Select isnull(Max(StypeID),0) from ShopType"
                lblLocID.Text = cmd.ExecuteScalar + 1
                Module1.InsertRecord("ShopType", "StypeID,StypeName", "'" & lblLocID.Text & "',N'" & cmbSType.Text & "'")
                Module1.DatasetFill("Select * from ShopType", "ShopType")

                cmbSType.DataSource = ds.Tables("ShopType")
                cmbSType.DisplayMember = ("STypeName")
                cmbSType.ValueMember = ("STypeID")
                aziz = cmbSType.Items.Count
                cmbSType.SelectedIndex = aziz - 1
                cmbSType.DropDownStyle = ComboBoxStyle.DropDownList
                EditCombo = False
                btnAddStype.Text = "جدید"
                btnCancelStype.Visible = False
                CM.Enabled = True
                ToolStrip1.Enabled = True
            End If
        Else
            cmbSType.DataSource = Nothing
            cmbSType.Items.Clear()
            cmbSType.DropDownStyle = ComboBoxStyle.DropDown
            EditCombo = True
            btnAddStype.Text = "ثبت"
            btnCancelStype.Visible = True
            CM.Enabled = False
            ToolStrip1.Enabled = False
        End If
    End Sub
    Private Sub btnCancelCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelCity.Click
        Module1.DatasetFill("Select * from Location", "Location")
        cmbCity.DataSource = ds.Tables("Location")
        cmbCity.DisplayMember = ("LocName")
        cmbCity.ValueMember = ("LocID")
        cmbCity.SelectedIndex = 0
        cmbCity.DropDownStyle = ComboBoxStyle.DropDownList
        EditCombo = False
        btnAddCity.Text = "جدید"
        btnCancelCity.Visible = False
        CM.Enabled = True
        ToolStrip1.Enabled = True
    End Sub

    Private Sub LLCityList_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LLCityList.LinkClicked
        Me.OpenGrid("Location", "LocID")
    End Sub
    Sub OpenGrid(ByVal OpenGridTableName As String, ByVal OpenGridCriteria As String)

        SetupListForAllHRM.GridFill("Select * from " & OpenGridTableName & " Order by " & OpenGridCriteria, OpenGridTableName)
        SetupListForAllHRM.Obj = Me
        SetupListForAllHRM.Show()

        SetupListForAll.MdiParent = Frm
        SetupListForAllHRM.TopMost = True



    End Sub

    Private Sub LLSaleTypeList_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LLSaleTypeList.LinkClicked
        Me.OpenGrid("ShopType", "STypeID")
    End Sub
    Sub IDPicker()
        Try

            Dim sqldreader As SqlDataReader
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select Max(ShopID) from Shop"
            cmd.Connection = cn
            If cn.State = ConnectionState.Closed Then cn.Open()
            sqldreader = cmd.ExecuteReader()
            While sqldreader.Read

                If IsDBNull(sqldreader.Item(0)) = True Then
                    Me.txtID.Text = 1
                Else
                    Me.txtID.Text = Val(sqldreader.Item(0)) + 1

                End If
            End While
            sqldreader.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbCity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCity.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub cmbSType_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbSType.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub chbSingle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSingle.CheckedChanged
        If chbSingle.Checked.Equals(True) Then
            CmbShop.Enabled = True
        Else
            CmbShop.Enabled = False
        End If
    End Sub

End Class