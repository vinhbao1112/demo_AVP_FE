Namespace Driver
    Public Class KepwareIGDriver
        Inherits DriverObject
        Implements IIGDriver

        Private m_GroupName As String = "TM.TMC"
        Public Property KepwareGroup() As String
            Get
                Return m_GroupName
            End Get
            Set(ByVal value As String)
                m_GroupName = value
            End Set
        End Property

        Public Sub New(ByVal sDriverName As String)
            MyBase.new(sDriverName)
            XPATH_KepServerTag = XPATH_KepServerTag & Me.DriverName
            XPATH_KepServerReadbackTag = XPATH_KepServerReadbackTag & Me.DriverName
            DriverUtility.ReadKepwareConfig(XPATH_KepServerTag)
            DriverUtility.RegisterKepwareReadback(m_GroupName, XPATH_KepServerReadbackTag)
        End Sub

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2017-07-05 </date>
        ''' </author>
        ''' <summary>
        ''' Switch IG Filament 1
        ''' </summary>
        Public Function SwitchIGFilament1() As Boolean Implements IIGDriver.SwitchIGFilament1
            Return True
        End Function
        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2017-07-05 </date>
        ''' </author>
        ''' <summary>
        ''' Switch IG Filament 2
        ''' </summary>
        Public Function SwitchIGFilament2() As Boolean Implements IIGDriver.SwitchIGFilament2
            Return True
        End Function

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Ion gauge pressure
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property IGPressure() As Single Implements IIGDriver.IGPressure
            Get

            End Get
        End Property
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Turn IG on
        ''' </summary>
        ''' <remarks></remarks>
        Public Function TurnOnIG() As Boolean Implements IIGDriver.TurnOnIG
            If (Utils.WriteCommandKepServer(Me.m_sDriverName, True) = String.Empty) Then
                Return True
            Else
                Return False
            End If
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Turn IG off
        ''' </summary>
        ''' <remarks></remarks>
        Public Function TurnOffIG() As Boolean Implements IIGDriver.TurnOffIG
            If (Utils.WriteCommandKepServer(Me.m_sDriverName, False) = String.Empty) Then
                Return True
            Else
                Return False
            End If
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Turn IG Degas On
        ''' </summary>
        ''' <remarks></remarks>
        Public Function TurnOnIGDegas() As Boolean Implements IIGDriver.TurnOnIGDegas
            ''Turn RO Off then RO On if mode is Kepware, only turn on IG Degas if mode is RSTi
            TurnOffIGDegas()

            If (Utils.WriteCommandKepServer(Me.m_sDriverName.Replace("Ion", "IgDegas"), True) = String.Empty) Then
                Return True
            Else
                Return False
            End If
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Turn IG degas off
        ''' </summary>
        ''' <remarks></remarks>
        Public Function TurnOffIGDegas() As Boolean Implements IIGDriver.TurnOffIGDegas
            If (Utils.WriteCommandKepServer(Me.m_sDriverName.Replace("Ion", "IgDegas"), False) = String.Empty) Then
                Return True
            Else
                Return False
            End If
        End Function
    End Class
End Namespace