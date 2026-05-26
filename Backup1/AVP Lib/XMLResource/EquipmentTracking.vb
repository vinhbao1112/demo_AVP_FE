Namespace XMLResources
    Public Class EquipmentTracking
        Public Const XMLText As String = _
        "<?xml version=""1.0"" encoding=""UTF-8""?>" & _
        "<StateMachine initstate=""IDLE"">" & _
        "	<State name=""BLOCKED"" id=""BLOCKED""/>" & _
        "	<State name=""IDLE"" id=""IDLE""/>" & _
        "	<State name=""BUSY"" id=""BUSY""/>" & _
        "	<Transition txNo=""2"" src=""IDLE"" dst=""BUSY"" triggerid=""2"">" & _
        "	    <desc equipment starts execution of a new task />" & _
        "	</Transition>" & _
        "	<Transition txNo=""3"" src=""BUSY"" dst=""IDLE"" triggerid=""3"">" & _
        "	    <desc completes execution of task and Material is removed from the equipment/>" & _
        "	</Transition>" & _
        "	<Transition txNo=""4"" src=""BUSY"" dst=""BUSY"" triggerid=""4"">" & _
        "	    <desc starts execution of a new task upon the normal completion of the previous task />" & _
        "	</Transition>" & _
        "	<Transition txNo=""5"" src=""BUSY"" dst=""BLOCKED"" triggerid=""5"">" & _
        "	    <desc A pause command is received or An abort command is received or A Fault condition occurs />	    " & _
        "	</Transition>" & _
        "	<Transition txNo=""6"" src=""BLOCKED"" dst=""BUSY"" triggerid=""6"">" & _
        "	    <desc All fault conditions are cleared and the equipment resumes execution of its task or starts execution of a new task />	    " & _
        "	</Transition>" & _
        "	<Transition txNo=""7"" src=""BLOCKED"" dst=""IDLE"" triggerid=""7"">" & _
        "	    <desc All fault conditions are cleared and All material is removed and equipment can begin a new task />	    " & _
        "	</Transition>" & _
        "	<Transition txNo=""8"" src=""IDLE"" dst=""BLOCKED"" triggerid=""8"">" & _
        "	    <desc (Material arrives and the equipment cannot begin executing a task) OR (A fault condition occurs which prevents the equipment from starting a new task) />	    " & _
        "	</Transition>" & _
        "	<Transition txNo=""9"" src=""BLOCKED"" dst=""BLOCKED"" triggerid=""9"">" & _
        "	    <desc Fault conditions occur that prevent the equipment from resuming a blocked task, or starting a new task />	    " & _
        "	</Transition>	" & _
        "</StateMachine>"
    End Class
End Namespace
