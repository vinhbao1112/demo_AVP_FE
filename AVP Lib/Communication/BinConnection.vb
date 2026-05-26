Imports System.Net.Sockets
Imports System.Text
Imports System.Threading


Namespace Communication
    Public Class BinConnection
        Inherits TerminalServerConnection

#Region "Pubic Method"

        ''' <name> Nguyen Tan Dung </name>
        ''' <date> 2011-12-22 </date>
        ''' <summary>
        ''' Send a message
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Function SendBytes(ByVal msg As Byte()) As Boolean
            AVPLib.Log.terminalServerLogger.Info("Enter SendMessage")

            Dim stream As NetworkStream = Nothing
            Try
                If Open() Then
                    stream = m_TcpClient.GetStream()
                    stream.Write(msg, 0, msg.Length)
                    AVPLib.Log.terminalServerLogger.Info("Leave SendMessage")
                    Return True
                End If
            Catch ex As Exception
                m_CurrentState = States.Disconnected
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave SendMessage")
            Return False
        End Function

        ''' <name> Nguyen Tan Dung </name>
        ''' <date> 2011-12-22 </date>
        ''' <summary>
        ''' Receive a message
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Function ReceiveBytes(ByVal Timeout As Integer) As Byte()
            AVPLib.Log.terminalServerLogger.Info("Enter ReceiveMessage")
            Try
                If Open() Then
                    Dim start As Int64 = Environment.TickCount
                    Dim current As Int64 = start
                    Dim blnIsMessageEmpty As Boolean = True
                    Dim msgMessage As Message = Nothing
                    While (current - start) <= Timeout
                        SyncLock m_MessageQueue.SyncRoot
                            If (m_MessageQueue.Count > 0) Then
                                msgMessage = CType(m_MessageQueue.Dequeue(), Message)
                                blnIsMessageEmpty = False
                            End If
                        End SyncLock
                        If blnIsMessageEmpty Then
                            Thread.Sleep(50)
                        Else
                            Return msgMessage.Bytes
                        End If
                        current = Environment.TickCount
                    End While
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.terminalServerLogger.Info("Leave ReceiveMessage")
            Return Nothing
        End Function

#End Region

#Region "Private methods"
        ''' <name> Nguyen Tan Dung </name>
        ''' <date> 2011-12-22 </date>
        ''' <summary>
        ''' Handle received buffer
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub OnDataReceived(ByVal arrBuffer As Byte(), ByVal nLength As Integer)
            AVPLib.Log.terminalServerLogger.Info("Enter OnDataReceived")
            Try
                Dim msgMessage As New Message()
                msgMessage.Bytes = New Byte(nLength - 1) {}
                Array.Copy(arrBuffer, 0, msgMessage.Bytes, 0, nLength)
                msgMessage.Time = Environment.TickCount
                SyncLock m_MessageQueue.SyncRoot
                    m_MessageQueue.Enqueue(msgMessage)
                End SyncLock
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave OnDataReceived")
        End Sub

#End Region
    End Class
End Namespace
