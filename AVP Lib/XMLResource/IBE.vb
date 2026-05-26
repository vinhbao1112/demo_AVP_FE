Namespace XMLResources
Public Class IBE
Public Const XMLText as String = _
"<RecipeDef>" & _
"  <ParameterList Id=""1"" isGroup=""1"" Group=""Version_Control"" GroupName=""Version_Control"" ShowInUI=""False"">" & _
"    <Parameter>" & _
"      <SeqNo>1</SeqNo>" & _
"      <Name>(c)2010 AVP Technology, LLC</Name>" & _
"      <Description>(c)2010 AVP Technology, LLC</Description>" & _
"      <Default></Default>" & _
"      <Unit>String</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>2</SeqNo>" & _
"      <Name>IBE Process File Version 4.03</Name>" & _
"      <Description>IBE Process File Version 4.03</Description>" & _
"      <Default></Default>" & _
"      <Unit>String</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"    </Parameter>" & _
"  </ParameterList>" & _
"  <ParameterList Id=""2"" isGroup=""1"" Group=""EtchBeamParameters"" GroupName=""EtchBeamParameters"" ShowInUI=""True"">" & _
"     <Parameter>" & _
"      <SeqNo>1</SeqNo>" & _
"      <Name>Beam_On</Name>" & _
"      <Description>Beam_On</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"       <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"     <Parameter>" & _
"      <SeqNo>2</SeqNo>" & _
"      <Name>Neutralizer_On</Name>" & _
"      <Description>Neutralizer_On</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>3</SeqNo>" & _
"      <Name>Beam_Voltage</Name>" & _
"      <Description>Beam_Voltage (V)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>1000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>4</SeqNo>" & _
"      <Name>Beam_Current</Name>" & _
"      <Description>Beam_Current (mA)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>1000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"     <Parameter>" & _
"      <SeqNo>5</SeqNo>" & _
"      <Name>Incident_RF_Power</Name>" & _
"        <Description>Incident_RF_Power (W)</Description>" & _
"        <Min>0</Min>" & _
"        <Max>1000</Max>" & _
"        <Default>0</Default>" & _
"        <Unit>Number</Unit>" & _
"        <ShowInUI>True</ShowInUI>" & _
"      </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>6</SeqNo>" & _
"      <Name>Suppresser_Voltage</Name>" & _
"        <Description>Suppressor_Voltage (V)</Description>" & _
"        <Min>0</Min>" & _
"        <Max>1000</Max>" & _
"        <Default>0</Default>" & _
"        <Unit>Number</Unit>" & _
"        <ShowInUI>True</ShowInUI>" & _
"      </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>7</SeqNo>" & _
"      <Name>PBN_FLOWRATE</Name>" & _
"      <Description>PBN_FLOWRATE ({0})(sccm)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>8</SeqNo>" & _
"      <Name>K_Factor</Name>" & _
"      <Description>K_Factor</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>9</SeqNo>" & _
"      <Name>Source_Electromagnet_Current</Name>" & _
"      <Description>Source_Electromagnet_Current (A)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>500</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>10</SeqNo>" & _
"      <Name>Continuous_Beam</Name>" & _
"      <Description>Continuous_Beam</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"     <Parameter>" & _
"      <SeqNo>11</SeqNo>" & _
"      <Name>CAIBE_Step</Name>" & _
"      <Description>CAIBE_Step</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"     <Parameter>" & _
"      <SeqNo>12</SeqNo>" & _
"      <Name>UseStepRF</Name>" & _
"      <Description>Use_Step_RF</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>	" & _
"  </ParameterList>" & _
"  <ParameterList Id=""3"" isGroup=""1"" Group=""EtchGasParameters"" GroupName=""EtchGasParameters"" ShowInUI=""True"">" & _
"    <Parameter>" & _
"      <SeqNo>1</SeqNo>" & _
"      <Name>Gas1</Name>" & _
"      <Description>Gas_1 ({0})(sccm)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>2</SeqNo>" & _
"      <Name>Gas2</Name>" & _
"      <Description>Gas_2 ({0})(sccm)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>3</SeqNo>" & _
"      <Name>Gas3</Name>" & _
"      <Description>Gas_3 ({0})(sccm)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>4</SeqNo>" & _
"      <Name>Gas4</Name>" & _
"      <Description>Gas_4 ({0})(sccm)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>5</SeqNo>" & _
"      <Name>Gas5</Name>" & _
"      <Description>Gas_5 ({0})(sccm)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"  </ParameterList>" & _
"  <ParameterList Id=""4"" isGroup=""1"" Group=""Control"" GroupName=""Control"" ShowInUI=""True"">" & _
"    <Parameter>" & _
"      <SeqNo>1</SeqNo>" & _
"      <Name>Process_Ends_By</Name>" & _
"      <Description>Process_Ends_By</Description>" & _
"      <Default>Time</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""Time"" SeqNoDisable=""2,7"">Time</Item>" & _
"		<Item Value=""Time-%PSR"" SeqNoDisable=""2,6"">Time - %PSR</Item>" & _
"        <Item Value=""Endpoint"" SeqNoDisable=""7"">Endpoint</Item>" & _
"		<Item Value=""EPMonitor"" SeqNoDisable=""7"">EP Monitor</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>2</SeqNo>" & _
"      <Name>Endpoint_Script_Name</Name>" & _
"      <Description>Endpoint_Script_Name</Description>" & _
"      <Default></Default>" & _
"      <Unit>String</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"     <Parameter>" & _
"      <SeqNo>3</SeqNo>" & _
"      <Name>UseElectroStaticShutter</Name>" & _
"      <Description>UseElectroStaticShutter</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>4</SeqNo>" & _
"      <Name>UseEtchRateCorrection</Name>" & _
"      <Description>UseEtchRateCorrection</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"     <Parameter>" & _
"      <SeqNo>5</SeqNo>" & _
"      <Name>Etch_Rate_Correction_Power_Group</Name>" & _
"      <Description>Etch_Rate_Correction_Power_Group</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>6</SeqNo>" & _
"      <Name>Etch_Time_Hour</Name>" & _
"      <Description>Etch_Time_Hour (hours)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>7</SeqNo>" & _
"      <Name>Etch_Time_Min</Name>" & _
"      <Description>Etch_Time_Min (minutes)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>8</SeqNo>" & _
"      <Name>Etch_Time_Sec</Name>" & _
"      <Description>Etch_Time_Sec (seconds)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>9</SeqNo>" & _
"      <Name>Etch_Time_MilliSec</Name>" & _
"      <Description>Etch_Time_MilliSec (miliseconds)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"    </Parameter>" & _
"	 <Parameter>" & _
"      <SeqNo>10</SeqNo>" & _
"      <Name>Etch_Percentage_PSR</Name>" & _
"      <Description>Etch_Percentage_PSR</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>11</SeqNo>" & _
"      <Name>Step_Type</Name>" & _
"      <Description>Step_Type</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>12</SeqNo>" & _
"      <Name>Source_Gas_Warning</Name>" & _
"      <Description>Source_Gas_Warning</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>13</SeqNo>" & _
"      <Name>Source_Gas_Fault</Name>" & _
"      <Description>Source_Gas_Fault</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>14</SeqNo>" & _
"      <Name>Process_Pressure_High</Name>" & _
"      <Description>Process_Pressure_High</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0.1</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>15</SeqNo>" & _
"      <Name>Process_Pressure_Low</Name>" & _
"      <Description>Process_Pressure_Low</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0.000001</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>16</SeqNo>" & _
"      <Name>IG_On</Name>" & _
"      <Description>IG_On</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>17</SeqNo>" & _
"      <Name>RIBE</Name>" & _
"      <Description>RIBE</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>18</SeqNo>" & _
"      <Name>Fixture_Angle</Name>" & _
"      <Description>Fixture_Angle (degree)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>360</Max>" & _
"      <Default>90</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>19</SeqNo>" & _
"      <Name>FlowCool_Flowrate</Name>" & _
"      <Description>FlowCool_Flowrate ({0})(sccm)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>    " & _
"    <Parameter>" & _
"      <SeqNo>20</SeqNo>" & _
"      <Name>Open_Etch_Shutter_At_Start</Name>" & _
"      <Description>Open_Etch_Shutter_At_Start</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>21</SeqNo>" & _
"      <Name>Open_Etch_Shutter_At_Beam</Name>" & _
"      <Description>Open_Etch_Shutter_At_Beam</Description>" & _
"      <Default>Yes</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>22</SeqNo>" & _
"      <Name>Close_Etch_Shutter_At_End</Name>" & _
"      <Description>Close_Etch_Shutter_At_End</Description>" & _
"      <Default>Yes</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>23</SeqNo>" & _
"      <Name>Open_Target_Shutter_At_Start</Name>" & _
"      <Description>Open_Target_Shutter_At_Start</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>24</SeqNo>" & _
"      <Name>Open_Target_Shutter_At_Beam</Name>" & _
"      <Description>Open_Target_Shutter_At_Beam</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>25</SeqNo>" & _
"      <Name>Close_Target_Shutter_At_End</Name>" & _
"      <Description>Close_Target_Shutter_At_End</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>26</SeqNo>" & _
"      <Name>Open_Fixture_Shutter_At_Start</Name>" & _
"      <Description>Open_Fixture_Shutter_At_Start</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>27</SeqNo>" & _
"      <Name>Open_Fixture_Shutter_At_Beam</Name>" & _
"      <Description>Open_Fixture_Shutter_At_Beam</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>28</SeqNo>" & _
"      <Name>Close_Fixture_Shutter_At_End</Name>" & _
"      <Description>Close_Fixture_Shutter_At_End</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>29</SeqNo>" & _
"      <Name>OpenTargetShield</Name>" & _
"      <Description>Open_Target_Shield</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>30</SeqNo>" & _
"      <Name>OpenCryoGate</Name>" & _
"      <Description>Open_Cryo_Gate</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"  </ParameterList>" & _
"  <ParameterList Id=""5"" isGroup=""1"" Group=""TiltSweep"" GroupName=""TiltSweep"" ShowInUI=""True"">" & _
"   <Parameter>" & _
"      <SeqNo>1</SeqNo>" & _
"      <Name>Fixture_Tilt</Name>" & _
"      <Description>Fixture_Tilt</Description>" & _
"      <Default>Static</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""Static"" SeqNoDisable=""2,3,4"">Static</Item>" & _
"        <Item Value=""Sweep"" SeqNoDisable=""Control:18"" SeqNoCalculate=""Control:18=String.Empty"">Sweep</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>2</SeqNo>" & _
"      <Name>Tilt_Sweep_Start_Angle</Name>" & _
"      <Description>Tilt_Sweep_Start_Angle (degree)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>360</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>3</SeqNo>" & _
"      <Name>Tilt_Sweep_End_Angle</Name>" & _
"      <Description>Tilt_Sweep_End_Angle (degree)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>360</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>4</SeqNo>" & _
"      <Name>Tilt_Sweep_Dwell_Time</Name>" & _
"      <Description>Tilt_Sweep_Dwell_Time (seconds)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"  </ParameterList>" & _
"  <ParameterList Id=""6"" isGroup=""1"" Group=""FixtureServo"" GroupName=""FixtureServo"" ShowInUI=""True"">" & _
"    <Parameter>" & _
"      <SeqNo>1</SeqNo>" & _
"      <Name>Fixture_Rotate</Name>" & _
"      <Description>Fixture_Rotate</Description>" & _
"      <Default>Continuous</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""Continuous"" SeqNoDisable=""2,3,4,6"">Continuous</Item>" & _
"        <Item Value=""Sweep"" SeqNoDisable=""4,5"">Sweep</Item>" & _
"        <Item Value=""Static"" SeqNoDisable=""2,3,5,6"">Static</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>2</SeqNo>" & _
"      <Name>Fixture_Rotate_Sweep</Name>" & _
"      <Description>Fixture_Rotate_Sweep</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>3</SeqNo>" & _
"      <Name>Fixture_Rotate_Static</Name>" & _
"      <Description>Fixture_Rotate_Static</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>4</SeqNo>" & _
"      <Name>Sweep_Start_Angle</Name>" & _
"      <Description>Sweep_Start_Angle (degree)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>360</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>5</SeqNo>" & _
"      <Name>Sweep_End_Angle</Name>" & _
"      <Description>Sweep_End_Angle (degree)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>360</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>6</SeqNo>" & _
"      <Name>Static_Angle</Name>" & _
"      <Description>Static_Angle (degree)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>360</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>7</SeqNo>" & _
"      <Name>Fixture_Rotation_Speed</Name>" & _
"      <Description>Fixture_Rotation_Speed</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100000</Max>" & _
"      <Default>10</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"	<Parameter>" & _
"      <SeqNo>8</SeqNo>" & _
"      <Name>Sweep_Dwell_Time</Name>" & _
"      <Description>Sweep_Dwell_Time (seconds)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100000</Max>" & _
"      <Default>4</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"  </ParameterList>" & _
"  <ParameterList Id=""7"" isGroup=""1"" Group=""DataTracing"" GroupName=""DataTracing"" ShowInUI=""True"">" & _
"    <Parameter>" & _
"      <SeqNo>1</SeqNo>" & _
"      <Name>TracingEnabled</Name>" & _
"      <Description>Enable Tracing</Description>" & _
"      <Default>Yes</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""true"">Yes</Item>" & _
"        <Item Value=""false"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>2</SeqNo>" & _
"      <Name>Interval</Name>" & _
"      <Description>Interval (s)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>2</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"  </ParameterList>" & _
"</RecipeDef>"
End Class
End Namespace
