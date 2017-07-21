Public Class App
    Private _gen As New GeneratorInterface
    Private _seq(107) As Double
    Private _seqTimeMs As Double
    Private _view As Bitmap
    Private _graph As Graphics
    Private _scanningFlag As Boolean = False
    Private _AccTestProcess As Boolean = False

    Private Sub bPlay_Click(sender As Object, e As EventArgs) Handles bPlayOnce.Click
        Try
            _gen.SendSequence(_seq, _seqTimeMs)
            _gen.PlayOnce()
        Catch ex As Exception
            _logger.AddError(ex.Message)
        End Try
    End Sub

    Private Sub AccelerationRequestProcess()
        While True
            ShowAccelerationData()
            Threading.Thread.Sleep(3000)
        End While
    End Sub
    Private Sub bGenerate_Click(sender As Object, e As EventArgs) Handles bGenerate.Click
        Dim level = Val(tbLevel.Text) / 100
        _seqTimeMs = Val(tbPeriod.Text)
        If rbSine.Checked Then
            For i = 0 To _seq.Length - 1
                _seq(i) = Math.Sin(i / _seq.Length * Math.PI * 2 - Math.PI * 0.5) * 0.5 * level + 0.5 * level
            Next
        ElseIf rbSquare.Checked Then
            For i = 0 To _seq.Length - 1
                If i > _seq.Length * 0.25 And i < _seq.Length * 0.75 Then
                    _seq(i) = level
                Else
                    _seq(i) = 0
                End If
            Next
        ElseIf rbTriangle.Checked Then
            For i = 0 To _seq.Length - 1
                If i < _seq.Length * 0.5 Then
                    _seq(i) = i * 2 / _seq.Length * level
                Else
                    _seq(i) = level - (i - _seq.Length / 2) * 2 / _seq.Length * level
                End If
            Next
        End If
        ShowSequence()
    End Sub

    Private Sub ShowSequence()
        _graph.Clear(Color.White)
        _graph.DrawLine(Pens.Gray, 0, CInt(_view.Height * 0.05), _view.Width, CInt(_view.Height * 0.05))
        _graph.DrawLine(Pens.Gray, 0, CInt(_view.Height * 0.95), _view.Width, CInt(_view.Height * 0.95))
        For i = 0 To _seq.Length - 2
            Dim y1 = CInt(_view.Height * 0.95 - (_seq(i) * _view.Height * 0.9))
            Dim y2 = CInt(_view.Height * 0.95 - (_seq(i + 1) * _view.Height * 0.9))
            Dim x1 = CInt(i * _view.Width / _seq.Length)
            Dim x2 = CInt((i + 1) * _view.Width / _seq.Length)
            _graph.DrawLine(Pens.Blue, x1, y1, x2, y2)
        Next
        lAccText.Text = ""
        lTime0.Text = "0 ms"
        lTime1.Text = (_seqTimeMs / 2).ToString + " ms"
        lTime2.Text = (_seqTimeMs).ToString + " ms"
        pbSignalView.Image = _view
        pbSignalView.Refresh()
        GroupBox3.Enabled = True
    End Sub

    Private Sub App_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbFreq.Text = CInt(1000 / Val(tbPeriod.Text)).ToString
        _view = New Bitmap(pbSignalView.Width, pbSignalView.Height)
        Dim th = New Threading.Thread(AddressOf AccelerationRequestProcess)
        th.Start()
        _graph = Graphics.FromImage(_view)
    End Sub

    Private Sub bRepeat_Click(sender As Object, e As EventArgs) Handles bRepeat.Click
        Try
            _gen.SendSequence(_seq, _seqTimeMs)
            _gen.Repeat()
            _AccTestProcess = True
        Catch ex As Exception
            _logger.AddError(ex.Message)
        End Try
    End Sub

    Private Sub bStop_Click(sender As Object, e As EventArgs) Handles bStop.Click
        Try
            _gen.StopRepeat()
            _AccTestProcess = False
        Catch ex As Exception
            _logger.AddError(ex.Message)
        End Try
    End Sub

    Private Sub tState_Tick(sender As Object, e As EventArgs) Handles tState.Tick
        tbConnectionInfo.Text = _gen.Board.BoardConnection.ToString + ", " + _gen.Board.BoardInfo
        If _gen.Board.BoardConnection = SimplSerialConnectStatus.Connected Then
            tbConnectionInfo.BackColor = Color.LightGreen
        Else
            tbConnectionInfo.BackColor = Color.LightPink
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub rbTotalTime_CheckedChanged(sender As Object, e As EventArgs) Handles rbTotalTime.CheckedChanged
        tbPeriod.Enabled = True
        tbFreq.Enabled = False
    End Sub

    Private Sub rbFreq_CheckedChanged(sender As Object, e As EventArgs) Handles rbFreq.CheckedChanged
        tbPeriod.Enabled = False
        tbFreq.Enabled = True
    End Sub

    Private Sub tbPeriod_TextChanged(sender As Object, e As EventArgs) Handles tbPeriod.TextChanged
        If rbTotalTime.Checked Then
            Try
                tbFreq.Text = CInt(1000 / Val(tbPeriod.Text)).ToString
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub tbFreq_TextChanged(sender As Object, e As EventArgs) Handles tbFreq.TextChanged
        If rbFreq.Checked Then
            tbPeriod.Text = CInt(1000 / Val(tbFreq.Text)).ToString
        End If
    End Sub

    Private Sub bFind_Click(sender As Object, e As EventArgs)
        _scanningFlag = Not _scanningFlag
        If _scanningFlag Then
            Dim th = New Threading.Thread(AddressOf FindResonantFrequency)
            th.Start()
        End If
    End Sub


    Private Sub ShowAccelerationData()
        Dim data = _gen.GetAcceleration()
        Dim img As Bitmap = New Bitmap(800, 256)
        Dim imgGraph = Graphics.FromImage(img)
        Dim p As New Pen(Brushes.Red)
        p.Width = 1.0F
        p.LineJoin = Drawing2D.LineJoin.Bevel
        Dim x0 As Single = 0
        Dim y0 As Single = img.Height / 2
        imgGraph.DrawLine(New Pen(Brushes.Green), 0, CInt(img.Height / 2), img.Width, CInt(img.Height / 2))
        For i = 0 To data.Count - 1
            imgGraph.DrawLine(p, x0, y0, CInt(i * img.Width / data.Length), CInt(img.Height / 2 + (data(i) - 128)))
            x0 = CInt(i * img.Width / data.Length)
            y0 = CInt(img.Height / 2 + (data(i) - 128))
        Next
        pbSignalView.Image = New Bitmap(img, pbSignalView.Width, pbSignalView.Height)
    End Sub

    Private Sub FindResonantFrequency()

        'Dim dataList As List(Of AccelerometerData) = New List(Of AccelerometerData)
        'Dim resonantSeqTimeValue As Double = 100
        'Dim maxAcc As Single = 1.0
        '_gen.Repeat()
        '_gen.GetMaxAcceleration(5)
        'While resonantSeqTimeValue > 5
        '    If _scanningFlag = False Then
        '        Exit While
        '    End If
        '    _gen.SendSequence(_seq, resonantSeqTimeValue)
        '    resonantSeqTimeValue = resonantSeqTimeValue - 4
        '    _gen.Repeat()
        '    Threading.Thread.Sleep(1000)
        '    dataList.Add(_gen.GetMaxAcceleration(1))
        '    _logger.AddMessage(resonantSeqTimeValue.ToString + "ms: " + dataList.Last().Z.ToString + "g")
        'End While
        '_gen.StopRepeat()
        'Dim maxAcceleration = dataList.ToArray
        'For Each accValues In maxAcceleration
        '    If accValues.X + accValues.Y + accValues.Z > maxAcc Then maxAcc = accValues.X + accValues.Y + accValues.Z
        'Next

        ''Нормализация значений и отрисовка графика
        'Dim img As Bitmap = New Bitmap(maxAcceleration.Count * 20, 800)
        'Dim imgGraph = Graphics.FromImage(img)
        'Dim p As New Pen(Brushes.Red)
        'p.Width = 4.0F
        'p.LineJoin = Drawing2D.LineJoin.Bevel
        'Dim x0 As Single = 0
        'Dim y0 As Single = img.Height
        'imgGraph.Clear(Color.White)
        'For i = 0 To maxAcceleration.Count - 1
        '    Dim normalisedValue As Single = (maxAcceleration(i).X + maxAcceleration(i).Y + maxAcceleration(i).Z) / maxAcc
        '    Dim y As Single = img.Height - Math.Round(img.Height * normalisedValue)
        '    If y > 1 Then y -= 1
        '    imgGraph.DrawLine(p, x0, y0, CInt(i * img.Width / maxAcceleration.Count), y)
        '    x0 = CInt(i * img.Width / maxAcceleration.Count)
        '    y0 = y
        'Next

        'pbSignalView.Image = New Bitmap(img, pbSignalView.Width, pbSignalView.Height)
        'img.Save("image.jpg")
        'Me.Invoke(Function()
        '              lAccText.Text = Math.Round(maxAcc).ToString + "g"
        '              lTime0.Text = "100ms"
        '              lTime1.Text = "50ms"
        '              lTime2.Text = "5ms"
        '              pbSignalView.Refresh()
        '          End Function)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim th = New Threading.Thread(AddressOf AccelerationRequestProcess)
        th.Start()
    End Sub
End Class
