Imports System.Data.SqlClient
Imports LanguageSelector
Public Class FrmObrayeOfficeSale
    Dim Var_ObrayeID As Integer
    Dim CityID As Integer
    Dim CityBasedID As String
    Dim i As Integer = 0
    Dim Arr_DGRowsClicked As New ArrayList
    Dim j As Integer = 0 ' For Search Section
    Dim Arr_DGSearchRowsClicked As New ArrayList ' For Seach Section
    Dim Var_Boo_SearchByLocationAllow As Boolean
    Dim AddEdit As Boolean
    Dim EditValue As Integer
    Dim a As Integer
    Dim cnt As Integer
    Dim CallFrom As String
    Dim CurrentRowSelected As Integer

    Dim CashCode As String
    Dim CustomerCode As String

    Dim AccountID As String
  
    Private Sub FrmObrayeOfficeSale_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Module1.Opencn()
        CityID = Frm.lbLocationID.Text
        CityBasedID = Frm.lbLocationName.Text
        Me.MaximizeBox = False
        TB1.Left = pnlcenter.Width / 2 - (TB1.Width / 2)
        TB1.Top = pnlcenter.Height / 2 - (TB1.Height / 2)
        pnlcenter.Left = Me.Width / 2 - (pnlcenter.Width / 2)
        pnlcenter.Top = Me.Height / 2 - (pnlcenter.Height / 2)

        Module1.DatasetFill("Select * from Location", "Location")
        ' Module1.DatasetFill("Select * from Customer where CustomerTypeID = 1", "Customer")
        Module1.DatasetFill("Select * from Shop", "Shop")
        Module1.DatasetFill("Select * from Customer", "Customer")
      
        '
        Module1.DatasetFill("Select * from VuCustomer", "VuCustomer")
        Call ComboFillerOfFahimshekaib(cmbCustomername, "VuCustomer", "CustomerName", "CustomerID")
        Call ComboFillerOfFahimshekaib(cmbLocation, "Location", "LocName", "LocID")
        ' Call ComboFillerOfFahimshekaib(cmbLocationSearch, "Customer", "CustomerName", "CustomerID")
        Call ComboFillerOfFahimshekaib(DGcmbCustomerName, "Customer", "CustomerName", "CustomerID")
        Call ComboFillerOfFahimshekaib(DGcmbCustomerNameSearch, "Customer", "CustomerName", "CustomerID")
        'Please do not remove the datagrid at the bottom of this page along with its related data like DGOBOPCustName combo cause they are all for future incase I find Time I will display the paid obraye amounts of the people.
        Call ComboFillerOfFahimshekaib(DGOBPCustName, "Customer", "CustomerName", "CustomerID")
        Call ComboFillerOfFahimshekaib(DGcmbLocation, "Location", "LocName", "LocID")
        Call ComboFillerOfFahimshekaib(DGSSCustomerName, "Customer", "CustomerName", "CustomerID")
        Call ComboFillerOfFahimshekaib(DGOBPCustName, "Customer", "CustomerName", "CustomerID")

        Call ComboFillerOfFahimshekaib(DGShopNameSearch, "Shop", "ShopName", "ShopID")
        Call ComboFillerOfFahimshekaib(DGSSShopName, "Shop", "ShopName", "ShopID")
        Call ComboFillerOfFahimshekaib(DGSSCustomerName, "Customer", "CustomerName", "CustomerID")
        txtPaid.Text = 0
        txtfill()
        DisableFewControls()
        If Frm.GID.Text > 2 Then
            Module1.CMStatusDisable(CM)
        End If
    End Sub



#Region "ACCOUNT SECTION ENTRY"

    Sub SaveVoucher()

        AccountID = "Obraye" & "-" & Var_ObrayeID

        If cn.State = ConnectionState.Closed Then cn.Open()

        Module1.DatasetFill("Select CashCode,SalesCode,CustoSubCode,DiscountCode from Impheads where CompanyID = " & Frm.LBCompanyID.Text & "", "Impheads")
        CashCode = ds.Tables("Impheads").Rows(0).Item("CashCode")
        CustomerCode = ds.Tables("Impheads").Rows(0).Item("CustoSubCode")

        Try
            'Trans = cn.BeginTransaction
            Dim cmdSave As New SqlCommand
            'cmdSave.Transaction = Trans
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmdSave.Connection = cn
            cmdSave.CommandType = CommandType.StoredProcedure
            cmdSave.CommandText = "InsertUpdateVMain"
            cmdSave.Parameters.Add("@Vno", SqlDbType.NVarChar)
            cmdSave.Parameters("@Vno").Value = AccountID
            cmdSave.Parameters.Add("@Vtype", SqlDbType.NVarChar)
            cmdSave.Parameters("@Vtype").Value = "Obraye Invoice"
            cmdSave.Parameters.Add("@Date", SqlDbType.SmallDateTime)
            cmdSave.Parameters("@Date").Value = Me.dtObrayeDate.Value.Date
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
            cmdSave.Parameters("@VKey").Value = Me.dtObrayeDate.Value.Date.AddDays(3)
            cmdSave.Parameters.Add("@VPost", SqlDbType.Bit)
            cmdSave.Parameters("@VPost").Value = 0

            cmdSave.Parameters.Add("@Flag", SqlDbType.Bit)
            cmdSave.Parameters("@Flag").Value = EditValue

            cmdSave.Parameters.Add("@Received", SqlDbType.NVarChar)
            cmdSave.Parameters("@Received").Value = "Nil"

            cmdSave.Parameters.Add("@paid", SqlDbType.NVarChar)
            cmdSave.Parameters("@paid").Value = "Nil"

            cmdSave.Parameters.Add("@Cheque", SqlDbType.NVarChar)
            cmdSave.Parameters("@Cheque").Value = "Nil" 'dtFrom.Value   Fahim commented it on 14 oct 08 Mustafa maintainance.

            If EditValue = 1 Then
                cmdSave.ExecuteNonQuery()

                GridSaveVoucher()
                'Trans.Commit()
            Else
                cmdSave.ExecuteNonQuery()
                DeleteGridVoucher()
                GridSaveVoucher()
                'Trans.Commit()
            End If

        Catch ex As Exception
            Trans.Rollback()
            MsgBox(ex.Message)

            Exit Sub
        End Try
    End Sub

    Sub DeleteGridVoucher()
        Dim cmdDelete As New SqlCommand

        cmdDelete.Connection = cn
        cmdDelete.Transaction = Trans
        cmdDelete.CommandType = CommandType.StoredProcedure
        cmdDelete.CommandText = "DeleteDetail"
        cmdDelete.Parameters.Add("@Vno", SqlDbType.NVarChar)
        cmdDelete.Parameters("@Vno").Value = AccountID
        cmdDelete.ExecuteNonQuery()

    End Sub

    Sub GridSaveVoucher()

        Dim s As Integer
        For s = 0 To DG.Rows.Count - 1
            Dim cmdSave As New SqlCommand
            cmdSave.Transaction = Trans
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmdSave.Connection = cn
            cmdSave.CommandType = CommandType.StoredProcedure
            cmdSave.CommandText = "SaveDetail"
            cmdSave.Parameters.Add("@Vno", SqlDbType.NVarChar)
            cmdSave.Parameters("@Vno").Value = AccountID
            cmdSave.Parameters.Add("@HeadID", SqlDbType.Char)
            cmdSave.Parameters("@HeadID").Value = CustomerCode
            cmdSave.Parameters.Add("@SubID", SqlDbType.BigInt)
            cmdSave.Parameters("@SubID").Value = DG.Rows(s).Cells("DGCmbCustomerName").Value
            cmdSave.Parameters.Add("@Remarks", SqlDbType.NVarChar)
            cmdSave.Parameters("@Remarks").Value = "From Obraye"
            cmdSave.Parameters.Add("@ChequeNo", SqlDbType.NVarChar)
            cmdSave.Parameters("@ChequeNo").Value = " "     '(IIf(IsNothing(DG.Rows(a).Cells(5).Value) = True, " ", DG.Rows(a).Cells(5).Value))
            cmdSave.Parameters.Add("@ChequeDate", SqlDbType.SmallDateTime)
            cmdSave.Parameters("@ChequeDate").Value = "01/01/1900"       '(IIf(IsDate(DG.Rows(a).Cells(6).Value) = False, "01/01/1900", DG.Rows(a).Cells(6).Value))
            cmdSave.Parameters.Add("@Dr", SqlDbType.Decimal)
            cmdSave.Parameters("@Dr").Value = 0
            cmdSave.Parameters.Add("@Cr", SqlDbType.Decimal)
            cmdSave.Parameters("@Cr").Value = DG.Rows(s).Cells("DGRasid").Value

            cmdSave.ExecuteNonQuery()
            cmdSave.Parameters.Clear()

            '''''''''''''''''''''''''
            Dim cmdSave1 As New SqlCommand
            cmdSave1.Transaction = Trans
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmdSave1.Connection = cn
            cmdSave1.CommandType = CommandType.StoredProcedure
            cmdSave1.CommandText = "SaveDetail"
            cmdSave1.Parameters.Add("@Vno", SqlDbType.NVarChar)
            cmdSave1.Parameters("@Vno").Value = AccountID
            ''@VNo, @HeadID, @SubID, @Remarks, @ChequeNo, @ChequeDate, @Dr, @Cr
            cmdSave1.Parameters.Add("@HeadID", SqlDbType.Char)
            cmdSave1.Parameters("@HeadID").Value = CashCode
            cmdSave1.Parameters.Add("@SubID", SqlDbType.BigInt)
            cmdSave1.Parameters("@SubID").Value = DG.Rows(s).Cells("DGCmbCustomerName").Value
            cmdSave1.Parameters.Add("@Remarks", SqlDbType.NVarChar)
            cmdSave1.Parameters("@Remarks").Value = "From Obraye"
            cmdSave1.Parameters.Add("@ChequeNo", SqlDbType.NVarChar)
            cmdSave1.Parameters("@ChequeNo").Value = " "     '(IIf(IsNothing(DG.Rows(a).Cells(5).Value) = True, " ", DG.Rows(a).Cells(5).Value))
            cmdSave1.Parameters.Add("@ChequeDate", SqlDbType.SmallDateTime)
            cmdSave1.Parameters("@ChequeDate").Value = "01/01/1900"       '(IIf(IsDate(DG.Rows(a).Cells(6).Value) = False, "01/01/1900", DG.Rows(a).Cells(6).Value))
            cmdSave1.Parameters.Add("@Dr", SqlDbType.Decimal)
            cmdSave1.Parameters("@Dr").Value = DG.Rows(s).Cells("DGRasid").Value
            cmdSave1.Parameters.Add("@Cr", SqlDbType.Decimal)
            cmdSave1.Parameters("@Cr").Value = 0

            cmdSave1.ExecuteNonQuery()
            cmdSave1.Parameters.Clear()
        Next
    End Sub

#End Region



    Sub DatagridFill()
        Try
            Module1.DatasetFill("Select Distinct(ShopID),Sum(Balance) as Balance,CounterForObraye from SaleMain where LocID= " & cmbLocation.SelectedValue & " and Balance>0 Group By ShopID,CounterForObraye", "SaleMain")
            Dim i As Integer = 0
            DG.Rows.Clear()
            For Each datarow As DataRow In ds.Tables("SaleMainOfSaleMan").Rows
                DG.Rows.Add()
                DG.Rows(i).Cells("DGShopName").Value = datarow("ShopID")
                For Each datarowOfShop As DataRow In ds.Tables("Shop").Rows
                    If datarowOfShop.Item("ShopID") = datarow("ShopID") Then
                        DG.Rows(i).Cells("DGShopkeeperName").Value = datarowOfShop("ConcernPName")
                        DG.Rows(i).Cells("DGAddress").Value = datarowOfShop("Address")
                    End If
                Next
                DG.Rows(i).Cells("DGRemainingBalance").Value = datarow("Balance")
                DG.Rows(i).Cells("DGCounterForObraye").Value = datarow("CounterForObraye")
                i = i + 1
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DG_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim a As Integer
        Try

            If Not Arr_DGRowsClicked.Count = 0 Then
                For a = 0 To Arr_DGRowsClicked.Count - 1
                    If a = DG.CurrentRow.Index Then

                        If Not DG.CurrentRow.DefaultCellStyle.BackColor = Color.Orange Then
                        Else
                            Exit Sub
                        End If
                    End If

                Next
            End If
        Catch ex As Exception

        End Try
        Try
            Dim s As Integer = DG.Rows.Count
            Arr_DGRowsClicked.Add(DG.CurrentRow.Index)
            DG.CurrentRow.DefaultCellStyle.BackColor = Color.Orange

            Module1.DatasetFill("Select InvoiceNo,ShopID,Balance,CounterForObraye from  VuSaleMainForObrayeDetail where ShopID =" & DG.CurrentRow.Cells("DGShopName").Value & " And Balance>0", "VuSaleMainForObrayeDetail")
            'Dim i As Integer = 0
            'DGSub.Rows.Clear()
            For Each datarow As DataRow In ds.Tables("VuSaleMainForObrayeDetail").Rows
                DG.Rows.Add()
                DG.Rows(i).Cells("DGSubcmbShopName").Value = datarow("ShopID")
                For Each datarowOfShop As DataRow In ds.Tables("Shop").Rows
                    If datarowOfShop.Item("ShopID") = datarow("ShopID") Then
                        DG.Rows(i).Cells("DGSubShopKeeper").Value = datarowOfShop("ConcernPName")
                        DG.Rows(i).Cells("DGSubAddress").Value = datarowOfShop("Address")
                    End If
                Next
                DG.Rows(i).Cells("DGSubInvNo").Value = datarow("InvoiceNo")
                DG.Rows(i).Cells("DGSubReaminingBalance").Value = datarow("Balance")
                Try
                    DG.Rows(i).Cells("DGSubBalance").Value = Val(DG.Rows(i).Cells("DGSubReaminingBalance").Value) - Val(DG.Rows(i).Cells("DGSubRasid").Value)
                Catch ex As Exception

                End Try
                i = i + 1

            Next
        Catch ex As Exception

        End Try
    End Sub


    Private Sub RBSearchCustomerName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSearchCustomerName.CheckedChanged
        If RBSearchCustomerName.Checked.Equals(True) Then
            ClearSearchGridAndTextBoxes()
            Module1.DatasetFill("Select * from VuCustomerForRBCustObraye where CustomerTypeID = 1", "VuCustomerForRBCustObraye")
            cmbLocationSearch.DataSource = Nothing
            cmbLocationSearch.DataSource = ds.Tables("VuCustomerForRBCustObraye")
            cmbLocationSearch.DisplayMember = "CustomerName"
            cmbLocationSearch.ValueMember = "CustomerID"
            ' MsgBox(cmbLocationSearch.Items.Count)
            lblForChkbox.Text = "فروشندۀ مشخص"
            'chkFixedLocation.Left = 565
        Else
            cmbLocationSearch.DataSource = Nothing
        End If
    End Sub

    Private Sub RBSearchLocation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSearchLocation.CheckedChanged
        If RBSearchLocation.Checked.Equals(True) Then
            ClearSearchGridAndTextBoxes()

            Module1.DatasetFill("Select * from Location", "Location")
            Call ComboFillerOfFahimshekaib(DGSSShopName, "Location", "LocName", "LocID")
            cmbLocationSearch.DataSource = ds.Tables("Location")
            cmbLocationSearch.DisplayMember = "LocName"
            cmbLocationSearch.ValueMember = "LocID"
            lblForChkbox.Text = "ساحِۀ مشخص"
            'chkFixedLocation.Left = 565
        Else
            cmbLocationSearch.DataSource = Nothing
        End If
    End Sub
    Sub ClearSearchGridAndTextBoxes()
        DGSearch.Rows.Clear()
        DGSearchSub.Rows.Clear()
        txtBalanceSearch.Text = 0
    End Sub
    Private Sub chkFixedLocation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFixedLocation.CheckedChanged
        ClearSearchGridAndTextBoxes()
        If chkFixedLocation.Checked.Equals(True) Then
            cmbLocationSearch.Enabled = True
        Else
            cmbLocationSearch.Enabled = False
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim k As Integer
        DGSearch.Rows.Clear()
        DGSearchSub.Rows.Clear()
        DGObPaid.Rows.Clear()
        txtBalanceSearch.Text = 0
        txtBalanceSearchInv.Text = 0
        txtBalanceSearchObPaid.Text = 0
        'Is has been frozen by Fahim because I don't want them to pick upi between two dates.They may be confused,Dates of search and Main Obraye form near grid are all invisibled and has been removed from the code.
        'If RBSearchLocation.Checked.Equals(True) Then
        '    If chkFixedLocation.Checked.Equals(True) Then
        '        Module1.DatasetFill("Select Distinct(CustomerID),ShopID, Sum(Balance) as Balance,CounterForObraye from VuSaleMainForObrayeMain  where LocID = " & cmbLocationSearch.SelectedValue & " and SaleDate between '" & dtFromSearch.Value.Date.ToString & "' and '" & dtToSearch.Value.Date.ToString & "' and Balance>0 Group By CustomerID,ShopID,CounterForObraye", "VuSaleMainForObrayeMain")
        '    Else
        '        Module1.DatasetFill("Select Distinct(CustomerID),ShopID, Sum(Balance) as Balance,CounterForObraye from VuSaleMainForObrayeMain where SaleDate between '" & dtFromSearch.Value.Date.ToString & "' and '" & dtToSearch.Value.Date.ToString & "' and Balance>0 Group By CustomerID,ShopID,CounterForObraye", "VuSaleMainForObrayeMain")
        '    End If
        'Else
        '    If chkFixedLocation.Checked.Equals(True) Then
        '        Module1.DatasetFill("Select Distinct(CustomerID),ShopID, Sum(Balance) as Balance,CounterForObraye from VuSaleMainForObrayeMain where CustomerID = " & cmbLocationSearch.SelectedValue & " and SaleDate between '" & dtFromSearch.Value.Date.ToString & "' and '" & dtToSearch.Value.Date.ToString & "' and Balance>0 Group By CustomerID,ShopID,CounterForObraye", "VuSaleMainForObrayeMain")
        '    Else
        '        Module1.DatasetFill("Select Distinct(CustomerID),ShopID, Sum(Balance) as Balance,CounterForObraye from VuSaleMainForObrayeMain where SaleDate between '" & dtFromSearch.Value.Date.ToString & "' and '" & dtToSearch.Value.Date.ToString & "' and Balance>0 Group By CustomerID,ShopID,CounterForObraye", "VuSaleMainForObrayeMain")
        '    End If
        'End If
        If RBSearchLocation.Checked.Equals(True) Then
            If chkFixedLocation.Checked.Equals(True) Then
                Module1.DatasetFill("Select Distinct(CustomerID),ShopID, Sum(Balance) as Balance,CounterForObraye from VuSaleMainForObrayeMain  where LocID = " & cmbLocationSearch.SelectedValue & " and Balance>0 Group By CustomerID,ShopID,CounterForObraye", "VuSaleMainForObrayeMain")
            Else
                Module1.DatasetFill("Select Distinct(CustomerID),ShopID, Sum(Balance) as Balance,CounterForObraye from VuSaleMainForObrayeMain where LocID <> 0 and Balance>0 Group By CustomerID,ShopID,CounterForObraye", "VuSaleMainForObrayeMain")
            End If
        Else
            If chkFixedLocation.Checked.Equals(True) Then
                Module1.DatasetFill("Select Distinct(CustomerID),ShopID, Sum(Balance) as Balance,CounterForObraye from VuSaleMainForObrayeMain where CustomerID = " & cmbLocationSearch.SelectedValue & " and Balance>0 Group By CustomerID,ShopID,CounterForObraye", "VuSaleMainForObrayeMain")
            Else
                Module1.DatasetFill("Select Distinct(CustomerID),ShopID, Sum(Balance) as Balance,CounterForObraye from VuSaleMainForObrayeMain where Balance>0 Group By CustomerID,ShopID,CounterForObraye", "VuSaleMainForObrayeMain")
            End If
        End If
        For Each drow As DataRow In ds.Tables("VuSaleMainForObrayeMain").Rows
            DGSearch.Rows.Add()
            DGSearch.Rows(k).Cells("DGSearchSNo").Value = k + 1
            DGSearch.Rows(k).Cells("DGcmbCustomerNameSearch").Value = drow("CustomerID")
            ' MsgBox(drow("CustomerID"))

            DGSearch.Rows(k).Cells("DGShopNameSearch").Value = drow("ShopID")
            For Each datarowOfShop As DataRow In ds.Tables("Shop").Rows
                If datarowOfShop.Item("ShopID") = drow("ShopID") Then
                    DGSearch.Rows(k).Cells("DGShopKeeperNameSearch").Value = datarowOfShop("ConcernPName")
                    DGSearch.Rows(k).Cells("DGAddressSearch").Value = datarowOfShop("Address")
                End If
            Next

            'Lets now get the remaining balance by subtracting baqaya of salemain from paid of obrayedetail.
            'As well as subtracting it from the amount paid 
            Dim TotalBalanaceremainingFromSaleMain As Decimal = Convert.ToDecimal(drow("Balance"))
            Module1.DatasetFill("Select Sum(Paid) as 'TotalPaid' from VuObrayeDetailForSearch where CustomerID = " & DGSearch.Rows(k).Cells("DGcmbCustomerNameSearch").Value, "VuObrayeDetailForSearch")
            'First let's subtract the amounts paid pack to the customer on his sale returns from the TotalBalanaceremainingFromSaleMain.
            Module1.DatasetFill("Select Sum(TotalPaid) as 'TotalPaidBackToCustomer' from VuSaleMainForObrayeDetail where CustomerID = " & DGSearch.Rows(k).Cells("DGcmbCustomerNameSearch").Value, "VuSaleMainForObrayeDetail")
            Dim TotalAmountOnHisSaleReturns As Decimal = IIf(ds.Tables("VuSaleMainForObrayeDetail").Rows(0).Item("TotalPaidBackToCustomer").Equals(DBNull.Value) = True, 0, ds.Tables("VuSaleMainForObrayeDetail").Rows(0).Item("TotalPaidBackToCustomer"))
            Dim SubtractedAmount As Decimal = TotalBalanaceremainingFromSaleMain - TotalAmountOnHisSaleReturns

            Dim PaidAmountInObraye As Decimal = IIf(ds.Tables("VuObrayeDetailForSearch").Rows(0).Item("TotalPaid").Equals(DBNull.Value) = True, 0, ds.Tables("VuObrayeDetailForSearch").Rows(0).Item("TotalPaid"))

            DGSearch.Rows(k).Cells("DGBaqayaSearch").Value = SubtractedAmount - PaidAmountInObraye
            DGSearch.Rows(k).Cells("DGBalanceSearch").Value = DGSearch.Rows(k).Cells("DGBaqayaSearch").Value
            'Rasid is not displayed , because whatever displayed here will be printed and taken to customers , and the amount received from them
            'will be manually written under that rasid column, then the page will be given to the operator to insert it in Obraye new record. It is not displayed in report too.
            'DGSearch.Rows(k).Cells("DGRasidSearch").Value = ds.Tables("VuObrayeDetailForSearch").Rows(0).Item("TotalPaid")
            'DGSearch.Rows(k).Cells("DGBaqayaSearch").Value = drow("Balance")
            'Try ' Now no need for that.
            '    DGSearch.Rows(k).Cells("DGBalanceSearch").Value = Val(DGSearch.Rows(k).Cells("DGBaqayaSearch").Value) - Val(DGSearch.Rows(k).Cells("DGRasidSearch").Value)

            'Catch ex As Exception

            'End Try
            Module1.DatasetFill("Select Max(CounterForObraye) as 'LastCounteryForObraye' from VuObrayeDetailForSearch where CustomerID = " & DGSearch.Rows(k).Cells("DGcmbCustomerNameSearch").Value & " And ObrayeDate =(Select Max(ObrayeDate) from VuObrayeDetailForSearch where CustomerID = " & DGSearch.Rows(k).Cells("DGcmbCustomerNameSearch").Value & ")", "VuObrayeDetailForSearch")

            DGSearch.Rows(k).Cells("DGCounterForObrayeSearch").Value = ds.Tables("VuObrayeDetailForSearch").Rows(0).Item("LastCounteryForObraye")
            'DGSearch.Rows(j).Cells("DGPaidSearch").Value = drow(5)
            'DGSearch.Rows(j).Cells("DGBalanceSearch").Value = drow(6)
            k = k + 1
        Next
        CalculationOfObrayeSearch()
    End Sub

    Private Sub DGSearch_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGSearch.CellDoubleClick
        ' This piece of code is added after the following commented lines are written.
        For Each dgrow As DataGridViewRow In DGSearch.Rows
            dgrow.DefaultCellStyle.BackColor = Color.White
        Next
        DGSearch.CurrentRow.DefaultCellStyle.BackColor = Color.Orange

        ' Get the data from SaleMain of those records which relates to this customer with balance>0
        'Before this I was using this grid to keep doubleclicking and getting the detail of one after another Person's record in grid.but now I added the following like DGSearchSub.rows.clear() 
        ' so that I get one one persons detail at a time, nothing has been changed in previous code, one you can comment the DGSearchSub.rows.clear() line and it will work like before.Also You should remove the DGOBPaid.rows.clear()
        'And Yes,    j = DGSearchSub.Rows.Count should be uncommented while j = 0 should be commented.
        ' For the time being I also commented the color check portion and would like to make the background of only doubleclicked row orange. 

        DGSearchSub.Rows.Clear()
        DGObPaid.Rows.Clear()
        DGSubInv_Balance()
        'Get data from Obraye of those records which relates to this customer.
        DGSubObrPaid_Detail()

    End Sub
    Sub DGSubInv_Balance()
       
        Dim a As Integer
        'j = DGSearchSub.Rows.Count
        j = 0
        Try
            'Read the details in DGSearch_CellDoubleClick.
            'If Not Arr_DGSearchRowsClicked.Count = 0 Then
            '    For a = 0 To Arr_DGSearchRowsClicked.Count - 1
            '        If a = DGSearch.CurrentRow.Index Then
            '            If Not DGSearch.CurrentRow.DefaultCellStyle.BackColor = Color.Orange Then
            '            Else
            '                Exit Sub
            '            End If

            '        End If

            '    Next
            'End If
          
        Catch ex As Exception

        End Try
        Try
            ' Dim s As Integer = DGSub.Rows.Count
            Arr_DGSearchRowsClicked.Add(DGSearch.CurrentRow.Index)
            DGSearch.CurrentRow.DefaultCellStyle.BackColor = Color.Orange
            'in the following query, the balance is of sale and totalpaid is of sale returned , okie dokie :-)
            Module1.DatasetFill("Select InvoiceNo,CustomerID,ShopID,Balance,TotalPaid,CounterForObraye from  VuSaleMainForObrayeDetail where CustomerID =" & DGSearch.CurrentRow.Cells("DGcmbCustomerNameSearch").Value & " And Balance>0", "VuSaleMainForObrayeDetail")
            'Dim i As Integer = 0
            'DGSub.Rows.Clear()
            For Each datarow As DataRow In ds.Tables("VuSaleMainForObrayeDetail").Rows
                DGSearchSub.Rows.Add()
                DGSearchSub.Rows(j).Cells("DGSSSNo").Value = DGSearchSub.Rows(j).Index + 1
                DGSearchSub.Rows(j).Cells("DGSSCustomerName").Value = datarow("CustomerID")
                DGSearchSub.Rows(j).Cells("DGSSShopName").Value = datarow("ShopID")
                '  MsgBox("sdf")
                ' MsgBox(DGSearchSub.Rows(i).Cells("DGSSShopName").FormattedValue())

                For Each datarowOfShop As DataRow In ds.Tables("Shop").Rows
                    If datarowOfShop.Item("ShopID") = datarow("ShopID") Then
                        DGSearchSub.Rows(j).Cells("DGSSShopkeeperName").Value = datarowOfShop("ConcernPName")
                        DGSearchSub.Rows(j).Cells("DGSSAddress").Value = datarowOfShop("Address")

                    End If
                Next
                DGSearchSub.Rows(j).Cells("DGSSInvoiceNo").Value = datarow("InvoiceNo")
                DGSearchSub.Rows(j).Cells("DGSSTotalAmount").Value = datarow("Balance") ' meqdare poole ke balaye moshtari manda.az Table Sale balancesh beland mesha.
                If datarow.IsNull("TotalPaid") = True Then
                    DGSearchSub.Rows(j).Cells("DGSSReturned").Value = 0
                Else
                    DGSearchSub.Rows(j).Cells("DGSSReturned").Value = datarow("TotalPaid")
                End If
                Try
                    DGSearchSub.Rows(j).Cells("DGSSBalance").Value = Val(DGSearchSub.Rows(j).Cells("DGSSTotalAmount").Value) - Val(DGSearchSub.Rows(j).Cells("DGSSReturned").Value)
                Catch ex As Exception

                End Try


                'Try
                '    DGSearchSub.Rows(j).Cells("DGSSBalance").Value = datarow("Balance")

                'Catch ex As Exception

                'End Try
                j = j + 1

            Next
          

        Catch ex As Exception

        End Try
    End Sub
    Sub DGSubObrPaid_Detail()
        Module1.DatasetFill("Select * from VuObrPaid_Detail_ForDGSub where CustomerID =" & DGSearch.CurrentRow.Cells("DGcmbCustomerNameSearch").Value, "VuObrPaid_Detail_ForDGSub")
        'Dim i As Integer = 0
        'DGSub.Rows.Clear()
        Dim j As Integer = 0
        For Each datarow As DataRow In ds.Tables("VuObrPaid_Detail_ForDGSub").Rows
            DGObPaid.Rows.Add()

            'DGSearchSub.Rows(j).Cells("DGSSCustomerName").Value = datarow("CustomerID")
            'DGSearchSub.Rows(j).Cells("DGSSShopName").Value = datarow("ShopID")
            ''  MsgBox("sdf")
            '' MsgBox(DGSearchSub.Rows(i).Cells("DGSSShopName").FormattedValue())

            'For Each datarowOfShop As DataRow In ds.Tables("Shop").Rows
            '    If datarowOfShop.Item("ShopID") = datarow("ShopID") Then
            '        DGSearchSub.Rows(j).Cells("DGSSShopkeeperName").Value = datarowOfShop("ConcernPName")
            '        DGSearchSub.Rows(j).Cells("DGSSAddress").Value = datarowOfShop("Address")

            '    End If
            'Next
            DGObPaid.Rows(j).Cells("DGObPSNo").Value = DGObPaid.Rows(j).Index + 1
            DGObPaid.Rows(j).Cells("DGOBPCustName").Value = datarow("CustomerName")
            DGObPaid.Rows(j).Cells("DGObPDescription").Value = datarow("Remarks")
            DGObPaid.Rows(j).Cells("DGObPDate").Value = datarow("ObrayeDate")
            DGObPaid.Rows(j).Cells("DGObPShopName").Value = datarow("ShopName")
            DGObPaid.Rows(j).Cells("DGObPObResp").Value = datarow("ObrayeResponsible")
            DGObPaid.Rows(j).Cells("DGObPPaid").Value = datarow("Paid")
            'Try
            '    DGSearchSub.Rows(j).Cells("DGSSBalance").Value = datarow("Balance")

            'Catch ex As Exception

            'End Try
            j = j + 1

        Next
    End Sub
    Private Sub DGSearch_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DGSearch.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGSearchSub_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DGSearchSub.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub
    'Search section finished here

    Private Sub cmbLocation_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbLocation.KeyPress
        If Asc(e.KeyChar) = 13 Then
            DatagridFill()
        End If
    End Sub

    Private Sub DG_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGSub_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DG.DataError, DG.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDisplayShops_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplayCustomerss.Click
        'DatagridFill()
        txtShopName.Text = ""
        txtShopkeeperName.Text = ""
        txtAddress.Text = ""
        If chkSpecificLocation.Checked.Equals(True) Then
            btnDisplayShopsCase_GeneralWithShops()
        Else
            If RBGeneralCustomers.Checked = True Then
                btnDisplayShopsCase_GeneralWithoutShops()
            ElseIf RBMobileSalesmen.Checked = True Then
                btnDisplayShopsCaseMobileSalesmen()
            End If

        End If
    End Sub
    Sub btnDisplayShopsCase_GeneralWithShops()
        Module1.DatasetFill("Select * from VuCustomer where CustomerTypeID>=2 And LocID=" & cmbLocation.SelectedValue, "VuCustomer")
        Call ComboFillerOfFahimshekaib(cmbCustomername, "VuCustomer", "CustomerName", "CustomerID")
        If ds.Tables("VuCustomer").Rows.Count = 0 Then
            cmbCustomername.Text = ""
        End If
        ' although i don't need it I just made a practice copy of this table.
        Dim VirtualTable As DataTable
        VirtualTable = ds.Tables("VuCustomer").Copy()
        If ds.Tables.Contains("VirtualTable") Then
            ds.Tables.Remove("VirtualTable")
        End If
        VirtualTable.TableName = "VirtualTable"
        ds.Tables.Add("VirtualTable")
    End Sub
    Sub btnDisplayShopsCase_GeneralWithoutShops()
        Module1.DatasetFill("Select * from VuCustomer where CustomerTypeID>=2 And LocID=0", "VuCustomer")
        Call ComboFillerOfFahimshekaib(cmbCustomername, "VuCustomer", "CustomerName", "CustomerID")
        If ds.Tables("VuCustomer").Rows.Count = 0 Then
            cmbCustomername.Text = ""
        End If
        ' although i don't need it I just made a practice copy of this table.
        Dim VirtualTable1 As DataTable
        VirtualTable1 = ds.Tables("VuCustomer").Copy()
        If ds.Tables.Contains("VirtualTable1") Then
            ds.Tables.Remove("VirtualTable1")
        End If
        VirtualTable1.TableName = "VirtualTable1"
        ds.Tables.Add("VirtualTable1")
    End Sub
    Sub btnDisplayShopsCaseMobileSalesmen()
        Module1.DatasetFill("Select * from VuCustomer where CustomerTypeID=1", "VuCustomer")
        Call ComboFillerOfFahimshekaib(cmbCustomername, "VuCustomer", "CustomerName", "CustomerID")
        If ds.Tables("VuCustomer").Rows.Count = 0 Then
            cmbCustomername.Text = ""
        End If
        ' although i don't need it I just made a practice copy of this table.
        Dim VirtualTable2 As DataTable
        VirtualTable2 = ds.Tables("VuCustomer").Copy()
        If ds.Tables.Contains("VirtualTable2") Then
            ds.Tables.Remove("VirtualTable2")
        End If
        VirtualTable2.TableName = "VirtualTable2"
        ds.Tables.Add("VirtualTable2")
    End Sub
    Private Sub cmbCustomername_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomername.SelectedIndexChanged
        If Var_Boo_SearchByLocationAllow.Equals(True) Then
            Try

                For Each datarow As DataRow In ds.Tables("Customer").Rows
                    If datarow("CustomerID") = cmbCustomername.SelectedValue Then
                        If Not datarow("ShopID") = 0 Then
                            For Each dtr As DataRow In ds.Tables("Shop").Rows
                                If dtr("ShopID") = datarow("ShopID") Then
                                    txtShopName.Text = dtr("ShopName")
                                    txtShopkeeperName.Text = dtr("ConcernPName")
                                    txtAddress.Text = dtr("Address")
                                End If
                            Next
                            'didn't work...by Arif bhai
                            'Dim drfound() As DataRow = ds.Tables("Shop").Select(datarow("ShopID"))
                            'If drfound.Length > 0 Then
                            '    txtShopName.Text = drfound(0).Item("ShopName")
                            '    txtShopkeeperName.Text = drfound(0).Item("ConcernPName")
                            '    txtAddress.Text = drfound(0).Item("Address")
                            'End If
                        Else
                            For Each dtr As DataRow In ds.Tables("Shop").Rows
                                If dtr("ShopID") = datarow("ShopID") Then
                                    txtShopName.Text = ""
                                    txtShopkeeperName.Text = ""
                                    txtAddress.Text = dtr("Address")
                                End If
                            Next
                        End If

                    End If
                Next

            Catch ex As Exception

            End Try
        Else
            Try

                For Each datarow As DataRow In ds.Tables("Customer").Rows
                    If datarow("CustomerID") = cmbCustomername.SelectedValue Then
                        If Not datarow("ShopID") = 0 Then
                            For Each dtr As DataRow In ds.Tables("Shop").Rows
                                If dtr("ShopID") = datarow("ShopID") Then
                                    txtShopName.Text = dtr("ShopName")
                                    txtShopkeeperName.Text = dtr("ConcernPName")
                                    txtAddress.Text = dtr("Address")
                                End If
                            Next
                        Else
                            For Each dtrr As DataRow In ds.Tables("Customer").Rows


                            Next
                            'didn't work...by Arif bhai
                            'Dim drfound() As DataRow = ds.Tables("Shop").Select(datarow("ShopID"))
                            'If drfound.Length > 0 Then
                            '    txtShopName.Text = drfound(0).Item("ShopName")
                            '    txtShopkeeperName.Text = drfound(0).Item("ConcernPName")
                            '    txtAddress.Text = drfound(0).Item("Address")
                            'End If
                        End If

                    End If
                Next
            Catch ex As Exception

            End Try
        End If
        Try
            Module1.DatasetFill("Select Sum(Balance) as 'Balance' From SaleMain where CustomerID = " & cmbCustomername.SelectedValue, "SaleMain")
            Dim BalanceFromSaleMain As Decimal = ds.Tables("SaleMain").Rows(0).Item("Balance")
            Dim BalancePaidInObraye As Decimal = 0
            Try
                Module1.DatasetFill("Select Sum(Paid) as 'Paid' From ObrayeDetail where CustomerID = " & cmbCustomername.SelectedValue, "ObrayeDetail")
                BalancePaidInObraye = ds.Tables("ObrayeDetail").Rows(0).Item("Paid")

            Catch ex As Exception
                BalancePaidInObraye = 0
            End Try

            Try

                txtRemaining.Text = BalanceFromSaleMain - BalancePaidInObraye
                'Try
                '    txtCounterForObraye.Text = ds.Tables("ObrayeDetail").Rows(0).Item("CounterForObraye")

                'Catch ex As Exception
                '    txtCounterForObraye.Text = 0
                'End Try
             
            Catch ex As Exception
                txtRemaining.Text = 0
                txtCounterForObraye.Text = 0
            End Try
        Catch ex As Exception
            txtRemaining.Text = 0
            txtCounterForObraye.Text = 0
        End Try
        txtPaid.Text = 0
    End Sub


#Region "Context Menu Buttons"
    Private Sub MnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuNew.Click
        AddEdit = True
        EditValue = 1
        Var_Boo_SearchByLocationAllow = True
        CStatus(Me, pnlcenter, TB1, TP1)
        cmbLocation.Enabled = False
        EnableFewControls()
        CMStatus(CM)
        txtclear(Me, pnlcenter, TB1, TP1)
        DG.Rows.Clear()
        CallFrom = "Saving"
        ToolStrip1.Enabled = False
        dtObrayeDate.Value = DateTime.Now
    End Sub

    Private Sub MnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSave.Click
        Try

      
            If DG.Rows.Count = 0 Then Exit Sub
            If EditValue = 1 Then
                Call IDPicker()
            End If

            Dim cmdsave As New SqlCommand


            cmdsave.CommandType = CommandType.StoredProcedure
            cmdsave.CommandText = "InsertUpdateObrayeMain"
            cmdsave.Connection = cn
            cmdsave.Parameters.Add("@ObrayeID", SqlDbType.Int).Value = Me.Var_ObrayeID
            cmdsave.Parameters.Add("@ObrayeDate", SqlDbType.SmallDateTime).Value = Me.dtObrayeDate.Value.Date
            cmdsave.Parameters.Add("@ObrayeResponsible ", SqlDbType.NVarChar).Value = Me.txtObrayeResponsible.Text
            cmdsave.Parameters.Add("@OfficeResponsible", SqlDbType.NVarChar).Value = Me.txtOfficeResposible.Text
            cmdsave.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = Me.txtTotalAmount.Text
            Dim Remarks As String = Me.txtRemarks.Text
            If Remarks.Equals("") Then
                cmdsave.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = " "
            Else
                cmdsave.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = Me.txtRemarks.Text
            End If

            cmdsave.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID
            cmdsave.Parameters.Add("@CityBasedID", SqlDbType.NVarChar).Value = CityBasedID & "-" & Me.Var_ObrayeID


            cmdsave.Parameters.Add("@Flag", SqlDbType.Bit).Value = EditValue
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmdsave.ExecuteNonQuery()

            cmdsave.Parameters.Clear()

            If EditValue = 1 Then
                'I just made it comment because it was passing "save" instead of datagrid wala or whatever we need.
                'K2(sender, e) 
                Call GridSave()
                Call SaveVoucher()
                'Trans.Commit()
                lblMessage.Text = "ریکارد شما موفقانه ثبت گردید"
                ' MsgBox("Your Record has been saved successfully..")
                txtfill()
                CallFrom = ""
            Else
                Call DeleteGrid()
                Call GridSave()
                Call SaveVoucher()
                'Trans.Commit()
                lblMessage.Text = "ریکارد شما موفقانه تجدید گردید"

                'MsgBox("Your Record has been updated successfully..")
            End If
            AddEdit = False
            Call CStatus(Me, pnlcenter, TB1, TP1)
            cmbLocation.Enabled = False
            CMStatus(CM)
            DG.ReadOnly = True

            ToolStrip1.Enabled = True
            DisableFewControls()
        Catch ex As Exception
            
        End Try
    End Sub

    Private Sub MnuUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuUndo.Click
        AddEdit = False
        EditValue = 0
        Call CMStatus(CM)
        Call CStatus(Me, pnlcenter, TB1, TP1)
        cmbLocation.Enabled = False
        DisableFewControls()
        Module1.DatasetFill("Select * from OrderEnglishMain", "OrderEnglishMain")
        Call txtfill()
        ToolStrip1.Enabled = True
    End Sub

    Private Sub MnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuEdit.Click
        AddEdit = True
        CMStatus(CM)
        CStatus(Me, pnlcenter, TB1, TP1)
        cmbLocation.Enabled = False
        EnableFewControls()
        EditValue = 0
        ToolStrip1.Enabled = False
        ComboFillerOfFahimshekaib(cmbCustomername, "Customer", "CustomerName", "CustomerID")
    End Sub

    Private Sub MnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDelete.Click
        Dim a As VariantType
        AccountID = "Obraye" & "-" & Var_ObrayeID
        a = MsgBox("Are you Sure.?" & Chr(13) & "  " & Chr(13) & " آیا شما مطمئن هستید  ", MsgBoxStyle.YesNo)
        If a = vbYes Then
            cmd.CommandText = " Delete from ObrayeMain where ObrayeID = " & Var_ObrayeID
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

            cmd.CommandText = " Delete from ObrayeDetail where ObrayeID=" & Var_ObrayeID
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

            cmd.CommandText = " Delete from VoucherMain where Vno='" & AccountID & "'"
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

            'cmd.CommandText = " Delete from GoDownIGL where ObrayeID=" & Var_ObrayeID & "  And Type='Received'"
            'cmd.Connection = cn
            'cmd.ExecuteNonQuery()

            'MsgBox("THE RECORD HAS BEEN DELETED SUCCESSFULLY" & Chr(13) & "  " & Chr(13) & " ریکارد مذکور موفقانه فسخ شد ", MsgBoxStyle.Information)
            If cnt = ds.Tables("ObrayeMain").Rows.Count - 1 Then
                cnt = cnt - 1
            End If
            If cnt < 0 Then
                txtclear(Me, pnlcenter, TB1, TP1)
                DG.Rows.Clear()
            End If
            Call txtfill()
            lblMessage.Text = "ریکارد مذکور موفقانه حذف گردید "
        End If
    End Sub

    Private Sub MnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuExit.Click
        Me.Close()
    End Sub
#End Region
#Region "Navigation Section"
    Private Sub TSFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSFirst.Click
        cnt = 0
        txtfill()
        DisableFewControls()
        'CStatus(Me, pnlcenter, TB1, TP1)
        'CMStatus(CM)
    End Sub

    Private Sub TSPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSPrevious.Click
        If cnt = 0 Then
            txtfill()

        Else
            cnt = cnt - 1
            txtfill()
        End If
        DisableFewControls()
    End Sub

    Private Sub TSNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSNext.Click
        If cnt = ds.Tables("ObrayeMain").Rows.Count - 1 Then
            MsgBox("شما در ریکارد اخیر قرار دارید")
        Else
            cnt = cnt + 1
            txtfill()
        End If
        DisableFewControls()
    End Sub

    Private Sub TSLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSLast.Click
        cnt = ds.Tables("ObrayeMain").Rows.Count - 1
        txtfill()
        DisableFewControls()
    End Sub
#End Region
    Private Sub TB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB1.SelectedIndexChanged
        If TB1.SelectedIndex = 1 Then
            Me.CM.Enabled = False
        Else
            Me.CM.Enabled = True
        End If
    End Sub
    Sub IDPicker()
        Try

            Dim sqldreader As SqlDataReader
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select Max(ObrayeID) from ObrayeMain"
            cmd.Connection = cn
            If cn.State = ConnectionState.Closed Then cn.Open()
            sqldreader = cmd.ExecuteReader()
            While sqldreader.Read

                If IsDBNull(sqldreader.Item(0)) = True Then
                    Me.Var_ObrayeID = 1
                Else
                    Me.Var_ObrayeID = Val(sqldreader.Item(0)) + 1

                End If
            End While
            sqldreader.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub GridSave()
        Dim cmdsaveGrid As New SqlCommand
        cmdsaveGrid.CommandType = CommandType.StoredProcedure
        cmdsaveGrid.CommandText = "InsertUpdateObrayeDetail"
        cmdsaveGrid.Connection = cn
        Try
            For a = 0 To DG.Rows.Count - 1
                'Trans = cn.BeginTransaction("Fahim")
                cmdsaveGrid.Parameters.Add("@ObrayeID", SqlDbType.Int).Value = Var_ObrayeID
                cmdsaveGrid.Parameters.Add("@Sno", SqlDbType.Int).Value = DG.Rows(a).Cells("DGSNo").Value
                'Dim PTypeID As Integer
                'Try
                '    For Each dtrow As DataRow In ds.Tables("ProductType").Rows
                '        If dtrow("ProdTypeName") = DG.Rows(a).Cells("DGcmbPType").Value Then
                '            PTypeID = dtrow("ProdTypeID")
                '            cmdsaveGrid.Parameters.Add("@ProdTypeID", SqlDbType.Int).Value = PTypeID 'DG.Rows(a).Cells("DGcmbPType").Value

                '        End If
                '    Next
                '        Catch ex As Exception
                '    cmdsaveGrid.Parameters.Add("@ProdTypeID", SqlDbType.Int).Value = DG.Rows(a).Cells("DGcmbPType").Value
                'End Try

                cmdsaveGrid.Parameters.Add("@CustomerID", SqlDbType.Int).Value = DG.Rows(a).Cells("DGcmbCustomerName").Value
                cmdsaveGrid.Parameters.Add("@ShopName", SqlDbType.NVarChar).Value = DG.Rows(a).Cells("DGShopName").Value
                cmdsaveGrid.Parameters.Add("@ConcernPName", SqlDbType.NVarChar).Value = DG.Rows(a).Cells("DGShopKeeper").Value
                cmdsaveGrid.Parameters.Add("@Address", SqlDbType.NVarChar).Value = DG.Rows(a).Cells("DGAddress").Value
                cmdsaveGrid.Parameters.Add("@LocationID", SqlDbType.Int).Value = DG.Rows(a).Cells("DGcmbLocation").Value
                cmdsaveGrid.Parameters.Add("@ToPay", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGReaminingBalance").Value
                cmdsaveGrid.Parameters.Add("@Paid", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGRasid").Value
                cmdsaveGrid.Parameters.Add("@Balance", SqlDbType.Decimal).Value = DG.Rows(a).Cells("DGBalance").Value

                Dim CountForObraye As Integer = DG.Rows(a).Cells("DGCounterForObraye").Value
                If IsNothing(CountForObraye) Then
                    cmdsaveGrid.Parameters.Add("@CounterForObraye", SqlDbType.Int).Value = " "
                Else
                    cmdsaveGrid.Parameters.Add("@CounterForObraye", SqlDbType.Int).Value = DG.Rows(a).Cells("DGCounterForObraye").Value

                End If
                'Trans.Commit()
                cmdsaveGrid.ExecuteNonQuery()
                cmdsaveGrid.Parameters.Clear()
            Next

        Catch ex As Exception
         
        End Try


    End Sub
    Sub DeleteGrid()

        Dim cmdsave As New SqlCommand
        cmdsave.CommandType = CommandType.StoredProcedure
        cmdsave.CommandText = "DeleteObrayeDetail"
        cmdsave.Connection = cn
        cmdsave.Parameters.Add("@ObrayeID", SqlDbType.Int).Value = Var_ObrayeID
        cmdsave.ExecuteNonQuery()

    End Sub
    Sub txtfill()
        Try
            lblMessage.Text = ""
            If cnt < 0 Then
                cnt = 0
            End If

            Module1.DatasetFill("Select * from ObrayeMain Order by ObrayeID", "ObrayeMain")

            If ds.Tables("ObrayeMain").Rows.Count = 0 Then
                Call txtclear(Me, pnlcenter, TB1, TP1)
                Exit Sub
            Else

                If CallFrom = "Saving" Then
                    cnt = ds.Tables("ObrayeMain").Rows.Count - 1
                End If
                Me.Var_ObrayeID = Val(ds.Tables("ObrayeMain").Rows(cnt).Item("ObrayeID"))

                dtObrayeDate.Value = ds.Tables("ObrayeMain").Rows(cnt).Item("ObrayeDate")
                txtObrayeResponsible.Text = ds.Tables("ObrayeMain").Rows(cnt).Item("ObrayeResponsible")
                txtOfficeResposible.Text = ds.Tables("ObrayeMain").Rows(cnt).Item("OfficeResponsible")
                txtTotalAmount.Text = ds.Tables("ObrayeMain").Rows(cnt).Item("TotalAmount")
                txtRemarks.Text = ds.Tables("ObrayeMain").Rows(cnt).Item("Remarks")
                Call Gridtxtfill()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Gridtxtfill()
        Try

            Module1.DatasetFill("Select * from ObrayeDetail where ObrayeID= " & Var_ObrayeID, "ObrayeDetail")

            DG.Rows.Clear()
            For a = 0 To ds.Tables("ObrayeDetail").Rows.Count - 1
                Try
                    DG.Rows.Add()
                    DG.Rows(a).Cells("DGSNo").Value = ds.Tables("ObrayeDetail").Rows(a).Item("SNo")
                    DG.Rows(a).Cells("DGcmbCustomerName").Value = ds.Tables("ObrayeDetail").Rows(a).Item("CustomerID")
                    DG.Rows(a).Cells("DGShopName").Value = ds.Tables("ObrayeDetail").Rows(a).Item("ShopName")
                    DG.Rows(a).Cells("DGShopKeeper").Value = ds.Tables("ObrayeDetail").Rows(a).Item("ConcernPName")
                    DG.Rows(a).Cells("DGAddress").Value = ds.Tables("ObrayeDetail").Rows(a).Item("Address")
                    DG.Rows(a).Cells("DGcmbLocation").Value = ds.Tables("ObrayeDetail").Rows(a).Item("LocationID")
                    DG.Rows(a).Cells("DGReaminingBalance").Value = ds.Tables("ObrayeDetail").Rows(a).Item("ToPay")
                    DG.Rows(a).Cells("DGRasid").Value = ds.Tables("ObrayeDetail").Rows(a).Item("Paid")
                    DG.Rows(a).Cells("DGBalance").Value = ds.Tables("ObrayeDetail").Rows(a).Item("Balance")
                    DG.Rows(a).Cells("DGCounterForObraye").Value = ds.Tables("ObrayeDetail").Rows(a).Item("CounterForObraye")
                Catch ex As Exception
                End Try
            Next

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnEnterToDG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnterToDG.Click
        If EditValue = 1 Then
            If cmbCustomername.Text = "" Then Exit Sub
            DG.Rows.Add()
            DG.Rows(DG.Rows.Count - 1).Cells("DGSNo").Value = DG.Rows(DG.Rows.Count - 1).Index + 1
            DG.Rows(DG.Rows.Count - 1).Cells("DGcmbCustomerName").Value = cmbCustomername.SelectedValue
            DG.Rows(DG.Rows.Count - 1).Cells("DGShopName").Value = txtShopName.Text
            DG.Rows(DG.Rows.Count - 1).Cells("DGShopKeeper").Value = txtShopkeeperName.Text
            DG.Rows(DG.Rows.Count - 1).Cells("DGAddress").Value = txtAddress.Text
            DG.Rows(DG.Rows.Count - 1).Cells("DGcmbLocation").Value = cmbLocation.SelectedValue
            DG.Rows(DG.Rows.Count - 1).Cells("DGReaminingBalance").Value = txtRemaining.Text
            DG.Rows(DG.Rows.Count - 1).Cells("DGRasid").Value = txtPaid.Text
            DG.Rows(DG.Rows.Count - 1).Cells("DGBalance").Value = txtBalance.Text
            DG.Rows(DG.Rows.Count - 1).Cells("DGCounterForObraye").Value = txtCounterForObraye.Text
        Else
            DG.Rows(CurrentRowSelected).Cells("DGSNo").Value = DG.Rows(CurrentRowSelected).Index + 1
            DG.Rows(CurrentRowSelected).Cells("DGcmbCustomerName").Value = cmbCustomername.SelectedValue
            DG.Rows(CurrentRowSelected).Cells("DGShopName").Value = txtShopName.Text
            DG.Rows(CurrentRowSelected).Cells("DGShopKeeper").Value = txtShopkeeperName.Text
            DG.Rows(CurrentRowSelected).Cells("DGAddress").Value = txtAddress.Text
            DG.Rows(CurrentRowSelected).Cells("DGcmbLocation").Value = cmbLocation.SelectedValue
            DG.Rows(CurrentRowSelected).Cells("DGReaminingBalance").Value = txtRemaining.Text
            DG.Rows(CurrentRowSelected).Cells("DGRasid").Value = txtPaid.Text
            DG.Rows(CurrentRowSelected).Cells("DGBalance").Value = txtBalance.Text
            DG.Rows(CurrentRowSelected).Cells("DGCounterForObraye").Value = txtCounterForObraye.Text

        End If
    End Sub
    'Sub CStuatus()
    '    Dim C As Control
    '    For Each C In Me.Controls
    '        If TypeOf C Is Panel Then
    '            Dim D As Control
    '            For Each D In C.Controls
    '                If TypeOf D Is TabControl Then
    '                    Dim E As Control
    '                    For Each E In D.Controls
    '                        If TypeOf E Is TabPage Then
    '                            If E.Name = "TP1" Then
    '                                MsgBox("hi")
    '                            End If
    '                        End If
    '                    Next
    '                End If
    '            Next
    '        End If
    '    Next
    'End Sub

 
    Private Sub chkSpecificLocation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSpecificLocation.CheckedChanged
        If chkSpecificLocation.Checked.Equals(True) Then
            cmbLocation.Enabled = True
            Var_Boo_SearchByLocationAllow = True
            RBGeneralCustomers.Checked = True
            RBMobileSalesmen.Enabled = False
        Else
            Var_Boo_SearchByLocationAllow = False
            cmbLocation.Enabled = False
            RBMobileSalesmen.Enabled = True
        End If
    End Sub
#Region "Fahimshekaib Special ComboFiller"
    Sub ComboFillerOfFahimshekaib(ByVal ComboName As ComboBox, ByVal NameOfTable As String, ByVal DisplayMember As String, ByVal ValueMember As String)
        ComboName.DataSource = Nothing
        ComboName.DataSource = ds.Tables(NameOfTable)
        ComboName.DisplayMember = DisplayMember
        ComboName.ValueMember = ValueMember
        'MsgBox(ComboName.Items.Count)
    End Sub
    Sub ComboFillerOfFahimshekaib(ByVal ComboName As DataGridViewComboBoxColumn, ByVal NameOfTable As String, ByVal DisplayMember As String, ByVal ValueMember As String)
        ComboName.DataSource = Nothing
        ComboName.DataSource = ds.Tables(NameOfTable)
        ComboName.DisplayMember = DisplayMember
        ComboName.ValueMember = ValueMember
    End Sub
#End Region

    Private Sub txtRemaining_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemaining.TextChanged
        If txtRemaining.Text = "" Then
            txtRemaining.Text = 0
        End If
        CalculateBalance()
    End Sub

    Private Sub txtPaid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPaid.TextChanged
        If txtPaid.Text = "" Then
            txtPaid.Text = 0
            txtPaid.SelectionStart = 0
            txtPaid.Select(0, 1)
        End If
        CalculateBalance()
    End Sub
    Sub CalculateBalance()
        txtBalance.Text = Val(txtRemaining.Text) - Val(txtPaid.Text)
        If Val(txtBalance.Text) < 0 Then
            txtPaid.Text = txtRemaining.Text
            txtPaid.Select(txtPaid.Text, txtPaid.Text)
        End If
    End Sub

    Private Sub txtPaid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPaid.KeyPress
      
        If IsNumeric(Me.ActiveControl.Text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Then e.Handled = True

    End Sub

    Private Sub DG_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellValueChanged
        Calculation()
    End Sub
    Sub Calculation()
        If AddEdit = True Then
            Try
                Dim CalculateAmount As Double = 0
                Dim Increamenter As Integer = 0
                For Each dgcol As DataGridViewColumn In DG.Columns
                    If dgcol.Name = "DGRasid" Then


                        'If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGRasid" Then
                        For Each dgrow As DataGridViewRow In DG.Rows
                            CalculateAmount = CalculateAmount + Val(Convert.ToDecimal(DG.Rows(Increamenter).Cells("DGRasid").Value))
                            Increamenter = Increamenter + 1
                        Next
                    End If
                    'End If
                Next
                txtTotalAmount.Text = CalculateAmount
            Catch ex As Exception

            End Try
        End If
    End Sub
    Sub CalculationOfObrayeSearch()
        'If EditValue = 1 Then
        Try
          
            Dim CalculateBalance As Double = 0

            Dim Increamenter As Integer = 0
            For Each dgcol As DataGridViewColumn In DGSearch.Columns
                If dgcol.Name = "DGBaqayaSearch" Then


                    'If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGRasid" Then
                    For Each dgrow As DataGridViewRow In DGSearch.Rows
                        'CalculateRemaining = CalculateRemaining + Val(Convert.ToDecimal(DGSearch.Rows(Increamenter).Cells("DGBaqayaSearch").Value))
                        'CalculateRasid = CalculateRasid + Val(Convert.ToDecimal(DGSearch.Rows(Increamenter).Cells("DGRasidSearch").Value))
                        CalculateBalance = CalculateBalance + Val(Convert.ToDecimal(DGSearch.Rows(Increamenter).Cells("DGBalanceSearch").Value))

                        Increamenter = Increamenter + 1
                    Next
                    'End If
                End If
            Next
         
            txtBalanceSearch.Text = CalculateBalance

        Catch ex As Exception

        End Try
        'End If
    End Sub
    Sub CalculationOfObrayeSearchIn()
        'If EditValue = 1 Then
        Try
            Dim CalculateRemaining As Double = 0


            Dim Increamenter As Integer = 0
            For Each dgcol As DataGridViewColumn In DGSearchSub.Columns
                If dgcol.Name = "DGSSTotalAmount" Then


                    'If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGRasid" Then
                    For Each dgrow As DataGridViewRow In DGSearchSub.Rows
                        CalculateRemaining = CalculateRemaining + Convert.ToDecimal(DGSearchSub.Rows(Increamenter).Cells("DGSSBalance").Value)

                        Increamenter = Increamenter + 1
                    Next
                    'End If
                End If
            Next
            txtBalanceSearchInv.Text = CalculateRemaining
        

        Catch ex As Exception

        End Try
        'End If
    End Sub
    Sub CalculationOfObrayeSearchObrayePaid()
        'If EditValue = 1 Then
        Try
            Dim CalculateRemaining As Double = 0


            Dim Increamenter As Integer = 0
            For Each dgcol As DataGridViewColumn In DGObPaid.Columns
                If dgcol.Name = "DGObPPaid" Then


                    'If DG.Columns(DG.CurrentCell.ColumnIndex).Name = "DGRasid" Then
                    For Each dgrow As DataGridViewRow In DGObPaid.Rows
                        CalculateRemaining = CalculateRemaining + Convert.ToDecimal(DGObPaid.Rows(Increamenter).Cells("DGObPPaid").Value)

                        Increamenter = Increamenter + 1
                    Next
                    'End If
                End If
            Next
            txtBalanceSearchObPaid.Text = CalculateRemaining


        Catch ex As Exception

        End Try
        'End If
    End Sub
    Sub DisableFewControls()
        btnDisplayCustomerss.Enabled = False
        chkSpecificLocation.Enabled = False
        btnEnterToDG.Enabled = False
        RBGeneralCustomers.Enabled = False
        RBMobileSalesmen.Enabled = False
    End Sub
    Sub EnableFewControls()
        btnDisplayCustomerss.Enabled = True
        chkSpecificLocation.Enabled = True
        btnEnterToDG.Enabled = True
        RBGeneralCustomers.Enabled = True
        RBMobileSalesmen.Enabled = True
    End Sub
    Private Sub DG_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DG.RowsRemoved
        Calculation()
    End Sub

    Private Sub txtCounterForObraye_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCounterForObraye.KeyPress
        If IsNumeric(Me.ActiveControl.Text & e.KeyChar) = False And Asc(e.KeyChar) <> 8 Or Asc(e.KeyChar) = 46 Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then
            btnEnterToDG.PerformClick()
        End If
    End Sub


    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            Module1.DeleteRecord("ObrayeReportForOffice")
            SaveIntoObrayeReportForOffice_Table()
            Call PrintReport()
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

      
    End Sub
    Sub SaveIntoObrayeReportForOffice_Table()

        Dim x As Integer = 0
        Dim cmdsaveGrid As New SqlCommand
        cmdsaveGrid.CommandType = CommandType.StoredProcedure
        cmdsaveGrid.CommandText = "InsertUpdateObrayeReportForOffice"
        cmdsaveGrid.Connection = cn
        Try
            For Each dgro As DataGridViewRow In DGSearch.Rows
                cmdsaveGrid.Parameters.Add("@SNo", SqlDbType.Int).Value = DGSearch.Rows(x).Cells("DGSearchSNo").Value
                cmdsaveGrid.Parameters.Add("@CustomerName", SqlDbType.NVarChar).Value = DGSearch.Rows(x).Cells("DGcmbCustomerNameSearch").FormattedValue
                Try
                    'Checking if data is available for this field for not.
                    Dim ShopNameSearch As String = DGSearch.Rows(x).Cells("DGShopNameSearch").Value
                    If ShopNameSearch = Nothing Then
                        cmdsaveGrid.Parameters.Add("@ShopName", SqlDbType.NVarChar).Value = ""

                    Else
                        cmdsaveGrid.Parameters.Add("@ShopName", SqlDbType.NVarChar).Value = DGSearch.Rows(x).Cells("DGShopNameSearch").FormattedValue

                    End If

                Catch ex As Exception

                End Try
                Try
                    'Checking if data is available for this field for not.
                    Dim ShopKeeperNameSearch As String = DGSearch.Rows(x).Cells("DGShopKeeperNameSearch").FormattedValue
                    If ShopKeeperNameSearch = Nothing Then
                        cmdsaveGrid.Parameters.Add("@ShopKeeperName", SqlDbType.NVarChar).Value = ""
                    Else
                        cmdsaveGrid.Parameters.Add("@ShopKeeperName", SqlDbType.NVarChar).Value = DGSearch.Rows(x).Cells("DGShopKeeperNameSearch").Value
                    End If

                Catch ex As Exception

                End Try
                Try
                    'Checking if data is available for this field for not.
                    Dim AddressSearch As String = DGSearch.Rows(x).Cells("DGAddressSearch").FormattedValue
                    If AddressSearch = Nothing Then
                        cmdsaveGrid.Parameters.Add("@Address", SqlDbType.NVarChar).Value = ""
                    Else
                        cmdsaveGrid.Parameters.Add("@Address", SqlDbType.NVarChar).Value = DGSearch.Rows(x).Cells("DGAddressSearch").Value
                    End If
                    cmdsaveGrid.Parameters.Add("@Remaining", SqlDbType.Decimal).Value = DGSearch.Rows(x).Cells("DGBaqayaSearch").Value

                    cmdsaveGrid.Parameters.Add("@Paid", SqlDbType.VarChar).Value = "" 'DGSearch.Rows(x).Cells("DGRasidSearch").Value
                    cmdsaveGrid.Parameters.Add("@Balance", SqlDbType.Decimal).Value = DGSearch.Rows(x).Cells("DGBalanceSearch").Value
                    cmdsaveGrid.Parameters.Add("@CounterForObraye", SqlDbType.Int).Value = DGSearch.Rows(x).Cells("DGCounterForObrayeSearch").Value
                Catch ex As Exception

                End Try

                'Trans.Commit()
                cmdsaveGrid.ExecuteNonQuery()
                cmdsaveGrid.Parameters.Clear()
                x += 1
                '
            Next

        Catch ex As Exception
        End Try
    End Sub
    Sub PrintReport()
        Module1.DatasetFill("Select * from ObrayeReportForSale", "ObrayeReportForSale")

        'Module1.DatasetFill("Select * from RptVuProduct where ProdCode=" & txtID.Text, "RptVuProduct")
        Dim rpt As New RptObrayeOffice
        rpt.SetDataSource(Module1.ds.Tables("ObrayeReportForSale"))
        frmRptSetup.CV.ReportSource = rpt
        Frm.RptShow()
    End Sub
    'Leave the following code,It will be used if we assign datasource to a datagrid and then save it at once to a table.
    'Dim sCopy As New SqlBulkCopy(cn)
    '    sCopy.DestinationTableName = "ObrayeReportForOffice"
    '' AddHandler sCopy.SqlRowsCopied, AddressOf OnSQLRowCopied

    'Dim dtSource As DataTable = Me.DGSearch.DataSource
    ''Dim obj_SqlRowsCopiedEventHandler As New SqlRowsCopiedEventHandler
    '    sCopy.WriteToServer(dtSource)
    ''For Each datarow As DataRow In DGSearch.Rows
    ''Next


    'Private Sub OnSQLRowCopied(ByVal sender As Object, ByVal e As SqlRowsCopiedEventArgs)

    '    'LabelCounting.Text = "Copied Data So Far :- " & e.RowsCopied
    '    'LabelCounting.Refresh()

    '    'ProgressBarSQL.Value = e.RowsCopied

    'End Sub

    Private Sub DG_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellClick
        cmbCustomername.SelectedValue = DG.CurrentRow.Cells("DGcmbCustomerName").Value
        txtShopName.Text = DG.CurrentRow.Cells("DGShopName").Value
        txtShopkeeperName.Text = DG.CurrentRow.Cells("DGShopKeeper").Value
        txtAddress.Text = DG.CurrentRow.Cells("DGAddress").Value
        txtRemaining.Text = DG.CurrentRow.Cells("DGReaminingBalance").Value
        txtPaid.Text = DG.CurrentRow.Cells("DGRasid").Value
        txtBalance.Text = DG.CurrentRow.Cells("DGBalance").Value
        txtCounterForObraye.Text = DG.CurrentRow.Cells("DGCounterForObraye").Value
        CurrentRowSelected = DG.CurrentRow.Index
    End Sub

    Private Sub DGSearchSub_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGSearchSub.CellValueChanged
        CalculationOfObrayeSearchIn()
    End Sub

    Private Sub DGSearchSub_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGSearchSub.RowsRemoved
        CalculationOfObrayeSearchIn()
    End Sub

    Private Sub TP1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TP1.Enter
        chkSpecificLocation.Checked = False
        cmbLocation.Enabled = False
    End Sub

    Private Sub TP2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TP2.Enter
        chkFixedLocation.Checked = False
        cmbLocationSearch.Enabled = False
    End Sub

    Private Sub DGObPaid_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DGObPaid.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGObPaid_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGObPaid.CellValueChanged
        CalculationOfObrayeSearchObrayePaid()
    End Sub

    Private Sub txtObrayeResponsible_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObrayeResponsible.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub txtOfficeResposible_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOfficeResposible.KeyPress
        If Not KeyboardLayout.getName() = "00000429" Then
            e.Handled = True
            KeyboardLayout.Farsi()
        End If
    End Sub

    Private Sub txtBalance_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBalance.TextChanged
        Try
            If Val(txtBalance.Text) < 0 Then
                txtPaid.Text = 0
            End If

            If txtBalance.Text = 0 Then
                txtCounterForObraye.Text = 0
            Else
                Module1.DatasetFill("Select Max(CounterForObraye) as 'LastCounteryForObraye' from VuObrayeDetailForSearch where CustomerID = " & cmbCustomername.SelectedValue & " And ObrayeDate =(Select Max(ObrayeDate) from VuObrayeDetailForSearch where CustomerID = " & cmbCustomername.SelectedValue & ")", "VuObrayeDetailForSearch")
                If IsDBNull(ds.Tables("VuObrayeDetailForSearch").Rows(0).Item("LastCounteryForObraye")) Then
                    txtCounterForObraye.Text = 0
                Else
                    Dim LastObrayeTurn As Integer = ds.Tables("VuObrayeDetailForSearch").Rows(0).Item("LastCounteryForObraye")
                    txtCounterForObraye.Text = LastObrayeTurn + 1
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub


End Class