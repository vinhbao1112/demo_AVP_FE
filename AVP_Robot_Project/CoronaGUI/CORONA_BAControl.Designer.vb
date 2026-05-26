<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CORONA_BAControl
    Inherits AVP_Robot_Project.PVDStatusBoard

    'Form overrides dispose to clean up the component list.
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
        Me.txtInformation = New AVP_Robot_Project.SL_Textbox
        Me.SuspendLayout()
        '
        'txtInformation
        '
        Me.txtInformation.AutoSendEventHandler = False
        Me.txtInformation.AutoSendKeyTabWhenFinishInput = False
        Me.txtInformation.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtInformation.Clickable = False
        Me.txtInformation.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtInformation.DisplayPressureFont = True
        Me.txtInformation.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtInformation.ForeColor = System.Drawing.Color.Lime
        Me.txtInformation.GasName = ""
        Me.txtInformation.GetDefaultMinMax = False
        Me.txtInformation.IsGasType_SynchronizeButNoUpdateMinMaxValueToPM = False
        Me.txtInformation.IsIntergerNumber = False
        Me.txtInformation.IsNumericTextbox = False
        Me.txtInformation.IsReadBack = True
        Me.txtInformation.IsTurboPumpTextbox = False
        Me.txtInformation.Location = New System.Drawing.Point(5, 31)
        Me.txtInformation.LogSource = ""
        Me.txtInformation.Name = "txtInformation"
        Me.txtInformation.PermissionCode = ""
        Me.txtInformation.ReadOnly = True
        Me.txtInformation.ShowUnitFormat = False
        Me.txtInformation.Size = New System.Drawing.Size(90, 24)
        Me.txtInformation.SourceOfMessageBox = ""
        Me.txtInformation.TabIndex = 8
        Me.txtInformation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtInformation.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.PVD4
        Me.txtInformation.UnitTypeUsed = ""
        Me.txtInformation.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtInformation.UseClickEventInForm = False
        Me.txtInformation.UseDigitNumber = AVP_Robot_Project.DigitsNumber.One_Digit
        Me.txtInformation.UseScientificFormat = False
        '
        'CORONA_BAControl
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.txtInformation)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "CORONA_BAControl"
        Me.Size = New System.Drawing.Size(99, 60)
        Me.Text = "Baratron"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.txtInformation, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtInformation As AVP_Robot_Project.SL_Textbox

End Class
