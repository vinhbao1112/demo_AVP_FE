Imports AVP_Robot_Project.ConstantAndEnum
Public Class usrAligner
    Private m_blnIsOnline As Boolean = False
#Region "Properties"
    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            usrOperations.IsOnline = value
        End Set
    End Property
#End Region

#Region "Private methods"
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-09-22</date>
    ''' </author>
    ''' <summary>
    ''' Active Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ActiveForm()
        Try
            Me.usrWaferInfo.Enabled = True
            Me.usrAlignmentInfo.Enabled = True
            Me.usrOperations.Enabled = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-09-22</date>
    ''' </author>
    ''' <summary>
    ''' Inactive Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InactiveForm()
        Try
            Me.usrWaferInfo.Enabled = False
            Me.usrAlignmentInfo.Enabled = False
            Me.usrOperations.Enabled = False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-09-22</date>
    ''' </author>
    ''' <summary>
    ''' Check Permission
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckPermission()
        If AVPLib.ContainerData.Permission(AVPLib.ConstEnum.PERMISSION_001) Then
            ActiveForm()
        Else
            InactiveForm()
        End If
    End Sub
#Region "Protected method"
    ''' <author>
    '''    	<name> Tran Ngoc Khiet</name>
    '''    	<date> 2009-07-14</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(usrOperations.Status)
            m_stoStatusObject.AddChild(usrWaferInfo.Status)
            m_stoStatusObject.AddChild(usrAlignmentInfo.Status)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region
End Class
