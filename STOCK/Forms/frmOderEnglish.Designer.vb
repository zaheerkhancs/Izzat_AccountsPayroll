<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOderEnglish
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOderEnglish))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pnlcentre = New System.Windows.Forms.Panel
        Me.btnPrint = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.TB1 = New System.Windows.Forms.TabControl
        Me.TP1 = New System.Windows.Forms.TabPage
        Me.chkSaveInvoiceProforma = New System.Windows.Forms.CheckBox
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.InvProfPB = New System.Windows.Forms.PictureBox
        Me.LnkInvoiceProforma = New System.Windows.Forms.LinkLabel
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbCompanySearch = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbOrderNoSearch = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtNote = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtJobTitle = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbVendorForOrderMainEnglish = New System.Windows.Forms.ComboBox
        Me.txtPersonName = New System.Windows.Forms.TextBox
        Me.txtOrderNo = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblMessage = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.dtReqDate = New System.Windows.Forms.DateTimePicker
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.DG = New System.Windows.Forms.DataGridView
        Me.DGSNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGPType = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DGcmbProductCode = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DGProductName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGDecription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.dtOrderDate = New System.Windows.Forms.DateTimePicker
        Me.CM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuReturn = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuNew = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSave = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUndo = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.OFD = New System.Windows.Forms.OpenFileDialog
        Me.pnlcentre.SuspendLayout()
        Me.TB1.SuspendLayout()
        Me.TP1.SuspendLayout()
        CType(Me.InvProfPB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CM.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlcentre
        '
        Me.pnlcentre.Controls.Add(Me.btnPrint)
        Me.pnlcentre.Controls.Add(Me.Label14)
        Me.pnlcentre.Controls.Add(Me.TB1)
        Me.pnlcentre.Location = New System.Drawing.Point(13, 38)
        Me.pnlcentre.Name = "pnlcentre"
        Me.pnlcentre.Size = New System.Drawing.Size(720, 553)
        Me.pnlcentre.TabIndex = 1
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImage = CType(resources.GetObject("btnPrint.BackgroundImage"), System.Drawing.Image)
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(596, 3)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(87, 45)
        Me.btnPrint.TabIndex = 0
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(279, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(170, 34)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "Order Page"
        '
        'TB1
        '
        Me.TB1.Controls.Add(Me.TP1)
        Me.TB1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB1.Location = New System.Drawing.Point(30, 67)
        Me.TB1.Name = "TB1"
        Me.TB1.SelectedIndex = 0
        Me.TB1.Size = New System.Drawing.Size(660, 483)
        Me.TB1.TabIndex = 27
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.Teal
        Me.TP1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TP1.Controls.Add(Me.chkSaveInvoiceProforma)
        Me.TP1.Controls.Add(Me.btnBrowse)
        Me.TP1.Controls.Add(Me.InvProfPB)
        Me.TP1.Controls.Add(Me.LnkInvoiceProforma)
        Me.TP1.Controls.Add(Me.Label5)
        Me.TP1.Controls.Add(Me.cmbCompanySearch)
        Me.TP1.Controls.Add(Me.Label4)
        Me.TP1.Controls.Add(Me.cmbOrderNoSearch)
        Me.TP1.Controls.Add(Me.Label3)
        Me.TP1.Controls.Add(Me.txtNote)
        Me.TP1.Controls.Add(Me.Label2)
        Me.TP1.Controls.Add(Me.txtJobTitle)
        Me.TP1.Controls.Add(Me.Label1)
        Me.TP1.Controls.Add(Me.cmbVendorForOrderMainEnglish)
        Me.TP1.Controls.Add(Me.txtPersonName)
        Me.TP1.Controls.Add(Me.txtOrderNo)
        Me.TP1.Controls.Add(Me.Panel2)
        Me.TP1.Controls.Add(Me.dtReqDate)
        Me.TP1.Controls.Add(Me.Label25)
        Me.TP1.Controls.Add(Me.Label24)
        Me.TP1.Controls.Add(Me.Label23)
        Me.TP1.Controls.Add(Me.Label22)
        Me.TP1.Controls.Add(Me.DG)
        Me.TP1.Controls.Add(Me.Label6)
        Me.TP1.Controls.Add(Me.txtRemarks)
        Me.TP1.Controls.Add(Me.Label11)
        Me.TP1.Controls.Add(Me.dtOrderDate)
        Me.TP1.ForeColor = System.Drawing.Color.White
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Name = "TP1"
        Me.TP1.Padding = New System.Windows.Forms.Padding(3)
        Me.TP1.Size = New System.Drawing.Size(652, 457)
        Me.TP1.TabIndex = 0
        Me.TP1.Text = "Order Information Section"
        '
        'chkSaveInvoiceProforma
        '
        Me.chkSaveInvoiceProforma.AutoSize = True
        Me.chkSaveInvoiceProforma.BackColor = System.Drawing.Color.Transparent
        Me.chkSaveInvoiceProforma.Location = New System.Drawing.Point(352, 153)
        Me.chkSaveInvoiceProforma.Name = "chkSaveInvoiceProforma"
        Me.chkSaveInvoiceProforma.Size = New System.Drawing.Size(181, 17)
        Me.chkSaveInvoiceProforma.TabIndex = 302
        Me.chkSaveInvoiceProforma.Text = "Update Invoice proforma as well"
        Me.chkSaveInvoiceProforma.UseVisualStyleBackColor = False
        Me.chkSaveInvoiceProforma.Visible = False
        '
        'btnBrowse
        '
        Me.btnBrowse.BackColor = System.Drawing.Color.Transparent
        Me.btnBrowse.Enabled = False
        Me.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBrowse.Location = New System.Drawing.Point(543, 149)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 301
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = False
        '
        'InvProfPB
        '
        Me.InvProfPB.InitialImage = CType(resources.GetObject("InvProfPB.InitialImage"), System.Drawing.Image)
        Me.InvProfPB.Location = New System.Drawing.Point(161, 149)
        Me.InvProfPB.Name = "InvProfPB"
        Me.InvProfPB.Size = New System.Drawing.Size(28, 23)
        Me.InvProfPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.InvProfPB.TabIndex = 300
        Me.InvProfPB.TabStop = False
        '
        'LnkInvoiceProforma
        '
        Me.LnkInvoiceProforma.AutoSize = True
        Me.LnkInvoiceProforma.Location = New System.Drawing.Point(196, 155)
        Me.LnkInvoiceProforma.Name = "LnkInvoiceProforma"
        Me.LnkInvoiceProforma.Size = New System.Drawing.Size(114, 13)
        Me.LnkInvoiceProforma.TabIndex = 299
        Me.LnkInvoiceProforma.TabStop = True
        Me.LnkInvoiceProforma.Text = "View Invoice Proforma"
        Me.LnkInvoiceProforma.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(29, 147)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 16)
        Me.Label5.TabIndex = 297
        Me.Label5.Text = "Invoice Proforma"
        '
        'cmbCompanySearch
        '
        Me.cmbCompanySearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCompanySearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCompanySearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbCompanySearch.FormattingEnabled = True
        Me.cmbCompanySearch.Location = New System.Drawing.Point(463, 80)
        Me.cmbCompanySearch.Name = "cmbCompanySearch"
        Me.cmbCompanySearch.Size = New System.Drawing.Size(153, 21)
        Me.cmbCompanySearch.TabIndex = 296
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(373, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 18)
        Me.Label4.TabIndex = 295
        Me.Label4.Text = "Company"
        '
        'cmbOrderNoSearch
        '
        Me.cmbOrderNoSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbOrderNoSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbOrderNoSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbOrderNoSearch.FormattingEnabled = True
        Me.cmbOrderNoSearch.Location = New System.Drawing.Point(464, 104)
        Me.cmbOrderNoSearch.Name = "cmbOrderNoSearch"
        Me.cmbOrderNoSearch.Size = New System.Drawing.Size(153, 21)
        Me.cmbOrderNoSearch.TabIndex = 294
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(374, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 18)
        Me.Label3.TabIndex = 293
        Me.Label3.Text = "Order No"
        '
        'txtNote
        '
        Me.txtNote.Location = New System.Drawing.Point(160, 174)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.ReadOnly = True
        Me.txtNote.Size = New System.Drawing.Size(458, 41)
        Me.txtNote.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(30, 174)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 16)
        Me.Label2.TabIndex = 292
        Me.Label2.Text = "&Note"
        '
        'txtJobTitle
        '
        Me.txtJobTitle.Location = New System.Drawing.Point(161, 82)
        Me.txtJobTitle.Name = "txtJobTitle"
        Me.txtJobTitle.ReadOnly = True
        Me.txtJobTitle.Size = New System.Drawing.Size(207, 21)
        Me.txtJobTitle.TabIndex = 291
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(30, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 16)
        Me.Label1.TabIndex = 290
        Me.Label1.Text = "JobTitle"
        '
        'cmbVendorForOrderMainEnglish
        '
        Me.cmbVendorForOrderMainEnglish.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbVendorForOrderMainEnglish.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbVendorForOrderMainEnglish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendorForOrderMainEnglish.Enabled = False
        Me.cmbVendorForOrderMainEnglish.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbVendorForOrderMainEnglish.FormattingEnabled = True
        Me.cmbVendorForOrderMainEnglish.Location = New System.Drawing.Point(161, 9)
        Me.cmbVendorForOrderMainEnglish.Name = "cmbVendorForOrderMainEnglish"
        Me.cmbVendorForOrderMainEnglish.Size = New System.Drawing.Size(457, 21)
        Me.cmbVendorForOrderMainEnglish.TabIndex = 0
        '
        'txtPersonName
        '
        Me.txtPersonName.Location = New System.Drawing.Point(161, 32)
        Me.txtPersonName.Multiline = True
        Me.txtPersonName.Name = "txtPersonName"
        Me.txtPersonName.ReadOnly = True
        Me.txtPersonName.Size = New System.Drawing.Size(207, 49)
        Me.txtPersonName.TabIndex = 273
        '
        'txtOrderNo
        '
        Me.txtOrderNo.Location = New System.Drawing.Point(161, 104)
        Me.txtOrderNo.Name = "txtOrderNo"
        Me.txtOrderNo.ReadOnly = True
        Me.txtOrderNo.Size = New System.Drawing.Size(207, 21)
        Me.txtOrderNo.TabIndex = 272
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.lblMessage)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 222)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(646, 34)
        Me.Panel2.TabIndex = 271
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.GreenYellow
        Me.lblMessage.Location = New System.Drawing.Point(199, 12)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblMessage.Size = New System.Drawing.Size(16, 15)
        Me.lblMessage.TabIndex = 288
        Me.lblMessage.Text = "..."
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AllowItemReorder = True
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripButton5, Me.ToolStripButton3, Me.ToolStripButton4})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 12)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(643, 23)
        Me.ToolStrip1.TabIndex = 245
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton2.Size = New System.Drawing.Size(77, 20)
        Me.ToolStripButton2.Text = "Move First"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton5.Size = New System.Drawing.Size(76, 20)
        Me.ToolStripButton5.Text = "Move Last"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton3.Size = New System.Drawing.Size(79, 20)
        Me.ToolStripButton3.Text = "Move Next"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton4.Size = New System.Drawing.Size(97, 20)
        Me.ToolStripButton4.Text = "Move Previoce"
        '
        'dtReqDate
        '
        Me.dtReqDate.CustomFormat = "dd/MM/yy"
        Me.dtReqDate.Enabled = False
        Me.dtReqDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtReqDate.Location = New System.Drawing.Point(463, 57)
        Me.dtReqDate.Name = "dtReqDate"
        Me.dtReqDate.Size = New System.Drawing.Size(155, 21)
        Me.dtReqDate.TabIndex = 2
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(30, 105)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(60, 16)
        Me.Label25.TabIndex = 263
        Me.Label25.Text = "Order No"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(374, 61)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(89, 16)
        Me.Label24.TabIndex = 262
        Me.Label24.Text = "Required Date"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(374, 39)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(71, 16)
        Me.Label23.TabIndex = 261
        Me.Label23.Text = "Order Date"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(30, 31)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(135, 16)
        Me.Label22.TabIndex = 260
        Me.Label22.Text = "Concern Person Name" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'DG
        '
        Me.DG.AllowUserToResizeColumns = False
        Me.DG.AllowUserToResizeRows = False
        Me.DG.BackgroundColor = System.Drawing.Color.White
        Me.DG.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.DG.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGSNo, Me.DGPType, Me.DGcmbProductCode, Me.DGProductName, Me.DGID, Me.DGQty, Me.DGDecription})
        Me.DG.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DG.Location = New System.Drawing.Point(3, 256)
        Me.DG.Name = "DG"
        Me.DG.ReadOnly = True
        Me.DG.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.DG.Size = New System.Drawing.Size(646, 198)
        Me.DG.TabIndex = 5
        '
        'DGSNo
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.DGSNo.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGSNo.HeaderText = "SNO"
        Me.DGSNo.Name = "DGSNo"
        Me.DGSNo.ReadOnly = True
        Me.DGSNo.Width = 60
        '
        'DGPType
        '
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.DGPType.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGPType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.DGPType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.DGPType.HeaderText = "Product Type"
        Me.DGPType.Name = "DGPType"
        Me.DGPType.ReadOnly = True
        Me.DGPType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGPType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DGPType.Width = 150
        '
        'DGcmbProductCode
        '
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.DGcmbProductCode.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGcmbProductCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.DGcmbProductCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.DGcmbProductCode.HeaderText = "List Of Products"
        Me.DGcmbProductCode.Name = "DGcmbProductCode"
        Me.DGcmbProductCode.ReadOnly = True
        Me.DGcmbProductCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGcmbProductCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DGcmbProductCode.Width = 150
        '
        'DGProductName
        '
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.DGProductName.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGProductName.HeaderText = "Product Name"
        Me.DGProductName.Name = "DGProductName"
        Me.DGProductName.ReadOnly = True
        '
        'DGID
        '
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.DGID.DefaultCellStyle = DataGridViewCellStyle5
        Me.DGID.HeaderText = "ID"
        Me.DGID.Name = "DGID"
        Me.DGID.ReadOnly = True
        Me.DGID.Visible = False
        '
        'DGQty
        '
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.DGQty.DefaultCellStyle = DataGridViewCellStyle6
        Me.DGQty.HeaderText = "Quantity"
        Me.DGQty.Name = "DGQty"
        Me.DGQty.ReadOnly = True
        Me.DGQty.Width = 60
        '
        'DGDecription
        '
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        Me.DGDecription.DefaultCellStyle = DataGridViewCellStyle7
        Me.DGDecription.HeaderText = "Description"
        Me.DGDecription.Name = "DGDecription"
        Me.DGDecription.ReadOnly = True
        Me.DGDecription.Width = 250
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(30, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 16)
        Me.Label6.TabIndex = 252
        Me.Label6.Text = "Company Name"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(161, 126)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.ReadOnly = True
        Me.txtRemarks.Size = New System.Drawing.Size(457, 21)
        Me.txtRemarks.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(30, 127)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 16)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Remarks"
        '
        'dtOrderDate
        '
        Me.dtOrderDate.CustomFormat = "dd/MM/yy"
        Me.dtOrderDate.Enabled = False
        Me.dtOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtOrderDate.Location = New System.Drawing.Point(463, 35)
        Me.dtOrderDate.Name = "dtOrderDate"
        Me.dtOrderDate.Size = New System.Drawing.Size(155, 21)
        Me.dtOrderDate.TabIndex = 1
        '
        'CM
        '
        Me.CM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CM.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuSearch, Me.MnuReturn, Me.MnuNew, Me.MnuSave, Me.MnuUndo, Me.MnuEdit, Me.MnuDelete, Me.MnuExit})
        Me.CM.Name = "ContextMenuStrip1"
        Me.CM.Size = New System.Drawing.Size(157, 180)
        '
        'MnuSearch
        '
        Me.MnuSearch.BackColor = System.Drawing.Color.White
        Me.MnuSearch.Image = CType(resources.GetObject("MnuSearch.Image"), System.Drawing.Image)
        Me.MnuSearch.Name = "MnuSearch"
        Me.MnuSearch.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.MnuSearch.Size = New System.Drawing.Size(156, 22)
        Me.MnuSearch.Text = "&Search"
        '
        'MnuReturn
        '
        Me.MnuReturn.BackColor = System.Drawing.Color.White
        Me.MnuReturn.Image = CType(resources.GetObject("MnuReturn.Image"), System.Drawing.Image)
        Me.MnuReturn.Name = "MnuReturn"
        Me.MnuReturn.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.MnuReturn.Size = New System.Drawing.Size(156, 22)
        Me.MnuReturn.Text = "&Return"
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
        Me.MnuExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.MnuExit.Size = New System.Drawing.Size(156, 22)
        Me.MnuExit.Text = "&Exit"
        '
        'OFD
        '
        Me.OFD.FileName = "OpenFileDialog1"
        '
        'frmOderEnglish
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(760, 604)
        Me.ContextMenuStrip = Me.CM
        Me.Controls.Add(Me.pnlcentre)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmOderEnglish"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmOderEnglish"
        Me.pnlcentre.ResumeLayout(False)
        Me.pnlcentre.PerformLayout()
        Me.TB1.ResumeLayout(False)
        Me.TP1.ResumeLayout(False)
        Me.TP1.PerformLayout()
        CType(Me.InvProfPB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CM.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlcentre As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TB1 As System.Windows.Forms.TabControl
    Friend WithEvents TP1 As System.Windows.Forms.TabPage
    Friend WithEvents txtPersonName As System.Windows.Forms.TextBox
    Friend WithEvents txtOrderNo As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents dtReqDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtOrderDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents CM As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MnuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents cmbVendorForOrderMainEnglish As System.Windows.Forms.ComboBox
    Friend WithEvents DGSNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGPType As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGcmbProductCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGProductName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGDecription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtJobTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbOrderNoSearch As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuReturn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbCompanySearch As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LnkInvoiceProforma As System.Windows.Forms.LinkLabel
    Friend WithEvents InvProfPB As System.Windows.Forms.PictureBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents OFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents chkSaveInvoiceProforma As System.Windows.Forms.CheckBox
End Class
