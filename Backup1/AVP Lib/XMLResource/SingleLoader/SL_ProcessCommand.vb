Namespace XMLResources
    Public Class SL_ProcessCommand
        Public Const XMLText As String = _
        "<Commands>" & _
        "  <Device name = ""Robot"">" & _
        "    <Command Code=""SET COMM ALL PKT SEQ AUT"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""SET IO ECHO N"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""STORE COMM ALL"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""HLLO"">" & _
        "      <Reply DecoderName=""TSRobotAliveDecoder"" Property=""IsCommunicating,OperationStatus,ErrorMessage"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""HOME ALL"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""GOTO N 1"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""GOTO N 2"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""GOTO N 3"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""GOTO N 4"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""GOTO N 5"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""GOTO N 6"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""GOTO N 7"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""GOTO N 8"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""GOTO N 9"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""GOTO Z DN"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""GOTO Z UP"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""GOTO R EX"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""GOTO R RE"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""IsRetracted"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""PICK 1"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""PICK 2"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""PICK 3"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""PICK 4"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""PICK 5"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""PICK 6"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""PICK 7"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""PICK 8"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""PICK 9"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""PLACE 1"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""PLACE 2"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""PLACE 3"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""PLACE 4"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""PLACE 5"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""PLACE 6"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""PLACE 7"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""PLACE 8"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""PLACE 9"">" & _
        "      <Reply DecoderName=""TSReadyErrorDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""RQ POS ABS ALL"">" & _
        "      <Reply DecoderName=""TSRobotRetractedDecoder"" Property=""IsRetracted,ErrorMessage"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""RQ STN 8 ALL"">" & _
        "      <Reply DecoderName=""TSRobotRqStnDecoder"" Property=""OperationStatus,ReqAlStn_R,ReqAlStn_Traw,ReqAlStn_Z,ReqLOWER,ReqNSLOTS,ReqPITCH"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""RQ STN 9 ALL"">" & _
        "      <Reply DecoderName=""TSRobotRqStnDecoder"" Property=""OperationStatus,ReqAlStn_R,ReqAlStn_Traw,ReqAlStn_Z,ReqLOWER,ReqNSLOTS,ReqPITCH"">True</Reply>" & _
        "    </Command>" & _
        "  </Device>" & _
        "  <Device name = ""Aligner"">" & _
        "    <Command Code=""SLIO M/B PKT BAUD 4 ECHO N"">" & _
        "      <Reply DecoderName=""TSAlignerReadyDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""LDCCDPOS 1 2700"">" & _
        "      <Reply DecoderName=""TSAlignerReadyDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""SLWF SIZE 5 CCD 1 FDCL NTCH"">" & _
        "      <Reply DecoderName=""TSAlignerReadyDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""HOME"">" & _
        "      <Reply DecoderName=""TSAlignerReadyDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""ALGN"">" & _
        "      <Reply DecoderName=""TSAlignerReadyDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""SCAN"">" & _
        "      <Reply DecoderName=""TSAlignerReadyDecoder"" Property=""OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""RSLT"">" & _
        "      <Reply DecoderName=""TSAlignerResultDecoder"" Property=""OperationStatus,RSLTAngularLocation,RSLTAngularLocationDeg,RSLTEccentricityAngle,RSLTEccentricityAngleDeg,RSLTMaxEccentricity,RSLTMaxEccentricityMils,RSLTAvgCCD,RSLTReScanNeed,RSLTTypeCode"">True</Reply>" & _
        "    </Command>" & _
        "     <Command Code=""RQID"">" & _
        "      <Reply DecoderName=""TSAlignerAliveDecoder"" Property=""IsCommunicating,OperationStatus"">True</Reply>" & _
        "    </Command>" & _
        "  </Device>" & _
        "  <Device name = ""Elevator"">" & _
        "    <Command Code=""00,R,CS"">" & _
        "      <Reply DecoderName=""TSClampStatusDecoder"" Property=""CLStatus,ErrorMessage"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""00,R,ER"">" & _
        "      <Reply DecoderName=""TSElevatorErrorDecoder"" Property=""IsCommunicating,OperationStatus,ErrorMessage"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""00,R,MI"">" & _
        "      <Reply DecoderName=""MappedInforDecoder"" Property=""SlotStatus"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""00,R,W2"">" & _
        "      <Reply DecoderName=""CassettePresentDecoder"" Property=""CPStatus,ErrorMessage"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""00,R,OS"">" & _
        "      <Reply DecoderName=""ElevatorOperationalDecoder"" Property=""OperationStatus,CurrentSlot,DCStatus,IsHwErrorReceived"">True</Reply>" & _
        "    </Command>" & _
        "  </Device>" & _
        "  <Device name = ""Cryo"">" & _
        "  	<Command Code=""$S16"">" & _
        "      <Reply DecoderName=""CryoPollingDecoder"" Property=""CryoOn,CryoRoughOn,CryoPurgeOn,CryoTCOn"" IsCheckSum=""True"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""$J;"">" & _
        "      <Reply DecoderName=""CryoNumberDecoder"" Property=""T1,ErrorMessage"" IsCheckSum=""True"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""$K:"">" & _
        "      <Reply DecoderName=""CryoNumberDecoder"" Property=""T2,ErrorMessage"" IsCheckSum=""True"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""$L="">" & _
        "      <Reply DecoderName=""CryoNumberDecoder"" Property=""Pressure"" IsCheckSum=""True"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""$O>"">" & _
        "      <Reply DecoderName=""CryoRegenStatusDecoder"" Property=""RegenStatus,ErrorMessage"" IsCheckSum=""True"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""$N1n"">" & _
        "      <Reply DecoderName=""TSDecoder"" Property=""ErrorMessage"" IsCheckSum=""False"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""$N0o"">" & _
        "      <Reply DecoderName=""TSDecoder"" Property=""ErrorMessage"" IsCheckSum=""False"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""$A1c"">" & _
        "      <Reply DecoderName=""TSDecoder"" Property=""ErrorMessage"" IsCheckSum=""False"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""$A0`"">" & _
        "      <Reply DecoderName=""TSDecoder"" Property=""ErrorMessage"" IsCheckSum=""False"">True</Reply>" & _
        "    </Command>" & _
        "    <Command Code=""$A?2"">" & _
        "      <Reply DecoderName=""CryoPumpStatusDecoder"" Property=""PumpStatus,IsCommunicating,ErrorMessage"" IsCheckSum=""True"">True</Reply>" & _
        "    </Command>" & _
        "  </Device>" & _
        "</Commands>"
    End Class
End Namespace
