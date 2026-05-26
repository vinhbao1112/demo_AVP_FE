Imports AVPLib
Imports AVPLib.ConstEnum
Public Class CycleATMScreen

#Region "Private methods"
    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2009-10-05</date>
    ''' </author>
    ''' <summary>
    ''' Active Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ActiveForm()
        Try
            Me.CycleATMPanel.Enabled = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-10-05</date>
    ''' </author>
    ''' <summary>
    ''' Inactive Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InactiveForm()
        Try
            Me.CycleATMPanel.Enabled = False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-10-05</date>
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
#End Region

#Region "Protected method"
    ''' <author>
    '''    	<name> Tran Cao Dua</name>
    '''    	<date> 2017-10-11</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(Me.CycleATMPanel.Status)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region
End Class
