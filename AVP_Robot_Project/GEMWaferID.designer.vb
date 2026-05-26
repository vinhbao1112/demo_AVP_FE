<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GEMWaferID
    Inherits System.Windows.Forms.Panel

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblWaferID = New System.Windows.Forms.Label
        Me.txtGEMWaferID = New AVP_Robot_Project.SL_Textbox
        Me.lblPadding = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblWaferID
        '
        Me.lblWaferID.Location = New System.Drawing.Point(0, 0)
        Me.lblWaferID.Name = "lblWaferID"
        Me.lblWaferID.Size = New System.Drawing.Size(50, 23)
        Me.lblWaferID.TabIndex = 0
        Me.lblWaferID.Text = "Label1"
        Me.lblWaferID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPadding
        '
        Me.lblPadding.Location = New System.Drawing.Point(0, 0)
        Me.lblPadding.Name = "lblPadding"
        Me.lblPadding.Size = New System.Drawing.Size(8, 23)
        Me.lblPadding.TabIndex = 0
        Me.lblPadding.Text = ""
        Me.lblPadding.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtGEMWaferID
        '
        Me.txtGEMWaferID.AutoSendEventHandler = True
        Me.txtGEMWaferID.AutoSendKeyTabWhenFinishInput = False
        Me.txtGEMWaferID.BackColor = System.Drawing.Color.White
        Me.txtGEMWaferID.Clickable = True
        Me.txtGEMWaferID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtGEMWaferID.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGEMWaferID.GasName = ""
        Me.txtGEMWaferID.GetDefaultMinMax = False
        Me.txtGEMWaferID.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = False
        Me.txtGEMWaferID.IsIntergerNumber = False
        Me.txtGEMWaferID.IsNumericTextbox = False
        Me.txtGEMWaferID.IsReadBack = False
        Me.txtGEMWaferID.IsTurboPumpTextbox = False
        Me.txtGEMWaferID.Location = New System.Drawing.Point(0, 0)
        Me.txtGEMWaferID.LogSource = ""
        Me.txtGEMWaferID.Name = "txtGEMWaferID"
        Me.txtGEMWaferID.PermissionCode = ""
        Me.txtGEMWaferID.ReadOnly = True
        Me.txtGEMWaferID.ShowUnitFormat = False
        Me.txtGEMWaferID.Size = New System.Drawing.Size(100, 24)
        Me.txtGEMWaferID.SourceOfMessageBox = ""
        Me.txtGEMWaferID.TabIndex = 0
        Me.txtGEMWaferID.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.AVP
        Me.txtGEMWaferID.UnitTypeUsed = ""
        Me.txtGEMWaferID.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtGEMWaferID.UseClickEventInForm = False
        Me.txtGEMWaferID.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtGEMWaferID.UseScientificFormat = False
        '
        'GEMWaferID
        '
        Me.Size = New System.Drawing.Size(323, 124)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblWaferID As System.Windows.Forms.Label
    Friend WithEvents lblPadding As System.Windows.Forms.Label
    Friend WithEvents txtGEMWaferID As AVP_Robot_Project.SL_Textbox

End Class
