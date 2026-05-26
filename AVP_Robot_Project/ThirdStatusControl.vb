Imports System.ComponentModel
Imports System.ComponentModel.Design

Public Class ThirdStatusControl
#Region "Class Constants & Variables"
    Public Enum DisplayStatus
        [Off] = 0
        [On] = 1
        [Unknown] = 2
    End Enum

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
        m_enmDisplayStatus = DisplayStatus.Off
    End Sub
#End Region

End Class
