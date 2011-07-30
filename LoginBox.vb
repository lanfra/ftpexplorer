Imports System.Windows.Forms

Public Class LoginBox
    Private result As String()

    Public Overloads Function GetCredentials() As String()
        result = Nothing
        MyBase.ShowDialog()
        Return result
    End Function


    Private Sub LoginBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.ShowDialog()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        ReDim result(1)
        result(0) = txtUsername.Text
        result(1) = txtPassword.Text
        Me.Close()
    End Sub
End Class