<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShopSetup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmShopSetup))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.TC = New System.Windows.Forms.TabControl
        Me.TP1 = New System.Windows.Forms.TabPage
        Me.lblLocID = New System.Windows.Forms.Label
        Me.LLSaleTypeList = New System.Windows.Forms.LinkLabel
        Me.lbSTypeID = New System.Windows.Forms.Label
        Me.btnAddStype = New System.Windows.Forms.Button
        Me.btnCancelStype = New System.Windows.Forms.Button
        Me.cmbSType = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.LLCityList = New System.Windows.Forms.LinkLabel
        Me.Label12 = New System.Windows.Forms.Label
        Me.btnCancelCity = New System.Windows.Forms.Button
        Me.btnAddCity = New System.Windows.Forms.Button
        Me.cmbCity = New System.Windows.Forms.ComboBox
        Me.lblMessage = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtphone = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtConcernName = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtDate = New System.Windows.Forms.DateTimePicker
        Me.txtAddress = New System.Windows.Forms.TextBox
        Me.txtFax = New System.Windows.Forms.TextBox
        Me.txtCell = New System.Windows.Forms.TextBox
        Me.txtShopName = New System.Windows.Forms.TextBox
        Me.txtID = New System.Windows.Forms.TextBox
        Me.TP2 = New System.Windows.Forms.TabPage
        Me.DGSearch = New System.Windows.Forms.DataGridView
        Me.GBSearch = New System.Windows.Forms.GroupBox
        Me.chbSingle = New System.Windows.Forms.CheckBox
        Me.CmbShop = New System.Windows.Forms.ComboBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TSAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.TSSave = New System.Windows.Forms.ToolStripMenuItem
        Me.TSUndo = New System.Windows.Forms.ToolStripMenuItem
        Me.TSUpdate = New System.Windows.Forms.ToolStripMenuItem
        Me.TSDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.TSClose = New System.Windows.Forms.ToolStripMenuItem
        Me.SAddress = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SLoc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SCName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TC.SuspendLayout()
        Me.TP1.SuspendLayout()
        Me.TP2.SuspendLayout()
        CType(Me.DGSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBSearch.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.CM.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(166, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(396, 56)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "معلومات مکمل دوکاندار"
        Me.ToolTip1.SetToolTip(Me.Label1, "Complete Information Of ShopKeppers")
        '
        'TC
        '
        Me.TC.Controls.Add(Me.TP1)
        Me.TC.Controls.Add(Me.TP2)
        Me.TC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TC.Location = New System.Drawing.Point(59, 138)
        Me.TC.Name = "TC"
        Me.TC.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TC.RightToLeftLayout = True
        Me.TC.SelectedIndex = 0
        Me.TC.Size = New System.Drawing.Size(586, 383)
        Me.TC.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.Teal
        Me.TP1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TP1.Controls.Add(Me.lblLocID)
        Me.TP1.Controls.Add(Me.LLSaleTypeList)
        Me.TP1.Controls.Add(Me.lbSTypeID)
        Me.TP1.Controls.Add(Me.btnAddStype)
        Me.TP1.Controls.Add(Me.btnCancelStype)
        Me.TP1.Controls.Add(Me.cmbSType)
        Me.TP1.Controls.Add(Me.Label10)
        Me.TP1.Controls.Add(Me.LLCityList)
        Me.TP1.Controls.Add(Me.Label12)
        Me.TP1.Controls.Add(Me.btnCancelCity)
        Me.TP1.Controls.Add(Me.btnAddCity)
        Me.TP1.Controls.Add(Me.cmbCity)
        Me.TP1.Controls.Add(Me.lblMessage)
        Me.TP1.Controls.Add(Me.Label7)
        Me.TP1.Controls.Add(Me.txtphone)
        Me.TP1.Controls.Add(Me.Label2)
        Me.TP1.Controls.Add(Me.txtConcernName)
        Me.TP1.Controls.Add(Me.Label9)
        Me.TP1.Controls.Add(Me.label6)
        Me.TP1.Controls.Add(Me.Label5)
        Me.TP1.Controls.Add(Me.Label4)
        Me.TP1.Controls.Add(Me.Label3)
        Me.TP1.Controls.Add(Me.dtDate)
        Me.TP1.Controls.Add(Me.txtAddress)
        Me.TP1.Controls.Add(Me.txtFax)
        Me.TP1.Controls.Add(Me.txtCell)
        Me.TP1.Controls.Add(Me.txtShopName)
        Me.TP1.Controls.Add(Me.txtID)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Name = "TP1"
        Me.TP1.Padding = New System.Windows.Forms.Padding(3)
        Me.TP1.Size = New System.Drawing.Size(578, 357)
        Me.TP1.TabIndex = 0
        Me.TP1.Text = "معلومات دوکاندار"
        '
        'lblLocID
        '
        Me.lblLocID.AutoSize = True
        Me.lblLocID.ForeColor = System.Drawing.Color.White
        Me.lblLocID.Location = New System.Drawing.Point(29, 76)
        Me.lblLocID.Name = "lblLocID"
        Me.lblLocID.Size = New System.Drawing.Size(58, 13)
        Me.lblLocID.TabIndex = 317
        Me.lblLocID.Text = "LocationID"
        Me.lblLocID.Visible = False
        '
        'LLSaleTypeList
        '
        Me.LLSaleTypeList.ActiveLinkColor = System.Drawing.Color.Lime
        Me.LLSaleTypeList.AutoSize = True
        Me.LLSaleTypeList.LinkColor = System.Drawing.Color.White
        Me.LLSaleTypeList.Location = New System.Drawing.Point(217, 106)
        Me.LLSaleTypeList.Name = "LLSaleTypeList"
        Me.LLSaleTypeList.Size = New System.Drawing.Size(32, 13)
        Me.LLSaleTypeList.TabIndex = 6
        Me.LLSaleTypeList.TabStop = True
        Me.LLSaleTypeList.Text = "لست"
        '
        'lbSTypeID
        '
        Me.lbSTypeID.AutoSize = True
        Me.lbSTypeID.ForeColor = System.Drawing.Color.White
        Me.lbSTypeID.Location = New System.Drawing.Point(29, 107)
        Me.lbSTypeID.Name = "lbSTypeID"
        Me.lbSTypeID.Size = New System.Drawing.Size(66, 13)
        Me.lbSTypeID.TabIndex = 315
        Me.lbSTypeID.Text = "ShopTypeID"
        Me.lbSTypeID.Visible = False
        '
        'btnAddStype
        '
        Me.btnAddStype.BackColor = System.Drawing.Color.Transparent
        Me.btnAddStype.Enabled = False
        Me.btnAddStype.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAddStype.ForeColor = System.Drawing.Color.White
        Me.btnAddStype.Location = New System.Drawing.Point(161, 102)
        Me.btnAddStype.Name = "btnAddStype"
        Me.btnAddStype.Size = New System.Drawing.Size(44, 22)
        Me.btnAddStype.TabIndex = 7
        Me.btnAddStype.Text = "جدید"
        Me.ToolTip1.SetToolTip(Me.btnAddStype, "Add New")
        Me.btnAddStype.UseVisualStyleBackColor = False
        '
        'btnCancelStype
        '
        Me.btnCancelStype.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelStype.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelStype.ForeColor = System.Drawing.Color.White
        Me.btnCancelStype.Location = New System.Drawing.Point(102, 102)
        Me.btnCancelStype.Name = "btnCancelStype"
        Me.btnCancelStype.Size = New System.Drawing.Size(53, 22)
        Me.btnCancelStype.TabIndex = 8
        Me.btnCancelStype.Text = "فسخ"
        Me.ToolTip1.SetToolTip(Me.btnCancelStype, "Cancel")
        Me.btnCancelStype.UseVisualStyleBackColor = False
        Me.btnCancelStype.Visible = False
        '
        'cmbSType
        '
        Me.cmbSType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSType.Enabled = False
        Me.cmbSType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbSType.FormattingEnabled = True
        Me.cmbSType.Location = New System.Drawing.Point(260, 103)
        Me.cmbSType.Name = "cmbSType"
        Me.cmbSType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbSType.Size = New System.Drawing.Size(149, 21)
        Me.cmbSType.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(483, 105)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 314
        Me.Label10.Text = "نوع فروش"
        Me.ToolTip1.SetToolTip(Me.Label10, "Sale Type")
        '
        'LLCityList
        '
        Me.LLCityList.ActiveLinkColor = System.Drawing.Color.Lime
        Me.LLCityList.AutoSize = True
        Me.LLCityList.LinkColor = System.Drawing.Color.White
        Me.LLCityList.Location = New System.Drawing.Point(217, 80)
        Me.LLCityList.Name = "LLCityList"
        Me.LLCityList.Size = New System.Drawing.Size(32, 13)
        Me.LLCityList.TabIndex = 2
        Me.LLCityList.TabStop = True
        Me.LLCityList.Text = "لست"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(493, 83)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 13)
        Me.Label12.TabIndex = 309
        Me.Label12.Text = "موقعیت"
        Me.ToolTip1.SetToolTip(Me.Label12, "Location")
        '
        'btnCancelCity
        '
        Me.btnCancelCity.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelCity.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelCity.ForeColor = System.Drawing.Color.White
        Me.btnCancelCity.Location = New System.Drawing.Point(103, 74)
        Me.btnCancelCity.Name = "btnCancelCity"
        Me.btnCancelCity.Size = New System.Drawing.Size(53, 22)
        Me.btnCancelCity.TabIndex = 4
        Me.btnCancelCity.Text = "فسخ"
        Me.btnCancelCity.UseVisualStyleBackColor = False
        Me.btnCancelCity.Visible = False
        '
        'btnAddCity
        '
        Me.btnAddCity.BackColor = System.Drawing.Color.Transparent
        Me.btnAddCity.Enabled = False
        Me.btnAddCity.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAddCity.ForeColor = System.Drawing.Color.White
        Me.btnAddCity.Location = New System.Drawing.Point(162, 75)
        Me.btnAddCity.Name = "btnAddCity"
        Me.btnAddCity.Size = New System.Drawing.Size(44, 22)
        Me.btnAddCity.TabIndex = 3
        Me.btnAddCity.Text = "جدید"
        Me.btnAddCity.UseVisualStyleBackColor = False
        '
        'cmbCity
        '
        Me.cmbCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCity.Enabled = False
        Me.cmbCity.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbCity.FormattingEnabled = True
        Me.cmbCity.Location = New System.Drawing.Point(260, 76)
        Me.cmbCity.Name = "cmbCity"
        Me.cmbCity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbCity.Size = New System.Drawing.Size(149, 21)
        Me.cmbCity.TabIndex = 1
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.GreenYellow
        Me.lblMessage.Location = New System.Drawing.Point(203, 327)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblMessage.Size = New System.Drawing.Size(25, 22)
        Me.lblMessage.TabIndex = 305
        Me.lblMessage.Text = "..."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(467, 183)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 251
        Me.Label7.Text = "شماره تلیفون"
        Me.ToolTip1.SetToolTip(Me.Label7, "Telephone No.")
        '
        'txtphone
        '
        Me.txtphone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtphone.Location = New System.Drawing.Point(183, 182)
        Me.txtphone.Name = "txtphone"
        Me.txtphone.ReadOnly = True
        Me.txtphone.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtphone.Size = New System.Drawing.Size(226, 21)
        Me.txtphone.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(418, 161)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 13)
        Me.Label2.TabIndex = 249
        Me.Label2.Text = "اسم دوکاندار  یا  مسئول"
        Me.ToolTip1.SetToolTip(Me.Label2, "Concern Person Name")
        '
        'txtConcernName
        '
        Me.txtConcernName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConcernName.Location = New System.Drawing.Point(183, 156)
        Me.txtConcernName.Name = "txtConcernName"
        Me.txtConcernName.ReadOnly = True
        Me.txtConcernName.Size = New System.Drawing.Size(226, 21)
        Me.txtConcernName.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(468, 266)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "آدرس"
        Me.ToolTip1.SetToolTip(Me.Label9, "Postal Address")
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.ForeColor = System.Drawing.Color.White
        Me.label6.Location = New System.Drawing.Point(471, 236)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(65, 13)
        Me.label6.TabIndex = 14
        Me.label6.Text = "شماره فکس"
        Me.ToolTip1.SetToolTip(Me.label6, "Fax No.")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(468, 208)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "شماره موبائل"
        Me.ToolTip1.SetToolTip(Me.Label5, "Mobile No.")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(479, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "اسم دوکان"
        Me.ToolTip1.SetToolTip(Me.Label4, "Shop Name ")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(488, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "تاریخ ثبت"
        Me.ToolTip1.SetToolTip(Me.Label3, "Entry Date")
        '
        'dtDate
        '
        Me.dtDate.CustomFormat = "dd/MM/yyyy"
        Me.dtDate.Enabled = False
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtDate.Location = New System.Drawing.Point(284, 49)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.Size = New System.Drawing.Size(125, 21)
        Me.dtDate.TabIndex = 0
        '
        'txtAddress
        '
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress.Location = New System.Drawing.Point(49, 263)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.ReadOnly = True
        Me.txtAddress.Size = New System.Drawing.Size(360, 55)
        Me.txtAddress.TabIndex = 14
        '
        'txtFax
        '
        Me.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFax.Location = New System.Drawing.Point(183, 236)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.ReadOnly = True
        Me.txtFax.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFax.Size = New System.Drawing.Size(226, 21)
        Me.txtFax.TabIndex = 13
        '
        'txtCell
        '
        Me.txtCell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCell.Location = New System.Drawing.Point(183, 209)
        Me.txtCell.Name = "txtCell"
        Me.txtCell.ReadOnly = True
        Me.txtCell.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCell.Size = New System.Drawing.Size(226, 21)
        Me.txtCell.TabIndex = 12
        '
        'txtShopName
        '
        Me.txtShopName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShopName.Location = New System.Drawing.Point(183, 130)
        Me.txtShopName.Name = "txtShopName"
        Me.txtShopName.ReadOnly = True
        Me.txtShopName.Size = New System.Drawing.Size(226, 21)
        Me.txtShopName.TabIndex = 9
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(49, 31)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(66, 21)
        Me.txtID.TabIndex = 3
        Me.txtID.Visible = False
        '
        'TP2
        '
        Me.TP2.BackColor = System.Drawing.Color.Teal
        Me.TP2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TP2.Controls.Add(Me.DGSearch)
        Me.TP2.Controls.Add(Me.GBSearch)
        Me.TP2.Location = New System.Drawing.Point(4, 22)
        Me.TP2.Name = "TP2"
        Me.TP2.Size = New System.Drawing.Size(578, 357)
        Me.TP2.TabIndex = 1
        Me.TP2.Text = "جستجو"
        '
        'DGSearch
        '
        Me.DGSearch.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGSearch.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGSearch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SAddress, Me.SType, Me.STel, Me.SLoc, Me.SCName, Me.SName, Me.SNo})
        Me.DGSearch.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DGSearch.Location = New System.Drawing.Point(0, 53)
        Me.DGSearch.Name = "DGSearch"
        Me.DGSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DGSearch.Size = New System.Drawing.Size(578, 304)
        Me.DGSearch.TabIndex = 6
        '
        'GBSearch
        '
        Me.GBSearch.Controls.Add(Me.chbSingle)
        Me.GBSearch.Controls.Add(Me.CmbShop)
        Me.GBSearch.Controls.Add(Me.btnSearch)
        Me.GBSearch.Controls.Add(Me.Label11)
        Me.GBSearch.Location = New System.Drawing.Point(3, 3)
        Me.GBSearch.Name = "GBSearch"
        Me.GBSearch.Size = New System.Drawing.Size(572, 44)
        Me.GBSearch.TabIndex = 1
        Me.GBSearch.TabStop = False
        '
        'chbSingle
        '
        Me.chbSingle.AutoSize = True
        Me.chbSingle.ForeColor = System.Drawing.Color.White
        Me.chbSingle.Location = New System.Drawing.Point(456, 18)
        Me.chbSingle.Name = "chbSingle"
        Me.chbSingle.Size = New System.Drawing.Size(91, 17)
        Me.chbSingle.TabIndex = 7
        Me.chbSingle.Text = "انتخاب جداگانه"
        Me.chbSingle.UseVisualStyleBackColor = True
        '
        'CmbShop
        '
        Me.CmbShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbShop.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmbShop.FormattingEnabled = True
        Me.CmbShop.Location = New System.Drawing.Point(138, 14)
        Me.CmbShop.Name = "CmbShop"
        Me.CmbShop.Size = New System.Drawing.Size(225, 21)
        Me.CmbShop.TabIndex = 2
        '
        'btnSearch
        '
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(42, 12)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(90, 23)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "جستجو"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(369, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "اسم دوکان"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AllowItemReorder = True
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripButton4, Me.ToolStripButton5, Me.ToolStripButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(59, 524)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip1.Size = New System.Drawing.Size(584, 23)
        Me.ToolStrip1.TabIndex = 247
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton2.Size = New System.Drawing.Size(59, 20)
        Me.ToolStripButton2.Text = "نخست"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton4.Size = New System.Drawing.Size(51, 20)
        Me.ToolStripButton4.Text = "قبلی"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton5.Size = New System.Drawing.Size(53, 20)
        Me.ToolStripButton5.Text = "نهایی"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton3.Size = New System.Drawing.Size(52, 20)
        Me.ToolStripButton3.Text = "بعدی"
        '
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'CM
        '
        Me.CM.BackColor = System.Drawing.Color.White
        Me.CM.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSAdd, Me.TSSave, Me.TSUndo, Me.TSUpdate, Me.TSDelete, Me.TSClose})
        Me.CM.Name = "CM"
        Me.CM.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.CM.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CM.Size = New System.Drawing.Size(139, 136)
        '
        'TSAdd
        '
        Me.TSAdd.BackColor = System.Drawing.Color.Transparent
        Me.TSAdd.ForeColor = System.Drawing.SystemColors.MenuText
        Me.TSAdd.Image = CType(resources.GetObject("TSAdd.Image"), System.Drawing.Image)
        Me.TSAdd.Name = "TSAdd"
        Me.TSAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TSAdd.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys)
        Me.TSAdd.Size = New System.Drawing.Size(138, 22)
        Me.TSAdd.Text = "&علاوه"
        Me.TSAdd.ToolTipText = "Add new Recod"
        '
        'TSSave
        '
        Me.TSSave.BackColor = System.Drawing.Color.Transparent
        Me.TSSave.Enabled = False
        Me.TSSave.ForeColor = System.Drawing.SystemColors.MenuText
        Me.TSSave.Image = CType(resources.GetObject("TSSave.Image"), System.Drawing.Image)
        Me.TSSave.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TSSave.Name = "TSSave"
        Me.TSSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TSSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.TSSave.Size = New System.Drawing.Size(138, 22)
        Me.TSSave.Text = "&ثبت"
        Me.TSSave.ToolTipText = "Save the Record"
        '
        'TSUndo
        '
        Me.TSUndo.BackColor = System.Drawing.Color.Transparent
        Me.TSUndo.Enabled = False
        Me.TSUndo.ForeColor = System.Drawing.SystemColors.MenuText
        Me.TSUndo.Image = CType(resources.GetObject("TSUndo.Image"), System.Drawing.Image)
        Me.TSUndo.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TSUndo.Name = "TSUndo"
        Me.TSUndo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TSUndo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.TSUndo.Size = New System.Drawing.Size(138, 22)
        Me.TSUndo.Text = "&خنثی"
        Me.TSUndo.ToolTipText = "Go one Step Back"
        '
        'TSUpdate
        '
        Me.TSUpdate.BackColor = System.Drawing.Color.Transparent
        Me.TSUpdate.ForeColor = System.Drawing.SystemColors.MenuText
        Me.TSUpdate.Image = CType(resources.GetObject("TSUpdate.Image"), System.Drawing.Image)
        Me.TSUpdate.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TSUpdate.Name = "TSUpdate"
        Me.TSUpdate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TSUpdate.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.J), System.Windows.Forms.Keys)
        Me.TSUpdate.Size = New System.Drawing.Size(138, 22)
        Me.TSUpdate.Text = "&تغیر"
        Me.TSUpdate.ToolTipText = "Update the Record"
        '
        'TSDelete
        '
        Me.TSDelete.BackColor = System.Drawing.Color.Transparent
        Me.TSDelete.ForeColor = System.Drawing.SystemColors.MenuText
        Me.TSDelete.Image = CType(resources.GetObject("TSDelete.Image"), System.Drawing.Image)
        Me.TSDelete.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TSDelete.Name = "TSDelete"
        Me.TSDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TSDelete.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.TSDelete.Size = New System.Drawing.Size(138, 22)
        Me.TSDelete.Text = "&حذف"
        Me.TSDelete.ToolTipText = "Delete the Record"
        '
        'TSClose
        '
        Me.TSClose.BackColor = System.Drawing.Color.Transparent
        Me.TSClose.ForeColor = System.Drawing.SystemColors.MenuText
        Me.TSClose.Image = CType(resources.GetObject("TSClose.Image"), System.Drawing.Image)
        Me.TSClose.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TSClose.Name = "TSClose"
        Me.TSClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TSClose.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.TSClose.Size = New System.Drawing.Size(138, 22)
        Me.TSClose.Text = "&خروج"
        Me.TSClose.ToolTipText = "Close the Form"
        '
        'SAddress
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.SAddress.DefaultCellStyle = DataGridViewCellStyle2
        Me.SAddress.HeaderText = "آدرس"
        Me.SAddress.Name = "SAddress"
        Me.SAddress.Width = 200
        '
        'SType
        '
        Me.SType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.SType.DefaultCellStyle = DataGridViewCellStyle3
        Me.SType.HeaderText = "نوع فروش"
        Me.SType.Name = "SType"
        '
        'STel
        '
        Me.STel.HeaderText = "نمبر تلیفون"
        Me.STel.Name = "STel"
        '
        'SLoc
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.SLoc.DefaultCellStyle = DataGridViewCellStyle4
        Me.SLoc.HeaderText = "موقیعت"
        Me.SLoc.Name = "SLoc"
        '
        'SCName
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.SCName.DefaultCellStyle = DataGridViewCellStyle5
        Me.SCName.HeaderText = "اسم مسئول"
        Me.SCName.Name = "SCName"
        '
        'SName
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.SName.DefaultCellStyle = DataGridViewCellStyle6
        Me.SName.HeaderText = "اسم دوکان"
        Me.SName.Name = "SName"
        '
        'SNo
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.SNo.DefaultCellStyle = DataGridViewCellStyle7
        Me.SNo.HeaderText = "شماره"
        Me.SNo.Name = "SNo"
        '
        'frmShopSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(695, 562)
        Me.ContextMenuStrip = Me.CM
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.TC)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmShopSetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmShopSetup"
        Me.TC.ResumeLayout(False)
        Me.TP1.ResumeLayout(False)
        Me.TP1.PerformLayout()
        Me.TP2.ResumeLayout(False)
        CType(Me.DGSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBSearch.ResumeLayout(False)
        Me.GBSearch.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.CM.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TC As System.Windows.Forms.TabControl
    Friend WithEvents TP1 As System.Windows.Forms.TabPage
    Friend WithEvents dtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents txtCell As System.Windows.Forms.TextBox
    Friend WithEvents txtShopName As System.Windows.Forms.TextBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents CM As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TSAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSUpdate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtphone As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtConcernName As System.Windows.Forms.TextBox
    Friend WithEvents TP2 As System.Windows.Forms.TabPage
    Friend WithEvents GBSearch As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DGSearch As System.Windows.Forms.DataGridView
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents LLSaleTypeList As System.Windows.Forms.LinkLabel
    Friend WithEvents lbSTypeID As System.Windows.Forms.Label
    Friend WithEvents btnAddStype As System.Windows.Forms.Button
    Friend WithEvents btnCancelStype As System.Windows.Forms.Button
    Friend WithEvents cmbSType As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LLCityList As System.Windows.Forms.LinkLabel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnCancelCity As System.Windows.Forms.Button
    Friend WithEvents btnAddCity As System.Windows.Forms.Button
    Friend WithEvents cmbCity As System.Windows.Forms.ComboBox
    Friend WithEvents lblLocID As System.Windows.Forms.Label
    Friend WithEvents CmbShop As System.Windows.Forms.ComboBox
    Friend WithEvents chbSingle As System.Windows.Forms.CheckBox
    Friend WithEvents SAddress As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SLoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SCName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SNo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
