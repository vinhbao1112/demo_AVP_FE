Public Class SL_ReadbackPanel

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
            Dim stbBeamVoltage As New SL_StatusTextBox(Me.txtBeamVoltage)
            Dim stbBeamCurrent As New SL_StatusTextBox(Me.txtBeamCurrent)
            Dim stbSuppressorVoltage As New SL_StatusTextBox(Me.txtSuppressorVoltage)
            Dim stbForwardRFPower As New SL_StatusTextBox(Me.txtForwardRFPower)
            Dim stbPBNCurrent As New SL_StatusTextBox(Me.txtPBNCurrent)
            Dim stbPBNBody As New SL_StatusTextBox(Me.txtPBNBody)
            Dim stbCryoTemp As New SL_StatusTextBox(Me.txtCryoTemp)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbBeamVoltage)
            m_stoStatusObject.AddChild(stbBeamCurrent)
            m_stoStatusObject.AddChild(stbSuppressorVoltage)
            m_stoStatusObject.AddChild(stbForwardRFPower)
            m_stoStatusObject.AddChild(stbPBNCurrent)
            m_stoStatusObject.AddChild(stbPBNBody)
            m_stoStatusObject.AddChild(stbCryoTemp)

            txtBeamVoltage.ParentStatusObj = m_stoStatusObject
            txtBeamCurrent.ParentStatusObj = m_stoStatusObject
            txtSuppressorVoltage.ParentStatusObj = m_stoStatusObject
            txtForwardRFPower.ParentStatusObj = m_stoStatusObject
            txtPBNCurrent.ParentStatusObj = m_stoStatusObject
            txtPBNBody.ParentStatusObj = m_stoStatusObject
            txtCryoTemp.ParentStatusObj = m_stoStatusObject

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.HeaderVisible = True
        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
