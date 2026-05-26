

''' <author>Hai Tran</author>
''' <date>2018-04-13</date>
''' <summary>
''' Mechanical pump control.
''' </summary>
Public Class MechanicalPumpControl

#Region "Constructors"

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-13</date>
    ''' <summary>
    ''' Mechanical pump control.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        RequireInitializeForUpdateView = False

    End Sub

#End Region

#Region "Methods"

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-13</date>
    ''' <summary>
    ''' Returns image of control.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function GenerateControlImage() As System.Drawing.Bitmap
        Dim img As Bitmap = Nothing
        Try
            If Me.Status = AVPControls.AVPDataLib.DisplayStatus.On Then
                img = My.Resources.Resources.MechanicalPump_On
            Else
                img = My.Resources.Resources.MechanicalPump_Off
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return img
    End Function

#End Region

End Class
