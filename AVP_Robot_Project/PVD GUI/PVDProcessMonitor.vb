Imports AVP_Robot_Project.ConstantAndEnum
Public Class PVDProcessMonitor
#Region "Properties"
#End Region
#Region "Protected method"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbRecipe As New StatusTextBox(Me.txtRecipe)
            Dim stbWaferID As New StatusTextBox(Me.txtWaferID)
            Dim stbProcessTime As New StatusTextBox(Me.txtProcessTime)
            Dim stbProcessStep As New StatusTextBox(Me.txtProcessStep)
            Dim stbStepTime As New StatusTextBox(Me.txtStepTime)
            Dim stbStatus As New StatusTextBox(Me.txtStatus)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbRecipe)
            m_stoStatusObject.AddChild(stbWaferID)
            m_stoStatusObject.AddChild(stbProcessStep)
            m_stoStatusObject.AddChild(stbProcessTime)
            m_stoStatusObject.AddChild(stbStepTime)
            m_stoStatusObject.AddChild(stbStatus)

            ' Init
            '

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Events – Buttons – Forms…"
    
#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        txtStatus.Text = AVPLib.ConstEnum.EnumChamberState.UNKNOWN.ToString()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
