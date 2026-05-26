Namespace Communication.TerminalDriver
    Public Class TransactionManager
#Region "Class Constants & Variables"
        Private Shared m_htbTransactionList As Hashtable
        Private Shared m_MessagesLock As New Object
        Public Shared Event ReconnectStatus As EventHandler(Of ReconnectEventArgs)
#End Region

#Region "Properties"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current TransactionList
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property TransactionList() As Hashtable
            Get
                Return m_htbTransactionList
            End Get
            Set(ByVal value As Hashtable)
                m_htbTransactionList = value
            End Set
        End Property
#End Region

#Region "Public method"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-10</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Run Transaction manager
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <remarks></remarks>
        Public Shared Function Run(ByVal Message As String, _
                Optional ByVal bOverrideTimeOut As Boolean = False, _
                Optional ByVal newTimeOut As Integer = 2000) As Boolean

            AVPLib.Log.terminalServerLogger.Debug("Enter Run")

            Dim blnResult As Boolean = False
            Try
                Dim intPos As Integer = Message.IndexOf(".")
                Dim strEquipementName As String = Message.Substring(0, intPos)
                Dim objValue As Object
                SyncLock m_MessagesLock
                    objValue = m_htbTransactionList.Item(strEquipementName)
                End SyncLock
                If (objValue IsNot Nothing) Then
                    Dim tstTransaction As Transaction = CType(objValue, Transaction)
                    blnResult = tstTransaction.Run(Message, bOverrideTimeOut, newTimeOut)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Debug("Leave Run")
            Return blnResult
        End Function
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-13</Date>
        '''		<Description>Implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Create transaction list
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub CreateTransactionList()
            AVPLib.Log.terminalServerLogger.Info("Enter CreateTransactionList")

            Try
                m_htbTransactionList = New Hashtable
                'Not check condition installed
                Dim strRobotName As String = ConstEnum.Equipments.Robot.ToString()
                Dim tranRobot As New RobotTransaction()
                tranRobot.Timeout = ContainerData.GetTimeout(strRobotName)
                AddHandler tranRobot.ReconnectStatus, AddressOf ReconnectHandle
                m_htbTransactionList.Add(strRobotName, tranRobot)

                If RobotConfigurationValues.ALINER_VISIBLE Then
                    Dim strAlignerName As String = ConstEnum.Equipments.Aligner.ToString()
                    Dim tranAligner As New AlignerTransaction()
                    tranAligner.Timeout = ContainerData.GetTimeout(strAlignerName)
                    AddHandler tranAligner.ReconnectStatus, AddressOf ReconnectHandle
                    m_htbTransactionList.Add(strAlignerName, tranAligner)
                End If

                If RobotConfigurationValues.TMCRYO_VISIBLE Then
                    Dim strTMCryo As String = ConstEnum.Equipments.TMPumpPackage.ToString()
                    Dim tranTMCryo As New CryoTransaction
                    tranTMCryo.TransactionTimeoutLimitProperty = ConstEnum.CRYO_TRANSACTION_TIMEOUT_LIMIT
                    tranTMCryo.Timeout = ContainerData.GetTimeout(strTMCryo)
                    AddHandler tranTMCryo.ReconnectStatus, AddressOf ReconnectHandle
                    m_htbTransactionList.Add(strTMCryo, tranTMCryo)
                End If

                If RobotConfigurationValues.TMWATERPUM_VISIBLE = True Then
                    Dim strTMWaterPump As String = ConstEnum.Equipments.TMWaterPump.ToString()
                    Dim tranTMWaterPump As New WaterPumpTransaction
                    tranTMWaterPump.Timeout = ContainerData.GetTimeout(strTMWaterPump)
                    AddHandler tranTMWaterPump.ReconnectStatus, AddressOf ReconnectHandle
                    m_htbTransactionList.Add(strTMWaterPump, tranTMWaterPump)
                End If

                Dim strLLAElevator As String = ConstEnum.Equipments.LLAElevator.ToString()
                Dim tranLLAElevator As New ElevatorTransaction
                tranLLAElevator.Timeout = ContainerData.GetTimeout(strLLAElevator)
                AddHandler tranLLAElevator.ReconnectStatus, AddressOf ReconnectHandle
                m_htbTransactionList.Add(strLLAElevator, tranLLAElevator)

                If RobotConfigurationValues.LLA_CRYO_VISIBLE Then
                    Dim strLLACryo As String = ConstEnum.Equipments.LLAPumpPackage.ToString()
                    Dim tranLLACryo As New CryoTransaction
                    tranLLACryo.TransactionTimeoutLimitProperty = ConstEnum.CRYO_TRANSACTION_TIMEOUT_LIMIT
                    tranLLACryo.Timeout = ContainerData.GetTimeout(strLLACryo)
                    AddHandler tranLLACryo.ReconnectStatus, AddressOf ReconnectHandle
                    m_htbTransactionList.Add(strLLACryo, tranLLACryo)
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave CreateTransactionList")
        End Sub

        Public Shared Sub Dispose()
            Try
                m_htbTransactionList.Clear()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        Private Shared Sub ReconnectHandle(ByVal obj As Object, ByVal e As ReconnectEventArgs)
            RaiseEvent ReconnectStatus(obj, e)
        End Sub
#End Region
    End Class

End Namespace
