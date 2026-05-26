Imports System.ComponentModel

Public Class PVD4TurboPumpControl
    Protected m_isWaterPumpInstalled As Boolean = True

#Region "Properties"
    <DefaultValue(GetType(Boolean), "True")> _
    Public Property IsWaterPumpInstalled() As Boolean
        Get
            Return m_isWaterPumpInstalled
        End Get
        Set(ByVal value As Boolean)
            If m_isWaterPumpInstalled <> value Then
                m_isWaterPumpInstalled = value
                UpdateView()
            End If
        End Set
    End Property
#End Region

#Region "Methods"
    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-08-17 </date>
    ''' </author>
    ''' <summary>
    ''' Get image for draw image control
    ''' </summary>
    Protected Overrides Function GenerateControlImage() As System.Drawing.Bitmap
        If m_isWaterPumpInstalled Then
            Return New Bitmap(My.Resources.Resources.Corona_Turbo_WithWaterPump)
        Else
            Return New Bitmap(My.Resources.Resources.Corona_Turbo)
        End If
    End Function

#End Region
End Class
