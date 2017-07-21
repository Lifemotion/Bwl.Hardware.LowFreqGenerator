Imports Bwl.Hardware.Serial
Imports Bwl.Hardware.SimplSerial

Public Enum SimplSerialConnectStatus
    NotFound
    Searching
    Connected
End Enum

Public Class SimplSerialConnector
    Public ReadOnly Property BoardNameToFind As String = ""
    Public ReadOnly Property BoardPortSpeed As Integer = 9600
    Public ReadOnly Property BoardConnection As SimplSerialConnectStatus
    Public ReadOnly Property BoardInfo As String = ""

    Public FindDeviceIntervalSeconds As Integer = 10

    Public Event DeviceIsConnectedTick()
    Protected Shared _portSync As New Object
    Protected _serial As New FastSerialPort
    Protected _ss As New SimplSerialBus(_serial)

    Public ReadOnly Property SS As SimplSerialBus
        Get
            Return _ss
        End Get
    End Property

    Public ReadOnly Property Connected As Boolean
        Get
            Return BoardConnection = SimplSerialConnectStatus.connected
        End Get
    End Property

    Public Sub New(sserialNameToFind As String, portSpeed As Integer)
        _BoardNameToFind = sserialNameToFind
        _BoardPortSpeed = portSpeed

        Dim thread As New Threading.Thread(AddressOf WorkThread) With {
            .Name = "SimplSerialConnector " + sserialNameToFind,
            .IsBackground = True
        }
        thread.Start()
    End Sub

    Private Function FindPort() As String
        SyncLock _portSync
            Dim devices = System.IO.Ports.SerialPort.GetPortNames
            For Each port In devices
                If port.ToLower.Contains("com") Or port.ToLower.Contains("ttyusb") Then
                    Dim testSS As New SimplSerialBus(port)
                    Dim result = ""
                    testSS.SerialDevice.DeviceSpeed = BoardPortSpeed
                    Try
                        testSS.Connect()
                        Dim info = testSS.RequestDeviceInfo(0)
                        If info.DeviceName.Contains(BoardNameToFind) Then result = port
                    Catch ex As Exception
                    End Try
                    Try
                        testSS.Disconnect()
                        testSS.SerialDevice.Disconnect()
                    Catch ex As Exception
                    End Try
                    If result > "" Then Return result
                End If
            Next
            Return ""
        End SyncLock
    End Function

    Private Sub WorkThread()
        Do
            Try
                If _ss.IsConnected = False Then
                    _BoardInfo = ""
                    _BoardConnection = SimplSerialConnectStatus.Searching

                    _serial.DeviceAddress = FindPort()
                    If _serial.DeviceAddress = "" Then
                        _BoardConnection = SimplSerialConnectStatus.notFound
                        Threading.Thread.Sleep(FindDeviceIntervalSeconds * 1000)
                    Else
                        _serial.DeviceSpeed = BoardPortSpeed
                        _ss.Connect()
                        Dim info = _ss.RequestDeviceInfo(0)
                        _BoardInfo = info.DeviceName
                        _BoardConnection = SimplSerialConnectStatus.Connected

                    End If
                Else
                    _BoardConnection = SimplSerialConnectStatus.Connected
                    RaiseEvent DeviceIsConnectedTick()
                End If
                Threading.Thread.Sleep(100)
            Catch ex As Exception
            End Try
        Loop
    End Sub
End Class
