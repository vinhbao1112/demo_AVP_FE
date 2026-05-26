Namespace XMLResources
Public Class DCPVD
Public Const XMLText as String = _
"<RecipeDef>" & _
"  <ParameterList Id=""1"" isGroup=""1"" Group=""Version_Control"" GroupName=""Version_Control"" ShowInUI=""False"">" & _
"    <Parameter>" & _
"      <SeqNo>1</SeqNo>" & _
"      <Name>(c)1999-2001 Veeco Instruments Inc.</Name>" & _
"      <Description>(c)1999-2001 Veeco Instruments Inc.</Description>" & _
"      <Default></Default>" & _
"      <Unit>String</Unit>" & _
"      <ShowInUI>False</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>2</SeqNo>" & _
"      <Name>IBD Process File Version 15.00</Name>" & _
"      <Description>IBD Process File Version 15.00</Description>" & _
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
"     <Parameter>" & _
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
"      <Description>Gas1</Description>" & _
"      <Min>0</Min>" & _
"      <Max>1000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>2</SeqNo>" & _
"      <Name>Gas2</Name>" & _
"      <Description>Gas2</Description>" & _
"      <Min>0</Min>" & _
"      <Max>1000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>3</SeqNo>" & _
"      <Name>Gas3</Name>" & _
"      <Description>Gas3</Description>" & _
"      <Min>0</Min>" & _
"      <Max>1000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>4</SeqNo>" & _
"      <Name>Gas4</Name>" & _
"      <Description>Gas4</Description>" & _
"      <Min>0</Min>" & _
"      <Max>1000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>5</SeqNo>" & _
"      <Name>Gas5</Name>" & _
"      <Description>Gas5</Description>" & _
"      <Min>0</Min>" & _
"      <Max>1000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>   " & _
"  </ParameterList>" & _
"  <ParameterList Id=""3"" isGroup=""1"" Group=""ProcessControl"" GroupName=""ProcessControl"" ShowInUI=""True"">" & _
"     <Parameter>" & _
"      <SeqNo>1</SeqNo>" & _
"      <Name>BaratronPressure</Name>" & _
"      <Description>BaratronPressure</Description>" & _
"      <Min>0</Min>" & _
"      <Max>1000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>2</SeqNo>" & _
"      <Name>ProcessTime</Name>" & _
"      <Description>ProcessTime</Description>" & _
"      <Min>0</Min>" & _
"      <Max>1000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>3</SeqNo>" & _
"      <Name>RampTime</Name>" & _
"      <Description>RampTime</Description>" & _
"      <Min>0</Min>" & _
"      <Max>1000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"    <Parameter>" & _
"      <SeqNo>4</SeqNo>" & _
"      <Name>VatPressure</Name>" & _
"      <Description>VatPressure</Description>" & _
"      <Min>0</Min>" & _
"      <Max>1000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>    	  	" & _
"    <Parameter>" & _
"      <SeqNo>5</SeqNo>" & _
"      <Name>OpenShutter</Name>" & _
"      <Description>OpenShutter</Description>" & _
"      <Default>False</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>" & _
"     <Parameter>" & _
"      <SeqNo>6</SeqNo>" & _
"      <Name>DepHeight</Name>" & _
"      <Description>DepHeight</Description>" & _
"      <Min>0</Min>" & _
"      <Max>1000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>    	" & _
"     <Parameter>" & _
"      <SeqNo>7</SeqNo>" & _
"      <Name>DepPower</Name>" & _
"      <Description>DepPower</Description>" & _
"      <Min>0</Min>" & _
"      <Max>1000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>    	" & _
"    <Parameter>" & _
"      <SeqNo>7</SeqNo>" & _
"      <Name>DepVoltage</Name>" & _
"      <Description>DepVoltage</Description>" & _
"      <Min>0</Min>" & _
"      <Max>1000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>    " & _
"     <Parameter>" & _
"      <SeqNo>8</SeqNo>" & _
"      <Name>PowerDown</Name>" & _
"      <Description>PowerDown</Description>" & _
"      <Default>False</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>    " & _
"    <Parameter>" & _
"      <SeqNo>9</SeqNo>" & _
"      <Name>BiasControl</Name>" & _
"      <Description>BiasControl</Description>" & _
"      <Default>Power</Default>" & _
"      <Unit>String</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>       " & _
"     <Parameter>" & _
"      <SeqNo>10</SeqNo>" & _
"      <Name>BiasMatchingModeAuto</Name>" & _
"      <Description>BiasMatchingModeAuto</Description>" & _
"      <Default>False</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>    " & _
"    <Parameter>" & _
"      <SeqNo>11</SeqNo>" & _
"      <Name>BiasC1</Name>" & _
"      <Description>BiasC1</Description>" & _
"      <Min>0</Min>" & _
"      <Max>1000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>   " & _
"    <Parameter>" & _
"      <SeqNo>12</SeqNo>" & _
"      <Name>BiasC2</Name>" & _
"      <Description>BiasC2</Description>" & _
"      <Min>0</Min>" & _
"      <Max>1000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>   " & _
"    <Parameter>" & _
"      <SeqNo>13</SeqNo>" & _
"      <Name>TargetPower</Name>" & _
"      <Description>TargetPower</Description>" & _
"      <Min>0</Min>" & _
"      <Max>1000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>  " & _
"     <Parameter>" & _
"      <SeqNo>14</SeqNo>" & _
"      <Name>MagnetronStateOn</Name>" & _
"      <Description>MagnetronStateOn</Description>" & _
"      <Default>False</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>    " & _
"    <Parameter>" & _
"      <SeqNo>15</SeqNo>" & _
"      <Name>MagnetStateOn</Name>" & _
"      <Description>MagnetStateOn</Description>" & _
"      <Default>False</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>     " & _
"     <Parameter>" & _
"      <SeqNo>16</SeqNo>" & _
"      <Name>MagCurrent</Name>" & _
"      <Description>MagCurrent</Description>" & _
"      <Min>0</Min>" & _
"      <Max>1000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>  " & _
"    <Parameter>" & _
"      <SeqNo>17</SeqNo>" & _
"      <Name>MagFrequency</Name>" & _
"      <Description>MagFrequency</Description>" & _
"      <Min>0</Min>" & _
"      <Max>1000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>  " & _
"    <Parameter>" & _
"      <SeqNo>18</SeqNo>" & _
"      <Name>MagnetDutyCycle</Name>" & _
"      <Description>MagnetDutyCycle</Description>" & _
"      <Min>0</Min>" & _
"      <Max>1000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>              " & _
"    <Parameter>" & _
"      <SeqNo>19</SeqNo>" & _
"      <Name>Pulse</Name>" & _
"      <Description>Pulse</Description>" & _
"      <Default>False</Default>" & _
"      <Unit>Boolean</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>  " & _
"    <Parameter>" & _
"      <SeqNo>20</SeqNo>" & _
"      <Name>TargetC1</Name>" & _
"      <Description>TargetC1</Description>" & _
"      <Min>0</Min>" & _
"      <Max>1000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>      " & _
"    <Parameter>" & _
"      <SeqNo>21</SeqNo>" & _
"      <Name>TargetC2</Name>" & _
"      <Description>TargetC2</Description>" & _
"      <Min>0</Min>" & _
"      <Max>1000</Max>" & _
"      <Default>0</Default>" & _
"      <Unit>Number</Unit>" & _
"      <ShowInUI>True</ShowInUI>" & _
"    </Parameter>      " & _
"  </ParameterList>" & _
" </RecipeDef>"
End Class
End Namespace
