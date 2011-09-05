<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WindowsSecurityDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WindowsSecurityDialog))
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.cbSUNAPW = New System.Windows.Forms.CheckBox()
        Me.picboxUsername = New System.Windows.Forms.PictureBox()
        Me.picboxAccPicture = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.picboxPassword = New System.Windows.Forms.PictureBox()
        CType(Me.picboxUsername, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxAccPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picboxPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnLogin
        '
        Me.btnLogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnLogin.Location = New System.Drawing.Point(255, 242)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(75, 23)
        Me.btnLogin.TabIndex = 2
        Me.btnLogin.Text = "Ok"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Lucida Sans Unicode", 7.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(388, 92)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = resources.GetString("Label3.Text")
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Location = New System.Drawing.Point(337, 242)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtUsername
        '
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUsername.Font = New System.Drawing.Font("Lucida Sans Unicode", 7.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(105, 142)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(188, 16)
        Me.txtUsername.TabIndex = 0
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPassword.Font = New System.Drawing.Font("Lucida Sans Unicode", 7.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(105, 172)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtPassword.Size = New System.Drawing.Size(188, 16)
        Me.txtPassword.TabIndex = 1
        '
        'cbSUNAPW
        '
        Me.cbSUNAPW.AutoSize = True
        Me.cbSUNAPW.BackColor = System.Drawing.Color.Transparent
        Me.cbSUNAPW.Font = New System.Drawing.Font("Lucida Sans Unicode", 7.75!)
        Me.cbSUNAPW.Location = New System.Drawing.Point(101, 194)
        Me.cbSUNAPW.Name = "cbSUNAPW"
        Me.cbSUNAPW.Size = New System.Drawing.Size(15, 14)
        Me.cbSUNAPW.TabIndex = 4
        Me.cbSUNAPW.TabStop = False
        Me.cbSUNAPW.UseVisualStyleBackColor = False
        '
        'picboxUsername
        '
        Me.picboxUsername.Image = Global.Windows_7_Dialogs.My.Resources.Resources.txtNotSelected
        Me.picboxUsername.Location = New System.Drawing.Point(100, 137)
        Me.picboxUsername.Name = "picboxUsername"
        Me.picboxUsername.Size = New System.Drawing.Size(197, 25)
        Me.picboxUsername.TabIndex = 12
        Me.picboxUsername.TabStop = False
        '
        'picboxAccPicture
        '
        Me.picboxAccPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picboxAccPicture.Location = New System.Drawing.Point(32, 147)
        Me.picboxAccPicture.Name = "picboxAccPicture"
        Me.picboxAccPicture.Size = New System.Drawing.Size(48, 48)
        Me.picboxAccPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picboxAccPicture.TabIndex = 11
        Me.picboxAccPicture.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox2.Image = Global.Windows_7_Dialogs.My.Resources.Resources.Win_Security_Dialog_Base_Selected
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(422, 274)
        Me.PictureBox2.TabIndex = 11
        Me.PictureBox2.TabStop = False
        '
        'picboxPassword
        '
        Me.picboxPassword.Image = Global.Windows_7_Dialogs.My.Resources.Resources.txtNotSelected
        Me.picboxPassword.Location = New System.Drawing.Point(101, 167)
        Me.picboxPassword.Name = "picboxPassword"
        Me.picboxPassword.Size = New System.Drawing.Size(197, 25)
        Me.picboxPassword.TabIndex = 13
        Me.picboxPassword.TabStop = False
        '
        'WindowsSecurityDialog
        '
        Me.AcceptButton = Me.btnLogin
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(422, 274)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.picboxPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.picboxUsername)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.picboxAccPicture)
        Me.Controls.Add(Me.cbSUNAPW)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WindowsSecurityDialog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MIT Wireless Password"
        CType(Me.picboxUsername, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxAccPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picboxPassword, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents cbSUNAPW As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents picboxAccPicture As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents picboxUsername As System.Windows.Forms.PictureBox
    Friend WithEvents picboxPassword As System.Windows.Forms.PictureBox

End Class
