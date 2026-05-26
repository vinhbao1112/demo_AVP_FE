Public Class GeneralRecipe
    Inherits BaseRecipe

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Change description of recipe base on configuration data
    ''' </summary>
    Protected Overrides Function ChangeDescription(ByVal groupCode As String, ByVal parameterName As String, ByRef parameterDescription As String, ByRef saveNotShow As Boolean, ByVal baseConfigData As BaseConfigurationData) As Boolean
        Dim result As Boolean = True

        Try
            If baseConfigData Is Nothing Then
                result = False
                Exit Try
            End If

            Dim generalConfigData As GeneralConfigurationData = CType(baseConfigData, GeneralConfigurationData)

            Select Case parameterName
                Case HConstants.Gas1
                    parameterDescription = String.Format(parameterDescription, generalConfigData.Gas1MFCEnable_CalibrationFactorId)
                    saveNotShow = (generalConfigData.Gas1MFCEnable_HasShutOffValve = False And generalConfigData.Gas1MFCEnable_HasSupplyValve = False)
                    result = Not saveNotShow

                Case HConstants.Gas2
                    parameterDescription = String.Format(parameterDescription, generalConfigData.Gas2MFCEnable_CalibrationFactorId)
                    saveNotShow = (generalConfigData.Gas2MFCEnable_HasShutOffValve = False And generalConfigData.Gas2MFCEnable_HasSupplyValve = False)
                    result = Not saveNotShow

                Case HConstants.Gas3
                    parameterDescription = String.Format(parameterDescription, generalConfigData.Gas3MFCEnable_CalibrationFactorId)
                    saveNotShow = (generalConfigData.Gas3MFCEnable_HasShutOffValve = False And generalConfigData.Gas3MFCEnable_HasSupplyValve = False)
                    result = Not saveNotShow

                Case HConstants.Gas4
                    parameterDescription = String.Format(parameterDescription, generalConfigData.Gas4MFCEnable_CalibrationFactorId)
                    saveNotShow = (generalConfigData.Gas4MFCEnable_HasShutOffValve = False And generalConfigData.Gas4MFCEnable_HasSupplyValve = False)
                    result = Not saveNotShow

                Case HConstants.Gas5
                    parameterDescription = String.Format(parameterDescription, generalConfigData.Gas5MFCEnable_CalibrationFactorId)
                    saveNotShow = (generalConfigData.Gas5MFCEnable_HasShutOffValve = False And generalConfigData.Gas5MFCEnable_HasSupplyValve = False)
                    result = Not saveNotShow

                Case HConstants.Gas6
                    parameterDescription = String.Format(parameterDescription, generalConfigData.Gas6MFCEnable_CalibrationFactorId)
                    saveNotShow = (generalConfigData.Gas6MFCEnable_HasShutOffValve = False And generalConfigData.Gas6MFCEnable_HasSupplyValve = False)
                    result = Not saveNotShow

                Case HConstants.Gas7
                    parameterDescription = String.Format(parameterDescription, generalConfigData.Gas7MFCEnable_CalibrationFactorId)
                    saveNotShow = (generalConfigData.Gas7MFCEnable_HasShutOffValve = False And generalConfigData.Gas7MFCEnable_HasSupplyValve = False)
                    result = Not saveNotShow

                Case HConstants.Gas8
                    parameterDescription = String.Format(parameterDescription, generalConfigData.Gas8MFCEnable_CalibrationFactorId)
                    saveNotShow = (generalConfigData.Gas8MFCEnable_HasShutOffValve = False And generalConfigData.Gas8MFCEnable_HasSupplyValve = False)
                    result = Not saveNotShow

                Case HConstants.Gas9
                    parameterDescription = String.Format(parameterDescription, generalConfigData.Gas9MFCEnable_CalibrationFactorId)
                    saveNotShow = (generalConfigData.Gas9MFCEnable_HasShutOffValve = False And generalConfigData.Gas9MFCEnable_HasSupplyValve = False)
                    result = Not saveNotShow

                Case HConstants.Gas10
                    parameterDescription = String.Format(parameterDescription, generalConfigData.Gas10MFCEnable_CalibrationFactorId)
                    saveNotShow = (generalConfigData.Gas10MFCEnable_HasShutOffValve = False And generalConfigData.Gas10MFCEnable_HasSupplyValve = False)
                    result = Not saveNotShow

                Case HConstants.Gas11
                    parameterDescription = String.Format(parameterDescription, generalConfigData.Gas11MFCEnable_CalibrationFactorId)
                    saveNotShow = (generalConfigData.Gas11MFCEnable_HasShutOffValve = False And generalConfigData.Gas11MFCEnable_HasSupplyValve = False)
                    result = Not saveNotShow

                Case HConstants.Gas12
                    parameterDescription = String.Format(parameterDescription, generalConfigData.Gas12MFCEnable_CalibrationFactorId)
                    saveNotShow = (generalConfigData.Gas12MFCEnable_HasShutOffValve = False And generalConfigData.Gas12MFCEnable_HasSupplyValve = False)
                    result = Not saveNotShow

                Case HConstants.Gas13
                    parameterDescription = String.Format(parameterDescription, generalConfigData.Gas13MFCEnable_CalibrationFactorId)
                    saveNotShow = (generalConfigData.Gas13MFCEnable_HasShutOffValve = False And generalConfigData.Gas13MFCEnable_HasSupplyValve = False)
                    result = Not saveNotShow

                Case HConstants.Gas14
                    parameterDescription = String.Format(parameterDescription, generalConfigData.Gas14MFCEnable_CalibrationFactorId)
                    saveNotShow = (generalConfigData.Gas14MFCEnable_HasShutOffValve = False And generalConfigData.Gas14MFCEnable_HasSupplyValve = False)
                    result = Not saveNotShow

                Case HConstants.Gas15
                    parameterDescription = String.Format(parameterDescription, generalConfigData.Gas15MFCEnable_CalibrationFactorId)
                    saveNotShow = (generalConfigData.Gas15MFCEnable_HasShutOffValve = False And generalConfigData.Gas15MFCEnable_HasSupplyValve = False)
                    result = Not saveNotShow

                Case HConstants.FlowcoolGas, HConstants.BackSideCooling
                    parameterDescription = String.Format(parameterDescription, generalConfigData.FlowCool_Installed_CalibrationFactorId)
                    saveNotShow = (generalConfigData.FlowCool_Installed_HasShutOffValve = False And generalConfigData.FlowCool_Installed_HasSupplyValve = False)
                    result = Not saveNotShow

            End Select
        Catch ex As Exception
            Logger.Error(ex.ToString())
            result = False
        End Try

        Return result
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' check to visible/invisible group parameter in recipe
    ''' </summary>
    Protected Overrides Function CheckingGroupShowInUI(ByVal groupCode As String, ByRef groupSaveButNotShow As Boolean, ByVal value As String, ByVal baseConfigData As BaseConfigurationData) As String
        Return value
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' check to visible/invisible parameter in recipe
    ''' </summary>
    Protected Overrides Function CheckingParameter(ByVal groupCode As String, ByVal parameterName As String, ByRef saveNotShow As Boolean, ByVal baseConfigData As BaseConfigurationData) As Boolean
        Return True
    End Function

    ''' <author>
    '''    	<name> Nguyen Dinh Minh Thi </name>
    '''    	<date> 2016-10-26 </date>
    ''' </author>
    ''' <summary>
    ''' check list of display item
    ''' </summary>
    Protected Overrides Function CheckingListOfDisplayItem(ByVal groupCode As String, ByVal parameterName As String, ByRef name As String, ByRef value As String, ByVal baseConfigData As BaseConfigurationData) As Boolean
        Return True
    End Function
End Class
