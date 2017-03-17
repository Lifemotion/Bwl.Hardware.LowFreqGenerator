Imports Bwl.Hardware.SimplSerial

Public Class GeneratorInterface
    Public ReadOnly Property Board As New SimplSerialConnector("LowFreqGen", 9600)

    Public Sub New()
        AddHandler Board.DeviceIsConnectedTick, AddressOf DeviceIsConnectedTick
    End Sub

    Private Sub DeviceIsConnectedTick()

    End Sub

    Public Sub SendSequence(sequence As Double())
        Dim bytes As New List(Of Byte)
        For Each sample In sequence
            sample = sample * 256
            If sample < 1 Then sample = 1
            If sample > 255 Then sample = 255
            bytes.Add(sample)
        Next
        bytes.Add(0)

        If Board.SS.Request(0, 45, bytes.ToArray).ResponseState <> ResponseState.ok Then Throw New Exception("SendSequence fail")
    End Sub

    Public Sub PlayOnce()
        If Board.SS.Request(0, 55, {0}).ResponseState <> ResponseState.ok Then Throw New Exception("PlayOnce fail")
    End Sub

    Public Sub Repeat()
        If Board.SS.Request(0, 55, {0}).ResponseState <> ResponseState.ok Then Throw New Exception("PlayOnce fail")
    End Sub

    Public Sub StopRepeat()
        If Board.SS.Request(0, 55, {0}).ResponseState <> ResponseState.ok Then Throw New Exception("PlayOnce fail")
    End Sub
End Class
