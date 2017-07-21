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
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tbConnectionInfo = New System.Windows.Forms.TextBox()
        Me.bPlayOnce = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lAccText = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.tbLevel = New System.Windows.Forms.TextBox()
        Me.rbFreq = New System.Windows.Forms.RadioButton()
        Me.tbPeriod = New System.Windows.Forms.TextBox()
        Me.rbTotalTime = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbFreq = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.bGenerate = New System.Windows.Forms.Button()
        Me.RadioButton7 = New System.Windows.Forms.RadioButton()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.rbSlowDown = New System.Windows.Forms.RadioButton()
        Me.rbSlowUp = New System.Windows.Forms.RadioButton()
        Me.rbTriangle = New System.Windows.Forms.RadioButton()
        Me.rbSquare = New System.Windows.Forms.RadioButton()
        Me.rbSine = New System.Windows.Forms.RadioButton()
        Me.lTime2 = New System.Windows.Forms.Label()
        Me.lTime1 = New System.Windows.Forms.Label()
        Me.lTime0 = New System.Windows.Forms.Label()
        Me.pbSignalView = New System.Windows.Forms.PictureBox()
        Me.bRepeat = New System.Windows.Forms.Button()
        Me.bStop = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.tState = New System.Windows.Forms.Timer(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.pbSignalView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'logWriter
        '
        Me.logWriter.Location = New System.Drawing.Point(2, 368)
        Me.logWriter.Size = New System.Drawing.Size(781, 192)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbConnectionInfo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(283, 47)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Connection"
        '
        'tbConnectionInfo
        '
        Me.tbConnectionInfo.Location = New System.Drawing.Point(6, 19)
        Me.tbConnectionInfo.Name = "tbConnectionInfo"
        Me.tbConnectionInfo.Size = New System.Drawing.Size(271, 20)
        Me.tbConnectionInfo.TabIndex = 5
        '
        'bPlayOnce
        '
        Me.bPlayOnce.Location = New System.Drawing.Point(6, 17)
        Me.bPlayOnce.Name = "bPlayOnce"
        Me.bPlayOnce.Size = New System.Drawing.Size(86, 23)
        Me.bPlayOnce.TabIndex = 3
        Me.bPlayOnce.Text = "Play Once"
        Me.bPlayOnce.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.lAccText)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.bGenerate)
        Me.GroupBox2.Controls.Add(Me.RadioButton7)
        Me.GroupBox2.Controls.Add(Me.RadioButton6)
        Me.GroupBox2.Controls.Add(Me.rbSlowDown)
        Me.GroupBox2.Controls.Add(Me.rbSlowUp)
        Me.GroupBox2.Controls.Add(Me.rbTriangle)
        Me.GroupBox2.Controls.Add(Me.rbSquare)
        Me.GroupBox2.Controls.Add(Me.rbSine)
        Me.GroupBox2.Controls.Add(Me.lTime2)
        Me.GroupBox2.Controls.Add(Me.lTime1)
        Me.GroupBox2.Controls.Add(Me.lTime0)
        Me.GroupBox2.Controls.Add(Me.pbSignalView)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 80)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(654, 285)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Generator"
        '
        'lAccText
        '
        Me.lAccText.AutoSize = True
        Me.lAccText.Location = New System.Drawing.Point(318, 17)
        Me.lAccText.Name = "lAccText"
        Me.lAccText.Size = New System.Drawing.Size(0, 13)
        Me.lAccText.TabIndex = 24
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.tbLevel)
        Me.GroupBox4.Controls.Add(Me.rbFreq)
        Me.GroupBox4.Controls.Add(Me.tbPeriod)
        Me.GroupBox4.Controls.Add(Me.rbTotalTime)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.tbFreq)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Location = New System.Drawing.Point(131, 11)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(161, 95)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Timing"
        '
        'tbLevel
        '
        Me.tbLevel.Location = New System.Drawing.Point(102, 65)
        Me.tbLevel.Name = "tbLevel"
        Me.tbLevel.Size = New System.Drawing.Size(52, 20)
        Me.tbLevel.TabIndex = 22
        Me.tbLevel.Text = "30"
        '
        'rbFreq
        '
        Me.rbFreq.AutoSize = True
        Me.rbFreq.Location = New System.Drawing.Point(10, 42)
        Me.rbFreq.Name = "rbFreq"
        Me.rbFreq.Size = New System.Drawing.Size(14, 13)
        Me.rbFreq.TabIndex = 25
        Me.rbFreq.UseVisualStyleBackColor = True
        '
        'tbPeriod
        '
        Me.tbPeriod.Location = New System.Drawing.Point(102, 14)
        Me.tbPeriod.Name = "tbPeriod"
        Me.tbPeriod.Size = New System.Drawing.Size(52, 20)
        Me.tbPeriod.TabIndex = 10
        Me.tbPeriod.Text = "100"
        '
        'rbTotalTime
        '
        Me.rbTotalTime.AutoSize = True
        Me.rbTotalTime.Checked = True
        Me.rbTotalTime.Location = New System.Drawing.Point(10, 18)
        Me.rbTotalTime.Name = "rbTotalTime"
        Me.rbTotalTime.Size = New System.Drawing.Size(14, 13)
        Me.rbTotalTime.TabIndex = 24
        Me.rbTotalTime.TabStop = True
        Me.rbTotalTime.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Total time, ms"
        '
        'tbFreq
        '
        Me.tbFreq.Enabled = False
        Me.tbFreq.Location = New System.Drawing.Point(102, 39)
        Me.tbFreq.Name = "tbFreq"
        Me.tbFreq.Size = New System.Drawing.Size(52, 20)
        Me.tbFreq.TabIndex = 19
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Freq, Hz"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Level,%"
        '
        'bGenerate
        '
        Me.bGenerate.Location = New System.Drawing.Point(183, 228)
        Me.bGenerate.Name = "bGenerate"
        Me.bGenerate.Size = New System.Drawing.Size(86, 23)
        Me.bGenerate.TabIndex = 23
        Me.bGenerate.Text = "Generate"
        Me.bGenerate.UseVisualStyleBackColor = True
        '
        'RadioButton7
        '
        Me.RadioButton7.AutoSize = True
        Me.RadioButton7.Location = New System.Drawing.Point(7, 175)
        Me.RadioButton7.Name = "RadioButton7"
        Me.RadioButton7.Size = New System.Drawing.Size(88, 17)
        Me.RadioButton7.TabIndex = 17
        Me.RadioButton7.Text = "Square Pulse"
        Me.RadioButton7.UseVisualStyleBackColor = True
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.Location = New System.Drawing.Point(6, 107)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(75, 17)
        Me.RadioButton6.TabIndex = 16
        Me.RadioButton6.Text = "Sine Pulse"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'rbSlowDown
        '
        Me.rbSlowDown.AutoSize = True
        Me.rbSlowDown.Location = New System.Drawing.Point(6, 153)
        Me.rbSlowDown.Name = "rbSlowDown"
        Me.rbSlowDown.Size = New System.Drawing.Size(108, 17)
        Me.rbSlowDown.TabIndex = 15
        Me.rbSlowDown.Text = "Slow-Down Pulse"
        Me.rbSlowDown.UseVisualStyleBackColor = True
        '
        'rbSlowUp
        '
        Me.rbSlowUp.AutoSize = True
        Me.rbSlowUp.Location = New System.Drawing.Point(6, 130)
        Me.rbSlowUp.Name = "rbSlowUp"
        Me.rbSlowUp.Size = New System.Drawing.Size(94, 17)
        Me.rbSlowUp.TabIndex = 14
        Me.rbSlowUp.Text = "Slow-Up Pulse"
        Me.rbSlowUp.UseVisualStyleBackColor = True
        '
        'rbTriangle
        '
        Me.rbTriangle.AutoSize = True
        Me.rbTriangle.Location = New System.Drawing.Point(6, 66)
        Me.rbTriangle.Name = "rbTriangle"
        Me.rbTriangle.Size = New System.Drawing.Size(61, 17)
        Me.rbTriangle.TabIndex = 13
        Me.rbTriangle.Text = "Trangle"
        Me.rbTriangle.UseVisualStyleBackColor = True
        '
        'rbSquare
        '
        Me.rbSquare.AutoSize = True
        Me.rbSquare.Location = New System.Drawing.Point(6, 43)
        Me.rbSquare.Name = "rbSquare"
        Me.rbSquare.Size = New System.Drawing.Size(59, 17)
        Me.rbSquare.TabIndex = 12
        Me.rbSquare.Text = "Square"
        Me.rbSquare.UseVisualStyleBackColor = True
        '
        'rbSine
        '
        Me.rbSine.AutoSize = True
        Me.rbSine.Checked = True
        Me.rbSine.Location = New System.Drawing.Point(6, 20)
        Me.rbSine.Name = "rbSine"
        Me.rbSine.Size = New System.Drawing.Size(46, 17)
        Me.rbSine.TabIndex = 11
        Me.rbSine.TabStop = True
        Me.rbSine.Text = "Sine"
        Me.rbSine.UseVisualStyleBackColor = True
        '
        'lTime2
        '
        Me.lTime2.Location = New System.Drawing.Point(581, 258)
        Me.lTime2.Name = "lTime2"
        Me.lTime2.Size = New System.Drawing.Size(67, 13)
        Me.lTime2.TabIndex = 9
        Me.lTime2.Text = "100 ms"
        Me.lTime2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lTime1
        '
        Me.lTime1.Location = New System.Drawing.Point(456, 258)
        Me.lTime1.Name = "lTime1"
        Me.lTime1.Size = New System.Drawing.Size(75, 13)
        Me.lTime1.TabIndex = 8
        Me.lTime1.Text = "50 ms"
        Me.lTime1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lTime0
        '
        Me.lTime0.AutoSize = True
        Me.lTime0.Location = New System.Drawing.Point(340, 258)
        Me.lTime0.Name = "lTime0"
        Me.lTime0.Size = New System.Drawing.Size(29, 13)
        Me.lTime0.TabIndex = 7
        Me.lTime0.Text = "0 ms"
        '
        'pbSignalView
        '
        Me.pbSignalView.BackColor = System.Drawing.Color.White
        Me.pbSignalView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbSignalView.Location = New System.Drawing.Point(343, 17)
        Me.pbSignalView.Name = "pbSignalView"
        Me.pbSignalView.Size = New System.Drawing.Size(305, 234)
        Me.pbSignalView.TabIndex = 6
        Me.pbSignalView.TabStop = False
        '
        'bRepeat
        '
        Me.bRepeat.Location = New System.Drawing.Point(6, 46)
        Me.bRepeat.Name = "bRepeat"
        Me.bRepeat.Size = New System.Drawing.Size(86, 23)
        Me.bRepeat.TabIndex = 4
        Me.bRepeat.Text = "Repeat"
        Me.bRepeat.UseVisualStyleBackColor = True
        '
        'bStop
        '
        Me.bStop.Location = New System.Drawing.Point(6, 75)
        Me.bStop.Name = "bStop"
        Me.bStop.Size = New System.Drawing.Size(86, 23)
        Me.bStop.TabIndex = 5
        Me.bStop.Text = "Stop"
        Me.bStop.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.bRepeat)
        Me.GroupBox3.Controls.Add(Me.bStop)
        Me.GroupBox3.Controls.Add(Me.bPlayOnce)
        Me.GroupBox3.Enabled = False
        Me.GroupBox3.Location = New System.Drawing.Point(672, 80)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(100, 285)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Control"
        '
        'tState
        '
        Me.tState.Enabled = True
        Me.tState.Interval = 500
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(312, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "25g"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(312, 233)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "-25g"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(318, 130)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(13, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "0"
        '
        'App
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "App"
        Me.Text = "Bwl.Hardware.LowFreqGenerator"
        Me.Controls.SetChildIndex(Me.logWriter, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.pbSignalView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents bPlayOnce As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents tbConnectionInfo As TextBox
    Friend WithEvents bStop As Button
    Friend WithEvents bRepeat As Button
    Friend WithEvents pbSignalView As PictureBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents bGenerate As Button
    Friend WithEvents tbLevel As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tbFreq As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents RadioButton7 As RadioButton
    Friend WithEvents RadioButton6 As RadioButton
    Friend WithEvents rbSlowDown As RadioButton
    Friend WithEvents rbSlowUp As RadioButton
    Friend WithEvents rbTriangle As RadioButton
    Friend WithEvents rbSquare As RadioButton
    Friend WithEvents rbSine As RadioButton
    Friend WithEvents tbPeriod As TextBox
    Friend WithEvents lTime2 As Label
    Friend WithEvents lTime1 As Label
    Friend WithEvents lTime0 As Label
    Friend WithEvents tState As Timer
    Friend WithEvents rbFreq As RadioButton
    Friend WithEvents rbTotalTime As RadioButton
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents lAccText As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
End Class
