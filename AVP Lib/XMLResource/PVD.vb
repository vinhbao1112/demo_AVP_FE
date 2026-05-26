Namespace XMLResources
Public Class PVD
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
"      <Name>PVD Process File Version 1.00</Name>" & _
"      <Description>PVD Process File Version 1.00</Description>" & _
"      <Default></Default>" & _
"      <Unit>String</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>3</SeqNo>" & _
"      <Name>StepName</Name>" & _
"      <Description></Description>" & _
"      <Default></Default>" & _
"      <Unit>String</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>4</SeqNo>" & _
"      <Name>StepDescription</Name>" & _
"      <Description></Description>" & _
"      <Default></Default>" & _
"      <Unit>String</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"    </Parameter>" & _
"  </ParameterList>" & _
"  <ParameterList Id=""2"" isGroup=""1"" Group=""Gases"" GroupName=""Gases_Control"" ShowInUI=""True"">" & _
"    <Parameter>" & _
"      <SeqNo>1</SeqNo>" & _
"      <Name>Gas1</Name>" & _
"      <Description>Gas 1 (sccm)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>2</SeqNo>" & _
"      <Name>Gas2</Name>" & _
"      <Description>Gas 2 (sccm)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>3</SeqNo>" & _
"      <Name>Gas3</Name>" & _
"      <Description>Gas 3 (sccm)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>4</SeqNo>" & _
"      <Name>Gas4</Name>" & _
"      <Description>Gas 4 (sccm)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>5</SeqNo>" & _
"      <Name>Gas5</Name>" & _
"      <Description>Back Side Cooling (sccm)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"  </ParameterList>" & _
"  <ParameterList Id=""3"" isGroup=""1"" Group=""ProcessControl"" GroupName=""ProcessControl"" ShowInUI=""True"">" & _
"    <Parameter>" & _
"      <SeqNo>1</SeqNo>" & _
"      <Name>ProcessTime</Name>" & _
"      <Description>Process Time (sec)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>36000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>2</SeqNo>" & _
"      <Name>RampTime</Name>" & _
"      <Description>Ramp Up Time (sec)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"      <Parameter>" & _
"      <SeqNo>3</SeqNo>" & _
"      <Name>ProcessPressure</Name>" & _
"      <Description>Process Pressure (mtorr)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>4</SeqNo>" & _
"      <Name>ProcessStartPressure</Name>" & _
"      <Description>Process Start Pressure (torr)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100</Max>" & _
"      <Default>5.00E-07</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"     <Parameter>" & _
"      <SeqNo>5</SeqNo>" & _
"      <Name>TargetPower</Name>" & _
"      <Description>Target Power (watts)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>6</SeqNo>" & _
"      <Name>TargetC1</Name>" & _
"      <Description>Target C1 (%)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>7</SeqNo>" & _
"      <Name>TargetC2</Name>" & _
"      <Description>Target C2 (%)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100</Max>" & _
"      <Default>0</Default>" & _
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
"        <Item Value=""True"">Auto</Item>" & _
"        <Item Value=""False"">Manual</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>   " & _
"    <Parameter>" & _
"      <SeqNo>9</SeqNo>" & _
"      <Name>OpenShutter</Name>" & _
"      <Description>Shutter Position</Description>" & _
"      <Default>Close</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""True"">Open</Item>" & _
"        <Item Value=""False"">Close</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"     <Parameter>" & _
"      <SeqNo>10</SeqNo>" & _
"      <Name>Pulse</Name>" & _
"      <Description>Pulse Mode</Description>" & _
"      <Default>Off</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""True"">On</Item>" & _
"        <Item Value=""False"">Off</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>           " & _
"    <Parameter>" & _
"      <SeqNo>11</SeqNo>" & _
"      <Name>PulseFrequency</Name>" & _
"      <Description>Pulse Frequency (kHz)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>12</SeqNo>" & _
"      <Name>PulseWidth</Name>" & _
"      <Description>Pulse Width (ns)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"    </Parameter>           " & _
"    <Parameter>" & _
"      <SeqNo>13</SeqNo>" & _
"      <Name>ChuckHeight</Name>" & _
"      <Description>Chuck Height (inches)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>4</Max>" & _
"      <Default>1.4</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"     <Parameter>" & _
"      <SeqNo>14</SeqNo>" & _
"      <Name>BiasPower</Name>" & _
"      <Description>Bias Power (watts)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"     <Parameter>" & _
"      <SeqNo>15</SeqNo>" & _
"      <Name>BiasVoltage</Name>" & _
"     <Description>Bias Voltage (volts)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>10000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"     <Parameter>" & _
"      <SeqNo>16</SeqNo>" & _
"      <Name>BiasC1</Name>" & _
"      <Description>Bias C1 (%)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>17</SeqNo>" & _
"      <Name>BiasC2</Name>" & _
"      <Description>Bias C2 (%)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"     <Parameter>" & _
"      <SeqNo>18</SeqNo>" & _
"      <Name>BiasMatchingMode</Name>" & _
"      <Description>Bias Match Mode</Description>" & _
"      <Default>Auto</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""True"">Auto</Item>" & _
"        <Item Value=""False"">Manual</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>19</SeqNo>" & _
"      <Name>BiasC1C2FromRecipe</Name>" & _
"      <Description>BiasC1C2FromRecipe</Description>" & _
"      <Default>Yes</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""True"">Yes</Item>" & _
"        <Item Value=""False"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"     <Parameter>" & _
"      <SeqNo>20</SeqNo>" & _
"      <Name>BiasControl</Name>" & _
"      <Description>Bias Control</Description>" & _
"      <Default>Power</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""Power"">Power</Item>" & _
"        <Item Value=""Voltage"">Voltage</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>21</SeqNo>" & _
"      <Name>PowerDown</Name>" & _
"      <Description>Power Down</Description>" & _
"      <Default>Yes</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""True"">Yes</Item>" & _
"        <Item Value=""False"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>22</SeqNo>" & _
"      <Name>MagnetState</Name>" & _
"      <Description>Parallel Magnet State</Description>" & _
"      <Default>Off</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""True"">On</Item>" & _
"        <Item Value=""False"">Off</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"      <Parameter>" & _
"      <SeqNo>23</SeqNo>" & _
"      <Name>MagCurrent</Name>" & _
"      <Description>Parallel Magnet Current (amps)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>20</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>24</SeqNo>" & _
"      <Name>MagnetDutyCycle</Name>" & _
"      <Description>Parallel Magnet Duty Cycle (%)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>  " & _
"    <Parameter>" & _
"      <SeqNo>25</SeqNo>" & _
"      <Name>MagFrequency</Name>" & _
"      <Description>Parallel Magnet Frequency (hz)</Description>" & _
"      <Min>0</Min>" & _
"      <Max>100</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter> " & _
"    <Parameter>" & _
"      <SeqNo>26</SeqNo>" & _
"      <Name>IsStabilize</Name>" & _
"      <Description>IsStabilize</Description>" & _
"      <Default>No</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"      <DisplayItems>" & _
"        <Item Value=""True"">Yes</Item>" & _
"        <Item Value=""False"">No</Item>" & _
"      </DisplayItems>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>27</SeqNo>" & _
"      <Name>RecipeComments</Name>" & _
"      <Description>Recipe Comments</Description>" & _
"      <Default>Comment</Default>" & _
"      <Unit>String</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter> " & _
"    </ParameterList>" & _
"</RecipeDef>"
End Class
End Namespace
