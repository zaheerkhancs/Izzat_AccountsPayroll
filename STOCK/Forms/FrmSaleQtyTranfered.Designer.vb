<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSaleQtyTranfered
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
        Me.DGTransfer = New System.Windows.Forms.DataGridView
        Me.DGTransferredSNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGTransferredQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGTransferredDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtQtyTransferredDate = New System.Windows.Forms.DateTimePicker
        Me.btnClose = New System.Windows.Forms.Button
        Me.txtProdName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtProdType = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTotalQty = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtTransferredQty = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtRemainingQty = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.txtRemainingStock = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtRemainingStockPcs = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        CType(Me.DGTransfer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGTransfer
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGTransfer.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGTransfer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGTransfer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGTransferredSNo, Me.DGTransferredQty, Me.DGTransferredDate})
        Me.DGTransfer.Location = New System.Drawing.Point(2, 163)
        Me.DGTransfer.Name = "DGTransfer"
        Me.DGTransfer.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGTransfer.Size = New System.Drawing.Size(444, 193)
        Me.DGTransfer.TabIndex = 0
        '
        'DGTransferredSNo
        '
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.DGTransferredSNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGTransferredSNo.HeaderText = "شماره"
        Me.DGTransferredSNo.Name = "DGTransferredSNo"
        Me.DGTransferredSNo.ReadOnly = True
        Me.DGTransferredSNo.Width = 60
        '
        'DGTransferredQty
        '
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.DGTransferredQty.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGTransferredQty.HeaderText = "مقدار مال"
        Me.DGTransferredQty.Name = "DGTransferredQty"
        Me.DGTransferredQty.Width = 150
        '
        'DGTransferredDate
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.Format = "dd/MM/yyyy"
        DataGridViewCellStyle4.NullValue = "01/01/1900"
        Me.DGTransferredDate.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGTransferredDate.HeaderText = "تاریخ"
        Me.DGTransferredDate.Name = "DGTransferredDate"
        Me.DGTransferredDate.ReadOnly = True
        Me.DGTransferredDate.Width = 140
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(357, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 16)
        Me.Label2.TabIndex = 290
        Me.Label2.Text = "تاریخ پرانتقال"
        '
        'dtQtyTransferredDate
        '
        Me.dtQtyTransferredDate.CustomFormat = "dd/MM/yy"
        Me.dtQtyTransferredDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtQtyTransferredDate.Location = New System.Drawing.Point(228, 68)
        Me.dtQtyTransferredDate.Name = "dtQtyTransferredDate"
        Me.dtQtyTransferredDate.Size = New System.Drawing.Size(123, 20)
        Me.dtQtyTransferredDate.TabIndex = 289
        '
        'btnClose
        '
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnClose.Location = New System.Drawing.Point(260, 362)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(141, 23)
        Me.btnClose.TabIndex = 288
        Me.btnClose.Text = "انتقال"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtProdName
        '
        Me.txtProdName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProdName.Location = New System.Drawing.Point(3, 25)
        Me.txtProdName.Name = "txtProdName"
        Me.txtProdName.ReadOnly = True
        Me.txtProdName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtProdName.Size = New System.Drawing.Size(348, 20)
        Me.txtProdName.TabIndex = 287
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(357, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 16)
        Me.Label5.TabIndex = 286
        Me.Label5.Text = "اسم محصول"
        '
        'txtProdType
        '
        Me.txtProdType.BackColor = System.Drawing.Color.White
        Me.txtProdType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProdType.Enabled = False
        Me.txtProdType.Location = New System.Drawing.Point(3, 4)
        Me.txtProdType.Name = "txtProdType"
        Me.txtProdType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtProdType.Size = New System.Drawing.Size(348, 20)
        Me.txtProdType.TabIndex = 285
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(364, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 16)
        Me.Label1.TabIndex = 284
        Me.Label1.Text = "نوع محصول"
        '
        'txtTotalQty
        '
        Me.txtTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalQty.Enabled = False
        Me.txtTotalQty.Location = New System.Drawing.Point(228, 46)
        Me.txtTotalQty.Name = "txtTotalQty"
        Me.txtTotalQty.ReadOnly = True
        Me.txtTotalQty.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTotalQty.Size = New System.Drawing.Size(123, 20)
        Me.txtTotalQty.TabIndex = 283
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(357, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 16)
        Me.Label7.TabIndex = 282
        Me.Label7.Text = "مقدار سرجم"
        '
        'txtTransferredQty
        '
        Me.txtTransferredQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransferredQty.Location = New System.Drawing.Point(3, 46)
        Me.txtTransferredQty.Name = "txtTransferredQty"
        Me.txtTransferredQty.ReadOnly = True
        Me.txtTransferredQty.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTransferredQty.Size = New System.Drawing.Size(115, 20)
        Me.txtTransferredQty.TabIndex = 294
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(124, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 16)
        Me.Label3.TabIndex = 293
        Me.Label3.Text = "مقدار انتقال یافته"
        '
        'txtRemainingQty
        '
        Me.txtRemainingQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemainingQty.Enabled = False
        Me.txtRemainingQty.Location = New System.Drawing.Point(3, 67)
        Me.txtRemainingQty.Name = "txtRemainingQty"
        Me.txtRemainingQty.ReadOnly = True
        Me.txtRemainingQty.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRemainingQty.Size = New System.Drawing.Size(115, 20)
        Me.txtRemainingQty.TabIndex = 292
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(135, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 291
        Me.Label4.Text = "مقدار باقیمانده"
        '
        'btnCancel
        '
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnCancel.Location = New System.Drawing.Point(51, 362)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(141, 23)
        Me.btnCancel.TabIndex = 295
        Me.btnCancel.Text = "خروج"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtRemainingStock
        '
        Me.txtRemainingStock.BackColor = System.Drawing.SystemColors.ControlText
        Me.txtRemainingStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemainingStock.Enabled = False
        Me.txtRemainingStock.ForeColor = System.Drawing.Color.White
        Me.txtRemainingStock.Location = New System.Drawing.Point(3, 102)
        Me.txtRemainingStock.Name = "txtRemainingStock"
        Me.txtRemainingStock.ReadOnly = True
        Me.txtRemainingStock.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRemainingStock.Size = New System.Drawing.Size(223, 20)
        Me.txtRemainingStock.TabIndex = 300
        Me.txtRemainingStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(230, 102)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(215, 16)
        Me.Label6.TabIndex = 299
        Me.Label6.Text = "مقدار سر جمع (کارتن) محصول در انبار"
        '
        'txtRemainingStockPcs
        '
        Me.txtRemainingStockPcs.BackColor = System.Drawing.SystemColors.ControlText
        Me.txtRemainingStockPcs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemainingStockPcs.Enabled = False
        Me.txtRemainingStockPcs.ForeColor = System.Drawing.Color.White
        Me.txtRemainingStockPcs.Location = New System.Drawing.Point(3, 128)
        Me.txtRemainingStockPcs.Name = "txtRemainingStockPcs"
        Me.txtRemainingStockPcs.ReadOnly = True
        Me.txtRemainingStockPcs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRemainingStockPcs.Size = New System.Drawing.Size(223, 20)
        Me.txtRemainingStockPcs.TabIndex = 302
        Me.txtRemainingStockPcs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(239, 128)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(206, 16)
        Me.Label8.TabIndex = 301
        Me.Label8.Text = "مقدار سر جمع (دانه) محصول در انبار"
        '
        'FrmSaleQtyTranfered
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(446, 394)
        Me.Controls.Add(Me.txtRemainingStockPcs)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtRemainingStock)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtTransferredQty)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtRemainingQty)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtQtyTransferredDate)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtProdName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtProdType)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTotalQty)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.DGTransfer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSaleQtyTranfered"
        Me.Text = "FrmSaleQtyTranfered"
        CType(Me.DGTransfer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGTransfer As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtQtyTransferredDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Public WithEvents txtProdName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents txtProdType As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents txtTotalQty As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents txtTransferredQty As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents txtRemainingQty As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DGTransferredSNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGTransferredQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGTransferredDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Public WithEvents txtRemainingStock As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents txtRemainingStockPcs As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
