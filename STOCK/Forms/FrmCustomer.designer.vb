<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCustomer
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
        Dim TypeIDLabel As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCustomer))
        Me.cmbType = New System.Windows.Forms.ComboBox
        Me.LLCustomersList = New System.Windows.Forms.LinkLabel
        Me.lblMessage = New System.Windows.Forms.Label
        Me.CM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuNew = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSave = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUndo = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.TSNavigator = New System.Windows.Forms.ToolStrip
        Me.TSFirst = New System.Windows.Forms.ToolStripButton
        Me.TSPrevious = New System.Windows.Forms.ToolStripButton
        Me.TSLast = New System.Windows.Forms.ToolStripButton
        Me.TSNext = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.txtphone = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtAddress = New System.Windows.Forms.TextBox
        Me.txtFax = New System.Windows.Forms.TextBox
        Me.txtCell = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtSinceDate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbCustomerName = New System.Windows.Forms.ComboBox
        Me.lblInvCode = New System.Windows.Forms.Label
        Me.txtInvCode = New System.Windows.Forms.TextBox
        Me.cmbShop = New System.Windows.Forms.ComboBox
        Me.lblShop = New System.Windows.Forms.Label
        Me.chk = New System.Windows.Forms.CheckBox
        Me.cmbLocation = New System.Windows.Forms.ComboBox
        Me.lblLocation = New System.Windows.Forms.Label
        TypeIDLabel = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Me.CM.SuspendLayout()
        Me.TSNavigator.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TypeIDLabel
        '
        TypeIDLabel.AutoSize = True
        TypeIDLabel.BackColor = System.Drawing.Color.Transparent
        TypeIDLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        TypeIDLabel.ForeColor = System.Drawing.Color.White
        TypeIDLabel.Location = New System.Drawing.Point(513, 117)
        TypeIDLabel.Name = "TypeIDLabel"
        TypeIDLabel.Size = New System.Drawing.Size(26, 16)
        TypeIDLabel.TabIndex = 74
        TypeIDLabel.Text = "نوع"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.BackColor = System.Drawing.Color.Transparent
        Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Label2.ForeColor = System.Drawing.Color.White
        Label2.Location = New System.Drawing.Point(456, 144)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(83, 16)
        Label2.TabIndex = 82
        Label2.Text = " اسم مشتری"
        '
        'cmbType
        '
        Me.cmbType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.Enabled = False
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Location = New System.Drawing.Point(196, 117)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbType.Size = New System.Drawing.Size(215, 21)
        Me.cmbType.TabIndex = 73
        '
        'LLCustomersList
        '
        Me.LLCustomersList.AutoSize = True
        Me.LLCustomersList.BackColor = System.Drawing.Color.Transparent
        Me.LLCustomersList.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LLCustomersList.LinkColor = System.Drawing.Color.Orange
        Me.LLCustomersList.Location = New System.Drawing.Point(451, 37)
        Me.LLCustomersList.Name = "LLCustomersList"
        Me.LLCustomersList.Size = New System.Drawing.Size(94, 16)
        Me.LLCustomersList.TabIndex = 280
        Me.LLCustomersList.TabStop = True
        Me.LLCustomersList.Text = "لست  مشتریان"
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Georgia", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.GreenYellow
        Me.lblMessage.Location = New System.Drawing.Point(141, 56)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblMessage.Size = New System.Drawing.Size(19, 14)
        Me.lblMessage.TabIndex = 281
        Me.lblMessage.Text = "..."
        '
        'CM
        '
        Me.CM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CM.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuNew, Me.MnuSave, Me.MnuEdit, Me.MnuDelete, Me.MnuUndo, Me.MnuExit})
        Me.CM.Name = "ContextMenuStrip1"
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
        'TSNavigator
        '
        Me.TSNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSFirst, Me.TSPrevious, Me.TSLast, Me.TSNext, Me.ToolStripButton1})
        Me.TSNavigator.Location = New System.Drawing.Point(0, 0)
        Me.TSNavigator.Name = "TSNavigator"
        Me.TSNavigator.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TSNavigator.Size = New System.Drawing.Size(575, 25)
        Me.TSNavigator.TabIndex = 283
        Me.TSNavigator.Text = "ToolStrip1"
        '
        'TSFirst
        '
        Me.TSFirst.Image = CType(resources.GetObject("TSFirst.Image"), System.Drawing.Image)
        Me.TSFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSFirst.Name = "TSFirst"
        Me.TSFirst.Size = New System.Drawing.Size(59, 22)
        Me.TSFirst.Text = "نخست"
        '
        'TSPrevious
        '
        Me.TSPrevious.Image = CType(resources.GetObject("TSPrevious.Image"), System.Drawing.Image)
        Me.TSPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSPrevious.Name = "TSPrevious"
        Me.TSPrevious.Size = New System.Drawing.Size(51, 22)
        Me.TSPrevious.Text = "قبلی"
        '
        'TSLast
        '
        Me.TSLast.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TSLast.Image = CType(resources.GetObject("TSLast.Image"), System.Drawing.Image)
        Me.TSLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSLast.Name = "TSLast"
        Me.TSLast.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TSLast.Size = New System.Drawing.Size(53, 22)
        Me.TSLast.Text = "نهایی"
        '
        'TSNext
        '
        Me.TSNext.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TSNext.Image = CType(resources.GetObject("TSNext.Image"), System.Drawing.Image)
        Me.TSNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSNext.Name = "TSNext"
        Me.TSNext.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TSNext.Size = New System.Drawing.Size(52, 22)
        Me.TSNext.Text = "بعدی"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(12, 28)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(104, 85)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 284
        Me.PictureBox1.TabStop = False
        '
        'txtphone
        '
        Me.txtphone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtphone.Enabled = False
        Me.txtphone.Location = New System.Drawing.Point(197, 174)
        Me.txtphone.Name = "txtphone"
        Me.txtphone.Size = New System.Drawing.Size(214, 21)
        Me.txtphone.TabIndex = 285
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(501, 258)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 16)
        Me.Label9.TabIndex = 291
        Me.Label9.Text = "آدرس"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.BackColor = System.Drawing.Color.Transparent
        Me.label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.label6.ForeColor = System.Drawing.Color.White
        Me.label6.Location = New System.Drawing.Point(462, 230)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(77, 16)
        Me.label6.TabIndex = 290
        Me.label6.Text = "شماره فکس"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(457, 202)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 16)
        Me.Label1.TabIndex = 289
        Me.Label1.Text = "شماره موبائل"
        '
        'txtAddress
        '
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress.Enabled = False
        Me.txtAddress.Location = New System.Drawing.Point(25, 258)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(386, 55)
        Me.txtAddress.TabIndex = 288
        '
        'txtFax
        '
        Me.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFax.Enabled = False
        Me.txtFax.Location = New System.Drawing.Point(197, 230)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(214, 21)
        Me.txtFax.TabIndex = 287
        '
        'txtCell
        '
        Me.txtCell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCell.Enabled = False
        Me.txtCell.Location = New System.Drawing.Point(197, 202)
        Me.txtCell.Name = "txtCell"
        Me.txtCell.Size = New System.Drawing.Size(214, 21)
        Me.txtCell.TabIndex = 286
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(455, 174)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 16)
        Me.Label7.TabIndex = 292
        Me.Label7.Text = "شماره تلیفون"
        '
        'dtSinceDate
        '
        Me.dtSinceDate.CustomFormat = "dd/MM/yyyy"
        Me.dtSinceDate.Enabled = False
        Me.dtSinceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtSinceDate.Location = New System.Drawing.Point(197, 319)
        Me.dtSinceDate.Name = "dtSinceDate"
        Me.dtSinceDate.Size = New System.Drawing.Size(214, 21)
        Me.dtSinceDate.TabIndex = 293
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(453, 321)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 16)
        Me.Label3.TabIndex = 294
        Me.Label3.Text = "تاریخ استخدام"
        '
        'cmbCustomerName
        '
        Me.cmbCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCustomerName.Enabled = False
        Me.cmbCustomerName.FormattingEnabled = True
        Me.cmbCustomerName.Location = New System.Drawing.Point(196, 145)
        Me.cmbCustomerName.Name = "cmbCustomerName"
        Me.cmbCustomerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbCustomerName.Size = New System.Drawing.Size(215, 21)
        Me.cmbCustomerName.TabIndex = 295
        '
        'lblInvCode
        '
        Me.lblInvCode.AutoSize = True
        Me.lblInvCode.BackColor = System.Drawing.Color.Transparent
        Me.lblInvCode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblInvCode.ForeColor = System.Drawing.Color.White
        Me.lblInvCode.Location = New System.Drawing.Point(455, 346)
        Me.lblInvCode.Name = "lblInvCode"
        Me.lblInvCode.Size = New System.Drawing.Size(84, 16)
        Me.lblInvCode.TabIndex = 297
        Me.lblInvCode.Text = "مخفف انوائس"
        '
        'txtInvCode
        '
        Me.txtInvCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvCode.Enabled = False
        Me.txtInvCode.Location = New System.Drawing.Point(197, 346)
        Me.txtInvCode.MaxLength = 3
        Me.txtInvCode.Name = "txtInvCode"
        Me.txtInvCode.Size = New System.Drawing.Size(214, 21)
        Me.txtInvCode.TabIndex = 296
        '
        'cmbShop
        '
        Me.cmbShop.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbShop.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbShop.FormattingEnabled = True
        Me.cmbShop.Location = New System.Drawing.Point(197, 373)
        Me.cmbShop.Name = "cmbShop"
        Me.cmbShop.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbShop.Size = New System.Drawing.Size(214, 21)
        Me.cmbShop.TabIndex = 298
        '
        'lblShop
        '
        Me.lblShop.AutoSize = True
        Me.lblShop.BackColor = System.Drawing.Color.Transparent
        Me.lblShop.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblShop.ForeColor = System.Drawing.Color.White
        Me.lblShop.Location = New System.Drawing.Point(501, 374)
        Me.lblShop.Name = "lblShop"
        Me.lblShop.Size = New System.Drawing.Size(38, 16)
        Me.lblShop.TabIndex = 299
        Me.lblShop.Text = "دوکان"
        '
        'chk
        '
        Me.chk.AutoSize = True
        Me.chk.BackColor = System.Drawing.Color.Transparent
        Me.chk.ForeColor = System.Drawing.Color.White
        Me.chk.Location = New System.Drawing.Point(105, 377)
        Me.chk.Name = "chk"
        Me.chk.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chk.Size = New System.Drawing.Size(86, 17)
        Me.chk.TabIndex = 300
        Me.chk.Text = "موجود نیست"
        Me.chk.UseVisualStyleBackColor = False
        '
        'cmbLocation
        '
        Me.cmbLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLocation.FormattingEnabled = True
        Me.cmbLocation.Location = New System.Drawing.Point(197, 401)
        Me.cmbLocation.Name = "cmbLocation"
        Me.cmbLocation.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbLocation.Size = New System.Drawing.Size(213, 21)
        Me.cmbLocation.TabIndex = 301
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.BackColor = System.Drawing.Color.Transparent
        Me.lblLocation.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblLocation.ForeColor = System.Drawing.Color.White
        Me.lblLocation.Location = New System.Drawing.Point(496, 403)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(43, 16)
        Me.lblLocation.TabIndex = 302
        Me.lblLocation.Text = "موقیت"
        '
        'FrmCustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Teal
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(575, 426)
        Me.ContextMenuStrip = Me.CM
        Me.Controls.Add(Me.lblLocation)
        Me.Controls.Add(Me.cmbLocation)
        Me.Controls.Add(Me.lblShop)
        Me.Controls.Add(Me.chk)
        Me.Controls.Add(Me.cmbShop)
        Me.Controls.Add(Me.txtInvCode)
        Me.Controls.Add(Me.cmbCustomerName)
        Me.Controls.Add(Me.dtSinceDate)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtphone)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.lblInvCode)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.txtFax)
        Me.Controls.Add(Me.txtCell)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TSNavigator)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.LLCustomersList)
        Me.Controls.Add(Label2)
        Me.Controls.Add(TypeIDLabel)
        Me.Controls.Add(Me.cmbType)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmCustomer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "..."
        Me.CM.ResumeLayout(False)
        Me.TSNavigator.ResumeLayout(False)
        Me.TSNavigator.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LLCustomersList As System.Windows.Forms.LinkLabel
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents CM As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MnuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSNavigator As System.Windows.Forms.ToolStrip
    Friend WithEvents TSFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSPrevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Public WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents txtphone As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents txtCell As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtSinceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents cmbCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents lblInvCode As System.Windows.Forms.Label
    Friend WithEvents txtInvCode As System.Windows.Forms.TextBox
    Friend WithEvents cmbShop As System.Windows.Forms.ComboBox
    Friend WithEvents lblShop As System.Windows.Forms.Label
    Friend WithEvents chk As System.Windows.Forms.CheckBox
    Friend WithEvents cmbLocation As System.Windows.Forms.ComboBox
    Friend WithEvents lblLocation As System.Windows.Forms.Label
End Class
