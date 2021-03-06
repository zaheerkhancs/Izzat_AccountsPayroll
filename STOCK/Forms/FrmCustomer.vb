Imports System.Data.SqlClient
Imports LanguageSelector
Public Class FrmCustomer
    Dim a As Integer
    Dim EditValue As Integer
    Dim cnt As Integer
    Dim RelationForeignKey
    Dim FieldToBeDisplayed
    Dim Var_CustomerID As Integer
    Dim CustomerTableName As String
    Dim CustomerID As String
    Dim ForeignField As Integer
    Dim AddEdit As Boolean
    Private Sub Customer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Module1.Opencn()
        Me.Top = Frm.Height / 4
        Me.Left = Frm.Width / 4
        'Me.Width = Screen.PrimaryScreen.Bounds.Width
        'Me.Height = Screen.PrimaryScreen.Bounds.Height
        'Me.CenterToScreen()
        ''Me.Panel6.Top = Me.Height / 2 - (Me.Panel6.Height / 2)
        'Me.Panel6.Left = Me.Width / 2 - (Me.Panel6.Width / 2)
        AddEdit = False
        Module1.DatasetFill("Select * from Location", "Location")
        cmbLocation.DataSource = ds.Tables("Location")
        cmbLocation.DisplayMember = "LocName"
        cmbLocation.ValueMember = "LocID"
        Module1.DatasetFill("Select * from Shop", "Shop")
        cmbShop.DataSource = ds.Tables("Shop")
        cmbShop.DisplayMember = "ShopName"
        cmbShop.ValueMember = "ShopID"

        Module1.DatasetFill("Select * from Customer", "Customer")
      
        Call ComboCustomerTypeFill()
        Call txtfill()
        DisableFields()
        'If cmbCustomerName.Text = cmbCustomerName.SelectedItem() Then

        'End If
        If Frm.GID.Text > 2 Then
            Module1.CMStatusDisable(CM)
        End If
    End Sub
#Region "Sub Functions txtclear,txtfill,OpenGrid,CMStatus,CMStatusDefault,CStatusDefault"
    Public Sub CStatusDefault()
        txtphone.Enabled = False
        cmbCustomerName.Enabled = False
        cmbType.Enabled = False
        cmbLocation.Enabled = False
        cmbShop.Enabled = False
    End Sub
    Public Sub CMStatusDefault()
        MnuNew.Enabled = True
        MnuEdit.Enabled = True
        MnuSave.Enabled = False
        MnuDelete.Enabled = True
        MnuUndo.Enabled = False


    End Sub
    Sub CStutus()
        Dim C As Control
        For Each C In Me.Controls
            If TypeOf C Is TextBox Or TypeOf C Is ComboBox Or TypeOf C Is DateTimePicker Then
                'Dim s As String = C.Name
                'If s = cmbLocation.Name Then
                '    MsgBox("asdf")
                'End If
                C.Enabled = Not C.Enabled

              
            End If
        Next


        'txtphone.Enabled = Not txtphone.Enabled
        'txtName.Enabled = Not txtName.Enabled
        'cmbType.Enabled = Not cmbType.Enabled
    End Sub
    Sub txtclear()
        Dim C As Control
        For Each C In Me.Controls
            If TypeOf C Is TextBox Then
                C.Text = ""
            End If
        Next
        txtInvCode.Text = ""
    End Sub
    Sub ComboCustomerTypeFill()
        Try

            Module1.DatasetFill("Select * from CustomerType", "CustomerType")
            cmbType.DataSource = ds.Tables("CustomerType")
            cmbType.DisplayMember = "CustomerTypeName"
            cmbType.ValueMember = "CustomerTypeID"
            If Module1.ds.Tables("CustomerType").Rows.Count > 0 Then
                cmbType.SelectedIndex = 0
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub txtfill()
        Try
            Module1.DatasetFill("Select * from Customer Order by CustomerID", "Customer")

            If ds.Tables("Customer").Rows.Count = 0 Then Exit Sub


            Me.Var_CustomerID = ds.Tables("Customer").Rows(cnt).Item("CustomerID")

            Me.cmbType.SelectedValue = ds.Tables("Customer").Rows(cnt).Item("CustomerTypeID")
            'If cmbType.SelectedValue > 1 Then
            cmbCustomerName.DataSource = Nothing
            cmbCustomerName.Items.Clear()
            Module1.DatasetFill("Select * from VuCustomer where CustomerTypeID =" & cmbType.SelectedValue, "VuCustomer")
            FillCustomerCombo("VuCustomer", "CustomerName", "CustomerID")
            ' End If
            cmbCustomerName.Text = ds.Tables("Customer").Rows(cnt).Item("CustomerName")
            txtphone.Text = ds.Tables("Customer").Rows(cnt).Item("Phone")
            txtCell.Text = ds.Tables("Customer").Rows(cnt).Item("CellNo")
            txtFax.Text = ds.Tables("Customer").Rows(cnt).Item("Fax")
            txtAddress.Text = ds.Tables("Customer").Rows(cnt).Item("Address")
            dtSinceDate.Value = ds.Tables("Customer").Rows(cnt).Item("SinceDate")
            ' the following code is later added.
            txtInvCode.Text = ds.Tables("Customer").Rows(cnt).Item("InvoiceCode")

            If cmbType.SelectedIndex = 0 Then
                txtInvCode.Visible = True
                lblInvCode.Visible = True
            Else
                txtInvCode.Visible = False
                lblInvCode.Visible = False
            End If

            If ds.Tables("Customer").Rows(cnt).Item("LocID") = 0 Then
                cmbShop.Visible = False
                chk.Visible = False
                chk.Checked = True
                lblShop.Visible = False
                cmbLocation.Visible = False
                cmbLocation.Left = 197
                cmbLocation.Top = 401
                lblLocation.Visible = False
                lblLocation.Top = 403
            Else
                lblShop.Visible = True
                cmbShop.Visible = True
                chk.Visible = True
                chk.Checked = False
                cmbLocation.Visible = True
                cmbLocation.Left = 197
                cmbLocation.Top = 346
                lblLocation.Visible = True
                lblLocation.Top = 346
                cmbLocation.SelectedValue = ds.Tables("Customer").Rows(cnt).Item("LocID")
                cmbShop.SelectedValue = ds.Tables("Customer").Rows(cnt).Item("ShopID")
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
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
        RelationForeignKey = "CustomerType"
        FieldToBeDisplayed = "CustomerName"
        SetupListForAll.GridFill3("Select CustomerID,CustomerTypeName as 'نوع مشتری ',CustomerName as 'اسم مستری',InvoiceCode as 'مخفف انوایس',Phone as 'تیلیفون',CellNo as 'موبائل',Address as 'آدرس',Fax as 'فکس',Convert(Varchar(11),SinceDate,106) as 'تاریخ استخدام' from VuCustomerForSetupList Order by CustomerTypeName Desc,CustomerName Asc", "VuCustomerForSetupList", RelationForeignKey, FieldToBeDisplayed)
        SetupListForAll.Obj = Me
        SetupListForAll.Show()
        SetupListForAll.MdiParent = Frm
    End Sub
#End Region


#Region "ContextMenuButtons"


    Private Sub MnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuNew.Click
        'Me.RightToLeft = Windows.Forms.RightToLeft.Yes
        If cmbType.SelectedIndex <> 2 Then
            Call txtclear()
            DisableFields()
        Else
            Call txtclear()
        End If

        Call CStutus()
        EditValue = 1
        cmbCustomerName.Focus()
        CMStatus()
        AddEdit = True
    End Sub

    Private Sub MnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSave.Click
        Dim headid As String
        cmd.CommandText = "Select CustoSubCode from Impheads"
        If cn.State = ConnectionState.Closed Then cn.Open()
        headid = cmd.ExecuteScalar
        'AZIZ
        Module1.DatasetFill("Select * from VuCustomer where CustomerTypeID = " & cmbType.SelectedValue & "And CustomerID= " & cmbCustomerName.SelectedValue, "VuCustomer")
        'AZIZ

        'THE FOLLOWING IS FOR CHECKING INVOICE CODE DUPLICATION
        If cmbType.SelectedIndex = 0 And EditValue = 1 Then
            Module1.DatasetFill("Select CustomerName from Customer where InvoiceCode ='" & txtInvCode.Text.Trim() & "'", "Customer")
            If ds.Tables("Customer").Rows.Count <> 0 Then
                MessageBox.Show("         " & txtInvCode.Text & "   ---   " & ds.Tables("Customer").Rows(0).Item("CustomerName") & Chr(13) & "این کود انوائس از قبل موجود است ", "تخطی از قانون", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            'Module1.DatasetFill("Select CustomerName from Customer where CustomerTypeID =1 And CustomerName ='" & cmbCustomerName.Text & "'", "Customer")
            'If ds.Tables("Customer").Rows.Count <> 0 Then
            '    MessageBox.Show("                                   " & ds.Tables("Customer").Rows(0).Item("CustomerName") & Chr(13) & "این اسم از قبل موجود است ", "تخطی از قانون", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            '    Exit Sub
            'End If
        End If
        'THE FOLLOWING IS FOR GENERAL DUPLICATE RECORD.
        Module1.DatasetFill("Select CustomerName from Customer where CustomerTypeID =" & cmbType.SelectedValue & " And CustomerName ='" & cmbCustomerName.Text & "'", "Customer")
        If ds.Tables("Customer").Rows.Count <> 0 And EditValue = 1 Then
            MessageBox.Show("                                   " & ds.Tables("Customer").Rows(0).Item("CustomerName") & Chr(13) & "این اسم از قبل موجود است ", "تخطی از قانون", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            'Trans.Rollback()
            Exit Sub

        End If

        'Try
        
        'Catch ex As Exception

        'End Try
        'THE FOLLOWING DATASETFILL IS FOR CHECKING IN OMOMY OR OTHERS.
        If cmbType.SelectedIndex > 1 Then
            Module1.DatasetFill("Select * from VuCustomer where CustomerTypeID = " & cmbType.SelectedValue & " And ForeignField= " & cmbCustomerName.Text.GetHashCode(), "VuCustomer")
        End If
        If cmbCustomerName.Text.Trim = "" Then Exit Sub
        If EditValue = 1 Then
            'MsgBox(cmbCustomerName.Text)
            Call IDPicker()
        End If
        Dim cmdsave As New SqlCommand
        Trans = cn.BeginTransaction
        cmdsave.Transaction = Trans
        Try
            cmdsave.CommandType = CommandType.StoredProcedure
            cmdsave.CommandText = "InsertUpdateCustomer"
            cmdsave.Connection = cn

            cmdsave.Parameters.Add("@CustomerID", SqlDbType.Int).Value = Me.Var_CustomerID
            cmdsave.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = cmbCustomerName.Text
            cmdsave.Parameters.Add("@CustomerTypeID", SqlDbType.Int).Value = Me.cmbType.SelectedValue
            cmdsave.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = Me.txtphone.Text
            cmdsave.Parameters.Add("@CellNo", SqlDbType.NVarChar).Value = Me.txtCell.Text
            cmdsave.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = Me.txtFax.Text
            cmdsave.Parameters.Add("@Address", SqlDbType.NVarChar).Value = Me.txtAddress.Text
            cmdsave.Parameters.Add("@SinceDate", SqlDbType.SmallDateTime).Value = Me.dtSinceDate.Value.Date.ToString
            If cmbType.SelectedIndex > 1 Then
                cmdsave.Parameters.Add("@ForeignField", SqlDbType.NVarChar).Value = cmbCustomerName.Text.GetHashCode()
            Else
                cmdsave.Parameters.Add("@ForeignField", SqlDbType.NVarChar).Value = Me.ForeignField
            End If
            If cmbType.SelectedIndex = 0 Then
                cmdsave.Parameters.Add("@InvoiceCode", SqlDbType.NVarChar).Value = txtInvCode.Text.Trim()
            Else
                cmdsave.Parameters.Add("@InvoiceCode", SqlDbType.Int).Value = 0
            End If
            If cmbType.SelectedIndex > 1 Then
                If chk.Checked.Equals(True) Then
                    cmdsave.Parameters.Add("@LocID", SqlDbType.Int).Value = 0
                    cmdsave.Parameters.Add("@ShopID", SqlDbType.Int).Value = 0
                Else

                    cmdsave.Parameters.Add("@LocID", SqlDbType.Int).Value = cmbLocation.SelectedValue
                    cmdsave.Parameters.Add("@ShopID", SqlDbType.Int).Value = cmbShop.SelectedValue

                End If

            Else
                cmdsave.Parameters.Add("@LocID", SqlDbType.Int).Value = 0
                cmdsave.Parameters.Add("@ShopID", SqlDbType.Int).Value = 0

            End If

            cmdsave.Parameters.Add("@CityID", SqlDbType.Int).Value = Val("1")
            cmdsave.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = "KBL" & Me.Var_CustomerID
            cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = EditValue
            If cmbType.SelectedIndex > 1 Then

                If ds.Tables("VuCustomer").Rows.Count = 1 And EditValue = 1 Then
                    MessageBox.Show("این ریکارد از قبل وجود دارد", "تخطی از قانون", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    lblMessage.Text = ""
                    Trans.Rollback()
                    Exit Sub

                Else
                    'If cn.State = ConnectionState.Closed Then cn.Open()

                    cmdsave.ExecuteNonQuery()
                    cmdsave.Parameters.Clear()
                    If EditValue = 1 Then
                        cmd.Connection = cn
                        cmd.Transaction = Trans
                        cmd.CommandText = "INSERT INTO Subsidiary VALUES(" & Me.Var_CustomerID & ",N'" & Me.cmbCustomerName.Text & "',N'" & headid & "','" & Me.dtSinceDate.Value & "',N' From HRM '," & Frm.LbUserID.Text & "," & Frm.LBCompanyID.Text & ",N'" & Frm.WName.Text & "')"
                        '    cmd.Transaction = Trans
                        cmd.ExecuteNonQuery()
                        Trans.Commit()

                        lblMessage.Text = "ریکارد شما موفقانه ثبت گردید"
                        ' MsgBox("Your Record has been saved successfully..")
                    Else



                        'MsgBox("Your Record has been updated successfully..")
                        cmd.Connection = cn
                        cmd.Transaction = Trans
                        cmd.Connection = cn
                        cmd.CommandText = "UPDATE Subsidiary SET SubName =N'" & Me.cmbCustomerName.Text & "',HEADID='" & headid & "',REMARKS=N' From HRM ',date='" & Me.dtSinceDate.Value & "',UserID=" & Frm.LbUserID.Text & ",WName=N'" & Frm.WName.Text & "' WHERE SUBID=" & Me.Var_CustomerID
                        ' cmd.Transaction = Trans
                        cmd.ExecuteNonQuery()
                        Trans.Commit()
                        lblMessage.Text = "ریکارد شما موفقانه تجدید گردید"
                    End If

                    CMStatus()
                    CStutus()
                    OpenGrid()
                    If cmbType.SelectedIndex <> 2 Then
                        DisableFields()
                    End If
                End If
            Else

                If ds.Tables("VuCustomer").Rows.Count = 1 And EditValue = 1 Then
                    MessageBox.Show("این ریکارد از قبل وجود دارد", "تخطی از قانون", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    lblMessage.Text = ""
                    Trans.Rollback()
                Else
                    ' If cn.State = ConnectionState.Closed Then cn.Open()
                    cmdsave.ExecuteNonQuery()
                    cmdsave.Parameters.Clear()
                    If EditValue = 1 Then
                        cmd.Connection = cn
                        cmd.Transaction = Trans
                        cmd.CommandText = "INSERT INTO Subsidiary VALUES(" & Me.Var_CustomerID & ",N'" & Me.cmbCustomerName.Text & "',N'" & headid & "','" & Me.dtSinceDate.Value & "',N' From HRM '," & Frm.LbUserID.Text & "," & Frm.LBCompanyID.Text & ",N'" & Frm.WName.Text & "')"
                        '    cmd.Transaction = Trans
                        cmd.ExecuteNonQuery()
                        Trans.Commit()

                        lblMessage.Text = "ریکارد شما موفقانه ثبت گردید"
                        ' MsgBox("Your Record has been saved successfully..")
                    Else
                        cmd.Connection = cn
                        cmd.Transaction = Trans
                        cmd.Connection = cn
                        cmd.CommandText = "UPDATE Subsidiary SET SubName =N'" & Me.cmbCustomerName.Text & "',HEADID='" & headid & "',REMARKS=N' From HRM ',date='" & Me.dtSinceDate.Value & "',UserID=" & Frm.LbUserID.Text & ",WName=N'" & Frm.WName.Text & "' WHERE SUBID=" & Me.Var_CustomerID
                        ' cmd.Transaction = Trans
                        cmd.ExecuteNonQuery()
                        Trans.Commit()
                        lblMessage.Text = "ریکارد شما موفقانه تجدید گردید"

                        'MsgBox("Your Record has been updated successfully..")

                    End If

                    CMStatus()
                    CStutus()
                    OpenGrid()
                    If cmbType.SelectedIndex <> 2 Then
                        DisableFields()
                    End If
                End If
            End If
            AddEdit = False
        Catch ex As Exception
            Trans.Rollback()
        End Try
        Module1.DatasetFill("Select ShopID,ShopName from Shop", "Shop")
        cmbShop.DataSource = ds.Tables("Shop")
        cmbShop.DisplayMember = "ShopName"
        cmbShop.ValueMember = "ShopID"
    End Sub

    Private Sub MnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuEdit.Click
        Call CStutus()
        EditValue = 0

        CMStatus()
        AddEdit = True
        If cmbType.SelectedIndex > 1 Then
            cmbShop.Visible = True
            chk.Visible = True
            cmbShop.Enabled = True
            lblShop.Visible = True
            cmbLocation.Visible = True
            cmbLocation.Left = 197
            cmbLocation.Top = 346
            lblLocation.Visible = True
            lblLocation.Top = 346
            If ds.Tables("Customer").Rows(cnt).Item("LocID") = 0 Then
                chk.Checked = True
            Else
                chk.Checked = False
            End If


        End If
    End Sub


    Private Sub MnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDelete.Click
        If Not Me.Var_CustomerID = 0 Then

            If MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then

                Module1.DeleteRecord("Customer", "CustomerID = " & Var_CustomerID)

                Module1.DeleteRecord("Subsidiary", "SubID = " & Var_CustomerID)

                SetupListForAll.GridFill3("Select CustomerTypeName as 'نوع مشتری ',CustomerName as 'اسم مستری',InvoiceCode as 'مخفف انوایس',Phone as 'تیلیفون',CellNo as 'موبائل',Address as 'آدرس',Fax as 'فکس',Convert(Varchar(11),SinceDate,106) as 'تاریخ استخدام' from VuCustomerForSetupList Order by CustomerTypeName Desc,CustomerName Asc", "Customer", RelationForeignKey, FieldToBeDisplayed)
                cnt = ds.Tables("Customer").Rows.Count
                If cnt = 0 Then
                    Var_CustomerID = 0
                    cmbCustomerName.Text = ""
                    Exit Sub
                End If

                'cnt = cnt - 1
                Call TxtFillAfterDeletion()
                OpenGrid()


            End If
        End If

    End Sub
    Private Sub TxtFillAfterDeletion()

        If cnt <> Module1.ds.Tables("Customer").Rows.Count Then
            ' MsgBox(Module1.ds.Tables("Customer").Rows.Count)

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
        DisableFields()
        txtclear()
        CMStatus()
        AddEdit = False
        Call txtfill()
    End Sub

    Private Sub MnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuExit.Click
        Me.Close()
    End Sub
#End Region
#Region "Navigation"
    Private Sub TSFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSFirst.Click
        cnt = 0
        AddEdit = False
        Call txtfill()
        CMStatusDefault()
        CStatusDefault()
    End Sub
    Private Sub TSPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSPrevious.Click
        If cnt = 0 Then Exit Sub
        cnt = cnt - 1
        AddEdit = False
        Call txtfill()
        CMStatusDefault()
        CStatusDefault()
    End Sub

    Private Sub TSNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSNext.Click
        If cnt = ds.Tables("Customer").Rows.Count - 1 Then Exit Sub
        cnt = cnt + 1
        AddEdit = False
        Call txtfill()
        CMStatusDefault()
        CStatusDefault()
    End Sub



    Private Sub TSLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSLast.Click
        cnt = ds.Tables("Customer").Rows.Count - 1
        AddEdit = False
        Call txtfill()
        CMStatusDefault()
        CStatusDefault()
    End Sub
#End Region

    Private Sub LLCustomersList_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LLCustomersList.LinkClicked
        For Each fr As Form In Frm.MdiChildren
            If fr.Name = "SetupListForAll" Then
                fr.WindowState = FormWindowState.Normal
                fr.BringToFront()
            Else
                OpenGrid()
            End If
        Next
    End Sub

    Private Sub txtCustomerName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            MnuSave_Click(MnuSave, e)
        End If
    End Sub

    Private Sub Customer_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        SetupListForAll.Close()
    End Sub
    Sub FillCustomerCombo(ByVal NameOfTable As String, ByVal DisplayMember As String, ByVal ValueMember As String)
        cmbCustomerName.DataSource = ds.Tables(NameOfTable)
        cmbCustomerName.DisplayMember = DisplayMember
        cmbCustomerName.ValueMember = ValueMember
    End Sub
    Private Sub cmbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged
        If AddEdit = True Then
            Try
                If cmbType.SelectedIndex > 2 Then
                    cmbCustomerName.DropDownStyle = ComboBoxStyle.DropDown

                Else


                    Select Case (cmbType.SelectedIndex)
                        Case 0

                            Module1.DatasetFill("Select * from EmpPerInfo where Department = 1 And Name Not In(Select CustomerName from Customer where CustomerTypeID =1)", "EmpPerInfo")
                            CustomerTableName = "EmpPerInfo"
                            CustomerID = "EmpID"
                            Call FillCustomerCombo("EmpPerInfo", "Name", "EmpID")
                            txtInvCode.Visible = True
                            lblInvCode.Visible = True
                            txtclear()
                            cmbCustomerName.DropDownStyle = ComboBoxStyle.DropDownList
                            cmbShop.Visible = False
                            chk.Visible = False
                            lblShop.Visible = False
                            cmbLocation.Visible = False
                            cmbLocation.Left = 197
                            cmbLocation.Top = 401
                            lblLocation.Visible = False
                            lblLocation.Top = 403
                            cmbLocation.Enabled = False
                        Case 1
                            Module1.DatasetFill("Select * from Province where ProvinceName Not In(Select CustomerName from Customer where CustomerTypeID =2)", "Province")

                            CustomerTableName = "Province"
                            CustomerID = "ProvinceID"
                            Call FillCustomerCombo("Province", "ConcernPName", "ProvinceID")
                            txtInvCode.Visible = False
                            lblInvCode.Visible = False
                            txtclear()
                            cmbCustomerName.DropDownStyle = ComboBoxStyle.DropDownList
                            cmbShop.Visible = False
                            chk.Visible = False
                            lblShop.Visible = False
                            cmbLocation.Visible = False
                            cmbLocation.Left = 197
                            cmbLocation.Top = 401
                            lblLocation.Visible = False
                            lblLocation.Top = 403
                            cmbLocation.Enabled = False
                        Case 2

                            cmbCustomerName.DataSource = Nothing
                            cmbCustomerName.Items.Clear()
                            Dim C As Control
                            For Each C In Me.Controls
                                If TypeOf C Is TextBox Then
                                    C.Text = ""
                                End If
                            Next
                            EnableFields()
                            txtInvCode.Visible = False
                            lblInvCode.Visible = False
                            cmbCustomerName.DropDownStyle = ComboBoxStyle.DropDown
                            cmbShop.Visible = True
                            chk.Visible = True
                            cmbShop.Enabled = True
                            lblShop.Visible = True
                            cmbLocation.Visible = True
                            cmbLocation.Left = 197
                            cmbLocation.Top = 346
                            lblLocation.Visible = True
                            lblLocation.Top = 346
                            cmbLocation.Enabled = True
                    End Select
                End If
                If cmbType.SelectedIndex > 1 Then
                    cmbCustomerName.DataSource = Nothing
                    cmbCustomerName.Items.Clear()
                    txtInvCode.Visible = False
                    lblInvCode.Visible = False
                    cmbCustomerName.DropDownStyle = ComboBoxStyle.DropDown
                    cmbShop.Visible = True
                    chk.Visible = True
                    cmbShop.Enabled = True
                    lblShop.Visible = True
                    cmbLocation.Visible = True
                    cmbLocation.Left = 197
                    cmbLocation.Top = 346
                    lblLocation.Visible = True
                    lblLocation.Top = 346
                    cmbLocation.Enabled = True
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
    Sub DisableFields()
        Dim C As Control
        For Each C In Me.Controls
            If TypeOf C Is TextBox Then
                C.Enabled = False
            End If
        Next
    End Sub
    Sub EnableFields()
        Dim C As Control
        For Each C In Me.Controls
            If TypeOf C Is TextBox Then
                C.Enabled = True
            End If
        Next
    End Sub

    Private Sub cmbCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomerName.SelectedIndexChanged
        If AddEdit = True Then
            Try

                If cmbType.SelectedIndex = 0 Then
                    Module1.DatasetFill("select * from VuEmpPerInfo where EmpID= " & cmbCustomerName.SelectedValue, "VuEmpPerInfo")

                    txtphone.Text = ds.Tables("VuEmpPerInfo").Rows(0)("ContactNo")
                    txtCell.Text = ""
                    txtFax.Text = ""
                    txtAddress.Text = ds.Tables("VuEmpPerInfo").Rows(0)("Address")
                    dtSinceDate.Value = ds.Tables("VuEmpPerInfo").Rows(0)("dtDate")
                    ForeignField = ds.Tables("VuEmpPerInfo").Rows(0).Item("EmpId")
                    DisableFields()
                    txtInvCode.Enabled = True
                Else
                    If cmbType.SelectedIndex = 1 Then
                        Module1.DatasetFill("select * from VuProvince where ProvinceID= " & cmbCustomerName.SelectedValue, "VuProvince")

                        txtphone.Text = ds.Tables("VuProvince").Rows(0)("Phone")
                        txtCell.Text = ds.Tables("VuProvince").Rows(0)("CellNo")
                        txtFax.Text = ds.Tables("VuProvince").Rows(0)("Fax")
                        txtAddress.Text = ds.Tables("VuProvince").Rows(0)("Address")
                        dtSinceDate.Value = ds.Tables("VuProvince").Rows(0)("SinceDate")
                        ForeignField = ds.Tables("VuProvince").Rows(0).Item("ProvinceID")
                        DisableFields()
                    End If
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
    Sub IDPicker()
        Dim id As Integer
        Try

            Dim sqldreader As SqlDataReader
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select Max(CustomerID) from Customer"
            cmd.Connection = cn
            Module1.Opencn()
            sqldreader = cmd.ExecuteReader()
            While sqldreader.Read

                If IsDBNull(sqldreader.Item(0)) = True Then
                    id = 1
                Else
                    id = Val(sqldreader.Item(0)) + 1

                End If
            End While
            sqldreader.Close()

            cmd.CommandText = "Select isnull(Max(SubID),0) from Subsidiary"
            If id < (cmd.ExecuteScalar + 1) Then
                Me.Var_CustomerID = cmd.ExecuteScalar + 1
            Else
                Me.Var_CustomerID = id
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

   
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
    Private Sub txtInvCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInvCode.KeyPress
        If KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.English()
        End If
        'If IsNumeric(sender.text & e.KeyChar) = False Then
        '    e.Handled = False
        'Else
        '    e.Handled = True
        'End If
        'MsgBox(Asc(e.KeyChar))
        'If IsNumeric(txtInvCode.Text & e.KeyChar) = True And Asc(e.KeyChar) <> 8 Then e.Handled = True
        If Asc(e.KeyChar) > 96 And Asc(e.KeyChar) < 123 Or Asc(e.KeyChar) = 32 Or Asc(e.KeyChar) = 8 Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub FrmCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        Me.TopMost = True
        Me.BringToFront()
    End Sub


    Private Sub cmbLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLocation.SelectedIndexChanged
        Try

            If AddEdit.Equals(True) Then
                Module1.DatasetFill("Select * from Shop where LocID=" & cmbLocation.SelectedValue, "Shop")
                cmbShop.DataSource = ds.Tables("Shop")
                cmbShop.DisplayMember = "ShopName"
                cmbShop.ValueMember = "ShopID"
            Else
                Module1.DatasetFill("Select * from Shop", "Shop")
                cmbShop.DataSource = ds.Tables("Shop")
                cmbShop.DisplayMember = "ShopName"
                cmbShop.ValueMember = "ShopID"

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbType_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbType.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub cmbCustomerName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCustomerName.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub txtAddress_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub cmbShop_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbShop.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub cmbLocation_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbLocation.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub


    Private Sub cmbShop_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbShop.SelectedIndexChanged
        Try
            Module1.DatasetFill("select * from VuShop where ShopID= " & cmbShop.SelectedValue, "VuShop")
            cmbCustomerName.Text = ds.Tables("VuShop").Rows(0)("ConcernPName")
            txtphone.Text = ds.Tables("VuShop").Rows(0)("Phone")
            txtCell.Text = ds.Tables("VuShop").Rows(0)("CellNo")
            txtFax.Text = ds.Tables("VuShop").Rows(0)("Fax")
            txtAddress.Text = ds.Tables("VuShop").Rows(0)("Address")
            dtSinceDate.Value = ds.Tables("VuShop").Rows(0)("SinceDate")
            ForeignField = ds.Tables("VuShop").Rows(0).Item("ShopID")

        Catch ex As Exception

        End Try
        

    End Sub
End Class