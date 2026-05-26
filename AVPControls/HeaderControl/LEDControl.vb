Public Class LEDControl
    Inherits AVPStatusControlBase

    Private m_blnSmall As Boolean = False

    Protected Overrides ReadOnly Property DefaultSize() As System.Drawing.Size
        Get
            If m_blnSmall Then
                Return New Size(12, 12)
            Else
                Return New Size(15, 15)
            End If
        End Get
    End Property

    Protected Overrides Function GenerateControlImage() As System.Drawing.Bitmap

        If m_blnSmall Then
            If Me.Status = AVPControls.AVPDataLib.DisplayStatus.On Then
                Return My.Resources.Resources.LEDGreenSmall
            ElseIf Me.Status = AVPControls.AVPDataLib.DisplayStatus.Error Then
                Return My.Resources.Resources.LEDRedSmall
            Else
                Return My.Resources.Resources.LEDGreySmall
            End If

        Else
            If Me.Status = AVPControls.AVPDataLib.DisplayStatus.On Then
                Return My.Resources.Resources.LEDGreen
            ElseIf Me.Status = AVPControls.AVPDataLib.DisplayStatus.Error Then
                Return My.Resources.Resources.LEDRed
            Else
                Return My.Resources.Resources.LEDGrey
            End If
        End If
    End Function

    Public Sub New()
        Me.IsInitialized = True
        Me.AlphaValueForRegion = 0
    End Sub


    ''' <author>Dung Pham</author>
    ''' <date>2021-03-02</date>
    ''' <summary>
    ''' Gets or sets a value indicating whether view led to small
    ''' </summary>
    ''' <value></value>
    <System.ComponentModel.DefaultValue(False)> _
    Public Property IsSmall() As Boolean
        Get
            Return m_blnSmall
        End Get
        Set(ByVal value As Boolean)
            If m_blnSmall <> value Then
                m_blnSmall = value

                Me.Size = New System.Drawing.Size(12, 12)
                Me.UpdateView()
            End If
        End Set
    End Property
End Class
