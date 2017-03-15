Imports Bwl.Hardware.SimplSerial

Public Class GeneratorInterface
    Public ReadOnly Property SS As New SimplSerialBus

    Public Sub Open(port As String)
        SS.SerialDevice.DeviceAddress = port
        SS.SerialDevice.DeviceSpeed = 9600
        SS.Connect()
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

        If SS.Request(0, 45, bytes.ToArray).ResponseState <> ResponseState.ok Then Throw New Exception("SendSequence fail")
    End Sub

    Public Sub PlayOnce()
        If SS.Request(0, 55, {0}).ResponseState <> ResponseState.ok Then Throw New Exception("PlayOnce fail")
    End Sub
End Class
