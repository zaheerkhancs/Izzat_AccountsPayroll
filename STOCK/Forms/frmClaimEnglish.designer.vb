<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClaimEnglish
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClaimEnglish))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pnlcentre = New System.Windows.Forms.Panel
        Me.btnPrint = New System.Windows.Forms.Button
        Me.TC = New System.Windows.Forms.TabControl
        Me.TB1 = New System.Windows.Forms.TabPage
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
        Me.DGcmbProductCode = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DGPcsInCrtn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGPricePerPcs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGPricePerCrtn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGCrtnPcs = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DGBroken = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGLeak = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGShort = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGDented = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGExpired = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGDecayedBeforeExpiration = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGDescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmbCompanyName = New System.Windows.Forms.ComboBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.dtDate = New System.Windows.Forms.DateTimePicker
        Me.Label14 = New System.Windows.Forms.Label
        Me.CM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuNew = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSave = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUndo = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.btnEnter = New System.Windows.Forms.Button
        Me.pnlcentre.SuspendLayout()
        Me.TC.SuspendLayout()
        Me.TB1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.btnPrint.Location = New System.Drawing.Point(23, 3)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnPrint.Size = New System.Drawing.Size(87, 45)
        Me.btnPrint.TabIndex = 300
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'TC
        '
        Me.TC.Controls.Add(Me.TB1)
        Me.TC.Location = New System.Drawing.Point(29, 86)
        Me.TC.Name = "TC"
        Me.TC.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TC.RightToLeftLayout = True
        Me.TC.SelectedIndex = 0
        Me.TC.Size = New System.Drawing.Size(685, 444)
        Me.TC.TabIndex = 299
        '
        'TB1
        '
        Me.TB1.BackColor = System.Drawing.Color.Teal
        Me.TB1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TB1.Controls.Add(Me.btnEnter)
        Me.TB1.Controls.Add(Me.txtQtyTotal)
        Me.TB1.Controls.Add(Me.Label2)
        Me.TB1.Controls.Add(Me.lblMessage)
        Me.TB1.Controls.Add(Me.txtTotal)
        Me.TB1.Controls.Add(Me.ToolStrip1)
        Me.TB1.Controls.Add(Me.cmbInvioceNo)
        Me.TB1.Controls.Add(Me.Label1)
        Me.TB1.Controls.Add(Me.DG)
        Me.TB1.Controls.Add(Me.txtRemarks)
        Me.TB1.Controls.Add(Me.Label11)
        Me.TB1.Controls.Add(Me.cmbCompanyName)
        Me.TB1.Controls.Add(Me.Label23)
        Me.TB1.Controls.Add(Me.Label22)
        Me.TB1.Controls.Add(Me.Label6)
        Me.TB1.Controls.Add(Me.dtDate)
        Me.TB1.Location = New System.Drawing.Point(4, 22)
        Me.TB1.Name = "TB1"
        Me.TB1.Padding = New System.Windows.Forms.Padding(3)
        Me.TB1.Size = New System.Drawing.Size(677, 418)
        Me.TB1.TabIndex = 0
        Me.TB1.Text = "Claim "
        '
        'txtQtyTotal
        '
        Me.txtQtyTotal.Location = New System.Drawing.Point(480, 8)
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
        Me.Label2.Location = New System.Drawing.Point(341, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 16)
        Me.Label2.TabIndex = 303
        Me.Label2.Text = "Total Claimed Quantity"
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.GreenYellow
        Me.lblMessage.Location = New System.Drawing.Point(221, 158)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblMessage.Size = New System.Drawing.Size(21, 19)
        Me.lblMessage.TabIndex = 302
        Me.lblMessage.Text = "..."
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(480, 32)
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
        Me.ToolStrip1.Location = New System.Drawing.Point(7, 157)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No
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
        Me.ToolStripButton2.Size = New System.Drawing.Size(77, 21)
        Me.ToolStripButton2.Text = "Move First"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton4.Size = New System.Drawing.Size(97, 21)
        Me.ToolStripButton4.Text = "Move Previous"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton5.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton5.Size = New System.Drawing.Size(76, 21)
        Me.ToolStripButton5.Text = "Move Last"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton3.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton3.Size = New System.Drawing.Size(79, 21)
        Me.ToolStripButton3.Text = "Move Next"
        '
        'cmbInvioceNo
        '
        Me.cmbInvioceNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInvioceNo.Enabled = False
        Me.cmbInvioceNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbInvioceNo.FormattingEnabled = True
        Me.cmbInvioceNo.Location = New System.Drawing.Point(131, 35)
        Me.cmbInvioceNo.Name = "cmbInvioceNo"
        Me.cmbInvioceNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbInvioceNo.Size = New System.Drawing.Size(156, 21)
        Me.cmbInvioceNo.TabIndex = 296
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(29, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 16)
        Me.Label1.TabIndex = 295
        Me.Label1.Text = "Invioce No."
        '
        'DG
        '
        Me.DG.AllowUserToAddRows = False
        Me.DG.AllowUserToDeleteRows = False
        Me.DG.BackgroundColor = System.Drawing.Color.White
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGSNo, Me.DGPType, Me.DGcmbProductCode, Me.DGPcsInCrtn, Me.DGPricePerPcs, Me.DGPricePerCrtn, Me.DGCrtnPcs, Me.DGBroken, Me.DGLeak, Me.DGShort, Me.DGDented, Me.DGExpired, Me.DGDecayedBeforeExpiration, Me.DGQty, Me.DGPrice, Me.DGDescription})
        Me.DG.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DG.Location = New System.Drawing.Point(3, 184)
        Me.DG.Name = "DG"
        Me.DG.ReadOnly = True
        Me.DG.Size = New System.Drawing.Size(671, 231)
        Me.DG.TabIndex = 293
        '
        'DGSNo
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DGSNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGSNo.HeaderText = "SNo."
        Me.DGSNo.Name = "DGSNo"
        Me.DGSNo.ReadOnly = True
        Me.DGSNo.Width = 60
        '
        'DGPType
        '
        Me.DGPType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.DGPType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.DGPType.HeaderText = "Product Type"
        Me.DGPType.Name = "DGPType"
        Me.DGPType.ReadOnly = True
        Me.DGPType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGPType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DGPType.Width = 130
        '
        'DGcmbProductCode
        '
        Me.DGcmbProductCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.DGcmbProductCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.DGcmbProductCode.HeaderText = "Product Name"
        Me.DGcmbProductCode.Name = "DGcmbProductCode"
        Me.DGcmbProductCode.ReadOnly = True
        Me.DGcmbProductCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGcmbProductCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DGcmbProductCode.Width = 130
        '
        'DGPcsInCrtn
        '
        Me.DGPcsInCrtn.HeaderText = "Pieces In Carten"
        Me.DGPcsInCrtn.Name = "DGPcsInCrtn"
        Me.DGPcsInCrtn.ReadOnly = True
        '
        'DGPricePerPcs
        '
        Me.DGPricePerPcs.HeaderText = "Price Per Pieces"
        Me.DGPricePerPcs.Name = "DGPricePerPcs"
        Me.DGPricePerPcs.ReadOnly = True
        '
        'DGPricePerCrtn
        '
        Me.DGPricePerCrtn.HeaderText = "Price Per Carten"
        Me.DGPricePerCrtn.Name = "DGPricePerCrtn"
        Me.DGPricePerCrtn.ReadOnly = True
        '
        'DGCrtnPcs
        '
        Me.DGCrtnPcs.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.DGCrtnPcs.HeaderText = "Carton/Piece"
        Me.DGCrtnPcs.Name = "DGCrtnPcs"
        Me.DGCrtnPcs.ReadOnly = True
        Me.DGCrtnPcs.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGCrtnPcs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DGBroken
        '
        Me.DGBroken.HeaderText = "Broken"
        Me.DGBroken.Name = "DGBroken"
        Me.DGBroken.ReadOnly = True
        '
        'DGLeak
        '
        Me.DGLeak.HeaderText = "Leak"
        Me.DGLeak.Name = "DGLeak"
        Me.DGLeak.ReadOnly = True
        '
        'DGShort
        '
        Me.DGShort.HeaderText = "Short"
        Me.DGShort.Name = "DGShort"
        Me.DGShort.ReadOnly = True
        '
        'DGDented
        '
        Me.DGDented.HeaderText = "Dented"
        Me.DGDented.Name = "DGDented"
        Me.DGDented.ReadOnly = True
        '
        'DGExpired
        '
        Me.DGExpired.HeaderText = "Expired"
        Me.DGExpired.Name = "DGExpired"
        Me.DGExpired.ReadOnly = True
        '
        'DGDecayedBeforeExpiration
        '
        Me.DGDecayedBeforeExpiration.HeaderText = "Decayed Before Expiration"
        Me.DGDecayedBeforeExpiration.Name = "DGDecayedBeforeExpiration"
        Me.DGDecayedBeforeExpiration.ReadOnly = True
        '
        'DGQty
        '
        Me.DGQty.HeaderText = "Claimed Qty"
        Me.DGQty.Name = "DGQty"
        Me.DGQty.ReadOnly = True
        '
        'DGPrice
        '
        Me.DGPrice.HeaderText = "Price"
        Me.DGPrice.Name = "DGPrice"
        Me.DGPrice.ReadOnly = True
        '
        'DGDescription
        '
        Me.DGDescription.HeaderText = "Description"
        Me.DGDescription.Name = "DGDescription"
        Me.DGDescription.ReadOnly = True
        Me.DGDescription.Width = 200
        '
        'txtRemarks
        '
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Enabled = False
        Me.txtRemarks.Location = New System.Drawing.Point(131, 100)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRemarks.Size = New System.Drawing.Size(514, 56)
        Me.txtRemarks.TabIndex = 292
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(29, 104)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 16)
        Me.Label11.TabIndex = 291
        Me.Label11.Text = "Remarks"
        '
        'cmbCompanyName
        '
        Me.cmbCompanyName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCompanyName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCompanyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCompanyName.Enabled = False
        Me.cmbCompanyName.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbCompanyName.FormattingEnabled = True
        Me.cmbCompanyName.Location = New System.Drawing.Point(131, 10)
        Me.cmbCompanyName.Name = "cmbCompanyName"
        Me.cmbCompanyName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbCompanyName.Size = New System.Drawing.Size(204, 21)
        Me.cmbCompanyName.TabIndex = 289
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(29, 64)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(70, 16)
        Me.Label23.TabIndex = 287
        Me.Label23.Text = "Claim Date"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(341, 40)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(69, 16)
        Me.Label22.TabIndex = 286
        Me.Label22.Text = "Total Price"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(29, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 16)
        Me.Label6.TabIndex = 284
        Me.Label6.Text = "Company Name"
        '
        'dtDate
        '
        Me.dtDate.CustomFormat = "dd/MM/yy"
        Me.dtDate.Enabled = False
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtDate.Location = New System.Drawing.Point(131, 62)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtDate.RightToLeftLayout = True
        Me.dtDate.Size = New System.Drawing.Size(122, 21)
        Me.dtDate.TabIndex = 283
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(254, 34)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(296, 34)
        Me.Label14.TabIndex = 298
        Me.Label14.Text = "Claim On Purchases"
        '
        'CM
        '
        Me.CM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CM.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuNew, Me.MnuSave, Me.MnuUndo, Me.MnuEdit, Me.MnuDelete, Me.MnuExit})
        Me.CM.Name = "ContextMenuStrip1"
        Me.CM.Size = New System.Drawing.Size(157, 136)
        '
        'MnuNew
        '
        Me.MnuNew.BackColor = System.Drawing.Color.White
        Me.MnuNew.Image = CType(resources.GetObject("MnuNew.Image"), System.Drawing.Image)
        Me.MnuNew.ImageTransparentColor = System.Drawing.Color.Black
        Me.MnuNew.Name = "MnuNew"
        Me.MnuNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.MnuNew.Size = New System.Drawing.Size(156, 22)
        Me.MnuNew.Text = "&Add New"
        '
        'MnuSave
        '
        Me.MnuSave.BackColor = System.Drawing.Color.White
        Me.MnuSave.Enabled = False
        Me.MnuSave.Image = CType(resources.GetObject("MnuSave.Image"), System.Drawing.Image)
        Me.MnuSave.ImageTransparentColor = System.Drawing.Color.Black
        Me.MnuSave.Name = "MnuSave"
        Me.MnuSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.MnuSave.Size = New System.Drawing.Size(156, 22)
        Me.MnuSave.Text = "&Save"
        '
        'MnuUndo
        '
        Me.MnuUndo.BackColor = System.Drawing.Color.White
        Me.MnuUndo.Enabled = False
        Me.MnuUndo.Image = CType(resources.GetObject("MnuUndo.Image"), System.Drawing.Image)
        Me.MnuUndo.ImageTransparentColor = System.Drawing.Color.Black
        Me.MnuUndo.Name = "MnuUndo"
        Me.MnuUndo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.MnuUndo.Size = New System.Drawing.Size(156, 22)
        Me.MnuUndo.Text = "&Undo"
        '
        'MnuEdit
        '
        Me.MnuEdit.BackColor = System.Drawing.Color.White
        Me.MnuEdit.Image = CType(resources.GetObject("MnuEdit.Image"), System.Drawing.Image)
        Me.MnuEdit.Name = "MnuEdit"
        Me.MnuEdit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.MnuEdit.Size = New System.Drawing.Size(156, 22)
        Me.MnuEdit.Text = "&Edit"
        '
        'MnuDelete
        '
        Me.MnuDelete.BackColor = System.Drawing.Color.White
        Me.MnuDelete.Image = CType(resources.GetObject("MnuDelete.Image"), System.Drawing.Image)
        Me.MnuDelete.Name = "MnuDelete"
        Me.MnuDelete.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.MnuDelete.Size = New System.Drawing.Size(156, 22)
        Me.MnuDelete.Text = "&Delete"
        '
        'MnuExit
        '
        Me.MnuExit.BackColor = System.Drawing.Color.White
        Me.MnuExit.Name = "MnuExit"
        Me.MnuExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.MnuExit.Size = New System.Drawing.Size(156, 22)
        Me.MnuExit.Text = "&Exit"
        '
        'btnEnter
        '
        Me.btnEnter.Location = New System.Drawing.Point(289, 33)
        Me.btnEnter.Name = "btnEnter"
        Me.btnEnter.Size = New System.Drawing.Size(48, 24)
        Me.btnEnter.TabIndex = 305
        Me.btnEnter.Text = "Enter"
        Me.btnEnter.UseVisualStyleBackColor = True
        '
        'frmClaimEnglish
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(783, 636)
        Me.ContextMenuStrip = Me.CM
        Me.Controls.Add(Me.pnlcentre)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmClaimEnglish"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmClaim"
        Me.pnlcentre.ResumeLayout(False)
        Me.pnlcentre.PerformLayout()
        Me.TC.ResumeLayout(False)
        Me.TB1.ResumeLayout(False)
        Me.TB1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents TB1 As System.Windows.Forms.TabPage
    Friend WithEvents cmbInvioceNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbCompanyName As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
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
    Friend WithEvents DGSNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGPType As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGcmbProductCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGPcsInCrtn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGPricePerPcs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGPricePerCrtn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGCrtnPcs As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGBroken As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGLeak As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGShort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGDented As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGExpired As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGDecayedBeforeExpiration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnEnter As System.Windows.Forms.Button
End Class
