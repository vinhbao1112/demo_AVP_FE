<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoadLockLeg
    Inherits AVP_Robot_Project.PVDStatusPanel
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
        Me.LLQuestionMark = New AVP_Robot_Project.QuestionMarkControl
        Me.ticCassetteLL = New AVP_Robot_Project.TransparentImageControl
        Me.fscFootStatus = New AVP_Robot_Project.FootStatusControl
        Me.ticCassetteLLWaferPresent = New AVP_Robot_Project.TransparentImageControl
        Me.SuspendLayout()
        '
        'LLQuestionMark
        '
        Me.LLQuestionMark.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LLQuestionMark.Image = Global.AVP_Robot_Project.My.Resources.Resources.Question_Mark
        Me.LLQuestionMark.ImageSize = New System.Drawing.Size(19, 29)
        Me.LLQuestionMark.IsChamberPic = False
        Me.LLQuestionMark.IsStretch = False
        Me.LLQuestionMark.Location = New System.Drawing.Point(64, 21)
        Me.LLQuestionMark.Name = "LLQuestionMark"
        Me.LLQuestionMark.PausedJobID = ""
        Me.LLQuestionMark.Size = New System.Drawing.Size(19, 29)
        Me.LLQuestionMark.TabIndex = 153
        Me.LLQuestionMark.TextColor = System.Drawing.Color.Wheat
        Me.LLQuestionMark.TextInImage = ""
        Me.LLQuestionMark.TextLocation = New System.Drawing.Point(0, 0)
        Me.LLQuestionMark.Visible = False
        '
        'ticCassetteLL
        '
        Me.ticCassetteLL.Image = Global.AVP_Robot_Project.My.Resources.Resources.LoadLock_CX4_Cassette
        Me.ticCassetteLL.ImageSize = New System.Drawing.Size(42, 41)
        Me.ticCassetteLL.IsChamberPic = False
        Me.ticCassetteLL.IsStretch = False
        Me.ticCassetteLL.Location = New System.Drawing.Point(22, 3)
        Me.ticCassetteLL.Name = "ticCassetteLL"
        Me.ticCassetteLL.Size = New System.Drawing.Size(42, 41)
        Me.ticCassetteLL.TabIndex = 154
        Me.ticCassetteLL.TextColor = System.Drawing.Color.Wheat
        Me.ticCassetteLL.TextInImage = ""
        Me.ticCassetteLL.TextLocation = New System.Drawing.Point(0, 0)
        Me.ticCassetteLL.Visible = False
        '
        'fscFootStatus
        '
        Me.fscFootStatus.Location = New System.Drawing.Point(1, 52)
        Me.fscFootStatus.Name = "fscFootStatus"
        Me.fscFootStatus.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.LoadLock_CX4_Door_Close
        Me.fscFootStatus.OffState_ColorText = System.Drawing.Color.Empty
        Me.fscFootStatus.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.LoadLock_CX4_Door_Open
        Me.fscFootStatus.OnState_ColorText = System.Drawing.Color.Empty
        Me.fscFootStatus.Size = New System.Drawing.Size(85, 6)
        Me.fscFootStatus.Status = AVP_Robot_Project.BinaryStatusControl.DisplayStatus.Off
        Me.fscFootStatus.TabIndex = 155
        Me.fscFootStatus.TextLocation = New System.Drawing.Point(0, 0)
        Me.fscFootStatus.TextLocIsFix = True
        Me.fscFootStatus.TextValue = ""
        Me.fscFootStatus.TypeOfChamberSupport = AVP_Robot_Project.TypeOfAVPChamber.IBE
        Me.fscFootStatus.UnknownImage = Nothing
        Me.fscFootStatus.UnknownState_ColorText = System.Drawing.Color.Empty
        '
        'ticCassetteLLWaferPresent
        '
        Me.ticCassetteLLWaferPresent.Image = Global.AVP_Robot_Project.My.Resources.Resources.LoadLock_CX4_Cassette_Wafer
        Me.ticCassetteLLWaferPresent.ImageSize = New System.Drawing.Size(42, 41)
        Me.ticCassetteLLWaferPresent.IsChamberPic = False
        Me.ticCassetteLLWaferPresent.IsStretch = False
        Me.ticCassetteLLWaferPresent.Location = New System.Drawing.Point(22, 3)
        Me.ticCassetteLLWaferPresent.Name = "ticCassetteLLWaferPresent"
        Me.ticCassetteLLWaferPresent.Size = New System.Drawing.Size(42, 41)
        Me.ticCassetteLLWaferPresent.TabIndex = 156
        Me.ticCassetteLLWaferPresent.TextColor = System.Drawing.Color.Wheat
        Me.ticCassetteLLWaferPresent.TextInImage = ""
        Me.ticCassetteLLWaferPresent.TextLocation = New System.Drawing.Point(0, 0)
        Me.ticCassetteLLWaferPresent.Visible = False
        '
        'LoadLockLeg
        '
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.LoadLock_CX4
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Controls.Add(Me.ticCassetteLLWaferPresent)
        Me.Controls.Add(Me.LLQuestionMark)
        Me.Controls.Add(Me.fscFootStatus)
        Me.Controls.Add(Me.ticCassetteLL)
        Me.Name = "LoadLockLeg"
        Me.Size = New System.Drawing.Size(95, 65)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LLQuestionMark As AVP_Robot_Project.QuestionMarkControl
    Friend WithEvents ticCassetteLL As AVP_Robot_Project.TransparentImageControl
    Friend WithEvents fscFootStatus As AVP_Robot_Project.FootStatusControl
    Friend WithEvents ticCassetteLLWaferPresent As AVP_Robot_Project.TransparentImageControl

End Class
