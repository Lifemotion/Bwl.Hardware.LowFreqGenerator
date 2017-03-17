Imports Bwl.Hardware.SimplSerial

Public Class GeneratorInterface
    Public ReadOnly Property Board As New SimplSerialConnector("LowFreq Gen", 9600)

    Public Sub New()
        AddHandler Board.DeviceIsConnectedTick, AddressOf DeviceIsConnectedTick
    End Sub

    Private Sub DeviceIsConnectedTick()

    End Sub

    Public Sub SendSequence(sequence As Double(), sequenceTimeMs As Double)
        Dim bytes As New List(Of Byte)
        Dim samplePauseMks = CInt((sequenceTimeMs * 1000 / sequence.Length))
        Dim spmh As Byte = (samplePauseMks >> 16) Mod 255
        Dim spmm As Byte = (samplePauseMks >> 8) Mod 255
        Dim spml As Byte = (samplePauseMks) Mod 255
        bytes.AddRange({spmh, spmm, spml, 0, 0, 0, 0, 0})

        For Each sample In sequence
            sample = Math.Round(sample * 256)
            If sample < 0 Then sample = 0
            If sample > 255 Then sample = 255
            bytes.Add(sample)
        Next

        If Board.SS.Request(0, 45, bytes.ToArray).ResponseState <> ResponseState.ok Then Throw New Exception("SendSequence fail")
    End Sub

    Public Sub PlayOnce()
        If Board.SS.Request(0, 55, {0}).ResponseState <> ResponseState.ok Then Throw New Exception("PlayOnce fail")
    End Sub

    Public Sub Repeat()
        If Board.SS.Request(0, 65, {0}).ResponseState <> ResponseState.ok Then Throw New Exception("Repeat fail")
    End Sub

    Public Sub StopRepeat()
        If Board.SS.Request(0, 66, {0}).ResponseState <> ResponseState.ok Then Throw New Exception("StopRepeat fail")
    End Sub
End Class
