<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSalePaymentDialogueBox
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DGDiag = New System.Windows.Forms.DataGridView
        Me.DGDiagSNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGDiagAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGDiagDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtInvoice = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTotalPaid = New System.Windows.Forms.TextBox
        Me.txtBalance = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTotalToPay = New System.Windows.Forms.TextBox
        Me.btnClose = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.DTPaymentDate = New System.Windows.Forms.DateTimePicker
        Me.btnExit = New System.Windows.Forms.Button
        CType(Me.DGDiag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGDiag
        '
        Me.DGDiag.BackgroundColor = System.Drawing.Color.Silver
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGDiag.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGDiag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGDiag.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGDiagSNo, Me.DGDiagAmount, Me.DGDiagDate})
        Me.DGDiag.Location = New System.Drawing.Point(0, 138)
        Me.DGDiag.Name = "DGDiag"
        Me.DGDiag.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGDiag.Size = New System.Drawing.Size(403, 174)
        Me.DGDiag.TabIndex = 0
        '
        'DGDiagSNo
        '
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.DGDiagSNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGDiagSNo.HeaderText = "شماره"
        Me.DGDiagSNo.Name = "DGDiagSNo"
        Me.DGDiagSNo.ReadOnly = True
        Me.DGDiagSNo.Width = 60
        '
        'DGDiagAmount
        '
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.DGDiagAmount.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGDiagAmount.HeaderText = "مقدار"
        Me.DGDiagAmount.Name = "DGDiagAmount"
        Me.DGDiagAmount.Width = 150
        '
        'DGDiagDate
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.Format = "dd/MM/yyyy"
        DataGridViewCellStyle4.NullValue = "01/01/1900"
        Me.DGDiagDate.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGDiagDate.HeaderText = "تاریخ"
        Me.DGDiagDate.Name = "DGDiagDate"
        Me.DGDiagDate.ReadOnly = True
        Me.DGDiagDate.Width = 150
        '
        'txtInvoice
        '
        Me.txtInvoice.BackColor = System.Drawing.Color.White
        Me.txtInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoice.Enabled = False
        Me.txtInvoice.Location = New System.Drawing.Point(12, 10)
        Me.txtInvoice.Name = "txtInvoice"
        Me.txtInvoice.Size = New System.Drawing.Size(159, 20)
        Me.txtInvoice.TabIndex = 257
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(223, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 16)
        Me.Label1.TabIndex = 256
        Me.Label1.Text = "شمارهُ درج (انوایس)"
        '
        'txtTotalPaid
        '
        Me.txtTotalPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPaid.Enabled = False
        Me.txtTotalPaid.Location = New System.Drawing.Point(12, 61)
        Me.txtTotalPaid.Name = "txtTotalPaid"
        Me.txtTotalPaid.ReadOnly = True
        Me.txtTotalPaid.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTotalPaid.Size = New System.Drawing.Size(159, 20)
        Me.txtTotalPaid.TabIndex = 255
        '
        'txtBalance
        '
        Me.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBalance.Enabled = False
        Me.txtBalance.Location = New System.Drawing.Point(12, 87)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBalance.Size = New System.Drawing.Size(159, 20)
        Me.txtBalance.TabIndex = 254
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(202, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(139, 16)
        Me.Label7.TabIndex = 253
        Me.Label7.Text = "مقدار پول پذرداخته شده"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(304, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 16)
        Me.Label4.TabIndex = 252
        Me.Label4.Text = "میزان"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(227, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 16)
        Me.Label5.TabIndex = 260
        Me.Label5.Text = "مقدار پول قابل تادیه"
        '
        'txtTotalToPay
        '
        Me.txtTotalToPay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalToPay.Location = New System.Drawing.Point(12, 35)
        Me.txtTotalToPay.Name = "txtTotalToPay"
        Me.txtTotalToPay.ReadOnly = True
        Me.txtTotalToPay.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTotalToPay.Size = New System.Drawing.Size(159, 20)
        Me.txtTotalToPay.TabIndex = 266
        '
        'btnClose
        '
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnClose.Location = New System.Drawing.Point(230, 318)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(161, 23)
        Me.btnClose.TabIndex = 267
        Me.btnClose.Text = "پرداخت"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(264, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 16)
        Me.Label2.TabIndex = 281
        Me.Label2.Text = "تاریخ پرداخت"
        '
        'DTPaymentDate
        '
        Me.DTPaymentDate.CustomFormat = "dd/MM/yy"
        Me.DTPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPaymentDate.Location = New System.Drawing.Point(12, 112)
        Me.DTPaymentDate.Name = "DTPaymentDate"
        Me.DTPaymentDate.Size = New System.Drawing.Size(159, 20)
        Me.DTPaymentDate.TabIndex = 280
        '
        'btnExit
        '
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnExit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnExit.Location = New System.Drawing.Point(12, 318)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(161, 23)
        Me.btnExit.TabIndex = 282
        Me.btnExit.Text = "خروج"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'FrmSalePaymentDialogueBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(403, 353)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DTPaymentDate)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtTotalToPay)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtInvoice)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTotalPaid)
        Me.Controls.Add(Me.txtBalance)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DGDiag)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmSalePaymentDialogueBox"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Text = "   محل پرداخت   "
        CType(Me.DGDiag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGDiag As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents txtTotalToPay As System.Windows.Forms.TextBox
    Public WithEvents txtTotalPaid As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Public WithEvents txtInvoice As System.Windows.Forms.TextBox
    Public WithEvents txtBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DTPaymentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents DGDiagSNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGDiagAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGDiagDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnExit As System.Windows.Forms.Button
End Class
