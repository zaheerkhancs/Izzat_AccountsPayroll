Imports System.Data.SqlClient
Imports LanguageSelector
Public Class FrmSale
    Dim a As Integer ' it has been used in all places , so do not ever create any local dim "a" inside a sub,use some other name.
    Public EditValue As Integer
    Dim cnt As Integer
    Dim k As Integer

    Public Var_SaleID As Integer
    Dim AddEdit As Boolean = False
    Dim azizkhanqarabaghi As Boolean
    ' The following variables are only for this form.
    Dim Var_ManDate As DateTime
    Dim Var_ExpDate As DateTime
    Dim i As Integer = 0
    Public CurrentRowKaTable As String
    Dim TableKaName_ForInsertion As String
    Dim Var_TransferDate As DateTime
    Dim MyComputerName As String
    Dim MyComputerIP As String
    Dim RowWanted As Integer = 0
    Dim bChangedToTime As DateTime
    Dim _InvoiceNo As String
    Dim SaleCode As String
    Dim CustomerCode As String
    Dim CashCode As String
    Dim ProdCode As Integer
    Dim Discount As String
    Dim Halftotal As Double
    Dim azizspliter() As String

    Dim purchaseQty As Integer
    Dim SalePerPcsQty As Integer
    Dim SalePerCrtnQty As Integer
    Dim ReturnPerPcsQty As Integer
    Dim ReturnPerCrtnQty As Integer
    Dim ClaimPerPcsQty As Integer
    Dim ClaimPerCrtnQty As Integer
    Dim DamagePerPcsQty As Integer
    Dim DamagePerCrtnQty As Integer

    Dim TotalSale As Decimal
    Dim TotalClaim As Decimal
    Dim TotalReturn As Decimal
    Dim TotalDamage As Decimal

    Public OldQty As Decimal
    Public OldQtyPcs As Decimal

    Public PcsInCrtn As Decimal
    Public CrtnIntoPcs As Decimal
    'Dim CustomerTableName As String
    'Dim CustomerID As String
    Private Sub FrmSale_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Module1.Opencn()
        AddEdit = False ' keep it false here and before txtfill true.
        azizkhanqarabaghi = False
        Me.MaximizeBox = False
        Module1.DatasetFill("Select * from Location", "Location")
  
        Call ComboFillerOfFahimshekaib(cmbLocation, "Location", "LocName", "LocID")
        cmbLocation.SelectedIndex = -1

        Module1.DatasetFill("Select * from Shop", "Shop")
        Call ComboFillerOfFahimshekaib(cmbShop, "Shop", "ShopName", "ShopID")
        cmbShop.SelectedIndex = -1

        Module1.DatasetFill("Select * from SaleMain Order by SaleID", "SaleMain")
        ' Filling Comboes of CustomerType,ProductType and Product ..Customer Combo will be filled later in type change.
        Module1.DatasetFill("Select * from CustomerType", "CustomerType")
        Call ComboFillerOfFahimshekaib(cmbCustomerType, "CustomerType", "CustomerTypeName", "CustomerTypeID")
        ' cmbCustomerType.SelectedIndex = -1
        ''
        Module1.DatasetFill("Select * from Customer", "Customer")
        Call ComboFillerOfFahimshekaib(cmbCustomerName, "Customer", "CustomerName", "CustomerID")
        If cmbCustomerName.Items.Count > 0 Then
            cmbCustomerName.SelectedIndex = -1
        End If

        ''
        Module1.DatasetFill("Select * from ProductType", "ProductType")
        Call ComboFillerOfFahimshekaib(DGPType, "ProductType", "ProdTypeName", "ProdTypeID")

        Module1.DatasetFill("Select * from CartonPiece", "CartonPiece")
        'Call ComboFillerOfFahimshekaib(DGCrtnPcs, " CartonPiece", "Name", "ID")
        DGCrtnPcs.DataSource = ds.Tables("CartonPiece")
        DGCrtnPcs.DisplayMember = ("Name")
        DGCrtnPcs.ValueMember = ("ID")
        Module1.DatasetFill("Select * from VuProduct", "VuProduct")
        Call ComboFillerOfFahimshekaib(DGProductCode, "VuProduct", "Product", "ProdCode")
        'Call ComboProductFiller()
        ''Call ComboCustomerNameFiller()
        'Call ComboProductTypeFill()
        Module1.DatasetFill("Select * from VuOrderNo_OnlyForSale ", "VuOrderNo_OnlyForSale")
        Call ComboFillerOfFahimshekaib(cmbOrderNo, "VuOrderNo_OnlyForSale", "SalOrderNo", "SalOrderID")
        cmbOrderNo.SelectedIndex = -1
        'cmbOrderNo.DataSource = ds.Tables("VuOrderNo_OnlyForSale")
        'cmbOrderNo.DisplayMember = "SalOrderNo"
        'cmbOrderNo.ValueMember = "SalOrderID"
        DGBtnTransfer.Visible = False
        AddEdit = True
        Call txtfill()
        azizkhanqarabaghi = True
        Me.MaximizeBox = False
        TB1.Left = pnlcentre.Width / 2 - (TB1.Width / 2)
        TB1.Top = pnlcentre.Height / 2 - (TB1.Height / 2)
        pnlcentre.Left = Me.Width / 2 - (pnlcentre.Width / 2)
        pnlcentre.Top = Me.Height / 2 - (pnlcentre.Height / 2)


        dtSaleDate.Value = Now

        Label10.Visible = False
        cmbInvoiceNoSearch.Visible = False
        Label12.Visible = False
        cmbCustomerTypeSearch.Visible = False
        Label13.Visible = False
        cmbCustomerNameSearch.Visible = False

        MnuReturn.Visible = False

        If Frm.GID.Text = 1 Then
            'MnuEdit.Visible = True
            'on 29th september it was commented too.watch stock calculation in this page.for detail of the reason.
        ElseIf Frm.GID.Text = 2 Then
            MnuEdit.Visible = False
        Else
            Module1.CMStatusDisable(CM)
        End If

    End Sub
#Region "IGL"
    Sub SaveIGL()
        Dim cmdsaveGridIGL As New SqlCommand
        cmdsaveGridIGL.CommandType = CommandType.StoredProcedure
        cmdsaveGridIGL.CommandText = "InsertIGL"
        cmdsaveGridIGL.Connection = cn
        Try
            For k = 0 To DG.Rows.Count - 1

                cmdsaveGridIGL.Parameters.Add("@ID", SqlDbType.Int)
                cmdsaveGridIGL.Parameters("@ID").Value = Var_SaleID

                cmdsaveGridIGL.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Me.dtSaleDate.Value.Date.ToString
                cmdsaveGridIGL.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "Sale"
                cmdsaveGridIGL.Parameters.Add("@ProductType", SqlDbType.Int).Value = DG.Rows(k).Cells("DGPType").Value
                cmdsaveGridIGL.Parameters.Add("@ProductCode", SqlDbType.Int).Value = DG.Rows(k).Cells("DGProductCode").Value
                cmdsaveGridIGL.Parameters.Add("@PurchaseQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@SaleQty", SqlDbType.Decimal).Value = Val(DG.Rows(k).Cells("DGDeliveredQty").Value)
                cmdsaveGridIGL.Parameters.Add("@ReturnQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@ClaimQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@DamageQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@CrtnPcs", SqlDbType.SmallInt).Value = Val(DG.Rows(k).Cells("DGCrtnPcs").Value)
                cmdsaveGridIGL.Parameters.Add("@Broken", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Leak", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Short", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Dent", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Expired", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@DecayedBeforeExpiration", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Etc", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Ok", SqlDbType.Decimal).Value = 0

                Try
                    If DG.Rows(k).Cells("DGDesciption").Value = "" Then
                        cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = " "
                    Else
                        cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = DG.Rows(k).Cells("DGDesciption").Value
                    End If
                Catch ex As Exception
                    cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = " "
                End Try

                cmdsaveGridIGL.Parameters.Add("@CityID", SqlDbType.Int).Value = Val("1")
                cmdsaveGridIGL.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = "KBL" & "-" & Me.Var_SaleID

                cmdsaveGridIGL.ExecuteNonQuery()
                cmdsaveGridIGL.Parameters.Clear()
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub UpdateIGL()
        Dim OldQty As Decimal = 0
        Dim NewQty As Decimal = 0
        Dim TotalQty As Decimal = 0
        Dim cmdsaveGridIGL As New SqlCommand
        cmdsaveGridIGL.CommandType = CommandType.StoredProcedure
        cmdsaveGridIGL.CommandText = "InsertIGL"
        cmdsaveGridIGL.Connection = cn
        Try

            Module1.DatasetFill("Select Sum(SaleQty)as SaleQuantity from VuIGL where ID=" & Var_SaleID & " and ProductType =" & DG.Rows(a).Cells("DGPType").Value & " and ProductCode=" & DG.Rows(a).Cells("DGProductCode").Value & " And Type='Sale'", "VuIGL")
            OldQty = ds.Tables("VuIGL").Rows(0).Item("SaleQuantity")
            NewQty = Val(DG.Rows(RowWanted).Cells("DGDeliveredQty").Value)
            TotalQty = NewQty - OldQty
        Catch ex As Exception
        End Try
        If TotalQty = 0 Then
            Exit Sub
        End If
        Try
            For k = 0 To 1 - 1

                cmdsaveGridIGL.Parameters.Add("@ID", SqlDbType.Int)
                cmdsaveGridIGL.Parameters("@ID").Value = Var_SaleID
                'For Each dtTable As DataTable In ds.Tables
                '    MsgBox(dtTable.TableName)
                'Next
                'Try
                '    'DateEntry = ds.Tables(TableKaName_ForInsertion).Rows(a).Item("trdate")

                'Catch ex As Exception

                'End Try
                'Try
                '    If DateEntry = #12:00:00 AM# Then
                '        Var_TransferDate = "01/01/1900"
                '        cmdsaveGridIGL.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Var_TransferDate
                '    Else
                '        Var_TransferDate = DateEntry
                '        cmdsaveGridIGL.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Var_TransferDate
                '    End If
                'Catch ex As Exception
                'End Try
                cmdsaveGridIGL.Parameters.Add("@dtDate", SqlDbType.SmallDateTime).Value = Var_TransferDate
                cmdsaveGridIGL.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "Sale"
                cmdsaveGridIGL.Parameters.Add("@ProductType", SqlDbType.Int).Value = DG.Rows(RowWanted).Cells("DGPType").Value
                cmdsaveGridIGL.Parameters.Add("@ProductCode", SqlDbType.Int).Value = DG.Rows(RowWanted).Cells("DGProductCode").Value


                cmdsaveGridIGL.Parameters.Add("@PurchaseQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@SaleQty", SqlDbType.Decimal).Value = TotalQty
                cmdsaveGridIGL.Parameters.Add("@ReturnQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@ClaimQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@DamageQty", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@CrtnPcs", SqlDbType.SmallInt).Value = Val(DG.Rows(RowWanted).Cells("DGCrtnPcs").Value)
                cmdsaveGridIGL.Parameters.Add("@Broken", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Leak", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Short", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Dent", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@Expired", SqlDbType.Decimal).Value = 0
                cmdsaveGridIGL.Parameters.Add("@DecayedBeforeExpiration", SqlDbType.Decimal).Value = 0

                Try
                    If DG.Rows(k).Cells("DGDesciption").Value = "" Then
                        cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = " "
                    Else
                        cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = DG.Rows(RowWanted).Cells("DGDesciption").Value
                    End If
                Catch ex As Exception
                    cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = " "
                End Try


                'cmdsaveGridIGL.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = "Purchase"
                cmdsaveGridIGL.Parameters.Add("@CityID", SqlDbType.Int).Value = Val("1")
                cmdsaveGridIGL.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = "KBL" & "-" & Me.Var_SaleID

                cmdsaveGridIGL.ExecuteNonQuery()
                cmdsaveGridIGL.Parameters.Clear()
            Next
        Catch ex As Exception
        End Try
    End Sub
#End Region


#Region "ACCOUNT SECTION ENTRY"

    Sub SaveVoucher()
        If cn.State = ConnectionState.Closed Then cn.Open()

        'cmd.CommandText = "Select CashCode from Impheads"
        'CashCode = cmd.ExecuteScalar

        'cmd.CommandText = "Select RpurchaseCode from Impheads"
        'PurchaseCode = cmd.ExecuteScalar

        Module1.DatasetFill("Select CashCode,SalesCode,CustoSubCode,DiscountCode from Impheads where CompanyID = " & Frm.LBCompanyID.Text & "", "Impheads")
        CashCode = ds.Tables("Impheads").Rows(0).Item("CashCode")
        SaleCode = ds.Tables("Impheads").Rows(0).Item("SalesCode")
        CustomerCode = ds.Tables("Impheads").Rows(0).Item("CustoSubCode")
        Discount = ds.Tables("Impheads").Rows(0).Item("DiscountCode")

        Try
            Trans = cn.BeginTransaction
            Dim cmdSave As New SqlCommand
            cmdSave.Transaction = Trans
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmdSave.Connection = cn
            cmdSave.CommandType = CommandType.StoredProcedure
            cmdSave.CommandText = "InsertUpdateVMain"
            cmdSave.Parameters.Add("@Vno", SqlDbType.NVarChar)
            cmdSave.Parameters("@Vno").Value = Me.txtInvoice.Text
            cmdSave.Parameters.Add("@Vtype", SqlDbType.NVarChar)
            cmdSave.Parameters("@Vtype").Value = "Sale Invoice"
            cmdSave.Parameters.Add("@Date", SqlDbType.SmallDateTime)
            cmdSave.Parameters("@Date").Value = Me.dtSaleDate.Value.Date
            cmdSave.Parameters.Add("@descr", SqlDbType.NVarChar)
            cmdSave.Parameters("@descr").Value = Me.txtRemarks.Text
            cmdSave.Parameters.Add("@UserID", SqlDbType.Int)
            cmdSave.Parameters("@UserID").Value = Frm.LbUserID.Text
            cmdSave.Parameters.Add("@CompanyID", SqlDbType.Int)
            cmdSave.Parameters("@CompanyID").Value = Frm.LBCompanyID.Text
            cmdSave.Parameters.Add("@WName", SqlDbType.VarChar)
            cmdSave.Parameters("@WName").Value = Frm.WName.Text
            cmdSave.Parameters.Add("@PID", SqlDbType.VarChar)
            cmdSave.Parameters("@PID").Value = Frm.LblPeriod.Text
            cmdSave.Parameters.Add("@Remarks", SqlDbType.NVarChar)
            cmdSave.Parameters("@Remarks").Value = Me.txtRemarks.Text
            cmdSave.Parameters.Add("@VKey", SqlDbType.SmallDateTime)
            cmdSave.Parameters("@VKey").Value = Me.dtSaleDate.Value.Date.AddDays(3)
            cmdSave.Parameters.Add("@VPost", SqlDbType.Bit)
            cmdSave.Parameters("@VPost").Value = 0

            cmdSave.Parameters.Add("@Flag", SqlDbType.Bit)
            cmdSave.Parameters("@Flag").Value = EditValue

            ''''''''''''@Received Varchar(50)
            ''@paid varchar(50)
            ''''@Cheque varchar(50)

            cmdSave.Parameters.Add("@Received", SqlDbType.NVarChar)
            cmdSave.Parameters("@Received").Value = "Nil"

            cmdSave.Parameters.Add("@paid", SqlDbType.NVarChar)
            cmdSave.Parameters("@paid").Value = "Nil"

            cmdSave.Parameters.Add("@Cheque", SqlDbType.NVarChar)
            cmdSave.Parameters("@Cheque").Value = "Nil"

            ' MsgBox(Me.DtDate.Value.AddDays(3))


            If EditValue = 1 Then
                cmdSave.ExecuteNonQuery()

                GridSaveVoucher()
                Trans.Commit()
                'Dim frmm As New FrmBox("Your Record has been saved successfully..")
                'frmm.ShowDialog()
            Else
                'If EditFlag = False Then
                '    MsgBox("Sorry :  you cannot do entry on wrong date..", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                '    Exit Sub
                'End If

                cmdSave.ExecuteNonQuery()
                DeleteGridVoucher()
                GridSaveVoucher()
                Trans.Commit()
                'MsgBox("Your Record has been Updated successfully..")
                'frmm.ShowDialog()
            End If

            'Module1.DatasetFill("Select * from VoucherMain where Vtype=N'" & GroupBox1.Text & "' and CompanyID=" & Frm.LBCompanyID.Text & " and PID=N'" & Frm.LblPeriod.Text & "'", "VoucherMain")
            'Call txtfill()
            'StatusMnu()


        Catch ex As Exception
            Trans.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub DeleteGridVoucher()
        Dim cmdDelete As New SqlCommand

        '  If cn.State = ConnectionState.Closed Then cn.Open()
        cmdDelete.Connection = cn
        cmdDelete.Transaction = Trans
        cmdDelete.CommandType = CommandType.StoredProcedure
        cmdDelete.CommandText = "DeleteDetail"
        cmdDelete.Parameters.Add("@Vno", SqlDbType.NVarChar)
        cmdDelete.Parameters("@Vno").Value = Me.txtInvoice.Text
        cmdDelete.ExecuteNonQuery()

    End Sub

    Sub GridSaveVoucher()
        '   Try


        Dim a As Integer
        '  For a = 0 To DG.Rows.Count - 2
        Dim cmdSave As New SqlCommand
        cmdSave.Transaction = Trans
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmdSave.Connection = cn
        cmdSave.CommandType = CommandType.StoredProcedure
        cmdSave.CommandText = "SaveDetail"
        cmdSave.Parameters.Add("@Vno", SqlDbType.NVarChar)
        cmdSave.Parameters("@Vno").Value = Me.txtInvoice.Text
        ''@VNo, @HeadID, @SubID, @Remarks, @ChequeNo, @ChequeDate, @Dr, @Cr
        cmdSave.Parameters.Add("@HeadID", SqlDbType.Char)
        cmdSave.Parameters("@HeadID").Value = SaleCode
        cmdSave.Parameters.Add("@SubID", SqlDbType.BigInt)
        cmdSave.Parameters("@SubID").Value = cmbCustomerName.SelectedValue
        cmdSave.Parameters.Add("@Remarks", SqlDbType.NVarChar)
        cmdSave.Parameters("@Remarks").Value = "From Sale"
        cmdSave.Parameters.Add("@ChequeNo", SqlDbType.NVarChar)
        cmdSave.Parameters("@ChequeNo").Value = " "     '(IIf(IsNothing(DG.Rows(a).Cells(5).Value) = True, " ", DG.Rows(a).Cells(5).Value))
        cmdSave.Parameters.Add("@ChequeDate", SqlDbType.SmallDateTime)
        cmdSave.Parameters("@ChequeDate").Value = "01/01/1900"       '(IIf(IsDate(DG.Rows(a).Cells(6).Value) = False, "01/01/1900", DG.Rows(a).Cells(6).Value))
        cmdSave.Parameters.Add("@Dr", SqlDbType.Decimal)
        cmdSave.Parameters("@Dr").Value = 0
        cmdSave.Parameters.Add("@Cr", SqlDbType.Decimal)
        cmdSave.Parameters("@Cr").Value = Me.txtTotalToPayWithoutDiscount.Text


        cmdSave.ExecuteNonQuery()

        If EditValue = 1 Then
            Module1.InsertRecord("CustomerRecordDetail", "" & Var_SaleID & ",'" & txtInvoice.Text & "','" & Me.dtSaleDate.Value.Date & "'," & Frm.LBCompanyID.Text & ",'" & SaleCode & "'," & cmbCustomerName.SelectedValue & "," & txtTotalToPayWithoutDiscount.Text & ",0,'" & Frm.LblPeriod.Text & "'", Trans)
        End If
        '''''''''''''''''''''''''
        Dim cmdSave1 As New SqlCommand
        cmdSave1.Transaction = Trans
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmdSave1.Connection = cn
        cmdSave1.CommandType = CommandType.StoredProcedure
        cmdSave1.CommandText = "SaveDetail"
        cmdSave1.Parameters.Add("@Vno", SqlDbType.NVarChar)
        cmdSave1.Parameters("@Vno").Value = Me.txtInvoice.Text
        ''@VNo, @HeadID, @SubID, @Remarks, @ChequeNo, @ChequeDate, @Dr, @Cr
        cmdSave1.Parameters.Add("@HeadID", SqlDbType.Char)
        cmdSave1.Parameters("@HeadID").Value = CashCode
        cmdSave1.Parameters.Add("@SubID", SqlDbType.BigInt)
        cmdSave1.Parameters("@SubID").Value = cmbCustomerName.SelectedValue
        cmdSave1.Parameters.Add("@Remarks", SqlDbType.NVarChar)
        cmdSave1.Parameters("@Remarks").Value = "From Sale"
        cmdSave1.Parameters.Add("@ChequeNo", SqlDbType.NVarChar)
        cmdSave1.Parameters("@ChequeNo").Value = " "     '(IIf(IsNothing(DG.Rows(a).Cells(5).Value) = True, " ", DG.Rows(a).Cells(5).Value))
        cmdSave1.Parameters.Add("@ChequeDate", SqlDbType.SmallDateTime)
        cmdSave1.Parameters("@ChequeDate").Value = "01/01/1900"       '(IIf(IsDate(DG.Rows(a).Cells(6).Value) = False, "01/01/1900", DG.Rows(a).Cells(6).Value))
        cmdSave1.Parameters.Add("@Dr", SqlDbType.Decimal)
        If Me.txtTotalPaid.Text = "" Then
            Me.txtTotalPaid.Text = 0
        End If
        cmdSave1.Parameters("@Dr").Value = Me.txtTotalPaid.Text
        cmdSave1.Parameters.Add("@Cr", SqlDbType.Decimal)
        cmdSave1.Parameters("@Cr").Value = 0

        cmdSave1.ExecuteNonQuery()



        Dim cmdSave2 As New SqlCommand
        cmdSave2.Transaction = Trans
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmdSave2.Connection = cn
        cmdSave2.CommandType = CommandType.StoredProcedure
        cmdSave2.CommandText = "SaveDetail"
        cmdSave2.Parameters.Add("@Vno", SqlDbType.NVarChar)
        cmdSave2.Parameters("@Vno").Value = Me.txtInvoice.Text
        ''@VNo, @HeadID, @SubID, @Remarks, @ChequeNo, @ChequeDate, @Dr, @Cr
        cmdSave2.Parameters.Add("@HeadID", SqlDbType.Char)
        cmdSave2.Parameters("@HeadID").Value = CustomerCode
        cmdSave2.Parameters.Add("@SubID", SqlDbType.BigInt)
        cmdSave2.Parameters("@SubID").Value = Me.cmbCustomerName.SelectedValue
        cmdSave2.Parameters.Add("@Remarks", SqlDbType.NVarChar)
        cmdSave2.Parameters("@Remarks").Value = "From Sale"
        cmdSave2.Parameters.Add("@ChequeNo", SqlDbType.NVarChar)
        cmdSave2.Parameters("@ChequeNo").Value = " "     '(IIf(IsNothing(DG.Rows(a).Cells(5).Value) = True, " ", DG.Rows(a).Cells(5).Value))
        cmdSave2.Parameters.Add("@ChequeDate", SqlDbType.SmallDateTime)
        cmdSave2.Parameters("@ChequeDate").Value = "01/01/1900"       '(IIf(IsDate(DG.Rows(a).Cells(6).Value) = False, "01/01/1900", DG.Rows(a).Cells(6).Value))
        cmdSave2.Parameters.Add("@Dr", SqlDbType.Decimal)
        cmdSave2.Parameters("@Dr").Value = Val(Me.txtBalance.Text)
        cmdSave2.Parameters.Add("@Cr", SqlDbType.Decimal)
        cmdSave2.Parameters("@Cr").Value = 0

        cmdSave2.ExecuteNonQuery()


        If txtDiscount.Text > 0 Then

            Dim cmdSave3 As New SqlCommand
            cmdSave3.Transaction = Trans
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmdSave3.Connection = cn
            cmdSave3.CommandType = CommandType.StoredProcedure
            cmdSave3.CommandText = "SaveDetail"
            cmdSave3.Parameters.Add("@Vno", SqlDbType.NVarChar)
            cmdSave3.Parameters("@Vno").Value = Me.txtInvoice.Text
            ''@VNo, @HeadID, @SubID, @Remarks, @ChequeNo, @ChequeDate, @Dr, @Cr
            cmdSave3.Parameters.Add("@HeadID", SqlDbType.Char)
            cmdSave3.Parameters("@HeadID").Value = Discount
            cmdSave3.Parameters.Add("@SubID", SqlDbType.BigInt)
            cmdSave3.Parameters("@SubID").Value = Me.cmbCustomerName.SelectedValue
            cmdSave3.Parameters.Add("@Remarks", SqlDbType.NVarChar)
            cmdSave3.Parameters("@Remarks").Value = "From Sale as a Discount"
            cmdSave3.Parameters.Add("@ChequeNo", SqlDbType.NVarChar)
            cmdSave3.Parameters("@ChequeNo").Value = " "     '(IIf(IsNothing(DG.Rows(a).Cells(5).Value) = True, " ", DG.Rows(a).Cells(5).Value))
            cmdSave3.Parameters.Add("@ChequeDate", SqlDbType.SmallDateTime)
            cmdSave3.Parameters("@ChequeDate").Value = "01/01/1900"       '(IIf(IsDate(DG.Rows(a).Cells(6).Value) = False, "01/01/1900", DG.Rows(a).Cells(6).Value))
            cmdSave3.Parameters.Add("@Dr", SqlDbType.Decimal)
            If Me.txtDiscount.Text = "" Then
                Me.txtDiscount.Text = 0
            End If
            cmdSave3.Parameters("@Dr").Value = Me.txtDiscount.Text
            cmdSave3.Parameters.Add("@Cr", SqlDbType.Decimal)
            cmdSave3.Parameters("@Cr").Value = 0

            cmdSave3.ExecuteNonQuery()

            If EditValue = 1 Then
                Module1.InsertRecord("CustomerRecordDetail", "" & Var_SaleID & ",'" & txtInvoice.Text & "','" & Me.dtSaleDate.Value.Date & "'," & Frm.LBCompanyID.Text & ",'" & Discount & "'," & cmbCustomerName.SelectedValue & ",0," & txtDiscount.Text & ",'" & Frm.LblPeriod.Text & "'", Trans)
            End If
            'Next

        End If
        '  Catch ex As Exception
        'MsgBox(ex.Message)
        'Trans.Rollback()

        'End Try
    End Sub

#End Region


#Region "Sub Functions IDPicker,txtclear,txtfill,OpenGrid,CMStatus,CMStatusDefault,CStatusDefault"
    Sub IDPicker()
        Try

            Dim sqldreader As SqlDataReader
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select Max(SaleID) from SaleMain"
            cmd.Connection = cn
            If cn.State = ConnectionState.Closed Then cn.Open()
            sqldreader = cmd.ExecuteReader()
            While sqldreader.Read

                If IsDBNull(sqldreader.Item(0)) = True Then
                    Me.Var_SaleID = 1
                Else
                    Me.Var_SaleID = Val(sqldreader.Item(0)) + 1

                End If
            End While
            sqldreader.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CalcTotal()
        Try
            txtBalance.Text = Val(txtTotalToPay.Text) - Val(txtTotalPaid.Text)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub CStatusDefault()
        txtInvoice.Enabled = False

        cmbCustomerType.Enabled = False
        cmbCustomerName.Enabled = False
        dtSaleDate.Enabled = False
        cmbOrderNo.Enabled = False
        txtTotalToPay.Enabled = False

        txtBalance.Enabled = False
        txtRemarks.Enabled = False
        DTManForGrid.Enabled = False
        DTExpForGrid.Enabled = False
    End Sub
    Public Sub CMStatusDefault()
        MnuNew.Enabled = True
        MnuEdit.Enabled = True
        MnuSave.Enabled = False
        MnuDelete.Enabled = True
        MnuUndo.Enabled = False
        btnPayment.Enabled = False
    End Sub
    Sub CStutus()
        'txtInvoice.Enabled = Not txtInvoice.Enabled

        'cmbCustomerType.Enabled = Not cmbCustomerType.Enabled
        'cmbCustomerName.Enabled = Not cmbCustomerName.Enabled
        dtSaleDate.Enabled = Not dtSaleDate.Enabled
        cmbOrderNo.Enabled = Not cmbOrderNo.Enabled
        txtTotalToPay.Enabled = Not txtTotalToPay.Enabled

        txtBalance.Enabled = Not txtBalance.Enabled
        txtRemarks.Enabled = Not txtRemarks.Enabled
        DTManForGrid.Enabled = Not DTManForGrid.Enabled
        DTExpForGrid.Enabled = Not DTExpForGrid.Enabled

        txtDiscount.ReadOnly = Not txtDiscount.ReadOnly
    End Sub
  
    'Sub ComboOrderNoFiller()
    '    Module1.DatasetFill("Select * from OrderFromCustomerMain", "OrderFromCustomerMain")
    '    cmbCustomerName.DataSource = ds.Tables("OrderFromCustomerMain")
    '    cmbCustomerName.DisplayMember = "SalOrderNo"
    '    cmbCustomerName.ValueMember = "SalOrderID"
    '    cmbCustomerName.SelectedIndex = 0
    'End Sub
    'Sub ComboCustomerNameFiller()
    '    Try


    '        Module1.DatasetFill("Select * from OrderFromCustomerMain", "OrderFromCustomerMain")
    '        cmbOrderNo.DataSource = ds.Tables("OrderFromCustomerMain")
    '        cmbOrderNo.DisplayMember = "CustomerName"
    '        cmbOrderNo.ValueMember = "CustomerID"
    '        cmbOrderNo.SelectedIndex = 0
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Sub ComboProductTypeFill()
    '    Module1.DatasetFill("Select * from ProductType", "ProductType")
    '    DGPType.DataSource = ds.Tables("ProductType")
    '    DGPType.DisplayMember = "ProdTypeName"
    '    DGPType.ValueMember = "ProdTypeID"
    'End Sub
    'Sub ComboProductFiller()
    '    Module1.DatasetFill("Select * from Product", "Product")
    '    DGProductCode.DataSource = ds.Tables("Product")
    '    DGProductCode.DisplayMember = "ProdName"
    '    DGProductCode.ValueMember = "ProdCode"
    'End Sub

    Sub txtfill()
        Try
            Module1.DatasetFill("Select * from SaleMain Order by SaleID", "SaleMain")

            If ds.Tables("SaleMain").Rows.Count = 0 Then
                Var_SaleID = 0
                Call ClearTheWholeForm()

                Exit Sub
            End If

            Me.Var_SaleID = Val(ds.Tables("SaleMain").Rows(cnt).Item("SaleID"))
            txtInvoice.Text = ds.Tables("SaleMain").Rows(cnt).Item("InvoiceNo")
            cmbCustomerType.SelectedIndex = -1
            cmbCustomerType.SelectedValue = ds.Tables("SaleMain").Rows(cnt).Item("CustomerTypeID")
            cmbCustomerName.SelectedIndex = -1
            cmbCustomerName.SelectedValue = ds.Tables("SaleMain").Rows(cnt).Item("CustomerID")
            cmbLocation.SelectedValue = ds.Tables("SaleMain").Rows(cnt).Item("LocID")
            cmbShop.SelectedValue = ds.Tables("SaleMain").Rows(cnt).Item("ShopID")
            If ds.Tables("SaleMain").Rows(cnt).Item("LocID") = 0 Then
                'Incase this person doesn't have shop
                cmbLocation.Visible = False
                lblLocation.Visible = False
                cmbShop.Visible = False
                lblShop.Visible = False
            Else
                'Incase this person has shop
                cmbLocation.Visible = True
                lblLocation.Visible = True
                cmbShop.Visible = True
                lblShop.Visible = True
            End If
            dtSaleDate.Value = ds.Tables("SaleMain").Rows(cnt).Item("SaleDate")
            cmbOrderNo.SelectedValue = ds.Tables("SaleMain").Rows(cnt).Item("SalOrderID")

            txtTotalToPayWithoutDiscount.Text = ds.Tables("SaleMain").Rows(cnt).Item("TotalWithOutDiscount")
            txtDiscount.Text = ds.Tables("SaleMain").Rows(cnt).Item("Discount")
            txtTotalToPay.Text = ds.Tables("SaleMain").Rows(cnt).Item("TotalAmount")
            txtTotalPaid.Text = ds.Tables("SaleMain").Rows(cnt).Item("TotalPaid")

            txtBalance.Text = ds.Tables("SaleMain").Rows(cnt).Item("Balance")
            txtRemarks.Text = ds.Tables("SaleMain").Rows(cnt).Item("Remarks")

            Call GridFill()
        Catch ex As Exception

        End Try
    End Sub
    Sub ClearTheWholeForm()
        Module1.txtclear(Me, pnlcentre, TB1, TP1)
        'cmbOrderNo.SelectedIndex = -1
        DG.Rows.Clear()
    End Sub
    Sub CMStatus()
        MnuNew.Enabled = Not MnuNew.Enabled
        MnuEdit.Enabled = Not MnuEdit.Enabled
        MnuSave.Enabled = Not MnuSave.Enabled
        MnuDelete.Enabled = Not MnuDelete.Enabled
        MnuUndo.Enabled = Not MnuUndo.Enabled
        btnPayment.Enabled = Not btnPayment.Enabled
    End Sub

#End Region


#Region "ContextMenuButtons"


    Private Sub MnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuNew.Click
        'Me.RightToLeft = Windows.Forms.RightToLeft.Yes
        Call ClearTheWholeForm()

        CStutus()
        CMStatus()
        DG.ReadOnly = False
        DGDisabler()
        ' DGProductCode.Visible = True
        DGBtnTransfer.Visible = True
        ' DG.Rows.Clear()
        AddEdit = True
        'order combo was filled in here before, but ow it is filled in form load.
        lblMessage.Text = ""
        EditValue = 1
        AddEdit = True
        Call InvoiceNoGenerator()
        txtInvoice.Text = _InvoiceNo
        Module1.DatasetFill("Select * from VuOrderNo_OnlyForSale where SalOrderID Not In(Select SalOrderID from SaleMain)", "VuOrderNo_OnlyForSale")
        Call ComboFillerOfFahimshekaib(cmbOrderNo, "VuOrderNo_OnlyForSale", "SalOrderNo", "SalOrderID")
        'Module1.DatasetFill("Select * from VuOrderNo_OnlyForSale ", "VuOrderNo_OnlyForSale")
        'Call ComboFillerOfFahimshekaib(cmbOrderNo, "VuOrderNo_OnlyForSale", "SalOrderNo", "SalOrderID")

        If MnuSearch.Visible = False Then
            MnuSearch.Visible = True
            Label10.Visible = False
            cmbInvoiceNoSearch.Visible = False
            Label12.Visible = False
            cmbCustomerTypeSearch.Visible = False
            Label13.Visible = False
            cmbCustomerNameSearch.Visible = False
            MnuReturn.Visible = False
        End If

        MnuSearch.Enabled = False
        dtSaleDate.Value = Now
        txtTotalPaid.Text = 0
    End Sub

    Private Sub MnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSave.Click
        'FrmSalePaymentDialogueBox.Show()
        'If DG.Rows.Count.Equals(0) Or cmbCustomerName.SelectedValue = Nothing Then Exit Sub
        If Val(txtBalance.Text) < 0 Then
            MessageBox.Show("میزان نباید کمتر از صفر باشد", "تخطی از قانون", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        If EditValue = 1 Then
            IDPicker()
        End If

        Dim cmdsave As New SqlCommand
        cmdsave.CommandType = CommandType.StoredProcedure
        cmdsave.CommandText = "InsertUpdateSaleMain"
        cmdsave.Connection = cn
        cmdsave.Parameters.Add("@SaleID", SqlDbType.Int).Value = Me.Var_SaleID
        cmdsave.Parameters.Add("@InvoiceNo", SqlDbType.NVarChar).Value = Me.txtInvoice.Text.Trim()
        cmdsave.Parameters.Add("@CustomerTypeID", SqlDbType.Int).Value = Me.cmbCustomerType.SelectedValue
        cmdsave.Parameters.Add("@CustomerID", SqlDbType.Int).Value = Me.cmbCustomerName.SelectedValue
        If cmbLocation.SelectedValue = Nothing Then
            cmdsave.Parameters.Add("@locID", SqlDbType.Int).Value = 0
            cmdsave.Parameters.Add("@ShopID", SqlDbType.Int).Value = 0
        Else


            cmdsave.Parameters.Add("@locID", SqlDbType.Int).Value = Me.cmbLocation.SelectedValue
            cmdsave.Parameters.Add("@ShopID", SqlDbType.Int).Value = Me.cmbShop.SelectedValue
        End If
        cmdsave.Parameters.Add("@SaleDate", SqlDbType.SmallDateTime).Value = Me.dtSaleDate.Value.Date
        cmdsave.Parameters.Add("@SalOrderID", SqlDbType.Int).Value = Me.cmbOrderNo.SelectedValue
        cmdsave.Parameters.Add("@TotalWithOutDiscount", SqlDbType.Decimal).Value = Me.txtTotalToPayWithoutDiscount.Text.Trim()
        cmdsave.Parameters.Add("@Discount", SqlDbType.Decimal).Value = Me.txtDiscount.Text.Trim()
        cmdsave.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = Me.txtTotalToPay.Text.Trim()
        cmdsave.Parameters.Add("@TotalPaid", SqlDbType.Decimal).Value = Me.txtTotalPaid.Text.Trim()

        cmdsave.Parameters.Add("@Balance", SqlDbType.Decimal).Value = Me.txtBalance.Text.Trim()
        cmdsave.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = Me.txtRemarks.Text
        cmdsave.Parameters.Add("@CounterForObraye", SqlDbType.Int).Value = 0
        cmdsave.Parameters.Add("@CityID", SqlDbType.Int).Value = Val("1")
        cmdsave.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = "KBL" & "-" & Me.Var_SaleID
        cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = EditValue
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmdsave.ExecuteNonQuery()

        cmdsave.Parameters.Clear()
        Module1.DatasetFill("Select * from VuOrderNo_OnlyForSale ", "VuOrderNo_OnlyForSale")
        Call ComboFillerOfFahimshekaib(cmbOrderNo, "VuOrderNo_OnlyForSale", "SalOrderNo", "SalOrderID")

        If EditValue = 1 Then
            ' First delete all exiting data of existing records.

            Call SalePaymentSave()

            Call GridSave()
            SaveIGL()
            SaveVoucher()
            'Call GridSubDetailUpdate()

            lblMessage.Text = "ریکارد شما موفقانه ثبت گردید"
            ' MsgBox("Your Record has been saved successfully..")
        Else
            If ds.Tables.Contains("SalePayment") Then
                DeleteSalePayment()
                Call SalePaymentSave()
                ds.Tables.Remove("SalePayment")
            End If
            Call DeleteGrid()
            Call GridSave()
            SaveVoucher()
            txtfill()
            'Call GridSubDetailUpdate()
            lblMessage.Text = "ریکارد شما موفقانه تجدید گردید"

            'MsgBox("Your Record has been updated successfully..")
        End If
        Call CStutus()
        CMStatus()
        DG.ReadOnly = True
        DGBtnTransfer.Visible = False
        'DGProductCode.Visible = False
        AddEdit = False

        FrmSalePaymentDialogueBox.Dispose()
        FrmSaleQtyTranfered.Dispose()

        If cmbOrderNo.Enabled = True Then
            cmbOrderNo.Enabled = False
        End If

        MnuSearch.Enabled = True

    End Sub
    Private Sub MnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuEdit.Click
        Call CStutus()
        EditValue = 0
        CMStatus()

        DG.ReadOnly = False
        DGDisabler()
        DGBtnTransfer.Visible = True
        'DGProductCode.Visible = True
        AddEdit = True
        lblMessage.Text = ""

        cmbOrderNo.Enabled = False

        If MnuSearch.Visible = False Then
            MnuSearch.Visible = True
            Label10.Visible = False
            cmbInvoiceNoSearch.Visible = False
            Label12.Visible = False
            cmbCustomerTypeSearch.Visible = False
            Label13.Visible = False
            cmbCustomerNameSearch.Visible = False
            MnuReturn.Visible = False
        End If

        MnuSearch.Enabled = False
    End Sub


    Private Sub MnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDelete.Click
        If Not Me.Var_SaleID.Equals("") Then

            If MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then

                Module1.DeleteRecord("SaleMain", "SaleID = " & Me.Var_SaleID)
                Module1.DeleteRecord("SaleSubDetail", "SaleID = " & Me.Var_SaleID)
                Module1.Opencn()

                cmd.CommandText = " Delete from SaleSubDetail where SaleID=" & Var_SaleID
                cmd.Connection = cn
                cmd.ExecuteNonQuery()

                cmd.CommandText = " Delete from IGL where ID=" & Var_SaleID & "  And Type='Sale'"
                cmd.Connection = cn
                cmd.ExecuteNonQuery()

                cmd.CommandText = " Delete from VoucherMain where Vno='" & txtInvoice.Text & "'"
                cmd.Connection = cn
                cmd.ExecuteNonQuery()

                cnt = ds.Tables("SaleMain").Rows.Count - 1
                If cnt = 0 Then
                    Call ClearTheWholeForm()

                    Exit Sub
                Else
                    cnt = cnt - 1
                    Call txtfill()
                End If
                lblMessage.Text = "ریکارد مذکور موفقانه حذف گردید "
                ' Call TxtFillAfterDeletion()

                If MnuSearch.Visible = False Then
                    MnuSearch.Visible = True
                    Label10.Visible = False
                    cmbInvoiceNoSearch.Visible = False
                    Label12.Visible = False
                    cmbCustomerTypeSearch.Visible = False
                    Label13.Visible = False
                    cmbCustomerNameSearch.Visible = False
                    MnuReturn.Visible = False
                End If

            End If
        End If

    End Sub
    Private Sub TxtFillAfterDeletion()

        If cnt <> Module1.ds.Tables("OrderFromCustomerMain").Rows.Count Then
            ' MsgBox(Module1.ds.Tables("OrderFromCustomerMain").Rows.Count)

            cnt = cnt - 1
            txtfill()
        Else
            If cnt <> 0 Then
                cnt = cnt - 1
                txtfill()
            Else
                MsgBox("There is no more record")
            End If
        End If
    End Sub



    Private Sub MnuUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuUndo.Click

        Call CStutus()
        CMStatus()
        Module1.DatasetFill("Select * from VuOrderNo_OnlyForSale ", "VuOrderNo_OnlyForSale")
        Call ComboFillerOfFahimshekaib(cmbOrderNo, "VuOrderNo_OnlyForSale", "SalOrderNo", "SalOrderID")

        Call txtfill()
        DG.ReadOnly = True
        DGBtnTransfer.Visible = False
        ' DGProductCode.Visible = False
        AddEdit = False
        WashUp()

        If cmbOrderNo.Enabled = True Then
            cmbOrderNo.Enabled = False
        End If

        MnuSearch.Enabled = True
    End Sub

    Private Sub MnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuExit.Click
        Me.Close()
        WashUp()

        For Each dtt As DataTable In ds.Tables
            If dtt.TableName.StartsWith("TableOfRowNo") Then
                MsgBox(ds.Tables.IndexOf(dtt))
                ds.Tables.Remove(dtt)
            End If

        Next
    End Sub
#End Region
    Sub WashUp()

        'If FrmSalePaymentDialogueBox.Visible = True Then
        FrmSalePaymentDialogueBox.P = True
        FrmSalePaymentDialogueBox.Var_PaymentFormIsOpen = False
        FrmSalePaymentDialogueBox.Close()
        'End If

        If FrmSaleQtyTranfered.Visible = True Then
            FrmSaleQtyTranfered.P = True
            FrmSaleQtyTranfered.Close()
        End If

        Dim arr(ds.Tables.Count) As String
        Dim index As Integer = 0
        For Each datatbl As DataTable In ds.Tables
            If datatbl.TableName.StartsWith("TableOfRowNo") Then
                arr(index) = datatbl.TableName
                index = index + 1
            End If
        Next


        Dim intloop As Integer = 0
        Dim strTableName As String = ""
        For intloop = 0 To index - 1
            strTableName = arr(intloop)
            'MsgBox(strTableName)
            ds.Tables.Remove(strTableName)
        Next
        DGBtnTransfer.Visible = False
    End Sub
#Region "Navigation"
    Private Sub TSFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSFirst.Click
        WashUp()
        cnt = 0
        Call txtfill()
        CMStatusDefault()
        CStatusDefault()

    End Sub
    Private Sub TSPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSPrevious.Click
        WashUp()
        If cnt = 0 Then
            Call txtfill()
            If ds.Tables("SaleMain").Rows.Count = 0 Then Exit Sub
            CMStatusDefault()
            CStatusDefault()


        Else
            cnt = cnt - 1
            Call txtfill()
            CMStatusDefault()
            CStatusDefault()

        End If



    End Sub

    Private Sub TSNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSNext.Click
        WashUp()
        If cnt = ds.Tables("SaleMain").Rows.Count - 1 Then Exit Sub
        cnt = cnt + 1
        Call txtfill()
        CMStatusDefault()
        CStatusDefault()

    End Sub
    Private Sub TSLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSLast.Click
        WashUp()
        cnt = ds.Tables("SaleMain").Rows.Count - 1
        Call txtfill()
        CMStatusDefault()
        CStatusDefault()

    End Sub
#End Region
#Region "Fahimshekaib Special ComboFiller"
    Sub ComboFillerOfFahimshekaib(ByVal ComboName As ComboBox, ByVal NameOfTable As String, ByVal DisplayMember As String, ByVal ValueMember As String)

        ComboName.DataSource = ds.Tables(NameOfTable)
        ComboName.DisplayMember = DisplayMember
        ComboName.ValueMember = ValueMember
    End Sub
    Sub ComboFillerOfFahimshekaib(ByVal ComboName As DataGridViewComboBoxColumn, ByVal NameOfTable As String, ByVal DisplayMember As String, ByVal ValueMember As String)

        ComboName.DataSource = ds.Tables(NameOfTable)
        ComboName.DisplayMember = DisplayMember
        ComboName.ValueMember = ValueMember
    End Sub
#End Region


    Private Sub cmbCustomerType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomerType.SelectedIndexChanged
        'Try
        '    Module1.DatasetFill("Select * from Customer where CustomerTypeID =" & cmbCustomerType.SelectedValue, "Customer")
        '    Call ComboFillerOfFahimshekaib(cmbCustomerName, "Customer", "CustomerName", "CustomerID")
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub cmbOrderNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOrderNo.SelectedIndexChanged

        Try
            If AddEdit.Equals(True) Then
                Module1.DatasetFill("Select * From VuCustomerForSaleOrder where SalOrderID = " & cmbOrderNo.SelectedValue, "VuCustomerForSaleOrder")
                'cmbCustomerType.SelectedValue = -1
                cmbCustomerType.Text = ds.Tables("VuCustomerForSaleOrder").Rows(0).Item("CustomerTypeName")

                ' because when selected index of cmbcustomertype not changed, it was not called in selected index changed, so i pasted it here.
                'cmbCustomerName.SelectedValue = 0
                'index = ds.Tables("VuCustomerForSaleOrder").Rows(0).Item("CustomerName")
                cmbCustomerName.Text = ds.Tables("VuCustomerForSaleOrder").Rows(0).Item("CustomerName")
                cmbLocation.SelectedValue = ds.Tables("VuCustomerForSaleOrder").Rows(0).Item("LocID")
                cmbShop.SelectedValue = ds.Tables("VuCustomerForSaleOrder").Rows(0).Item("ShopID")
                If ds.Tables("VuCustomerForSaleOrder").Rows(0).Item("LocID") = 0 Then
                    'Incase this person doesn't have shop
                    cmbLocation.Visible = False
                    lblLocation.Visible = False
                    cmbShop.Visible = False
                    lblShop.Visible = False
                Else
                    'Incase this person has shop
                    cmbLocation.Visible = True
                    lblLocation.Visible = True
                    cmbShop.Visible = True
                    lblShop.Visible = True
                End If
                GridFillFromOrder()
            End If
        Catch ex As Exception
        End Try
        Try
            'added after testing.
            If ds.Tables.Contains(CurrentRowKaTable) And AddEdit = True Then
                ds.Tables.Remove(CurrentRowKaTable)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub ProductPriceFill()
        Try
            Module1.DatasetFill("Select PcsInCtrn,SalPerPiece,SalPerCrtn from VuProductPrices where ProdTypeID = " & DG.Rows(i).Cells("DGPType").Value & " and ProdCode =" & DG.Rows(i).Cells("DGProductCode").Value & "", "VuProductPrices")
            DG.Rows(i).Cells("DGPcsInCrtn").Value = ds.Tables("VuProductPrices").Rows(0).Item("PcsInCtrn")
            DG.Rows(i).Cells("DGPricePerPcs").Value = ds.Tables("VuProductPrices").Rows(0).Item("SalPerPiece")
            DG.Rows(i).Cells("DGPricePerCrtn").Value = ds.Tables("VuProductPrices").Rows(0).Item("SalPerCrtn")
        Catch ex As Exception
        End Try
    End Sub
    Sub GridFillFromOrder()
        Try

            DG.Rows.Clear()
            Module1.DatasetFill("Select * from VuOrderFromCustomerDetail where SalOrderID = " & cmbOrderNo.SelectedValue, "VuOrderFromCustomerDetail")
            For i = 0 To ds.Tables("VuOrderFromCustomerDetail").Rows.Count - 1
                DG.Rows.Add()
                DG.Rows(i).Cells("DGSNo").Value = ds.Tables("VuOrderFromCustomerDetail").Rows(i).Item("SNo")
                DG.Rows(i).Cells("DGPType").Value = ds.Tables("VuOrderFromCustomerDetail").Rows(i).Item("ProdTypeID")
                DG.Rows(i).Cells("DGProductCode").Value = ds.Tables("VuOrderFromCustomerDetail").Rows(i).Item("ProdCode")
                DG.Rows(i).Cells("DGCrtnPcs").Value = ds.Tables("VuOrderFromCustomerDetail").Rows(i).Item("CrtnPcs")
                DG.Rows(i).Cells("DGQty").Value = ds.Tables("VuOrderFromCustomerDetail").Rows(i).Item("Qty")
                DG.Rows(i).Cells("DGDeliveredQty").Value = "0"
                DG.Rows(i).Cells("DGRemainingQty").Value = ds.Tables("VuOrderFromCustomerDetail").Rows(i).Item("Qty")
                DG.Rows(i).Cells("DGPrice").Value = "0"
                DG.Rows(i).Cells("DGDesciption").Value = "---"
                ProductPriceFill()
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub GridFill()
        Try
            Dim i As Integer = 0

            DG.Rows.Clear()

            Module1.DatasetFill("Select * from SaleDetail where SaleID = " & Var_SaleID, "SaleDetail")
            For i = 0 To ds.Tables("SaleDetail").Rows.Count - 1

                DG.Rows.Add()
                DG.Rows(i).Cells("DGSNo").Value = ds.Tables("SaleDetail").Rows(i).Item("SNo")
                DG.Rows(i).Cells("DGPType").Value = ds.Tables("SaleDetail").Rows(i).Item("ProdTypeID")
                DG.Rows(i).Cells("DGProductCode").Value = ds.Tables("SaleDetail").Rows(i).Item("ProdCode")
                DG.Rows(i).Cells("DGPcsInCrtn").Value = ds.Tables("SaleDetail").Rows(i).Item("PcsInCrtn")
                DG.Rows(i).Cells("DGPricePerPcs").Value = ds.Tables("SaleDetail").Rows(i).Item("PricePerPcs")
                DG.Rows(i).Cells("DGPricePerCrtn").Value = ds.Tables("SaleDetail").Rows(i).Item("PricePerCrtn")
                DG.Rows(i).Cells("DGCrtnPcs").Value = ds.Tables("SaleDetail").Rows(i).Item("CrtnPcs")
                DG.Rows(i).Cells("DGQty").Value = ds.Tables("SaleDetail").Rows(i).Item("Qty")
                DG.Rows(i).Cells("DGDeliveredQty").Value = ds.Tables("SaleDetail").Rows(i).Item("DeliveredQty")
                DG.Rows(i).Cells("DGRemainingQty").Value = ds.Tables("SaleDetail").Rows(i).Item("RemainingQty")
                DG.Rows(i).Cells("DGPrice").Value = ds.Tables("SaleDetail").Rows(i).Item("Price")
                DG.Rows(i).Cells("DGDesciption").Value = ds.Tables("SaleDetail").Rows(i).Item("ProdDescription")
                DG.Rows(i).Cells("DGManDate").Value = ds.Tables("SaleDetail").Rows(i).Item("ManDate")
                DG.Rows(i).Cells("DGExpDate").Value = ds.Tables("SaleDetail").Rows(i).Item("ExpDate")

            Next
        Catch ex As Exception

        End Try
    End Sub
    
    Sub SalePaymentSave()

        ' FrmSalePaymentDialogueBox.Visible = True


        Dim cmdsaveGrid As New SqlCommand
        cmdsaveGrid.CommandType = CommandType.StoredProcedure
        cmdsaveGrid.CommandText = "InsertUpdateSalePayment"
        cmdsaveGrid.Connection = cn
        Try

            For a = 0 To FrmSalePaymentDialogueBox.DGDiag.Rows.Count - 2
                'Trans = cn.BeginTransaction("Fahim")
                cmdsaveGrid.Parameters.Add("@SaleID", SqlDbType.Int).Value = Var_SaleID



                cmdsaveGrid.Parameters.Add("@SNo", SqlDbType.Int).Value = FrmSalePaymentDialogueBox.DGDiag.Rows(a).Cells(0).Value
                cmdsaveGrid.Parameters.Add("@Amount", SqlDbType.Int).Value = FrmSalePaymentDialogueBox.DGDiag.Rows(a).Cells(1).Value

                Dim Var_PaymentDate As DateTime
                Try
                    If FrmSalePaymentDialogueBox.DGDiag.Rows(a).Cells(2).Value = #12:00:00 AM# Then
                        Var_PaymentDate = "01/01/1900"
                        cmdsaveGrid.Parameters.Add("@PaymentDate", SqlDbType.SmallDateTime).Value = Var_PaymentDate

                    Else
                        Var_PaymentDate = FrmSalePaymentDialogueBox.DGDiag.Rows(a).Cells(2).Value
                        cmdsaveGrid.Parameters.Add("@PaymentDate", SqlDbType.SmallDateTime).Value = Var_PaymentDate

                    End If
                Catch ex As Exception
                    Var_PaymentDate = "01/01/1900"
                    cmdsaveGrid.Parameters.Add("@PaymentDate", SqlDbType.SmallDateTime).Value = Var_PaymentDate

                End Try

                'cmdsaveGrid.Parameters.Add("@PaymentDate", SqlDbType.SmallDateTime).Value = FrmSalePaymentDialogueBox.DGDiag.Rows(a).Cells(2).Value
                ''cmdsaveGrid.Parameters.Add("@PaymentDate", SqlDbType.NVarChar).Value = FrmSalePaymentDialogueBox.DGDiag.Rows(a).Cells(2).Value
                cmdsaveGrid.Parameters.Add("@CityID", SqlDbType.Int).Value = Val("1")
                cmdsaveGrid.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = "KBL" & "-" & Me.Var_SaleID
                'Trans.Commit()

                If cn.State = ConnectionState.Closed Then cn.Open()
                cmdsaveGrid.ExecuteNonQuery()
                cmdsaveGrid.Parameters.Clear()
            Next
            'For Each frm As Form In Me.Controls
            '    If frm.Name = FrmSaleQtyTranfered.ToString() Then
            '        frm.Close()
            '    End If
            'Next

        Catch ex As Exception
            'Trans.Rollback()
        End Try
    End Sub


    Sub GridSave()
        Dim cmdsaveGrid As New SqlCommand
        cmdsaveGrid.CommandType = CommandType.StoredProcedure
        cmdsaveGrid.CommandText = "InsertUpdateSaleDetail"
        cmdsaveGrid.Connection = cn
        Try

            For a = 0 To DG.Rows.Count - 1 ' This is 1 because I haven't allowed an extra row at the end of the DataGrid.
                'Trans = cn.BeginTransaction("Fahim")
                cmdsaveGrid.Parameters.Add("@SaleID", SqlDbType.Int).Value = Var_SaleID
                cmdsaveGrid.Parameters.Add("@Sno", SqlDbType.Int).Value = DG.Rows(a).Cells("DGSno").Value
                cmdsaveGrid.Parameters.Add("@ProdTypeID", SqlDbType.Int).Value = DG.Rows(a).Cells("DGPType").Value
                cmdsaveGrid.Parameters.Add("@ProdCode", SqlDbType.Int).Value = DG.Rows(a).Cells("DGProductCode").Value

                cmdsaveGrid.Parameters.Add("@PcsInCrtn", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGPcsInCrtn").Value)
                cmdsaveGrid.Parameters.Add("@PricePerPcs", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGPricePerPcs").Value)
                cmdsaveGrid.Parameters.Add("@PricePerCrtn", SqlDbType.Decimal).Value = Val(DG.Rows(a).Cells("DGPricePerCrtn").Value)

                cmdsaveGrid.Parameters.Add("@CrtnPcs", SqlDbType.Int).Value = Val(DG.Rows(a).Cells("DGCrtnPcs").Value)

                cmdsaveGrid.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGQty").Value)

                cmdsaveGrid.Parameters.Add("@Price", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGPrice").Value)

                cmdsaveGrid.Parameters.Add("@DeliveredQty", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGDeliveredQty").Value)
                cmdsaveGrid.Parameters.Add("@RemainingQty", SqlDbType.Decimal).Value = Convert.ToDecimal(DG.Rows(a).Cells("DGRemainingQty").Value)
                If DG.Rows(a).Cells("DGDesciption").Value = Nothing Then
                    cmdsaveGrid.Parameters.Add("@ProdDescription", SqlDbType.NVarChar).Value = "---"
                Else
                    cmdsaveGrid.Parameters.Add("@ProdDescription", SqlDbType.NVarChar).Value = DG.Rows(a).Cells("DGDesciption").Value

                End If

                Try

                    If DG.Rows(a).Cells("DGManDate").Value = #12:00:00 AM# Then
                        Var_ManDate = "01/01/1900"
                        cmdsaveGrid.Parameters.Add("@ManDate", SqlDbType.SmallDateTime).Value = Var_ManDate

                    Else
                        Var_ManDate = Convert.ToDateTime(DG.Rows(a).Cells("DGManDate").Value)
                        cmdsaveGrid.Parameters.Add("@ManDate", SqlDbType.SmallDateTime).Value = Var_ManDate

                    End If
                Catch ex As Exception
                    Var_ManDate = "01/01/1900"
                    cmdsaveGrid.Parameters.Add("@ManDate", SqlDbType.SmallDateTime).Value = Var_ManDate

                End Try
                'MsgBox(Convert.ToDateTime(DG.Rows(a).Cells("DGManDate").Value))
                'cmdsaveGrid.Parameters.Add("@ManDate", SqlDbType.SmallDateTime).Value = Convert.ToDateTime(DG.Rows(a).Cells("DGManDate").Value)


                Try

                    If DG.Rows(a).Cells("DGExpDate").Value = #12:00:00 AM# Then
                        Var_ExpDate = "01/01/1900"
                        cmdsaveGrid.Parameters.Add("@ExpDate", SqlDbType.SmallDateTime).Value = Var_ExpDate

                    Else
                        Var_ExpDate = Convert.ToDateTime(DG.Rows(a).Cells("DGExpDate").Value)
                        cmdsaveGrid.Parameters.Add("@ExpDate", SqlDbType.SmallDateTime).Value = Var_ExpDate

                    End If
                Catch ex As Exception
                    Var_ExpDate = "01/01/1900"
                    cmdsaveGrid.Parameters.Add("@ExpDate", SqlDbType.SmallDateTime).Value = Var_ExpDate

                End Try
                'cmdsaveGrid.Parameters.Add("@ExpDate", SqlDbType.SmallDateTime).Value = Convert.ToDateTime(DG.Rows(a).Cells("DGExpDate").Value)




                'Trans.Commit()

                cmdsaveGrid.ExecuteNonQuery()
                cmdsaveGrid.Parameters.Clear()

                Call GetHostComputerInformation()
                ' Now for each successful insertion of grid row we call its sub detail grid insertion.

                Dim RowNum As String = Me.DG.Rows(a).Cells(0).Value
                TableKaName_ForInsertion = "TableOfRowNo " & RowNum
                RowWanted = RowNum - 1
                If ds.Tables.Contains(TableKaName_ForInsertion) Then


                    Call DeleteSaleSubDetailGrid()
                    Call SaveSaleSubDetailGrid()
                End If
            Next
        Catch ex As Exception
            'Trans.Rollback()
        End Try


    End Sub
    Sub DGDisabler()
        DGSno.ReadOnly = True
        DGPType.ReadOnly = True
        DGProductCode.ReadOnly = True
        DGDeliveredQty.ReadOnly = True
        DGPcsInCrtn.ReadOnly = True
        DGPricePerPcs.ReadOnly = True
        DGPricePerCrtn.ReadOnly = True
        DGPrice.ReadOnly = True
        DGQty.ReadOnly = True
        DGRemainingQty.ReadOnly = True
    End Sub
    Sub GetHostComputerInformation()
        'For retieving computer name and IP.
        'MsgBox(System.Net.Dns.GetHostEntry("localhost").HostName) ' Just for getting the host computer name.
        MyComputerName = System.Net.Dns.GetHostEntry("localhost").HostName
        Dim MyPCName As System.Net.IPHostEntry

        MyPCName = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())

        'MsgBox(MyComputerName)
        Dim IP() As System.Net.IPAddress
        IP = MyPCName.AddressList
        MyComputerIP = IP(0).ToString()

        'MsgBox(MyComputerIP)

    End Sub
#Region "New experiment"
    Sub SaveSaleSubDetailGrid()

        Dim cmdsaveGrid As New SqlCommand
        cmdsaveGrid.CommandType = CommandType.StoredProcedure
        cmdsaveGrid.CommandText = "OnlyInsertSaleSubDetail"
        cmdsaveGrid.Connection = cn
        Try

            For Each dtable As DataTable In ds.Tables
                If dtable.TableName = TableKaName_ForInsertion Then
                    For Each tr As DataRow In dtable.Rows

                        cmdsaveGrid.Parameters.Add("@SaleID", SqlDbType.Int).Value = Var_SaleID  'tr("SaleID") ' we better get Var_SaleID data here, althow in temporary table it is present,but in network it can be assigned to some other pc's record entry.
                        'MsgBox(tr("SaleID"))
                        cmdsaveGrid.Parameters.Add("@DGSNo", SqlDbType.Int).Value = tr("DGSno")
                        cmdsaveGrid.Parameters.Add("@DGTransferredSNo", SqlDbType.Int).Value = tr("Sno")
                        cmdsaveGrid.Parameters.Add("@DGTransferredQty", SqlDbType.Decimal).Value = tr("Qty")
                        Try

                            If tr("trdate") = #12:00:00 AM# Then
                                Var_TransferDate = "01/01/1900"
                                cmdsaveGrid.Parameters.Add("@DGTransferredDate", SqlDbType.SmallDateTime).Value = Var_TransferDate

                            Else
                                Var_TransferDate = tr("trdate")
                                cmdsaveGrid.Parameters.Add("@DGTransferredDate", SqlDbType.SmallDateTime).Value = Var_TransferDate

                            End If

                        Catch ex As Exception
                            'Var_TransferDate = "01/01/1900"
                            'cmdsaveGrid.Parameters.Add("@DGTransferredDate", SqlDbType.SmallDateTime).Value = Var_TransferDate
                            Dim fahim As String
                            fahim = tr("trdate")
                            Dim hh() As String
                            hh = Split(fahim, "/")
                            Dim b As String

                            b = hh(1) & "/" & hh(0) & "/" & hh(2)

                            bChangedToTime = Convert.ToDateTime(b)
                            Var_TransferDate = bChangedToTime
                            cmdsaveGrid.Parameters.Add("@DGTransferredDate", SqlDbType.SmallDateTime).Value = Var_TransferDate

                            'MsgBox(b)
                        End Try
                        cmdsaveGrid.Parameters.Add("@ComputerName", SqlDbType.NVarChar).Value = Me.MyComputerName
                        cmdsaveGrid.Parameters.Add("@ComputerIP", SqlDbType.NVarChar).Value = Me.MyComputerIP


                        'Trans.Commit()
                        If cn.State = ConnectionState.Closed Then cn.Open()
                        cmdsaveGrid.ExecuteNonQuery()
                        cmdsaveGrid.Parameters.Clear()
                    Next
                End If
                
            Next
            If EditValue <> 1 Then
                For Each dtable1 As DataTable In ds.Tables
                    If dtable1.TableName = TableKaName_ForInsertion Then
                        UpdateIGL()
                    End If
                Next
            End If

w:
            ' What I am doing here is that I am removing that temporary table which was created only because of this
            ' row, so as everything is saved all the temporary tables will be removed from the dataset.
            If ds.Tables.Contains(TableKaName_ForInsertion) = True Then
                ds.Tables.Remove(TableKaName_ForInsertion)

                '                    datatable()
            End If

        Catch ex As Exception
            'Trans.Rollback()
            GoTo w
        End Try
        'Sub SplitTheDate()

        '    End Sub

    End Sub
    Sub DeleteSaleSubDetailGrid()

        Dim cmdsave As New SqlCommand
        cmdsave.CommandType = CommandType.StoredProcedure
        cmdsave.CommandText = "DeleteSaleSubDetail"
        cmdsave.Connection = cn
        If EditValue = 1 Then
            'Dim VarNew_SaleID As Integer
            'VarNew_SaleID = Var_SaleID + 1
            'cmdsave.Parameters.Add("@SaleID", SqlDbType.Int).Value = VarNew_SaleID
        Else
            cmdsave.Parameters.Add("@SaleID", SqlDbType.Int).Value = Me.Var_SaleID

            cmdsave.Parameters.Add("@DGSNo", SqlDbType.Int).Value = Me.DG.Rows(a).Cells(0).Value
            cmdsave.ExecuteNonQuery()
        End If


    End Sub
#End Region

    Sub DeleteSalePayment()

        Dim cmdsave As New SqlCommand
        cmdsave.CommandType = CommandType.StoredProcedure
        cmdsave.CommandText = "DeleteSalePayment"
        cmdsave.Connection = cn
        cmdsave.Parameters.Add("@SaleID", SqlDbType.Int).Value = Var_SaleID
        cmdsave.ExecuteNonQuery()

    End Sub

    Sub DeleteGrid()

        Dim cmdsave As New SqlCommand
        cmdsave.CommandType = CommandType.StoredProcedure
        cmdsave.CommandText = "DeleteSaleDetail"
        cmdsave.Connection = cn
        cmdsave.Parameters.Add("@SaleID", SqlDbType.Int).Value = Var_SaleID
        cmdsave.ExecuteNonQuery()

    End Sub

    Private Sub DG_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DG.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPayment.Click
        'Var_SaleID = Var_SaleID
        Try
            If FrmSalePaymentDialogueBox.Var_PaymentFormIsOpen = True Then
                FrmSalePaymentDialogueBox.Visible = True
            Else
                FrmSalePaymentDialogueBox.Call_Is_From_FormName = Me.Name
                FrmSalePaymentDialogueBox.Visible = True
                FrmSalePaymentDialogueBox.TopMost = True
                ' FrmSalePaymentDialogueBox.MdiParent = Frm
                Try
                    If Me.EditValue = 0 Then
                        Call FrmSalePaymentDialogueBox.GridFill()
                    End If
                Catch ex As Exception

                End Try
                FrmSalePaymentDialogueBox.txtInvoice.Text = Me.txtInvoice.Text
                FrmSalePaymentDialogueBox.txtTotalToPay.Text = Me.txtTotalToPay.Text
                FrmSalePaymentDialogueBox.txtTotalPaid.Text = Me.txtTotalPaid.Text
                FrmSalePaymentDialogueBox.txtBalance.Text = Me.txtBalance.Text
            End If
        Catch ex As Exception
            FrmSalePaymentDialogueBox.ShowDialog()
        End Try

        '        FrmSalePaymentDialogueBox.ShowDialog()
        'FrmSalePaymentDialogueBox.Abc(Var_SaleID)


    End Sub
  

    Private Sub DG_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellValueChanged
        'Try
        '    calc()
        'Catch ex As Exception

        'End Try


        Dim Total As Double = 0
        Try
            If DG.CurrentRow.Cells("DGCrtnPcs").Value = 1 Then
                Total = Total + Val(DG.CurrentRow.Cells("DGPricePerPcs").Value) * Val(DG.CurrentRow.Cells("DGDeliveredQty").Value)
                DG.CurrentRow.Cells("DGPrice").Value = Total
            Else
                Total = Total + Val(DG.CurrentRow.Cells("DGPricePerCrtn").Value) * Val(DG.CurrentRow.Cells("DGDeliveredQty").Value)
                DG.CurrentRow.Cells("DGPrice").Value = Total
            End If
        Catch ex As Exception
        End Try


        Dim CalculateAmount As Decimal = 0
        Dim Increamenter As Integer = 0
        Try

            If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGBtnTransfer" Or DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGCrtnPcs" Then
                If azizkhanqarabaghi = True Then
                    For Each Row As DataGridViewRow In DG.Rows
                        CalculateAmount = Val(CalculateAmount) + Val(Convert.ToDecimal(DG.Rows(Increamenter).Cells("DGPrice").Value))
                        Increamenter = Increamenter + 1
                    Next
                    txtTotalToPayWithoutDiscount.Text = CalculateAmount
                    txtDiscount.Text = 0
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub calc()
        Dim Total As Decimal = 0
        Dim a As Integer
        Try
            For a = 0 To DG.Rows.Count - 1
                Total = Total + Val(DG.Rows(a).Cells("DGPrice").Value)
            Next
            Me.txtTotalToPay.Text = Total
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DTManForGrid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTManForGrid.KeyPress
        DG.CurrentRow.Cells("DGManDate").Value = DTManForGrid.Value.Date()
    End Sub


    Private Sub DTExpForGrid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTExpForGrid.KeyPress
        DG.CurrentRow.Cells("DGExpDate").Value = DTExpForGrid.Value.Date()
    End Sub

    Private Sub FrmSale_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        For Each ctrl As Control In Frm.Controls
            If TypeOf ctrl Is Form Then
                If ctrl.Name = "FrmSalePaymentDialogueBox" Or ctrl.Name = "FrmSaleQtyTranfered" Then
                    ctrl.Dispose()
                End If
            End If
        Next

    End Sub
    Private Sub DG_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DG.RowsAdded
        Try
            DG.Rows(e.RowIndex).Cells("DGBtnTransfer").Value = "انتقال"
        Catch ex As Exception

        End Try
    End Sub


#Region " STOCK CHECKER "

    Sub FinalCalculate()
        Dim Amad As Double = 0
        Dim Raft As Double = 0
        Dim Total As Double = 0
        'Dim a As Integer
        Try
            'For a = 0 To DG.Rows.Count - 1
            Amad = 0
            Raft = 0
            Amad = Amad + Val(purchaseQty) + Val(TotalReturn)
            Raft = Raft + Val(TotalSale) + Val(TotalClaim) + Val(TotalDamage)
            Total = Amad - Raft
            CrtnIntoPcs = Val(Total) * Val(PcsInCrtn)
            FrmSaleQtyTranfered.txtRemainingStock.Text = Total
            'MsgBox(FrmSaleQtyTranfered.txtRemainingStock.Text)
            'Next
            FrmSaleQtyTranfered.txtRemainingStockPcs.Text = CrtnIntoPcs
        Catch ex As Exception

        End Try
    End Sub

    Sub Calculator()
        'Dim b As String
        Dim CrtnPcsDivision As Decimal
        Dim c As Decimal
        Dim aziz As String
        Dim Fullportion As String
        Dim PointPortion As String
        Dim ReadyToAssignValue As String
        Try
            CrtnPcsDivision = Val(SalePerPcsQty) / PcsInCrtn
            If CrtnPcsDivision = 0 Then
                TotalSale = SalePerCrtnQty
                Exit Try
            Else
                aziz = CrtnPcsDivision
                azizspliter = aziz.Split(".")
                If azizspliter.Length > 1 Then
                    If azizspliter(1).Length > 2 Then
                        Fullportion = azizspliter(0)
                        PointPortion = azizspliter(1)
                        'b = CType(CrtnPcsDivision, String) ' bekara shud.
                        c = PointPortion.Substring(0, 2)
                        ReadyToAssignValue = Fullportion & "." & c
                        TotalSale = Val(SalePerCrtnQty) + ReadyToAssignValue
                    Else
                        TotalSale = Val(SalePerCrtnQty) + CrtnPcsDivision
                    End If
                Else
                    TotalSale = Val(SalePerCrtnQty) + CrtnPcsDivision
                End If
            End If
        Catch ex As Exception
        End Try

        Try
            CrtnPcsDivision = Val(ReturnPerPcsQty) / PcsInCrtn
            If CrtnPcsDivision = 0 Then
                TotalReturn = ReturnPerCrtnQty
                Exit Try
            Else
                aziz = CrtnPcsDivision
                azizspliter = aziz.Split(".")
                If azizspliter.Length > 1 Then
                    If azizspliter(1).Length > 2 Then
                        Fullportion = azizspliter(0)
                        PointPortion = azizspliter(1)
                        'b = CType(CrtnPcsDivision, String) ' bekara shud.
                        c = PointPortion.Substring(0, 2)
                        ReadyToAssignValue = Fullportion & "." & c
                        TotalReturn = Val(ReturnPerCrtnQty) + ReadyToAssignValue
                    Else
                        TotalReturn = Val(ReturnPerCrtnQty) + CrtnPcsDivision
                    End If
                Else
                    TotalReturn = Val(ReturnPerCrtnQty) + CrtnPcsDivision
                End If
            End If
        Catch ex As Exception
        End Try

        Try
            CrtnPcsDivision = Val(ClaimPerPcsQty) / PcsInCrtn
            If CrtnPcsDivision = 0 Then
                TotalClaim = ClaimPerCrtnQty
                Exit Try

            Else
                aziz = CrtnPcsDivision
                azizspliter = aziz.Split(".")
                If azizspliter.Length > 1 Then
                    If azizspliter(1).Length > 2 Then
                        Fullportion = azizspliter(0)
                        PointPortion = azizspliter(1)
                        'b = CType(CrtnPcsDivision, String) ' bekara shud.
                        c = PointPortion.Substring(0, 2)
                        ReadyToAssignValue = Fullportion & "." & c
                        TotalClaim = Val(ClaimPerCrtnQty) + ReadyToAssignValue
                    Else
                        TotalClaim = Val(ClaimPerCrtnQty) + CrtnPcsDivision
                    End If
                Else
                    TotalClaim = Val(ClaimPerCrtnQty) + CrtnPcsDivision
                End If
            End If
        Catch ex As Exception
        End Try

        Try
            CrtnPcsDivision = Val(DamagePerPcsQty) / PcsInCrtn
            If CrtnPcsDivision = 0 Then
                TotalDamage = DamagePerCrtnQty
                Exit Try
            Else
                aziz = CrtnPcsDivision
                azizspliter = aziz.Split(".")
                If azizspliter.Length > 1 Then
                    If azizspliter(1).Length > 2 Then
                        Fullportion = azizspliter(0)
                        PointPortion = azizspliter(1)
                        'b = CType(CrtnPcsDivision, String) ' bekara shud.
                        c = PointPortion.Substring(0, 2)
                        ReadyToAssignValue = Fullportion & "." & c
                        TotalDamage = Val(DamagePerCrtnQty) + ReadyToAssignValue
                    Else
                        TotalDamage = Val(DamagePerCrtnQty) + CrtnPcsDivision
                    End If
                Else
                    TotalDamage = Val(DamagePerCrtnQty) + CrtnPcsDivision
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Sub Selecter()

        Try
            Module1.DatasetFill("Select Sum(PurchaseQty) As Purchase from IGL where ProductCode=" & ProdCode & " and Type='Purchase'", "IGL")
            If ds.Tables("IGL").Rows(0).IsNull("Purchase") Then
                purchaseQty = 0
            Else
                purchaseQty = ds.Tables("IGL").Rows(0).Item("Purchase")
            End If
        Catch ex As Exception
        End Try

        Try
            Module1.DatasetFill("Select Sum(SaleQty) As SalePcs from IGL where ProductCode=" & ProdCode & " and Type='Sale' and CrtnPcs = 1", "IGL")
            If ds.Tables("IGL").Rows(0).IsNull("SalePcs") Then
                SalePerPcsQty = 0
            Else
                SalePerPcsQty = ds.Tables("IGL").Rows(0).Item("SalePcs")
            End If
        Catch ex As Exception
        End Try

        Try
            Module1.DatasetFill("Select Sum(SaleQty) As SaleCrtn from IGL where ProductCode=" & ProdCode & " and Type='Sale' and CrtnPcs = 2", "IGL")
            If ds.Tables("IGL").Rows(0).IsNull("SaleCrtn") Then
                SalePerCrtnQty = 0
            Else
                SalePerCrtnQty = ds.Tables("IGL").Rows(0).Item("SaleCrtn")
            End If
        Catch ex As Exception
        End Try

        Try
            Module1.DatasetFill("Select Sum(ReturnQty) As ReturnPcs from IGL where ProductCode=" & ProdCode & " and Type='Sale Return' and CrtnPcs = 1", "IGL")
            If ds.Tables("IGL").Rows(0).IsNull("ReturnPcs") Then
                ReturnPerPcsQty = 0
            Else
                ReturnPerPcsQty = ds.Tables("IGL").Rows(0).Item("ReturnPcs")
            End If
        Catch ex As Exception
        End Try

        Try
            Module1.DatasetFill("Select Sum(ReturnQty) As ReturnCrtn from IGL where ProductCode=" & ProdCode & " and Type='Sale Return' and CrtnPcs = 2", "IGL")
            If ds.Tables("IGL").Rows(0).IsNull("ReturnCrtn") Then
                ReturnPerCrtnQty = 0
            Else
                ReturnPerCrtnQty = ds.Tables("IGL").Rows(0).Item("ReturnCrtn")
            End If
        Catch ex As Exception
        End Try

        Try
            Module1.DatasetFill("Select Sum(ClaimQty) As ClaimPcs from IGL where ProductCode=" & ProdCode & " and Type='Claim' and CrtnPcs = 1", "IGL")
            If ds.Tables("IGL").Rows(0).IsNull("ClaimPcs") Then
                ClaimPerPcsQty = 0
            Else
                ClaimPerPcsQty = ds.Tables("IGL").Rows(0).Item("ClaimPcs")
            End If
        Catch ex As Exception
        End Try

        Try
            Module1.DatasetFill("Select Sum(ClaimQty) As ClaimCrtn from IGL where ProductCode=" & ProdCode & " and Type='Claim' and CrtnPcs = 2", "IGL")
            If ds.Tables("IGL").Rows(0).IsNull("ClaimCrtn") Then
                ClaimPerCrtnQty = 0
            Else
                ClaimPerCrtnQty = ds.Tables("IGL").Rows(0).Item("ClaimCrtn")
            End If
        Catch ex As Exception
        End Try

        Try
            Module1.DatasetFill("Select Sum(DamageQty) As DamagePcs from IGL where ProductCode=" & ProdCode & " and Type='Damage' and CrtnPcs = 1", "IGL")
            If ds.Tables("IGL").Rows(0).IsNull("DamagePcs") Then
                DamagePerPcsQty = 0
            Else
                DamagePerPcsQty = ds.Tables("IGL").Rows(0).Item("DamagePcs")
            End If
        Catch ex As Exception
        End Try

        Try
            Module1.DatasetFill("Select Sum(DamageQty) As DamageCrtn from IGL where ProductCode=" & ProdCode & " and Type='Damage' and CrtnPcs = 2", "IGL")
            If ds.Tables("IGL").Rows(0).IsNull("DamageCrtn") Then
                DamagePerCrtnQty = 0
            Else
                DamagePerCrtnQty = ds.Tables("IGL").Rows(0).Item("DamageCrtn")
            End If
        Catch ex As Exception
        End Try

        Calculator()

        FinalCalculate()

    End Sub

#End Region

    Private Sub DG_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellClick

        'If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGBtnTransfer" Then
        'of aziz ,but when mustafa sold mistakenly in carton and went to change it back to piece,then it didn't calculate
        'the amount, this way I fixed it there so I thought regarding calculation of the quantities I should add it here too.
        'aziz code of If conditions has been commented above.
        'ok leave that , after discussing with aziz we came up with this decision that if any user enters work data he should delete that
        'record and re enter it.
        'If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGBtnTransfer" Or DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGCrtnPcs" Then
        If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGBtnTransfer" Then
            Try
                ' Dim RowIndex As Object
                ' RowIndex = DG.CurrentRow.Index

                'Dim Frm & RowIndex As New FrmSaleQtyTranfered

                FrmSaleQtyTranfered.txtProdType.Text = DG.CurrentRow.Cells("DGPType").FormattedValue()
                FrmSaleQtyTranfered.txtProdName.Text = Me.DG.CurrentRow.Cells("DGProductCode").FormattedValue()
                ProdCode = Me.DG.CurrentRow.Cells("DGProductCode").Value
                PcsInCrtn = DG.CurrentRow.Cells("DGPcsinCrtn").Value
                FrmSaleQtyTranfered.txtTotalQty.Text = Me.DG.CurrentRow.Cells("DGQty").FormattedValue()
                FrmSaleQtyTranfered.txtTransferredQty.Text = Me.DG.CurrentRow.Cells("DGDeliveredQty").Value
                FrmSaleQtyTranfered.txtRemainingQty.Text = Me.DG.CurrentRow.Cells("DGRemainingQty").Value

                FrmSaleQtyTranfered.Visible = True
                FrmSaleQtyTranfered.TopMost = True

                Dim RowNumberForConcatination As String = Me.DG.CurrentRow.Cells(0).Value
                CurrentRowKaTable = "TableOfRowNo " & RowNumberForConcatination

                If ds.Tables.Contains(CurrentRowKaTable) Then
                    ' MsgBox("apne table se bhar do")
                    FrmSaleQtyTranfered.DGTransfer.Rows.Clear()
                    Call FrmSaleQtyTranfered.GridFillFrom_CurrentRowKaTable()
                    Selecter()
                Else
                    ' I commented this because as the form was called to become visible, it automatically called that forms load,
                    ' so this GridFill was being called two time, no need for that.
                    FrmSaleQtyTranfered.GridFill()
                    Selecter()
                End If

            Catch ex As Exception

                'FrmSaleQtyTranfered.ShowDialog()
            End Try
            '        FrmSalePaymentDialogueBox.ShowDialog()
            'FrmSalePaymentDialogueBox.Abc(Var_SaleID)
            '-------------------------
            OldQty = FrmSaleQtyTranfered.txtTransferredQty.Text
        End If
    End Sub
    Private Sub NumericKeys(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' Now we don;t use this, hech badard namekhora. magar dar SaleReturn kar meyaya.
        If DG.CurrentCell.ColumnIndex = 8 Or DG.CurrentCell.ColumnIndex = 11 Then
            If IsNumeric(Me.ActiveControl.Text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Then e.Handled = True
        End If
    End Sub
    Private Sub DG_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DG.EditingControlShowing
        If DG.CurrentCell.ColumnIndex = 8 Or DG.CurrentCell.ColumnIndex = 11 Then
            Dim ltxt As New TextBox
            ltxt = CType(e.Control, TextBox)
            AddHandler ltxt.KeyPress, AddressOf NumericKeys
        End If
        'Delegation for setting data in a cell without having to leave that cell.
        Dim cont As Control = e.Control
        Dim tpe As Type = cont.GetType
        If tpe.FullName = "System.Windows.Forms.DataGridViewTextBoxEditingControl" Then
            Try
                Dim ltxt As New TextBox
                ltxt = CType(e.Control, TextBox)
                AddHandler ltxt.KeyPress, AddressOf DelegateCellData

            Catch ex As Exception

            End Try
        ElseIf tpe.FullName = "System.Windows.Forms.DataGridViewComboBoxEditingControl" Then
            'Try
            '    Dim cmb As ComboBox
            '    cmb = CType(e.Control, ComboBox)
            '    AddHandler cmb.SelectionChangeCommitted, AddressOf DelegateCellData

            'Catch ex As Exception
            'End Try
        End If

    End Sub
    Private Sub DelegateCellData(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Me.DG.CurrentCell.Value = Me.ActiveControl.Text & e.KeyChar
    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            If Var_SaleID = 0 Then
                Exit Sub
            Else
                Module1.DatasetFill("Select * from RptVuSaleMain where SaleID=" & Var_SaleID, "RptVuSaleMain")
                Dim rpt As New RptSale
                rpt.SetDataSource(Module1.ds.Tables("RptVuSaleMain"))
                frmRptSetup.CV.ReportSource = rpt
                Frm.RptShow()
                'Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub InvoiceNoGenerator()
        Dim _m As String
        Dim _y As String
        Dim _MaxID As String
        Dim _Criteria As String
        _m = Date.Now.Month
        _y = Date.Now.Year
        _y = _y.Substring(2, 2)

        If _m.Length = 1 Then
            _m = "0" & _m
        End If
        _Criteria = "IAL-SAL-" & _m & "-" & _y & "-"

        Try

            Dim sqldreader As SqlDataReader
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select Max(Convert(INT,Substring(InvoiceNo,15,len(InvoiceNo)))) from salemain where InvoiceNo Like('" & _Criteria & "%'" & ")"
            cmd.Connection = cn
            If cn.State = ConnectionState.Closed Then cn.Open()
            sqldreader = cmd.ExecuteReader()
            While sqldreader.Read

                If IsDBNull(sqldreader.Item(0)) = True Then
                    _MaxID = 1
                Else
                    _MaxID = Val(sqldreader.Item(0)) + 1

                End If
            End While
            sqldreader.Close()

            If _m.Length = 1 Then
                _m = "0" & _m
            End If
            If _MaxID.Length = 1 Then
                _MaxID = "0" & _MaxID
            End If
            _InvoiceNo = "IAL-SAL-" & _m & "-" & _y & "-" & _MaxID
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub txtTotalToPay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalToPay.TextChanged
        Try
            CalcTotal()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtBalance_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBalance.TextChanged
        Try
            CalcTotal()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTotalPaid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalPaid.TextChanged
        Try
            CalcTotal()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtDiscount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscount.TextChanged
        Try
            Try
                Dim azizkhan As Decimal
                azizkhan = Val(txtTotalToPayWithoutDiscount.Text) - Val(txtDiscount.Text)
                If azizkhan < 0 Then
                    Dim abc As String = txtDiscount.Text
                    abc = abc.Remove(abc.Length - 1, 1)
                    txtDiscount.Text = txtDiscount.Text.Replace(txtDiscount.Text, abc)
                    Me.txtDiscount.Select(0, Me.txtDiscount.Text.Length)
                Else
                    txtTotalToPay.Text = azizkhan
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTotalToPayWithoutDiscount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalToPayWithoutDiscount.TextChanged
        Try
            Dim azizkhan As Double
            azizkhan = Val(txtTotalToPayWithoutDiscount.Text) - Val(txtDiscount.Text)
            If azizkhan < 0 Then
            Else
                txtTotalToPay.Text = azizkhan
            End If
        Catch ex As Exception

        End Try
    End Sub
    Dim btext As Boolean = True
    Private Sub txtDiscount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscount.KeyPress

        Try

            If IsNumeric(sender.text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Then
                e.Handled = True
            Else


                Dim aziz As Decimal
                If Asc(e.KeyChar) = 8 Then
                Else
                    'If btext Then
                    ' txtDiscount.Text = Me.ActiveControl.Text & e.KeyChar
                    aziz = Val(txtTotalToPayWithoutDiscount.Text) - Val(txtDiscount.Text)
                    If Val(txtDiscount.Text) > Val(aziz) Then
                        e.Handled = True

                    End If
                    'Dim str As String = Convert.ToString(txtDiscount.Text)
                    'str.Remove(str.Length - 2, 2)
                    'txtDiscount.Text = str
                    ' btext = False
                    'Me.txtDiscount.Text = txtDiscount.Text.Substring(Me.txtDiscount.Text.Length - 1)
                End If
                ' End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtRemarks_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemarks.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub MnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSearch.Click
        Try

            

            Module1.DatasetFill("Select * from VuCustomerTypeForSaleMainSearch", "VuCustomerTypeForSaleMainSearch")
            cmbCustomerTypeSearch.DataSource = ds.Tables("VuCustomerTypeForSaleMainSearch")
            cmbCustomerTypeSearch.DisplayMember = ("CustomerTypeName")
            cmbCustomerTypeSearch.ValueMember = ("CustomerTypeID")


            ClearTheWholeForm()

            cmbCustomerTypeSearch.SelectedIndex = 0

            Label10.Visible = True
            cmbInvoiceNoSearch.Visible = True
            Label12.Visible = True
            cmbCustomerTypeSearch.Visible = True
            Label13.Visible = True
            cmbCustomerNameSearch.Visible = True

            MnuReturn.Visible = True
            MnuSearch.Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MnuReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuReturn.Click
        If DG.Rows.Count = 0 And txtInvoice.Text = "" Then
            Module1.DatasetFill("Select * from VuOrderNo_OnlyForSale ", "VuOrderNo_OnlyForSale")
            ComboFillerOfFahimshekaib(cmbOrderNo, "VuOrderNo_OnlyForSale", "SalOrderNo", "SalOrderID")
            txtfill()
        End If

        cmbInvoiceNoSearch.Visible = False
        Label10.Visible = False
        Label12.Visible = False
        cmbCustomerTypeSearch.Visible = False
        Label13.Visible = False
        cmbCustomerNameSearch.Visible = False

        MnuSearch.Visible = True
        MnuReturn.Visible = False
    End Sub

    Private Sub cmbInvoiceNoSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbInvoiceNoSearch.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then

                Dim Var_numberOfOccurance As Integer = 0
                Dim Var_PostionFound As Integer = 0
                Dim Var_loopLength As Integer = 0
                Dim Var_LetAssignment As Boolean = True
                For Each dtr As DataRow In ds.Tables("SaleMain").Rows
                    If cmbInvoiceNoSearch.SelectedValue = dtr("SaleID") Then
                        Var_numberOfOccurance += 1

                    Else

                    End If
                    If Var_numberOfOccurance = 1 And Var_LetAssignment = True Then
                        Var_PostionFound = Var_loopLength
                        Var_LetAssignment = False
                    End If
                    Var_loopLength += 1
                Next
                If Var_numberOfOccurance = 0 Then
                    txtclear(Me, pnlcentre, TB1, TP1)
                    'Module1.GetMax("SocialDataID", "SocialData")
                    'lblRecNo.Text = Module1.MaxID
                    'CStatusDefault()
                    MnuEdit.Enabled = False
                    MnuNew.Enabled = True

                    Exit Sub
                Else
                    cnt = Var_PostionFound

                    'Module1.DatasetFill("Select * from VuOrderNo_OnlyForSale ", "VuOrderNo_OnlyForSale")
                    'ComboFillerOfFahimshekaib(cmbOrderNo, "VuOrderNo_OnlyForSale", "SalOrderNo", "SalOrderID")

                    'Module1.DatasetFill("Select * from SaleMain where SaleID=" & cmbInvoiceNoSearch.SelectedValue, "SaleMain")

                    If ds.Tables("SaleMain").Rows.Count = 0 Then
                        Var_SaleID = 0
                        Call ClearTheWholeForm()
                        Exit Sub
                    End If

                    Me.Var_SaleID = Val(ds.Tables("SaleMain").Rows(cnt).Item("SaleID"))
                    txtInvoice.Text = ds.Tables("SaleMain").Rows(cnt).Item("InvoiceNo")
                    cmbCustomerType.SelectedIndex = -1
                    cmbCustomerType.SelectedValue = ds.Tables("SaleMain").Rows(cnt).Item("CustomerTypeID")
                    cmbCustomerName.SelectedIndex = -1
                    cmbCustomerName.SelectedValue = ds.Tables("SaleMain").Rows(cnt).Item("CustomerID")
                    cmbLocation.SelectedValue = ds.Tables("SaleMain").Rows(cnt).Item("LocID")
                    cmbShop.SelectedValue = ds.Tables("SaleMain").Rows(cnt).Item("ShopID")
                    If ds.Tables("SaleMain").Rows(cnt).Item("LocID") = 0 Then
                        'Incase this person doesn't have shop
                        cmbLocation.Visible = False
                        lblLocation.Visible = False
                        cmbShop.Visible = False
                        lblShop.Visible = False
                    Else
                        'Incase this person has shop
                        cmbLocation.Visible = True
                        lblLocation.Visible = True
                        cmbShop.Visible = True
                        lblShop.Visible = True
                    End If
                    dtSaleDate.Value = ds.Tables("SaleMain").Rows(cnt).Item("SaleDate")
                    cmbOrderNo.SelectedValue = ds.Tables("SaleMain").Rows(cnt).Item("SalOrderID")

                    txtTotalToPayWithoutDiscount.Text = ds.Tables("SaleMain").Rows(cnt).Item("TotalWithOutDiscount")
                    txtDiscount.Text = ds.Tables("SaleMain").Rows(cnt).Item("Discount")
                    txtTotalToPay.Text = ds.Tables("SaleMain").Rows(cnt).Item("TotalAmount")
                    txtTotalPaid.Text = ds.Tables("SaleMain").Rows(cnt).Item("TotalPaid")

                    txtBalance.Text = ds.Tables("SaleMain").Rows(cnt).Item("Balance")
                    txtRemarks.Text = ds.Tables("SaleMain").Rows(cnt).Item("Remarks")

                    Call GridFill()

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmbCustomerTypeSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomerTypeSearch.SelectedIndexChanged
        Try
            Module1.DatasetFill("Select * from VuCustomerNameForSaleMainSearch where CustomerTypeID=" & cmbCustomerTypeSearch.SelectedValue, "VuCustomerNameForSaleMainSearch")
            cmbCustomerNameSearch.DataSource = ds.Tables("VuCustomerNameForSaleMainSearch")
            cmbCustomerNameSearch.DisplayMember = ("CustomerName")
            cmbCustomerNameSearch.ValueMember = ("CustomerID")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmbCustomerNameSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomerNameSearch.SelectedIndexChanged
        Try

            Module1.DatasetFill("Select * from VuInvoiceNoForSaleMainSearch where CustomerTypeID=" & cmbCustomerTypeSearch.SelectedValue & " and CustomerID=" & cmbCustomerNameSearch.SelectedValue & "", "VuInvoiceNoForSaleMainSearch")
            cmbInvoiceNoSearch.DataSource = ds.Tables("VuInvoiceNoForSaleMainSearch")
            cmbInvoiceNoSearch.DisplayMember = ("InvoiceNo")
            cmbInvoiceNoSearch.ValueMember = ("SaleID")

        Catch ex As Exception
        End Try
    End Sub
End Class

