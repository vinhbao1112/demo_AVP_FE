Namespace XMLResources
    Public Class ProcessJob
        Public Const XMLText As String = _
        "<?xml version=""1.0"" encoding=""UTF-8""?>" & _
        "<StateMachine initstate=""NoState"">" & _
        "	<State name=""NO STATE"" id=""NoState""/>" & _
        "	<State name=""WAITING FOR START"" id=""WaitingForStart""/>" & _
        "	<State name=""PROCESSING"" id=""Processing""/>" & _
        "	<State name=""PROCESS COMPLETE"" id=""ProcessComplete""/>" & _
        "	<State name=""STOPPING"" id=""Stopping""/>" & _
        "	<State name=""PAUSING"" id=""Pausing""/>" & _
        "	<State name=""PAUSED"" id=""Paused""/>" & _
        "	<State name=""ABORTING"" id=""Aborting""/>" & _
        "	<Transition txNo=""1"" src=""NoState"" dst=""WaitingForStart"" triggerid=""PJ_CREATED""/>	" & _
        "	<Transition txNo=""2"" src=""WaitingForStart"" dst=""Processing"" triggerid=""PJ_PROCESSING""/>" & _
        "	<Transition txNo=""3"" src=""Processing"" dst=""ProcessComplete"" triggerid=""PJ_PROCESSCOMPLETE""/>" & _
        "	<Transition txNo=""4"" src=""ProcessComplete"" dst=""NoState"" triggerid=""PJ_DELETE""/>	" & _
        "	<Transition txNo=""5"" src=""WaitingForStart"" dst=""Pausing"" triggerid=""PJ_PAUSE""/>" & _
        "	<Transition txNo=""6"" src=""Processing"" dst=""Pausing"" triggerid=""PJ_PAUSE""/>" & _
        "	<Transition txNo=""7"" src=""ProcessComplete"" dst=""Pausing"" triggerid=""PJ_PAUSE""/>	" & _
        "	<Transition txNo=""8"" src=""Pausing"" dst=""WaitingForStart"" triggerid=""PJ_RESUME""/>" & _
        "	<Transition txNo=""9"" src=""Pausing"" dst=""Processing"" triggerid=""PJ_RESUME""/>" & _
        "	<Transition txNo=""10"" src=""Pausing"" dst=""ProcessComplete"" triggerid=""PJ_RESUME""/>	" & _
        "	<Transition txNo=""11"" src=""Paused"" dst=""WaitingForStart"" triggerid=""PJ_RESUME""/>" & _
        "	<Transition txNo=""12"" src=""Paused"" dst=""Processing"" triggerid=""PJ_RESUME""/>" & _
        "	<Transition txNo=""13"" src=""Paused"" dst=""ProcessComplete"" triggerid=""PJ_RESUME""/>	" & _
        "	<Transition txNo=""14"" src=""WaitingForStart"" dst=""Stopping"" triggerid=""PJ_STOP""/>" & _
        "	<Transition txNo=""15"" src=""Processing"" dst=""Stopping"" triggerid=""PJ_STOP""/>" & _
        "	<Transition txNo=""16"" src=""ProcessComplete"" dst=""Stopping"" triggerid=""PJ_STOP""/>	" & _
        "	<Transition txNo=""17"" src=""Pausing"" dst=""Stopping"" triggerid=""PJ_STOP""/>	" & _
        "	<Transition txNo=""18"" src=""Pausing"" dst=""Paused"" triggerid=""PJ_PAUSED""/>	" & _
        "	<Transition txNo=""19"" src=""Paused"" dst=""Stopping"" triggerid=""PJ_STOP""/>	" & _
        "	<Transition txNo=""20"" src=""WaitingForStart"" dst=""Aborting"" triggerid=""PJ_ABORT""/>" & _
        "	<Transition txNo=""21"" src=""Processing"" dst=""Aborting"" triggerid=""PJ_ABORT""/>" & _
        "	<Transition txNo=""22"" src=""ProcessComplete"" dst=""Aborting"" triggerid=""PJ_ABORT""/>	" & _
        "	<Transition txNo=""23"" src=""Stopping"" dst=""Aborting"" triggerid=""PJ_ABORT""/>" & _
        "	<Transition txNo=""24"" src=""Pausing"" dst=""Aborting"" triggerid=""PJ_ABORT""/>" & _
        "	<Transition txNo=""25"" src=""Paused"" dst=""Aborting"" triggerid=""PJ_ABORT""/>" & _
        "	<Transition txNo=""26"" src=""Aborting"" dst=""NoState"" triggerid=""PJ_DELETE""/>" & _
        "	<Transition txNo=""27"" src=""Stopping"" dst=""NoState"" triggerid=""PJ_DELETE""/>" & _
        "</StateMachine>"
    End Class
End Namespace
