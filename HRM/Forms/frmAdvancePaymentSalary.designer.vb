<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdvancePaymentSalary
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdvancePaymentSalary))
        Me.lbIDR = New System.Windows.Forms.Label
        Me.dtRecieveDate = New System.Windows.Forms.DateTimePicker
        Me.Label16 = New System.Windows.Forms.Label
        Me.DGRecieveSearch = New System.Windows.Forms.DataGridView
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Remaining = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtRecieveRemarks = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtRemaining = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtTakenAmount = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtGivenAmount = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtEmpName = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.GBSearch = New System.Windows.Forms.GroupBox
        Me.btnRecieveSearch = New System.Windows.Forms.Button
        Me.dtToRecieve = New System.Windows.Forms.DateTimePicker
        Me.dtFromRecieve = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbReceiveEmpName = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.CMRecieve = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem
        Me.TSRecieveSave = New System.Windows.Forms.ToolStripMenuItem
        Me.TSRecieveUndo = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripMenuItem
        Me.TSRecieveClose = New System.Windows.Forms.ToolStripMenuItem
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSubmit = New System.Windows.Forms.Button
        CType(Me.DGRecieveSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBSearch.SuspendLayout()
        Me.CMRecieve.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbIDR
        '
        Me.lbIDR.AutoSize = True
        Me.lbIDR.BackColor = System.Drawing.Color.Transparent
        Me.lbIDR.Location = New System.Drawing.Point(13, 94)
        Me.lbIDR.Name = "lbIDR"
        Me.lbIDR.Size = New System.Drawing.Size(38, 13)
        Me.lbIDR.TabIndex = 54
        Me.lbIDR.Text = "Label5"
        Me.lbIDR.Visible = False
        '
        'dtRecieveDate
        '
        Me.dtRecieveDate.CustomFormat = "dd/MM/yyyy"
        Me.dtRecieveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtRecieveDate.Location = New System.Drawing.Point(447, 90)
        Me.dtRecieveDate.Name = "dtRecieveDate"
        Me.dtRecieveDate.Size = New System.Drawing.Size(122, 21)
        Me.dtRecieveDate.TabIndex = 0
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(580, 94)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 13)
        Me.Label16.TabIndex = 52
        Me.Label16.Text = "تاریخ پرداخت"
        '
        'DGRecieveSearch
        '
        Me.DGRecieveSearch.AllowUserToAddRows = False
        Me.DGRecieveSearch.AllowUserToDeleteRows = False
        Me.DGRecieveSearch.AllowUserToOrderColumns = True
        Me.DGRecieveSearch.AllowUserToResizeColumns = False
        Me.DGRecieveSearch.AllowUserToResizeRows = False
        Me.DGRecieveSearch.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.DGRecieveSearch.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.DGRecieveSearch.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGRecieveSearch.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGRecieveSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGRecieveSearch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.dtDate, Me.Amount, Me.Remaining, Me.Remarks})
        Me.DGRecieveSearch.Location = New System.Drawing.Point(12, 230)
        Me.DGRecieveSearch.Name = "DGRecieveSearch"
        Me.DGRecieveSearch.ReadOnly = True
        Me.DGRecieveSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGRecieveSearch.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.DGRecieveSearch.Size = New System.Drawing.Size(641, 205)
        Me.DGRecieveSearch.TabIndex = 41
        '
        'ID
        '
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.ID.DefaultCellStyle = DataGridViewCellStyle2
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'dtDate
        '
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.Format = "dd/MM/yyyy"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.dtDate.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtDate.HeaderText = "تاریخ پرداخت"
        Me.dtDate.Name = "dtDate"
        Me.dtDate.ReadOnly = True
        '
        'Amount
        '
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.Amount.DefaultCellStyle = DataGridViewCellStyle4
        Me.Amount.HeaderText = "مقدار گرفته شده"
        Me.Amount.Name = "Amount"
        Me.Amount.ReadOnly = True
        Me.Amount.Width = 120
        '
        'Remaining
        '
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.Remaining.DefaultCellStyle = DataGridViewCellStyle5
        Me.Remaining.HeaderText = "مقدار باقی مانده"
        Me.Remaining.Name = "Remaining"
        Me.Remaining.ReadOnly = True
        Me.Remaining.Width = 120
        '
        'Remarks
        '
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.Remarks.DefaultCellStyle = DataGridViewCellStyle6
        Me.Remarks.HeaderText = "تفصیل"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.ReadOnly = True
        Me.Remarks.Width = 215
        '
        'txtRecieveRemarks
        '
        Me.txtRecieveRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRecieveRemarks.Location = New System.Drawing.Point(12, 171)
        Me.txtRecieveRemarks.Multiline = True
        Me.txtRecieveRemarks.Name = "txtRecieveRemarks"
        Me.txtRecieveRemarks.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtRecieveRemarks.Size = New System.Drawing.Size(557, 53)
        Me.txtRecieveRemarks.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(602, 174)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 13)
        Me.Label12.TabIndex = 50
        Me.Label12.Text = "ملاحظات"
        '
        'txtRemaining
        '
        Me.txtRemaining.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemaining.Location = New System.Drawing.Point(12, 145)
        Me.txtRemaining.Name = "txtRemaining"
        Me.txtRemaining.ReadOnly = True
        Me.txtRemaining.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtRemaining.Size = New System.Drawing.Size(200, 21)
        Me.txtRemaining.TabIndex = 49
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(225, 148)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 13)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "مقدار باقی مانده"
        '
        'txtTakenAmount
        '
        Me.txtTakenAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTakenAmount.Location = New System.Drawing.Point(12, 119)
        Me.txtTakenAmount.Name = "txtTakenAmount"
        Me.txtTakenAmount.ReadOnly = True
        Me.txtTakenAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTakenAmount.Size = New System.Drawing.Size(200, 21)
        Me.txtTakenAmount.TabIndex = 47
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(225, 122)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 13)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "مقدار گرفته شده"
        '
        'txtGivenAmount
        '
        Me.txtGivenAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGivenAmount.Location = New System.Drawing.Point(369, 145)
        Me.txtGivenAmount.Name = "txtGivenAmount"
        Me.txtGivenAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtGivenAmount.Size = New System.Drawing.Size(200, 21)
        Me.txtGivenAmount.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(582, 148)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 44
        Me.Label9.Text = "مقدار پرداخت"
        '
        'txtEmpName
        '
        Me.txtEmpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmpName.Location = New System.Drawing.Point(369, 119)
        Me.txtEmpName.Name = "txtEmpName"
        Me.txtEmpName.ReadOnly = True
        Me.txtEmpName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtEmpName.Size = New System.Drawing.Size(200, 21)
        Me.txtEmpName.TabIndex = 43
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(590, 121)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 13)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "اسم کارمند"
        '
        'GBSearch
        '
        Me.GBSearch.BackColor = System.Drawing.Color.Transparent
        Me.GBSearch.Controls.Add(Me.btnRecieveSearch)
        Me.GBSearch.Controls.Add(Me.dtToRecieve)
        Me.GBSearch.Controls.Add(Me.dtFromRecieve)
        Me.GBSearch.Controls.Add(Me.Label7)
        Me.GBSearch.Controls.Add(Me.Label6)
        Me.GBSearch.Controls.Add(Me.cmbReceiveEmpName)
        Me.GBSearch.Controls.Add(Me.Label5)
        Me.GBSearch.ForeColor = System.Drawing.Color.White
        Me.GBSearch.Location = New System.Drawing.Point(7, 10)
        Me.GBSearch.Name = "GBSearch"
        Me.GBSearch.Size = New System.Drawing.Size(646, 44)
        Me.GBSearch.TabIndex = 0
        Me.GBSearch.TabStop = False
        '
        'btnRecieveSearch
        '
        Me.btnRecieveSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRecieveSearch.Location = New System.Drawing.Point(6, 14)
        Me.btnRecieveSearch.Name = "btnRecieveSearch"
        Me.btnRecieveSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnRecieveSearch.TabIndex = 3
        Me.btnRecieveSearch.Text = "جستجو"
        Me.btnRecieveSearch.UseVisualStyleBackColor = True
        '
        'dtToRecieve
        '
        Me.dtToRecieve.CustomFormat = "dd/MM/yyyy"
        Me.dtToRecieve.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtToRecieve.Location = New System.Drawing.Point(99, 16)
        Me.dtToRecieve.Name = "dtToRecieve"
        Me.dtToRecieve.Size = New System.Drawing.Size(99, 21)
        Me.dtToRecieve.TabIndex = 2
        '
        'dtFromRecieve
        '
        Me.dtFromRecieve.CustomFormat = "dd/MM/yyyy"
        Me.dtFromRecieve.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFromRecieve.Location = New System.Drawing.Point(252, 16)
        Me.dtFromRecieve.Name = "dtFromRecieve"
        Me.dtFromRecieve.Size = New System.Drawing.Size(99, 21)
        Me.dtFromRecieve.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(204, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "تا تاریخ"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(357, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "از تاریخ"
        '
        'cmbReceiveEmpName
        '
        Me.cmbReceiveEmpName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReceiveEmpName.Enabled = False
        Me.cmbReceiveEmpName.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbReceiveEmpName.FormattingEnabled = True
        Me.cmbReceiveEmpName.Location = New System.Drawing.Point(419, 15)
        Me.cmbReceiveEmpName.Name = "cmbReceiveEmpName"
        Me.cmbReceiveEmpName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbReceiveEmpName.Size = New System.Drawing.Size(153, 21)
        Me.cmbReceiveEmpName.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(578, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "اسم کارمند"
        '
        'CMRecieve
        '
        Me.CMRecieve.BackColor = System.Drawing.Color.White
        Me.CMRecieve.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem7, Me.TSRecieveSave, Me.TSRecieveUndo, Me.ToolStripMenuItem10, Me.ToolStripMenuItem11, Me.TSRecieveClose})
        Me.CMRecieve.Name = "CM"
        Me.CMRecieve.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.CMRecieve.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CMRecieve.Size = New System.Drawing.Size(139, 136)
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripMenuItem7.Enabled = False
        Me.ToolStripMenuItem7.ForeColor = System.Drawing.SystemColors.MenuText
        Me.ToolStripMenuItem7.Image = CType(resources.GetObject("ToolStripMenuItem7.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStripMenuItem7.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(138, 22)
        Me.ToolStripMenuItem7.Text = "&علاوه"
        Me.ToolStripMenuItem7.ToolTipText = "Add new Recod"
        '
        'TSRecieveSave
        '
        Me.TSRecieveSave.BackColor = System.Drawing.Color.Transparent
        Me.TSRecieveSave.ForeColor = System.Drawing.SystemColors.MenuText
        Me.TSRecieveSave.Image = CType(resources.GetObject("TSRecieveSave.Image"), System.Drawing.Image)
        Me.TSRecieveSave.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TSRecieveSave.Name = "TSRecieveSave"
        Me.TSRecieveSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TSRecieveSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.TSRecieveSave.Size = New System.Drawing.Size(138, 22)
        Me.TSRecieveSave.Text = "&ثبت"
        Me.TSRecieveSave.ToolTipText = "Save the Record"
        '
        'TSRecieveUndo
        '
        Me.TSRecieveUndo.BackColor = System.Drawing.Color.Transparent
        Me.TSRecieveUndo.ForeColor = System.Drawing.SystemColors.MenuText
        Me.TSRecieveUndo.Image = CType(resources.GetObject("TSRecieveUndo.Image"), System.Drawing.Image)
        Me.TSRecieveUndo.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TSRecieveUndo.Name = "TSRecieveUndo"
        Me.TSRecieveUndo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TSRecieveUndo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.TSRecieveUndo.Size = New System.Drawing.Size(138, 22)
        Me.TSRecieveUndo.Text = "&خنثی"
        Me.TSRecieveUndo.ToolTipText = "Go one Step Back"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripMenuItem10.Enabled = False
        Me.ToolStripMenuItem10.ForeColor = System.Drawing.SystemColors.MenuText
        Me.ToolStripMenuItem10.Image = CType(resources.GetObject("ToolStripMenuItem10.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem10.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStripMenuItem10.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.J), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(138, 22)
        Me.ToolStripMenuItem10.Text = "&تغیر"
        Me.ToolStripMenuItem10.ToolTipText = "Update the Record"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripMenuItem11.Enabled = False
        Me.ToolStripMenuItem11.ForeColor = System.Drawing.SystemColors.MenuText
        Me.ToolStripMenuItem11.Image = CType(resources.GetObject("ToolStripMenuItem11.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem11.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStripMenuItem11.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(138, 22)
        Me.ToolStripMenuItem11.Text = "&حذف"
        Me.ToolStripMenuItem11.ToolTipText = "Delete the Record"
        '
        'TSRecieveClose
        '
        Me.TSRecieveClose.BackColor = System.Drawing.Color.Transparent
        Me.TSRecieveClose.ForeColor = System.Drawing.SystemColors.MenuText
        Me.TSRecieveClose.Image = CType(resources.GetObject("TSRecieveClose.Image"), System.Drawing.Image)
        Me.TSRecieveClose.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TSRecieveClose.Name = "TSRecieveClose"
        Me.TSRecieveClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TSRecieveClose.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.TSRecieveClose.Size = New System.Drawing.Size(138, 22)
        Me.TSRecieveClose.Text = "&خروج"
        Me.TSRecieveClose.ToolTipText = "Close the Form"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(505, 441)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(147, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "فسخ"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSubmit
        '
        Me.btnSubmit.BackColor = System.Drawing.Color.Transparent
        Me.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSubmit.ForeColor = System.Drawing.Color.White
        Me.btnSubmit.Location = New System.Drawing.Point(352, 441)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(147, 23)
        Me.btnSubmit.TabIndex = 3
        Me.btnSubmit.Text = "ثبت"
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'frmAdvancePaymentSalary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Teal
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(664, 476)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lbIDR)
        Me.Controls.Add(Me.dtRecieveDate)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.DGRecieveSearch)
        Me.Controls.Add(Me.txtRecieveRemarks)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtRemaining)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtTakenAmount)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtGivenAmount)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtEmpName)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GBSearch)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmAdvancePaymentSalary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "پرداخت پشکی"
        CType(Me.DGRecieveSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBSearch.ResumeLayout(False)
        Me.GBSearch.PerformLayout()
        Me.CMRecieve.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbIDR As System.Windows.Forms.Label
    Friend WithEvents dtRecieveDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DGRecieveSearch As System.Windows.Forms.DataGridView
    Friend WithEvents txtRecieveRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtRemaining As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTakenAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtGivenAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtEmpName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GBSearch As System.Windows.Forms.GroupBox
    Friend WithEvents btnRecieveSearch As System.Windows.Forms.Button
    Friend WithEvents dtToRecieve As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFromRecieve As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbReceiveEmpName As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CMRecieve As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSRecieveSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSRecieveUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem11 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSRecieveClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remaining As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
