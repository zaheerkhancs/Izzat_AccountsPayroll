<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIncomeStatment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmIncomeStatment))
        Me.PanDate = New System.Windows.Forms.Panel
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.DtDate2 = New System.Windows.Forms.DateTimePicker
        Me.DtDate1 = New System.Windows.Forms.DateTimePicker
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.CV = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.PanDate.SuspendLayout()
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
        Me.PanDate.Location = New System.Drawing.Point(0, 32)
        Me.PanDate.Name = "PanDate"
        Me.PanDate.Size = New System.Drawing.Size(735, 41)
        Me.PanDate.TabIndex = 16
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(660, 0)
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
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.Transparent
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(735, 32)
        Me.PanelTop.TabIndex = 15
        '
        'CV
        '
        Me.CV.ActiveViewIndex = -1
        Me.CV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CV.Location = New System.Drawing.Point(0, 73)
        Me.CV.Name = "CV"
        Me.CV.SelectionFormula = ""
        Me.CV.Size = New System.Drawing.Size(735, 417)
        Me.CV.TabIndex = 17
        Me.CV.ViewTimeSelectionFormula = ""
        '
        'FrmIncomeStatment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(735, 490)
        Me.Controls.Add(Me.CV)
        Me.Controls.Add(Me.PanDate)
        Me.Controls.Add(Me.PanelTop)
        Me.Name = "FrmIncomeStatment"
        Me.Text = "FrmIncomeStatment"
        Me.PanDate.ResumeLayout(False)
        Me.PanDate.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanDate As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DtDate2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtDate1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents CV As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
