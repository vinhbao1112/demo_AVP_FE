Public Class ChamberLib

#Region "Class Support Sort"

    Public Class ReverserDBRecipeTemplateParameter
        Implements IComparer

        ' Calls CaseInsensitiveComparer.Compare with the parameters reversed.
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-08-25</date>
        ''' </author>
        ''' <summary>
        ''' Compare
        ''' </summary>
        ''' <param name="x"></param>
        ''' <param name="y"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            Try
                Dim recipeTemplateParameter1 As DBRecipeTemplateParameter = CType(x, DBRecipeTemplateParameter)
                Dim recipeTemplateParameter2 As DBRecipeTemplateParameter = CType(y, DBRecipeTemplateParameter)
                Return recipeTemplateParameter1.SeqNo < recipeTemplateParameter2.SeqNo
            Catch ex As Exception
                Logger.Error(ex.Message)
            End Try

        End Function 'IComparer.Compare

    End Class 'ReverserDBRecipeTemplateParameter

    Public Class ReverserDBRecipeStep
        Implements IComparer

        ' Calls CaseInsensitiveComparer.Compare with the parameters reversed.
        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2016-01-08 </date>
        ''' </author>
        ''' <summary>
        ''' Compare
        ''' </summary>
        ''' <param name="x"></param>
        ''' <param name="y"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            Try
                Dim recipeStep1 As DBRecipeStep = CType(x, DBRecipeStep)
                Dim recipeStep2 As DBRecipeStep = CType(y, DBRecipeStep)
                Return recipeStep1.SeqNo < recipeStep2.SeqNo
            Catch ex As Exception
                Logger.Error(ex.Message)
            End Try
        End Function 'IComparer.Compare

    End Class 'ReverserDBRecipeStep

#End Region

#Region "Data table"

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' AddDataColumns
    ''' </summary>
    Public Shared Sub AddDataColumns(ByVal dataTable As DataTable, ByVal columnName As String, ByVal columnType As Type, ByVal columnCaption As String)
        Try
            If dataTable.Columns(columnName) Is Nothing Then
                Dim columns As DataColumn = New DataColumn(columnName, columnType)
                columns.Caption = columnCaption
                dataTable.Columns.Add(columns)
            End If
        Catch ex As Exception
            Logger.Error(ex.Message)
        End Try
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' IsHiddenColumn
    ''' </summary>
    Public Shared Function IsHiddenColumn(ByVal columnName As String) As Boolean
        Dim result As Boolean = False

        Try
            Dim Columns As String() = {HConstants.ColumnParameterName, HConstants.ColumnParameterMax, HConstants.ColumnParameterMin, _
                                       HConstants.ColumnDefaultValue, HConstants.ColumnBelongToGroup, HConstants.ColumnUnit, _
                                       HConstants.ColumnUnitShow, HConstants.ColumnParameterCalculate}

            For Each Column As String In Columns
                If columnName = Column Then
                    result = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            Logger.Error(ex.Message)
        End Try

        Return result
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' Get DataTable of recipe
    ''' </summary>>
    Public Shared Function CreateDataTableRecipe(ByVal dbRecipe As DBRecipe) As DataTable
        Dim dataTable As New DataTable()

        Try
            If dbRecipe Is Nothing Then
                Exit Try
            End If

            Dim drPulse As DataRow = Nothing ''hold Pulse Row to reorder
            Dim drPulseFrequency As DataRow = Nothing ''hold Pulse Row to reorder
            Dim drPulseDuty As DataRow = Nothing ''hold Pulse Row to reorder
            Dim drMagnetron As DataRow = Nothing ''hold MagnatronState Row to reorder
            'Dim drRampTime As DataRow = Nothing ''hold Pulse Row to reorder
            'Begin Add Columns
            AddDataColumns(dataTable, HConstants.ColumnParameters, GetType(String), HConstants.ColumnParameters)
            AddDataColumns(dataTable, HConstants.ColumnParameterName, GetType(String), HConstants.ColumnParameterName)
            AddDataColumns(dataTable, HConstants.ColumnParameterMax, GetType(Double), HConstants.ColumnParameterMax)
            AddDataColumns(dataTable, HConstants.ColumnParameterMin, GetType(Double), HConstants.ColumnParameterMin)
            AddDataColumns(dataTable, HConstants.ColumnDefaultValue, GetType(String), HConstants.ColumnDefaultValue)
            AddDataColumns(dataTable, HConstants.ColumnBelongToGroup, GetType(String), HConstants.ColumnBelongToGroup)
            AddDataColumns(dataTable, HConstants.ColumnUnit, GetType(String), HConstants.ColumnUnit)
            AddDataColumns(dataTable, HConstants.ColumnUnitShow, GetType(String), HConstants.ColumnUnitShow)
            AddDataColumns(dataTable, HConstants.ColumnParameterCalculate, GetType(String), HConstants.ColumnParameterCalculate)

            Dim listRecipeSteps As ArrayList = dbRecipe.ListOfRecipeSteps
            If listRecipeSteps.Count > 0 Then
                listRecipeSteps.Sort(New ReverserDBRecipeStep())

                For i As Integer = 1 To listRecipeSteps.Count
                    AddDataColumns(dataTable, "Step" + i.ToString(), GetType(String), "Step-" + i.ToString())
                Next
            Else
                AddDataColumns(dataTable, "Step1", GetType(String), "Step-1")
            End If
            'End Add Columns

            'Begin Add Data
            Dim listRecipeTemplateGroupParameters As ArrayList = dbRecipe.ListOfRecipeTemplateGroupParameters

            For Each groupParameter As DBRecipeTemplateGroupParameters In listRecipeTemplateGroupParameters
                Dim drGroup As DataRow = Nothing
                If groupParameter.IsGroup Then
                    drGroup = dataTable.NewRow()
                    drGroup(HConstants.ColumnParameters) = groupParameter.GroupName
                    drGroup(HConstants.ColumnParameterName) = groupParameter.GroupCode
                    drGroup(HConstants.ColumnDefaultValue) = String.Empty
                    drGroup(HConstants.ColumnBelongToGroup) = String.Empty
                    drGroup(HConstants.ColumnUnit) = String.Empty
                    drGroup(HConstants.ColumnUnitShow) = String.Empty
                    drGroup(HConstants.ColumnParameterCalculate) = String.Empty
                    dataTable.Rows.Add(drGroup)
                End If

                Dim listParameters As ArrayList = groupParameter.ListOfParameters
                listParameters.Sort(New ReverserDBRecipeTemplateParameter())

                For Each parameter As DBRecipeTemplateParameter In listParameters
                    If parameter IsNot Nothing AndAlso parameter.ShowUI Then
                        Dim drDetail As DataRow = dataTable.NewRow()
                        drDetail(HConstants.ColumnParameters) = parameter.Description
                        drDetail(HConstants.ColumnParameterName) = parameter.Name
                        drDetail(HConstants.ColumnParameterMax) = parameter.Max
                        drDetail(HConstants.ColumnParameterMin) = parameter.Min
                        drDetail(HConstants.ColumnDefaultValue) = parameter.DefaultValue
                        drDetail(HConstants.ColumnBelongToGroup) = IIf(drGroup Is Nothing, String.Empty, groupParameter.GroupCode)
                        drDetail(HConstants.ColumnUnit) = parameter.Unit
                        drDetail(HConstants.ColumnUnitShow) = parameter.UnitShow
                        drDetail(HConstants.ColumnParameterCalculate) = String.Empty

                        Dim Index As Integer = 1
                        If listRecipeSteps.Count > 0 Then
                            For Each recipeStep As DBRecipeStep In listRecipeSteps
                                Dim Value As String = GetValueOfRecipeStep(recipeStep, groupParameter.GroupCode, parameter.Name)
                                ' If Value is not exist in recipe ("Nothing"),
                                ' set "0" if value type is Number, 
                                ' set "No" if value type is Boolean, other set DefaultValue tag
                                If Value Is Nothing Then
                                    If String.Compare(parameter.Unit, "Number", True) = 0 Then
                                        drDetail("Step" + Index.ToString()) = "0"
                                    Else
                                        drDetail("Step" + Index.ToString()) = parameter.DefaultValue
                                    End If
                                ElseIf Value = String.Empty Then
                                    drDetail("Step" + Index.ToString()) = parameter.DefaultValue
                                Else
                                    drDetail("Step" + Index.ToString()) = Value
                                End If
                                Index += 1
                            Next
                        Else
                            drDetail("Step" + Index.ToString()) = parameter.DefaultValue
                        End If

                        If dbRecipe.RecipeDCPVD Then
                            If (parameter.Name = HConstants.Pulse) Then
                                drPulse = drDetail
                            ElseIf (parameter.Name = HConstants.PulseFrequency) Then
                                drPulseFrequency = drDetail
                            ElseIf (parameter.Name = HConstants.PulseWidth) Then
                                drPulseDuty = drDetail
                                '    ElseIf (Parameter.Name = "RampTime") Then
                                '        drRampTime = drDetail
                            Else
                                dataTable.Rows.Add(drDetail)
                            End If
                        Else
                            dataTable.Rows.Add(drDetail)
                        End If

                    End If
                Next
            Next
            'End Add Data

            If dbRecipe.RecipeDCPVD Then ''reorder
                Dim index As Integer = 0
                For Each row As DataRow In dataTable.Rows
                    If row(HConstants.ColumnParameterName).ToString().Contains(HConstants.TargetPower) Then
                        If drPulse IsNot Nothing Then
                            index += 1
                            dataTable.Rows.InsertAt(drPulse, index)
                        End If
                        If drPulseFrequency IsNot Nothing Then
                            index += 1
                            dataTable.Rows.InsertAt(drPulseFrequency, index)
                        End If
                        If drPulseDuty IsNot Nothing Then
                            index += 1
                            dataTable.Rows.InsertAt(drPulseDuty, index)
                        End If
                        Exit For
                    Else
                        index += 1
                    End If
                Next
            End If

        Catch ex As Exception
            Logger.Error(ex.Message)
            dataTable = Nothing
        End Try

        Return dataTable
    End Function

#End Region

#Region "support function"
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' Get Value that support Get step value exactly 
    ''' </summary>
    Public Shared Function GetValueOfRecipeStep(ByVal recipeStep As DBRecipeStep, ByVal groupCode As String, ByVal parameterName As String) As String
        Dim result As String = Nothing

        Try
            If recipeStep Is Nothing Then
                Exit Try
            End If

            For Each groupParameter As DBRecipeGroupParameters In recipeStep.ListOfGroupParameters
                For Each parameter As DBRecipeParameter In groupParameter.ListOfParameters
                    If parameter.Name = parameterName AndAlso groupParameter.GroupCode = groupCode Then
                        result = parameter.Value
                        Exit Try
                    End If
                Next
            Next
        Catch ex As Exception
            Logger.Error(ex.Message)
        End Try

        Return result
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-15 </date>
    ''' </author>
    ''' <summary>
    ''' Get List of Param to Show on GUI (all display value)
    ''' </summary>
    Public Shared Function GetListOfRecipeTemplateDisplayItems(ByVal selectedRecipe As DBRecipe) As Dictionary(Of String, List(Of KeyValuePair(Of String, String)))
        Dim listOfDisplayItems As New Dictionary(Of String, List(Of KeyValuePair(Of String, String)))

        Try
            If selectedRecipe Is Nothing Then
                Exit Try
            End If

            For Each groupParameter As DBRecipeTemplateGroupParameters In selectedRecipe.ListOfRecipeTemplateGroupParameters
                For Each parameter As DBRecipeTemplateParameter In groupParameter.ListOfParameters
                    If parameter.DisplayItems IsNot Nothing AndAlso parameter.DisplayItems.Count > 0 Then
                        '2014-03-17 Tin Pham: key = PVD.ProcessControl.PowerDown, PVD6S.ProcessControl.PowerDown, ...
                        Dim keyParameterName As String = selectedRecipe.ChamberType & "." & groupParameter.GroupCode & "." & parameter.Name

                        If Not (listOfDisplayItems.ContainsKey(keyParameterName)) Then
                            listOfDisplayItems.Add(keyParameterName, parameter.DisplayItems)
                        End If
                    End If
                Next
            Next
        Catch ex As Exception
            Logger.Error(ex.Message)
        End Try

        Return listOfDisplayItems
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-15 </date>
    ''' </author>
    ''' <summary>
    ''' Convert Value from GUI to Real value (eg: On/Off to True/False) before saving to file/ showing to GUI
    ''' </summary>
    Public Shared Function ConvertToRealValue(ByVal selectedRecipe As DBRecipe, ByVal loadFromFile As Boolean) As Boolean
        Dim result As Boolean = True

        Try
            If selectedRecipe Is Nothing Then
                result = False
                Exit Try
            End If

            Dim listOfDisplayItems As Dictionary(Of String, List(Of KeyValuePair(Of String, String))) = GetListOfRecipeTemplateDisplayItems(selectedRecipe)

            For Each recipeStep As DBRecipeStep In selectedRecipe.ListOfRecipeSteps

                For Each recipeGroupParameter As DBRecipeGroupParameters In recipeStep.ListOfGroupParameters

                    For Each recipeParameter As DBRecipeParameter In recipeGroupParameter.ListOfParameters

                        '2014-03-17 Tin Pham: key = PVD.ProcessControl.PowerDown, PVD6S.ProcessControl.PowerDown, ...
                        Dim keyParameterName As String = selectedRecipe.ChamberType & "." & recipeGroupParameter.GroupCode & "." & recipeParameter.Name

                        If listOfDisplayItems.ContainsKey(keyParameterName) And Not loadFromFile Then
                            Dim realValue As KeyValuePair(Of String, String) = Nothing

                            For Each realValue In listOfDisplayItems(keyParameterName)
                                If realValue.Key = recipeParameter.Value Then
                                    recipeParameter.Value = realValue.Value
                                End If
                            Next

                        ElseIf listOfDisplayItems.ContainsKey(keyParameterName) Then
                            Dim realValue As KeyValuePair(Of String, String) = Nothing

                            For Each realValue In listOfDisplayItems(keyParameterName)
                                If realValue.Value.ToLower() = recipeParameter.Value.ToLower() Then
                                    recipeParameter.Value = realValue.Key
                                End If
                            Next
                        End If
                    Next

                Next

            Next
        Catch ex As Exception
            Logger.Error(ex.Message)
            result = False
        End Try

        Return result
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-15 </date>
    ''' </author>
    ''' <summary>
    ''' check Param for Recipe : show or hide in DataGrid and in TreeView
    ''' </summary>
    Public Shared Function CheckParameterRecipeVisible(ByVal selectedRecipe As DBRecipe, ByVal groupCode As String, ByVal parameterName As String) As Boolean
        Dim result As Boolean = True

        Try
            If selectedRecipe Is Nothing Then
                Exit Try
            End If

            For Each groupParameter As DBRecipeTemplateGroupParameters In selectedRecipe.ListOfRecipeTemplateGroupParameters
                If groupParameter.SaveNotShow AndAlso parameterName.Contains(groupParameter.GroupCode) Then
                    result = False
                    Exit Try
                End If

                For Each parameter As DBRecipeTemplateParameter In groupParameter.ListOfParameters
                    If parameterName = parameter.Name AndAlso groupCode = groupParameter.GroupCode Then
                        result = Not (parameter.SaveNotShow)
                        Exit Try
                    End If
                Next
            Next
        Catch ex As Exception
            Logger.Error(ex.Message)
        End Try

        Return result
    End Function

#End Region

End Class
