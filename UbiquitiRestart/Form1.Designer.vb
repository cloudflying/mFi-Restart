<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.btnRestart = New System.Windows.Forms.Button()
        Me.btnConfigure = New System.Windows.Forms.LinkLabel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblLastRestart = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnRestart
        '
        Me.btnRestart.Location = New System.Drawing.Point(192, 161)
        Me.btnRestart.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRestart.Name = "btnRestart"
        Me.btnRestart.Size = New System.Drawing.Size(309, 100)
        Me.btnRestart.TabIndex = 0
        Me.btnRestart.Text = "Restart"
        Me.btnRestart.UseVisualStyleBackColor = True
        '
        'btnConfigure
        '
        Me.btnConfigure.AutoSize = True
        Me.btnConfigure.Location = New System.Drawing.Point(638, 401)
        Me.btnConfigure.Name = "btnConfigure"
        Me.btnConfigure.Size = New System.Drawing.Size(68, 18)
        Me.btnConfigure.TabIndex = 1
        Me.btnConfigure.TabStop = True
        Me.btnConfigure.Text = "Configure"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(192, 281)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox1.Size = New System.Drawing.Size(309, 135)
        Me.TextBox1.TabIndex = 2
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(12, 60)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(699, 44)
        Me.lblStatus.TabIndex = 3
        Me.lblStatus.Text = "Last Check - Not Run..."
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLastRestart
        '
        Me.lblLastRestart.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastRestart.Location = New System.Drawing.Point(12, 104)
        Me.lblLastRestart.Name = "lblLastRestart"
        Me.lblLastRestart.Size = New System.Drawing.Size(699, 44)
        Me.lblLastRestart.TabIndex = 4
        Me.lblLastRestart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(723, 428)
        Me.Controls.Add(Me.lblLastRestart)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnConfigure)
        Me.Controls.Add(Me.btnRestart)
        Me.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Restart Network and Internet"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnRestart As Button
    Friend WithEvents btnConfigure As LinkLabel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblLastRestart As Label
End Class
