Imports System.ComponentModel
Imports System.ComponentModel.Design

Public Class FourStatusControl
#Region "Class Constants & Variables"
    Public Enum DisplayStatus
        [Default] = 0 ''
        [Home] = 1 ''on
        [Moving] = 2
        [Error] = 3
    End Enum

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2014-12-29</date>
    ''' <author>
    ''' <summary>
    ''' Containning event data of status control
    ''' </summary>
    Public Class StatusEventArgs
        Inherits EventArgs
        Private m_preStatus As DisplayStatus
        Private m_curStatus As DisplayStatus

        Public ReadOnly Property PreStatus() As DisplayStatus
            Get
                Return m_preStatus
            End Get
        End Property

        Public ReadOnly Property Status() As DisplayStatus
            Get
                Return m_curStatus
            End Get
        End Property

        Public Sub New(ByVal preStatus As DisplayStatus, ByVal currentStatus As DisplayStatus)
            m_preStatus = preStatus
            m_curStatus = currentStatus
        End Sub
    End Class

    Public Event StatusChanged(ByVal sender As Object, ByVal e As StatusEventArgs)
    Private m_enmDisplayStatus As DisplayStatus
#End Region

#Region "Public Properties"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-06</date>
    ''' </author>
    ''' <summary>
    ''' Set of get display status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Status() As DisplayStatus
        Get
            Return m_enmDisplayStatus
        End Get
        Set(ByVal value As DisplayStatus)
            Try
                m_enmDisplayStatus = value
                Me.Refresh()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

        End Set
    End Property
#End Region

#Region "Constructor & Destructor"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-06</date>
    ''' </author>
    ''' <summary>
    ''' Contructor
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        m_enmDisplayStatus = DisplayStatus.Default
    End Sub
#End Region

End Class
