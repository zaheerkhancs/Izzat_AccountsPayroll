<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DfrmGoDownForReport
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPhoneReport = New System.Windows.Forms.TextBox
        Me.txtConcernPReport = New System.Windows.Forms.TextBox
        Me.cmbGoDownReport = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(62, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(179, 24)
        Me.Label1.TabIndex = 317
        Me.Label1.Text = "مقدمات گزارش های گدام ها"
        '
        'txtPhoneReport
        '
        Me.txtPhoneReport.Location = New System.Drawing.Point(25, 149)
        Me.txtPhoneReport.Name = "txtPhoneReport"
        Me.txtPhoneReport.ReadOnly = True
        Me.txtPhoneReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPhoneReport.Size = New System.Drawing.Size(171, 21)
        Me.txtPhoneReport.TabIndex = 330
        '
        'txtConcernPReport
        '
        Me.txtConcernPReport.Location = New System.Drawing.Point(25, 121)
        Me.txtConcernPReport.Name = "txtConcernPReport"
        Me.txtConcernPReport.ReadOnly = True
        Me.txtConcernPReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtConcernPReport.Size = New System.Drawing.Size(171, 21)
        Me.txtConcernPReport.TabIndex = 329
        '
        'cmbGoDownReport
        '
        Me.cmbGoDownReport.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbGoDownReport.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbGoDownReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGoDownReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbGoDownReport.FormattingEnabled = True
        Me.cmbGoDownReport.Location = New System.Drawing.Point(25, 89)
        Me.cmbGoDownReport.Name = "cmbGoDownReport"
        Me.cmbGoDownReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbGoDownReport.Size = New System.Drawing.Size(171, 21)
        Me.cmbGoDownReport.TabIndex = 328
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(229, 156)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 327
        Me.Label5.Text = "شماره تماس"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(204, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 13)
        Me.Label4.TabIndex = 326
        Me.Label4.Text = "اسم شخص مسول"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(233, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 325
        Me.Label3.Text = "اسم گدام"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(73, 200)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 332
        Me.btnCancel.Text = "لغو"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Transparent
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOK.ForeColor = System.Drawing.Color.White
        Me.btnOK.Location = New System.Drawing.Point(164, 200)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 331
        Me.btnOK.Text = "درج"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'DfrmGoDownForReport
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Teal
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(307, 255)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtPhoneReport)
        Me.Controls.Add(Me.txtConcernPReport)
        Me.Controls.Add(Me.cmbGoDownReport)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DfrmGoDownForReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DfrmGoDownForReport"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPhoneReport As System.Windows.Forms.TextBox
    Friend WithEvents txtConcernPReport As System.Windows.Forms.TextBox
    Friend WithEvents cmbGoDownReport As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
