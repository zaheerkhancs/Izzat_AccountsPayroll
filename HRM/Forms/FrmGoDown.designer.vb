<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGoDown
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGoDown))
        Me.Label1 = New System.Windows.Forms.Label
        Me.TC = New System.Windows.Forms.TabControl
        Me.TP1 = New System.Windows.Forms.TabPage
        Me.lblMessage = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtphone = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtConcernName = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtDate = New System.Windows.Forms.DateTimePicker
        Me.txtAddress = New System.Windows.Forms.TextBox
        Me.txtGName = New System.Windows.Forms.TextBox
        Me.txtID = New System.Windows.Forms.TextBox
        Me.TP2 = New System.Windows.Forms.TabPage
        Me.DGSearch = New System.Windows.Forms.DataGridView
        Me.GSNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GKName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GTel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GAddress = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GBSearch = New System.Windows.Forms.GroupBox
        Me.chbSingle = New System.Windows.Forms.CheckBox
        Me.cmbGoDownName = New System.Windows.Forms.ComboBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
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
        Me.Label1.Location = New System.Drawing.Point(205, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(390, 56)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "معلومات مکمل گدام ها "
        '
        'TC
        '
        Me.TC.Controls.Add(Me.TP1)
        Me.TC.Controls.Add(Me.TP2)
        Me.TC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TC.Location = New System.Drawing.Point(83, 144)
        Me.TC.Name = "TC"
        Me.TC.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TC.RightToLeftLayout = True
        Me.TC.SelectedIndex = 0
        Me.TC.Size = New System.Drawing.Size(523, 351)
        Me.TC.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.Teal
        Me.TP1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TP1.Controls.Add(Me.lblMessage)
        Me.TP1.Controls.Add(Me.Label7)
        Me.TP1.Controls.Add(Me.txtphone)
        Me.TP1.Controls.Add(Me.Label2)
        Me.TP1.Controls.Add(Me.txtConcernName)
        Me.TP1.Controls.Add(Me.Label9)
        Me.TP1.Controls.Add(Me.Label4)
        Me.TP1.Controls.Add(Me.Label3)
        Me.TP1.Controls.Add(Me.dtDate)
        Me.TP1.Controls.Add(Me.txtAddress)
        Me.TP1.Controls.Add(Me.txtGName)
        Me.TP1.Controls.Add(Me.txtID)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Name = "TP1"
        Me.TP1.Padding = New System.Windows.Forms.Padding(3)
        Me.TP1.Size = New System.Drawing.Size(515, 325)
        Me.TP1.TabIndex = 0
        Me.TP1.Text = "معلومات مکمل گدام ها "
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.GreenYellow
        Me.lblMessage.Location = New System.Drawing.Point(182, 292)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblMessage.Size = New System.Drawing.Size(25, 22)
        Me.lblMessage.TabIndex = 304
        Me.lblMessage.Text = "..."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(431, 186)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 251
        Me.Label7.Text = "شماره تلیفون"
        '
        'txtphone
        '
        Me.txtphone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtphone.Location = New System.Drawing.Point(184, 182)
        Me.txtphone.Name = "txtphone"
        Me.txtphone.ReadOnly = True
        Me.txtphone.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtphone.Size = New System.Drawing.Size(214, 21)
        Me.txtphone.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(406, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 249
        Me.Label2.Text = "اسم شخص مسئول"
        '
        'txtConcernName
        '
        Me.txtConcernName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConcernName.Location = New System.Drawing.Point(184, 144)
        Me.txtConcernName.Name = "txtConcernName"
        Me.txtConcernName.ReadOnly = True
        Me.txtConcernName.Size = New System.Drawing.Size(214, 21)
        Me.txtConcernName.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(444, 223)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "آدرس"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(449, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "اسم گدام"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(472, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "تاریخ"
        '
        'dtDate
        '
        Me.dtDate.CustomFormat = "dd/MM/yyyy"
        Me.dtDate.Enabled = False
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtDate.Location = New System.Drawing.Point(265, 72)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.Size = New System.Drawing.Size(133, 21)
        Me.dtDate.TabIndex = 0
        '
        'txtAddress
        '
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress.Location = New System.Drawing.Point(12, 221)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.ReadOnly = True
        Me.txtAddress.Size = New System.Drawing.Size(386, 60)
        Me.txtAddress.TabIndex = 4
        '
        'txtGName
        '
        Me.txtGName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGName.Location = New System.Drawing.Point(184, 109)
        Me.txtGName.Name = "txtGName"
        Me.txtGName.ReadOnly = True
        Me.txtGName.Size = New System.Drawing.Size(214, 21)
        Me.txtGName.TabIndex = 1
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(12, 31)
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
        Me.TP2.Size = New System.Drawing.Size(515, 325)
        Me.TP2.TabIndex = 1
        Me.TP2.Text = "جستجو"
        '
        'DGSearch
        '
        Me.DGSearch.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGSearch.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DGSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGSearch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GSNo, Me.GName, Me.GKName, Me.GTel, Me.GAddress})
        Me.DGSearch.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DGSearch.Location = New System.Drawing.Point(0, 50)
        Me.DGSearch.Name = "DGSearch"
        Me.DGSearch.Size = New System.Drawing.Size(515, 275)
        Me.DGSearch.TabIndex = 5
        '
        'GSNo
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.GSNo.DefaultCellStyle = DataGridViewCellStyle6
        Me.GSNo.HeaderText = "شماره"
        Me.GSNo.Name = "GSNo"
        '
        'GName
        '
        Me.GName.HeaderText = "اسم گدام"
        Me.GName.Name = "GName"
        '
        'GKName
        '
        Me.GKName.HeaderText = "اسم مسئول"
        Me.GKName.Name = "GKName"
        '
        'GTel
        '
        Me.GTel.HeaderText = "نمبر تلیفون"
        Me.GTel.Name = "GTel"
        '
        'GAddress
        '
        Me.GAddress.HeaderText = "آدرس"
        Me.GAddress.Name = "GAddress"
        Me.GAddress.Width = 200
        '
        'GBSearch
        '
        Me.GBSearch.Controls.Add(Me.chbSingle)
        Me.GBSearch.Controls.Add(Me.cmbGoDownName)
        Me.GBSearch.Controls.Add(Me.btnSearch)
        Me.GBSearch.Controls.Add(Me.Label5)
        Me.GBSearch.Location = New System.Drawing.Point(10, 0)
        Me.GBSearch.Name = "GBSearch"
        Me.GBSearch.Size = New System.Drawing.Size(497, 41)
        Me.GBSearch.TabIndex = 0
        Me.GBSearch.TabStop = False
        '
        'chbSingle
        '
        Me.chbSingle.AutoSize = True
        Me.chbSingle.ForeColor = System.Drawing.Color.White
        Me.chbSingle.Location = New System.Drawing.Point(382, 17)
        Me.chbSingle.Name = "chbSingle"
        Me.chbSingle.Size = New System.Drawing.Size(91, 17)
        Me.chbSingle.TabIndex = 8
        Me.chbSingle.Text = "انتخاب جداگانه"
        Me.chbSingle.UseVisualStyleBackColor = True
        '
        'cmbGoDownName
        '
        Me.cmbGoDownName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGoDownName.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbGoDownName.FormattingEnabled = True
        Me.cmbGoDownName.Location = New System.Drawing.Point(123, 14)
        Me.cmbGoDownName.Name = "cmbGoDownName"
        Me.cmbGoDownName.Size = New System.Drawing.Size(194, 21)
        Me.cmbGoDownName.TabIndex = 2
        '
        'btnSearch
        '
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(32, 13)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(76, 23)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "جستجو"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(324, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "اسم گدام"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AllowItemReorder = True
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripButton4, Me.ToolStripButton5, Me.ToolStripButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(83, 498)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip1.Size = New System.Drawing.Size(523, 23)
        Me.ToolStrip1.TabIndex = 249
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
        'FrmGoDown
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(695, 562)
        Me.ContextMenuStrip = Me.CM
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TC)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmGoDown"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmGoDown"
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
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtphone As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtConcernName As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtGName As System.Windows.Forms.TextBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
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
    Friend WithEvents TP2 As System.Windows.Forms.TabPage
    Friend WithEvents GBSearch As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DGSearch As System.Windows.Forms.DataGridView
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents cmbGoDownName As System.Windows.Forms.ComboBox
    Friend WithEvents chbSingle As System.Windows.Forms.CheckBox
    Friend WithEvents GSNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GKName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GTel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GAddress As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
