Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum

Public Class AVPTextBox
    Inherits TextBox


    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim drawBrush As SolidBrush = New SolidBrush(ForeColor)

        e.Graphics.DrawString(Text, Font, Brushes.Black, 0.0F, 0.0F)
    End Sub

    
End Class
