Namespace XMLResources
    Public Class ControlJob
        Public Const XMLText As String = _
        "<?xml version=""1.0"" encoding=""UTF-8""?>" & _
        "<StateMachine initstate=""NoState"">" & _
        "	<State name=""NO STATE"" id=""NoState""/>" & _
        "	<State name=""WAITNGFORSTART"" id=""WaitingForStart""/>" & _
        "	<State name=""EXECUTING"" id=""Executing"" />" & _
        "	<State name=""PAUSED"" id=""Paused"" />" & _
        "	<State name=""COMPLETED"" id=""Completed"" />	" & _
        "	<Transition txNo=""6"" src=""NoState"" dst=""WaitingForStart"" triggerid=""CJ_CREATED""/>" & _
        "	<Transition txNo=""7"" src=""WaitingForStart"" dst=""Executing"" triggerid=""CJ_EXECUTING""/>" & _
        "	<Transition txNo=""8"" src=""Executing"" dst=""Paused"" triggerid=""CJ_PAUSED""/>" & _
        "	<Transition txNo=""9"" src=""Paused"" dst=""Executing"" triggerid=""CJ_EXECUTING""/>" & _
        "	<Transition txNo=""10"" src=""Executing"" dst=""Completed"" triggerid=""CJ_COMPLETED""/>" & _
        "	<Transition txNo=""14"" src=""WaitingForStart"" dst=""Completed"" triggerid=""CJ_STOPPED""/>" & _
        "	<Transition txNo=""15"" src=""Executing"" dst=""Completed"" triggerid=""CJ_STOPPED""/>" & _
        "	<Transition txNo=""16"" src=""Paused"" dst=""Completed"" triggerid=""CJ_STOPPED""/>" & _
        "	<Transition txNo=""17"" src=""WaitingForStart"" dst=""Completed"" triggerid=""CJ_ABORTED""/>" & _
        "	<Transition txNo=""18"" src=""Executing"" dst=""Completed"" triggerid=""CJ_ABORTED""/>" & _
        "	<Transition txNo=""19"" src=""Paused"" dst=""Completed"" triggerid=""CJ_ABORTED""/>" & _
        "	<Transition txNo=""13"" src=""Completed"" dst=""NoState"" triggerid=""CJ_DELETED""/>" & _
        "</StateMachine>"
    End Class
End Namespace
