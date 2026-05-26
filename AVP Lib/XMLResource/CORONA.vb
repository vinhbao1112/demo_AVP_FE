Namespace XMLResources
Public Class CORONA
Public Const XMLText as String = _
"<RecipeDef>" & _
"  <ParameterList Id=""1"" isGroup=""1"" Group=""Version_Control"" GroupName=""Version_Control"" ShowInUI=""False"">" & _
"    <Parameter>" & _
"      <SeqNo>1</SeqNo>" & _
"      <Name>(c)2012 AVP Technology, LLC</Name>" & _
"      <Description>(c)2012 AVP Technology, LLC</Description>" & _
"      <Default>" & _
"      </Default>" & _
"      <Unit>String</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>2</SeqNo>" & _
"      <Name>CORONA Process File Version 1.00</Name>" & _
"      <Description>CORONA Process File Version 1.00</Description>" & _
"      <Default>" & _
"      </Default>" & _
"      <Unit>String</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>3</SeqNo>" & _
"      <Name>StepName</Name>" & _
"      <Description>" & _
"      </Description>" & _
"      <Default>" & _
"      </Default>" & _
"      <Unit>String</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>4</SeqNo>" & _
"      <Name>StepDescription</Name>" & _
"      <Description>" & _
"      </Description>" & _
"      <Default>" & _
"      </Default>" & _
"      <Unit>String</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"    </Parameter>" & _
"  </ParameterList>" & _
"  <ParameterList Id=""2"" isGroup=""1"" Group=""Gasses"" GroupName=""Gasses_Control"" ShowInUI=""True"">" & _
"    <Parameter>" & _
"      <SeqNo>1</SeqNo>" & _
"      <Name>Gas1</Name>" & _
"      <Description>Gas 1 ({0})(sccm)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>145</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>2</SeqNo>" & _
"      <Name>Gas2</Name>" & _
"      <Description>Gas 2 ({0})(sccm)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>145</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>3</SeqNo>" & _
"      <Name>Gas3</Name>" & _
"      <Description>Gas 3 ({0})(sccm)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>4</SeqNo>" & _
"      <Name>Gas4</Name>" & _
"      <Description>Gas 4 ({0})(sccm)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>145</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>5</SeqNo>" & _
"      <Name>Gas5</Name>" & _
"      <Description>Gas 5 ({0})(sccm)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>145</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"  </ParameterList>" & _
"  <ParameterList Id=""3"" isGroup=""1"" Group=""ProcessControl"" GroupName=""ProcessControl"" ShowInUI=""True"">" & _
"    <Parameter>" & _
"      <SeqNo>1</SeqNo>" & _
"      <Name>ProcessTimeHours</Name>" & _
"      <Description>Process Time Hours (hours)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>2</SeqNo>" & _
"      <Name>ProcessTimeMinutes</Name>" & _
"      <Description>Process Time Minutes (mins)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>59</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>3</SeqNo>" & _
"      <Name>ProcessTimeSeconds</Name>" & _
"      <Description>Process Time Seconds (secs)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>59</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>4</SeqNo>" & _
"      <Name>ProcessStartPressure</Name>" & _
"      <Description>Process Start Pressure (torr)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100</Max>" & _
"      <Default>5.00E-06</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>5</SeqNo>" & _
"      <Name>ProcessVATMode</Name>" & _
"      <Description>Process VAT Mode</Description>" & _
"      <Default>Pressure</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""Pressure"">Pressure</Item>" & _
"        <Item Value=""Percent"">Percent</Item>" & _
"        <Item Value=""Open"">Open</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>6</SeqNo>" & _
"      <Name>ProcessVATPosition</Name>" & _
"      <Description>Process VAT Pos (%)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>7</SeqNo>" & _
"      <Name>ProcessPressure</Name>" & _
"      <Description>Process Pressure (mtorr)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>8</SeqNo>" & _
"      <Name>SubTableRotationSpeed</Name>" & _
"      <Description>SubTable Rotation Speed</Description>" & _
"      <Min>1</Min>" & _
"      <Max>10</Max>" & _
"      <Default>5</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>9</SeqNo>" & _
"      <Name>BiasPower</Name>" & _
"      <Description>Bias Power (secs)</Description>" & _
"      <Min>1</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>10</SeqNo>" & _
"      <Name>PowerDown</Name>" & _
"      <Description>Power Down</Description>" & _
"      <Default>Yes</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>11</SeqNo>" & _
"      <Name>LogIntervalSecond</Name>" & _
"      <Description>Log Data Interval (secs)</Description>" & _
"      <Min>1</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>5</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"  </ParameterList>" & _
"  <ParameterList Id=""4"" isGroup=""1"" Group=""Target1"" GroupName=""Target1"" ShowInUI=""True"">" & _
"    <Parameter>" & _
"      <SeqNo>1</SeqNo>" & _
"      <Name>TargetPower</Name>" & _
"      <Description>Target Power (Watts)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>2</SeqNo>" & _
"      <Name>TargetRampTime</Name>" & _
"      <Description>Target Ramp Time (Secs)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>3</SeqNo>" & _
"      <Name>TargetPulseFrequency</Name>" & _
"      <Description>Target Pulse Frequency (kHz)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>4</SeqNo>" & _
"      <Name>TargetPulseWidth</Name>" & _
"      <Description>Target Pulse Width (ns)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>5</SeqNo>" & _
"      <Name>TargetShutterOpen</Name>" & _
"      <Description>Target Shutter Open</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"  </ParameterList>" & _
"  <ParameterList Id=""4"" isGroup=""1"" Group=""Target2"" GroupName=""Target2"" ShowInUI=""True"">" & _
"    <Parameter>" & _
"      <SeqNo>1</SeqNo>" & _
"      <Name>TargetPower</Name>" & _
"      <Description>Target Power (Watts)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>2</SeqNo>" & _
"      <Name>TargetRampTime</Name>" & _
"      <Description>Target Ramp Time (Secs)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>3</SeqNo>" & _
"      <Name>TargetPulseFrequency</Name>" & _
"      <Description>Target Pulse Frequency (kHz)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>4</SeqNo>" & _
"      <Name>TargetPulseWidth</Name>" & _
"      <Description>Target Pulse Width (ns)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>5</SeqNo>" & _
"      <Name>TargetShutterOpen</Name>" & _
"      <Description>Target Shutter Open</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"  </ParameterList>" & _
"  <ParameterList Id=""4"" isGroup=""1"" Group=""Target3"" GroupName=""Target3"" ShowInUI=""True"">" & _
"    <Parameter>" & _
"      <SeqNo>1</SeqNo>" & _
"      <Name>TargetPower</Name>" & _
"      <Description>Target Power (Watts)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>2</SeqNo>" & _
"      <Name>TargetRampTime</Name>" & _
"      <Description>Target Ramp Time (Secs)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>3</SeqNo>" & _
"      <Name>TargetPulseFrequency</Name>" & _
"      <Description>Target Pulse Frequency (kHz)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>4</SeqNo>" & _
"      <Name>TargetPulseWidth</Name>" & _
"      <Description>Target Pulse Width (ns)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>5</SeqNo>" & _
"      <Name>TargetShutterOpen</Name>" & _
"      <Description>Target Shutter Open</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"  </ParameterList>" & _
"  <ParameterList Id=""4"" isGroup=""1"" Group=""Target4"" GroupName=""Target4"" ShowInUI=""True"">" & _
"    <Parameter>" & _
"      <SeqNo>1</SeqNo>" & _
"      <Name>TargetPower</Name>" & _
"      <Description>Target Power (Watts)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>2</SeqNo>" & _
"      <Name>TargetRampTime</Name>" & _
"      <Description>Target Ramp Time (Secs)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>3</SeqNo>" & _
"      <Name>TargetPulseFrequency</Name>" & _
"      <Description>Target Pulse Frequency (kHz)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>4</SeqNo>" & _
"      <Name>TargetPulseWidth</Name>" & _
"      <Description>Target Pulse Width (ns)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>5</SeqNo>" & _
"      <Name>TargetShutterOpen</Name>" & _
"      <Description>Target Shutter Open</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"  </ParameterList>" & _
"</RecipeDef>"
End Class
End Namespace
