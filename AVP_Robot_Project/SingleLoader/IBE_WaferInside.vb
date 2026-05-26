Public Class IBE_WaferInside
    Private m_WaferID As String = String.Empty
    Public Property WaferID() As String
        Get
            Return m_WaferID
        End Get
        Set(ByVal value As String)
            m_WaferID = value
            lblWaferID.Text = value
            Me.Refresh()
        End Set
    End Property

    Private m_WaferStatus As SL_CustomButton.DisplayStatus = SL_CustomButton.DisplayStatus.Off
    Public Property Status() As SL_CustomButton.DisplayStatus
        Get
            Return m_WaferStatus
        End Get
        Set(ByVal value As SL_CustomButton.DisplayStatus)
            m_WaferStatus = value
            Me.Wafer.Status = value
            If value = SL_CustomButton.DisplayStatus.Error Then
                Me.lblWaferID.Image = AVP_Robot_Project.My.Resources.Resources.WaferMass_Red
                Me.lblWaferID.ForeColor = Color.White
            ElseIf value = SL_CustomButton.DisplayStatus.Off Then
                Me.lblWaferID.Image = AVP_Robot_Project.My.Resources.Resources.WaferMass_Green
                Me.lblWaferID.ForeColor = Color.White
            ElseIf value = SL_CustomButton.DisplayStatus.On Then
                Me.lblWaferID.Image = AVP_Robot_Project.My.Resources.Resources.WaferMass_Blue
                Me.lblWaferID.ForeColor = Color.White
            Else
                Me.lblWaferID.Image = AVP_Robot_Project.My.Resources.Resources.WaferMass_Yellow
                Me.lblWaferID.ForeColor = Color.Black
            End If
            Me.Refresh()
        End Set
    End Property

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.lblWaferID.Location = New Point(23, 9)
        ' Add any initialization after the InitializeComponent() call.

    End Sub

   
End Class
