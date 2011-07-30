Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Public Enum Images
    DRIVE = 0
    OPEN_FOLDER = 1
    CLOSED_FOLDER = 2
    FILE = 3
End Enum

Public Class MainBox
    Private Request As FtpWebRequest
    Private RemoteDir As FtpDirectory
    Private LastDirectory As String = ""
    Private WithEvents client As FtpClient

    Private Sub MainBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Fill the local file system
        Dim drives As DriveInfo() = DriveInfo.GetDrives()
        For i As Integer = 0 To drives.Length - 1
            Dim drive As String = drives(i).Name.Replace("\", "")
            tvwLocal.Nodes.Add(drive, drive, Images.DRIVE, Images.DRIVE)
            Dim node As TreeNode = tvwLocal.Nodes(drive)
            Dim eventargs As New TreeViewEventArgs(node)
            tvwLocal_AfterExpand(Nothing, eventargs)
        Next
    End Sub

    Private Function ExtractFileName(ByVal path As String) As String
        Dim files As String() = path.Split("\")
        Dim file As String = files(files.Length - 1)
        Return file
    End Function

    Private Sub tvwLocal_AfterExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwLocal.AfterExpand
        On Error GoTo em
        Dim current As TreeNode = e.Node
        'Dim nextFile As String = Dir(current.Name & "\", FileAttribute.Directory)
        Dim dirInfo As String() = Directory.GetDirectories(current.Name & "\")
        current.Nodes.Clear()
        'Do While (nextFile IsNot Nothing AndAlso nextFile.Length > 0)
        For Each nextFile As String In dirInfo
            Dim dirnode As New TreeNode
            dirnode.Text = ExtractFileName(nextFile)
            dirnode.Name = nextFile ' current.Name & "\" & nextFile
            dirnode.ImageIndex = Images.CLOSED_FOLDER
            dirnode.SelectedImageIndex = Images.CLOSED_FOLDER
            dirnode.Nodes.Add("*DUMMY*")
            'current.Nodes.Add(current.Name & "\" & nextFile, nextFile, Images.CLOSED_FOLDER, Images.CLOSED_FOLDER)
            current.Nodes.Add(dirnode)
            'Loop
        Next
        dirInfo = Directory.GetFiles(current.Name & "\")
        'nextFile = Dir(current.Name & "\")
        For Each nextFile As String In dirInfo
            current.Nodes.Add(nextFile, ExtractFileName(nextFile), Images.FILE, Images.FILE)
        Next
        Exit Sub
em:
        If Err.Number <> 52 And Err.Number <> 57 Then
            MessageBox.Show(Err.Description)
        End If
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        On Error GoTo em
        If txtUrl.Text.Length = 0 Then
            MessageBox.Show("Please enter valid Url")
            Exit Sub
        End If
        Dim url As New Uri(txtUrl.Text)
        If url.Scheme <> Uri.UriSchemeFtp Then
            MessageBox.Show("Not an FTP Url")
            Exit Sub
        End If
        Dim login As New LoginBox()
        Dim cred As String() = login.GetCredentials()
        txtLog.AppendText("Preparing to connect...")
        If cred IsNot Nothing Then
            client = New FtpClient(txtUrl.Text, cred(0), cred(1))
            ListRemoteDirectory("")
        End If
        Exit Sub
em:
        MessageBox.Show(Err.Description)
    End Sub

    Private Sub ListRemoteDirectory(ByVal directory As String)
        lvwRemote.Items.Clear()
        'Request = CType(FtpWebRequest.Create(txtUrl.Text), FtpWebRequest)
        'Request.Credentials = New NetworkCredential(cred(0), cred(1))
        RemoteDir = client.ListDirectory(directory)
        LastDirectory = directory
        lvwRemote.Items.Add("..", "..")
        For Each item As FtpFileInfo In RemoteDir
            If item.FileType = FtpFileInfo.DirectoryEntryTypes.Directory Then
                lvwRemote.Items.Add(item.FileName, Images.CLOSED_FOLDER)
            Else
                lvwRemote.Items.Add(item.FileName, Images.FILE)
            End If
        Next

    End Sub

    Private Sub client_StatusChanged(ByVal newStatus As String) Handles client.StatusChanged
        txtLog.AppendText(newStatus & Environment.NewLine)
        Application.DoEvents()
    End Sub

    Private Sub lvwRemote_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwRemote.DoubleClick
        If lvwRemote.SelectedItems.Count > 0 Then
            Dim item As ListViewItem = lvwRemote.SelectedItems(0)
            If item.ImageIndex <> Images.FILE Then
                ListRemoteDirectory(item.Text)
            End If
        End If
    End Sub

    Private Sub lvwRemote_ItemMouseHover(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListViewItemMouseHoverEventArgs) Handles lvwRemote.ItemMouseHover
        lblStatus.Text = client.CurrentDirectory & IIf(client.CurrentDirectory.Length = 1, "", "/") & e.Item.Text
    End Sub

    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        If tvwLocal.SelectedNode IsNot Nothing AndAlso tvwLocal.SelectedNode.ImageIndex = Images.FILE Then
            Dim fi As New FileInfo(tvwLocal.SelectedNode.FullPath)
            client.Upload(fi)
            ListRemoteDirectory(".")
        End If
    End Sub

    Private Sub lvwRemote_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwRemote.SelectedIndexChanged

    End Sub

    Private Sub btnDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownload.Click
        If tvwLocal.SelectedNode IsNot Nothing AndAlso tvwLocal.SelectedNode.ImageIndex = Images.CLOSED_FOLDER AndAlso _
        lvwRemote.SelectedItems(0).ImageIndex = Images.FILE Then
            Dim sourceFile As String = lvwRemote.SelectedItems(0).Text
            Dim fi As New FileInfo(tvwLocal.SelectedNode.FullPath & "\" & sourceFile)
            client.Download(sourceFile, fi, True)
            Dim node As TreeNode = tvwLocal.SelectedNode
            Dim ev As New TreeViewEventArgs(node)
            tvwLocal_AfterExpand(Nothing, ev)
            node.Expand()
            node.Nodes(fi.FullName).EnsureVisible()
        End If
    End Sub
End Class
