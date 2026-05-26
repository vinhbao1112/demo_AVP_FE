Imports System.ComponentModel

Public Class RobotConfigPanel
    Public Event ConfigRobot_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    Private m_isEnabledEdit As Boolean = False

    <DefaultValue(False)> _
    Public ReadOnly Property IsEnabledEdit() As Boolean
        Get
            Return m_isEnabledEdit
        End Get
    End Property

    Protected Overrides ReadOnly Property DefaultSize() As System.Drawing.Size
        Get
            Return New Size(505, 550)
        End Get
    End Property

    ''' <author>
    '''     <name>Tinh Le</name>
    '''     <date> 2020-04-23 </date>
    ''' </author>
    ''' <summary>
    '''  EnableEdit
    ''' </summary>
    Public Sub EnableEdit(ByVal enable As Boolean)
        Try
            m_isEnabledEdit = enable

        Catch ex As Exception

        End Try
    End Sub

    ''' <author>
    '''     <name>Tinh Le</name>
    '''     <date> 2020-04-23 </date>
    ''' </author>
    ''' <summary>
    '''  RobotConfigClick
    ''' </summary>
    Private Sub RobotConfigClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R_STN1.Click, Z_STN9.Click, Z_STN8.Click, Z_STN7.Click, Z_STN6.Click, Z_STN5.Click, Z_STN4.Click, Z_STN3.Click, Z_STN2.Click, Z_STN10.Click, Z_STN1.Click, T_STN9.Click, T_STN8.Click, T_STN7.Click, T_STN6.Click, T_STN5.Click, T_STN4.Click, T_STN3.Click, T_STN2.Click, T_STN10.Click, T_STN1.Click, R_STN9.Click, R_STN8.Click, R_STN7.Click, R_STN6.Click, R_STN5.Click, R_STN4.Click, R_STN3.Click, R_STN2.Click, R_STN10.Click, PITCH_STN9.Click, PITCH_STN8.Click, PITCH_STN7.Click, PITCH_STN6.Click, PITCH_STN5.Click, PITCH_STN4.Click, PITCH_STN3.Click, PITCH_STN2.Click, PITCH_STN10.Click, PITCH_STN1.Click, LOWER_STN9.Click, LOWER_STN8.Click, LOWER_STN7.Click, LOWER_STN6.Click, LOWER_STN5.Click, LOWER_STN4.Click, LOWER_STN3.Click, LOWER_STN2.Click, LOWER_STN10.Click, LOWER_STN1.Click, Z_WVEL.Click, Z_WACC.Click, Z_PVEL.Click, Z_PACC.Click, Z_HVEL.Click, Z_HACC.Click, T_WVEL.Click, T_WACC.Click, T_PVEL.Click, T_PACC.Click, T_HVEL.Click, T_HACC.Click, R_WVEL.Click, R_WACC.Click, R_PVEL.Click, R_PACC.Click, R_HVEL.Click, R_HACC.Click
        If IsEnabledEdit Then
            RaiseEvent ConfigRobot_Click(sender, e)
        End If
    End Sub
End Class
