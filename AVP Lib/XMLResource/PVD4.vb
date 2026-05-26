Namespace XMLResources
Public Class PVD4
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
"      <Name>PVD4 Process File Version 2.8</Name>" & _
"      <Description>PVD4 Process File Version 2.8</Description>" & _
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
"  <ParameterList Id=""2"" isGroup=""1"" Group=""StepDescription"" GroupName=""Description"" ShowInUI=""True"">   " & _
"    <Parameter>" & _
"      <SeqNo>1</SeqNo>" & _
"      <Name>StepDescription</Name>" & _
"      <Description>Description</Description>" & _
"      <Default>" & _
"      </Default>" & _
"      <Unit>String</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"  </ParameterList>" & _
"  <ParameterList Id=""3"" isGroup=""1"" Group=""LoopInfomation"" GroupName=""Loop Information"" ShowInUI=""True"">" & _
"    <Parameter>" & _
"      <SeqNo>1</SeqNo>" & _
"      <Name>LoopMode</Name>" & _
"      <Description>Loop Mode</Description>" & _
"      <Default>NONE</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""0"" SeqNoDisable=""2"" SeqNoCalculate=""2=0"">NONE</Item>" & _
"        <Item Value=""1"" SeqNoDisable=""2"" SeqNoCalculate=""2=0"">START</Item>" & _
"		<Item Value=""2"">END</Item>" & _
"		<Item Value=""3"">SELF LOOP</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>2</SeqNo>" & _
"      <Name>LoopCount</Name>" & _
"      <Description>Loop Count</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"  </ParameterList>" & _
"  <ParameterList Id=""4"" isGroup=""1"" Group=""Gasses"" GroupName=""Gasses Control"" ShowInUI=""True"">" & _
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
"	<Parameter>" & _
"      <SeqNo>6</SeqNo>" & _
"      <Name>UseGasDistribution</Name>" & _
"      <Description>Use Gas Distribution</Description>" & _
"      <Default>Yes</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>7</SeqNo>" & _
"      <Name>UseSecondaryGasOnly</Name>" & _
"      <Description>Secondary Gas Only</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>8</SeqNo>" & _
"      <Name>UseMainDist</Name>" & _
"      <Description>Use Main Distribution Valve</Description>" & _
"      <Default>Yes</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>9</SeqNo>" & _
"      <Name>UseSeconDist</Name>" & _
"      <Description>Use Secondary Distribution Valve</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"  </ParameterList>" & _
"  <ParameterList Id=""5"" isGroup=""1"" Group=""ProcessControl"" GroupName=""Process Control"" ShowInUI=""True"">" & _
"    <Parameter>" & _
"      <SeqNo>1</SeqNo>" & _
"      <Name>ControlMode</Name>" & _
"      <Description>Control Mode (Time / Revolution / Static)</Description>" & _
"      <Default>Time</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""Time"" SeqNoDisable=""FilMetricControl:1,FilMetricControl:2,FilMetricControl:3,2,4"">Time</Item>" & _
"        <Item Value=""Revolution"" SeqNoDisable=""FilMetricControl:1,FilMetricControl:2,FilMetricControl:3,3,4"">Revolution</Item>" & _
"        <Item Value=""Static"" SeqNoDisable=""FilMetricControl:1,FilMetricControl:2,FilMetricControl:3,2,32"">Static</Item>" & _
"		<Item Value=""Thickness"">Thickness</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"	 <Parameter>" & _
"      <SeqNo>2</SeqNo>" & _
"      <Name>Revolution</Name>" & _
"      <Description>Revolution (No. Rev)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>10</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>3</SeqNo>" & _
"      <Name>ProcessTimeSeconds</Name>" & _
"      <Description>Process Time (secs)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>59</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>4</SeqNo>" & _
"      <Name>StaticPostion</Name>" & _
"      <Description>Static Wafer Position (1-{0})</Description>" & _
"      <Min>1</Min>" & _
"      <Max>8</Max>" & _
"      <Default>1</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>5</SeqNo>" & _
"      <Name>ProcessStartPressure</Name>" & _
"      <Description>Process Start Pressure (torr)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100</Max>" & _
"      <Default>5.00E-06</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>6</SeqNo>" & _
"      <Name>ProcessVATMode</Name>" & _
"      <Description>Process VAT Mode</Description>" & _
"      <Default>Pressure</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""Pressure"" SeqNoDisable=""7"">Pressure</Item>" & _
"        <Item Value=""Percent"" SeqNoDisable=""8"">Percent</Item>" & _
"        <Item Value=""Open"" SeqNoDisable=""7,8"">Open</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>7</SeqNo>" & _
"      <Name>ProcessVATPosition</Name>" & _
"      <Description>Process VAT Pos (%)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>8</SeqNo>" & _
"      <Name>ProcessPressure</Name>" & _
"      <Description>Process Pressure (mtorr)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>9</SeqNo>" & _
"      <Name>PowerDown</Name>" & _
"      <Description>Power Down</Description>" & _
"      <Default>Yes</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No (Shutter Close)</Item>" & _
"		<Item Value=""falseShutterOpen"">No (Shutter Open)</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>10</SeqNo>" & _
"      <Name>LogIntervalSecond</Name>" & _
"      <Description>Data Log Interval (secs)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>1000</Max>" & _
"      <Default>2</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"  </ParameterList>" & _
"  <ParameterList Id=""6"" isGroup=""1"" Group=""RFTargetPower"" GroupName=""RF Target Power"" ShowInUI=""True"">" & _
"    <Parameter>" & _
"      <SeqNo>1</SeqNo>" & _
"      <Name>TargetSelection</Name>" & _
"      <Description>Target Selection (1-4)</Description>" & _
"      <Default>T4</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""T1"">T1</Item>" & _
"        <Item Value=""T2"">T2</Item>" & _
"		<Item Value=""T3"">T3</Item>" & _
"		<Item Value=""T4"">T4</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>2</SeqNo>" & _
"      <Name>TargetPower</Name>" & _
"      <Description>Target Power (Watts)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>50000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>3</SeqNo>" & _
"      <Name>TargetRampTime</Name>" & _
"      <Description>Target Ramp Time (Secs)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>60</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>4</SeqNo>" & _
"      <Name>TargetVoltageMin</Name>" & _
"      <Description>Target Voltage Min (Volts)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>500</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>5</SeqNo>" & _
"      <Name>TargetVoltageMax</Name>" & _
"      <Description>Target Voltage Max (Volts)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>500</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>6</SeqNo>" & _
"      <Name>TargetC1</Name>" & _
"      <Description>Target C1 (%)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100</Max>" & _
"      <Default>50</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>7</SeqNo>" & _
"      <Name>TargetC2</Name>" & _
"      <Description>Target C2 (%)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100</Max>" & _
"      <Default>50</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>8</SeqNo>" & _
"      <Name>TargetMatchingMode</Name>" & _
"      <Description>Target Match Mode</Description>" & _
"      <Default>Auto</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Auto</Item>" & _
"        <Item Value=""false"">Manual</Item>" & _
"      </DisplayItems>" & _
"    </Parameter> " & _
"	<Parameter>" & _
"      <SeqNo>9</SeqNo>" & _
"      <Name>TargetShutterOpen</Name>" & _
"      <Description>Target Shutter Open</Description>" & _
"      <Default>Yes</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"  </ParameterList>" & _
"  <ParameterList Id=""7"" isGroup=""1"" Group=""DCTargetPower"" GroupName=""DC Target Power"" ShowInUI=""True"">" & _
"    <Parameter>" & _
"      <SeqNo>1</SeqNo>" & _
"      <Name>TargetSelection</Name>" & _
"      <Description>Target Selection (1-4)</Description>" & _
"      <Default>T4</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""T1"">T1</Item>" & _
"        <Item Value=""T2"">T2</Item>" & _
"		<Item Value=""T3"">T3</Item>" & _
"		<Item Value=""T4"">T4</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>2</SeqNo>" & _
"      <Name>TargetPower</Name>" & _
"      <Description>Target Power (Watts)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>50000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>3</SeqNo>" & _
"      <Name>TargetRampTime</Name>" & _
"      <Description>Target Ramp Time (Secs)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>60</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>4</SeqNo>" & _
"      <Name>TargetPulseFrequency</Name>" & _
"      <Description>Target Pulse Frequency (kHz)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>5</SeqNo>" & _
"      <Name>TargetPulseWidth</Name>" & _
"      <Description>Target Pulse Width (ns)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>6</SeqNo>" & _
"      <Name>TargetShutterOpen</Name>" & _
"      <Description>Target Shutter Open</Description>" & _
"      <Default>Yes</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"  </ParameterList>" & _
"  <ParameterList Id=""8"" isGroup=""1"" Group=""SubstratePower"" GroupName=""Substrate Power"" ShowInUI=""True"">" & _
"    <Parameter>" & _
"      <SeqNo>1</SeqNo>" & _
"      <Name>ControlMode</Name>" & _
"      <Description>Control Mode</Description>" & _
"      <Default>Power</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""Power"">Power</Item>" & _
"        <Item Value=""Voltage"">Voltage</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>2</SeqNo>" & _
"      <Name>BiasPower</Name>" & _
"      <Description>Bias Power (Watts)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>50000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>3</SeqNo>" & _
"      <Name>BiasVoltage</Name>" & _
"      <Description>Bias Voltage (Volts)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>500</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>4</SeqNo>" & _
"      <Name>BiasVoltageMin</Name>" & _
"      <Description>Bias Voltage Min (Volts)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>500</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>5</SeqNo>" & _
"      <Name>BiasVoltageMax</Name>" & _
"      <Description>Bias Voltage Max (Volts)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>500</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>	" & _
"    <Parameter>" & _
"      <SeqNo>6</SeqNo>" & _
"      <Name>SubGrounded</Name>" & _
"      <Description>Sub. Grounded</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"" SeqNoDisable=""2,3"" SeqNoCalculate=""2=0;3=0"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>    " & _
"  </ParameterList>" & _
"  <ParameterList Id=""9"" isGroup=""1"" Group=""MotionControl"" GroupName=""Motion Control"" ShowInUI=""True"">" & _
"	<Parameter>" & _
"      <SeqNo>1</SeqNo>" & _
"      <Name>TableRotationSpeed</Name>" & _
"      <Description>Table Rotation Speed (Rpm)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>15</Max>" & _
"      <Default>5</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>2</SeqNo>" & _
"      <Name>TableHeight</Name>" & _
"      <Description>Table Height (mm)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>500</Max>" & _
"      <Default>30</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"  </ParameterList>" & _
"<ParameterList Id=""10"" isGroup=""1"" Group=""FilMetricControl"" GroupName=""Thickness Monitor"" ShowInUI=""True"">" & _
"	<Parameter>" & _
"      <SeqNo>1</SeqNo>" & _
"      <Name>RecipeName</Name>" & _
"      <Description>Recipe Name</Description>" & _
"      <Default></Default>" & _
"      <Unit>String</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>2</SeqNo>" & _
"      <Name>WaferThickness</Name>" & _
"      <Description>Wafer Thickness (?)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>5000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>3</SeqNo>" & _
"      <Name>DelayTimes</Name>" & _
"      <Description>Delay Times (Secs)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>1000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"  </ParameterList>     " & _
"</RecipeDef>"
End Class
End Namespace
