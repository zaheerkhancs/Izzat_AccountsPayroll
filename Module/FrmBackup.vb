
Imports System.ServiceProcess
Imports System.IO
Public Class FrmBackup


    Private Sub FrmServiceController_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lblwait.Text = ""
    End Sub


    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        Try


            Dim svc As New ServiceController("MSSQLSERVER", ".")
            Dim s As ServiceControllerStatus = svc.Status
            If s = ServiceControllerStatus.Stopped Then
                svc.Start()
                svc.WaitForStatus(ServiceControllerStatus.Running)
                svc.Refresh()
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        Try


            Dim svc As New ServiceController("MSSQLSERVER", ".")

            Dim s As ServiceControllerStatus = svc.Status
            If s = ServiceControllerStatus.Running Then
                svc.Stop()
                svc.WaitForStatus(ServiceControllerStatus.Stopped)
                svc.Refresh()
            End If


        Catch ex As Exception

        End Try
    End Sub


    Private Sub btnBrowseLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseLocation.Click
        Dim dlg As New FolderBrowserDialog
        If dlg.ShowDialog() Then
            lblLocation.Text = dlg.SelectedPath()

        End If
    End Sub

    Private Sub btnBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackup.Click

        Try
            If lblLocation.Text.Trim().Equals("") Then
                MsgBox("لطفآ برای فولدر جدید یک موقیت را انتخاب کنید" & Chr(13) & "Please select a location or create a new folder")
                btnBrowseLocation_Click(btnBrowseLocation, e)
            Else
                lblwait.Text = "لطفآ انتظار نمایید"
                Cursor = Cursors.WaitCursor
                Timer1.Start()
                btnStop_Click(btnStop, e)
                Threading.Thread.Sleep(5000)
                'Directory.GetFiles(Application.StartupPath, "", SearchOption.AllDirectories)
                File.Copy(Application.StartupPath & "\IALimited_Data.mdf", lblLocation.Text & "\IALimited_Data.mdf")
                File.Copy(Application.StartupPath & "\IALimited_Log.ldf", lblLocation.Text & "\IALimited_Log.ldf")
                ' The following poice of code works, but its too long.
                'Dim fs As New FileStream(lblLocation.Text & "\Note.txt", FileMode.CreateNew, FileAccess.ReadWrite)

                'Dim bduffer() As Byte
                'buffer = System.Text.Encoding.ASCII.GetBytes(txtNote.Text.Trim())
                'fs.Write(buffer, 0, buffer.Length)
                'fs.Flush()
                'fs.Close()
                File.WriteAllText(lblLocation.Text & "\note.txt", txtNote.Text.Trim())
                btnStart_Click(btnStart, e)
                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            MessageBox.Show("Error occured during taking back up, Please try again.", "Error ocurred", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Timer1.Stop()
            lblwait.Text = ""
        End Try




    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.ProgBarBackup.Increment(10)
        If Me.ProgBarBackup.Value = Me.ProgBarBackup.Maximum Then
            Timer1.Stop()
            MessageBox.Show("داتا بیس شما موفقانه کاپی شد", "Successful back up", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Me.Close()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class