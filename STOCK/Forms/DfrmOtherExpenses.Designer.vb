<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DfrmOtherExpenses
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtPayment = New System.Windows.Forms.DateTimePicker
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnPay = New System.Windows.Forms.Button
        Me.txtInvoice = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.DGDiag = New System.Windows.Forms.DataGridView
        Me.DGDiagSNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGDesc = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DGDiagAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DG = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtExpenseType = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.DGDiag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(312, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 16)
        Me.Label2.TabIndex = 292
        Me.Label2.Text = "تاریخ پرداخت"
        '
        'dtPayment
        '
        Me.dtPayment.CustomFormat = "dd/MM/yyyy"
        Me.dtPayment.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPayment.Location = New System.Drawing.Point(12, 72)
        Me.dtPayment.Name = "dtPayment"
        Me.dtPayment.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtPayment.Size = New System.Drawing.Size(192, 21)
        Me.dtPayment.TabIndex = 291
        '
        'btnCancel
        '
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(12, 351)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(156, 23)
        Me.btnCancel.TabIndex = 290
        Me.btnCancel.Text = "خروج"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnPay
        '
        Me.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnPay.ForeColor = System.Drawing.Color.White
        Me.btnPay.Location = New System.Drawing.Point(237, 351)
        Me.btnPay.Name = "btnPay"
        Me.btnPay.Size = New System.Drawing.Size(156, 23)
        Me.btnPay.TabIndex = 289
        Me.btnPay.Text = "پرداخت"
        Me.btnPay.UseVisualStyleBackColor = True
        '
        'txtInvoice
        '
        Me.txtInvoice.BackColor = System.Drawing.Color.White
        Me.txtInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoice.Enabled = False
        Me.txtInvoice.Location = New System.Drawing.Point(12, 25)
        Me.txtInvoice.Name = "txtInvoice"
        Me.txtInvoice.Size = New System.Drawing.Size(192, 21)
        Me.txtInvoice.TabIndex = 286
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(281, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 16)
        Me.Label1.TabIndex = 285
        Me.Label1.Text = "شمارهُ درج انوایس"
        '
        'txtTotal
        '
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(12, 48)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTotal.Size = New System.Drawing.Size(192, 21)
        Me.txtTotal.TabIndex = 283
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(337, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 16)
        Me.Label4.TabIndex = 281
        Me.Label4.Text = "جمع کل"
        '
        'DGDiag
        '
        Me.DGDiag.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGDiag.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGDiag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGDiag.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGDiagSNo, Me.DGDesc, Me.DGDiagAmount, Me.DG})
        Me.DGDiag.Location = New System.Drawing.Point(0, 133)
        Me.DGDiag.Name = "DGDiag"
        Me.DGDiag.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGDiag.Size = New System.Drawing.Size(405, 212)
        Me.DGDiag.TabIndex = 280
        '
        'DGDiagSNo
        '
        Me.DGDiagSNo.HeaderText = "شماره"
        Me.DGDiagSNo.Name = "DGDiagSNo"
        Me.DGDiagSNo.ReadOnly = True
        Me.DGDiagSNo.Width = 60
        '
        'DGDesc
        '
        Me.DGDesc.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.DGDesc.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.DGDesc.HeaderText = "اقسام اخرجات"
        Me.DGDesc.Name = "DGDesc"
        Me.DGDesc.Width = 160
        '
        'DGDiagAmount
        '
        Me.DGDiagAmount.HeaderText = "مقدار"
        Me.DGDiagAmount.Name = "DGDiagAmount"
        '
        'DG
        '
        Me.DG.HeaderText = "ID"
        Me.DG.Name = "DG"
        Me.DG.Visible = False
        '
        'txtExpenseType
        '
        Me.txtExpenseType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExpenseType.Location = New System.Drawing.Point(12, 96)
        Me.txtExpenseType.Name = "txtExpenseType"
        Me.txtExpenseType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtExpenseType.Size = New System.Drawing.Size(192, 21)
        Me.txtExpenseType.TabIndex = 293
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(312, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 16)
        Me.Label3.TabIndex = 294
        Me.Label3.Text = "نوع اخراجات"
        '
        'DfrmOtherExpenses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(405, 386)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtExpenseType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtPayment)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnPay)
        Me.Controls.Add(Me.txtInvoice)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DGDiag)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DfrmOtherExpenses"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DfrmOtherExpenses"
        CType(Me.DGDiag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtPayment As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnPay As System.Windows.Forms.Button
    Friend WithEvents txtInvoice As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DGDiag As System.Windows.Forms.DataGridView
    Friend WithEvents txtExpenseType As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DGDiagSNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGDesc As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DGDiagAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DG As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
