<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCompany
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCompany))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.DtTo = New System.Windows.Forms.DateTimePicker
        Me.ChkIsCurrent = New System.Windows.Forms.CheckBox
        Me.DtFrom = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtID = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtRemarks = New System.Windows.Forms.TextBox
        Me.TxtCompanyID = New System.Windows.Forms.TextBox
        Me.TxtName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ContextM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuSave = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemUndo = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextM.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.TxtRemarks)
        Me.GroupBox1.Controls.Add(Me.TxtCompanyID)
        Me.GroupBox1.Controls.Add(Me.TxtName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.GroupBox1.Location = New System.Drawing.Point(47, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(658, 341)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Company Information"
        Me.ToolTip1.SetToolTip(Me.GroupBox1, "Company Information")
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(347, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(195, 14)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "(will be occur on account period start.)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(484, 102)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(139, 14)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "(will be display on Reports)"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.PictureBox2)
        Me.GroupBox2.Controls.Add(Me.DtTo)
        Me.GroupBox2.Controls.Add(Me.ChkIsCurrent)
        Me.GroupBox2.Controls.Add(Me.DtFrom)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.TxtID)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.GroupBox2.Location = New System.Drawing.Point(87, 137)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(408, 188)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Financial Period"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(95, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(302, 35)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "You must define the financial period here."
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(18, 13)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(53, 44)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 45
        Me.PictureBox2.TabStop = False
        '
        'DtTo
        '
        Me.DtTo.Enabled = False
        Me.DtTo.Location = New System.Drawing.Point(151, 133)
        Me.DtTo.Name = "DtTo"
        Me.DtTo.Size = New System.Drawing.Size(236, 22)
        Me.DtTo.TabIndex = 44
        '
        'ChkIsCurrent
        '
        Me.ChkIsCurrent.AutoSize = True
        Me.ChkIsCurrent.Enabled = False
        Me.ChkIsCurrent.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkIsCurrent.ForeColor = System.Drawing.Color.White
        Me.ChkIsCurrent.Location = New System.Drawing.Point(151, 160)
        Me.ChkIsCurrent.Name = "ChkIsCurrent"
        Me.ChkIsCurrent.Size = New System.Drawing.Size(82, 18)
        Me.ChkIsCurrent.TabIndex = 43
        Me.ChkIsCurrent.Text = "Is Current"
        Me.ToolTip1.SetToolTip(Me.ChkIsCurrent, "Is Current")
        Me.ChkIsCurrent.UseVisualStyleBackColor = True
        '
        'DtFrom
        '
        Me.DtFrom.Enabled = False
        Me.DtFrom.Location = New System.Drawing.Point(151, 101)
        Me.DtFrom.Name = "DtFrom"
        Me.DtFrom.Size = New System.Drawing.Size(236, 22)
        Me.DtFrom.TabIndex = 42
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(85, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "To Date"
        Me.ToolTip1.SetToolTip(Me.Label4, "End Date")
        '
        'TxtID
        '
        Me.TxtID.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtID.Enabled = False
        Me.TxtID.Location = New System.Drawing.Point(152, 69)
        Me.TxtID.Name = "TxtID"
        Me.TxtID.Size = New System.Drawing.Size(235, 22)
        Me.TxtID.TabIndex = 40
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(79, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "From Date"
        Me.ToolTip1.SetToolTip(Me.Label6, "Start Date")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(51, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 13)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Account Period ID"
        '
        'TxtRemarks
        '
        Me.TxtRemarks.BackColor = System.Drawing.Color.White
        Me.TxtRemarks.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemarks.ForeColor = System.Drawing.Color.Black
        Me.TxtRemarks.Location = New System.Drawing.Point(143, 95)
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.ReadOnly = True
        Me.TxtRemarks.Size = New System.Drawing.Size(326, 29)
        Me.TxtRemarks.TabIndex = 8
        Me.TxtRemarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtCompanyID
        '
        Me.TxtCompanyID.BackColor = System.Drawing.Color.White
        Me.TxtCompanyID.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCompanyID.ForeColor = System.Drawing.Color.Black
        Me.TxtCompanyID.Location = New System.Drawing.Point(143, 22)
        Me.TxtCompanyID.MaxLength = 24
        Me.TxtCompanyID.Name = "TxtCompanyID"
        Me.TxtCompanyID.ReadOnly = True
        Me.TxtCompanyID.Size = New System.Drawing.Size(120, 22)
        Me.TxtCompanyID.TabIndex = 9
        Me.TxtCompanyID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtName
        '
        Me.TxtName.BackColor = System.Drawing.Color.White
        Me.TxtName.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtName.ForeColor = System.Drawing.Color.Black
        Me.TxtName.Location = New System.Drawing.Point(142, 52)
        Me.TxtName.MaxLength = 20
        Me.TxtName.Name = "TxtName"
        Me.TxtName.ReadOnly = True
        Me.TxtName.Size = New System.Drawing.Size(199, 29)
        Me.TxtName.TabIndex = 7
        Me.TxtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(7, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Company Full Name"
        Me.ToolTip1.SetToolTip(Me.Label3, "Company full Name")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(7, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Company Name"
        Me.ToolTip1.SetToolTip(Me.Label2, "Company Name")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(7, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Company ID"
        Me.ToolTip1.SetToolTip(Me.Label1, "Company ID")
        '
        'ContextM
        '
        Me.ContextM.BackgroundImage = CType(resources.GetObject("ContextM.BackgroundImage"), System.Drawing.Image)
        Me.ContextM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ContextM.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.ToolStripMenuSave, Me.ToolStripMenuEdit, Me.ToolStripMenuItemUndo, Me.ExitToolStripMenuItem})
        Me.ContextM.Name = "ContextMenuStrip1"
        Me.ContextM.Size = New System.Drawing.Size(138, 114)
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Image = CType(resources.GetObject("NewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.NewToolStripMenuItem.Text = "&New"
        '
        'ToolStripMenuSave
        '
        Me.ToolStripMenuSave.Enabled = False
        Me.ToolStripMenuSave.Image = CType(resources.GetObject("ToolStripMenuSave.Image"), System.Drawing.Image)
        Me.ToolStripMenuSave.ImageTransparentColor = System.Drawing.Color.Black
        Me.ToolStripMenuSave.Name = "ToolStripMenuSave"
        Me.ToolStripMenuSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.ToolStripMenuSave.Size = New System.Drawing.Size(137, 22)
        Me.ToolStripMenuSave.Text = "&Save"
        '
        'ToolStripMenuEdit
        '
        Me.ToolStripMenuEdit.Image = CType(resources.GetObject("ToolStripMenuEdit.Image"), System.Drawing.Image)
        Me.ToolStripMenuEdit.Name = "ToolStripMenuEdit"
        Me.ToolStripMenuEdit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.ToolStripMenuEdit.Size = New System.Drawing.Size(137, 22)
        Me.ToolStripMenuEdit.Text = "E&dit"
        '
        'ToolStripMenuItemUndo
        '
        Me.ToolStripMenuItemUndo.Enabled = False
        Me.ToolStripMenuItemUndo.Image = CType(resources.GetObject("ToolStripMenuItemUndo.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemUndo.ImageTransparentColor = System.Drawing.Color.Black
        Me.ToolStripMenuItemUndo.Name = "ToolStripMenuItemUndo"
        Me.ToolStripMenuItemUndo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.ToolStripMenuItemUndo.Size = New System.Drawing.Size(137, 22)
        Me.ToolStripMenuItemUndo.Text = "&Undo"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 347)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(753, 55)
        Me.Panel2.TabIndex = 2
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AllowItemReorder = True
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.White
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripButton5, Me.ToolStripButton4, Me.ToolStripButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(749, 23)
        Me.ToolStrip1.TabIndex = 244
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton2.Size = New System.Drawing.Size(75, 20)
        Me.ToolStripButton2.Text = "Move first"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton5.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton5.Size = New System.Drawing.Size(73, 20)
        Me.ToolStripButton5.Text = "Move last"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton4.Size = New System.Drawing.Size(97, 20)
        Me.ToolStripButton4.Text = "Move previous"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton3.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton3.Size = New System.Drawing.Size(78, 20)
        Me.ToolStripButton3.Text = "Move next"
        '
        'FrmCompany
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Navy
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(753, 402)
        Me.ContextMenuStrip = Me.ContextM
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmCompany"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmCompany"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextM.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents TxtCompanyID As System.Windows.Forms.TextBox
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents DtTo As System.Windows.Forms.DateTimePicker
    Public WithEvents ChkIsCurrent As System.Windows.Forms.CheckBox
    Friend WithEvents DtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtID As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ContextM As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
