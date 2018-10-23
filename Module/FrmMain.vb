Imports System.Windows.Forms
Imports System.Drawing
Imports IZAT_AFGHAN_LIMITED.My.Resources.IALResources
Imports System.Threading
Public Class Frm
    Dim a As Boolean
    Dim b As Boolean
    Dim ACC As Boolean
    Dim STK As Boolean
    Dim HRM As Boolean
    Dim Exch As Boolean
    Public MaximumCurrencyID As Integer
    Dim CurrentCurrencyID As Integer
    Dim ExchangeIsClickedForDatePrompt As Boolean = False
    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Global.System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub


    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer = 0


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If a = True Then
            Me.pnlupanddown.Height = pnlupanddown.Height + 3
            If pnlupanddown.Height = 25 Then
                Timer1.Enabled = False
            End If
        Else

            pnlupanddown.Height = pnlupanddown.Height - 3
            If pnlupanddown.Height = 1 Then
                Timer1.Enabled = False
            End If
            If pnlupanddown.Height = 1 Then

                Me.BackgroundImage = My.Resources.IALResources.IALBackground
                Me.BackgroundImageLayout = ImageLayout.Stretch
            End If
            End If
    End Sub

    Private Sub pctupdown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctupdown.Click
        Timer1.Enabled = True
        If pnlupanddown.Height = 1 Then
            a = True
        Else
            a = False
        End If
       
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        'I made it 180 so that it shouldn't waste time, they don't like movement, they want urgent action.
        If b = True Then
            Me.pnldrag.Width = pnldrag.Width + 180
            If pnldrag.Width = 180 Then
                Timer2.Enabled = False

            End If
        Else

            pnldrag.Width = pnldrag.Width - 180
            If pnldrag.Width = 0 Then
                Timer2.Enabled = False
                MakeMainButtonsVisibleInvisible()
            End If
            'Application.DoEvents()
        End If
    End Sub

   

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If HRM = True Or STK = True Or Exch = True Then
            Exit Sub
        Else
            If pnldrag.Width = 0 Then
                MakeMainButtonsVisibleInvisible()
            End If

            Timer2.Enabled = True
            If pnldrag.Width = 0 Then
                b = True
                ACC = True
            Else
                b = False
                ACC = False
            End If
        End If

        Me.mspsetupform.Visible = False
        Me.msphrm.Visible = False
        Me.PnlExchange.Visible = False
        Me.mspAccount.Visible = True
        ChangeButtonColor(Button1)
    End Sub
    Private Sub ChangeButtonColor(ByVal Btn As Button)
        Try
            'Got to get it from IALResource file:

   
            Button1.Image = My.Resources.IALResources.btn
            btnstock.Image = My.Resources.IALResources.btn
            btnhrm.Image = My.Resources.IALResources.btn
            btnExchange.Image = My.Resources.IALResources.btn


            Btn.Image = My.Resources.IALResources.btnClicked

        Catch ex As Exception

        End Try
    End Sub
    Private Sub ChangeLinksColor(ByVal lnk As ToolStripMenuItem)
        Try
         
            For Each ctrl As Control In Me.Controls
                ' If TypeOf ctrl Is PictureBox Then
                ' For Each ctrl0 As Control In ctrl.Controls
                'MsgBox(ctrl.Controls.Count)
                If TypeOf ctrl Is Panel Then
                    For Each ctrl2 As Control In ctrl.Controls
                        'MsgBox(ctrl.Controls.Count)
                        'For Each aaa As Control In ctrl.Controls
                        '    MsgBox(aaa.Name)
                        'Next
                        If ctrl2.Name = "pnldrag" Then
                            'For Each aaa As Control In ctrl2.Controls
                            '    MsgBox(aaa.Name)
                            'Next
                            For Each cntn As Control In ctrl2.Controls
                                If cntn.Name = "mspsetupform" Then

                                    If TypeOf cntn Is MenuStrip Then

                                        For Each smi As ToolStripMenuItem In mspsetupform.Items
                                            If Not smi.Name = "ToolStripcustomer" Or smi.Name = "ToolStripMenuItem8" Or smi.Name = "ToolStripMenuItem4" Then

                                                smi.Image = My.Resources.IALResources.arrowblue
                                            End If
                                        Next

                                        lnk.Image = My.Resources.IALResources.arrowred
                                    End If

                               

                                   
                                ElseIf cntn.Name = "mspAccount" Then
                                    If TypeOf cntn Is MenuStrip Then

                                        For Each smi As ToolStripMenuItem In mspAccount.Items


                                            smi.Image = My.Resources.IALResources.arrowblue
                                        Next

                                        lnk.Image = My.Resources.IALResources.arrowred
                                    End If
                                ElseIf cntn.Name = "msphrm" Then
                                    If TypeOf cntn Is MenuStrip Then

                                        For Each smi As ToolStripMenuItem In msphrm.Items
                                            'MsgBox(smi.Name)
                                            For Each sm As ToolStripDropDownItem In smi.DropDownItems



                                                sm.Image = My.Resources.IALResources.arrowblue
                                                'MsgBox(sm.Name)
                                            Next
                                        Next

                                        lnk.Image = My.Resources.IALResources.arrowred
                                    End If

                                End If
                            Next
                        End If
                    Next
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub
    Private Sub ChangeLinksColorOnMouseHover(ByVal lnk As ToolStripMenuItem)
        Try
           
            'For Each MS As MenuStrip In Me.Controls
            '    MsgBox(MS.Name)
            'Next
            For Each ctrl As Control In Me.Controls
                ' If TypeOf ctrl Is PictureBox Then
                ' For Each ctrl0 As Control In ctrl.Controls
                'MsgBox(ctrl.Controls.Count)
                If TypeOf ctrl Is Panel Then
                    For Each ctrl2 As Control In ctrl.Controls
                        'MsgBox(ctrl.Controls.Count)
                        'For Each aaa As Control In ctrl.Controls
                        '    MsgBox(aaa.Name)
                        'Next
                        If ctrl2.Name = "pnldrag" Then
                            'For Each aaa As Control In ctrl2.Controls
                            '    MsgBox(aaa.Name)
                            'Next
                            For Each cntn As Control In ctrl2.Controls
                                If cntn.Name = "mspsetupform" Then

                                    If TypeOf cntn Is MenuStrip Then

                                        For Each smi As ToolStripMenuItem In mspsetupform.Items
                                            If Not smi.Name = "ToolStripcustomer" Or smi.Name = "ToolStripMenuItem8" Or smi.Name = "ToolStripMenuItem4" Then

                                                smi.Image = My.Resources.IALResources.arrowblue
                                            End If
                                        Next

                                        lnk.Image = My.Resources.IALResources.arrowred
                                    End If




                                ElseIf cntn.Name = "mspAccount" Then
                                    If TypeOf cntn Is MenuStrip Then

                                        For Each smi As ToolStripMenuItem In mspAccount.Items


                                            smi.Image = My.Resources.IALResources.arrowblue
                                        Next

                                        lnk.Image = My.Resources.IALResources.arrowred
                                    End If
                                ElseIf cntn.Name = "msphrm" Then

                                End If
                            Next
                        End If
                    Next
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End
    End Sub

    Private Sub Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = 0
        Me.Top = 0

        Call Opencn()
        Me.Width = Screen.PrimaryScreen.Bounds.Width
        Me.Height = Screen.PrimaryScreen.Bounds.Height
        Me.BackgroundImage = My.Resources.IALResources.IALBackground
        Me.BackgroundImageLayout = ImageLayout.Stretch
        ' Frm.MdiParent = Me
        'Frm.Show()
        'Frm.TopMost = True
        FrmLogin.Close()
        WName.Text = System.Net.Dns.GetHostEntry("LocalHost").HostName
        pnldrag.Width = 0
        ACC = False
        STK = False
        HRM = False
        dtCurrencyDate.Value = System.DateTime.Now()
        AxShockwaveFlash1.Movie = Application.StartupPath + "\IZAT AFGHAN.swf"
     
        'AxShockwaveFlash1.Width = Screen.PrimaryScreen.Bounds.Width
    End Sub


    Private Sub btnstock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnstock.Click
        If ACC = True Or HRM = True Or Exch = True Then
            Exit Sub
        Else
            If pnldrag.Width = 0 Then
                MakeMainButtonsVisibleInvisible()
            End If
            Timer2.Enabled = True
            If pnldrag.Width = 0 Then
                b = True
                STK = True
            Else
                b = False
                STK = False
            End If
        End If
        'Application.DoEvents()

        Me.mspAccount.Visible = False
        Me.msphrm.Visible = False
        Me.PnlExchange.Visible = False
        Me.mspsetupform.Visible = True
        ChangeButtonColor(btnstock)
    End Sub

    Private Sub btnhrm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhrm.Click
        If ACC = True Or STK = True Or Exch = True Then
            Exit Sub
        Else
            If pnldrag.Width = 0 Then
                MakeMainButtonsVisibleInvisible()
            End If
            Timer2.Enabled = True
            If pnldrag.Width = 0 Then
                b = True
                HRM = True
            Else
                b = False
                HRM = False
            End If
        End If
        'Application.DoEvents()
        Me.mspsetupform.Visible = False
        Me.mspAccount.Visible = False
        Me.PnlExchange.Visible = False
        Me.msphrm.Visible = True
        ChangeButtonColor(btnhrm)
    End Sub


    '----------------

    Sub CloseForms()
        Try

            For Each f As Form In Me.MdiChildren
                f.Close()
                f.Dispose()
            Next
        Catch ex As Exception
            MsgBox("Location : CloseForms in MDIParent" & Chr(10) & ex.Message)
        End Try

    End Sub

    Private Sub ShowForm(ByVal fm As Form)
        Try
            If Me.Contains(fm) Then Exit Sub

            Call CloseForms()

            fm.MdiParent = Me
            fm.Width = 826
            fm.Height = 732

            fm.BackgroundImage = Nothing
            fm.BackColor = Color.Teal
            fm.Show()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ShowFormForReport(ByVal fm As Form)
        Try
            If Me.Contains(fm) Then Exit Sub

            fm.MdiParent = Me
            fm.Width = 826
            fm.Height = 732


            fm.Show()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
    Sub RptShow()
        ShowFormForReport(frmRptSetup)
    End Sub



    'Private Sub ChartOfAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mspAccount.Click
    '    ''For Each ChildForm As Form In Me.MdiChildren

    '    ''    ChildForm.Close()

    '    ''Next
    '    ''FrmChartOfAccount.MdiParent = Me
    '    ''FrmChartOfAccount.Show()
    '    ' ''Me.BringToFront()
    '    ''FrmChartOfAccount.BringToFront()
    '    ShowForm(FrmChartOfAccount)
    '    FrmChartOfAccount.MdiParent = Me
    '    FrmChartOfAccount.BringToFront()

    'End Sub

    'Private Sub AccountCatagoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ''For Each ChildForm As Form In Me.MdiChildren

    '    ''    ChildForm.Close()

    '    ''Next
    '    ' ''FormClose()
    '    ''FrmSubCategory.MdiParent = Me
    '    ''FrmSubCategory.Show()
    '    ''FrmSubCategory.BringToFront()
    '    ShowForm(FrmSubCategory)
    '    FrmSubCategory.MdiParent = Me
    '    FrmSubCategory.BringToFront()
    'End Sub

    'Private Sub UserAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'FormClose()
    '    For Each ChildForm As Form In Me.MdiChildren

    '        ChildForm.Close()

    '    Next

    '    FrmUser.MdiParent = Me
    '    FrmUser.Show()
    '    FrmUser.BringToFront()
    '    ''ShowForm(FrmUser)
    '    ''FrmUser.MdiParent = Me
    '    ''FrmUser.BringToFront()
    'End Sub

    'Private Sub UserGroupsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    For Each ChildForm As Form In Me.MdiChildren

    '        ChildForm.Close()

    '    Next

    '    FrmUser.MdiParent = Me
    '    FrmUser.Show()
    '    FrmUser.BringToFront()
    '    ''ShowForm(FrmUser)
    '    ''FrmUser.MdiParent = Me
    '    ''FrmUser.BringToFront()
    'End Sub

    'Private Sub UserPermissionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    For Each ChildForm As Form In Me.MdiChildren

    '        ChildForm.Close()

    '    Next

    '    FrmUser.MdiParent = Me
    '    FrmUser.Show()
    '    FrmUser.BringToFront()
    '    ''ShowForm(FrmUser)
    '    ''FrmUser.MdiParent = Me
    '    ''FrmUser.BringToFront()
    'End Sub

    'Private Sub ToolMenuSubsidiary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'FormClose()
    '    ''For Each ChildForm As Form In Me.MdiChildren

    '    ''    ChildForm.Close()
    '    ''Next
    '    ''FrmSubSidiary.MdiParent = Me
    '    ''FrmSubSidiary.Show()
    '    ''FrmSubSidiary.BringToFront()
    '    ShowForm(FrmSubSidiary)
    '    FrmSubSidiary.MdiParent = Me
    '    FrmSubSidiary.BringToFront()
    'End Sub

    'Private Sub CompanyInformationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ''For Each ChildForm As Form In Me.MdiChildren

    '    ''    ChildForm.Close()

    '    ''Next

    '    ''FrmCompany.MdiParent = Me
    '    ''FrmCompany.Show()
    '    ''FrmCompany.BringToFront()
    '    ShowForm(FrmCompany)
    '    FrmCompany.MdiParent = Me
    '    FrmCompany.BringToFront()
    'End Sub

    'Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ''For Each ChildForm As Form In Me.MdiChildren

    '    ''    ChildForm.Close()

    '    ''Next
    '    ''FinancialPeriod.MdiParent = Me
    '    ' ''FormClose()
    '    ''FinancialPeriod.Show()
    '    ''FinancialPeriod.BringToFront()
    '    ShowForm(FinancialPeriod)
    '    FinancialPeriod.MdiParent = Me
    '    FinancialPeriod.BringToFront()
    'End Sub

    'Private Sub VoucherTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    For Each ChildForm As Form In Me.MdiChildren
    '        ChildForm.Close()
    '    Next
    '    FrmVoucherType.MdiParent = Me
    '    FrmVoucherType.Show()
    '    FrmVoucherType.BringToFront()
    '    'FrmVoucherType.Top = Me.Height + 20
    '    ''ShowForm(FrmVoucherType)
    '    ''FrmVoucherType.MdiParent = Me
    '    ''FrmVoucherType.BringToFront()
    'End Sub

    'Private Sub VoucherPostingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ''For Each ChildForm As Form In Me.MdiChildren

    '    ''    ChildForm.Close()

    '    ''Next
    '    ''FrmPostingSetup.MdiParent = Me
    '    ''FrmPostingSetup.Show()
    '    ''FrmPostingSetup.BringToFront()
    '    ShowForm(FrmPostingSetup)
    '    FrmPostingSetup.MdiParent = Me
    '    FrmPostingSetup.BringToFront()
    'End Sub

    'Private Sub GToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    For Each ChildForm As Form In Me.MdiChildren

    '        ChildForm.Close()

    '    Next
    '    FrmGLSetup.MdiParent = Me
    '    FrmGLSetup.Show()
    '    FrmGLSetup.BringToFront()
    '    ''ShowForm(FrmGLSetup)
    '    ''FrmGLSetup.MdiParent = Me
    '    ''FrmGLSetup.BringToFront()
    'End Sub

    'Private Sub ProjectSetupsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    For Each ChildForm As Form In Me.MdiChildren

    '        ChildForm.Close()

    '    Next
    '    FrmCompanySetup.MdiParent = Me
    '    FrmCompanySetup.Show()
    '    FrmCompanySetup.BringToFront()
    '    ''ShowForm(FrmCompanySetup)
    '    ''FrmCompanySetup.MdiParent = Me
    '    ''FrmCompanySetup.BringToFront()
    'End Sub

    'Private Sub PeriodClosingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ''For Each ChildForm As Form In Me.MdiChildren

    '    ''    ChildForm.Close()

    '    ''Next
    '    ''FrmClosing.MdiParent = Me
    '    ''FrmClosing.Show()
    '    ''FrmClosing.BringToFront()
    '    ShowForm(FrmClosing)
    '    FrmClosing.MdiParent = Me
    '    FrmClosing.BringToFront()
    'End Sub



    Private Sub ChartOfAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChartOfAccountToolStripMenuItem.Click
        ShowForm(FrmChartOfAccount)
        FrmChartOfAccount.MdiParent = Me
        FrmChartOfAccount.BringToFront()
        ChangeLinksColor(ChartOfAccountToolStripMenuItem)
    End Sub

    Private Sub AccountCatagoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountCatagoryToolStripMenuItem.Click
        ShowForm(FrmSubCategory)
        FrmSubCategory.MdiParent = Me
        FrmSubCategory.BringToFront()
        ChangeLinksColor(AccountCatagoryToolStripMenuItem)
    End Sub

    Private Sub UserAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserAccountToolStripMenuItem.Click
        For Each ChildForm As Form In Me.MdiChildren

            ChildForm.Close()

        Next

        FrmUser.MdiParent = Me
        FrmUser.Show()
        FrmUser.BringToFront()
        ChangeLinksColor(UserAccountToolStripMenuItem)
    End Sub

    Private Sub UserGroupsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserGroupsToolStripMenuItem.Click
        For Each ChildForm As Form In Me.MdiChildren

            ChildForm.Close()

        Next

        FrmUser.MdiParent = Me
        FrmUser.Show()
        FrmUser.BringToFront()
        ChangeLinksColor(UserGroupsToolStripMenuItem)
    End Sub

    Private Sub UserPermissionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserPermissionsToolStripMenuItem.Click
        For Each ChildForm As Form In Me.MdiChildren

            ChildForm.Close()

        Next

        FrmUser.MdiParent = Me
        FrmUser.Show()
        FrmUser.BringToFront()
        ChangeLinksColor(UserPermissionsToolStripMenuItem)
    End Sub

    Private Sub ToolMenuSubsidiary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolMenuSubsidiary.Click
        ShowForm(FrmSubSidiary)
        FrmSubSidiary.MdiParent = Me
        FrmSubSidiary.BringToFront()
        ChangeLinksColor(ToolMenuSubsidiary)
    End Sub

    Private Sub CompanyInformationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompanyInformationToolStripMenuItem.Click
        ShowForm(FrmCompany)
        FrmCompany.MdiParent = Me
        FrmCompany.BringToFront()
        ChangeLinksColor(CompanyInformationToolStripMenuItem)
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        ShowForm(FinancialPeriod)
        FinancialPeriod.MdiParent = Me
        FinancialPeriod.BringToFront()
        ChangeLinksColor(ToolStripMenuItem1)
    End Sub

    Private Sub VoucherTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VoucherTypeToolStripMenuItem.Click
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
        FrmVoucherType.MdiParent = Me
        FrmVoucherType.Show()
        FrmVoucherType.BringToFront()
        ChangeLinksColor(VoucherTypeToolStripMenuItem)
    End Sub

    Private Sub VoucherPostingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VoucherPostingToolStripMenuItem.Click
        ShowForm(FrmPostingSetup)
        FrmPostingSetup.MdiParent = Me
        FrmPostingSetup.BringToFront()
        ChangeLinksColor(VoucherPostingToolStripMenuItem)
    End Sub

    Private Sub GToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GToolStripMenuItem.Click
        For Each ChildForm As Form In Me.MdiChildren

            ChildForm.Close()

        Next
        FrmGLSetup.MdiParent = Me
        FrmGLSetup.Show()
        FrmGLSetup.BringToFront()
        ChangeLinksColor(GToolStripMenuItem)
    End Sub

    Private Sub ProjectSetupsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectSetupsToolStripMenuItem.Click
        For Each ChildForm As Form In Me.MdiChildren

            ChildForm.Close()

        Next
        FrmCompanySetup.MdiParent = Me
        FrmCompanySetup.Show()
        FrmCompanySetup.BringToFront()
        ChangeLinksColor(ProjectSetupsToolStripMenuItem)
    End Sub

    Private Sub PeriodClosingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PeriodClosingToolStripMenuItem.Click
        ShowForm(FrmClosing)
        FrmClosing.MdiParent = Me
        FrmClosing.BringToFront()
        ChangeLinksColor(PeriodClosingToolStripMenuItem)
    End Sub

    Private Sub ImpheadsToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImpheadsToolStripMenuItem.Click
        FrmImpHeads.Show()
        FrmImpHeads.MdiParent = Me
        ChangeLinksColor(ImpheadsToolStripMenuItem)
    End Sub

    Private Sub ExitToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub


    Private Sub ToolStripBiltyInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripBiltyInfo.Click

      
        ShowForm(frmBilty)
        ChangeLinksColor(ToolStripBiltyInfo)
        'frmBilty.MdiParent = Me
        'frmBilty.BringToFront()
    End Sub

    Private Sub ToolStripPurchase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripPurchase.Click
        ShowForm(frmPurchase)
        ChangeLinksColor(ToolStripPurchase)
    End Sub

    Private Sub معلوماتمکملToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles معلوماتمکملToolStripMenuItem.Click
        ShowForm(FrmEmpSetup)
        ChangeLinksColor(معلوماتمکملToolStripMenuItem)
    End Sub

    Private Sub معلوماتمکملکمپنیToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles معلوماتمکملکمپنیToolStripMenuItem.Click
        ShowForm(frmVendorSetup)
        ChangeLinksColor(معلوماتمکملکمپنیToolStripMenuItem)
    End Sub

    Private Sub معلوماتمکملنمائندگیهاToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles معلوماتمکملنمائندگیهاToolStripMenuItem.Click
        ShowForm(frmProvinces)
        ChangeLinksColor(معلوماتمکملنمائندگیهاToolStripMenuItem)
    End Sub

    Private Sub معلوماتمکملگدامهاToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles معلوماتمکملگدامهاToolStripMenuItem.Click
        ShowForm(FrmGoDown)
        ChangeLinksColor(معلوماتمکملگدامهاToolStripMenuItem)
    End Sub

    Private Sub معلوماتمکملدوکاندارهاToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles معلوماتمکملدوکاندارهاToolStripMenuItem.Click
        ShowForm(frmShopSetup)
        ChangeLinksColor(معلوماتمکملدوکاندارهاToolStripMenuItem)
    End Sub

    Private Sub معاشاتماهوارToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles معاشاتماهوارToolStripMenuItem.Click
        ShowForm(frmSalaries)
        ChangeLinksColor(معاشاتماهوارToolStripMenuItem)
    End Sub

    Private Sub پرداختپشکیToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles پرداختپشکیToolStripMenuItem.Click
        ShowForm(frmAdvancePayment)
        ChangeLinksColor(پرداختپشکیToolStripMenuItem)
    End Sub

    Private Sub ToolStripProductType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripProductType.Click
        For Each ChildForm As Form In Me.MdiChildren

            ChildForm.Close()

        Next
        FrmProductType.MdiParent = Me
        FrmProductType.Show()
        FrmProductType.BringToFront()
        ChangeLinksColor(ToolStripProductType)
    End Sub

    Private Sub ToolStripProducts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripProducts.Click
        For Each ChildForm As Form In Me.MdiChildren

            ChildForm.Close()

        Next
        FrmProduct.MdiParent = Me
        FrmProduct.Show()
        FrmProduct.BringToFront()
        ChangeLinksColor(ToolStripProducts)
    End Sub
    Private Sub ToolStripCustomerType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripCustomerType.Click
        For Each ChildForm As Form In Me.MdiChildren

            ChildForm.Close()

        Next
        FrmCustomerType.MdiParent = Me
        FrmCustomerType.Show()
        FrmCustomerType.BringToFront()
        ChangeLinksColor(ToolStripCustomerType)

    End Sub
    Private Sub ToolStripCustomers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripCustomers.Click
        For Each ChildForm As Form In Me.MdiChildren

            ChildForm.Close()

        Next

        FrmCustomer.MdiParent = Me
        FrmCustomer.Show()
        FrmCustomer.Left = Me.Left + 75
        FrmCustomer.Top = Me.Top + 75
        FrmCustomer.BringToFront()
        ChangeLinksColor(ToolStripCustomers)
    End Sub
    Private Sub ToolStripWeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripWeight.Click
        For Each ChildForm As Form In Me.MdiChildren

            ChildForm.Close()

        Next
        FrmWeight.MdiParent = Me
        FrmWeight.Show()
        FrmWeight.BringToFront()
        ChangeLinksColor(ToolStripWeight)
    End Sub
    Private Sub ToolStripCustomerOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripCustomerOrder.Click

        ShowForm(FrmOrderFromCustomer)
        ChangeLinksColor(ToolStripCustomerOrder)
    End Sub

    Private Sub ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem13.Click

        ShowForm(FrmCheque)
        ChangeLinksColor(ToolStripMenuItem13)
    End Sub

    Private Sub ToolStripMenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem14.Click
        ShowForm(FrmSale)
        ChangeLinksColor(ToolStripMenuItem14)
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        ShowForm(FrmReturn)
        ChangeLinksColor(ToolStripMenuItem5)
    End Sub
    Private Sub TSExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSExit.Click
        'Dim Ctr As Control
        For Each Ctr As Control In Me.Controls
            If TypeOf Ctr Is Form Then
                Ctr.Dispose()

            End If
        Next

        If FrmSaleQtyTranfered.P = False Then
            FrmSaleQtyTranfered.P = True
        End If

        If DfrmPurchaseQty.P = False Then
            DfrmPurchaseQty.P = True
        End If

        If FrmSalePaymentDialogueBox.P = False Then
            FrmSalePaymentDialogueBox.P = True
        End If
        For Each form As Form In Me.MdiChildren
            form.Close()
        Next
        Application.Exit()
    End Sub

    Private Sub TSMinimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub مالفاسدشدهToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles مالفاسدشدهToolStripMenuItem.Click
        ShowForm(frmDamages)
        ChangeLinksColor(مالفاسدشدهToolStripMenuItem)
    End Sub
    Private Sub گزارشهایمعاشاتماهوارToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles گزارشهایمعاشاتماهوارToolStripMenuItem.Click
        CloseForms()
        DfrmSalForReport.ShowDialog()
        ChangeLinksColor(گزارشهایمعاشاتماهوارToolStripMenuItem)
    End Sub

    Private Sub گزارشهایپرداختپشکیToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles گزارشهایپرداختپشکیToolStripMenuItem.Click
        CloseForms()
        DfrmAdvancePaymentForReport.ShowDialog()
        ChangeLinksColor(گزارشهایپرداختپشکیToolStripMenuItem)
    End Sub

    Private Sub گزارشهایمعلوماتمکملکارمندهاToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles گزارشهایمعلوماتمکملکارمندهاToolStripMenuItem.Click
        CloseForms()
        DfrmEmpForReport.ShowDialog()
        ChangeLinksColor(گزارشهایمعلوماتمکملکارمندهاToolStripMenuItem)
    End Sub

    Private Sub گزارشهایکمپنیهاToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles گزارشهایکمپنیهاToolStripMenuItem.Click
        CloseForms()
        DfrmVendorForReport.ShowDialog()
        ChangeLinksColor(گزارشهایکمپنیهاToolStripMenuItem)
    End Sub

    Private Sub گزارشهاینمائندگیهادرولایاتToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles گزارشهاینمائندگیهادرولایاتToolStripMenuItem.Click
        CloseForms()
        DfrmProvinceForReport.ShowDialog()
        ChangeLinksColor(گزارشهاینمائندگیهادرولایاتToolStripMenuItem)
    End Sub

    Private Sub گزارشهایگدامهاToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles گزارشهایگدامهاToolStripMenuItem.Click
        CloseForms()
        DfrmGoDownForReport.ShowDialog()
        ChangeLinksColor(گزارشهایگدامهاToolStripMenuItem)
    End Sub

    Private Sub گزارشهایدوکاندارهاToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles گزارشهایدوکاندارهاToolStripMenuItem.Click
        CloseForms()
        DfrmShopKepperForReport.ShowDialog()
        ChangeLinksColor(گزارشهایدوکاندارهاToolStripMenuItem)
    End Sub

    Private Sub ENGLISHToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ENGLISHToolStripMenuItem.Click
        ShowForm(frmOderEnglish)
        ChangeLinksColor(ToolStripOrder)
    End Sub

    Private Sub فارسیToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles فارسیToolStripMenuItem.Click
        ShowForm(FrmOrder)
        ChangeLinksColor(ToolStripOrder)
    End Sub

    Private Sub FlushDatabaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlushDatabaseToolStripMenuItem.Click
        ShowForm(FlushDatabase)
        ChangeLinksColor(ToolStripMenuItem5)
    End Sub

   
    Private Sub StockViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockViewerToolStripMenuItem.Click
        ShowForm(frmStockViewer)
        ChangeLinksColor(StockViewerToolStripMenuItem)
    End Sub
    Private Sub FarsiToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FarsiToolStripMenuItem2.Click
        ShowForm(frmClaim)
        ChangeLinksColor(ToolStripMenuItem7) 'main link for claim
    End Sub

    Private Sub EnglishToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnglishToolStripMenuItem3.Click
        ShowForm(frmClaimEnglish)
        ChangeLinksColor(ToolStripMenuItem7) 'main link for claim
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        ShowForm(FrmSaleOfSaleman)
        ChangeLinksColor(ToolStripMenuItem6)
    End Sub


 
    Private Sub btnExchange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExchange.Click

        If ACC = True Or STK = True Or HRM = True Then
            Exit Sub
        Else
            If pnldrag.Width = 0 Then
                MakeMainButtonsVisibleInvisible()
            End If
            Timer2.Enabled = True
            If pnldrag.Width = 0 Then
                b = True
                Exch = True
            Else
                b = False
                Exch = False
            End If
        End If
        'Application.DoEvents()
        Me.mspsetupform.Visible = False
        Me.mspAccount.Visible = False
        Me.msphrm.Visible = False
        Me.PnlExchange.Visible = True
        ExchangeIsClickedForDatePrompt = True
        Module1.DatasetFill("Select * from CurrencyTable where CurrencyDate ='" & dtCurrencyDate.Value.Date & "'", "CurrencyTable")
        Call FillExchange()
        ChangeButtonColor(btnExchange)

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Call ChangeGBStatus()
        Call btnStatus()
        btnSave.Text = "ثبت"
    End Sub
    Sub ChangeGBStatus()
        GBPool.Enabled = Not GBPool.Enabled
        GBTabadula.Enabled = Not GBTabadula.Enabled
    End Sub
    Sub btnStatus()
        btnAdd.Enabled = Not btnAdd.Enabled
        btnSave.Enabled = Not btnSave.Enabled
        btnEdit.Enabled = Not btnEdit.Enabled
        btnCancel.Enabled = Not btnCancel.Enabled
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        For Each ctrl As Control In PnlExchange.Controls
            If TypeOf ctrl Is GroupBox Then

                'For Each ctrl2 As Control In ctrl.Controls
                '    If TypeOf ctrl2 Is TextBox Then
                '        If ctrl2.Text.Equals("") Then
                '            If ctrl2.Tag.Equals("Numeric") Then
                '                ctrl2.Text = "0.0"

                '            End If

                '        End If
                '    End If
                'Next

            End If
        Next
        If btnSave.Text = "ثبت" Then
            If FirstCheckDuplicateEntryInCurrentDate().Equals(0) Then
                MaximumCurrencyID = Module1.GetMax("ID", "CurrencyTable")
                Module1.InsertRecord("CurrencyTable", "ID,CurrencyDate,SelectedCurrency,Afghani,Dollar,Euro,Pound,kaldar,Remarks", "'" & MaximumCurrencyID & "','" & dtCurrencyDate.Value.Date & "','" & cmbMoney.Text & "','" & txtAfghani.Text & "','" & txtDollar.Text & "','" & txtEuro.Text & "','" & txtPound.Text & "','" & txtKaldar.Text & "','" & txtRemarks.Text.Replace("'", "''").Trim() & "'")
                MessageBox.Show(" موفقانه ثبت گردید")
            Else
                MessageBox.Show("ریکارد برای این تاریخ قبلاّ موجود است" & Chr(13) & "" & Chr(13) & " شما میتوانید در آن تفییر بیاورید", "تخطی از قانون", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
                Exit Sub
            End If

        ElseIf btnSave.Text = "تجدید" Then
            Module1.UpdateRecord("CurrencyTable", "SelectedCurrency = '" & cmbMoney.Text & "', Afghani = " & txtAfghani.Text & ",Dollar=" & txtDollar.Text & ",Euro= " & txtEuro.Text & ",Pound= " & txtPound.Text & ",Kaldar= " & txtKaldar.Text & ",Remarks='" & txtRemarks.Text & "'", "ID =" & CurrentCurrencyID)
            MessageBox.Show(" موفقانه تجدید گردید")
        End If


        Call ChangeGBStatus()
        Call btnStatus()
    End Sub

    Private Sub txtAfghani_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAfghani.KeyPress
        If IsNumeric(sender.text & e.KeyChar) = False Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 8 Then
            e.Handled = False
        End If
    End Sub

    Private Sub txtDollar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDollar.KeyPress
        If IsNumeric(sender.text & e.KeyChar) = False Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 8 Then
            e.Handled = False
        End If
    End Sub

    Private Sub txtEuro_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEuro.KeyPress
        If IsNumeric(sender.text & e.KeyChar) = False Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 8 Then
            e.Handled = False
        End If
    End Sub

    Private Sub txtPound_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPound.KeyPress
        If IsNumeric(sender.text & e.KeyChar) = False Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 8 Then
            e.Handled = False
        End If
    End Sub

    Private Sub txtAmountInOtherCurrency_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmountInOtherCurrency.TextChanged
        CalculateTheMoneyPlease()
    End Sub

    Private Sub cmbCurrencyType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCurrencyType.SelectedIndexChanged
        CalculateTheMoneyPlease()
    End Sub
    Sub CalculateTheMoneyPlease()
        If cmbMoney.SelectedIndex = 0 Then
            CalculateInDollar()
        ElseIf cmbMoney.SelectedIndex = 1 Then
            CalculateInKaldar()
        ElseIf cmbMoney.SelectedIndex = 2 Then
            CalculateInAfghani()
        End If
        GetTillFirstTwoPoints()
    End Sub
    Sub CalculateInDollar()
        If cmbCurrencyType.Text = "افغانی" Then
            txtExchangedAmount.Text = Val(txtAmountInOtherCurrency.Text) / Val(txtAfghani.Text)
        End If
        If cmbCurrencyType.Text = "دالر" Then
            txtExchangedAmount.Text = txtAmountInOtherCurrency.Text
        End If
        If cmbCurrencyType.Text = "یورو" Then
            txtExchangedAmount.Text = Val(txtAmountInOtherCurrency.Text) / Val(txtEuro.Text)
        End If
        If cmbCurrencyType.Text = "پاوند" Then
            txtExchangedAmount.Text = Val(txtAmountInOtherCurrency.Text) / Val(txtPound.Text)
        End If
        If cmbCurrencyType.Text = "کلدار" Then
            txtExchangedAmount.Text = Val(txtAmountInOtherCurrency.Text) / Val(txtKaldar.Text)
        End If

    End Sub
    Sub CalculateInKaldar()
        If cmbCurrencyType.Text = "افغانی" Then
            txtExchangedAmount.Text = (Val(txtAmountInOtherCurrency.Text) * Val(txtAfghani.Text)) / 1000
        End If
        If cmbCurrencyType.Text = "دالر" Then
            txtExchangedAmount.Text = Val(txtAmountInOtherCurrency.Text) * Val(txtDollar.Text)
        End If
        If cmbCurrencyType.Text = "یورو" Then
            txtExchangedAmount.Text = Val(txtAmountInOtherCurrency.Text) * Val(txtEuro.Text)
        End If
        If cmbCurrencyType.Text = "پاوند" Then
            txtExchangedAmount.Text = Val(txtAmountInOtherCurrency.Text) * Val(txtPound.Text)
        End If
        If cmbCurrencyType.Text = "کلدار" Then
            txtExchangedAmount.Text = txtAmountInOtherCurrency.Text
        End If
    End Sub
    Sub CalculateInAfghani()
        If cmbCurrencyType.Text = "افغانی" Then
            txtExchangedAmount.Text = txtAmountInOtherCurrency.Text
        End If
        If cmbCurrencyType.Text = "دالر" Then
            txtExchangedAmount.Text = Val(txtAmountInOtherCurrency.Text) * Val(txtDollar.Text)
        End If
        If cmbCurrencyType.Text = "یورو" Then
            txtExchangedAmount.Text = Val(txtAmountInOtherCurrency.Text) * Val(txtEuro.Text)
        End If
        If cmbCurrencyType.Text = "پاوند" Then
            txtExchangedAmount.Text = Val(txtAmountInOtherCurrency.Text) * Val(txtPound.Text)
        End If
        If cmbCurrencyType.Text = "کلدار" Then
            txtExchangedAmount.Text = (Val(txtAmountInOtherCurrency.Text) * Val(txtKaldar.Text)) / 1000
        End If
    End Sub
    Sub GetTillFirstTwoPoints()
        Try
            Dim TwoPoints() As String = txtExchangedAmount.Text.Split(".")
            txtExchangedAmount.Text = TwoPoints(0) & "." & (TwoPoints(1).Substring(0, 2))
        Catch ex As Exception
        End Try
    End Sub
    Sub FillExchange()
        If ds.Tables("CurrencyTable").Rows.Count.Equals(0) Then
            Call txtclear()
            If ExchangeIsClickedForDatePrompt.Equals(True) Then
                If b = True Then
                    MsgBox("No Record set for this date")
                End If
            End If
        Else
            CurrentCurrencyID = ds.Tables("CurrencyTable").Rows(0).Item("ID")
            dtCurrencyDate.Value = ds.Tables("CurrencyTable").Rows(0).Item("CurrencyDate")
            cmbMoney.Text = ds.Tables("CurrencyTable").Rows(0).Item("SelectedCurrency")
            txtAfghani.Text = ds.Tables("CurrencyTable").Rows(0).Item("Afghani")
            txtDollar.Text = ds.Tables("CurrencyTable").Rows(0).Item("Dollar")
            txtEuro.Text = ds.Tables("CurrencyTable").Rows(0).Item("Euro")
            txtPound.Text = ds.Tables("CurrencyTable").Rows(0).Item("Pound")
            txtKaldar.Text = ds.Tables("CurrencyTable").Rows(0).Item("Kaldar")
            txtRemarks.Text = ds.Tables("CurrencyTable").Rows(0).Item("Remarks")
        End If

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Call ChangeGBStatus()
        Call btnStatus()
        btnSave.Text = "تجدید"
    End Sub
    Private Function FirstCheckDuplicateEntryInCurrentDate()
        Module1.DatasetFill("Select CurrencyDate from VuCurrencyTable where CurrencyDate = '" & dtCurrencyDate.Value.Date & "'", "VuCurrencyTable")
        If ds.Tables("VuCurrencyTable").Rows.Count.Equals(0) Then
            Return 0
        Else
            Return 1
        End If
    End Function

    Private Sub txtAmountInOtherCurrency_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmountInOtherCurrency.KeyPress
        Module1.NumericTextBox(txtAmountInOtherCurrency, e)
    End Sub

    Private Sub dtCurrencyDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtCurrencyDate.ValueChanged
        Module1.DatasetFill("Select * from CurrencyTable where CurrencyDate ='" & dtCurrencyDate.Value.Date & "'", "CurrencyTable")
        Call FillExchange()
        CalculateTheMoneyPlease()
    End Sub
    Sub txtclear()
        For Each ctrl As Control In PnlExchange.Controls
            If TypeOf ctrl Is GroupBox Then
                If ctrl.Name = "GBPool" Then
                    For Each ctrl2 As Control In ctrl.Controls
                        If TypeOf ctrl2 Is TextBox Then
                             ctrl2.Text = "0.0"

                        End If
                    Next
                End If
            End If
        Next
        If txtRemarks.Text = "0.0" Then
            txtRemarks.Text = " "
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Call ChangeGBStatus()
        Call btnStatus()
        Call FillExchange()
    End Sub

    Private Sub مالفاسدشدۀفروشندۀسیارToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles مالفاسدشدۀفروشندۀسیارToolStripMenuItem.Click
        ShowForm(FrmDamagesOfSaleman)
        ChangeLinksColor(مالفاسدشدۀفروشندۀسیارToolStripMenuItem)
    End Sub

    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click
        ShowForm(GodownStock)
        ChangeLinksColor(ToolStripMenuItem9)
    End Sub

  
    Private Sub معلوماتمکملدوکاندارهاToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles معلوماتمکملدوکاندارهاToolStripMenuItem1.Click
        ShowForm(MoneyExchanger)
        ChangeLinksColor(معلوماتمکملدوکاندارهاToolStripMenuItem1)
    End Sub

  
    Private Sub SaraafToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaraafToolStripMenuItem.Click
        ShowForm(Saraaf)
        ChangeLinksColor(SaraafToolStripMenuItem)
    End Sub

    Private Sub AttendenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttendenceToolStripMenuItem.Click
        For Each ChildForm As Form In Me.MdiChildren

            ChildForm.Close()

        Next

        frmAttendenceSheet.MdiParent = Me
        frmAttendenceSheet.Show()
        frmAttendenceSheet.BringToFront()
    End Sub

    Private Sub مقدماتحاضریToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles مقدماتحاضریToolStripMenuItem.Click
        CloseForms()
        DFrmAttendenceSheet.ShowDialog()
    End Sub

    Private Sub لستابرایToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles لستابرایToolStripMenuItem.Click
        ShowForm(FrmObraye)
        ChangeLinksColor(لستابرایToolStripMenuItem)
    End Sub

    Sub MakeMainButtonsVisibleInvisible()
        btnAccMain.Visible = Not btnAccMain.Visible
        btnStockMain.Visible = Not btnStockMain.Visible
        btnHRMMain.Visible = Not btnHRMMain.Visible
        btnExchangeMain.Visible = Not btnExchangeMain.Visible
    End Sub

    Private Sub btnAccMain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccMain.Click
        Button1.PerformClick()
    End Sub

    Private Sub btnStockMain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStockMain.Click
        btnstock.PerformClick()
    End Sub
    Private Sub btnHRMMain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHRMMain.Click
        btnhrm.PerformClick()
    End Sub

    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click
        ShowForm(FrmObrayeOfficeSale)
        ChangeLinksColor(ToolStripMenuItem10)
    End Sub

    Private Sub cmbMoney_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMoney.SelectedIndexChanged
        If cmbMoney.SelectedIndex = 0 Then

            Label10.Text = "معادل یک دالر"
            Label5.Left = 116
            Label5.Text = "افغانی"
            Label12.Text = "معادل آن به دالر"
            Label14.Left = 116
            Label6.Text = " دالر"
            Label14.Text = "کلدار"
            Label7.Text = "یورو"
            Label8.Text = "پوند"
            txtDollar.Text = 1
            txtDollar.Enabled = False
            txtAfghani.Enabled = True
            txtKaldar.Enabled = True
        ElseIf cmbMoney.SelectedIndex = 1 Then

            Label10.Text = "معادل به کلدار"
            Label5.Left = 87
            Label5.Text = "1000" & "افغانی"
            Label12.Text = "معادل آن به کلدار"
            Label6.Text = "1" & "  دالر"
            Label7.Text = "1" & " یورو"
            Label8.Text = "1" & "  پوند"
            Label14.Left = 116
            Label14.Text = "کلدار"
            txtKaldar.Text = 1
            txtKaldar.Enabled = False
            txtAfghani.Enabled = True
            txtDollar.Enabled = True
        ElseIf cmbMoney.SelectedIndex = 2 Then

            Label10.Text = "معادل به اففانی"
            Label12.Text = "معادل آن به اففانی"
            Label5.Left = 116
            Label5.Text = "افغانی"
            Label6.Text = "1" & "  دالر"
            Label7.Text = "1" & " یورو"
            Label8.Text = "1" & "  پوند"
            Label14.Left = 87
            Label14.Text = "1000" & " کلدار"
            txtAfghani.Text = 1
            txtAfghani.Enabled = False
            txtKaldar.Enabled = True
            txtDollar.Enabled = True
        End If
        'If cmbMoney.SelectedIndex = 0 Then

        '    Label10.Text = "معادل یک دالر"
        '    Label5.Left = 116
        '    Label5.Text = "افغانی"
        '    Label12.Text = "معادل آن به دالر"
        '    Label6.Text = "کلدار"
        '    Label7.Text = "یورو"
        '    Label8.Text = "پوند"

        'ElseIf cmbMoney.SelectedIndex = 1 Then

        '    Label10.Text = "معادل به کلدار"
        '    Label5.Left = 87
        '    Label5.Text = "1000" & "افغانی"
        '    Label12.Text = "معادل آن به کلدار"
        '    Label6.Text = "1" & "  دالر"
        '    Label7.Text = "1" & " یورو"
        '    Label8.Text = "1" & "  پوند"
        'ElseIf cmbMoney.SelectedIndex = 2 Then

        '    Label10.Text = "معادل به اففانی"
        '    Label5.Left = 87
        '    Label5.Text = "1000" & " کلدار"
        '    Label12.Text = "معادل آن به اففانی"
        '    Label6.Text = "1" & "  دالر"
        '    Label7.Text = "1" & " یورو"
        '    Label8.Text = "1" & "  پوند"
        'End If

    End Sub

    Private Sub txtKaldar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKaldar.KeyPress
        If IsNumeric(sender.text & e.KeyChar) = False Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 8 Then
            e.Handled = False
        End If
    End Sub

 
    Private Sub lblKeyboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblKeyboard.Click
        PBKeyboard.Visible = Not PBKeyboard.Visible
        PBKeyboard.Image = My.Resources.IALResources.Keyboard
    End Sub

    Private Sub ToolStripProductType_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripProductType.MouseHover
        Try
            'ChangeLinksColorOnMouseHover(ToolStripProductType)
            '    For Each cntrl As Control In Me.MdiChildren
            '        If TypeOf cntrl Is Form Then
            '            ' cntrl.GetType()is  Form 
            '            'Dim Tp As Type
            '            'Tp = cntrl.GetType()
            '            'If TypeOf Tp Is Form Then

            '            'End If
            '            'For Each cn As Control In cntrl.Controls

            '            '    If TypeOf cn Is Form Then


            '            '        For Each frm As Form In Me.Controls
            '            '            If Me.Controls.Count = 0 Then
            '            '                MsgBox("No form is open")
            '            '            Else
            '            '                MsgBox(frm.Name & " is open")
            '            '            End If
            '            '        Next
            '            '    End If
            '            'Next
            '        End If
            '    Next

        Catch ex As Exception

        End Try

        'For Each smi As ToolStripMenuItem In mspAccount.Items



        'Next

    End Sub

    Private Sub btnExchangeMain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExchangeMain.Click
        btnExchange.PerformClick()
    End Sub

    Private Sub BackUpToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackUpToolStripMenuItem11.Click

        Call CloseForms()
        Dim frmbkup As New FrmBackup
        Try
            If Me.Contains(frmbkup) Then Exit Sub
            frmbkup.MdiParent = Me
            frmbkup.Show()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
        ChangeLinksColor(BackUpToolStripMenuItem11)
    End Sub


  
    Private Sub ToolStripReplacement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripReplacement.Click
        ShowForm(FrmIssuedOnReplacement)
        ChangeLinksColor(ToolStripReplacement)
    End Sub
End Class
