<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCashBook
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCashBook))
        Me.PanDate = New System.Windows.Forms.Panel
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.DtDate2 = New System.Windows.Forms.DateTimePicker
        Me.DtDate1 = New System.Windows.Forms.DateTimePicker
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.BtnHeads = New System.Windows.Forms.Button
        Me.CmbHeads = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtHead2 = New System.Windows.Forms.DateTimePicker
        Me.DtHead1 = New System.Windows.Forms.DateTimePicker
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RBDate = New System.Windows.Forms.RadioButton
        Me.RBHeads = New System.Windows.Forms.RadioButton
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.CV = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.PanDate.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanDate
        '
        Me.PanDate.BackColor = System.Drawing.Color.Transparent
        Me.PanDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanDate.Controls.Add(Me.Button1)
        Me.PanDate.Controls.Add(Me.Label5)
        Me.PanDate.Controls.Add(Me.Label6)
        Me.PanDate.Controls.Add(Me.DtDate2)
        Me.PanDate.Controls.Add(Me.DtDate1)
        Me.PanDate.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanDate.Location = New System.Drawing.Point(0, 143)
        Me.PanDate.Name = "PanDate"
        Me.PanDate.Size = New System.Drawing.Size(807, 41)
        Me.PanDate.TabIndex = 18
        Me.PanDate.Visible = False
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.Location = New System.Drawing.Point(732, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(73, 39)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Preview"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(332, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "To Date"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(129, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "From Date"
        '
        'DtDate2
        '
        Me.DtDate2.CustomFormat = "dd/MM/yyyy"
        Me.DtDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtDate2.Location = New System.Drawing.Point(391, 9)
        Me.DtDate2.Name = "DtDate2"
        Me.DtDate2.Size = New System.Drawing.Size(99, 20)
        Me.DtDate2.TabIndex = 1
        '
        'DtDate1
        '
        Me.DtDate1.CustomFormat = "dd/MM/yyyy"
        Me.DtDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtDate1.Location = New System.Drawing.Point(196, 9)
        Me.DtDate1.Name = "DtDate1"
        Me.DtDate1.Size = New System.Drawing.Size(99, 20)
        Me.DtDate1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.BtnHeads)
        Me.Panel2.Controls.Add(Me.CmbHeads)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.DtHead2)
        Me.Panel2.Controls.Add(Me.DtHead1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 102)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(807, 41)
        Me.Panel2.TabIndex = 17
        Me.Panel2.Visible = False
        '
        'BtnHeads
        '
        Me.BtnHeads.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnHeads.Image = CType(resources.GetObject("BtnHeads.Image"), System.Drawing.Image)
        Me.BtnHeads.Location = New System.Drawing.Point(732, 0)
        Me.BtnHeads.Name = "BtnHeads"
        Me.BtnHeads.Size = New System.Drawing.Size(73, 39)
        Me.BtnHeads.TabIndex = 6
        Me.BtnHeads.Text = "Preview"
        Me.BtnHeads.UseVisualStyleBackColor = True
        '
        'CmbHeads
        '
        Me.CmbHeads.FormattingEnabled = True
        Me.CmbHeads.Location = New System.Drawing.Point(77, 12)
        Me.CmbHeads.Name = "CmbHeads"
        Me.CmbHeads.Size = New System.Drawing.Size(240, 21)
        Me.CmbHeads.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(8, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Head Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(516, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "To Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(349, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "From Date"
        '
        'DtHead2
        '
        Me.DtHead2.CustomFormat = "dd/MM/yyyy"
        Me.DtHead2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtHead2.Location = New System.Drawing.Point(568, 12)
        Me.DtHead2.Name = "DtHead2"
        Me.DtHead2.Size = New System.Drawing.Size(99, 20)
        Me.DtHead2.TabIndex = 1
        '
        'DtHead1
        '
        Me.DtHead1.CustomFormat = "dd/MM/yyyy"
        Me.DtHead1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtHead1.Location = New System.Drawing.Point(411, 12)
        Me.DtHead1.Name = "DtHead1"
        Me.DtHead1.Size = New System.Drawing.Size(99, 20)
        Me.DtHead1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.RBDate)
        Me.Panel1.Controls.Add(Me.RBHeads)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 61)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(807, 41)
        Me.Panel1.TabIndex = 16
        '
        'RBDate
        '
        Me.RBDate.AutoSize = True
        Me.RBDate.ForeColor = System.Drawing.Color.White
        Me.RBDate.Location = New System.Drawing.Point(359, 5)
        Me.RBDate.Name = "RBDate"
        Me.RBDate.Size = New System.Drawing.Size(117, 17)
        Me.RBDate.TabIndex = 2
        Me.RBDate.TabStop = True
        Me.RBDate.Text = "Cash book By Date"
        Me.RBDate.UseVisualStyleBackColor = True
        '
        'RBHeads
        '
        Me.RBHeads.AutoSize = True
        Me.RBHeads.ForeColor = System.Drawing.Color.White
        Me.RBHeads.Location = New System.Drawing.Point(90, 5)
        Me.RBHeads.Name = "RBHeads"
        Me.RBHeads.Size = New System.Drawing.Size(125, 17)
        Me.RBHeads.TabIndex = 1
        Me.RBHeads.TabStop = True
        Me.RBHeads.Text = "Cash book By Heads"
        Me.RBHeads.UseVisualStyleBackColor = True
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.Transparent
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(807, 61)
        Me.PanelTop.TabIndex = 15
        '
        'CV
        '
        Me.CV.ActiveViewIndex = -1
        Me.CV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CV.Location = New System.Drawing.Point(0, 184)
        Me.CV.Name = "CV"
        Me.CV.SelectionFormula = ""
        Me.CV.Size = New System.Drawing.Size(807, 390)
        Me.CV.TabIndex = 19
        Me.CV.ViewTimeSelectionFormula = ""
        '
        'FrmCashBook
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(807, 574)
        Me.Controls.Add(Me.CV)
        Me.Controls.Add(Me.PanDate)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelTop)
        Me.Name = "FrmCashBook"
        Me.Text = "frmCashBook"
        Me.PanDate.ResumeLayout(False)
        Me.PanDate.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanDate As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DtDate2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtDate1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnHeads As System.Windows.Forms.Button
    Public WithEvents CmbHeads As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtHead2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtHead1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RBDate As System.Windows.Forms.RadioButton
    Friend WithEvents RBHeads As System.Windows.Forms.RadioButton
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents CV As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
