<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class App
    Inherits Bwl.Framework.FormAppBase

    'Форма переопределяет dispose для очистки списка компонентов.
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

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.bPort = New System.Windows.Forms.ComboBox()
        Me.bOpen = New System.Windows.Forms.Button()
        Me.bPlay = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.bOpen)
        Me.GroupBox1.Controls.Add(Me.bPort)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(197, 144)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Connection"
        '
        'bPort
        '
        Me.bPort.FormattingEnabled = True
        Me.bPort.Location = New System.Drawing.Point(14, 19)
        Me.bPort.Name = "bPort"
        Me.bPort.Size = New System.Drawing.Size(110, 21)
        Me.bPort.TabIndex = 0
        '
        'bOpen
        '
        Me.bOpen.Location = New System.Drawing.Point(130, 19)
        Me.bOpen.Name = "bOpen"
        Me.bOpen.Size = New System.Drawing.Size(61, 23)
        Me.bOpen.TabIndex = 1
        Me.bOpen.Text = "Open"
        Me.bOpen.UseVisualStyleBackColor = True
        '
        'bPlay
        '
        Me.bPlay.Location = New System.Drawing.Point(6, 115)
        Me.bPlay.Name = "bPlay"
        Me.bPlay.Size = New System.Drawing.Size(61, 23)
        Me.bPlay.TabIndex = 3
        Me.bPlay.Text = "Play"
        Me.bPlay.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.bPlay)
        Me.GroupBox2.Location = New System.Drawing.Point(215, 27)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(238, 144)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Generator"
        '
        'App
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "App"
        Me.Text = "Bwl.Hardware.LowFreqGenerator"
        Me.Controls.SetChildIndex(Me.logWriter, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents bOpen As Button
    Friend WithEvents bPort As ComboBox
    Friend WithEvents bPlay As Button
    Friend WithEvents GroupBox2 As GroupBox
End Class
