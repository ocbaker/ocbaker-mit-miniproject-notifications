Public Class SecurityDialog
#Region "Variables"
    Private _Dialog As New WindowsSecurityDialog
    Private _DescriptiveText As String
    Private _Title As String
    Private _Username As String
    Private _Password As String
    Private _SUNPW As Boolean
    Private _UserData As UserData
    Public _ProxyDetail As String = "The Server https//10.1.1.110 at MIT Wireless Network Login requires a username and password"
    Private _Warning As String = "Warning: This server is requesting that your username and password be sent in an insecure manner (basic authentication without a secure connection)."
#End Region

#Region "Events"
    Event DialogOpened()
    Event Cancelled()
    Event LoginRequested(ByVal username As String, ByVal password As String, ByVal SaveUsernameAndPassword As Boolean)
#End Region

#Region "Constructors"

#End Region

#Region "Properties"
    ReadOnly Property UserData As UserData
        Get
            Return _UserData
        End Get
    End Property
#End Region

#Region "Methods"
    'Sub UseProxyDefault(ByVal RequestingProxyName As String)
    '
    'End Sub
    Sub Show(Optional ByVal title As String = "", Optional ByVal context As String = "")

        If context = "" And title = "" Then
            _Dialog.Label3.Text = _ProxyDetail & vbNewLine & _Warning
            _Dialog.Text = "Proxy Authentication"
        Else
            _Dialog.Label3.Text = context
            _Dialog.Text = title & vbNewLine & _Warning
        End If

        _Dialog.ShowDialog()
        _UserData = _Dialog._UserData
    End Sub

#End Region

#Region "Functions"
#Region "Private"

#End Region

#End Region
End Class

Public Class Oli
    Inherits SecurityDialog

    Sub New()
        Dim a As String = "Hello"
        MyBase.New(a)
    End Sub
End Class
