Imports Bwl.Hardware.SimplSerial

Public Class AccelerometerDriver
    Private _ss As SimplSerialBus = Nothing
    Public Const Scale100g As Byte = 0
    Public Const Scale200g As Byte = 1
    Public Const Scale400g As Byte = 2
    Private _mux As Single = 0.0

    Sub New(sserial As SimplSerialBus)
        Me._ss = sserial
        _mux = 100.0 / 32768.0
    End Sub

    Sub SetScale(scale As Byte)
        Dim response = _ss.Request(0, 10, {scale})
        If response.ResponseState <> ResponseState.ok Then
            Throw New Exception("Accelerometer scale initialization failed")
        End If
        If (scale = 1) Then
            _mux = 200.0 / 32768.0
        ElseIf (scale = 2) Then
            _mux = 400.0 / 32768.0
        Else
            _mux = 100.0 / 32768.0
        End If
    End Sub

    Function GetData() As Byte()
        Try
            Dim response = _ss.Request(New SSRequest(0, 10, {}), 20)
            Return response.Data

        Catch ex As Exception

        End Try
        Dim bytes(100) As Byte
        Return bytes

    End Function

End Class
