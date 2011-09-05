Imports System.Net
Imports System.Drawing

Public Class WindowsSecurityDialog
    Event Login(ByVal username As String, ByVal Password As String)
    Event SaveUNPW_Clicked(ByVal Checked As Boolean)
    Public _UserData As UserData
    Dim save As Boolean = False
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        _UserData = New UserData(txtUsername.Text, txtPassword.Text)
        If save = True Then
            Select Case cbSUNAPW.Checked
                Case True
                    'Misc.Settings.Username = txtUsername.Text
                    'Misc.Settings.Password = txtPassword.Text
                    'Misc.Settings.SUNAPW = True
                Case False
                    'Misc.Settings.Username = ""
                    'Misc.Settings.Password = ""
                    'Misc.Settings.SUNAPW = False
            End Select
        End If
        txtUsername.Text = ""
        txtPassword.Text = ""
        cbSUNAPW.Checked = False
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'PictureBox1.Image = Misc.Settings.UserPicture
        'cbSUNAPW.Checked = Misc.Settings.SUNAPW
        If cbSUNAPW.Checked Then
            'txtUsername.Text = Misc.Settings.Username
            'txtPassword.Text = Misc.Settings.Password
        Else
            txtUsername.Text = "Username"
            txtUsername.ForeColor = Color.Gray
            Dim font As New Font("Lucida Sans Unicode", 8.25, FontStyle.Regular)
            txtUsername.Font = font
            txtPassword.Text = "Password"
            txtPassword.ForeColor = Color.Gray
            txtPassword.Font = font
            txtPassword.PasswordChar = ""
            txtPassword.UseSystemPasswordChar = False
        End If
        Label3.Select()
        txtUsername.Focus()
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        save = cbSUNAPW.Checked
        RaiseEvent Login(txtUsername.Text, txtPassword.Text)
        Me.Close()
    End Sub

    Private Sub cbSUNAPW_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSUNAPW.CheckedChanged
        'Misc.Settings.SUNAPW = cbSUNAPW.Checked
    End Sub

    Private Sub txtUsername_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsername.GotFocus
        picboxUsername.Image = My.Resources.txtSelected
        If txtUsername.Text = "Username" Then
            txtUsername.Text = ""
            txtUsername.ForeColor = Color.Black
            Dim font As New Font("Lucida Sans Unicode", 8.25, FontStyle.Regular)
            txtUsername.Font = font
        End If
    End Sub

    Private Sub txtUsername_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsername.LostFocus
        picboxUsername.Image = My.Resources.txtNotSelected
        If txtUsername.Text = "" Then
            Dim font As New Font("Lucida Sans Unicode", 8.25, FontStyle.Regular)
            txtUsername.Font = font
            txtUsername.Text = "Username"
            txtUsername.ForeColor = Color.Gray
        End If
    End Sub
    Dim cancelFail As Boolean = False
    Private Sub txtPassword_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.GotFocus
        picboxPassword.Image = My.Resources.txtSelected
        If txtPassword.Font.FontFamily.Name = "Lucida Sans Unicode" Then
            Dim font As New Font("Wingdings", 5.5, FontStyle.Regular) 'Lucida Sans Unicode 105, 175
            'Dim font As New Font("Wingdings", 9, FontStyle.Regular)
            txtPassword.Font = font
            txtPassword.Text = ""
            txtPassword.ForeColor = Color.Black
            txtPassword.Font = font
            txtPassword.PasswordChar = "l" '•
            txtPassword.Location = New Point(105, 175)

        End If
    End Sub

    Private Sub txtPassword_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.LostFocus
        picboxPassword.Image = My.Resources.txtNotSelected
        If txtPassword.Text = "" Then
            Dim font As New Font("Lucida Sans Unicode", 8.25, FontStyle.Regular)
            txtPassword.Font = font
            txtPassword.Text = "Password"
            txtPassword.ForeColor = Color.Gray
            txtPassword.Font = font
            txtPassword.PasswordChar = ""
            txtPassword.Location = New Point(105, 172)
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class
