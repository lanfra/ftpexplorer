Imports System.Net
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Collections.Generic

Public Class FtpClient
    Public ReadOnly Hostname As String
    Public ReadOnly Username As String
    Public ReadOnly Password As String
    Public CurrentDirectory As String
    Public Event StatusChanged(ByVal newStatus As String)

    Private Authenticated As Boolean

    Sub New(ByVal hostname As String, ByVal userName As String, ByVal password As String)
        Me.Hostname = hostname
        Me.Username = userName
        Me.Password = password
    End Sub

    Private Function GetCurrentUrl() As String
        If CurrentDirectory = "/" Then
            Return Hostname
        Else
            Return Hostname & CurrentDirectory
        End If
    End Function

    Public Function ListDirectory(Optional ByVal directory As String = "") As FtpDirectory
        On Error GoTo em
        Dim url As String
        If directory.Length = 0 Then
            Me.CurrentDirectory = "/"
            'url = Hostname
        ElseIf directory = "." Then
            'No need to do anything
        ElseIf directory = ".." Then
            If CurrentDirectory <> "/" Then
                '/pub/a
                Dim index As Integer = Me.CurrentDirectory.LastIndexOf("/")
                CurrentDirectory = CurrentDirectory.Substring(0, index)
                If CurrentDirectory.Length = 0 Then CurrentDirectory = "/"
            Else
                RaiseEvent StatusChanged("Already in the root directory")
                'url = Hostname & "/" & CurrentDirectory
            End If
        Else
            Me.CurrentDirectory &= IIf(CurrentDirectory.Length = 1, "", "/") & directory
        End If
        url = GetCurrentUrl()
        RaiseEvent StatusChanged("Logging in with user " & Username)
        'return a simple list of filenames in directory
        Dim ftp As Net.FtpWebRequest = GetRequest(url)

        'Set request to do simple list

        ftp.Method = Net.WebRequestMethods.Ftp.ListDirectoryDetails
        Dim response As FtpWebResponse = ftp.GetResponse()
        Dim sr As New StreamReader(response.GetResponseStream())
        Dim str As String = sr.ReadToEnd()
        'replace CRLF to CR, remove last instance
        str = str.Replace(vbCrLf, vbCr).TrimEnd(Chr(13))
        'split the string into a list
        If Not Authenticated Then
            Authenticated = True
            RaiseEvent StatusChanged(response.WelcomeMessage)
            RaiseEvent StatusChanged("Login successful...")
        End If
        RaiseEvent StatusChanged("Current directory is " & CurrentDirectory)
        Return New FtpDirectory(str, url)
        Exit Function
em:
        MessageBox.Show(Err.Description)
    End Function

    Private Function GetRequest(ByVal url As String) As FtpWebRequest
        Dim ftp As FtpWebRequest = FtpWebRequest.Create(url)
        ftp.Credentials = New NetworkCredential(Username, Password)
        Return ftp
    End Function

    Public Function Upload(ByVal fi As FileInfo, Optional ByVal targetFilename As String = "") As Boolean
        'copy the file specified to target file: target file can be full path or just filename (uses current dir)
        '1. check target
        Dim target As String
        If targetFilename.Trim = "" Then
            'Blank target: use source filename & current dir
            target = GetCurrentUrl() & "/" & fi.Name
        Else
            'otherwise treat as filename only, use current directory
            target = GetCurrentUrl() & "/" & targetFilename
        End If
        Dim URI As String = target 'GetCurrentUrl() & "/" & target
        'perform copy
        Dim ftp As Net.FtpWebRequest = GetRequest(URI)
        'Set request to upload a file in binary
        ftp.Method = Net.WebRequestMethods.Ftp.UploadFile
        ftp.UseBinary = True
        'Notify FTP of the expected size
        ftp.ContentLength = fi.Length
        'create byte array to store: ensure at least 1 byte!
        Const BufferSize As Integer = 2048
        Dim content(BufferSize - 1) As Byte, dataRead As Integer
        'open file for reading
        Using fs As FileStream = fi.OpenRead()
            Try
                'open request to send
                Using rs As Stream = ftp.GetRequestStream
                    Do
                        dataRead = fs.Read(content, 0, BufferSize)
                        rs.Write(content, 0, dataRead)
                        RaiseEvent StatusChanged(dataRead.ToString() & " bytes sent")
                    Loop Until dataRead < BufferSize
                    rs.Close()
                    RaiseEvent StatusChanged("File uploaded successfully")
                End Using
            Catch ex As Exception
                RaiseEvent StatusChanged("Error: " & ex.Message)
            Finally
                'ensure file closed
                fs.Close()
            End Try
        End Using
        ftp = Nothing
        Return True
    End Function

    Public Function Download(ByVal sourceFilename As String, ByVal targetFI As FileInfo, Optional ByVal PermitOverwrite As Boolean = False) As Boolean
        '1. check target
        If targetFI.Exists And Not (PermitOverwrite) Then
            'Throw New ApplicationException("Target file already exists")
            RaiseEvent StatusChanged("Target file already exists")
        End If
        '2. check source
        Dim URI As String = GetCurrentUrl() & "/" & sourceFilename
        '3. perform copy
        Dim ftp As Net.FtpWebRequest = GetRequest(URI)
        'Set request to download a file in binary mode
        ftp.Method = Net.WebRequestMethods.Ftp.DownloadFile
        ftp.UseBinary = True
        'open request and get response stream
        Using response As FtpWebResponse = CType(ftp.GetResponse, FtpWebResponse)
            Using responseStream As Stream = response.GetResponseStream
                'loop to read & write to file
                Using fs As FileStream = targetFI.OpenWrite
                    Try
                        Dim buffer(2047) As Byte
                        Dim read As Integer = 0
                        Do
                            read = responseStream.Read(buffer, 0, buffer.Length)
                            fs.Write(buffer, 0, read)
                        Loop Until read = 0
                        responseStream.Close()
                        fs.Flush()
                        fs.Close()
                    Catch ex As Exception
                        'catch error and delete file only partially downloaded
                        fs.Close()
                        'delete target file as it's incomplete
                        targetFI.Delete()
                        'Throw
                        RaiseEvent StatusChanged("Download was incomplete due to an error...")
                    End Try
                End Using
                responseStream.Close()
            End Using
            response.Close()
        End Using
        Return True
    End Function
End Class

Public Class FtpDirectory
    Inherits List(Of FtpFileInfo)
    Sub New(ByVal dir As String, ByVal path As String)
        For Each line As String In dir.Replace(vbLf, "").Split(CChar(vbCr))
            'parse
            If line <> "" Then
                Dim fi As FtpFileInfo
                Try
                    fi = New FtpFileInfo(line, path)
                Catch
                    fi = Nothing
                End Try
                If fi IsNot Nothing Then
                    Me.Add(fi)
                End If
            End If
        Next
    End Sub
End Class

Public Class FtpFileInfo
    Public ReadOnly FileName As String
    Public ReadOnly FileType As DirectoryEntryTypes
    Public ReadOnly Path As String
    Public ReadOnly Size As Long
    Public ReadOnly Permission As String
    Public ReadOnly FileDateTime As Date

    Public Enum DirectoryEntryTypes
        File
        Directory
    End Enum

    Sub New(ByVal line As String, ByVal path As String)
        'parse line
        Dim m As Match = GetMatchingRegex(line)
        If m Is Nothing Then
            'failed
            Throw New ApplicationException("Unable to parse line: " & line)
        Else
            Me.FileName = m.Groups("name").Value
            Me.Path = path
            Me.Size = CLng(m.Groups("size").Value)
            Me.Permission = m.Groups("permission").Value
            Dim _dir As String = m.Groups("dir").Value
            If (_dir <> "" And _dir <> "-") Then
                Me.FileType = DirectoryEntryTypes.Directory
            Else
                Me.FileType = DirectoryEntryTypes.File
            End If

            Try
                Me.FileDateTime = Date.Parse(m.Groups("timestamp").Value)
            Catch ex As Exception
                Me.FileDateTime = Nothing
            End Try
        End If
    End Sub

    Private Function GetMatchingRegex(ByVal line As String) As Match
        Dim formats As String() = { _
                    "(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})\s+\d+\s+\w+\s+\w+\s+(?<size>\d+)\s+(?<timestamp>\w+\s+\d+\s+\d{4})\s+(?<name>.+)", _
                    "(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})\s+\d+\s+\d+\s+(?<size>\d+)\s+(?<timestamp>\w+\s+\d+\s+\d{4})\s+(?<name>.+)", _
                    "(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})\s+\d+\s+\d+\s+(?<size>\d+)\s+(?<timestamp>\w+\s+\d+\s+\d{1,2}:\d{2})\s+(?<name>.+)", _
                    "(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})\s+\d+\s+\w+\s+\w+\s+(?<size>\d+)\s+(?<timestamp>\w+\s+\d+\s+\d{1,2}:\d{2})\s+(?<name>.+)", _
                    "(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})(\s+)(?<size>(\d+))(\s+)(?<ctbit>(\w+\s\w+))(\s+)(?<size2>(\d+))\s+(?<timestamp>\w+\s+\d+\s+\d{2}:\d{2})\s+(?<name>.+)", _
                    "(?<timestamp>\d{2}\-\d{2}\-\d{2}\s+\d{2}:\d{2}[Aa|Pp][mM])\s+(?<dir>\<\w+\>){0,1}(?<size>\d+){0,1}\s+(?<name>.+)"}
        Dim rx As Regex, m As Match
        For i As Integer = 0 To formats.Length - 1
            rx = New Regex(formats(i))
            m = rx.Match(line)
            If m.Success Then
                Return m
            End If
        Next
    End Function

End Class
