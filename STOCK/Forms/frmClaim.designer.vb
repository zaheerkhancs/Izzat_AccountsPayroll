<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClaim
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClaim))
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pnlcentre = New System.Windows.Forms.Panel
        Me.btnPrint = New System.Windows.Forms.Button
        Me.TC = New System.Windows.Forms.TabControl
        Me.TP1 = New System.Windows.Forms.TabPage
        Me.btnPayment = New System.Windows.Forms.Button
        Me.txtPaid = New System.Windows.Forms.TextBox
        Me.txtBalance = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtQtyTotal = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblMessage = New System.Windows.Forms.Label
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.cmbInvioceNo = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DG = New System.Windows.Forms.DataGridView
        Me.DGSNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGPType = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DGProductCode = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DGPcsInCrtn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGPricePerPcs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGPricePerCrtn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGCrtnPcs = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DGQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGBroken = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGLeak = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGShort = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGDent = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGExpired = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGDecayedBeforeExpiration = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGClaimQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGDescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmbCompanyName = New System.Windows.Forms.ComboBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.dtDate = New System.Windows.Forms.DateTimePicker
        Me.TP2 = New System.Windows.Forms.TabPage
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtTotalPcs = New System.Windows.Forms.TextBox
        Me.txtTotalCrtn = New System.Windows.Forms.TextBox
        Me.DGSearch = New System.Windows.Forms.DataGridView
        Me.DGSSNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGSPType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGSPName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGSQtyInCrtn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGSPricePerPcs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGSPricePerCrtn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGSCrtnPcs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGSBroken = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGSLeak = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGSShort = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGSDent = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGSExpired = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGSBeforeExpired = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGSTotalQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGSPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGSDescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbCompanySearch = New System.Windows.Forms.ComboBox
        Me.cmbInvoiceNoSearch = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.CM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuNew = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSave = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUndo = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.pnlcentre.SuspendLayout()
        Me.TC.SuspendLayout()
        Me.TP1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TP2.SuspendLayout()
        CType(Me.DGSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CM.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlcentre
        '
        Me.pnlcentre.Controls.Add(Me.btnPrint)
        Me.pnlcentre.Controls.Add(Me.TC)
        Me.pnlcentre.Controls.Add(Me.Label14)
        Me.pnlcentre.Location = New System.Drawing.Point(32, 38)
        Me.pnlcentre.Name = "pnlcentre"
        Me.pnlcentre.Size = New System.Drawing.Size(740, 577)
        Me.pnlcentre.TabIndex = 0
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImage = CType(resources.GetObject("btnPrint.BackgroundImage"), System.Drawing.Image)
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(23, 13)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnPrint.Size = New System.Drawing.Size(87, 45)
        Me.btnPrint.TabIndex = 300
        Me.btnPrint.Text = " پرنت"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'TC
        '
        Me.TC.Controls.Add(Me.TP1)
        Me.TC.Controls.Add(Me.TP2)
        Me.TC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TC.Location = New System.Drawing.Point(29, 86)
        Me.TC.Name = "TC"
        Me.TC.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TC.RightToLeftLayout = True
        Me.TC.SelectedIndex = 0
        Me.TC.Size = New System.Drawing.Size(685, 488)
        Me.TC.TabIndex = 299
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.Teal
        Me.TP1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TP1.Controls.Add(Me.btnPayment)
        Me.TP1.Controls.Add(Me.txtPaid)
        Me.TP1.Controls.Add(Me.txtBalance)
        Me.TP1.Controls.Add(Me.Label7)
        Me.TP1.Controls.Add(Me.Label5)
        Me.TP1.Controls.Add(Me.Label4)
        Me.TP1.Controls.Add(Me.txtQtyTotal)
        Me.TP1.Controls.Add(Me.Label2)
        Me.TP1.Controls.Add(Me.lblMessage)
        Me.TP1.Controls.Add(Me.txtTotal)
        Me.TP1.Controls.Add(Me.ToolStrip1)
        Me.TP1.Controls.Add(Me.cmbInvioceNo)
        Me.TP1.Controls.Add(Me.Label1)
        Me.TP1.Controls.Add(Me.DG)
        Me.TP1.Controls.Add(Me.txtRemarks)
        Me.TP1.Controls.Add(Me.Label11)
        Me.TP1.Controls.Add(Me.cmbCompanyName)
        Me.TP1.Controls.Add(Me.Label23)
        Me.TP1.Controls.Add(Me.Label6)
        Me.TP1.Controls.Add(Me.dtDate)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Name = "TP1"
        Me.TP1.Padding = New System.Windows.Forms.Padding(3)
        Me.TP1.Size = New System.Drawing.Size(677, 462)
        Me.TP1.TabIndex = 0
        Me.TP1.Text = "دعوی بالای مال فاسد شده "
        '
        'btnPayment
        '
        Me.btnPayment.BackColor = System.Drawing.Color.Transparent
        Me.btnPayment.Enabled = False
        Me.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPayment.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnPayment.ForeColor = System.Drawing.Color.White
        Me.btnPayment.Location = New System.Drawing.Point(17, 60)
        Me.btnPayment.Name = "btnPayment"
        Me.btnPayment.Size = New System.Drawing.Size(60, 23)
        Me.btnPayment.TabIndex = 311
        Me.btnPayment.Text = "پرداخت"
        Me.btnPayment.UseVisualStyleBackColor = False
        '
        'txtPaid
        '
        Me.txtPaid.Location = New System.Drawing.Point(90, 61)
        Me.txtPaid.Name = "txtPaid"
        Me.txtPaid.ReadOnly = True
        Me.txtPaid.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPaid.Size = New System.Drawing.Size(93, 21)
        Me.txtPaid.TabIndex = 309
        '
        'txtBalance
        '
        Me.txtBalance.Location = New System.Drawing.Point(17, 85)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBalance.Size = New System.Drawing.Size(165, 21)
        Me.txtBalance.TabIndex = 308
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(200, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(121, 16)
        Me.Label7.TabIndex = 307
        Me.Label7.Text = "مقدار  پذرداخته شده"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(207, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 16)
        Me.Label5.TabIndex = 306
        Me.Label5.Text = "مقدار پول قابل تادیه"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(283, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 16)
        Me.Label4.TabIndex = 305
        Me.Label4.Text = "میزان"
        '
        'txtQtyTotal
        '
        Me.txtQtyTotal.Location = New System.Drawing.Point(17, 109)
        Me.txtQtyTotal.Name = "txtQtyTotal"
        Me.txtQtyTotal.ReadOnly = True
        Me.txtQtyTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtQtyTotal.Size = New System.Drawing.Size(165, 21)
        Me.txtQtyTotal.TabIndex = 304
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(207, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 16)
        Me.Label2.TabIndex = 303
        Me.Label2.Text = "جمع کل مقدار مسترد شده"
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.GreenYellow
        Me.lblMessage.Location = New System.Drawing.Point(221, 425)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblMessage.Size = New System.Drawing.Size(19, 13)
        Me.lblMessage.TabIndex = 302
        Me.lblMessage.Text = "..."
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(17, 37)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTotal.Size = New System.Drawing.Size(165, 21)
        Me.txtTotal.TabIndex = 301
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AllowItemReorder = True
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripButton4, Me.ToolStripButton5, Me.ToolStripButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 431)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip1.Size = New System.Drawing.Size(669, 24)
        Me.ToolStrip1.TabIndex = 300
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton2.Size = New System.Drawing.Size(59, 21)
        Me.ToolStripButton2.Text = "نخست"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton4.Size = New System.Drawing.Size(51, 21)
        Me.ToolStripButton4.Text = "قبلی"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton5.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton5.Size = New System.Drawing.Size(53, 21)
        Me.ToolStripButton5.Text = "نهایی"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton3.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton3.Size = New System.Drawing.Size(52, 21)
        Me.ToolStripButton3.Text = "بعدی"
        '
        'cmbInvioceNo
        '
        Me.cmbInvioceNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbInvioceNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbInvioceNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInvioceNo.Enabled = False
        Me.cmbInvioceNo.FormattingEnabled = True
        Me.cmbInvioceNo.Location = New System.Drawing.Point(377, 36)
        Me.cmbInvioceNo.Name = "cmbInvioceNo"
        Me.cmbInvioceNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbInvioceNo.Size = New System.Drawing.Size(172, 21)
        Me.cmbInvioceNo.TabIndex = 296
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(569, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 16)
        Me.Label1.TabIndex = 295
        Me.Label1.Text = "انوایس خریداری"
        '
        'DG
        '
        Me.DG.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGSNo, Me.DGPType, Me.DGProductCode, Me.DGPcsInCrtn, Me.DGPricePerPcs, Me.DGPricePerCrtn, Me.DGCrtnPcs, Me.DGQty, Me.DGBroken, Me.DGLeak, Me.DGShort, Me.DGDent, Me.DGExpired, Me.DGDecayedBeforeExpiration, Me.DGClaimQty, Me.DGPrice, Me.DGDescription})
        Me.DG.Location = New System.Drawing.Point(17, 194)
        Me.DG.Name = "DG"
        Me.DG.ReadOnly = True
        Me.DG.Size = New System.Drawing.Size(651, 231)
        Me.DG.TabIndex = 293
        '
        'DGSNo
        '
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DGSNo.DefaultCellStyle = DataGridViewCellStyle7
        Me.DGSNo.HeaderText = "شماره"
        Me.DGSNo.Name = "DGSNo"
        Me.DGSNo.ReadOnly = True
        Me.DGSNo.Width = 60
        '
        'DGPType
        '
        Me.DGPType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.DGPType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.DGPType.HeaderText = "نوع محصول"
        Me.DGPType.Name = "DGPType"
        Me.DGPType.ReadOnly = True
        Me.DGPType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGPType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DGPType.Width = 130
        '
        'DGProductCode
        '
        Me.DGProductCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.DGProductCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.DGProductCode.HeaderText = "اسم محصول"
        Me.DGProductCode.Name = "DGProductCode"
        Me.DGProductCode.ReadOnly = True
        Me.DGProductCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGProductCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DGProductCode.Width = 130
        '
        'DGPcsInCrtn
        '
        Me.DGPcsInCrtn.HeaderText = "تعداد در فی کارتن"
        Me.DGPcsInCrtn.Name = "DGPcsInCrtn"
        Me.DGPcsInCrtn.ReadOnly = True
        '
        'DGPricePerPcs
        '
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.DGPricePerPcs.DefaultCellStyle = DataGridViewCellStyle8
        Me.DGPricePerPcs.HeaderText = "قیمت فی دانه"
        Me.DGPricePerPcs.Name = "DGPricePerPcs"
        Me.DGPricePerPcs.ReadOnly = True
        '
        'DGPricePerCrtn
        '
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.DGPricePerCrtn.DefaultCellStyle = DataGridViewCellStyle9
        Me.DGPricePerCrtn.HeaderText = "قیمت فی کارتن"
        Me.DGPricePerCrtn.Name = "DGPricePerCrtn"
        Me.DGPricePerCrtn.ReadOnly = True
        '
        'DGCrtnPcs
        '
        Me.DGCrtnPcs.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.DGCrtnPcs.HeaderText = "دانه/کارتن"
        Me.DGCrtnPcs.Name = "DGCrtnPcs"
        Me.DGCrtnPcs.ReadOnly = True
        '
        'DGQty
        '
        Me.DGQty.HeaderText = "مقدار"
        Me.DGQty.Name = "DGQty"
        Me.DGQty.ReadOnly = True
        Me.DGQty.Width = 60
        '
        'DGBroken
        '
        Me.DGBroken.HeaderText = "شکسته"
        Me.DGBroken.Name = "DGBroken"
        Me.DGBroken.ReadOnly = True
        '
        'DGLeak
        '
        Me.DGLeak.HeaderText = "لیک"
        Me.DGLeak.Name = "DGLeak"
        Me.DGLeak.ReadOnly = True
        '
        'DGShort
        '
        Me.DGShort.HeaderText = "کمبود"
        Me.DGShort.Name = "DGShort"
        Me.DGShort.ReadOnly = True
        '
        'DGDent
        '
        Me.DGDent.HeaderText = "ضربه خورده"
        Me.DGDent.Name = "DGDent"
        Me.DGDent.ReadOnly = True
        '
        'DGExpired
        '
        Me.DGExpired.HeaderText = "اکسپایر شده"
        Me.DGExpired.Name = "DGExpired"
        Me.DGExpired.ReadOnly = True
        '
        'DGDecayedBeforeExpiration
        '
        Me.DGDecayedBeforeExpiration.HeaderText = "قبل از  لکسپایری خراب شده"
        Me.DGDecayedBeforeExpiration.Name = "DGDecayedBeforeExpiration"
        Me.DGDecayedBeforeExpiration.ReadOnly = True
        '
        'DGClaimQty
        '
        Me.DGClaimQty.HeaderText = "مقدار مسترد شده"
        Me.DGClaimQty.Name = "DGClaimQty"
        Me.DGClaimQty.ReadOnly = True
        '
        'DGPrice
        '
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.DGPrice.DefaultCellStyle = DataGridViewCellStyle10
        Me.DGPrice.HeaderText = "قیمت"
        Me.DGPrice.Name = "DGPrice"
        Me.DGPrice.ReadOnly = True
        '
        'DGDescription
        '
        Me.DGDescription.HeaderText = "تفصیل"
        Me.DGDescription.Name = "DGDescription"
        Me.DGDescription.ReadOnly = True
        Me.DGDescription.Width = 200
        '
        'txtRemarks
        '
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Enabled = False
        Me.txtRemarks.Location = New System.Drawing.Point(17, 132)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(533, 56)
        Me.txtRemarks.TabIndex = 292
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(608, 133)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 16)
        Me.Label11.TabIndex = 291
        Me.Label11.Text = "ملاحظات"
        '
        'cmbCompanyName
        '
        Me.cmbCompanyName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCompanyName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCompanyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCompanyName.Enabled = False
        Me.cmbCompanyName.FormattingEnabled = True
        Me.cmbCompanyName.Location = New System.Drawing.Point(377, 12)
        Me.cmbCompanyName.Name = "cmbCompanyName"
        Me.cmbCompanyName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbCompanyName.Size = New System.Drawing.Size(173, 21)
        Me.cmbCompanyName.TabIndex = 289
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(592, 107)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(69, 16)
        Me.Label23.TabIndex = 287
        Me.Label23.Text = "تاریخ دعوی"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(617, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 16)
        Me.Label6.TabIndex = 284
        Me.Label6.Text = "کمپنی"
        '
        'dtDate
        '
        Me.dtDate.CustomFormat = "dd/MM/yy"
        Me.dtDate.Enabled = False
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtDate.Location = New System.Drawing.Point(377, 105)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtDate.RightToLeftLayout = True
        Me.dtDate.Size = New System.Drawing.Size(172, 21)
        Me.dtDate.TabIndex = 283
        '
        'TP2
        '
        Me.TP2.BackColor = System.Drawing.Color.Teal
        Me.TP2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TP2.Controls.Add(Me.Label10)
        Me.TP2.Controls.Add(Me.Label9)
        Me.TP2.Controls.Add(Me.txtTotalPcs)
        Me.TP2.Controls.Add(Me.txtTotalCrtn)
        Me.TP2.Controls.Add(Me.DGSearch)
        Me.TP2.Controls.Add(Me.btnSearch)
        Me.TP2.Controls.Add(Me.Label8)
        Me.TP2.Controls.Add(Me.Label3)
        Me.TP2.Controls.Add(Me.cmbCompanySearch)
        Me.TP2.Controls.Add(Me.cmbInvoiceNoSearch)
        Me.TP2.Location = New System.Drawing.Point(4, 22)
        Me.TP2.Name = "TP2"
        Me.TP2.Size = New System.Drawing.Size(677, 462)
        Me.TP2.TabIndex = 1
        Me.TP2.Text = "جستجو"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(542, 434)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 14)
        Me.Label10.TabIndex = 312
        Me.Label10.Text = "جمع کل(کارتن)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(545, 407)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 14)
        Me.Label9.TabIndex = 311
        Me.Label9.Text = "جمع کل (دانه)"
        '
        'txtTotalPcs
        '
        Me.txtTotalPcs.Location = New System.Drawing.Point(254, 405)
        Me.txtTotalPcs.Name = "txtTotalPcs"
        Me.txtTotalPcs.Size = New System.Drawing.Size(251, 21)
        Me.txtTotalPcs.TabIndex = 310
        '
        'txtTotalCrtn
        '
        Me.txtTotalCrtn.Location = New System.Drawing.Point(254, 432)
        Me.txtTotalCrtn.Name = "txtTotalCrtn"
        Me.txtTotalCrtn.Size = New System.Drawing.Size(251, 21)
        Me.txtTotalCrtn.TabIndex = 309
        '
        'DGSearch
        '
        Me.DGSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGSearch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGSSNO, Me.DGSPType, Me.DGSPName, Me.DGSQtyInCrtn, Me.DGSPricePerPcs, Me.DGSPricePerCrtn, Me.DGSCrtnPcs, Me.DGSBroken, Me.DGSLeak, Me.DGSShort, Me.DGSDent, Me.DGSExpired, Me.DGSBeforeExpired, Me.DGSTotalQty, Me.DGSPrice, Me.DGSDescription})
        Me.DGSearch.Location = New System.Drawing.Point(3, 92)
        Me.DGSearch.Name = "DGSearch"
        Me.DGSearch.Size = New System.Drawing.Size(671, 307)
        Me.DGSearch.TabIndex = 308
        '
        'DGSSNO
        '
        Me.DGSSNO.HeaderText = "شماره"
        Me.DGSSNO.Name = "DGSSNO"
        Me.DGSSNO.Width = 50
        '
        'DGSPType
        '
        Me.DGSPType.HeaderText = "نوع محصول"
        Me.DGSPType.Name = "DGSPType"
        Me.DGSPType.Width = 120
        '
        'DGSPName
        '
        Me.DGSPName.HeaderText = "اسم محصول"
        Me.DGSPName.Name = "DGSPName"
        Me.DGSPName.Width = 120
        '
        'DGSQtyInCrtn
        '
        Me.DGSQtyInCrtn.HeaderText = "تعداد در کارتن"
        Me.DGSQtyInCrtn.Name = "DGSQtyInCrtn"
        Me.DGSQtyInCrtn.Width = 70
        '
        'DGSPricePerPcs
        '
        Me.DGSPricePerPcs.HeaderText = "قیمت فی دانه"
        Me.DGSPricePerPcs.Name = "DGSPricePerPcs"
        Me.DGSPricePerPcs.Width = 70
        '
        'DGSPricePerCrtn
        '
        Me.DGSPricePerCrtn.HeaderText = "قیمت فی کارتن"
        Me.DGSPricePerCrtn.Name = "DGSPricePerCrtn"
        Me.DGSPricePerCrtn.Width = 70
        '
        'DGSCrtnPcs
        '
        Me.DGSCrtnPcs.HeaderText = "دانه / کارتن"
        Me.DGSCrtnPcs.Name = "DGSCrtnPcs"
        Me.DGSCrtnPcs.Width = 70
        '
        'DGSBroken
        '
        Me.DGSBroken.HeaderText = "شکسته"
        Me.DGSBroken.Name = "DGSBroken"
        Me.DGSBroken.Width = 70
        '
        'DGSLeak
        '
        Me.DGSLeak.HeaderText = "لیک"
        Me.DGSLeak.Name = "DGSLeak"
        Me.DGSLeak.Width = 70
        '
        'DGSShort
        '
        Me.DGSShort.HeaderText = "کمبود"
        Me.DGSShort.Name = "DGSShort"
        Me.DGSShort.Width = 70
        '
        'DGSDent
        '
        Me.DGSDent.HeaderText = "ضربه خورده"
        Me.DGSDent.Name = "DGSDent"
        Me.DGSDent.Width = 70
        '
        'DGSExpired
        '
        Me.DGSExpired.HeaderText = "اکسپایر شده"
        Me.DGSExpired.Name = "DGSExpired"
        Me.DGSExpired.Width = 70
        '
        'DGSBeforeExpired
        '
        Me.DGSBeforeExpired.HeaderText = "قبل از  لکسپایری خراب شده"
        Me.DGSBeforeExpired.Name = "DGSBeforeExpired"
        '
        'DGSTotalQty
        '
        Me.DGSTotalQty.HeaderText = "جمع کل"
        Me.DGSTotalQty.Name = "DGSTotalQty"
        '
        'DGSPrice
        '
        Me.DGSPrice.HeaderText = "قیمت"
        Me.DGSPrice.Name = "DGSPrice"
        '
        'DGSDescription
        '
        Me.DGSDescription.HeaderText = "تفصیل"
        Me.DGSDescription.Name = "DGSDescription"
        Me.DGSDescription.Width = 150
        '
        'btnSearch
        '
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnSearch.Location = New System.Drawing.Point(138, 35)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(87, 48)
        Me.btnSearch.TabIndex = 307
        Me.btnSearch.Text = "جستجو"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(529, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 14)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "انوایس خریداری"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(545, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 14)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "اسم کمپنی"
        '
        'cmbCompanySearch
        '
        Me.cmbCompanySearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCompanySearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCompanySearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbCompanySearch.FormattingEnabled = True
        Me.cmbCompanySearch.Location = New System.Drawing.Point(254, 35)
        Me.cmbCompanySearch.Name = "cmbCompanySearch"
        Me.cmbCompanySearch.Size = New System.Drawing.Size(251, 21)
        Me.cmbCompanySearch.TabIndex = 1
        '
        'cmbInvoiceNoSearch
        '
        Me.cmbInvoiceNoSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbInvoiceNoSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbInvoiceNoSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbInvoiceNoSearch.FormattingEnabled = True
        Me.cmbInvoiceNoSearch.Location = New System.Drawing.Point(254, 62)
        Me.cmbInvoiceNoSearch.Name = "cmbInvoiceNoSearch"
        Me.cmbInvoiceNoSearch.Size = New System.Drawing.Size(251, 21)
        Me.cmbInvoiceNoSearch.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(156, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(478, 34)
        Me.Label14.TabIndex = 298
        Me.Label14.Text = "صفحه دعوی بالای کمپنی ها برای مال فاسد شده"
        '
        'CM
        '
        Me.CM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CM.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuNew, Me.MnuSave, Me.MnuUndo, Me.MnuEdit, Me.MnuDelete, Me.MnuExit})
        Me.CM.Name = "ContextMenuStrip1"
        Me.CM.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CM.Size = New System.Drawing.Size(139, 136)
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
        'MnuEdit
        '
        Me.MnuEdit.BackColor = System.Drawing.Color.White
        Me.MnuEdit.Image = CType(resources.GetObject("MnuEdit.Image"), System.Drawing.Image)
        Me.MnuEdit.Name = "MnuEdit"
        Me.MnuEdit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.J), System.Windows.Forms.Keys)
        Me.MnuEdit.Size = New System.Drawing.Size(138, 22)
        Me.MnuEdit.Text = "&تغیر"
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
        'MnuExit
        '
        Me.MnuExit.BackColor = System.Drawing.Color.White
        Me.MnuExit.Name = "MnuExit"
        Me.MnuExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.MnuExit.Size = New System.Drawing.Size(138, 22)
        Me.MnuExit.Text = "&خروج"
        '
        'frmClaim
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(783, 636)
        Me.ContextMenuStrip = Me.CM
        Me.Controls.Add(Me.pnlcentre)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmClaim"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmClaim"
        Me.pnlcentre.ResumeLayout(False)
        Me.pnlcentre.PerformLayout()
        Me.TC.ResumeLayout(False)
        Me.TP1.ResumeLayout(False)
        Me.TP1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TP2.ResumeLayout(False)
        Me.TP2.PerformLayout()
        CType(Me.DGSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CM.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlcentre As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TC As System.Windows.Forms.TabControl
    Friend WithEvents TP1 As System.Windows.Forms.TabPage
    Friend WithEvents cmbInvioceNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbCompanyName As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CM As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MnuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents txtQtyTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Public WithEvents btnPayment As System.Windows.Forms.Button
    Friend WithEvents txtPaid As System.Windows.Forms.TextBox
    Friend WithEvents txtBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DGSNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGPType As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGProductCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGPcsInCrtn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGPricePerPcs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGPricePerCrtn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGCrtnPcs As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGBroken As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGLeak As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGShort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGDent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGExpired As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGDecayedBeforeExpiration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGClaimQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TP2 As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbCompanySearch As System.Windows.Forms.ComboBox
    Friend WithEvents cmbInvoiceNoSearch As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents DGSearch As System.Windows.Forms.DataGridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPcs As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalCrtn As System.Windows.Forms.TextBox
    Friend WithEvents DGSSNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGSPType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGSPName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGSQtyInCrtn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGSPricePerPcs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGSPricePerCrtn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGSCrtnPcs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGSBroken As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGSLeak As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGSShort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGSDent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGSExpired As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGSBeforeExpired As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGSTotalQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGSPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGSDescription As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
