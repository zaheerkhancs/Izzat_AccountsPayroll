<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChequeCriteriaForPrint
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DG = New System.Windows.Forms.DataGridView
        Me.DGSNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGChequeID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGCustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGChequeNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGInvoiceNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGCheckbox = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.RBCurrentCheque = New System.Windows.Forms.RadioButton
        Me.RBList = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.txtCriteriaValue = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbCriteriaType = New System.Windows.Forms.ComboBox
        Me.RBSearch = New System.Windows.Forms.RadioButton
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DG
        '
        Me.DG.AllowUserToAddRows = False
        Me.DG.AllowUserToDeleteRows = False
        Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGSNo, Me.DGChequeID, Me.DGCustomerName, Me.DGChequeNo, Me.DGInvoiceNo, Me.DGCheckbox})
        Me.DG.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DG.Location = New System.Drawing.Point(0, 164)
        Me.DG.Name = "DG"
        Me.DG.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DG.Size = New System.Drawing.Size(573, 386)
        Me.DG.TabIndex = 0
        '
        'DGSNo
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.DGSNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGSNo.HeaderText = "شماره"
        Me.DGSNo.Name = "DGSNo"
        Me.DGSNo.ReadOnly = True
        '
        'DGChequeID
        '
        Me.DGChequeID.HeaderText = "شمارِۀ چک"
        Me.DGChequeID.Name = "DGChequeID"
        Me.DGChequeID.Visible = False
        '
        'DGCustomerName
        '
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.DGCustomerName.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGCustomerName.HeaderText = "اسم شخص"
        Me.DGCustomerName.Name = "DGCustomerName"
        Me.DGCustomerName.ReadOnly = True
        '
        'DGChequeNo
        '
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.DGChequeNo.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGChequeNo.HeaderText = " شمارۀ چک"
        Me.DGChequeNo.Name = "DGChequeNo"
        Me.DGChequeNo.ReadOnly = True
        '
        'DGInvoiceNo
        '
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.DGInvoiceNo.DefaultCellStyle = DataGridViewCellStyle5
        Me.DGInvoiceNo.HeaderText = "انوایس"
        Me.DGInvoiceNo.Name = "DGInvoiceNo"
        Me.DGInvoiceNo.ReadOnly = True
        '
        'DGCheckbox
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.NullValue = False
        Me.DGCheckbox.DefaultCellStyle = DataGridViewCellStyle6
        Me.DGCheckbox.HeaderText = "انتخاب"
        Me.DGCheckbox.Name = "DGCheckbox"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(383, 131)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 29)
        Me.btnCancel.TabIndex = 343
        Me.btnCancel.Text = "لغو"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Transparent
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOK.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnOK.ForeColor = System.Drawing.Color.White
        Me.btnOK.Location = New System.Drawing.Point(474, 131)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 29)
        Me.btnOK.TabIndex = 342
        Me.btnOK.Text = "راپور"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(145, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(294, 19)
        Me.Label1.TabIndex = 344
        Me.Label1.Text = "لطفآ چک های چاپ شدنی را انتخاب نمایید"
        '
        'RBCurrentCheque
        '
        Me.RBCurrentCheque.AutoSize = True
        Me.RBCurrentCheque.BackColor = System.Drawing.Color.Transparent
        Me.RBCurrentCheque.Checked = True
        Me.RBCurrentCheque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RBCurrentCheque.ForeColor = System.Drawing.Color.White
        Me.RBCurrentCheque.Location = New System.Drawing.Point(50, 51)
        Me.RBCurrentCheque.Name = "RBCurrentCheque"
        Me.RBCurrentCheque.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RBCurrentCheque.Size = New System.Drawing.Size(72, 17)
        Me.RBCurrentCheque.TabIndex = 345
        Me.RBCurrentCheque.TabStop = True
        Me.RBCurrentCheque.Text = "چک فعلی"
        Me.RBCurrentCheque.UseVisualStyleBackColor = False
        '
        'RBList
        '
        Me.RBList.AutoSize = True
        Me.RBList.BackColor = System.Drawing.Color.Transparent
        Me.RBList.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RBList.ForeColor = System.Drawing.Color.White
        Me.RBList.Location = New System.Drawing.Point(27, 77)
        Me.RBList.Name = "RBList"
        Me.RBList.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RBList.Size = New System.Drawing.Size(95, 17)
        Me.RBList.TabIndex = 346
        Me.RBList.Text = "انتخاب از لست "
        Me.RBList.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.txtCriteriaValue)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbCriteriaType)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(249, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(303, 82)
        Me.GroupBox1.TabIndex = 347
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "جستجو"
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSearch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(222, 48)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 343
        Me.btnSearch.Text = "جستجو"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'txtCriteriaValue
        '
        Me.txtCriteriaValue.Location = New System.Drawing.Point(15, 50)
        Me.txtCriteriaValue.Name = "txtCriteriaValue"
        Me.txtCriteriaValue.Size = New System.Drawing.Size(187, 21)
        Me.txtCriteriaValue.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(205, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "جستجو  به اساس "
        '
        'cmbCriteriaType
        '
        Me.cmbCriteriaType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCriteriaType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCriteriaType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCriteriaType.FormattingEnabled = True
        Me.cmbCriteriaType.Location = New System.Drawing.Point(15, 23)
        Me.cmbCriteriaType.Name = "cmbCriteriaType"
        Me.cmbCriteriaType.Size = New System.Drawing.Size(187, 21)
        Me.cmbCriteriaType.TabIndex = 0
        '
        'RBSearch
        '
        Me.RBSearch.AutoSize = True
        Me.RBSearch.BackColor = System.Drawing.Color.Transparent
        Me.RBSearch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RBSearch.ForeColor = System.Drawing.Color.White
        Me.RBSearch.Location = New System.Drawing.Point(62, 100)
        Me.RBSearch.Name = "RBSearch"
        Me.RBSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RBSearch.Size = New System.Drawing.Size(60, 17)
        Me.RBSearch.TabIndex = 348
        Me.RBSearch.Text = "جستجو"
        Me.RBSearch.UseVisualStyleBackColor = False
        '
        'ChequeCriteriaForPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Teal
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(573, 550)
        Me.Controls.Add(Me.RBSearch)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.RBList)
        Me.Controls.Add(Me.RBCurrentCheque)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.DG)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ChequeCriteriaForPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ChequeCriteriaForPrint"
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RBCurrentCheque As System.Windows.Forms.RadioButton
    Friend WithEvents RBList As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbCriteriaType As System.Windows.Forms.ComboBox
    Friend WithEvents txtCriteriaValue As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents RBSearch As System.Windows.Forms.RadioButton
    Public WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents DGSNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGChequeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGCustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGChequeNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGInvoiceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGCheckbox As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
