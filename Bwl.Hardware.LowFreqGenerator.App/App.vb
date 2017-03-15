Public Class App
    Private _gen As New GeneratorInterface

    Private Sub bPlay_Click(sender As Object, e As EventArgs) Handles bPlay.Click
        Dim seq(107) As Double
        For i = 0 To seq.Length - 1
            seq(i) = Math.Sin(i / seq.Length * Math.PI * 2) * 0.5 + 0.5
        Next
        _gen.SendSequence(seq)
        _gen.PlayOnce()
    End Sub

    Private Sub bOpen_Click(sender As Object, e As EventArgs) Handles bOpen.Click
        _gen.Open("COM11")

    End Sub
End Class
