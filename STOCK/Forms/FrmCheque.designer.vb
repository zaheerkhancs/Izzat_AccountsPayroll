<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCheque
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCheque))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label14 = New System.Windows.Forms.Label
        Me.pnlcentre = New System.Windows.Forms.Panel
        Me.btnPrint = New System.Windows.Forms.Button
        Me.TB1 = New System.Windows.Forms.TabControl
        Me.TP1 = New System.Windows.Forms.TabPage
        Me.txtCurrentProdAmount = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtGodownPhoneNo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbOrderNo = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblMessage = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TSFirst = New System.Windows.Forms.ToolStripButton
        Me.TSPrevious = New System.Windows.Forms.ToolStripButton
        Me.TSLast = New System.Windows.Forms.ToolStripButton
        Me.TSNext = New System.Windows.Forms.ToolStripButton
        Me.cmbCustomerName = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbGodownName = New System.Windows.Forms.ComboBox
        Me.txtGodownAddress = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmbInvoiceNo = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.DG = New System.Windows.Forms.DataGridView
        Me.DGSno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGPType = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DGProductCode = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DGCrtnPcs = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DGQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGDescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtGodownKeeper = New System.Windows.Forms.TextBox
        Me.txtChequeNo = New System.Windows.Forms.TextBox
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.dtChkDate = New System.Windows.Forms.DateTimePicker
        Me.CM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuNew = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSave = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUndo = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.pnlcentre.SuspendLayout()
        Me.TB1.SuspendLayout()
        Me.TP1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CM.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(276, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(257, 34)
        Me.Label14.TabIndex = 247
        Me.Label14.Text = "صفحه چک برای سرایدار"
        '
        'pnlcentre
        '
        Me.pnlcentre.Controls.Add(Me.btnPrint)
        Me.pnlcentre.Controls.Add(Me.TB1)
        Me.pnlcentre.Controls.Add(Me.Label14)
        Me.pnlcentre.Location = New System.Drawing.Point(27, 12)
        Me.pnlcentre.Name = "pnlcentre"
        Me.pnlcentre.Size = New System.Drawing.Size(729, 579)
        Me.pnlcentre.TabIndex = 1
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImage = CType(resources.GetObject("btnPrint.BackgroundImage"), System.Drawing.Image)
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(24, 17)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(87, 45)
        Me.btnPrint.TabIndex = 252
        Me.btnPrint.Text = " پرنت"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'TB1
        '
        Me.TB1.Controls.Add(Me.TP1)
        Me.TB1.Location = New System.Drawing.Point(20, 89)
        Me.TB1.Name = "TB1"
        Me.TB1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TB1.RightToLeftLayout = True
        Me.TB1.SelectedIndex = 0
        Me.TB1.Size = New System.Drawing.Size(677, 488)
        Me.TB1.TabIndex = 248
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.Teal
        Me.TP1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TP1.Controls.Add(Me.txtCurrentProdAmount)
        Me.TP1.Controls.Add(Me.Label5)
        Me.TP1.Controls.Add(Me.txtGodownPhoneNo)
        Me.TP1.Controls.Add(Me.Label4)
        Me.TP1.Controls.Add(Me.cmbOrderNo)
        Me.TP1.Controls.Add(Me.Label1)
        Me.TP1.Controls.Add(Me.lblMessage)
        Me.TP1.Controls.Add(Me.ToolStrip1)
        Me.TP1.Controls.Add(Me.cmbCustomerName)
        Me.TP1.Controls.Add(Me.Label3)
        Me.TP1.Controls.Add(Me.cmbGodownName)
        Me.TP1.Controls.Add(Me.txtGodownAddress)
        Me.TP1.Controls.Add(Me.Label13)
        Me.TP1.Controls.Add(Me.cmbInvoiceNo)
        Me.TP1.Controls.Add(Me.Label2)
        Me.TP1.Controls.Add(Me.DG)
        Me.TP1.Controls.Add(Me.Label6)
        Me.TP1.Controls.Add(Me.txtGodownKeeper)
        Me.TP1.Controls.Add(Me.txtChequeNo)
        Me.TP1.Controls.Add(Me.txtRemarks)
        Me.TP1.Controls.Add(Me.Label8)
        Me.TP1.Controls.Add(Me.Label9)
        Me.TP1.Controls.Add(Me.Label10)
        Me.TP1.Controls.Add(Me.Label12)
        Me.TP1.Controls.Add(Me.dtChkDate)
        Me.TP1.ForeColor = System.Drawing.Color.White
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Name = "TP1"
        Me.TP1.Padding = New System.Windows.Forms.Padding(3)
        Me.TP1.Size = New System.Drawing.Size(669, 462)
        Me.TP1.TabIndex = 0
        Me.TP1.Text = "بخش معلومات اساسی"
        '
        'txtCurrentProdAmount
        '
        Me.txtCurrentProdAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCurrentProdAmount.Enabled = False
        Me.txtCurrentProdAmount.Location = New System.Drawing.Point(7, 213)
        Me.txtCurrentProdAmount.Name = "txtCurrentProdAmount"
        Me.txtCurrentProdAmount.ReadOnly = True
        Me.txtCurrentProdAmount.Size = New System.Drawing.Size(197, 20)
        Me.txtCurrentProdAmount.TabIndex = 295
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(222, 213)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 16)
        Me.Label5.TabIndex = 294
        Me.Label5.Text = "مقدار موجود"
        '
        'txtGodownPhoneNo
        '
        Me.txtGodownPhoneNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGodownPhoneNo.Enabled = False
        Me.txtGodownPhoneNo.Location = New System.Drawing.Point(6, 80)
        Me.txtGodownPhoneNo.Name = "txtGodownPhoneNo"
        Me.txtGodownPhoneNo.Size = New System.Drawing.Size(198, 20)
        Me.txtGodownPhoneNo.TabIndex = 293
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(211, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 16)
        Me.Label4.TabIndex = 292
        Me.Label4.Text = "شمارهُ تیلیفون"
        '
        'cmbOrderNo
        '
        Me.cmbOrderNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbOrderNo.Enabled = False
        Me.cmbOrderNo.FormattingEnabled = True
        Me.cmbOrderNo.Location = New System.Drawing.Point(303, 81)
        Me.cmbOrderNo.Name = "cmbOrderNo"
        Me.cmbOrderNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbOrderNo.Size = New System.Drawing.Size(198, 21)
        Me.cmbOrderNo.TabIndex = 291
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(559, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 290
        Me.Label1.Text = "شمارهُ آردر خریدار"
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.GreenYellow
        Me.lblMessage.Location = New System.Drawing.Point(237, 174)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblMessage.Size = New System.Drawing.Size(19, 13)
        Me.lblMessage.TabIndex = 289
        Me.lblMessage.Text = "..."
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AllowItemReorder = True
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSFirst, Me.TSPrevious, Me.TSLast, Me.TSNext})
        Me.ToolStrip1.Location = New System.Drawing.Point(33, 179)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip1.Size = New System.Drawing.Size(603, 23)
        Me.ToolStrip1.TabIndex = 288
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TSFirst
        '
        Me.TSFirst.ForeColor = System.Drawing.Color.White
        Me.TSFirst.Image = CType(resources.GetObject("TSFirst.Image"), System.Drawing.Image)
        Me.TSFirst.Name = "TSFirst"
        Me.TSFirst.RightToLeftAutoMirrorImage = True
        Me.TSFirst.Size = New System.Drawing.Size(59, 20)
        Me.TSFirst.Text = "نخست"
        '
        'TSPrevious
        '
        Me.TSPrevious.ForeColor = System.Drawing.Color.White
        Me.TSPrevious.Image = CType(resources.GetObject("TSPrevious.Image"), System.Drawing.Image)
        Me.TSPrevious.Name = "TSPrevious"
        Me.TSPrevious.RightToLeftAutoMirrorImage = True
        Me.TSPrevious.Size = New System.Drawing.Size(51, 20)
        Me.TSPrevious.Text = "قبلی"
        '
        'TSLast
        '
        Me.TSLast.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TSLast.ForeColor = System.Drawing.Color.White
        Me.TSLast.Image = CType(resources.GetObject("TSLast.Image"), System.Drawing.Image)
        Me.TSLast.Name = "TSLast"
        Me.TSLast.RightToLeftAutoMirrorImage = True
        Me.TSLast.Size = New System.Drawing.Size(53, 20)
        Me.TSLast.Text = "نهایی"
        '
        'TSNext
        '
        Me.TSNext.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TSNext.ForeColor = System.Drawing.Color.White
        Me.TSNext.Image = CType(resources.GetObject("TSNext.Image"), System.Drawing.Image)
        Me.TSNext.Name = "TSNext"
        Me.TSNext.RightToLeftAutoMirrorImage = True
        Me.TSNext.Size = New System.Drawing.Size(52, 20)
        Me.TSNext.Text = "بعدی"
        '
        'cmbCustomerName
        '
        Me.cmbCustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbCustomerName.Enabled = False
        Me.cmbCustomerName.FormattingEnabled = True
        Me.cmbCustomerName.Location = New System.Drawing.Point(5, 8)
        Me.cmbCustomerName.Name = "cmbCustomerName"
        Me.cmbCustomerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbCustomerName.Size = New System.Drawing.Size(198, 21)
        Me.cmbCustomerName.TabIndex = 273
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(217, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 16)
        Me.Label3.TabIndex = 272
        Me.Label3.Text = " اسم مشتری"
        '
        'cmbGodownName
        '
        Me.cmbGodownName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbGodownName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbGodownName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGodownName.Enabled = False
        Me.cmbGodownName.FormattingEnabled = True
        Me.cmbGodownName.Location = New System.Drawing.Point(6, 33)
        Me.cmbGodownName.Name = "cmbGodownName"
        Me.cmbGodownName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbGodownName.Size = New System.Drawing.Size(198, 21)
        Me.cmbGodownName.TabIndex = 271
        '
        'txtGodownAddress
        '
        Me.txtGodownAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGodownAddress.Enabled = False
        Me.txtGodownAddress.Location = New System.Drawing.Point(7, 102)
        Me.txtGodownAddress.Multiline = True
        Me.txtGodownAddress.Name = "txtGodownAddress"
        Me.txtGodownAddress.Size = New System.Drawing.Size(198, 74)
        Me.txtGodownAddress.TabIndex = 270
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(225, 108)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 16)
        Me.Label13.TabIndex = 269
        Me.Label13.Text = "آدرس سرای"
        '
        'cmbInvoiceNo
        '
        Me.cmbInvoiceNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbInvoiceNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbInvoiceNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInvoiceNo.Enabled = False
        Me.cmbInvoiceNo.FormattingEnabled = True
        Me.cmbInvoiceNo.Location = New System.Drawing.Point(303, 56)
        Me.cmbInvoiceNo.Name = "cmbInvoiceNo"
        Me.cmbInvoiceNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbInvoiceNo.Size = New System.Drawing.Size(198, 21)
        Me.cmbInvoiceNo.TabIndex = 267
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(603, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 16)
        Me.Label2.TabIndex = 261
        Me.Label2.Text = "تاریخ چک"
        '
        'DG
        '
        Me.DG.AllowUserToAddRows = False
        Me.DG.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGSno, Me.DGPType, Me.DGProductCode, Me.DGCrtnPcs, Me.DGQty, Me.DGDescription})
        Me.DG.Location = New System.Drawing.Point(3, 239)
        Me.DG.Name = "DG"
        Me.DG.Size = New System.Drawing.Size(663, 222)
        Me.DG.TabIndex = 258
        '
        'DGSno
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.DGSno.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGSno.HeaderText = "شماره"
        Me.DGSno.Name = "DGSno"
        Me.DGSno.ReadOnly = True
        Me.DGSno.Width = 60
        '
        'DGPType
        '
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.DGPType.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGPType.HeaderText = "نوع محصول"
        Me.DGPType.Name = "DGPType"
        Me.DGPType.ReadOnly = True
        Me.DGPType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGPType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DGPType.Width = 200
        '
        'DGProductCode
        '
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.DGProductCode.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGProductCode.HeaderText = "اسم محصول"
        Me.DGProductCode.Name = "DGProductCode"
        Me.DGProductCode.ReadOnly = True
        Me.DGProductCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGProductCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DGProductCode.Width = 210
        '
        'DGCrtnPcs
        '
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DGCrtnPcs.DefaultCellStyle = DataGridViewCellStyle5
        Me.DGCrtnPcs.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.DGCrtnPcs.HeaderText = "کارتن/دانه"
        Me.DGCrtnPcs.Name = "DGCrtnPcs"
        Me.DGCrtnPcs.ReadOnly = True
        Me.DGCrtnPcs.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGCrtnPcs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DGQty
        '
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.DGQty.DefaultCellStyle = DataGridViewCellStyle6
        Me.DGQty.HeaderText = "مقدار"
        Me.DGQty.Name = "DGQty"
        '
        'DGDescription
        '
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        Me.DGDescription.DefaultCellStyle = DataGridViewCellStyle7
        Me.DGDescription.HeaderText = "تفصیل"
        Me.DGDescription.Name = "DGDescription"
        Me.DGDescription.Width = 250
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(500, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(166, 16)
        Me.Label6.TabIndex = 249
        Me.Label6.Text = "شمارهُ درج (انوایس) خریداری"
        '
        'txtGodownKeeper
        '
        Me.txtGodownKeeper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGodownKeeper.Enabled = False
        Me.txtGodownKeeper.Location = New System.Drawing.Point(6, 57)
        Me.txtGodownKeeper.Name = "txtGodownKeeper"
        Me.txtGodownKeeper.Size = New System.Drawing.Size(198, 20)
        Me.txtGodownKeeper.TabIndex = 247
        '
        'txtChequeNo
        '
        Me.txtChequeNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChequeNo.Enabled = False
        Me.txtChequeNo.Location = New System.Drawing.Point(303, 9)
        Me.txtChequeNo.Name = "txtChequeNo"
        Me.txtChequeNo.Size = New System.Drawing.Size(198, 20)
        Me.txtChequeNo.TabIndex = 246
        '
        'txtRemarks
        '
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Enabled = False
        Me.txtRemarks.Location = New System.Drawing.Point(303, 106)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(198, 53)
        Me.txtRemarks.TabIndex = 23
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(614, 111)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 16)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "ملاحظه"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(211, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 16)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "اسم سرای دار"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(228, 38)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 16)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "اسم سرای"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(593, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 16)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "شماره چک"
        '
        'dtChkDate
        '
        Me.dtChkDate.CustomFormat = "dd/MM/yy"
        Me.dtChkDate.Enabled = False
        Me.dtChkDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtChkDate.Location = New System.Drawing.Point(303, 32)
        Me.dtChkDate.Name = "dtChkDate"
        Me.dtChkDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtChkDate.Size = New System.Drawing.Size(198, 20)
        Me.dtChkDate.TabIndex = 3
        '
        'CM
        '
        Me.CM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CM.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuNew, Me.MnuSave, Me.MnuDelete, Me.MnuUndo, Me.MnuExit})
        Me.CM.Name = "ContextMenuStrip1"
        Me.CM.Size = New System.Drawing.Size(139, 114)
        '
        'MnuNew
        '
        Me.MnuNew.BackColor = System.Drawing.Color.White
        Me.MnuNew.Image = CType(resources.GetObject("MnuNew.Image"), System.Drawing.Image)
        Me.MnuNew.ImageTransparentColor = System.Drawing.Color.Black
        Me.MnuNew.Name = "MnuNew"
        Me.MnuNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys)
        Me.MnuNew.Size = New System.Drawing.Size(138, 22)
        Me.MnuNew.Text = "&علاوه"
        '
        'MnuSave
        '
        Me.MnuSave.BackColor = System.Drawing.Color.White
        Me.MnuSave.Enabled = False
        Me.MnuSave.Image = CType(resources.GetObject("MnuSave.Image"), System.Drawing.Image)
        Me.MnuSave.ImageTransparentColor = System.Drawing.Color.Black
        Me.MnuSave.Name = "MnuSave"
        Me.MnuSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.MnuSave.Size = New System.Drawing.Size(138, 22)
        Me.MnuSave.Text = "&ثبت"
        '
        'MnuDelete
        '
        Me.MnuDelete.BackColor = System.Drawing.Color.White
        Me.MnuDelete.Image = CType(resources.GetObject("MnuDelete.Image"), System.Drawing.Image)
        Me.MnuDelete.Name = "MnuDelete"
        Me.MnuDelete.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.MnuDelete.Size = New System.Drawing.Size(138, 22)
        Me.MnuDelete.Text = "&حذف"
        '
        'MnuUndo
        '
        Me.MnuUndo.BackColor = System.Drawing.Color.White
        Me.MnuUndo.Enabled = False
        Me.MnuUndo.Image = CType(resources.GetObject("MnuUndo.Image"), System.Drawing.Image)
        Me.MnuUndo.ImageTransparentColor = System.Drawing.Color.Black
        Me.MnuUndo.Name = "MnuUndo"
        Me.MnuUndo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.MnuUndo.Size = New System.Drawing.Size(138, 22)
        Me.MnuUndo.Text = "خنثی"
        '
        'MnuExit
        '
        Me.MnuExit.BackColor = System.Drawing.Color.White
        Me.MnuExit.Name = "MnuExit"
        Me.MnuExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.MnuExit.Size = New System.Drawing.Size(138, 22)
        Me.MnuExit.Text = "&خروج"
        '
        'FrmCheque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(755, 603)
        Me.ContextMenuStrip = Me.CM
        Me.Controls.Add(Me.pnlcentre)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmCheque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmCheque"
        Me.pnlcentre.ResumeLayout(False)
        Me.pnlcentre.PerformLayout()
        Me.TB1.ResumeLayout(False)
        Me.TP1.ResumeLayout(False)
        Me.TP1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CM.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents pnlcentre As System.Windows.Forms.Panel
    Friend WithEvents TB1 As System.Windows.Forms.TabControl
    Friend WithEvents TP1 As System.Windows.Forms.TabPage
    Friend WithEvents cmbCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbGodownName As System.Windows.Forms.ComboBox
    Friend WithEvents txtGodownAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbInvoiceNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtGodownKeeper As System.Windows.Forms.TextBox
    Friend WithEvents txtChequeNo As System.Windows.Forms.TextBox
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtChkDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents CM As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MnuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSPrevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbOrderNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtGodownPhoneNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents txtCurrentProdAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DGSno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGPType As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGProductCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGCrtnPcs As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGDescription As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
