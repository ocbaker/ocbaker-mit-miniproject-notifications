<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About))
        Me.niMain = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.cmsNotifyIcon = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.LoginToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripTextBox2 = New System.Windows.Forms.ToolStripTextBox
        Me.AutoLogin = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.loginWUAP = New System.Windows.Forms.ToolStripMenuItem
        Me.cmsNotifyIcon.SuspendLayout()
        Me.SuspendLayout()
        '
        'niMain
        '
        Me.niMain.ContextMenuStrip = Me.cmsNotifyIcon
        Me.niMain.Icon = CType(resources.GetObject("niMain.Icon"), System.Drawing.Icon)
        Me.niMain.Text = "MIT Auto Login"
        Me.niMain.Visible = True
        '
        'cmsNotifyIcon
        '
        Me.cmsNotifyIcon.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem, Me.ToolStripMenuItem1, Me.LoginToolStripMenuItem, Me.AutoLogin, Me.ToolStripMenuItem2, Me.AboutToolStripMenuItem})
        Me.cmsNotifyIcon.Name = "cmsNotifyIcon"
        Me.cmsNotifyIcon.Size = New System.Drawing.Size(134, 104)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(130, 6)
        '
        'LoginToolStripMenuItem
        '
        Me.LoginToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox1, Me.ToolStripTextBox2, Me.loginWUAP})
        Me.LoginToolStripMenuItem.Name = "LoginToolStripMenuItem"
        Me.LoginToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.LoginToolStripMenuItem.Text = "Login..."
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(100, 23)
        Me.ToolStripTextBox1.Text = "Username"
        '
        'ToolStripTextBox2
        '
        Me.ToolStripTextBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripTextBox2.Name = "ToolStripTextBox2"
        Me.ToolStripTextBox2.Size = New System.Drawing.Size(100, 23)
        Me.ToolStripTextBox2.Text = "Password"
        '
        'AutoLogin
        '
        Me.AutoLogin.CheckOnClick = True
        Me.AutoLogin.Enabled = False
        Me.AutoLogin.Name = "AutoLogin"
        Me.AutoLogin.Size = New System.Drawing.Size(133, 22)
        Me.AutoLogin.Text = "Auto Login"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(130, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.AboutToolStripMenuItem.Text = "About..."
        '
        'loginWUAP
        '
        Me.loginWUAP.Name = "loginWUAP"
        Me.loginWUAP.Size = New System.Drawing.Size(160, 22)
        Me.loginWUAP.Text = "Login"
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Name = "About"
        Me.Text = "About"
        Me.cmsNotifyIcon.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents niMain As System.Windows.Forms.NotifyIcon
    Friend WithEvents cmsNotifyIcon As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LoginToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AutoLogin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripTextBox2 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents loginWUAP As System.Windows.Forms.ToolStripMenuItem
End Class
