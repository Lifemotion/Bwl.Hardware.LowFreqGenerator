Public Class App
    Private _gen As New GeneratorInterface
    Private _seq(127) As Double
    Private _view As Bitmap
    Private _graph As Graphics
    Private Sub bPlay_Click(sender As Object, e As EventArgs) Handles bPlayOnce.Click
        Try
            _gen.SendSequence(_seq)
            _gen.PlayOnce()
        Catch ex As Exception
            _logger.AddError(ex.Message)
        End Try
    End Sub

    Private Sub bGenerate_Click(sender As Object, e As EventArgs) Handles bGenerate.Click
        Dim level = Val(tbLevel.Text) / 100
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

        pbSignalView.Image = _view
        pbSignalView.Refresh()
    End Sub

    Private Sub App_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _view = New Bitmap(pbSignalView.Width, pbSignalView.Height)
        '_view = New Bitmap(_seq.Length, 260)
        _graph = Graphics.FromImage(_view)
    End Sub

    Private Sub bRepeat_Click(sender As Object, e As EventArgs) Handles bRepeat.Click
        Try
            _gen.SendSequence(_seq)
            _gen.Repeat()
        Catch ex As Exception
            _logger.AddError(ex.Message)
        End Try
    End Sub

    Private Sub bStop_Click(sender As Object, e As EventArgs) Handles bStop.Click
        Try
            _gen.StopRepeat()
        Catch ex As Exception
            _logger.AddError(ex.Message)
        End Try
    End Sub
End Class
