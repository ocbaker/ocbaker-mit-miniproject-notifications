Public Class UserData

    Private _Username As String
    Private _Password As String

    Public Sub New(ByVal username As String, ByVal password As String)
        _Username = username
        _Password = password
    End Sub

    Public ReadOnly Property Username As String
        Get
            Return _Username
        End Get
    End Property
    Public ReadOnly Property Password As String
        Get
            Return _Password
        End Get
    End Property
End Class
