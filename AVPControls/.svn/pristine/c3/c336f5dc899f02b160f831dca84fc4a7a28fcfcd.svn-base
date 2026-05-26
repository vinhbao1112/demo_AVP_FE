Imports System.ComponentModel
Imports AVPControls.AVPDataLib

Public Class AVPShutterControl

    Dim m_ShutterType As ShutterTypes = ShutterTypes.EtchShutter

#Region "Properties"
    Protected Overrides ReadOnly Property DefaultSize() As System.Drawing.Size
        Get
            Return New Size(60, 194)
        End Get
    End Property

    Protected Overrides ReadOnly Property DefaultCursor() As System.Windows.Forms.Cursor
        Get
            Return Cursors.Hand
        End Get
    End Property

    ''' <author>
    '''     <name>Dy Do</name>
    '''     <date>2019-06-13</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicates shutter type of control.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(ShutterTypes), "EtchShutter")> _
    Public Overridable Property ShutterType() As ShutterTypes
        Get
            Return m_ShutterType
        End Get
        Set(ByVal value As ShutterTypes)
            If m_ShutterType = value Then
                Return
            End If
            m_ShutterType = value
            UpdateView()
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2019-11-07</date>
    ''' <summary>
    ''' Gets or sets alpha value for region.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Category("AVP Layout"), Description("Get or set a value indicates the alpha components value of pixels which be remove from region.")> _
    <DefaultValue(CType(0, Byte))> _
    Public Property RegionAlphaValue() As Byte
        Get
            Return Me.AlphaValueForRegion
        End Get
        Set(ByVal value As Byte)
            If Me.AlphaValueForRegion <> value Then
                Me.AlphaValueForRegion = value
                UpdateView()
            End If
        End Set
    End Property

#End Region

#Region "Methods"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-14</date>
    ''' </author>
    ''' <summary>
    ''' Generate shutter image.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function GenerateControlImage() As System.Drawing.Bitmap
        Dim img As Bitmap = Nothing
        Try
            If Me.ChamberType = AVPChamberTypes.PVD2R4 Then
                Select Case Me.Status
                    Case DisplayStatus.Off
                        img = My.Resources.Resources.PVD2R4_Shutter_Close
                    Case DisplayStatus.On
                        img = My.Resources.Resources.PVD2R4_Shutter_Open
                    Case Else
                        img = My.Resources.Resources.PVD2R4_Shutter_Unknown
                End Select
            ElseIf Me.ChamberType = AVPChamberTypes.VIBD OrElse Me.ChamberType = AVPChamberTypes.IBD Then
                If Me.ShutterType = ShutterTypes.EtchShutter Then
                    Select Case Me.Status
                        Case DisplayStatus.Off
                            img = My.Resources.Resources.IBDVeeCo_FixtureShutter_Close
                        Case DisplayStatus.On
                            img = My.Resources.Resources.IBDVeeCo_FixtureShutter_Opened
                        Case Else
                            img = My.Resources.Resources.IBDVeeCo_FixtureShutter_Unknow
                    End Select

                ElseIf Me.ShutterType = ShutterTypes.DepShutter Then
                    Select Case Me.Status
                        Case AVPControls.AVPDataLib.DisplayStatus.Unknow
                            img = My.Resources.IBDVeeCo_DepoShutter_Unknow
                        Case AVPControls.AVPDataLib.DisplayStatus.Off
                            img = My.Resources.IBDVeeCo_DepoShutter_Close
                        Case AVPControls.AVPDataLib.DisplayStatus.On
                            img = My.Resources.IBDVeeCo_DepoShutter_Opened
                    End Select

                ElseIf Me.ShutterType = ShutterTypes.TargetShutter Then
                    Select Case Me.Status
                        Case AVPControls.AVPDataLib.DisplayStatus.Unknow
                            img = My.Resources.IBDVeeCo_PadShutter_Unknow
                        Case AVPControls.AVPDataLib.DisplayStatus.Off
                            img = My.Resources.IBDVeeCo_PadShutter_Close
                        Case AVPControls.AVPDataLib.DisplayStatus.On
                            img = My.Resources.IBDVeeCo_PadShutter_Opened
                    End Select

                End If

            ElseIf Me.ChamberType = AVPChamberTypes.PVDA_SA Then
                Select Case Me.Status
                    Case AVPControls.AVPDataLib.DisplayStatus.Off
                        img = My.Resources.PVDA_SA_ShutterClosed
                    Case AVPControls.AVPDataLib.DisplayStatus.On
                        img = My.Resources.PVDA_SA_ShutterOpen
                    Case Else
                        img = My.Resources.PVDA_SA_ShutterUnknown
                End Select

            Else
                Select Case Me.Status
                    Case DisplayStatus.Off
                        img = My.Resources.Resources.IBEShutter_Close
                    Case DisplayStatus.On
                        img = My.Resources.Resources.IBEShutter_Open
                    Case Else
                        If Me.LastStatus = DisplayStatus.Off Then
                            img = My.Resources.Resources.IBEShutter_Close_Unknown
                        Else
                            img = My.Resources.Resources.IBEShutter_Open_Unknown
                        End If
                End Select
            End If

        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return img
    End Function


#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.AlphaValueForRegion = 0
        Me.IsInitialized = True
        Me.ChamberType = AVPChamberTypes.IBE
        Me.ResumeUpdateView()

    End Sub
End Class
