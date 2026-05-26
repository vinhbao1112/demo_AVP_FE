Imports avplib
Imports AVPLib.ConstEnum
Imports AVP_Robot_Project.ConstantAndEnum
Public Class AlignerWaferControl
    Private imgWafer As Image = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Complete
#Region "Protected Methods"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-27</date>
    ''' </author>
    ''' <summary>
    ''' Paint circle to screen
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Try
            Dim ColorWaferID As Color
            If DesignMode Then
                e.Graphics.DrawEllipse(Pens.Black, 0, 0, Me.Width - 1, Me.Height - 1)
                Exit Try
            End If
            Dim cb As AVPLib.DataManagerment.Aligner = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Aligner.ToString())
            If cb.GetWaferInfo() IsNot Nothing Then
                If Utils.Check_WaferID_Has_PausedJob(cb.GetWaferInfo().WaferID) AndAlso Not (Me.Parent.Name = CASSETTESPANEL_STR) Then
                    If cb.GetWaferInfo().WaferStatus = ConstEnum.enumWaferStatus.eWaferComplete Then
                        Me.imgWafer = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Complete_QM
                        ColorWaferID = Color.Black
                    ElseIf cb.GetWaferInfo().WaferStatus = ConstEnum.enumWaferStatus.eWaferNew Then
                        Me.imgWafer = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Unprocess_QM
                        ColorWaferID = Color.White
                    ElseIf cb.GetWaferInfo().WaferStatus = ConstEnum.enumWaferStatus.eWaferExposed Then
                        Me.imgWafer = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Partial_QM
                        ColorWaferID = Color.Black
                    ElseIf cb.GetWaferInfo().WaferStatus = ConstEnum.enumWaferStatus.eWaferError Then
                        Me.imgWafer = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Error_QM
                        ColorWaferID = Color.White
                    End If
                Else
                    If cb.GetWaferInfo().WaferStatus = ConstEnum.enumWaferStatus.eWaferComplete Then
                        Me.imgWafer = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Complete
                        ColorWaferID = Color.Black
                    ElseIf cb.GetWaferInfo().WaferStatus = ConstEnum.enumWaferStatus.eWaferNew Then
                        Me.imgWafer = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Unprocess
                        ColorWaferID = Color.White
                    ElseIf cb.GetWaferInfo().WaferStatus = ConstEnum.enumWaferStatus.eWaferExposed Then
                        Me.imgWafer = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Partial
                        ColorWaferID = Color.Black
                    ElseIf cb.GetWaferInfo().WaferStatus = ConstEnum.enumWaferStatus.eWaferError Then
                        Me.imgWafer = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Error
                        ColorWaferID = Color.White
                    End If
                End If
            End If

            If (MyBase.Status = DisplayStatus.Off) Then
                e.Graphics.DrawEllipse(Pens.Black, 0, 0, Me.Width - 1, Me.Height - 1)

            Else
                If (cb.GetWaferInfo() IsNot Nothing) Then
                    e.Graphics.DrawImage(Me.imgWafer, 0, 0, Me.imgWafer.Width, Me.imgWafer.Height)
                    e.Graphics.DrawString(cb.GetWaferInfo().WaferID, New Font("Times New Roman", 10, FontStyle.Bold), _
                                          New SolidBrush(ColorWaferID), (Me.Width - 1) / 4 - 4, _
                                          (Me.Height - 1) / 3 - 1)
                End If
            End If
            '
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

End Class
