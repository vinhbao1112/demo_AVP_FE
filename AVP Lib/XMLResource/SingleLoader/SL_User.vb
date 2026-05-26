Namespace XMLResources
    Public Class SL_User
        Public Const XMLText As String = _
        "<Users>" & _
        "  <User>" & _
        "    <Username>OPERATOR</Username>" & _
        "    <Password>123</Password>" & _
        "    <Group>2</Group>" & _
        "    <Disable>0</Disable>" & _
        "    <AccessList>" & _
        "      <Access Permit=""1"" Code=""001"" Screen=""Maintenance"" />" & _
        "      <Access Permit=""0"" Code=""003"" Screen=""Diagnostic"" />" & _
        "      <Access Permit=""0"" Code=""004"" Screen=""Recipe Editor"" />" & _
        "      <Access Permit=""1"" Code=""005"" Screen=""I/O Override"" />" & _
        "      <Access Permit=""0"" Code=""007"" Screen=""WaferRun Dialog"" />" & _
        "      <Access Permit=""0"" Code=""008"" Screen=""System Setup"" />" & _
        "      <Access Permit=""1"" Code=""010"" Screen=""Process"">" & _
        "        <Access Permit=""0"" Code=""0101"" Screen=""Reset All Wafer Count"" />" & _
        "        <Access Permit=""0"" Code=""0102"" Screen=""Click Other Buttons"" />" & _
        "      </Access>" & _
        "      <Access Permit=""1"" Code=""011"" Screen=""DataLog"" />" & _
        "      <Access Permit=""0"" Code=""012"" Screen=""User Setup"" />" & _
        "      <Access Permit=""0"" Code=""013"" Screen=""Alarm"" />" & _
        "      <Access Permit=""0"" Code=""021"" Screen=""Exit AVP Software"" />" & _
        "      <Access Permit=""0"" Code=""022"" Screen=""Mark for Return"" />" & _
        "      <Access Permit=""0"" Code=""023"" Screen=""Resume"" />" & _
        "      <Access Permit=""0"" Code=""024"" Screen=""Return"" />" & _
        "    </AccessList>" & _
        "    <RecipePrivilege>" & _
        "      <Recipe Type=""IBE"" Name=""Chamber1"">" & _
        "        <ParameterList Group=""BeamParameters"">" & _
        "          <Parameter>" & _
        "            <Name>Beam_Voltage</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Beam_Current</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Suppresser_Voltage</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Incident_RF_Power</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>PBN_FLOWRATE</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>K</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Neutralizer_On</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>FlowCool_Flowrate</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Continuous_Beam</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "        </ParameterList>" & _
        "        <ParameterList Group=""GasParameters"">" & _
        "          <Parameter>" & _
        "            <Name>Value_1</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Value_2</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Value_3</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Value_4</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Value_5</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "        </ParameterList>" & _
        "        <ParameterList Group=""Control"">" & _
        "          <Parameter>" & _
        "            <Name>Process_Ends_By</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Etch_Time_Hour</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Etch_Time_Min</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Etch_Time_Sec</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Step_Type</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Step_Type</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Source_Gas_Warning</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Source_Gas_Fault</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Process_Pressure_Low</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Process_Pressure_High</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Fixture_Angle</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Use_CAIBE</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>OpenCryoGate</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Open_Shutter_At_Beam</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "        </ParameterList>" & _
        "        <ParameterList Group=""FixtureServo"">" & _
        "          <Parameter>" & _
        "            <Name>Fixture_Rotate_Continious</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Fixture_Rotate_Sweep</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Fixture_Rotate_Static</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Sweep_Start_Angle</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Sweep_End_Angle</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Static_Angle</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Fixture_Rotation_Speed</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "        </ParameterList>" & _
        "      </Recipe>" & _
        "    </RecipePrivilege>" & _
        "  </User>" & _
        "  <User>" & _
        "    <Username>ADMIN</Username>" & _
        "    <Password>123</Password>" & _
        "    <Group>1</Group>" & _
        "    <Disable>0</Disable>" & _
        "    <AccessList>" & _
        "      <Access Permit=""1"" Code=""001"" Screen=""Maintenance"" />" & _
        "      <Access Permit=""1"" Code=""003"" Screen=""Diagnostic"" />" & _
        "      <Access Permit=""1"" Code=""004"" Screen=""Recipe Editor"" />" & _
        "      <Access Permit=""1"" Code=""005"" Screen=""I/O Override"" />" & _
        "      <Access Permit=""1"" Code=""008"" Screen=""System Setup"" />" & _
        "      <Access Permit=""1"" Code=""010"" Screen=""Process"">" & _
        "        <Access Permit=""1"" Code=""0101"" Screen=""Reset All Wafer Count"" />" & _
        "        <Access Permit=""1"" Code=""0102"" Screen=""Click Other Buttons"" />" & _
        "      </Access>" & _
        "      <Access Permit=""1"" Code=""011"" Screen=""DataLog"" />" & _
        "      <Access Permit=""1"" Code=""012"" Screen=""User Setup"" />" & _
        "      <Access Permit=""1"" Code=""013"" Screen=""Alarm"" />" & _
        "      <Access Permit=""1"" Code=""014"" Screen=""Waferflow Editor"" />" & _
        "      <Access Permit=""1"" Code=""021"" Screen=""Exit AVP Software"" />" & _
        "      <Access Permit=""1"" Code=""022"" Screen=""Mark for Return"" />" & _
        "      <Access Permit=""1"" Code=""023"" Screen=""Resume"" />" & _
        "      <Access Permit=""1"" Code=""024"" Screen=""Return"" />" & _
        "    </AccessList>" & _
        "    <RecipePrivilege>" & _
        "      <Recipe Type=""IBE"" Name=""Chamber1"">" & _
        "        <ParameterList Group=""EtchBeamParameters"">" & _
        "          <Parameter>" & _
        "            <Name>Beam_On</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Neutralizer_On</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Beam_Voltage</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Beam_Current</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Incident_RF_Power</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Suppresser_Voltage</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>PBN_FLOWRATE</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>K</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Continuous_Beam</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>CAIBE_Step</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>UseStepRF</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "        </ParameterList>" & _
        "        <ParameterList Group=""DepositionBeamParameters"">" & _
        "          <Parameter>" & _
        "            <Name>Beam_On</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Neutralizer_On</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Beam_Voltage</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Beam_Current</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Incident_RF_Power</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Suppresser_Voltage</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>PBN_FLOWRATE</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>K</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Continuous_Beam</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>UseStepRF</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "        </ParameterList>" & _
        "        <ParameterList Group=""EtchGasParameters"">" & _
        "          <Parameter>" & _
        "            <Name>Value_1</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Value_2</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Value_3</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Value_4</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Value_5</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "        </ParameterList>" & _
        "        <ParameterList Group=""DepositionGasParameters"">" & _
        "          <Parameter>" & _
        "            <Name>Value_1</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Value_2</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Value_3</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Value_4</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Value_5</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "        </ParameterList>" & _
        "        <ParameterList Group=""MagneticChuck"">" & _
        "          <Parameter>" & _
        "            <Name>Power_On</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Phase_90</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Square_Wave</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "        </ParameterList>" & _
        "        <ParameterList Group=""FaultTolerance"">" & _
        "          <Parameter>" & _
        "            <Name>Active</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>AbortOnError</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "        </ParameterList>" & _
        "        <ParameterList Group=""HotChuck"">" & _
        "          <Parameter>" & _
        "            <Name>Active</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>WaitForTemperature</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Temperature</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>TimeInSeconds</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "        </ParameterList>" & _
        "        <ParameterList Group=""Control"">" & _
        "          <Parameter>" & _
        "            <Name>Process_Ends_By</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Endpoint_Script_Name</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>UseElectroStaticShutter</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>UseEtchRateCorrection</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Etch_Rate_Correction_Power_Group</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Etch_Time_Hour</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Etch_Time_Min</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Etch_Time_Sec</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Etch_Time_MilliSec</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Ion_Charge</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Process_Pressure_High</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Process_Pressure_Low</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Fixture_Angle</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Target_Side</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Target_Angle</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>FlowCool_Flowrate</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Open_Etch_Shutter_At_Start</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Open_Etch_Shutter_At_Beam</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Close_Etch_Shutter_At_End</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Open_Depo_Shutter_At_Start</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Open_Depo_Shutter_At_Beam</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Close_Depo_Shutter_At_End</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Open_Target_Shutter_At_Start</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Open_Target_Shutter_At_Beam</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Close_Target_Shutter_At_End</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Open_Fixture_Shutter_At_Start</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Open_Fixture_Shutter_At_Beam</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Close_Fixture_Shutter_At_End</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>OpenTargetShield</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>OpenCryoGate</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>UseRGA</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>WaitForGEMStepTime</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "        </ParameterList>" & _
        "        <ParameterList Group=""FixtureServo"">" & _
        "          <Parameter>" & _
        "            <Name>Fixture_Rotate_Continious</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Fixture_Rotate_Sweep</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Fixture_Rotate_Static</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Sweep_Start_Angle</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Sweep_End_Angle</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Static_Angle</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Fixture_Rotation_Speed</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "        </ParameterList>" & _
        "        <ParameterList Group=""DataTracing"">" & _
        "          <Parameter>" & _
        "            <Name>TracingEnabled</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Interval</Name>" & _
        "            <RW>True</RW>" & _
        "          </Parameter>" & _
        "        </ParameterList>" & _
        "      </Recipe>" & _
        "    </RecipePrivilege>" & _
        "  </User>" & _
        "  <User>" & _
        "    <Username>DEFAULT_DO_NOT_READ_IN_GUI</Username>" & _
        "    <Password>123</Password>" & _
        "    <Group>2</Group>" & _
        "    <Disable>0</Disable>" & _
        "    <AccessList>" & _
        "      <Access Permit=""1"" Code=""001"" DefaultFor=""Engineer,Operator"" Screen=""Maintenance"" />" & _
        "      <Access Permit=""1"" Code=""003"" DefaultFor=""Engineer"" Screen=""Diagnostic"" />" & _
        "      <Access Permit=""1"" Code=""004"" DefaultFor=""Engineer"" Screen=""Recipe Editor"" />" & _
        "      <Access Permit=""1"" Code=""005"" DefaultFor=""Engineer,Operator"" Screen=""I/O Override"" />" & _
        "      <Access Permit=""1"" Code=""007"" DefaultFor=""Engineer"" Screen=""WaferRun Dialog"" />" & _
        "      <Access Permit=""1"" Code=""008"" DefaultFor=""Engineer"" Screen=""System Setup"" />" & _
        "      <Access Permit=""1"" Code=""010"" DefaultFor=""Engineer,Operator"" Screen=""Process"">" & _
        "        <Access Permit=""1"" Code=""0101"" Screen=""Reset All Wafer Count"" />" & _
        "        <Access Permit=""1"" Code=""0102"" Screen=""Click Other Buttons"" />" & _
        "      </Access>" & _
        "      <Access Permit=""1"" Code=""011"" DefaultFor=""Engineer,Operator"" Screen=""DataLog"" />" & _
        "      <Access Permit=""1"" Code=""012"" DefaultFor=""Engineer"" Screen=""User Setup"" />" & _
        "      <Access Permit=""1"" Code=""013"" DefaultFor=""Engineer"" Screen=""Alarm"" />" & _
        "      <Access Permit=""1"" Code=""021"" DefaultFor=""Engineer,Maint"" Screen=""Exit AVP Software"" />" & _
        "      <Access Permit=""1"" Code=""022"" DefaultFor=""Engineer"" Screen=""Mark for Return"" />" & _
        "      <Access Permit=""1"" Code=""023"" DefaultFor=""Engineer"" Screen=""Resume"" />" & _
        "      <Access Permit=""1"" Code=""024"" DefaultFor=""Engineer"" Screen=""Return"" />" & _
        "    </AccessList>" & _
        "   <RecipePrivilege>" & _
        "      <Recipe Type=""IBE"" Name=""Chamber1"">" & _
        "        <ParameterList Group=""EtchBeamParameters"">" & _
        "          <Parameter>" & _
        "            <Name>Beam_On</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Neutralizer_On</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Beam_Voltage</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Beam_Current</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Incident_RF_Power</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Suppresser_Voltage</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>PBN_FLOWRATE</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>K</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Continuous_Beam</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>CAIBE_Step</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>UseStepRF</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "        </ParameterList>" & _
        "        <ParameterList Group=""DepositionBeamParameters"">" & _
        "          <Parameter>" & _
        "            <Name>Beam_On</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Neutralizer_On</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Beam_Voltage</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Beam_Current</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Incident_RF_Power</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Suppresser_Voltage</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>PBN_FLOWRATE</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>K</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Continuous_Beam</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>UseStepRF</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "        </ParameterList>" & _
        "        <ParameterList Group=""EtchGasParameters"">" & _
        "          <Parameter>" & _
        "            <Name>Value_1</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Value_2</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Value_3</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Value_4</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Value_5</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "        </ParameterList>" & _
        "        <ParameterList Group=""DepositionGasParameters"">" & _
        "          <Parameter>" & _
        "            <Name>Value_1</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Value_2</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Value_3</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Value_4</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Value_5</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "        </ParameterList>" & _
        "        <ParameterList Group=""MagneticChuck"">" & _
        "          <Parameter>" & _
        "            <Name>Power_On</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Phase_90</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Square_Wave</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "        </ParameterList>" & _
        "        <ParameterList Group=""FaultTolerance"">" & _
        "          <Parameter>" & _
        "            <Name>Active</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>AbortOnError</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "        </ParameterList>" & _
        "        <ParameterList Group=""HotChuck"">" & _
        "          <Parameter>" & _
        "            <Name>Active</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>WaitForTemperature</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Temperature</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>TimeInSeconds</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "        </ParameterList>" & _
        "        <ParameterList Group=""Control"">" & _
        "          <Parameter>" & _
        "            <Name>Process_Ends_By</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Endpoint_Script_Name</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>UseElectroStaticShutter</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>UseEtchRateCorrection</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Etch_Rate_Correction_Power_Group</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Etch_Time_Hour</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Etch_Time_Min</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Etch_Time_Sec</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Etch_Time_MilliSec</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Ion_Charge</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Process_Pressure_High</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Process_Pressure_Low</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Fixture_Angle</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Target_Side</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Target_Angle</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>FlowCool_Flowrate</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Open_Etch_Shutter_At_Start</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Open_Etch_Shutter_At_Beam</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Close_Etch_Shutter_At_End</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Open_Depo_Shutter_At_Start</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Open_Depo_Shutter_At_Beam</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Close_Depo_Shutter_At_End</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Open_Target_Shutter_At_Start</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Open_Target_Shutter_At_Beam</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Close_Target_Shutter_At_End</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Open_Fixture_Shutter_At_Start</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Open_Fixture_Shutter_At_Beam</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Close_Fixture_Shutter_At_End</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>OpenTargetShield</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>OpenCryoGate</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>UseRGA</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>WaitForGEMStepTime</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "        </ParameterList>" & _
        "        <ParameterList Group=""FixtureServo"">" & _
        "          <Parameter>" & _
        "            <Name>Fixture_Rotate_Continious</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Fixture_Rotate_Sweep</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Fixture_Rotate_Static</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Sweep_Start_Angle</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Sweep_End_Angle</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Static_Angle</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Fixture_Rotation_Speed</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "        </ParameterList>" & _
        "        <ParameterList Group=""DataTracing"">" & _
        "          <Parameter>" & _
        "            <Name>TracingEnabled</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "          <Parameter>" & _
        "            <Name>Interval</Name>" & _
        "            <RW DefaultFor=""Engineer"">True</RW>" & _
        "          </Parameter>" & _
        "        </ParameterList>" & _
        "      </Recipe>" & _
        "    </RecipePrivilege>" & _
        "  </User>" & _
        " " & _
        "</Users>"
    End Class
End Namespace
