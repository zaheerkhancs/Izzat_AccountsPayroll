<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVendorSetup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVendorSetup))
        Me.Label1 = New System.Windows.Forms.Label
        Me.TC = New System.Windows.Forms.TabControl
        Me.TP1 = New System.Windows.Forms.TabPage
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtJobTitle = New System.Windows.Forms.TextBox
        Me.lblMessage = New System.Windows.Forms.Label
        Me.txtID = New System.Windows.Forms.TextBox
        Me.txtAddress1 = New System.Windows.Forms.TextBox
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.txtFax = New System.Windows.Forms.TextBox
        Me.txtContact = New System.Windows.Forms.TextBox
        Me.txtConcernPName = New System.Windows.Forms.TextBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.dtDate = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TP2 = New System.Windows.Forms.TabPage
        Me.DGSearch = New System.Windows.Forms.DataGridView
        Me.VSNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VCName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VJob = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VTel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VFax = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vmail = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VAddress = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GBSearch = New System.Windows.Forms.GroupBox
        Me.chbSingle = New System.Windows.Forms.CheckBox
        Me.cmbVendorName = New System.Windows.Forms.ComboBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.CM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TSAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.TSSave = New System.Windows.Forms.ToolStripMenuItem
        Me.TSUndo = New System.Windows.Forms.ToolStripMenuItem
        Me.TSUpdate = New System.Windows.Forms.ToolStripMenuItem
        Me.TSDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.TSClose = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
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
        Me.Label1.Location = New System.Drawing.Point(71, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(603, 56)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = " معلومات مکمل فروشنده و یا کمپنی "
        Me.ToolTip1.SetToolTip(Me.Label1, "Complete Vendor Information")
        '
        'TC
        '
        Me.TC.Controls.Add(Me.TP1)
        Me.TC.Controls.Add(Me.TP2)
        Me.TC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TC.Location = New System.Drawing.Point(41, 136)
        Me.TC.Name = "TC"
        Me.TC.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TC.RightToLeftLayout = True
        Me.TC.SelectedIndex = 0
        Me.TC.Size = New System.Drawing.Size(610, 387)
        Me.TC.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.Teal
        Me.TP1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TP1.Controls.Add(Me.Label10)
        Me.TP1.Controls.Add(Me.txtJobTitle)
        Me.TP1.Controls.Add(Me.lblMessage)
        Me.TP1.Controls.Add(Me.txtID)
        Me.TP1.Controls.Add(Me.txtAddress1)
        Me.TP1.Controls.Add(Me.txtEmail)
        Me.TP1.Controls.Add(Me.txtFax)
        Me.TP1.Controls.Add(Me.txtContact)
        Me.TP1.Controls.Add(Me.txtConcernPName)
        Me.TP1.Controls.Add(Me.txtName)
        Me.TP1.Controls.Add(Me.dtDate)
        Me.TP1.Controls.Add(Me.Label9)
        Me.TP1.Controls.Add(Me.Label8)
        Me.TP1.Controls.Add(Me.Label7)
        Me.TP1.Controls.Add(Me.Label6)
        Me.TP1.Controls.Add(Me.Label5)
        Me.TP1.Controls.Add(Me.Label4)
        Me.TP1.Controls.Add(Me.Label3)
        Me.TP1.Controls.Add(Me.Label2)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Name = "TP1"
        Me.TP1.Padding = New System.Windows.Forms.Padding(3)
        Me.TP1.Size = New System.Drawing.Size(602, 361)
        Me.TP1.TabIndex = 0
        Me.TP1.Text = "معلومات درباره فروشنده"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(515, 143)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 13)
        Me.Label10.TabIndex = 307
        Me.Label10.Text = "شغل"
        Me.ToolTip1.SetToolTip(Me.Label10, "Job Title")
        '
        'txtJobTitle
        '
        Me.txtJobTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJobTitle.Location = New System.Drawing.Point(230, 141)
        Me.txtJobTitle.Name = "txtJobTitle"
        Me.txtJobTitle.ReadOnly = True
        Me.txtJobTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtJobTitle.Size = New System.Drawing.Size(200, 21)
        Me.txtJobTitle.TabIndex = 3
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.GreenYellow
        Me.lblMessage.Location = New System.Drawing.Point(224, 329)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblMessage.Size = New System.Drawing.Size(25, 22)
        Me.lblMessage.TabIndex = 305
        Me.lblMessage.Text = "..."
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(110, 55)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(100, 21)
        Me.txtID.TabIndex = 2
        Me.txtID.Visible = False
        '
        'txtAddress1
        '
        Me.txtAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress1.Location = New System.Drawing.Point(59, 256)
        Me.txtAddress1.Multiline = True
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.ReadOnly = True
        Me.txtAddress1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAddress1.Size = New System.Drawing.Size(371, 63)
        Me.txtAddress1.TabIndex = 7
        '
        'txtEmail
        '
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Location = New System.Drawing.Point(230, 226)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.ReadOnly = True
        Me.txtEmail.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEmail.Size = New System.Drawing.Size(200, 21)
        Me.txtEmail.TabIndex = 6
        '
        'txtFax
        '
        Me.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFax.Location = New System.Drawing.Point(230, 197)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.ReadOnly = True
        Me.txtFax.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFax.Size = New System.Drawing.Size(200, 21)
        Me.txtFax.TabIndex = 5
        '
        'txtContact
        '
        Me.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContact.Location = New System.Drawing.Point(230, 168)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.ReadOnly = True
        Me.txtContact.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtContact.Size = New System.Drawing.Size(200, 21)
        Me.txtContact.TabIndex = 4
        '
        'txtConcernPName
        '
        Me.txtConcernPName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConcernPName.Location = New System.Drawing.Point(230, 114)
        Me.txtConcernPName.Name = "txtConcernPName"
        Me.txtConcernPName.ReadOnly = True
        Me.txtConcernPName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtConcernPName.Size = New System.Drawing.Size(200, 21)
        Me.txtConcernPName.TabIndex = 2
        '
        'txtName
        '
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtName.Location = New System.Drawing.Point(230, 85)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtName.Size = New System.Drawing.Size(200, 21)
        Me.txtName.TabIndex = 1
        '
        'dtDate
        '
        Me.dtDate.CustomFormat = "dd/MM/yyyy"
        Me.dtDate.Enabled = False
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtDate.Location = New System.Drawing.Point(303, 55)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.Size = New System.Drawing.Size(127, 21)
        Me.dtDate.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(515, 258)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "آدرس"
        Me.ToolTip1.SetToolTip(Me.Label9, "Postal Address 1")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(464, 228)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "آدرس الکترونیکی"
        Me.ToolTip1.SetToolTip(Me.Label8, "Email Address")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(451, 116)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "اسم شخص مسئول"
        Me.ToolTip1.SetToolTip(Me.Label7, "Concern Person Name")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(486, 199)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "شماره فکس"
        Me.ToolTip1.SetToolTip(Me.Label6, "Fax No.")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(481, 170)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "شماره تماس"
        Me.ToolTip1.SetToolTip(Me.Label5, "Contact No.")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(486, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "اسم کمپنی"
        Me.ToolTip1.SetToolTip(Me.Label4, "Company Name")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(519, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "تاریخ"
        Me.ToolTip1.SetToolTip(Me.Label3, "Date")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(86, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "ID"
        Me.Label2.Visible = False
        '
        'TP2
        '
        Me.TP2.BackColor = System.Drawing.Color.Teal
        Me.TP2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TP2.Controls.Add(Me.DGSearch)
        Me.TP2.Controls.Add(Me.GBSearch)
        Me.TP2.Location = New System.Drawing.Point(4, 22)
        Me.TP2.Name = "TP2"
        Me.TP2.Size = New System.Drawing.Size(602, 361)
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
        Me.DGSearch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VSNo, Me.VName, Me.VCName, Me.VJob, Me.VTel, Me.VFax, Me.Vmail, Me.VAddress})
        Me.DGSearch.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DGSearch.Location = New System.Drawing.Point(0, 54)
        Me.DGSearch.Name = "DGSearch"
        Me.DGSearch.Size = New System.Drawing.Size(602, 307)
        Me.DGSearch.TabIndex = 7
        '
        'VSNo
        '
        Me.VSNo.HeaderText = "شماره"
        Me.VSNo.Name = "VSNo"
        '
        'VName
        '
        Me.VName.HeaderText = "اسم کمپنی"
        Me.VName.Name = "VName"
        '
        'VCName
        '
        Me.VCName.HeaderText = "اسم مسئول"
        Me.VCName.Name = "VCName"
        '
        'VJob
        '
        Me.VJob.HeaderText = "شغل"
        Me.VJob.Name = "VJob"
        '
        'VTel
        '
        Me.VTel.HeaderText = "نمبر تلیفون"
        Me.VTel.Name = "VTel"
        '
        'VFax
        '
        Me.VFax.HeaderText = "نمبر فکس"
        Me.VFax.Name = "VFax"
        '
        'Vmail
        '
        Me.Vmail.HeaderText = "ایمیل"
        Me.Vmail.Name = "Vmail"
        Me.Vmail.ReadOnly = True
        '
        'VAddress
        '
        Me.VAddress.HeaderText = "آدرس"
        Me.VAddress.Name = "VAddress"
        Me.VAddress.Width = 200
        '
        'GBSearch
        '
        Me.GBSearch.Controls.Add(Me.chbSingle)
        Me.GBSearch.Controls.Add(Me.cmbVendorName)
        Me.GBSearch.Controls.Add(Me.btnSearch)
        Me.GBSearch.Controls.Add(Me.Label12)
        Me.GBSearch.Location = New System.Drawing.Point(3, 3)
        Me.GBSearch.Name = "GBSearch"
        Me.GBSearch.Size = New System.Drawing.Size(596, 41)
        Me.GBSearch.TabIndex = 2
        Me.GBSearch.TabStop = False
        '
        'chbSingle
        '
        Me.chbSingle.AutoSize = True
        Me.chbSingle.ForeColor = System.Drawing.Color.White
        Me.chbSingle.Location = New System.Drawing.Point(487, 16)
        Me.chbSingle.Name = "chbSingle"
        Me.chbSingle.Size = New System.Drawing.Size(91, 17)
        Me.chbSingle.TabIndex = 10
        Me.chbSingle.Text = "انتخاب جداگانه"
        Me.chbSingle.UseVisualStyleBackColor = True
        '
        'cmbVendorName
        '
        Me.cmbVendorName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendorName.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbVendorName.FormattingEnabled = True
        Me.cmbVendorName.Location = New System.Drawing.Point(128, 14)
        Me.cmbVendorName.Name = "cmbVendorName"
        Me.cmbVendorName.Size = New System.Drawing.Size(267, 21)
        Me.cmbVendorName.TabIndex = 2
        '
        'btnSearch
        '
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(17, 12)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "جستجو"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(400, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 13)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "اسم کمپنی"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AllowItemReorder = True
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripButton4, Me.ToolStripButton5, Me.ToolStripButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(42, 522)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip1.Size = New System.Drawing.Size(609, 23)
        Me.ToolStrip1.TabIndex = 246
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
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'frmVendorSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(695, 562)
        Me.ContextMenuStrip = Me.CM
        Me.Controls.Add(Me.TC)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmVendorSetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmVendorSetup"
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
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents txtContact As System.Windows.Forms.TextBox
    Friend WithEvents txtConcernPName As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents dtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents CM As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TSAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSUpdate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TP2 As System.Windows.Forms.TabPage
    Friend WithEvents GBSearch As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents DGSearch As System.Windows.Forms.DataGridView
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents txtJobTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbVendorName As System.Windows.Forms.ComboBox
    Friend WithEvents chbSingle As System.Windows.Forms.CheckBox
    Friend WithEvents VSNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VCName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VJob As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VTel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VFax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vmail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VAddress As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
