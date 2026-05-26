Imports System.ComponentModel
Imports System.ComponentModel.Design

Public Class BinaryStatusControl
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
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-27</date>
    ''' </author>
    ''' <summary>
    ''' Set of get display status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Property Status() As DisplayStatus
        Get
            Return m_enmDisplayStatus
        End Get
        Set(ByVal value As DisplayStatus)
            Try
                Dim isChange As Boolean = (m_enmDisplayStatus <> value)
                m_enmDisplayStatus = value
                If (isChange) Then
                    Me.Refresh()
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

        End Set
    End Property
#End Region

#Region "Constructor & Destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-27</date>
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
