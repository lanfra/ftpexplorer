<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainBox
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainBox))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtUrl = New System.Windows.Forms.TextBox
        Me.btnOk = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.progressBar1 = New System.Windows.Forms.ToolStripProgressBar
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.txtUsername = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.mnuFtp = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DownloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CreateFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ShowDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLocal = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UploadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ShowDetailsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.tvwLocal = New System.Windows.Forms.TreeView
        Me.lvwRemote = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtLog = New System.Windows.Forms.RichTextBox
        Me.StatusStrip1.SuspendLayout()
        Me.mnuFtp.SuspendLayout()
        Me.mnuLocal.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Url:"
        '
        'txtUrl
        '
        Me.txtUrl.Location = New System.Drawing.Point(32, 12)
        Me.txtUrl.Name = "txtUrl"
        Me.txtUrl.Size = New System.Drawing.Size(145, 21)
        Me.txtUrl.TabIndex = 1
        Me.txtUrl.Text = "ftp://localhost"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(567, 11)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(40, 23)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "DRIVE")
        Me.ImageList1.Images.SetKeyName(1, "OPEN_FOLDER")
        Me.ImageList1.Images.SetKeyName(2, "CLOSED_FOLDER")
        Me.ImageList1.Images.SetKeyName(3, "FILE")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Local System"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(512, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Remote System"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.progressBar1, Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 410)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(615, 22)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'progressBar1
        '
        Me.progressBar1.Name = "progressBar1"
        Me.progressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 17)
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(224, 12)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(83, 21)
        Me.txtUsername.TabIndex = 13
        Me.txtUsername.Text = "Anonymous"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(181, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 15)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "User:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(381, 12)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(83, 21)
        Me.txtPassword.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(310, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 15)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Password:"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(504, 12)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(57, 21)
        Me.txtPort.TabIndex = 17
        Me.txtPort.Text = "21"
        Me.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(466, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 15)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Port:"
        '
        'mnuFtp
        '
        Me.mnuFtp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuFtp.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DownloadToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.CreateFolderToolStripMenuItem, Me.ShowDetailsToolStripMenuItem})
        Me.mnuFtp.Name = "mnuFtp"
        Me.mnuFtp.Size = New System.Drawing.Size(150, 92)
        '
        'DownloadToolStripMenuItem
        '
        Me.DownloadToolStripMenuItem.Name = "DownloadToolStripMenuItem"
        Me.DownloadToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DownloadToolStripMenuItem.Text = "Download"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'CreateFolderToolStripMenuItem
        '
        Me.CreateFolderToolStripMenuItem.Name = "CreateFolderToolStripMenuItem"
        Me.CreateFolderToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.CreateFolderToolStripMenuItem.Text = "Create Folder"
        '
        'ShowDetailsToolStripMenuItem
        '
        Me.ShowDetailsToolStripMenuItem.Name = "ShowDetailsToolStripMenuItem"
        Me.ShowDetailsToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.ShowDetailsToolStripMenuItem.Text = "Show Details"
        '
        'mnuLocal
        '
        Me.mnuLocal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuLocal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UploadToolStripMenuItem, Me.ShowDetailsToolStripMenuItem1})
        Me.mnuLocal.Name = "ContextMenuStrip1"
        Me.mnuLocal.Size = New System.Drawing.Size(153, 70)
        '
        'UploadToolStripMenuItem
        '
        Me.UploadToolStripMenuItem.Name = "UploadToolStripMenuItem"
        Me.UploadToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.UploadToolStripMenuItem.Text = "Upload"
        '
        'ShowDetailsToolStripMenuItem1
        '
        Me.ShowDetailsToolStripMenuItem1.Name = "ShowDetailsToolStripMenuItem1"
        Me.ShowDetailsToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.ShowDetailsToolStripMenuItem1.Text = "Show Details"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(10, 75)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tvwLocal)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lvwRemote)
        Me.SplitContainer1.Size = New System.Drawing.Size(597, 198)
        Me.SplitContainer1.SplitterDistance = 303
        Me.SplitContainer1.TabIndex = 21
        '
        'tvwLocal
        '
        Me.tvwLocal.ContextMenuStrip = Me.mnuLocal
        Me.tvwLocal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvwLocal.ImageKey = "CLOSED_FOLDER"
        Me.tvwLocal.ImageList = Me.ImageList1
        Me.tvwLocal.Location = New System.Drawing.Point(0, 0)
        Me.tvwLocal.Name = "tvwLocal"
        Me.tvwLocal.SelectedImageKey = "CLOSED_FOLDER"
        Me.tvwLocal.Size = New System.Drawing.Size(303, 198)
        Me.tvwLocal.TabIndex = 24
        '
        'lvwRemote
        '
        Me.lvwRemote.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lvwRemote.ContextMenuStrip = Me.mnuFtp
        Me.lvwRemote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwRemote.Location = New System.Drawing.Point(0, 0)
        Me.lvwRemote.Name = "lvwRemote"
        Me.lvwRemote.Size = New System.Drawing.Size(290, 198)
        Me.lvwRemote.SmallImageList = Me.ImageList1
        Me.lvwRemote.TabIndex = 13
        Me.lvwRemote.UseCompatibleStateImageBehavior = False
        Me.lvwRemote.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Files/Folders"
        Me.ColumnHeader1.Width = 164
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtLog)
        Me.Panel1.Location = New System.Drawing.Point(10, 279)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(597, 128)
        Me.Panel1.TabIndex = 22
        '
        'txtLog
        '
        Me.txtLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLog.Location = New System.Drawing.Point(0, 0)
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.txtLog.Size = New System.Drawing.Size(597, 128)
        Me.txtLog.TabIndex = 19
        Me.txtLog.Text = ""
        '
        'MainBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 432)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtUrl)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "MainBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ftp Explorer"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.mnuFtp.ResumeLayout(False)
        Me.mnuLocal.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUrl As System.Windows.Forms.TextBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents progressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents mnuFtp As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DownloadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLocal As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents UploadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowDetailsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tvwLocal As System.Windows.Forms.TreeView
    Friend WithEvents lvwRemote As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtLog As System.Windows.Forms.RichTextBox

End Class
