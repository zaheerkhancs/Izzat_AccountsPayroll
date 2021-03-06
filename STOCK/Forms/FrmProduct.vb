Imports System.Data.SqlClient
Imports LanguageSelector
Public Class FrmProduct
    Dim a As Integer
    Dim EditValue As Integer
    Dim cnt As Integer
    Dim EditProductType As Boolean
    Dim EditWeight As Boolean
    Dim RelationForeignKey
    Dim FieldToBeDisplayed
    Dim Navigating As Boolean = True
    Dim NewRecordIsSaved As Boolean
    Dim TimesDisplayed As Integer

    Private Sub FrmProduct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Module1.Opencn()
        'Me.Top = Frm.Height / 4
        'Me.Left = Frm.Width / 4
        'Me.Width = Screen.PrimaryScreen.Bounds.Width
        'Me.Height = Screen.PrimaryScreen.Bounds.Height
        Me.Top = Frm.Top
        Me.Left = Frm.Left
        'Me.CenterToScreen()
        ''Me.Panel6.Top = Me.Height / 2 - (Me.Panel6.Height / 2)
        'Me.Panel6.Left = Me.Width / 2 - (Me.Panel6.Width / 2)
        Module1.DatasetFill("Select * from ProductType", "ProductType")
        Call ComboFillerOfFahimshekaib(cmbProdType, "ProductType", "ProdTypeName", "ProdTypeID")
        Call ComboFillerOfFahimshekaib(cmbProdTypeEnglish, "ProductType", "ProdTypeNameEnglish", "ProdTypeID")
        Module1.DatasetFill("Select * from Weight", "Weight")
        Call ComboFillerOfFahimshekaib(cmbWeight, "Weight", "WeightName", "WeightID")

        Module1.DatasetFill("Select * from Product", "Product")
        Call txtfill()
        If Frm.GID.Text > 2 Then
            Module1.CMStatusDisable(CM)
        End If
    End Sub
#Region "Sub Functions txtclear,txtfill,OpenGrid,CMStatus,CMStatusDefault,CStatusDefault"
    Public Sub CStatusDefault()
        txtID.Enabled = False
        txtName.Enabled = False
        cmbProdType.Enabled = False
        cmbWeight.Enabled = False
        txtPcsInCrtn.ReadOnly = True
        txtPricePerCrtn.ReadOnly = True
        txtPricePerPcs.ReadOnly = True
        txtSalPerCrtn.ReadOnly = True
        txtSalPerPiece.ReadOnly = True
        txtSalPriceMobileCrtn.ReadOnly = True
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
        cmbProdType.Enabled = Not cmbProdType.Enabled
        cmbWeight.Enabled = Not cmbWeight.Enabled

        btnAddProdType.Enabled = Not btnAddProdType.Enabled
        btnAddWeight.Enabled = Not btnAddWeight.Enabled

        txtPcsInCrtn.ReadOnly = Not txtPcsInCrtn.ReadOnly
        txtPricePerPcs.ReadOnly = Not txtPricePerPcs.ReadOnly
        txtPricePerCrtn.ReadOnly = Not txtPricePerCrtn.ReadOnly
        txtSalPerCrtn.ReadOnly = Not txtSalPerCrtn.ReadOnly
        txtSalPerPiece.ReadOnly = Not txtSalPerPiece.ReadOnly
        txtSalPriceMobileCrtn.ReadOnly = Not txtSalPriceMobileCrtn.ReadOnly
    End Sub
    'Sub txtclear()
    '    'Dim C As Control
    '    'For Each C In Me.Controls
    '    '    If TypeOf C Is ComboBox Or TypeOf C Is TextBox Then
    '    '        C.Text = ""
    '    '    End If
    '    'Next
    '    Me.txtID.Text = ""
    '    Me.txtName.Text = ""
    '    Me.txtPricePerPcs.Text = 0
    '    Me.txtPricePerCrtn.Text = 0
    '    Me.txtPcsInCrtn.Text = 0
    '    Me.txtSalPerCrtn.Text = 0
    '    Me.txtSalPerPiece.Text = 0

    'End Sub
    Sub txtClear()
        For Each C As Control In Me.Controls
            If TypeOf C Is TextBox Then
                C.Text = ""
            End If
            If TypeOf C Is GroupBox Then
                For Each D As Control In C.Controls
                    If TypeOf D Is TextBox Then
                        D.Text = ""
                    End If
                Next
            End If

        Next

    End Sub
    Sub txtfill()
        Try
            Module1.DatasetFill("Select * from Product Order by ProdCode", "Product")

            If ds.Tables("Product").Rows.Count = 0 Then Exit Sub
            If NewRecordIsSaved.Equals(True) Then
                cnt = ds.Tables("Product").Rows.Count - 1
            End If

            Me.txtID.Text = ds.Tables("Product").Rows(cnt).Item("ProdCode")
            Me.txtName.Text = ds.Tables("Product").Rows(cnt).Item("ProdName")
            Me.txtNameEnglish.Text = ds.Tables("Product").Rows(cnt).Item("ProdNameEnglish")
            Me.cmbProdType.SelectedValue = ds.Tables("Product").Rows(cnt).Item("ProdTypeID")
            Me.cmbProdTypeEnglish.SelectedValue = ds.Tables("Product").Rows(cnt).Item("ProdTypeID")
            Me.cmbWeight.SelectedValue = ds.Tables("Product").Rows(cnt).Item("WeightID")
            Me.txtPcsInCrtn.Text = ds.Tables("Product").Rows(cnt).Item("PcsInCtrn")
            Me.txtPricePerPcs.Text = ds.Tables("Product").Rows(cnt).Item("PricePerPcs")
            Me.txtPricePerCrtn.Text = ds.Tables("Product").Rows(cnt).Item("PricePerCrtn")
            Me.txtSalPerCrtn.Text = ds.Tables("Product").Rows(cnt).Item("SalPerCrtn")
            Me.txtSalPerPiece.Text = ds.Tables("Product").Rows(cnt).Item("SalPerPiece")
            Me.txtSalPriceMobileCrtn.Text = ds.Tables("Product").Rows(cnt).Item("SalMobileCrtn")
            Me.txtSalPriceMobilePcs.Text = ds.Tables("Product").Rows(cnt).Item("SalMobilePcs")
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
        RelationForeignKey = "ProductType"
        FieldToBeDisplayed = "Product"
        SetupListForAll.GridFill3("Select ProdCode as شماره,ProdTypeName as نوع,Product as محصول,ProdTypeNameEnglish as 'Product Type',ProductEnglish as 'Product Name',PcsInCtrn as 'تعداد در فی کارتن',PricePerCrtn as 'خرید فی کارتن',PricePerPcs as 'خرید فی دانه' ,SalPerCrtn as 'فروش فی کارتن',SalPerPiece as 'فروش فی دانه' from VuProduct Order by ProdCode", "VuProduct", RelationForeignKey, FieldToBeDisplayed)
        SetupListForAll.Obj = Me
        SetupListForAll.Show()

        SetupListForAll.MdiParent = Frm

    End Sub
#End Region


#Region "ContextMenuButtons"


    Private Sub MnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuNew.Click
        'Me.RightToLeft = Windows.Forms.RightToLeft.Yes
        Navigating = False
        Try

            Dim sqldreader As SqlDataReader

            Call txtclear()
            Call CStutus()
            EditValue = 1
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select Max(ProdCode) from Product"
            cmd.Connection = cn

            sqldreader = cmd.ExecuteReader()
            While sqldreader.Read

                If IsDBNull(sqldreader.Item(0)) = True Then
                    Me.txtID.Text = 1
                Else
                    Me.txtID.Text = Val(sqldreader.Item(0)) + 1

                End If
            End While
            sqldreader.Close()
            txtName.Focus()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        CMStatus()
        cmbProdType.Focus()
    End Sub

    Private Sub MnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSave.Click
        If cmbProdType.Text = "" Or txtName.Text = "" Or cmbWeight.Text = "" Or txtPcsInCrtn.Text = "" Or txtPricePerPcs.Text = "" Then
            MsgBox(" PLEASE FILL THE REQUIRED FIELDS " & Chr(13) & "  " & Chr(13) & " لطفآ خانه های مذکور را خالی نگذارید ", MsgBoxStyle.Critical)
            Exit Sub
        Else
            Dim cmdsave As New SqlCommand
            cmdsave.CommandType = CommandType.StoredProcedure
            cmdsave.CommandText = "InsertUpdateProduct"
            cmdsave.Connection = cn
            cmdsave.Parameters.Add("@ProdCode", SqlDbType.Int).Value = Me.txtID.Text
            cmdsave.Parameters.Add("@ProdName", SqlDbType.VarChar).Value = Me.txtName.Text
            cmdsave.Parameters.Add("@ProdNameEnglish", SqlDbType.VarChar).Value = Me.txtNameEnglish.Text
            cmdsave.Parameters.Add("@ProdTypeID", SqlDbType.VarChar).Value = Me.cmbProdType.SelectedValue
            cmdsave.Parameters.Add("@WeightID", SqlDbType.VarChar).Value = Me.cmbWeight.SelectedValue
            cmdsave.Parameters.Add("@PcsInCtrn", SqlDbType.Decimal).Value = Val(txtPcsInCrtn.Text)
            cmdsave.Parameters.Add("@PricePerPcs", SqlDbType.Decimal).Value = txtPricePerPcs.Text
            cmdsave.Parameters.Add("@PricePerCrtn", SqlDbType.Decimal).Value = txtPricePerCrtn.Text
            cmdsave.Parameters.Add("@SalPerCrtn", SqlDbType.Decimal).Value = txtSalPerCrtn.Text
            cmdsave.Parameters.Add("@SalPerPiece", SqlDbType.Decimal).Value = txtSalPerPiece.Text
            cmdsave.Parameters.Add("@SalMobileCrtn", SqlDbType.Decimal).Value = txtSalPriceMobileCrtn.Text
            cmdsave.Parameters.Add("@SalMobilePcs", SqlDbType.Decimal).Value = txtSalPriceMobilePcs.Text

            cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = EditValue
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmdsave.ExecuteNonQuery()

            cmdsave.Parameters.Clear()
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
            SetupListForAll.GridFill3("Select ProdCode as شماره,ProdTypeName as نوع,Product as محصول,ProdTypeNameEnglish as 'Product Type',ProductEnglish as 'Product Name',PcsInCtrn as 'تعداد در فی کارتن',PricePerCrtn as 'خرید فی کارتن',PricePerPcs as 'خرید فی دانه' ,SalPerCrtn as 'فروش فی کارتن',SalPerPiece as 'فروش فی دانه' from VuProduct Order by ProdCode", "VuProduct", RelationForeignKey, FieldToBeDisplayed)
            CMStatus()
            OpenGrid()
            txtfill()
        End If
        Navigating = True
    End Sub

    Private Sub MnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuEdit.Click
        Call CStutus()
        EditValue = 0
        CMStatus()
        Navigating = False
    End Sub


    Private Sub MnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDelete.Click
        If Not Me.txtID.Text = "" Then

            If MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then

                Module1.DeleteRecord("Product", "ProdCode = " & txtID.Text)

                SetupListForAll.GridFill3("Select ProdCode as شماره,ProdTypeName as نوع,Product as محصول,ProdTypeNameEnglish as 'Product Type',ProductEnglish as 'Product Name',PcsInCtrn as 'تعداد در فی کارتن',PricePerCrtn as 'خرید فی کارتن',PricePerPcs as 'خرید فی دانه' ,SalPerCrtn as 'فروش فی کارتن',SalPerPiece as 'فروش فی دانه' from VuProduct Order by ProdCode", "VuProduct", RelationForeignKey, FieldToBeDisplayed)
                cnt = ds.Tables("Product").Rows.Count
                If cnt = 0 Then
                    txtClear()

                    Exit Sub
                End If

                'cnt = cnt - 1
                NewRecordIsSaved = False
                Call TxtFillAfterDeletion()
                OpenGrid()


            End If
        End If
        Module1.Opencn()
        Navigating = False
    End Sub


    Private Sub TxtFillAfterDeletion()

        If cnt <> Module1.ds.Tables("Product").Rows.Count Then
            ' MsgBox(Module1.ds.Tables("Product").Rows.Count)

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
        Navigating = True
    End Sub

    Private Sub MnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuExit.Click
        Me.Close()
    End Sub
#End Region
#Region "Navigation"
    Private Sub TSFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSFirst.Click
        cnt = 0
        NewRecordIsSaved = False
        Call txtfill()
        CMStatusDefault()
        CStatusDefault()
        Navigating = True
    End Sub
    Private Sub TSPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSPrevious.Click
        If cnt = 0 Then Exit Sub
        cnt = cnt - 1
        NewRecordIsSaved = False
        Call txtfill()
        CMStatusDefault()
        CStatusDefault()
        Navigating = True
    End Sub

    Private Sub TSNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSNext.Click
        If cnt = ds.Tables("Product").Rows.Count - 1 Then Exit Sub
        cnt = cnt + 1
        NewRecordIsSaved = False
        Call txtfill()
        CMStatusDefault()
        CStatusDefault()
        Navigating = True
    End Sub



    Private Sub TSLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSLast.Click
        cnt = ds.Tables("Product").Rows.Count - 1
        NewRecordIsSaved = False
        Call txtfill()
        CMStatusDefault()
        CStatusDefault()
        Navigating = True
    End Sub
#End Region

    Private Sub LLProductsList_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LLProductsList.LinkClicked
        For Each fr As Form In Frm.MdiChildren
            If fr.Name = "SetupListForAll" Then
                fr.WindowState = FormWindowState.Normal
                fr.BringToFront()
            Else

                If SetupListForAll.Var_AlreadyDisplayed.Equals(False) Then
                    ' If TimesDisplayed.Equals(0) Then
                    OpenGrid()
                    'TimesDisplayed += 1
                    'End If
                End If
                End If
        Next

    End Sub

 

    Private Sub FrmProduct_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        SetupListForAll.Close()
    End Sub
#Region "Combo Editors"
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
 

    Private Sub btnCancelProdType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelProdType.Click
        Try

            Module1.DatasetFill("Select * from ProductType", "ProductType")
            Call ComboFillerOfFahimshekaib(cmbProdType, "ProductType", "ProdTypeName", "ProdTypeID")
            EditProductType = False
            cmbProdType.DropDownStyle = ComboBoxStyle.DropDownList
            btnAddProdType.Text = "جدید"
            btnCancelProdType.Visible = False

        Catch ex As Exception
        End Try


    End Sub

    Private Sub btnAddProdType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddProdType.Click
        Dim NewID As Integer
        Try
            If EditProductType = True Then
                If cmbProdType.Text = "" Then
                    MsgBox(" PLEASE FILL THE REQUIRED FIELD " & Chr(13) & "  " & Chr(13) & " لطفآ خانه مذکور را خالی نگذارید ", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    cmd.CommandText = "Select isnull(Max(ProdTypeID),0) from ProductType"
                    NewID = cmd.ExecuteScalar + 1

                    'Module1.InsertRecord("Nationality", "NID,NName", "'" & NewID & "',N'" & cmbProdType.Text & "'")
                    'Module1.DatasetFill("Select * from Nationality", "Nationality")
                    Dim cmdsave As New SqlCommand
                    cmdsave.CommandType = CommandType.StoredProcedure
                    cmdsave.CommandText = "InsertUpdateProductType"
                    cmdsave.Connection = cn
                    cmdsave.Parameters.Add("@ProdTypeID", SqlDbType.Int)
                    cmdsave.Parameters("@ProdTypeID").Value = NewID

                    cmdsave.Parameters.Add("@ProdTypeName", SqlDbType.VarChar)
                    cmdsave.Parameters("@ProdTypeName").Value = cmbProdType.Text

                    cmdsave.Parameters.Add("@Flag", SqlDbType.Bit)
                    cmdsave.Parameters("@Flag").Value = EditValue
                    cmdsave.ExecuteNonQuery()

                    cmdsave.Parameters.Clear()

                    Module1.DatasetFill("Select * from ProductType", "ProductType")
                    Call ComboFillerOfFahimshekaib(cmbProdType, "ProductType", "ProdTypeName", "ProdTypeID")

                    cmbProdType.SelectedIndex = 0
                    cmbProdType.DropDownStyle = ComboBoxStyle.DropDownList
                    EditProductType = False
                    btnAddProdType.Text = "جدید"
                    btnCancelProdType.Visible = False
                End If
            Else
                cmbProdType.DataSource = Nothing
                cmbProdType.Items.Clear()
                cmbProdType.DropDownStyle = ComboBoxStyle.DropDown
                EditProductType = True
                btnAddProdType.Text = "ثبت"
                btnCancelProdType.Visible = True
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnAddWeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddWeight.Click
        Dim NewID As Integer
        Try
            If EditWeight = True Then
                If cmbWeight.Text = "" Then
                    MsgBox(" PLEASE FILL THE REQUIRED FIELD " & Chr(13) & "  " & Chr(13) & " لطفآ خانه مذکور را خالی نگذارید ", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    cmd.CommandText = "Select isnull(Max(WeightID),0) from Weight"
                    NewID = cmd.ExecuteScalar + 1

                    'Module1.InsertRecord("Nationality", "NID,NName", "'" & NewID & "',N'" & cmbProdType.Text & "'")
                    'Module1.DatasetFill("Select * from Nationality", "Nationality")
                    Dim cmdsave As New SqlCommand
                    cmdsave.CommandType = CommandType.StoredProcedure
                    cmdsave.CommandText = "InsertUpdateWeight"
                    cmdsave.Connection = cn
                    cmdsave.Parameters.Add("@WeightID", SqlDbType.Int)
                    cmdsave.Parameters("@WeightID").Value = NewID

                    cmdsave.Parameters.Add("@WeightName", SqlDbType.VarChar)
                    cmdsave.Parameters("@WeightName").Value = cmbWeight.Text

                    cmdsave.Parameters.Add("@Flag", SqlDbType.Bit)
                    cmdsave.Parameters("@Flag").Value = EditValue
                    cmdsave.ExecuteNonQuery()

                    cmdsave.Parameters.Clear()
                    Module1.DatasetFill("Select * from Weight", "Weight")
                    Call ComboFillerOfFahimshekaib(cmbWeight, "Weight", "WeightName", "WeightID")

                    cmbWeight.SelectedIndex = 0
                    cmbWeight.DropDownStyle = ComboBoxStyle.DropDownList
                    EditWeight = False
                    btnAddWeight.Text = "جدید"
                    btnCancelWeight.Visible = False
                End If
            Else
                cmbWeight.DataSource = Nothing
                cmbWeight.Items.Clear()
                cmbWeight.DropDownStyle = ComboBoxStyle.DropDown
                EditWeight = True
                btnAddWeight.Text = "ثبت"
                btnCancelWeight.Visible = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCancelWeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelWeight.Click
        Try

            Module1.DatasetFill("Select * from Weight", "Weight")
            Call ComboFillerOfFahimshekaib(cmbWeight, "Weight", "WeightName", "WeightID")

            EditWeight = False
            cmbWeight.DropDownStyle = ComboBoxStyle.DropDownList
            btnAddWeight.Text = "جدید"
            btnCancelWeight.Visible = False

        Catch ex As Exception
        End Try

    End Sub
#End Region

  
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            If txtID.Text = 0 Then
                Exit Sub
            Else
                Module1.DatasetFill("Select * from RptVuProduct", "RptVuProduct")

                'Module1.DatasetFill("Select * from RptVuProduct where ProdCode=" & txtID.Text, "RptVuProduct")
                Dim rpt As New RptProducts
                rpt.SetDataSource(Module1.ds.Tables("RptVuProduct"))
                frmRptSetup.CV.ReportSource = rpt
                Frm.RptShow()
                'Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
   

    Sub CalculatePurchasePrice()
        If Navigating = False Then
            Try
                If txtPricePerCrtn.Text = "" Then
                    txtPricePerCrtn.Text = 0
                End If
                txtPricePerPcs.Text = txtPricePerCrtn.Text / txtPcsInCrtn.Text
            Catch ex As Exception

            End Try
            If txtPricePerPcs.Text = "NaN" Then
                txtPricePerPcs.Text = 0
            End If
        End If
    End Sub

    Sub CalculateSalePrice()
        If Navigating = False Then
            Try
                If txtSalPerCrtn.Text = "" Then
                    txtSalPerPiece.Text = 0
                End If
                txtSalPerPiece.Text = txtSalPerCrtn.Text / txtPcsInCrtn.Text
            Catch ex As Exception

            End Try
            If txtSalPerPiece.Text = "NaN" Then
                txtSalPerPiece.Text = 0
            End If
        End If
    End Sub


    Private Sub txtPricePerCrtn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPricePerCrtn.TextChanged
        CalculatePurchasePrice()
    End Sub

    Private Sub txtPcsInCrtn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPcsInCrtn.TextChanged

        CalculatePurchasePrice()
        CalculateSalePrice()
    End Sub

    Private Sub txtSalPerCrtn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSalPerCrtn.TextChanged
        CalculateSalePrice()
    End Sub

    Private Sub cmbProdType_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbProdType.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
        cmbProdType.DroppedDown = True
        'If e.KeyChar = Chr(13) Then
        '    btnAddProdType.PerformClick()
        'End If
    End Sub

    Private Sub FrmProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        Me.TopMost = True
        Me.BringToFront()
    End Sub

    Private Sub txtName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub cmbProdTypeEnglish_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbProdTypeEnglish.KeyPress
        If KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.English()
        End If
    End Sub

    Private Sub txtNameEnglish_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNameEnglish.KeyPress
        If KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.English()
        End If
    End Sub

    Private Sub txtPcsInCrtn_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPcsInCrtn.KeyPress
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

    Private Sub txtPricePerCrtn_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPricePerCrtn.KeyPress
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

    Private Sub txtSalPerCrtn_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalPerCrtn.KeyPress
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

    Private Sub cmbWeight_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbWeight.KeyPress
        If KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.English()
        End If
        cmbWeight.DroppedDown = True
    End Sub

    Private Sub txtSalPriceMobileCrtn_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalPriceMobileCrtn.KeyPress
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

    Private Sub txtSalPriceMobileCrtn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSalPriceMobileCrtn.TextChanged
        If Navigating = False Then
            Try
                If txtSalPriceMobileCrtn.Text = "" Then
                    txtSalPriceMobileCrtn.Text = 0
                End If
                txtSalPriceMobilePcs.Text = txtSalPriceMobileCrtn.Text / txtPcsInCrtn.Text
            Catch ex As Exception

            End Try
            If txtSalPriceMobilePcs.Text = "NaN" Then
                txtSalPriceMobilePcs.Text = 0
            End If
        End If
    End Sub
End Class