<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MoneyExchanger
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MoneyExchanger))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.TC = New System.Windows.Forms.TabControl
        Me.TP1 = New System.Windows.Forms.TabPage
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TSFirst = New System.Windows.Forms.ToolStripButton
        Me.TSPrevious = New System.Windows.Forms.ToolStripButton
        Me.TSLast = New System.Windows.Forms.ToolStripButton
        Me.TSNext = New System.Windows.Forms.ToolStripButton
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
        Me.txtMExName = New System.Windows.Forms.TextBox
        Me.TP2 = New System.Windows.Forms.TabPage
        Me.DGSearch = New System.Windows.Forms.DataGridView
        Me.SSNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SCName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SFax = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SAddress = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GBSearch = New System.Windows.Forms.GroupBox
        Me.chbSingle = New System.Windows.Forms.CheckBox
        Me.cmbSarafName = New System.Windows.Forms.ComboBox
        Me.btnSearc = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.CM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TSAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.TSSave = New System.Windows.Forms.ToolStripMenuItem
        Me.TSUndo = New System.Windows.Forms.ToolStripMenuItem
        Me.TSUpdate = New System.Windows.Forms.ToolStripMenuItem
        Me.TSDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.TSClose = New System.Windows.Forms.ToolStripMenuItem
        Me.bbtnAdd = New System.Windows.Forms.Button
        Me.bbtnSave = New System.Windows.Forms.Button
        Me.bbtnEdit = New System.Windows.Forms.Button
        Me.bbtnCancel = New System.Windows.Forms.Button
        Me.bbtnDelete = New System.Windows.Forms.Button
        Me.bbtnExit = New System.Windows.Forms.Button
        Me.TC.SuspendLayout()
        Me.TP1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TP2.SuspendLayout()
        CType(Me.DGSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBSearch.SuspendLayout()
        Me.CM.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(148, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(447, 56)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "معلومات مکمل  صراف ها "
        '
        'TC
        '
        Me.TC.Controls.Add(Me.TP1)
        Me.TC.Controls.Add(Me.TP2)
        Me.TC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TC.Location = New System.Drawing.Point(54, 134)
        Me.TC.Name = "TC"
        Me.TC.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TC.RightToLeftLayout = True
        Me.TC.SelectedIndex = 0
        Me.TC.Size = New System.Drawing.Size(586, 375)
        Me.TC.TabIndex = 3
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.Teal
        Me.TP1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TP1.Controls.Add(Me.ToolStrip1)
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
        Me.TP1.Controls.Add(Me.txtMExName)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Name = "TP1"
        Me.TP1.Padding = New System.Windows.Forms.Padding(3)
        Me.TP1.Size = New System.Drawing.Size(578, 349)
        Me.TP1.TabIndex = 0
        Me.TP1.Text = "معلومات صراف "
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AllowItemReorder = True
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSFirst, Me.TSPrevious, Me.TSLast, Me.TSNext})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 322)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip1.Size = New System.Drawing.Size(572, 23)
        Me.ToolStrip1.TabIndex = 306
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
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.GreenYellow
        Me.lblMessage.Location = New System.Drawing.Point(197, 297)
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
        Me.Label7.Location = New System.Drawing.Point(476, 149)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 251
        Me.Label7.Text = "شماره تلیفون"
        '
        'txtphone
        '
        Me.txtphone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtphone.Enabled = False
        Me.txtphone.Location = New System.Drawing.Point(221, 147)
        Me.txtphone.Name = "txtphone"
        Me.txtphone.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtphone.Size = New System.Drawing.Size(214, 21)
        Me.txtphone.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(445, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 249
        Me.Label2.Text = "اسم شخص مسئول"
        '
        'txtConcernName
        '
        Me.txtConcernName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConcernName.Enabled = False
        Me.txtConcernName.Location = New System.Drawing.Point(221, 118)
        Me.txtConcernName.Name = "txtConcernName"
        Me.txtConcernName.Size = New System.Drawing.Size(214, 21)
        Me.txtConcernName.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(513, 240)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "آدرس"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.ForeColor = System.Drawing.Color.White
        Me.label6.Location = New System.Drawing.Point(480, 209)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(65, 13)
        Me.label6.TabIndex = 14
        Me.label6.Text = "شماره فکس"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(477, 178)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "شماره موبائل"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(480, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "اسم صرافی"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(517, 66)
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
        Me.dtDate.Location = New System.Drawing.Point(221, 61)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.Size = New System.Drawing.Size(214, 21)
        Me.dtDate.TabIndex = 0
        '
        'txtAddress
        '
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress.Enabled = False
        Me.txtAddress.Location = New System.Drawing.Point(49, 236)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(386, 55)
        Me.txtAddress.TabIndex = 6
        '
        'txtFax
        '
        Me.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFax.Enabled = False
        Me.txtFax.Location = New System.Drawing.Point(221, 206)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFax.Size = New System.Drawing.Size(214, 21)
        Me.txtFax.TabIndex = 5
        '
        'txtCell
        '
        Me.txtCell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCell.Enabled = False
        Me.txtCell.Location = New System.Drawing.Point(221, 176)
        Me.txtCell.Name = "txtCell"
        Me.txtCell.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCell.Size = New System.Drawing.Size(214, 21)
        Me.txtCell.TabIndex = 4
        '
        'txtMExName
        '
        Me.txtMExName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMExName.Enabled = False
        Me.txtMExName.Location = New System.Drawing.Point(221, 90)
        Me.txtMExName.Name = "txtMExName"
        Me.txtMExName.Size = New System.Drawing.Size(214, 21)
        Me.txtMExName.TabIndex = 1
        '
        'TP2
        '
        Me.TP2.BackColor = System.Drawing.Color.Teal
        Me.TP2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TP2.Controls.Add(Me.DGSearch)
        Me.TP2.Controls.Add(Me.GBSearch)
        Me.TP2.Location = New System.Drawing.Point(4, 22)
        Me.TP2.Name = "TP2"
        Me.TP2.Size = New System.Drawing.Size(578, 349)
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
        Me.DGSearch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SSNO, Me.SName, Me.SCName, Me.STel, Me.SFax, Me.SAddress})
        Me.DGSearch.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DGSearch.Location = New System.Drawing.Point(0, 74)
        Me.DGSearch.Name = "DGSearch"
        Me.DGSearch.Size = New System.Drawing.Size(578, 275)
        Me.DGSearch.TabIndex = 6
        '
        'SSNO
        '
        Me.SSNO.HeaderText = "شماره"
        Me.SSNO.Name = "SSNO"
        '
        'SName
        '
        Me.SName.HeaderText = "اسم صرافی"
        Me.SName.Name = "SName"
        '
        'SCName
        '
        Me.SCName.HeaderText = "اسم مسئول"
        Me.SCName.Name = "SCName"
        '
        'STel
        '
        Me.STel.HeaderText = "نمبر تلیفون"
        Me.STel.Name = "STel"
        '
        'SFax
        '
        Me.SFax.HeaderText = "نمبر فکس"
        Me.SFax.Name = "SFax"
        '
        'SAddress
        '
        Me.SAddress.HeaderText = "آدرس"
        Me.SAddress.Name = "SAddress"
        Me.SAddress.Width = 200
        '
        'GBSearch
        '
        Me.GBSearch.Controls.Add(Me.chbSingle)
        Me.GBSearch.Controls.Add(Me.cmbSarafName)
        Me.GBSearch.Controls.Add(Me.btnSearc)
        Me.GBSearch.Controls.Add(Me.Label12)
        Me.GBSearch.Location = New System.Drawing.Point(5, 3)
        Me.GBSearch.Name = "GBSearch"
        Me.GBSearch.Size = New System.Drawing.Size(570, 41)
        Me.GBSearch.TabIndex = 1
        Me.GBSearch.TabStop = False
        '
        'chbSingle
        '
        Me.chbSingle.AutoSize = True
        Me.chbSingle.ForeColor = System.Drawing.Color.White
        Me.chbSingle.Location = New System.Drawing.Point(455, 17)
        Me.chbSingle.Name = "chbSingle"
        Me.chbSingle.Size = New System.Drawing.Size(91, 17)
        Me.chbSingle.TabIndex = 8
        Me.chbSingle.Text = "انتخاب جداگانه"
        Me.chbSingle.UseVisualStyleBackColor = True
        '
        'cmbSarafName
        '
        Me.cmbSarafName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSarafName.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbSarafName.FormattingEnabled = True
        Me.cmbSarafName.Location = New System.Drawing.Point(144, 15)
        Me.cmbSarafName.Name = "cmbSarafName"
        Me.cmbSarafName.Size = New System.Drawing.Size(219, 21)
        Me.cmbSarafName.TabIndex = 2
        '
        'btnSearc
        '
        Me.btnSearc.Location = New System.Drawing.Point(36, 13)
        Me.btnSearc.Name = "btnSearc"
        Me.btnSearc.Size = New System.Drawing.Size(75, 23)
        Me.btnSearc.TabIndex = 1
        Me.btnSearc.Text = "جستجو"
        Me.btnSearc.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(369, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 13)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "اسم صرافی"
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
        'bbtnAdd
        '
        Me.bbtnAdd.Location = New System.Drawing.Point(95, 515)
        Me.bbtnAdd.Name = "bbtnAdd"
        Me.bbtnAdd.Size = New System.Drawing.Size(82, 25)
        Me.bbtnAdd.TabIndex = 6
        Me.bbtnAdd.Text = "Add"
        Me.bbtnAdd.UseVisualStyleBackColor = True
        Me.bbtnAdd.Visible = False
        '
        'bbtnSave
        '
        Me.bbtnSave.Location = New System.Drawing.Point(183, 515)
        Me.bbtnSave.Name = "bbtnSave"
        Me.bbtnSave.Size = New System.Drawing.Size(82, 25)
        Me.bbtnSave.TabIndex = 7
        Me.bbtnSave.Text = "Save"
        Me.bbtnSave.UseVisualStyleBackColor = True
        Me.bbtnSave.Visible = False
        '
        'bbtnEdit
        '
        Me.bbtnEdit.Location = New System.Drawing.Point(271, 515)
        Me.bbtnEdit.Name = "bbtnEdit"
        Me.bbtnEdit.Size = New System.Drawing.Size(82, 25)
        Me.bbtnEdit.TabIndex = 8
        Me.bbtnEdit.Text = "Edit"
        Me.bbtnEdit.UseVisualStyleBackColor = True
        Me.bbtnEdit.Visible = False
        '
        'bbtnCancel
        '
        Me.bbtnCancel.Location = New System.Drawing.Point(359, 515)
        Me.bbtnCancel.Name = "bbtnCancel"
        Me.bbtnCancel.Size = New System.Drawing.Size(82, 25)
        Me.bbtnCancel.TabIndex = 9
        Me.bbtnCancel.Text = "Cancel"
        Me.bbtnCancel.UseVisualStyleBackColor = True
        Me.bbtnCancel.Visible = False
        '
        'bbtnDelete
        '
        Me.bbtnDelete.Location = New System.Drawing.Point(450, 515)
        Me.bbtnDelete.Name = "bbtnDelete"
        Me.bbtnDelete.Size = New System.Drawing.Size(82, 25)
        Me.bbtnDelete.TabIndex = 10
        Me.bbtnDelete.Text = "Delete"
        Me.bbtnDelete.UseVisualStyleBackColor = True
        Me.bbtnDelete.Visible = False
        '
        'bbtnExit
        '
        Me.bbtnExit.Location = New System.Drawing.Point(538, 515)
        Me.bbtnExit.Name = "bbtnExit"
        Me.bbtnExit.Size = New System.Drawing.Size(82, 25)
        Me.bbtnExit.TabIndex = 11
        Me.bbtnExit.Text = "Exit"
        Me.bbtnExit.UseVisualStyleBackColor = True
        Me.bbtnExit.Visible = False
        '
        'MoneyExchanger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(695, 562)
        Me.ContextMenuStrip = Me.CM
        Me.Controls.Add(Me.bbtnDelete)
        Me.Controls.Add(Me.bbtnExit)
        Me.Controls.Add(Me.bbtnCancel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bbtnEdit)
        Me.Controls.Add(Me.bbtnSave)
        Me.Controls.Add(Me.TC)
        Me.Controls.Add(Me.bbtnAdd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MoneyExchanger"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MoneyExchanger"
        Me.TC.ResumeLayout(False)
        Me.TP1.ResumeLayout(False)
        Me.TP1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TP2.ResumeLayout(False)
        CType(Me.DGSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBSearch.ResumeLayout(False)
        Me.GBSearch.PerformLayout()
        Me.CM.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TC As System.Windows.Forms.TabControl
    Friend WithEvents TP1 As System.Windows.Forms.TabPage
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtphone As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtConcernName As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents txtCell As System.Windows.Forms.TextBox
    Friend WithEvents txtMExName As System.Windows.Forms.TextBox
    Friend WithEvents TP2 As System.Windows.Forms.TabPage
    Friend WithEvents DGSearch As System.Windows.Forms.DataGridView
    Friend WithEvents GBSearch As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearc As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CM As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TSAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSUpdate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bbtnAdd As System.Windows.Forms.Button
    Friend WithEvents bbtnSave As System.Windows.Forms.Button
    Friend WithEvents bbtnEdit As System.Windows.Forms.Button
    Friend WithEvents bbtnCancel As System.Windows.Forms.Button
    Friend WithEvents bbtnDelete As System.Windows.Forms.Button
    Friend WithEvents bbtnExit As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSPrevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbSarafName As System.Windows.Forms.ComboBox
    Friend WithEvents chbSingle As System.Windows.Forms.CheckBox
    Friend WithEvents SSNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SCName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SFax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SAddress As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
